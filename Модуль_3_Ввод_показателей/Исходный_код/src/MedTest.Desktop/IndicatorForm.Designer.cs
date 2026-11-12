#nullable enable
namespace MedTest.Desktop;

partial class IndicatorForm
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.TableLayoutPanel layout = null!, fieldsPanel = null!;
    private System.Windows.Forms.FlowLayoutPanel buttons = null!;
    private System.Windows.Forms.Label titleLabel = null!, errorLabel = null!, codeLabel = null!, groupLabel = null!, nameLabel = null!, unitLabel = null!, refMinLabel = null!, refMaxLabel = null!, validMinLabel = null!, validMaxLabel = null!, decimalsLabel = null!, sortLabel = null!;
    private System.Windows.Forms.TextBox codeBox = null!, nameBox = null!, unitBox = null!, refMinBox = null!, refMaxBox = null!, validMinBox = null!, validMaxBox = null!;
    private System.Windows.Forms.ComboBox groupBox = null!;
    private System.Windows.Forms.NumericUpDown decimalsBox = null!, sortBox = null!;
    private System.Windows.Forms.CheckBox activeCheck = null!;
    private UiButton saveButton = null!, cancelButton = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.titleLabel = new System.Windows.Forms.Label();
        this.fieldsPanel = new System.Windows.Forms.TableLayoutPanel();
        this.codeLabel = new System.Windows.Forms.Label();
        this.groupLabel = new System.Windows.Forms.Label();
        this.nameLabel = new System.Windows.Forms.Label();
        this.unitLabel = new System.Windows.Forms.Label();
        this.refMinLabel = new System.Windows.Forms.Label();
        this.refMaxLabel = new System.Windows.Forms.Label();
        this.validMinLabel = new System.Windows.Forms.Label();
        this.validMaxLabel = new System.Windows.Forms.Label();
        this.decimalsLabel = new System.Windows.Forms.Label();
        this.sortLabel = new System.Windows.Forms.Label();
        this.codeBox = new System.Windows.Forms.TextBox();
        this.groupBox = new System.Windows.Forms.ComboBox();
        this.nameBox = new System.Windows.Forms.TextBox();
        this.unitBox = new System.Windows.Forms.TextBox();
        this.refMinBox = new System.Windows.Forms.TextBox();
        this.refMaxBox = new System.Windows.Forms.TextBox();
        this.validMinBox = new System.Windows.Forms.TextBox();
        this.validMaxBox = new System.Windows.Forms.TextBox();
        this.decimalsBox = new System.Windows.Forms.NumericUpDown();
        this.sortBox = new System.Windows.Forms.NumericUpDown();
        this.activeCheck = new System.Windows.Forms.CheckBox();
        this.errorLabel = new System.Windows.Forms.Label();
        this.buttons = new System.Windows.Forms.FlowLayoutPanel();
        this.saveButton = new MedTest.Desktop.UiButton();
        this.cancelButton = new MedTest.Desktop.UiButton();
        this.layout.SuspendLayout();
        this.fieldsPanel.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.decimalsBox)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.sortBox)).BeginInit();
        this.buttons.SuspendLayout();
        this.SuspendLayout();
        //
        // layout: title, fields, error line, buttons
        //
        this.layout.ColumnCount = 1;
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.Controls.Add(this.titleLabel, 0, 0);
        this.layout.Controls.Add(this.fieldsPanel, 0, 1);
        this.layout.Controls.Add(this.errorLabel, 0, 2);
        this.layout.Controls.Add(this.buttons, 0, 3);
        this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.layout.Name = "layout";
        this.layout.Padding = new System.Windows.Forms.Padding(28, 22, 28, 18);
        this.layout.RowCount = 4;
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
        //
        // titleLabel
        //
        this.titleLabel.AutoEllipsis = true;
        this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.titleLabel.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Text = "Новый показатель";
        this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // fieldsPanel: two columns, a caption above every field
        //
        this.fieldsPanel.ColumnCount = 2;
        this.fieldsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.fieldsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.fieldsPanel.Controls.Add(this.codeLabel, 0, 0);
        this.fieldsPanel.Controls.Add(this.codeBox, 0, 1);
        this.fieldsPanel.Controls.Add(this.groupLabel, 1, 0);
        this.fieldsPanel.Controls.Add(this.groupBox, 1, 1);
        this.fieldsPanel.Controls.Add(this.nameLabel, 0, 2);
        this.fieldsPanel.Controls.Add(this.nameBox, 0, 3);
        this.fieldsPanel.Controls.Add(this.unitLabel, 1, 2);
        this.fieldsPanel.Controls.Add(this.unitBox, 1, 3);
        this.fieldsPanel.Controls.Add(this.refMinLabel, 0, 4);
        this.fieldsPanel.Controls.Add(this.refMinBox, 0, 5);
        this.fieldsPanel.Controls.Add(this.refMaxLabel, 1, 4);
        this.fieldsPanel.Controls.Add(this.refMaxBox, 1, 5);
        this.fieldsPanel.Controls.Add(this.validMinLabel, 0, 6);
        this.fieldsPanel.Controls.Add(this.validMinBox, 0, 7);
        this.fieldsPanel.Controls.Add(this.validMaxLabel, 1, 6);
        this.fieldsPanel.Controls.Add(this.validMaxBox, 1, 7);
        this.fieldsPanel.Controls.Add(this.decimalsLabel, 0, 8);
        this.fieldsPanel.Controls.Add(this.decimalsBox, 0, 9);
        this.fieldsPanel.Controls.Add(this.sortLabel, 1, 8);
        this.fieldsPanel.Controls.Add(this.sortBox, 1, 9);
        this.fieldsPanel.Controls.Add(this.activeCheck, 0, 11);
        this.fieldsPanel.SetColumnSpan(this.activeCheck, 2);
        this.fieldsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.fieldsPanel.Name = "fieldsPanel";
        this.fieldsPanel.RowCount = 13;
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
        this.fieldsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // codeLabel
        //
        this.codeLabel.AutoSize = true;
        this.codeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.codeLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.codeLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.codeLabel.Name = "codeLabel";
        this.codeLabel.Text = "Код (латиница) *";
        //
        // groupLabel
        //
        this.groupLabel.AutoSize = true;
        this.groupLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.groupLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.groupLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.groupLabel.Name = "groupLabel";
        this.groupLabel.Text = "Группа *";
        //
        // nameLabel
        //
        this.nameLabel.AutoSize = true;
        this.nameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.nameLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.nameLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.nameLabel.Name = "nameLabel";
        this.nameLabel.Text = "Название *";
        //
        // unitLabel
        //
        this.unitLabel.AutoSize = true;
        this.unitLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.unitLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.unitLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.unitLabel.Name = "unitLabel";
        this.unitLabel.Text = "Единица измерения";
        //
        // refMinLabel
        //
        this.refMinLabel.AutoSize = true;
        this.refMinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.refMinLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.refMinLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.refMinLabel.Name = "refMinLabel";
        this.refMinLabel.Text = "Норма: от *";
        //
        // refMaxLabel
        //
        this.refMaxLabel.AutoSize = true;
        this.refMaxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.refMaxLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.refMaxLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.refMaxLabel.Name = "refMaxLabel";
        this.refMaxLabel.Text = "Норма: до *";
        //
        // validMinLabel
        //
        this.validMinLabel.AutoSize = true;
        this.validMinLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.validMinLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.validMinLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.validMinLabel.Name = "validMinLabel";
        this.validMinLabel.Text = "Допустимый минимум при вводе *";
        //
        // validMaxLabel
        //
        this.validMaxLabel.AutoSize = true;
        this.validMaxLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.validMaxLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.validMaxLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.validMaxLabel.Name = "validMaxLabel";
        this.validMaxLabel.Text = "Допустимый максимум при вводе *";
        //
        // decimalsLabel
        //
        this.decimalsLabel.AutoSize = true;
        this.decimalsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.decimalsLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.decimalsLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.decimalsLabel.Name = "decimalsLabel";
        this.decimalsLabel.Text = "Знаков после запятой";
        //
        // sortLabel
        //
        this.sortLabel.AutoSize = true;
        this.sortLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.sortLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.sortLabel.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.sortLabel.Name = "sortLabel";
        this.sortLabel.Text = "Порядок в списке";
        //
        // codeBox
        //
        this.codeBox.AccessibleName = "Код (латиница)";
        this.codeBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.codeBox.Height = 30;
        this.codeBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.codeBox.MaxLength = 20;
        this.codeBox.Name = "codeBox";
        this.codeBox.TabIndex = 0;
        this.codeBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // groupBox
        //
        this.groupBox.AccessibleName = "Группа";
        this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBox.Items.AddRange(new object[] { "Давление и пульс", "Общий анализ крови", "Биохимия крови" });
        this.groupBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.groupBox.MaxLength = 60;
        this.groupBox.Name = "groupBox";
        this.groupBox.TabIndex = 1;
        this.groupBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // nameBox
        //
        this.nameBox.AccessibleName = "Название";
        this.nameBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.nameBox.Height = 30;
        this.nameBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.nameBox.MaxLength = 100;
        this.nameBox.Name = "nameBox";
        this.nameBox.TabIndex = 2;
        this.nameBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // unitBox
        //
        this.unitBox.AccessibleName = "Единица измерения";
        this.unitBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.unitBox.Height = 30;
        this.unitBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.unitBox.MaxLength = 20;
        this.unitBox.Name = "unitBox";
        this.unitBox.TabIndex = 3;
        this.unitBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // refMinBox
        //
        this.refMinBox.AccessibleName = "Норма: от";
        this.refMinBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.refMinBox.Height = 30;
        this.refMinBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.refMinBox.MaxLength = 20;
        this.refMinBox.Name = "refMinBox";
        this.refMinBox.TabIndex = 4;
        this.refMinBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // refMaxBox
        //
        this.refMaxBox.AccessibleName = "Норма: до";
        this.refMaxBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.refMaxBox.Height = 30;
        this.refMaxBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.refMaxBox.MaxLength = 20;
        this.refMaxBox.Name = "refMaxBox";
        this.refMaxBox.TabIndex = 5;
        this.refMaxBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // validMinBox
        //
        this.validMinBox.AccessibleName = "Допустимый минимум при вводе";
        this.validMinBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.validMinBox.Height = 30;
        this.validMinBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.validMinBox.MaxLength = 20;
        this.validMinBox.Name = "validMinBox";
        this.validMinBox.TabIndex = 6;
        this.validMinBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // validMaxBox
        //
        this.validMaxBox.AccessibleName = "Допустимый максимум при вводе";
        this.validMaxBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.validMaxBox.Height = 30;
        this.validMaxBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.validMaxBox.MaxLength = 20;
        this.validMaxBox.Name = "validMaxBox";
        this.validMaxBox.TabIndex = 7;
        this.validMaxBox.TextChanged += new System.EventHandler(this.FieldChanged);
        //
        // decimalsBox
        //
        this.decimalsBox.AccessibleName = "Знаков после запятой";
        this.decimalsBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.decimalsBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.decimalsBox.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
        this.decimalsBox.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
        this.decimalsBox.Value = new decimal(new int[] { 1, 0, 0, 0 });
        this.decimalsBox.Name = "decimalsBox";
        this.decimalsBox.TabIndex = 8;
        //
        // sortBox
        //
        this.sortBox.AccessibleName = "Порядок в списке";
        this.sortBox.Dock = System.Windows.Forms.DockStyle.Top;
        this.sortBox.Margin = new System.Windows.Forms.Padding(0, 2, 16, 0);
        this.sortBox.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
        this.sortBox.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
        this.sortBox.Value = new decimal(new int[] { 200, 0, 0, 0 });
        this.sortBox.Name = "sortBox";
        this.sortBox.TabIndex = 9;
        //
        // activeCheck
        //
        this.activeCheck.AutoSize = true;
        this.activeCheck.Checked = true;
        this.activeCheck.CheckState = System.Windows.Forms.CheckState.Checked;
        this.activeCheck.Dock = System.Windows.Forms.DockStyle.Fill;
        this.activeCheck.Margin = new System.Windows.Forms.Padding(0, 6, 16, 0);
        this.activeCheck.Text = "Используется при вводе обследований";
        this.activeCheck.UseVisualStyleBackColor = true;
        this.activeCheck.Name = "activeCheck";
        this.activeCheck.TabIndex = 10;
        //
        // errorLabel (validation and database messages)
        //
        this.errorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(181, 82, 62);
        this.errorLabel.Name = "errorLabel";
        this.errorLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
        //
        // buttons
        //
        this.buttons.Controls.Add(this.cancelButton);
        this.buttons.Controls.Add(this.saveButton);
        this.buttons.Dock = System.Windows.Forms.DockStyle.Fill;
        this.buttons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this.buttons.Name = "buttons";
        this.buttons.WrapContents = false;
        //
        // saveButton
        //
        this.saveButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.saveButton.Name = "saveButton";
        this.saveButton.Size = new System.Drawing.Size(140, 38);
        this.saveButton.TabIndex = 11;
        this.saveButton.Text = "Сохранить";
        this.saveButton.Tone = MedTest.Desktop.ButtonTone.Primary;
        this.saveButton.Click += new System.EventHandler(this.SaveClick);
        //
        // cancelButton
        //
        this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cancelButton.Margin = new System.Windows.Forms.Padding(8, 0, 0, 0);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.Size = new System.Drawing.Size(120, 38);
        this.cancelButton.TabIndex = 12;
        this.cancelButton.Text = "Отмена";
        //
        // IndicatorForm
        //
        this.AcceptButton = this.saveButton;
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this.cancelButton;
        this.ClientSize = new System.Drawing.Size(760, 700);
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(680, 640);
        this.Name = "IndicatorForm";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "МедТест — показатель";
        this.layout.ResumeLayout(false);
        this.fieldsPanel.ResumeLayout(false);
        this.fieldsPanel.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.decimalsBox)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.sortBox)).EndInit();
        this.buttons.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
