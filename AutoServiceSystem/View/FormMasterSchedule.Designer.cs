namespace View
{
    partial class FormMasterSchedule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            buttonSelect = new Button();
            buttonCancel = new Button();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelFormControl = new FlowLayoutPanel();
            tableLayoutPanelMain = new TableLayoutPanel();
            labelSelectedDate = new Label();
            dataGridViewSchedule = new DataGridView();
            labelInfo = new Label();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedule).BeginInit();
            SuspendLayout();
            // 
            // buttonSelect
            // 
            buttonSelect.Location = new Point(520, 3);
            buttonSelect.Name = "buttonSelect";
            buttonSelect.Size = new Size(120, 23);
            buttonSelect.TabIndex = 1;
            buttonSelect.Text = "Выбрать слот";
            buttonSelect.UseVisualStyleBackColor = true;
            buttonSelect.Click += buttonSelect_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(646, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // tableLayoutPanelWrapper
            // 
            tableLayoutPanelWrapper.ColumnCount = 1;
            tableLayoutPanelWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.Controls.Add(flowLayoutPanelFormControl, 0, 1);
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelMain, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(800, 650);
            tableLayoutPanelWrapper.TabIndex = 0;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonSelect);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 618);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(794, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 1;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(labelSelectedDate, 0, 0);
            tableLayoutPanelMain.Controls.Add(dataGridViewSchedule, 0, 1);
            tableLayoutPanelMain.Controls.Add(labelInfo, 0, 2);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(3, 3);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 3;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.Size = new Size(794, 609);
            tableLayoutPanelMain.TabIndex = 1;
            // 
            // labelSelectedDate
            // 
            labelSelectedDate.AutoSize = true;
            labelSelectedDate.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelSelectedDate.Location = new Point(3, 0);
            labelSelectedDate.Name = "labelSelectedDate";
            labelSelectedDate.Size = new Size(156, 21);
            labelSelectedDate.TabIndex = 0;
            labelSelectedDate.Text = "Расписание на ...";
            // 
            // dataGridViewSchedule
            // 
            dataGridViewSchedule.AllowUserToAddRows = false;
            dataGridViewSchedule.AllowUserToDeleteRows = false;
            dataGridViewSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSchedule.Dock = DockStyle.Fill;
            dataGridViewSchedule.Location = new Point(3, 27);
            dataGridViewSchedule.MultiSelect = false;
            dataGridViewSchedule.Name = "dataGridViewSchedule";
            dataGridViewSchedule.ReadOnly = true;
            dataGridViewSchedule.RowHeadersVisible = false;
            dataGridViewSchedule.RowTemplate.Height = 25;
            dataGridViewSchedule.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewSchedule.Size = new Size(788, 529);
            dataGridViewSchedule.TabIndex = 1;
            dataGridViewSchedule.CellClick += dataGridViewSchedule_CellClick;
            dataGridViewSchedule.CellDoubleClick += dataGridViewSchedule_CellDoubleClick;
            // 
            // labelInfo
            // 
            labelInfo.AutoSize = true;
            labelInfo.Dock = DockStyle.Fill;
            labelInfo.Location = new Point(3, 559);
            labelInfo.Name = "labelInfo";
            labelInfo.Size = new Size(788, 50);
            labelInfo.TabIndex = 2;
            labelInfo.Text = "✓ - Свободно (зелёный) | ✗ - Занято (красный) | Обед (оранжевый)\r\nДважды кликните на зелёную ячейку для выбора";
            // 
            // FormMasterSchedule
            // 
            AcceptButton = buttonSelect;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(800, 650);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 650);
            Name = "FormMasterSchedule";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Расписание мастеров";
            Load += FormMasterSchedule_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSchedule).EndInit();
            ResumeLayout(false);
        }

        private Button buttonSelect;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelSelectedDate;
        private DataGridView dataGridViewSchedule;
        private Label labelInfo;
    }
}
