using System.Globalization;
using MedTest.Core;

namespace MedTest.Desktop;

/// <summary>
/// Показатель справочника: код, группа, название, единица, справочная норма и допустимый диапазон ввода,
/// точность и порядок вывода. Доступно администратору.
/// </summary>
public partial class IndicatorForm : Form
{
    private readonly AppSession? session;
    private readonly Indicator? indicator;
    private bool saving;

    public IndicatorForm() { InitializeComponent(); Theme.Apply(this); }

    public IndicatorForm(AppSession session, Indicator? indicator) : this()
    {
        this.session = session; this.indicator = indicator;
        if (indicator == null) { groupBox.Text = "Биохимия крови"; return; }
        titleLabel.Text = "Показатель «" + indicator.Name + "»";
        codeBox.Text = indicator.Code; groupBox.Text = indicator.Group; nameBox.Text = indicator.Name; unitBox.Text = indicator.Unit;
        refMinBox.Text = N(indicator.RefMin); refMaxBox.Text = N(indicator.RefMax);
        validMinBox.Text = N(indicator.ValidMin); validMaxBox.Text = N(indicator.ValidMax);
        decimalsBox.Value = indicator.Decimals; sortBox.Value = Math.Clamp(indicator.SortOrder, 0, 9999);
        activeCheck.Checked = indicator.IsActive;
    }

    private static string N(decimal v) => v.ToString("0.###", CultureInfo.GetCultureInfo("ru-RU"));

    /// <summary>Opens the form; returns true when the indicator was saved.</summary>
    public static bool Edit(IWin32Window? owner, AppSession session, Indicator? indicator)
    {
        using var form = new IndicatorForm(session, indicator);
        return form.ShowDialog(owner) == DialogResult.OK;
    }

    private async void SaveClick(object? sender, EventArgs e)
    {
        if (saving || session == null) return;
        foreach (var (box, caption) in new (Control, string)[] { (codeBox, "Код"), (groupBox, "Группа"), (nameBox, "Название") })
            if (box.Text.Trim().Length == 0) { Error("Заполните поле «" + caption + "».", box); return; }
        decimal?[] numbers = new decimal?[4];
        var boxes = new (TextBox Box, string Caption)[] { (refMinBox, "Норма: от"), (refMaxBox, "Норма: до"), (validMinBox, "Допустимый минимум"), (validMaxBox, "Допустимый максимум") };
        for (int i = 0; i < boxes.Length; i++)
        {
            if (!Texts.TryNumber(boxes[i].Box.Text, out var v)) { Error("«" + boxes[i].Caption + "»: введите число, например 3,5.", boxes[i].Box); return; }
            numbers[i] = v;
        }
        var input = new IndicatorInput(codeBox.Text.Trim(), groupBox.Text.Trim(), nameBox.Text.Trim(), unitBox.Text.Trim(),
            numbers[0]!.Value, numbers[1]!.Value, numbers[2]!.Value, numbers[3]!.Value, (int)decimalsBox.Value, (int)sortBox.Value, activeCheck.Checked);
        saving = true; saveButton.Enabled = false; errorLabel.ForeColor = Theme.Muted; errorLabel.Text = "Сохранение…";
        var (_, error) = await AppSession.Try(() => session.Db.SaveIndicatorAsync(session.Actor, indicator?.Id, input));
        saving = false;
        if (IsDisposed) return;
        saveButton.Enabled = true;
        if (error != null) { Error(error, null); return; }
        DialogResult = DialogResult.OK; Close();
    }

    /// <summary>The message about a field disappears as soon as the user starts correcting it.</summary>
    private void FieldChanged(object? sender, EventArgs e) { if (!saving && errorLabel.ForeColor == Theme.Rust) errorLabel.Text = ""; }

    private void Error(string text, Control? field)
    {
        errorLabel.ForeColor = Theme.Rust; errorLabel.Text = text;
        field?.Focus();
    }
}
