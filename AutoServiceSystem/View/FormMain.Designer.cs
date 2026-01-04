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
            SystemToolStripMenuItem = new ToolStripMenuItem();
            SystemUsersToolStripMenuItem = new ToolStripMenuItem();
            ItemToolStripMenuItem = new ToolStripMenuItem();
            CreateItemToolStripMenuItem = new ToolStripMenuItem();
            EditItemToolStripMenuItem = new ToolStripMenuItem();
            dataGridViewOrders = new DataGridView();
            ColumnId = new DataGridViewTextBoxColumn();
            ColumnDate = new DataGridViewTextBoxColumn();
            ColumnTIme = new DataGridViewTextBoxColumn();
            ColumnStatus = new DataGridViewTextBoxColumn();
            ColumnWorker = new DataGridViewTextBoxColumn();
            ColumnCar = new DataGridViewTextBoxColumn();
            ColumnContactPerson = new DataGridViewTextBoxColumn();
            tabControl = new TabControl();
            tabPageOrders = new TabPage();
            tableLayoutPanelOrders = new TableLayoutPanel();
            tableLayoutPanelOrdersFilter = new TableLayoutPanel();
            textBoxOrderFilterSearch = new TextBox();
            dateTimePickerOrderFilterDateFrom = new DateTimePicker();
            dateTimePickerOrderFilterDateTo = new DateTimePicker();
            comboBoxOrderFilterStatus = new ComboBox();
            comboBoxOrderFilterWorker = new ComboBox();
            buttonOrdersFiltersSubmit = new Button();
            tabPageCars = new TabPage();
            tableLayoutPanelCars = new TableLayoutPanel();
            tableLayoutPanelCarsFilter = new TableLayoutPanel();
            textBoxCarsSearch = new TextBox();
            buttonCarsFiltersSubmit = new Button();
            dataGridViewCars = new DataGridView();
            ColumnStateMark = new DataGridViewTextBoxColumn();
            ColumnBrand = new DataGridViewTextBoxColumn();
            ColumnModel = new DataGridViewTextBoxColumn();
            ColumnYear = new DataGridViewTextBoxColumn();
            ColumnColor = new DataGridViewTextBoxColumn();
            ColumnVIN = new DataGridViewTextBoxColumn();
            tabPageClients = new TabPage();
            tableLayoutPanelClients = new TableLayoutPanel();
            dataGridViewClients = new DataGridView();
            ColumnClientType = new DataGridViewTextBoxColumn();
            ColumnContactInfo = new DataGridViewTextBoxColumn();
            tableLayoutPanelClientsFilter = new TableLayoutPanel();
            textBoxClientsSearch = new TextBox();
            comboBoxClientsTypeFilter = new ComboBox();
            buttonClientsFiltersSubmit = new Button();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            tabControl.SuspendLayout();
            tabPageOrders.SuspendLayout();
            tableLayoutPanelOrders.SuspendLayout();
            tableLayoutPanelOrdersFilter.SuspendLayout();
            tabPageCars.SuspendLayout();
            tableLayoutPanelCars.SuspendLayout();
            tableLayoutPanelCarsFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCars).BeginInit();
            tabPageClients.SuspendLayout();
            tableLayoutPanelClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).BeginInit();
            tableLayoutPanelClientsFilter.SuspendLayout();
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
            menuStrip.Items.AddRange(new ToolStripItem[] { InfoToolStripMenuItem, SystemToolStripMenuItem, ItemToolStripMenuItem });
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
            // SystemToolStripMenuItem
            // 
            SystemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { SystemUsersToolStripMenuItem });
            SystemToolStripMenuItem.Name = "SystemToolStripMenuItem";
            SystemToolStripMenuItem.Size = new Size(66, 20);
            SystemToolStripMenuItem.Text = "Система";
            // 
            // SystemUsersToolStripMenuItem
            // 
            SystemUsersToolStripMenuItem.Name = "SystemUsersToolStripMenuItem";
            SystemUsersToolStripMenuItem.Size = new Size(152, 22);
            SystemUsersToolStripMenuItem.Text = "Пользователи";
            SystemUsersToolStripMenuItem.Click += SystemUsersToolStripMenuItem_Click;
            // 
            // ItemToolStripMenuItem
            // 
            ItemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateItemToolStripMenuItem, EditItemToolStripMenuItem });
            ItemToolStripMenuItem.Name = "ItemToolStripMenuItem";
            ItemToolStripMenuItem.Size = new Size(66, 20);
            ItemToolStripMenuItem.Text = "Элемент";
            // 
            // CreateItemToolStripMenuItem
            // 
            CreateItemToolStripMenuItem.Name = "CreateItemToolStripMenuItem";
            CreateItemToolStripMenuItem.ShortcutKeys = Keys.Insert;
            CreateItemToolStripMenuItem.Size = new Size(154, 22);
            CreateItemToolStripMenuItem.Text = "Создать";
            CreateItemToolStripMenuItem.Click += CreateItemToolStripMenuItem_Click;
            // 
            // EditItemToolStripMenuItem
            // 
            EditItemToolStripMenuItem.Name = "EditItemToolStripMenuItem";
            EditItemToolStripMenuItem.Size = new Size(154, 22);
            EditItemToolStripMenuItem.Text = "Редактировать";
            EditItemToolStripMenuItem.Click += EditItemToolStripMenuItem_Click;
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[] { ColumnId, ColumnDate, ColumnTIme, ColumnStatus, ColumnWorker, ColumnCar, ColumnContactPerson });
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.Location = new Point(3, 38);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.Size = new Size(1273, 493);
            dataGridViewOrders.TabIndex = 2;
            // 
            // ColumnId
            // 
            ColumnId.HeaderText = "Номер";
            ColumnId.Name = "ColumnId";
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
            tabControl.Controls.Add(tabPageClients);
            tabControl.Dock = DockStyle.Fill;
            tabControl.HotTrack = true;
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
            tableLayoutPanelOrders.Controls.Add(tableLayoutPanelOrdersFilter, 0, 0);
            tableLayoutPanelOrders.Controls.Add(dataGridViewOrders, 0, 1);
            tableLayoutPanelOrders.Dock = DockStyle.Fill;
            tableLayoutPanelOrders.Location = new Point(3, 3);
            tableLayoutPanelOrders.Name = "tableLayoutPanelOrders";
            tableLayoutPanelOrders.RowCount = 2;
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle());
            tableLayoutPanelOrders.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrders.Size = new Size(1279, 534);
            tableLayoutPanelOrders.TabIndex = 4;
            // 
            // tableLayoutPanelOrdersFilter
            // 
            tableLayoutPanelOrdersFilter.ColumnCount = 6;
            tableLayoutPanelOrdersFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrdersFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelOrdersFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelOrdersFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelOrdersFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelOrdersFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanelOrdersFilter.Controls.Add(textBoxOrderFilterSearch, 0, 0);
            tableLayoutPanelOrdersFilter.Controls.Add(dateTimePickerOrderFilterDateFrom, 1, 0);
            tableLayoutPanelOrdersFilter.Controls.Add(dateTimePickerOrderFilterDateTo, 2, 0);
            tableLayoutPanelOrdersFilter.Controls.Add(comboBoxOrderFilterStatus, 3, 0);
            tableLayoutPanelOrdersFilter.Controls.Add(comboBoxOrderFilterWorker, 4, 0);
            tableLayoutPanelOrdersFilter.Controls.Add(buttonOrdersFiltersSubmit, 5, 0);
            tableLayoutPanelOrdersFilter.Dock = DockStyle.Fill;
            tableLayoutPanelOrdersFilter.Location = new Point(3, 3);
            tableLayoutPanelOrdersFilter.Name = "tableLayoutPanelOrdersFilter";
            tableLayoutPanelOrdersFilter.RowCount = 1;
            tableLayoutPanelOrdersFilter.RowStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelOrdersFilter.Size = new Size(1273, 29);
            tableLayoutPanelOrdersFilter.TabIndex = 3;
            // 
            // textBoxOrderFilterSearch
            // 
            textBoxOrderFilterSearch.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxOrderFilterSearch.Location = new Point(3, 3);
            textBoxOrderFilterSearch.Name = "textBoxOrderFilterSearch";
            textBoxOrderFilterSearch.PlaceholderText = "Поиск";
            textBoxOrderFilterSearch.Size = new Size(290, 23);
            textBoxOrderFilterSearch.TabIndex = 1;
            textBoxOrderFilterSearch.TextChanged += textBoxOrderFilterSearch_TextChanged;
            // 
            // dateTimePickerOrderFilterDateFrom
            // 
            dateTimePickerOrderFilterDateFrom.Location = new Point(299, 3);
            dateTimePickerOrderFilterDateFrom.Name = "dateTimePickerOrderFilterDateFrom";
            dateTimePickerOrderFilterDateFrom.Size = new Size(145, 23);
            dateTimePickerOrderFilterDateFrom.TabIndex = 0;
            dateTimePickerOrderFilterDateFrom.ValueChanged += dateTimePickerOrderFilterDateFrom_ValueChanged;
            // 
            // dateTimePickerOrderFilterDateTo
            // 
            dateTimePickerOrderFilterDateTo.Location = new Point(450, 3);
            dateTimePickerOrderFilterDateTo.Name = "dateTimePickerOrderFilterDateTo";
            dateTimePickerOrderFilterDateTo.Size = new Size(143, 23);
            dateTimePickerOrderFilterDateTo.TabIndex = 5;
            dateTimePickerOrderFilterDateTo.ValueChanged += dateTimePickerOrderFilterDateTo_ValueChanged;
            // 
            // comboBoxOrderFilterStatus
            // 
            comboBoxOrderFilterStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrderFilterStatus.FormattingEnabled = true;
            comboBoxOrderFilterStatus.Items.AddRange(new object[] { "Все статусы" });
            comboBoxOrderFilterStatus.Location = new Point(599, 3);
            comboBoxOrderFilterStatus.Name = "comboBoxOrderFilterStatus";
            comboBoxOrderFilterStatus.Size = new Size(252, 23);
            comboBoxOrderFilterStatus.TabIndex = 4;
            comboBoxOrderFilterStatus.SelectedIndexChanged += comboBoxOrderFilterStatus_SelectedIndexChanged;
            // 
            // comboBoxOrderFilterWorker
            // 
            comboBoxOrderFilterWorker.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxOrderFilterWorker.Items.AddRange(new object[] { "Все мастера" });
            comboBoxOrderFilterWorker.Location = new Point(857, 3);
            comboBoxOrderFilterWorker.Name = "comboBoxOrderFilterWorker";
            comboBoxOrderFilterWorker.Size = new Size(343, 23);
            comboBoxOrderFilterWorker.TabIndex = 6;
            comboBoxOrderFilterWorker.SelectedIndexChanged += comboBoxOrderFilterWorker_SelectedIndexChanged;
            // 
            // buttonOrdersFiltersSubmit
            // 
            buttonOrdersFiltersSubmit.Dock = DockStyle.Fill;
            buttonOrdersFiltersSubmit.Location = new Point(1206, 3);
            buttonOrdersFiltersSubmit.Name = "buttonOrdersFiltersSubmit";
            buttonOrdersFiltersSubmit.Size = new Size(64, 23);
            buttonOrdersFiltersSubmit.TabIndex = 7;
            buttonOrdersFiltersSubmit.Text = "Найти";
            buttonOrdersFiltersSubmit.UseVisualStyleBackColor = true;
            buttonOrdersFiltersSubmit.Click += buttonOrdersFiltersSubmit_Click;
            // 
            // tabPageCars
            // 
            tabPageCars.Controls.Add(tableLayoutPanelCars);
            tabPageCars.Location = new Point(4, 24);
            tabPageCars.Name = "tabPageCars";
            tabPageCars.Padding = new Padding(3);
            tabPageCars.Size = new Size(1285, 540);
            tabPageCars.TabIndex = 1;
            tabPageCars.Text = "Автомобили";
            tabPageCars.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelCars
            // 
            tableLayoutPanelCars.ColumnCount = 1;
            tableLayoutPanelCars.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelCars.Controls.Add(tableLayoutPanelCarsFilter, 0, 0);
            tableLayoutPanelCars.Controls.Add(dataGridViewCars, 0, 1);
            tableLayoutPanelCars.Dock = DockStyle.Fill;
            tableLayoutPanelCars.Location = new Point(3, 3);
            tableLayoutPanelCars.Name = "tableLayoutPanelCars";
            tableLayoutPanelCars.RowCount = 2;
            tableLayoutPanelCars.RowStyles.Add(new RowStyle());
            tableLayoutPanelCars.RowStyles.Add(new RowStyle());
            tableLayoutPanelCars.Size = new Size(1279, 534);
            tableLayoutPanelCars.TabIndex = 1;
            // 
            // tableLayoutPanelCarsFilter
            // 
            tableLayoutPanelCarsFilter.ColumnCount = 2;
            tableLayoutPanelCarsFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelCarsFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanelCarsFilter.Controls.Add(textBoxCarsSearch, 0, 0);
            tableLayoutPanelCarsFilter.Controls.Add(buttonCarsFiltersSubmit, 1, 0);
            tableLayoutPanelCarsFilter.Dock = DockStyle.Fill;
            tableLayoutPanelCarsFilter.Location = new Point(3, 3);
            tableLayoutPanelCarsFilter.Name = "tableLayoutPanelCarsFilter";
            tableLayoutPanelCarsFilter.RowCount = 1;
            tableLayoutPanelCarsFilter.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarsFilter.Size = new Size(1273, 29);
            tableLayoutPanelCarsFilter.TabIndex = 2;
            // 
            // textBoxCarsSearch
            // 
            textBoxCarsSearch.Dock = DockStyle.Fill;
            textBoxCarsSearch.Location = new Point(3, 3);
            textBoxCarsSearch.Name = "textBoxCarsSearch";
            textBoxCarsSearch.PlaceholderText = "Поиск";
            textBoxCarsSearch.Size = new Size(1197, 23);
            textBoxCarsSearch.TabIndex = 1;
            textBoxCarsSearch.TextChanged += textBoxCarsSearch_TextChanged;
            // 
            // buttonCarsFiltersSubmit
            // 
            buttonCarsFiltersSubmit.Dock = DockStyle.Fill;
            buttonCarsFiltersSubmit.Location = new Point(1206, 3);
            buttonCarsFiltersSubmit.Name = "buttonCarsFiltersSubmit";
            buttonCarsFiltersSubmit.Size = new Size(64, 23);
            buttonCarsFiltersSubmit.TabIndex = 2;
            buttonCarsFiltersSubmit.Text = "Найти";
            buttonCarsFiltersSubmit.UseVisualStyleBackColor = true;
            buttonCarsFiltersSubmit.Click += buttonCarsFiltersSubmit_Click;
            // 
            // dataGridViewCars
            // 
            dataGridViewCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCars.Columns.AddRange(new DataGridViewColumn[] { ColumnStateMark, ColumnBrand, ColumnModel, ColumnYear, ColumnColor, ColumnVIN });
            dataGridViewCars.Dock = DockStyle.Fill;
            dataGridViewCars.Location = new Point(3, 38);
            dataGridViewCars.Name = "dataGridViewCars";
            dataGridViewCars.RowHeadersVisible = false;
            dataGridViewCars.Size = new Size(1273, 493);
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
            ColumnVIN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnVIN.HeaderText = "VIN";
            ColumnVIN.Name = "ColumnVIN";
            // 
            // tabPageClients
            // 
            tabPageClients.Controls.Add(tableLayoutPanelClients);
            tabPageClients.Location = new Point(4, 24);
            tabPageClients.Name = "tabPageClients";
            tabPageClients.Padding = new Padding(3);
            tabPageClients.Size = new Size(1285, 540);
            tabPageClients.TabIndex = 2;
            tabPageClients.Text = "Клиенты";
            tabPageClients.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelClients
            // 
            tableLayoutPanelClients.ColumnCount = 1;
            tableLayoutPanelClients.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelClients.Controls.Add(dataGridViewClients, 0, 1);
            tableLayoutPanelClients.Controls.Add(tableLayoutPanelClientsFilter, 0, 0);
            tableLayoutPanelClients.Dock = DockStyle.Fill;
            tableLayoutPanelClients.Location = new Point(3, 3);
            tableLayoutPanelClients.Name = "tableLayoutPanelClients";
            tableLayoutPanelClients.RowCount = 2;
            tableLayoutPanelClients.RowStyles.Add(new RowStyle());
            tableLayoutPanelClients.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelClients.Size = new Size(1279, 534);
            tableLayoutPanelClients.TabIndex = 0;
            // 
            // dataGridViewClients
            // 
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClients.Columns.AddRange(new DataGridViewColumn[] { ColumnClientType, ColumnContactInfo });
            dataGridViewClients.Dock = DockStyle.Fill;
            dataGridViewClients.Location = new Point(3, 38);
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.RowHeadersVisible = false;
            dataGridViewClients.Size = new Size(1273, 493);
            dataGridViewClients.TabIndex = 0;
            // 
            // ColumnClientType
            // 
            ColumnClientType.HeaderText = "Тип";
            ColumnClientType.Name = "ColumnClientType";
            // 
            // ColumnContactInfo
            // 
            ColumnContactInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnContactInfo.HeaderText = "Контактное лицо";
            ColumnContactInfo.Name = "ColumnContactInfo";
            // 
            // tableLayoutPanelClientsFilter
            // 
            tableLayoutPanelClientsFilter.ColumnCount = 3;
            tableLayoutPanelClientsFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelClientsFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelClientsFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanelClientsFilter.Controls.Add(textBoxClientsSearch, 0, 0);
            tableLayoutPanelClientsFilter.Controls.Add(comboBoxClientsTypeFilter, 1, 0);
            tableLayoutPanelClientsFilter.Controls.Add(buttonClientsFiltersSubmit, 2, 0);
            tableLayoutPanelClientsFilter.Dock = DockStyle.Fill;
            tableLayoutPanelClientsFilter.Location = new Point(3, 3);
            tableLayoutPanelClientsFilter.Name = "tableLayoutPanelClientsFilter";
            tableLayoutPanelClientsFilter.RowCount = 1;
            tableLayoutPanelClientsFilter.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientsFilter.Size = new Size(1273, 29);
            tableLayoutPanelClientsFilter.TabIndex = 1;
            // 
            // textBoxClientsSearch
            // 
            textBoxClientsSearch.Dock = DockStyle.Fill;
            textBoxClientsSearch.Location = new Point(3, 3);
            textBoxClientsSearch.Name = "textBoxClientsSearch";
            textBoxClientsSearch.PlaceholderText = "Поиск";
            textBoxClientsSearch.Size = new Size(955, 23);
            textBoxClientsSearch.TabIndex = 1;
            textBoxClientsSearch.TextChanged += textBoxClientsSearch_TextChanged;
            // 
            // comboBoxClientsTypeFilter
            // 
            comboBoxClientsTypeFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClientsTypeFilter.FormattingEnabled = true;
            comboBoxClientsTypeFilter.Items.AddRange(new object[] { "Все типы", "Физические лица", "Юридические лица" });
            comboBoxClientsTypeFilter.Location = new Point(964, 3);
            comboBoxClientsTypeFilter.Name = "comboBoxClientsTypeFilter";
            comboBoxClientsTypeFilter.Size = new Size(236, 23);
            comboBoxClientsTypeFilter.TabIndex = 0;
            comboBoxClientsTypeFilter.SelectedIndexChanged += comboBoxClientsTypeFilter_SelectedIndexChanged;
            // 
            // buttonClientsFiltersSubmit
            // 
            buttonClientsFiltersSubmit.Dock = DockStyle.Fill;
            buttonClientsFiltersSubmit.Location = new Point(1206, 3);
            buttonClientsFiltersSubmit.Name = "buttonClientsFiltersSubmit";
            buttonClientsFiltersSubmit.Size = new Size(64, 23);
            buttonClientsFiltersSubmit.TabIndex = 2;
            buttonClientsFiltersSubmit.Text = "Найти";
            buttonClientsFiltersSubmit.UseVisualStyleBackColor = true;
            buttonClientsFiltersSubmit.Click += buttonClientsFiltersSubmit_Click;
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
            tableLayoutPanelOrdersFilter.ResumeLayout(false);
            tableLayoutPanelOrdersFilter.PerformLayout();
            tabPageCars.ResumeLayout(false);
            tableLayoutPanelCars.ResumeLayout(false);
            tableLayoutPanelCarsFilter.ResumeLayout(false);
            tableLayoutPanelCarsFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCars).EndInit();
            tabPageClients.ResumeLayout(false);
            tableLayoutPanelClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewClients).EndInit();
            tableLayoutPanelClientsFilter.ResumeLayout(false);
            tableLayoutPanelClientsFilter.PerformLayout();
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
        private DateTimePicker dateTimePickerOrderFilterDateFrom;
        private TableLayoutPanel tableLayoutPanelOrdersFilter;
        private ComboBox comboBoxOrderFilterStatus;
        private ComboBox comboBoxOrderFilterWorker;
        private TextBox textBoxOrderFilterSearch;
        private TableLayoutPanel tableLayoutPanelOrders;
        private DateTimePicker dateTimePickerOrderFilterDateTo;
        private TableLayoutPanel tableLayoutPanelCars;
        private TextBox textBoxCarsSearch;
        private ToolStripMenuItem SystemToolStripMenuItem;
        private ToolStripMenuItem SystemUsersToolStripMenuItem;
        private DataGridViewTextBoxColumn ColumnStateMark;
        private DataGridViewTextBoxColumn ColumnBrand;
        private DataGridViewTextBoxColumn ColumnModel;
        private DataGridViewTextBoxColumn ColumnYear;
        private DataGridViewTextBoxColumn ColumnColor;
        private DataGridViewTextBoxColumn ColumnVIN;
        private DataGridViewTextBoxColumn ColumnId;
        private DataGridViewTextBoxColumn ColumnDate;
        private DataGridViewTextBoxColumn ColumnTIme;
        private DataGridViewTextBoxColumn ColumnStatus;
        private DataGridViewTextBoxColumn ColumnWorker;
        private DataGridViewTextBoxColumn ColumnCar;
        private DataGridViewTextBoxColumn ColumnContactPerson;
        private ToolStripMenuItem ItemToolStripMenuItem;
        private ToolStripMenuItem CreateItemToolStripMenuItem;
        private ToolStripMenuItem EditItemToolStripMenuItem;
        private TabPage tabPageClients;
        private TableLayoutPanel tableLayoutPanelClients;
        private DataGridView dataGridViewClients;
        private TableLayoutPanel tableLayoutPanelClientsFilter;
        private DataGridViewTextBoxColumn ColumnClientType;
        private DataGridViewTextBoxColumn ColumnContactInfo;
        private ComboBox comboBoxClientsTypeFilter;
        private TextBox textBoxClientsSearch;
        private TableLayoutPanel tableLayoutPanelCarsFilter;
        private Button buttonOrdersFiltersSubmit;
        private Button buttonCarsFiltersSubmit;
        private Button buttonClientsFiltersSubmit;
    }
}