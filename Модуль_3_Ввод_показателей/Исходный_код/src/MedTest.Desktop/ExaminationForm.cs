using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>
/// Ввод показателей одного обследования — давление, пульс, анализы.
/// Пустые строки не сохраняются; оценка «норма / выше / ниже» видна сразу при вводе.
/// </summary>
public partial class ExaminationForm : Form
{
    private readonly AppSession? session;
    private readonly Patient? patient;
    private readonly Examination? existing;
    private readonly List<Indicator> rows = [];
    private bool saving;

    public ExaminationForm()
    {
        InitializeComponent(); Theme.Apply(this);
        // Theme.Apply makes every grid a read-only list; here only the value column is typed into.
        valuesGrid.ReadOnly = false;
        foreach (DataGridViewColumn column in valuesGrid.Columns) { column.ReadOnly = column != valueColumn; column.SortMode = DataGridViewColumnSortMode.NotSortable; }
        valuesGrid.SelectionMode = DataGridViewSelectionMode.CellSelect;
        valuesGrid.EditMode = DataGridViewEditMode.EditOnEnter;
        valueColumn.DefaultCellStyle.Font = Theme.CellBoldFont;
        valueColumn.DefaultCellStyle.BackColor = Theme.Expanded;
    }

    /// <summary>New examination (existing = null) or correction of a saved one.</summary>
    public ExaminationForm(AppSession session, Patient patient, IReadOnlyList<Indicator> indicators, Examination? existing, bool readOnly = false) : this()
    {
        this.session = session; this.patient = patient; this.existing = existing;
        titleLabel.Text = readOnly ? "Обследование" : existing == null ? "Новое обследование" : "Исправление обследования";
        Text = "МедТест — " + titleLabel.Text.ToLowerInvariant();
        patientLabel.Text = patient.FullName + "   ·   " + patient.CardNumber + "   ·   " + Ages.Text(patient.AgeOn(DateOnly.FromDateTime(session.Db.Now()))) + ", " + patient.SexTitle.ToLowerInvariant();
        var at = existing?.TakenAt ?? session.Db.Now();
        datePicker.MaxDate = session.Db.Now().Date; datePicker.Value = at.Date;
        timePicker.Value = new DateTime(2000, 1, 1, at.Hour, at.Minute, 0);
        commentBox.Text = existing?.Comment ?? "";
        var recorded = existing?.Values.ToDictionary(v => v.IndicatorId, v => v.Value) ?? [];
        foreach (var i in indicators.Where(i => i.IsActive || recorded.ContainsKey(i.Id)).OrderBy(i => i.SortOrder).ThenBy(i => i.Name))
        {
            rows.Add(i);
            int r = valuesGrid.Rows.Add(i.Group, i.Name, recorded.TryGetValue(i.Id, out var v) ? i.Format(v) : "", i.Unit, i.RangeText, "");
            valuesGrid.Rows[r].Tag = i;
        }
        UpdateSummary();
        if (readOnly)
        {
            // Viewing an examination entered by another doctor (or by an administrator).
            valueColumn.ReadOnly = true; valueColumn.DefaultCellStyle.BackColor = Theme.Surface;
            commentBox.ReadOnly = true; datePicker.Enabled = false; timePicker.Enabled = false;
            saveButton.Visible = false; clearButton.Visible = false; cancelButton.Text = "Закрыть";
            messageLabel.ForeColor = Theme.Muted;
            messageLabel.Text = "Внёс " + existing?.DoctorName + ". Исправить может только он.";
            IsReadOnly = true;
        }
    }

    public bool IsReadOnly { get; private set; }

    /// <summary>The cursor starts in the first value cell.</summary>
    protected override void OnShown(EventArgs e)
    {
        base.OnShown(e);
        if (valuesGrid.Rows.Count == 0 || IsReadOnly) return;
        valuesGrid.Focus();
        valuesGrid.CurrentCell = valuesGrid.Rows[0].Cells[valueColumn.Index];
    }

    /// <summary>State of one row: empty, a wrong number, outside the input range, or an assessed value.</summary>
    internal (bool Empty, decimal? Value, string? Problem) Read(int row)
    {
        var i = rows[row];
        var text = valuesGrid.Rows[row].Cells[valueColumn.Index].Value?.ToString();
        if (string.IsNullOrWhiteSpace(text)) return (true, null, null);
        if (!Texts.TryNumber(text, out var value)) return (false, null, "не число");
        if (value < i.ValidMin || value > i.ValidMax) return (false, value, "вне " + i.Format(i.ValidMin) + "–" + i.Format(i.ValidMax));
        return (false, value, null);
    }

