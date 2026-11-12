using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>
/// Карта пациента справа от списка — история обследований и сведения о пациенте. Отсюда вводятся обследования.
/// </summary>
public partial class PatientCard : UserControl
{
    private AppSession? session;
    private Patient? patient;
    private IReadOnlyList<Indicator> indicators = [];
    private Dictionary<int, IndicatorStats> stats = [];
    private List<Examination> exams = [];
    private bool loading;

    /// <summary>Raised after the patient or an examination was changed, so the list can be refreshed.</summary>
    public event EventHandler? Changed;
    /// <summary>Text for the status line of the main window; the flag marks an error.</summary>
    public event Action<string, bool>? Message;

    public PatientCard()
    {
        InitializeComponent();
        Theme.Apply(this);
        foreach (DataGridViewColumn c in historyGrid.Columns) c.SortMode = DataGridViewColumnSortMode.NotSortable;
        ShowEmpty();
    }

    public Patient? Patient => patient;
    public IReadOnlyList<Examination> Examinations => exams;

    private void ShowEmpty()
    {
        patient = null; exams = [];
        nameLabel.Text = "Пациент не выбран"; subLabel.Text = "Выберите строку в списке слева.";
        statusLabel.Visible = false; actions.Visible = false; tabs.Visible = false; footerLabel.Text = "";
    }

    /// <summary>Shows a patient. Statistics come from the main window, computed over all patients.</summary>
    public async Task LoadAsync(AppSession session, int? patientId, IReadOnlyList<Indicator> indicators, IReadOnlyDictionary<int, IndicatorStats> stats)
    {
        this.session = session; this.indicators = indicators; this.stats = stats.ToDictionary();
        if (patientId == null) { ShowEmpty(); return; }
        loading = true;
        try
        {
            var (p, error) = await AppSession.Try(() => session.Db.GetPatientAsync(session.Actor, patientId.Value));
            if (IsDisposed) return;
            if (p == null) { ShowEmpty(); Message?.Invoke(error ?? "Пациент не найден.", true); return; }
            var (list, examError) = await AppSession.Try(() => session.Db.ListExaminationsAsync(session.Actor, p.Id));
            if (IsDisposed) return;
            if (list == null) { Message?.Invoke(examError!, true); list = []; }
            patient = p; exams = list;
            Render();
        }
        finally { loading = false; }
    }

    private Indicator? Find(int id) => indicators.FirstOrDefault(i => i.Id == id);

    /// <summary>The latest value of every measured indicator, in the order of the directory.</summary>
    public List<(Indicator Indicator, decimal Value, DateTime At)> LatestValues() =>
        exams.SelectMany(e => e.Values.Select(v => (v.IndicatorId, v.Value, e.TakenAt, e.Id)))
            .GroupBy(x => x.IndicatorId)
            .Select(g => g.OrderByDescending(x => x.TakenAt).ThenByDescending(x => x.Id).First())
            .Select(x => (Indicator: Find(x.IndicatorId), x.Value, x.TakenAt))
            .Where(x => x.Indicator != null)
            .Select(x => (x.Indicator!, x.Value, x.TakenAt))
            .OrderBy(x => x.Item1.SortOrder).ToList();

    private void Render()
    {
        if (patient == null || session == null) return;
        var today = DateOnly.FromDateTime(session.Db.Now());
        nameLabel.Text = patient.FullName;
        subLabel.Text = patient.CardNumber + "  ·  " + Ages.Text(patient.AgeOn(today)) + "  ·  " + patient.SexTitle.ToLowerInvariant() + (patient.IsArchived ? "  ·  в архиве" : "");
        var latest = LatestValues();
        int outside = latest.Count(x => Statistics.Reference(x.Value, x.Indicator).Status != RefStatus.Normal);
        var tag = Theme.Deviations(outside, exams.Count);
        statusLabel.Text = tag.Text; statusLabel.BackColor = tag.Back; statusLabel.ForeColor = tag.Fore; statusLabel.Visible = true;
        actions.Visible = true; tabs.Visible = true;

        archiveButton.Text = patient.IsArchived ? "Вернуть из архива" : "В архив";
        deleteButton.Visible = session.IsAdmin && exams.Count == 0;
        newExamButton.Visible = session.IsDoctor;
        newExamButton.Enabled = !patient.IsArchived;

        historyGrid.Rows.Clear();
        foreach (var e in exams)
        {
            int off = e.Values.Count(v => Find(v.IndicatorId) is { } i && Statistics.Reference(v.Value, i).Status != RefStatus.Normal);
            int r = historyGrid.Rows.Add(Texts.DateTime(e.TakenAt), e.DoctorName, e.Values.Count, off == 0 ? "—" : off.ToString(), e.Comment ?? "");
            historyGrid.Rows[r].Tag = e;
        }
        UpdateHistoryButtons();

        birthValue.Text = Texts.Date(patient.BirthDate) + " (" + Ages.Text(patient.AgeOn(today)) + ")";
        cardValue.Text = patient.CardNumber; sexValue.Text = patient.SexTitle;
        phoneValue.Text = patient.Phone ?? "не указан"; noteValue.Text = patient.Note ?? "—";
        stateValue.Text = patient.IsArchived ? "В архиве: новые обследования не вносятся" : "Наблюдается";
        footerLabel.Text = exams.Count == 0 ? "Обследований пока нет." : "Обследований: " + exams.Count + ", последнее " + Texts.DateTime(exams[0].TakenAt) + ".";
    }


