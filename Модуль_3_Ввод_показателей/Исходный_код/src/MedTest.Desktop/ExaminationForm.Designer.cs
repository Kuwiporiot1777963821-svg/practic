#nullable enable
namespace MedTest.Desktop;

partial class ExaminationForm
{
    private System.ComponentModel.IContainer? components = null;
    private System.Windows.Forms.TableLayoutPanel layout = null!, dateRow = null!;
    private System.Windows.Forms.Label titleLabel = null!, patientLabel = null!, dateLabel = null!, summaryLabel = null!, commentLabel = null!, messageLabel = null!;
    private System.Windows.Forms.DateTimePicker datePicker = null!, timePicker = null!;
    private System.Windows.Forms.DataGridView valuesGrid = null!;
    private System.Windows.Forms.DataGridViewTextBoxColumn groupColumn = null!, nameColumn = null!, valueColumn = null!, unitColumn = null!, normColumn = null!, statusColumn = null!;
    private System.Windows.Forms.TextBox commentBox = null!;
    private System.Windows.Forms.FlowLayoutPanel buttons = null!;
    private UiButton saveButton = null!, cancelButton = null!, clearButton = null!;

    protected override void Dispose(bool disposing) { if (disposing) components?.Dispose(); base.Dispose(disposing); }

    private void InitializeComponent()
    {
        this.layout = new System.Windows.Forms.TableLayoutPanel();
        this.titleLabel = new System.Windows.Forms.Label();
        this.patientLabel = new System.Windows.Forms.Label();
        this.dateRow = new System.Windows.Forms.TableLayoutPanel();
        this.dateLabel = new System.Windows.Forms.Label();
        this.datePicker = new System.Windows.Forms.DateTimePicker();
        this.timePicker = new System.Windows.Forms.DateTimePicker();
        this.summaryLabel = new System.Windows.Forms.Label();
        this.valuesGrid = new System.Windows.Forms.DataGridView();
        this.groupColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.nameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.valueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.unitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.normColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.statusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
        this.commentLabel = new System.Windows.Forms.Label();
        this.commentBox = new System.Windows.Forms.TextBox();
        this.messageLabel = new System.Windows.Forms.Label();
        this.buttons = new System.Windows.Forms.FlowLayoutPanel();
        this.saveButton = new MedTest.Desktop.UiButton();
        this.cancelButton = new MedTest.Desktop.UiButton();
        this.clearButton = new MedTest.Desktop.UiButton();
        this.layout.SuspendLayout();
        this.dateRow.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.valuesGrid)).BeginInit();
        this.buttons.SuspendLayout();
        this.SuspendLayout();
        //
        // layout
        //
        this.layout.ColumnCount = 1;
        this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.Controls.Add(this.titleLabel, 0, 0);
        this.layout.Controls.Add(this.patientLabel, 0, 1);
        this.layout.Controls.Add(this.dateRow, 0, 2);
        this.layout.Controls.Add(this.summaryLabel, 0, 3);
        this.layout.Controls.Add(this.valuesGrid, 0, 4);
        this.layout.Controls.Add(this.commentLabel, 0, 5);
        this.layout.Controls.Add(this.commentBox, 0, 6);
        this.layout.Controls.Add(this.messageLabel, 0, 7);
        this.layout.Controls.Add(this.buttons, 0, 8);
        this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
        this.layout.Name = "layout";
        this.layout.Padding = new System.Windows.Forms.Padding(28, 20, 28, 16);
        this.layout.RowCount = 9;
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
        this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
        //
        // titleLabel
        //
        this.titleLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.titleLabel.Font = new System.Drawing.Font("Georgia", 16F, System.Drawing.FontStyle.Bold);
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Text = "Новое обследование";
        this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // patientLabel
        //
        this.patientLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.patientLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.patientLabel.Name = "patientLabel";
        this.patientLabel.Text = "Пациент";
        this.patientLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // dateRow
        //
        this.dateRow.ColumnCount = 4;
        this.dateRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
        this.dateRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
        this.dateRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
        this.dateRow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.dateRow.Controls.Add(this.dateLabel, 0, 0);
        this.dateRow.Controls.Add(this.datePicker, 1, 0);
        this.dateRow.Controls.Add(this.timePicker, 2, 0);
        this.dateRow.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dateRow.Margin = new System.Windows.Forms.Padding(0);
        this.dateRow.Name = "dateRow";
        this.dateRow.RowCount = 1;
        this.dateRow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        //
        // dateLabel
        //
        this.dateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dateLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.dateLabel.Name = "dateLabel";
        this.dateLabel.Text = "Дата и время";
        this.dateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // datePicker
        //
        this.datePicker.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        this.datePicker.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        this.datePicker.Name = "datePicker";
        this.datePicker.TabIndex = 0;
        //
        // timePicker
        //
        this.timePicker.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
        this.timePicker.CustomFormat = "HH:mm";
        this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.timePicker.Margin = new System.Windows.Forms.Padding(0);
        this.timePicker.Name = "timePicker";
        this.timePicker.ShowUpDown = true;
        this.timePicker.TabIndex = 1;
        //
        // summaryLabel
        //
        this.summaryLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.summaryLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.summaryLabel.Name = "summaryLabel";
        this.summaryLabel.Text = "";
        this.summaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // valuesGrid
        //
        this.valuesGrid.AllowUserToAddRows = false;
        this.valuesGrid.AllowUserToDeleteRows = false;
        this.valuesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        this.valuesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.groupColumn, this.nameColumn, this.valueColumn, this.unitColumn, this.normColumn, this.statusColumn });
        this.valuesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
        this.valuesGrid.Name = "valuesGrid";
        this.valuesGrid.RowHeadersVisible = false;
        this.valuesGrid.TabIndex = 2;
        this.valuesGrid.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.ValuesPainting);
        this.valuesGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValuesChanged);
        //
        // groupColumn
        //
        this.groupColumn.FillWeight = 22F;
        this.groupColumn.HeaderText = "Группа";
        this.groupColumn.Name = "group";
        //
        // nameColumn
        //
        this.nameColumn.FillWeight = 28F;
        this.nameColumn.HeaderText = "Показатель";
        this.nameColumn.Name = "name";
        //
        // valueColumn
        //
        this.valueColumn.FillWeight = 14F;
        this.valueColumn.HeaderText = "Значение";
        this.valueColumn.MaxInputLength = 12;
        this.valueColumn.Name = "value";
        //
        // unitColumn
        //
        this.unitColumn.FillWeight = 17F;
        this.unitColumn.HeaderText = "Ед.";
        this.unitColumn.Name = "unit";
        //
        // normColumn
        //
        this.normColumn.FillWeight = 17F;
        this.normColumn.HeaderText = "Норма";
        this.normColumn.Name = "norm";
        //
        // statusColumn
        //
        this.statusColumn.FillWeight = 20F;
        this.statusColumn.HeaderText = "Оценка";
        this.statusColumn.Name = "status";
        //
        // commentLabel
        //
        this.commentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.commentLabel.ForeColor = System.Drawing.Color.FromArgb(91, 105, 100);
        this.commentLabel.Name = "commentLabel";
        this.commentLabel.Text = "Комментарий";
        this.commentLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        //
        // commentBox
        //
        this.commentBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.commentBox.MaxLength = 1000;
        this.commentBox.Multiline = true;
        this.commentBox.Name = "commentBox";
        this.commentBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.commentBox.TabIndex = 3;
        //
        // messageLabel
        //
        this.messageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
        this.messageLabel.ForeColor = System.Drawing.Color.FromArgb(181, 82, 62);
        this.messageLabel.Name = "messageLabel";
        this.messageLabel.Text = "";
        this.messageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //
        // buttons
        //
        this.buttons.Controls.Add(this.saveButton);
        this.buttons.Controls.Add(this.cancelButton);
        this.buttons.Controls.Add(this.clearButton);
        this.buttons.Dock = System.Windows.Forms.DockStyle.Fill;
        this.buttons.Margin = new System.Windows.Forms.Padding(0);
        this.buttons.Name = "buttons";
        this.buttons.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
        //
        // saveButton
        //
        this.saveButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        this.saveButton.Name = "saveButton";
        this.saveButton.Size = new System.Drawing.Size(200, 38);
        this.saveButton.TabIndex = 4;
        this.saveButton.Text = "Сохранить обследование";
        this.saveButton.Tone = MedTest.Desktop.ButtonTone.Primary;
        this.saveButton.Click += new System.EventHandler(this.SaveClick);
        //
        // cancelButton
        //
        this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cancelButton.Margin = new System.Windows.Forms.Padding(0, 0, 8, 0);
        this.cancelButton.Name = "cancelButton";
        this.cancelButton.Size = new System.Drawing.Size(120, 38);
        this.cancelButton.TabIndex = 5;
        this.cancelButton.Text = "Отмена";
        //
        // clearButton
        //
        this.clearButton.Margin = new System.Windows.Forms.Padding(0);
        this.clearButton.Name = "clearButton";
        this.clearButton.Size = new System.Drawing.Size(150, 38);
        this.clearButton.TabIndex = 6;
        this.clearButton.Text = "Очистить значения";
        this.clearButton.Click += new System.EventHandler(this.ClearClick);
        //
        // ExaminationForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.White;
        this.CancelButton = this.cancelButton;
        this.ClientSize = new System.Drawing.Size(900, 760);
        this.Controls.Add(this.layout);
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ForeColor = System.Drawing.Color.FromArgb(17, 33, 28);
        this.MinimizeBox = false;
        this.MinimumSize = new System.Drawing.Size(760, 620);
        this.Name = "ExaminationForm";
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "МедТест — обследование";
        this.layout.ResumeLayout(false);
        this.dateRow.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.valuesGrid)).EndInit();
        this.buttons.ResumeLayout(false);
        this.ResumeLayout(false);
    }
}
