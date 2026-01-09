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
            ColumnOrderId = new DataGridViewTextBoxColumn();
            ColumnOrderNumber = new DataGridViewTextBoxColumn();
            ColumnOrderDate = new DataGridViewTextBoxColumn();
            ColumnOrderTime = new DataGridViewTextBoxColumn();
            ColumnOrderStatus = new DataGridViewTextBoxColumn();
            ColumnOrderWorker = new DataGridViewTextBoxColumn();
            ColumnOrderCar = new DataGridViewTextBoxColumn();
            ColumnOrderClient = new DataGridViewTextBoxColumn();
            tabControl = new TabControl();
            tabPageOrders = new TabPage();
            tableLayoutPanelOrders = new TableLayoutPanel();
            tableLayoutPanelOrdersFilter = new TableLayoutPanel();
            textBoxOrderFilterSearch = new TextBox();
            dateTimePickerOrderFilterDateFrom = new DateTimePicker();
            dateTimePickerOrderFilterDateTo = new DateTimePicker();
            comboBoxOrderFilterStatus = new ComboBox();
            comboBoxOrderFilterWorker = new ComboBox();
            buttonOrdersFiltersSearchSubmit = new Button();
            tabPageCars = new TabPage();
            tableLayoutPanelCars = new TableLayoutPanel();
            tableLayoutPanelCarsFilter = new TableLayoutPanel();
            textBoxCarsFilterSearch = new TextBox();
            buttonCarsFiltersSearchSubmit = new Button();
            dataGridViewCars = new DataGridView();
            ColumnCarId = new DataGridViewTextBoxColumn();
            ColumnCarStateMark = new DataGridViewTextBoxColumn();
            ColumnCarBrand = new DataGridViewTextBoxColumn();
            ColumnCarModel = new DataGridViewTextBoxColumn();
            ColumnCarProductionYear = new DataGridViewTextBoxColumn();
            ColumnCarColor = new DataGridViewTextBoxColumn();
            ColumnCarVIN = new DataGridViewTextBoxColumn();
            tabPageClients = new TabPage();
            tableLayoutPanelClients = new TableLayoutPanel();
            dataGridViewClients = new DataGridView();
            ColumnClientId = new DataGridViewTextBoxColumn();
            ColumnClientType = new DataGridViewTextBoxColumn();
            ColumnClientContactInfo = new DataGridViewTextBoxColumn();
            tableLayoutPanelClientsFilter = new TableLayoutPanel();
            textBoxClientsFilterSearch = new TextBox();
            comboBoxClientsTypeFilter = new ComboBox();
            buttonClientsFiltersSearchSubmit = new Button();
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
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[] { ColumnOrderId, ColumnOrderNumber, ColumnOrderDate, ColumnOrderTime, ColumnOrderStatus, ColumnOrderWorker, ColumnOrderCar, ColumnOrderClient });
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.Location = new Point(3, 38);
            dataGridViewOrders.MultiSelect = false;
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.Size = new Size(1273, 493);
            dataGridViewOrders.TabIndex = 2;
            // 
            // ColumnOrderId
            // 
            ColumnOrderId.HeaderText = "Id";
            ColumnOrderId.Name = "ColumnOrderId";
            ColumnOrderId.ReadOnly = true;
            ColumnOrderId.Visible = false;
            // 
            // ColumnOrderNumber
            // 
            ColumnOrderNumber.HeaderText = "Номер";
            ColumnOrderNumber.Name = "ColumnOrderNumber";
            ColumnOrderNumber.ReadOnly = true;
            // 
            // ColumnOrderDate
            // 
            ColumnOrderDate.HeaderText = "Дата";
            ColumnOrderDate.Name = "ColumnOrderDate";
            ColumnOrderDate.ReadOnly = true;
            // 
            // ColumnOrderTime
            // 
            ColumnOrderTime.HeaderText = "Время";
            ColumnOrderTime.Name = "ColumnOrderTime";
            ColumnOrderTime.ReadOnly = true;
            // 
            // ColumnOrderStatus
            // 
            ColumnOrderStatus.HeaderText = "Статус";
            ColumnOrderStatus.Name = "ColumnOrderStatus";
            ColumnOrderStatus.ReadOnly = true;
            // 
            // ColumnOrderWorker
            // 
            ColumnOrderWorker.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnOrderWorker.HeaderText = "Мастер";
            ColumnOrderWorker.Name = "ColumnOrderWorker";
            ColumnOrderWorker.ReadOnly = true;
            // 
            // ColumnOrderCar
            // 
            ColumnOrderCar.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnOrderCar.HeaderText = "Автомобиль";
            ColumnOrderCar.Name = "ColumnOrderCar";
            ColumnOrderCar.ReadOnly = true;
            // 
            // ColumnOrderClient
            // 
            ColumnOrderClient.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnOrderClient.HeaderText = "Клиент";
            ColumnOrderClient.Name = "ColumnOrderClient";
            ColumnOrderClient.ReadOnly = true;
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
            tableLayoutPanelOrdersFilter.Controls.Add(buttonOrdersFiltersSearchSubmit, 5, 0);
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
            // 
            // dateTimePickerOrderFilterDateFrom
            // 
            dateTimePickerOrderFilterDateFrom.CustomFormat = "dd MMMM yyyy г.";
            dateTimePickerOrderFilterDateFrom.Format = DateTimePickerFormat.Custom;
            dateTimePickerOrderFilterDateFrom.Location = new Point(299, 3);
            dateTimePickerOrderFilterDateFrom.Name = "dateTimePickerOrderFilterDateFrom";
            dateTimePickerOrderFilterDateFrom.Size = new Size(145, 23);
            dateTimePickerOrderFilterDateFrom.TabIndex = 0;
            dateTimePickerOrderFilterDateFrom.ValueChanged += dateTimePickerOrderFilterDateFrom_ValueChanged;
            // 
            // dateTimePickerOrderFilterDateTo
            // 
            dateTimePickerOrderFilterDateTo.CustomFormat = "dd MMMM yyyy г.";
            dateTimePickerOrderFilterDateTo.Format = DateTimePickerFormat.Custom;
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
            // buttonOrdersFiltersSearchSubmit
            // 
            buttonOrdersFiltersSearchSubmit.Dock = DockStyle.Fill;
            buttonOrdersFiltersSearchSubmit.Location = new Point(1206, 3);
            buttonOrdersFiltersSearchSubmit.Name = "buttonOrdersFiltersSearchSubmit";
            buttonOrdersFiltersSearchSubmit.Size = new Size(64, 23);
            buttonOrdersFiltersSearchSubmit.TabIndex = 7;
            buttonOrdersFiltersSearchSubmit.Text = "Найти";
            buttonOrdersFiltersSearchSubmit.UseVisualStyleBackColor = true;
            buttonOrdersFiltersSearchSubmit.Click += buttonOrdersFiltersSearchSubmit_Click;
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
            tableLayoutPanelCarsFilter.Controls.Add(textBoxCarsFilterSearch, 0, 0);
            tableLayoutPanelCarsFilter.Controls.Add(buttonCarsFiltersSearchSubmit, 1, 0);
            tableLayoutPanelCarsFilter.Dock = DockStyle.Fill;
            tableLayoutPanelCarsFilter.Location = new Point(3, 3);
            tableLayoutPanelCarsFilter.Name = "tableLayoutPanelCarsFilter";
            tableLayoutPanelCarsFilter.RowCount = 1;
            tableLayoutPanelCarsFilter.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarsFilter.Size = new Size(1273, 29);
            tableLayoutPanelCarsFilter.TabIndex = 2;
            // 
            // textBoxCarsFilterSearch
            // 
            textBoxCarsFilterSearch.Dock = DockStyle.Fill;
            textBoxCarsFilterSearch.Location = new Point(3, 3);
            textBoxCarsFilterSearch.Name = "textBoxCarsFilterSearch";
            textBoxCarsFilterSearch.PlaceholderText = "Поиск";
            textBoxCarsFilterSearch.Size = new Size(1197, 23);
            textBoxCarsFilterSearch.TabIndex = 1;
            // 
            // buttonCarsFiltersSearchSubmit
            // 
            buttonCarsFiltersSearchSubmit.Dock = DockStyle.Fill;
            buttonCarsFiltersSearchSubmit.Location = new Point(1206, 3);
            buttonCarsFiltersSearchSubmit.Name = "buttonCarsFiltersSearchSubmit";
            buttonCarsFiltersSearchSubmit.Size = new Size(64, 23);
            buttonCarsFiltersSearchSubmit.TabIndex = 2;
            buttonCarsFiltersSearchSubmit.Text = "Найти";
            buttonCarsFiltersSearchSubmit.UseVisualStyleBackColor = true;
            buttonCarsFiltersSearchSubmit.Click += buttonCarsFiltersSearchSubmit_Click;
            // 
            // dataGridViewCars
            // 
            dataGridViewCars.AllowUserToAddRows = false;
            dataGridViewCars.AllowUserToDeleteRows = false;
            dataGridViewCars.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCars.Columns.AddRange(new DataGridViewColumn[] { ColumnCarId, ColumnCarStateMark, ColumnCarBrand, ColumnCarModel, ColumnCarProductionYear, ColumnCarColor, ColumnCarVIN });
            dataGridViewCars.Dock = DockStyle.Fill;
            dataGridViewCars.Location = new Point(3, 38);
            dataGridViewCars.MultiSelect = false;
            dataGridViewCars.Name = "dataGridViewCars";
            dataGridViewCars.ReadOnly = true;
            dataGridViewCars.RowHeadersVisible = false;
            dataGridViewCars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewCars.Size = new Size(1273, 493);
            dataGridViewCars.TabIndex = 0;
            // 
            // ColumnCarId
            // 
            ColumnCarId.HeaderText = "Id";
            ColumnCarId.Name = "ColumnCarId";
            ColumnCarId.ReadOnly = true;
            ColumnCarId.Visible = false;
            // 
            // ColumnCarStateMark
            // 
            ColumnCarStateMark.HeaderText = "Госномер";
            ColumnCarStateMark.Name = "ColumnCarStateMark";
            ColumnCarStateMark.ReadOnly = true;
            // 
            // ColumnCarBrand
            // 
            ColumnCarBrand.HeaderText = "Марка";
            ColumnCarBrand.Name = "ColumnCarBrand";
            ColumnCarBrand.ReadOnly = true;
            ColumnCarBrand.Width = 282;
            // 
            // ColumnCarModel
            // 
            ColumnCarModel.HeaderText = "Модель";
            ColumnCarModel.Name = "ColumnCarModel";
            ColumnCarModel.ReadOnly = true;
            ColumnCarModel.Width = 281;
            // 
            // ColumnCarProductionYear
            // 
            ColumnCarProductionYear.HeaderText = "Год";
            ColumnCarProductionYear.Name = "ColumnCarProductionYear";
            ColumnCarProductionYear.ReadOnly = true;
            // 
            // ColumnCarColor
            // 
            ColumnCarColor.HeaderText = "Цвет";
            ColumnCarColor.Name = "ColumnCarColor";
            ColumnCarColor.ReadOnly = true;
            // 
            // ColumnCarVIN
            // 
            ColumnCarVIN.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnCarVIN.HeaderText = "VIN";
            ColumnCarVIN.Name = "ColumnCarVIN";
            ColumnCarVIN.ReadOnly = true;
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
            dataGridViewClients.AllowUserToAddRows = false;
            dataGridViewClients.AllowUserToDeleteRows = false;
            dataGridViewClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewClients.Columns.AddRange(new DataGridViewColumn[] { ColumnClientId, ColumnClientType, ColumnClientContactInfo });
            dataGridViewClients.Dock = DockStyle.Fill;
            dataGridViewClients.Location = new Point(3, 38);
            dataGridViewClients.MultiSelect = false;
            dataGridViewClients.Name = "dataGridViewClients";
            dataGridViewClients.ReadOnly = true;
            dataGridViewClients.RowHeadersVisible = false;
            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.Size = new Size(1273, 493);
            dataGridViewClients.TabIndex = 0;
            // 
            // ColumnClientId
            // 
            ColumnClientId.HeaderText = "Id";
            ColumnClientId.Name = "ColumnClientId";
            ColumnClientId.ReadOnly = true;
            ColumnClientId.Visible = false;
            // 
            // ColumnClientType
            // 
            ColumnClientType.HeaderText = "Тип";
            ColumnClientType.Name = "ColumnClientType";
            ColumnClientType.ReadOnly = true;
            // 
            // ColumnClientContactInfo
            // 
            ColumnClientContactInfo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnClientContactInfo.HeaderText = "Контактное лицо";
            ColumnClientContactInfo.Name = "ColumnClientContactInfo";
            ColumnClientContactInfo.ReadOnly = true;
            // 
            // tableLayoutPanelClientsFilter
            // 
            tableLayoutPanelClientsFilter.ColumnCount = 3;
            tableLayoutPanelClientsFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelClientsFilter.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelClientsFilter.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 70F));
            tableLayoutPanelClientsFilter.Controls.Add(textBoxClientsFilterSearch, 0, 0);
            tableLayoutPanelClientsFilter.Controls.Add(comboBoxClientsTypeFilter, 1, 0);
            tableLayoutPanelClientsFilter.Controls.Add(buttonClientsFiltersSearchSubmit, 2, 0);
            tableLayoutPanelClientsFilter.Dock = DockStyle.Fill;
            tableLayoutPanelClientsFilter.Location = new Point(3, 3);
            tableLayoutPanelClientsFilter.Name = "tableLayoutPanelClientsFilter";
            tableLayoutPanelClientsFilter.RowCount = 1;
            tableLayoutPanelClientsFilter.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientsFilter.Size = new Size(1273, 29);
            tableLayoutPanelClientsFilter.TabIndex = 1;
            // 
            // textBoxClientsFilterSearch
            // 
            textBoxClientsFilterSearch.Dock = DockStyle.Fill;
            textBoxClientsFilterSearch.Location = new Point(3, 3);
            textBoxClientsFilterSearch.Name = "textBoxClientsFilterSearch";
            textBoxClientsFilterSearch.PlaceholderText = "Поиск";
            textBoxClientsFilterSearch.Size = new Size(955, 23);
            textBoxClientsFilterSearch.TabIndex = 1;
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
            // buttonClientsFiltersSearchSubmit
            // 
            buttonClientsFiltersSearchSubmit.Dock = DockStyle.Fill;
            buttonClientsFiltersSearchSubmit.Location = new Point(1206, 3);
            buttonClientsFiltersSearchSubmit.Name = "buttonClientsFiltersSearchSubmit";
            buttonClientsFiltersSearchSubmit.Size = new Size(64, 23);
            buttonClientsFiltersSearchSubmit.TabIndex = 2;
            buttonClientsFiltersSearchSubmit.Text = "Найти";
            buttonClientsFiltersSearchSubmit.UseVisualStyleBackColor = true;
            buttonClientsFiltersSearchSubmit.Click += buttonClientsFiltersSearchSubmit_Click;
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
            FormClosing += FormMain_FormClosing;
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
        private TextBox textBoxCarsFilterSearch;
        private ToolStripMenuItem SystemToolStripMenuItem;
        private ToolStripMenuItem SystemUsersToolStripMenuItem;
        private ToolStripMenuItem ItemToolStripMenuItem;
        private ToolStripMenuItem CreateItemToolStripMenuItem;
        private ToolStripMenuItem EditItemToolStripMenuItem;
        private TabPage tabPageClients;
        private TableLayoutPanel tableLayoutPanelClients;
        private DataGridView dataGridViewClients;
        private TableLayoutPanel tableLayoutPanelClientsFilter;
        private ComboBox comboBoxClientsTypeFilter;
        private TextBox textBoxClientsFilterSearch;
        private TableLayoutPanel tableLayoutPanelCarsFilter;
        private Button buttonOrdersFiltersSearchSubmit;
        private Button buttonCarsFiltersSearchSubmit;
        private Button buttonClientsFiltersSearchSubmit;
        private DataGridViewTextBoxColumn ColumnOrderId;
        private DataGridViewTextBoxColumn ColumnOrderNumber;
        private DataGridViewTextBoxColumn ColumnOrderDate;
        private DataGridViewTextBoxColumn ColumnOrderTime;
        private DataGridViewTextBoxColumn ColumnOrderStatus;
        private DataGridViewTextBoxColumn ColumnOrderWorker;
        private DataGridViewTextBoxColumn ColumnOrderCar;
        private DataGridViewTextBoxColumn ColumnOrderClient;
        private DataGridViewTextBoxColumn ColumnCarId;
        private DataGridViewTextBoxColumn ColumnCarStateMark;
        private DataGridViewTextBoxColumn ColumnCarBrand;
        private DataGridViewTextBoxColumn ColumnCarModel;
        private DataGridViewTextBoxColumn ColumnCarProductionYear;
        private DataGridViewTextBoxColumn ColumnCarColor;
        private DataGridViewTextBoxColumn ColumnCarVIN;
        private DataGridViewTextBoxColumn ColumnClientId;
        private DataGridViewTextBoxColumn ColumnClientType;
        private DataGridViewTextBoxColumn ColumnClientContactInfo;
    }
}