    /// <summary>The selected examination; the newest one while nothing is selected.</summary>
    private Examination? SelectedExam => historyGrid.CurrentRow?.Tag as Examination ?? (historyGrid.Rows.Count > 0 ? historyGrid.Rows[0].Tag as Examination : null);

    private void UpdateHistoryButtons()
    {
        var e = SelectedExam;
        bool own = session?.IsDoctor == true && e != null && e.DoctorId == session.Actor.Id;
        editExamButton.Text = own ? "Исправить" : "Открыть";
        editExamButton.Enabled = e != null;
        deleteExamButton.Visible = session?.IsDoctor == true;
        deleteExamButton.Enabled = own;
    }

    private void HistorySelectionChanged(object? sender, EventArgs e) { if (!loading) UpdateHistoryButtons(); }
    private void HistoryDoubleClick(object? sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) editExamButton.PerformClick(); }

    private async void NewExamClick(object? sender, EventArgs e)
    {
        if (session == null || patient == null) return;
        using var form = new ExaminationForm(session, patient, indicators, null);
        if (form.ShowDialog(FindForm()) == DialogResult.OK) await AfterChange("Обследование сохранено.");
    }

    private async void EditExamClick(object? sender, EventArgs e)
    {
        if (session == null || patient == null || SelectedExam is not { } exam) return;
        bool own = session.IsDoctor && exam.DoctorId == session.Actor.Id;
        using var form = new ExaminationForm(session, patient, indicators, exam, readOnly: !own);
        if (form.ShowDialog(FindForm()) == DialogResult.OK && own) await AfterChange("Обследование исправлено.");
    }

    private async void DeleteExamClick(object? sender, EventArgs e)
    {
        if (session == null || SelectedExam is not { } exam) return;
        if (MessageBox.Show(FindForm(), "Удалить обследование от " + Texts.DateTime(exam.TakenAt) + "? Значения показателей будут удалены.", "МедТест",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
        var error = await AppSession.Try(() => session.Db.DeleteExaminationAsync(session.Actor, exam.Id));
        if (error != null) { Message?.Invoke(error, true); return; }
        await AfterChange("Обследование удалено.");
    }

    private async void EditPatientClick(object? sender, EventArgs e)
    {
        if (loading || session == null || patient == null) return;
        if (PatientForm.Edit(FindForm(), session, patient) is not null) await AfterChange("Данные пациента сохранены.");
    }

    private async void ArchiveClick(object? sender, EventArgs e)
    {
        if (loading || session == null || patient == null) return;
        bool archive = !patient.IsArchived;
        var error = await AppSession.Try(() => session.Db.SetArchivedAsync(session.Actor, patient.Id, archive));
        if (error != null) { Message?.Invoke(error, true); return; }
        await AfterChange(archive ? "Пациент переведён в архив." : "Пациент возвращён из архива.");
    }

    private async void DeleteClick(object? sender, EventArgs e)
    {
        if (session == null || patient == null) return;
        if (MessageBox.Show(FindForm(), "Удалить пациента " + patient.FullName + " (" + patient.CardNumber + ")? Это нельзя отменить.", "МедТест",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
        var error = await AppSession.Try(() => session.Db.DeletePatientAsync(session.Actor, patient.Id));
        if (error != null) { Message?.Invoke(error, true); return; }
        ShowEmpty();
        Message?.Invoke("Пациент удалён.", false);
        Changed?.Invoke(this, EventArgs.Empty);
    }


    /// <summary>The main window reloads the list, recomputes the statistics and then reloads this card.</summary>
    private Task AfterChange(string text)
    {
        Message?.Invoke(text, false);
        Changed?.Invoke(this, EventArgs.Empty);
        return Task.CompletedTask;
    }
}