    private void UpdateSummary()
    {
        int filled = 0, outside = 0, wrong = 0;
        for (int r = 0; r < rows.Count; r++)
        {
            var (empty, value, problem) = Read(r);
            if (empty) continue;
            if (problem != null) { wrong++; continue; }
            filled++;
            if (Statistics.Reference(value!.Value, rows[r]).Status != RefStatus.Normal) outside++;
        }
        summaryLabel.Text = filled == 0 && wrong == 0 ? "Пустые строки не сохраняются."
            : $"Заполнено: {filled}" + (outside > 0 ? $", вне нормы: {outside}" : ", все в норме") + (wrong > 0 ? $", с ошибкой: {wrong}" : "");
        summaryLabel.ForeColor = wrong > 0 ? Theme.Rust : Theme.Muted;
        valuesGrid.InvalidateColumn(statusColumn.Index);
    }

    private void ValuesChanged(object? sender, DataGridViewCellEventArgs e) { if (e.RowIndex >= 0) UpdateSummary(); }

    /// <summary>Group name only on the first row of a group; the status column is drawn as a tag.</summary>
    private void ValuesPainting(object? sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= rows.Count) return;
        int band = e.CellBounds.Height;
        if (e.ColumnIndex == groupColumn.Index)
        {
            bool first = e.RowIndex == 0 || rows[e.RowIndex - 1].Group != rows[e.RowIndex].Group;
            GridPaint.Text(e, first ? rows[e.RowIndex].Group : "", Theme.CellBoldFont, Theme.Muted, band);
        }
        else if (e.ColumnIndex == statusColumn.Index)
        {
            var (empty, value, problem) = Read(e.RowIndex);
            if (empty) { GridPaint.Text(e, "", Theme.CellFont, Theme.Muted, band); return; }
            var tag = problem != null ? new Theme.StatusTag("Ошибка: " + problem, Theme.Status(RefStatus.Above).Back, Theme.Rust)
                : Theme.Status(Statistics.Reference(value!.Value, rows[e.RowIndex]).Status);
            GridPaint.Tag(e, tag, band);
        }
    }

    private void ClearClick(object? sender, EventArgs e)
    {
        valuesGrid.EndEdit();
        foreach (DataGridViewRow row in valuesGrid.Rows) row.Cells[valueColumn.Index].Value = "";
        UpdateSummary();
    }

    private async void SaveClick(object? sender, EventArgs e)
    {
        if (saving || session == null || patient == null) return;
        valuesGrid.EndEdit();
        var values = new List<MeasuredValue>();
        for (int r = 0; r < rows.Count; r++)
        {
            var (empty, value, problem) = Read(r);
            if (empty) continue;
            if (problem != null)
            {
                Error("«" + rows[r].Name + "»: " + (problem == "не число" ? "введите число, например " + rows[r].Format(rows[r].RefMin) + "."
                    : MedTest.Data.Rules.Sentence("значение " + problem + " " + rows[r].Unit) + " Проверьте ввод."));
                valuesGrid.CurrentCell = valuesGrid.Rows[r].Cells[valueColumn.Index];
                return;
            }
            values.Add(new(rows[r].Id, value!.Value));
        }
        if (values.Count == 0) { Error("Введите хотя бы один показатель."); return; }
        var takenAt = datePicker.Value.Date + timePicker.Value.TimeOfDay;
        saving = true; saveButton.Enabled = false; messageLabel.ForeColor = Theme.Muted; messageLabel.Text = "Сохранение…";
        var (saved, error) = await AppSession.Try(() => session.Db.SaveExaminationAsync(session.Actor, existing?.Id, new ExaminationInput(patient.Id, takenAt, commentBox.Text, values)));
        saving = false;
        if (IsDisposed) return;
        saveButton.Enabled = true;
        if (error != null) { Error(error); return; }
        Saved = saved;
        DialogResult = DialogResult.OK; Close();
    }

    /// <summary>The examination as stored, after a successful save.</summary>
    public Examination? Saved { get; private set; }

    private void Error(string text) { messageLabel.ForeColor = Theme.Rust; messageLabel.Text = text; }
}
