namespace View
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            menuStrip = new MenuStrip();
            InfoToolStripMenuItem = new ToolStripMenuItem();
            AboutProgramToolStripMenuItem = new ToolStripMenuItem();
            dataGridViewOrders = new DataGridView();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnTIme = new DataGridViewTextBoxColumn();
            ColumnStatus = new DataGridViewTextBoxColumn();
            ColumnWorker = new DataGridViewTextBoxColumn();
            ColumnCar = new DataGridViewTextBoxColumn();
            ColumnContactPerson = new DataGridViewTextBoxColumn();
            tabControl = new TabControl();
            tabPageOrders = new TabPage();
            tableLayoutPanelOrders = new TableLayoutPanel();
            flowLayoutPanelOrderInstruments = new FlowLayoutPanel();
            dateTimePickerOrderFilterDateFrom = new DateTimePicker();
            dateTimePickerOrderFilterDateTo = new DateTimePicker();
            comboBoxOrderFilterStatus = new ComboBox();
            textBoxOrderFilterSearch = new TextBox();
            tabPageCars = new TabPage();
            dataGridViewCars = new DataGridView();
            ColumnStateMark = new DataGridViewTextBoxColumn();
            ColumnBrand = new DataGridViewTextBoxColumn();
            ColumnModel = new DataGridViewTextBoxColumn();
            ColumnYear = new DataGridViewTextBoxColumn();
            ColumnColor = new DataGridViewTextBoxColumn();
            ColumnVIN = new DataGridViewTextBoxColumn();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            tabControl.SuspendLayout();
            tabPageOrders.SuspendLayout();
            tableLayoutPanelOrders.SuspendLayout();
            flowLayoutPanelOrderInstruments.SuspendLayout();
            tabPageCars.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCars).BeginInit();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 592);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1293, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(112, 17);
            toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // menuStrip
            // 
            menuStrip.Items.AddRange(new ToolStripItem[] { InfoToolStripMenuItem });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1293, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // InfoToolStripMenuItem
            // 
            InfoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AboutProgramToolStripMenuItem });
            InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            InfoToolStripMenuItem.Size = new Size(65, 20);
            InfoToolStripMenuItem.Text = "Справка";
            // 
            // AboutProgramToolStripMenuItem
            // 
            AboutProgramToolStripMenuItem.Name = "AboutProgramToolStripMenuItem";
            AboutProgramToolStripMenuItem.Size = new Size(149, 22);
            AboutProgramToolStripMenuItem.Text = "О программе";
            AboutProgramToolStripMenuItem.Click += AboutProgramToolStripMenuItem_Click;
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[] { ColumnDate, ColumnTIme, ColumnStatus, ColumnWorker, ColumnCar, ColumnContactPerson });
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.Location = new Point(3, 38);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.Size = new Size(1273, 493);
            dataGridViewOrders.TabIndex = 2;
            // 
            // ColumnDate
            // 
            ColumnDate.HeaderText = "Дата";
            ColumnDate.Name = "ColumnDate";
            // 
            // ColumnTIme
            // 
            ColumnTIme.HeaderText = "Время";
            ColumnTIme.Name = "ColumnTIme";
            // 
            // ColumnStatus
            // 
            ColumnStatus.HeaderText = "Статус";
            ColumnStatus.Name = "ColumnStatus";
            // 
            // ColumnWorker
            // 
            ColumnWorker.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnWorker.HeaderText = "Мастер";
            ColumnWorker.Name = "ColumnWorker";
            // 
            // ColumnCar
            // 
            ColumnCar.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnCar.HeaderText = "Автомобиль";
            ColumnCar.Name = "ColumnCar";
            // 
            // ColumnContactPerson
            // 
            ColumnContactPerson.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnContactPerson.HeaderText = "Контактное лицо";
            ColumnContactPerson.Name = "ColumnContactPerson";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageOrders);
            tabControl.Controls.Add(tabPageCars);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 24);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1293, 568);
            tabControl.TabIndex = 3;
            // 
            // tabPageOrders
            // 
            tabPageOrders.Controls.Add(tableLayoutPanelOrders);
            tabPageOrders.Location = new Point(4, 24);
            tabPageOrders.Name = "tabPageOrders";
            tabPageOrders.Padding = new Padding(3);
            tabPageOrders.Size = new Size(1285, 540);
            tabPageOrders.TabIndex = 0;
            tabPageOrders.Text = "Заказ-наряды";
            tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelOrders
            // 
            tableLayoutPanelOrders.ColumnCount = 1;
            tableLayoutPanelOrders.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.Controls.Add(dataGridViewOrders, 0, 1);
            tableLayoutPanelOrders.Controls.Add(flowLayoutPanelOrderInstruments, 0, 0);
            tableLayoutPanelOrders.Dock = DockStyle.Fill;
            tableLayoutPanelOrders.Location = new Point(3, 3);
            tableLayoutPanelOrders.Name = "tableLayoutPanelOrders";
            tableLayoutPanelOrders.RowCount = 2;
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle());
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.Size = new Size(1279, 534);
            tableLayoutPanelOrders.TabIndex = 4;
            // 
            // flowLayoutPanelOrderInstruments
            // 
            flowLayoutPanelOrderInstruments.AutoSize = true;
            flowLayoutPanelOrderInstruments.Controls.Add(dateTimePickerOrderFilterDateFrom);
            flowLayoutPanelOrderInstruments.Controls.Add(dateTimePickerOrderFilterDateTo);
            flowLayoutPanelOrderInstruments.Controls.Add(comboBoxOrderFilterStatus);
            flowLayoutPanelOrderInstruments.Controls.Add(textBoxOrderFilterSearch);
            flowLayoutPanelOrderInstruments.Location = new Point(3, 3);
            flowLayoutPanelOrderInstruments.Name = "flowLayoutPanelOrderInstruments";
            flowLayoutPanelOrderInstruments.Size = new Size(921, 29);
            flowLayoutPanelOrderInstruments.TabIndex = 3;
            // 
            // dateTimePickerOrderFilterDateFrom
            // 
            dateTimePickerOrderFilterDateFrom.Location = new Point(3, 3);
            dateTimePickerOrderFilterDateFrom.Name = "dateTimePickerOrderFilterDateFrom";
            dateTimePickerOrderFilterDateFrom.Size = new Size(145, 23);
            dateTimePickerOrderFilterDateFrom.TabIndex = 0;
            // 
            // dateTimePickerOrderFilterDateTo
            // 
            dateTimePickerOrderFilterDateTo.Location = new Point(154, 3);
            dateTimePickerOrderFilterDateTo.Name = "dateTimePickerOrderFilterDateTo";
            dateTimePickerOrderFilterDateTo.Size = new Size(143, 23);
            dateTimePickerOrderFilterDateTo.TabIndex = 5;
            // 
            // comboBoxOrderFilterStatus
            // 
            comboBoxOrderFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrderFilterStatus.FormattingEnabled = true;
            comboBoxOrderFilterStatus.Items.AddRange(new object[] { "Все статусы" });
            comboBoxOrderFilterStatus.Location = new Point(303, 3);
            comboBoxOrderFilterStatus.Name = "comboBoxOrderFilterStatus";
            comboBoxOrderFilterStatus.Size = new Size(252, 23);
            comboBoxOrderFilterStatus.TabIndex = 4;
            // 
            // textBoxOrderFilterSearch
            // 
            textBoxOrderFilterSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxOrderFilterSearch.Location = new Point(561, 3);
            textBoxOrderFilterSearch.Name = "textBoxOrderFilterSearch";
            textBoxOrderFilterSearch.PlaceholderText = "Поиск по заказ-нарядам";
            textBoxOrderFilterSearch.Size = new Size(357, 23);
            textBoxOrderFilterSearch.TabIndex = 1;
            // 
            // tabPageCars
            // 
            tabPageCars.Controls.Add(dataGridViewCars);
            tabPageCars.Location = new Point(4, 24);
            tabPageCars.Name = "tabPageCars";
            tabPageCars.Padding = new Padding(3);
            tabPageCars.Size = new Size(1285, 540);
            tabPageCars.TabIndex = 1;
            tabPageCars.Text = "Автомобили";
            tabPageCars.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCars
            // 
            dataGridViewCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCars.Columns.AddRange(new DataGridViewColumn[] { ColumnStateMark, ColumnBrand, ColumnModel, ColumnYear, ColumnColor, ColumnVIN });
            dataGridViewCars.Dock = DockStyle.Fill;
            dataGridViewCars.Location = new Point(3, 3);
            dataGridViewCars.Name = "dataGridViewCars";
            dataGridViewCars.RowHeadersVisible = false;
            dataGridViewCars.Size = new Size(1279, 534);
            dataGridViewCars.TabIndex = 0;
            // 
            // ColumnStateMark
            // 
            ColumnStateMark.HeaderText = "Госномер";
            ColumnStateMark.Name = "ColumnStateMark";
            // 
            // ColumnBrand
            // 
            ColumnBrand.HeaderText = "Марка";
            ColumnBrand.Name = "ColumnBrand";
            ColumnBrand.Width = 282;
            // 
            // ColumnModel
            // 
            ColumnModel.HeaderText = "Модель";
            ColumnModel.Name = "ColumnModel";
            ColumnModel.Width = 281;
            // 
            // ColumnYear
            // 
            ColumnYear.HeaderText = "Год";
            ColumnYear.Name = "ColumnYear";
            // 
            // ColumnColor
            // 
            ColumnColor.HeaderText = "Цвет";
            ColumnColor.Name = "ColumnColor";
            // 
            // ColumnVIN
            // 
            ColumnVIN.HeaderText = "VIN";
            ColumnVIN.Name = "ColumnVIN";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1293, 614);
            Controls.Add(tabControl);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MinimumSize = new Size(640, 480);
            Name = "FormMain";
            Text = "ИС Автосервис";
            Load += FormMain_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            tabControl.ResumeLayout(false);
            tabPageOrders.ResumeLayout(false);
            tableLayoutPanelOrders.ResumeLayout(false);
            tableLayoutPanelOrders.PerformLayout();
            flowLayoutPanelOrderInstruments.ResumeLayout(false);
            flowLayoutPanelOrderInstruments.PerformLayout();
            tabPageCars.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCars).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private MenuStrip menuStrip;
        private ToolStripMenuItem InfoToolStripMenuItem;
        private ToolStripMenuItem AboutProgramToolStripMenuItem;
        private DataGridView dataGridViewOrders;
        private TabControl tabControl;
        private TabPage tabPageOrders;
        private TabPage tabPageCars;
        private DataGridView dataGridViewCars;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnTIme;
        private DataGridViewTextBoxColumn ColumnStatus;
        private DataGridViewTextBoxColumn ColumnWorker;
        private DataGridViewTextBoxColumn ColumnCar;
        private DataGridViewTextBoxColumn ColumnContactPerson;
        private DataGridViewTextBoxColumn ColumnStateMark;
        private DataGridViewTextBoxColumn ColumnBrand;
        private DataGridViewTextBoxColumn ColumnModel;
        private DataGridViewTextBoxColumn ColumnYear;
        private DataGridViewTextBoxColumn ColumnColor;
        private DataGridViewTextBoxColumn ColumnVIN;
        private DateTimePicker dateTimePickerOrderFilterDateFrom;
        private FlowLayoutPanel flowLayoutPanelOrderInstruments;
        private ComboBox comboBoxOrderFilterStatus;
        private TextBox textBoxOrderFilterSearch;
        private TableLayoutPanel tableLayoutPanelOrders;
        private DateTimePicker dateTimePickerOrderFilterDateTo;
    }
}