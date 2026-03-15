namespace View
{
    partial class FormOrder
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
            buttonAccept = new Button();
            buttonCancel = new Button();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelFormControl = new FlowLayoutPanel();
            tabControl = new TabControl();
            tabPageMain = new TabPage();
            tableLayoutPanelMain = new TableLayoutPanel();
            labelOrderNumber = new Label();
            labelClient = new Label();
            labelCar = new Label();
            labelMaster = new Label();
            labelServiceDateTime = new Label();
            labelStatus = new Label();
            textBoxOrderNumber = new TextBox();
            comboBoxClient = new ComboBox();
            comboBoxCar = new ComboBox();
            comboBoxMaster = new ComboBox();
            dateTimePickerServiceDateTime = new DateTimePicker();
            buttonShowSchedule = new Button();
            comboBoxStatus = new ComboBox();
            tableLayoutPanelClient = new TableLayoutPanel();
            buttonAddClient = new Button();
            tableLayoutPanelCar = new TableLayoutPanel();
            buttonAddCar = new Button();
            tabPageServices = new TabPage();
            tableLayoutPanelServices = new TableLayoutPanel();
            dataGridViewServices = new DataGridView();
            buttonAddService = new Button();
            buttonRemoveService = new Button();
            labelServicesTotal = new Label();
            tabPageParts = new TabPage();
            tableLayoutPanelParts = new TableLayoutPanel();
            dataGridViewParts = new DataGridView();
            buttonAddPart = new Button();
            buttonRemovePart = new Button();
            labelPartsTotal = new Label();
            tabPageSummary = new TabPage();
            tableLayoutPanelSummary = new TableLayoutPanel();
            labelTotalPrice = new Label();
            textBoxTotalPrice = new TextBox();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageMain.SuspendLayout();
            tableLayoutPanelMain.SuspendLayout();
            tabPageServices.SuspendLayout();
            tableLayoutPanelServices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            tabPageParts.SuspendLayout();
            tableLayoutPanelParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParts).BeginInit();
            tabPageSummary.SuspendLayout();
            tableLayoutPanelSummary.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(539, 3);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(100, 23);
            buttonAccept.TabIndex = 1;
            buttonAccept.Text = "Сохранить";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(645, 3);
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
            tableLayoutPanelWrapper.Controls.Add(tabControl, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(784, 511);
            tableLayoutPanelWrapper.TabIndex = 2;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonAccept);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 479);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(778, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageMain);
            tabControl.Controls.Add(tabPageServices);
            tabControl.Controls.Add(tabPageParts);
            tabControl.Controls.Add(tabPageSummary);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(3, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(778, 470);
            tabControl.TabIndex = 1;
            // 
            // tabPageMain
            // 
            tabPageMain.Controls.Add(tableLayoutPanelMain);
            tabPageMain.Location = new Point(4, 24);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Padding = new Padding(3);
            tabPageMain.Size = new Size(770, 442);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "Основное";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.Controls.Add(labelOrderNumber, 0, 0);
            tableLayoutPanelMain.Controls.Add(labelClient, 0, 1);
            tableLayoutPanelMain.Controls.Add(labelCar, 0, 2);
            tableLayoutPanelMain.Controls.Add(labelMaster, 0, 3);
            tableLayoutPanelMain.Controls.Add(labelServiceDateTime, 0, 4);
            tableLayoutPanelMain.Controls.Add(labelStatus, 0, 5);
            tableLayoutPanelMain.Controls.Add(textBoxOrderNumber, 1, 0);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelClient, 1, 1);
            tableLayoutPanelMain.Controls.Add(tableLayoutPanelCar, 1, 2);
            tableLayoutPanelMain.Controls.Add(comboBoxMaster, 1, 3);
            tableLayoutPanelMain.Controls.Add(dateTimePickerServiceDateTime, 1, 4);
            tableLayoutPanelMain.Controls.Add(comboBoxStatus, 1, 5);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(3, 3);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 7;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.Size = new Size(764, 436);
            tableLayoutPanelMain.TabIndex = 0;
            // 
            // labelOrderNumber
            // 
            labelOrderNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelOrderNumber.AutoSize = true;
            labelOrderNumber.Location = new Point(3, 7);
            labelOrderNumber.Name = "labelOrderNumber";
            labelOrderNumber.Size = new Size(120, 15);
            labelOrderNumber.TabIndex = 0;
            labelOrderNumber.Text = "Номер заявки";
            // 
            // labelClient
            // 
            labelClient.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelClient.AutoSize = true;
            labelClient.Location = new Point(3, 36);
            labelClient.Name = "labelClient";
            labelClient.Size = new Size(120, 15);
            labelClient.TabIndex = 1;
            labelClient.Text = "Клиент";
            // 
            // labelCar
            // 
            labelCar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCar.AutoSize = true;
            labelCar.Location = new Point(3, 65);
            labelCar.Name = "labelCar";
            labelCar.Size = new Size(120, 15);
            labelCar.TabIndex = 2;
            labelCar.Text = "Автомобиль";
            // 
            // labelMaster
            // 
            labelMaster.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelMaster.AutoSize = true;
            labelMaster.Location = new Point(3, 94);
            labelMaster.Name = "labelMaster";
            labelMaster.Size = new Size(120, 15);
            labelMaster.TabIndex = 3;
            labelMaster.Text = "Мастер";
            // 
            // labelServiceDateTime
            // 
            labelServiceDateTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelServiceDateTime.AutoSize = true;
            labelServiceDateTime.Location = new Point(3, 123);
            labelServiceDateTime.Name = "labelServiceDateTime";
            labelServiceDateTime.Size = new Size(120, 15);
            labelServiceDateTime.TabIndex = 4;
            labelServiceDateTime.Text = "Дата и время услуги";
            // 
            // labelStatus
            // 
            labelStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelStatus.AutoSize = true;
            labelStatus.Location = new Point(3, 152);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(120, 15);
            labelStatus.TabIndex = 5;
            labelStatus.Text = "Статус";
            // 
            // textBoxOrderNumber
            // 
            textBoxOrderNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxOrderNumber.Location = new Point(129, 3);
            textBoxOrderNumber.Name = "textBoxOrderNumber";
            textBoxOrderNumber.ReadOnly = true;
            textBoxOrderNumber.Size = new Size(632, 23);
            textBoxOrderNumber.TabIndex = 6;
            // 
            // comboBoxClient
            // 
            comboBoxClient.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxClient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(129, 32);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(632, 23);
            comboBoxClient.TabIndex = 7;
            comboBoxClient.SelectedIndexChanged += comboBoxClient_SelectedIndexChanged;
            // 
            // comboBoxCar
            // 
            comboBoxCar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCar.FormattingEnabled = true;
            comboBoxCar.Location = new Point(129, 61);
            comboBoxCar.Name = "comboBoxCar";
            comboBoxCar.Size = new Size(632, 23);
            comboBoxCar.TabIndex = 8;
            // 
            // comboBoxMaster
            // 
            comboBoxMaster.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxMaster.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMaster.FormattingEnabled = true;
            comboBoxMaster.Location = new Point(129, 90);
            comboBoxMaster.Name = "comboBoxMaster";
            comboBoxMaster.Size = new Size(632, 23);
            comboBoxMaster.TabIndex = 9;
            //
            // dateTimePickerServiceDateTime
            //
            dateTimePickerServiceDateTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerServiceDateTime.Format = DateTimePickerFormat.Short;
            dateTimePickerServiceDateTime.Location = new Point(129, 119);
            dateTimePickerServiceDateTime.Name = "dateTimePickerServiceDateTime";
            dateTimePickerServiceDateTime.Size = new Size(546, 23);
            dateTimePickerServiceDateTime.TabIndex = 10;
            dateTimePickerServiceDateTime.ValueChanged += dateTimePickerServiceDateTime_ValueChanged;
            //
            // buttonShowSchedule
            //
            buttonShowSchedule.Anchor = AnchorStyles.Left;
            buttonShowSchedule.Location = new Point(681, 120);
            buttonShowSchedule.Name = "buttonShowSchedule";
            buttonShowSchedule.Size = new Size(80, 23);
            buttonShowSchedule.TabIndex = 11;
            buttonShowSchedule.Text = "Расписание";
            buttonShowSchedule.UseVisualStyleBackColor = true;
            buttonShowSchedule.Click += buttonShowSchedule_Click;
            //
            // comboBoxStatus
            //
            comboBoxStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStatus.FormattingEnabled = true;
            comboBoxStatus.Items.AddRange(new object[] { "Ожидает", "В работе", "Выполнена", "Просрочена", "Отменена" });
            comboBoxStatus.Location = new Point(129, 148);
            comboBoxStatus.Name = "comboBoxStatus";
            comboBoxStatus.Size = new Size(632, 23);
            comboBoxStatus.TabIndex = 11;
            //
            // tableLayoutPanelClient
            //
            tableLayoutPanelClient.ColumnCount = 2;
            tableLayoutPanelClient.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelClient.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelClient.Controls.Add(comboBoxClient, 0, 0);
            tableLayoutPanelClient.Controls.Add(buttonAddClient, 1, 0);
            tableLayoutPanelClient.Dock = DockStyle.Fill;
            tableLayoutPanelClient.Location = new Point(129, 33);
            tableLayoutPanelClient.Name = "tableLayoutPanelClient";
            tableLayoutPanelClient.RowCount = 1;
            tableLayoutPanelClient.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelClient.Size = new Size(632, 23);
            tableLayoutPanelClient.TabIndex = 12;
            //
            // comboBoxClient
            //
            comboBoxClient.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxClient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxClient.FormattingEnabled = true;
            comboBoxClient.Location = new Point(3, 3);
            comboBoxClient.Name = "comboBoxClient";
            comboBoxClient.Size = new Size(546, 23);
            comboBoxClient.TabIndex = 7;
            comboBoxClient.SelectedIndexChanged += comboBoxClient_SelectedIndexChanged;
            //
            // buttonAddClient
            //
            buttonAddClient.Anchor = AnchorStyles.Left;
            buttonAddClient.Location = new Point(555, 3);
            buttonAddClient.Name = "buttonAddClient";
            buttonAddClient.Size = new Size(75, 23);
            buttonAddClient.TabIndex = 8;
            buttonAddClient.Text = "Добавить";
            buttonAddClient.UseVisualStyleBackColor = true;
            buttonAddClient.Click += buttonAddClient_Click;
            //
            // tableLayoutPanelCar
            //
            tableLayoutPanelCar.ColumnCount = 2;
            tableLayoutPanelCar.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelCar.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelCar.Controls.Add(comboBoxCar, 0, 0);
            tableLayoutPanelCar.Controls.Add(buttonAddCar, 1, 0);
            tableLayoutPanelCar.Dock = DockStyle.Fill;
            tableLayoutPanelCar.Location = new Point(129, 62);
            tableLayoutPanelCar.Name = "tableLayoutPanelCar";
            tableLayoutPanelCar.RowCount = 1;
            tableLayoutPanelCar.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelCar.Size = new Size(632, 23);
            tableLayoutPanelCar.TabIndex = 13;
            //
            // comboBoxCar
            //
            comboBoxCar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCar.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCar.FormattingEnabled = true;
            comboBoxCar.Location = new Point(3, 3);
            comboBoxCar.Name = "comboBoxCar";
            comboBoxCar.Size = new Size(546, 23);
            comboBoxCar.TabIndex = 9;
            //
            // buttonAddCar
            //
            buttonAddCar.Anchor = AnchorStyles.Left;
            buttonAddCar.Location = new Point(555, 3);
            buttonAddCar.Name = "buttonAddCar";
            buttonAddCar.Size = new Size(75, 23);
            buttonAddCar.TabIndex = 10;
            buttonAddCar.Text = "Добавить";
            buttonAddCar.UseVisualStyleBackColor = true;
            buttonAddCar.Click += buttonAddCar_Click;
            // 
            // tabPageServices
            // 
            tabPageServices.Controls.Add(tableLayoutPanelServices);
            tabPageServices.Location = new Point(4, 24);
            tabPageServices.Name = "tabPageServices";
            tabPageServices.Padding = new Padding(3);
            tabPageServices.Size = new Size(770, 442);
            tabPageServices.TabIndex = 1;
            tabPageServices.Text = "Услуги";
            tabPageServices.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelServices
            // 
            tableLayoutPanelServices.ColumnCount = 1;
            tableLayoutPanelServices.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelServices.Controls.Add(dataGridViewServices, 0, 0);
            tableLayoutPanelServices.Controls.Add(buttonAddService, 0, 1);
            tableLayoutPanelServices.Controls.Add(buttonRemoveService, 0, 2);
            tableLayoutPanelServices.Controls.Add(labelServicesTotal, 0, 3);
            tableLayoutPanelServices.Dock = DockStyle.Fill;
            tableLayoutPanelServices.Location = new Point(3, 3);
            tableLayoutPanelServices.Name = "tableLayoutPanelServices";
            tableLayoutPanelServices.RowCount = 5;
            tableLayoutPanelServices.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelServices.RowStyles.Add(new RowStyle());
            tableLayoutPanelServices.RowStyles.Add(new RowStyle());
            tableLayoutPanelServices.RowStyles.Add(new RowStyle());
            tableLayoutPanelServices.RowStyles.Add(new RowStyle());
            tableLayoutPanelServices.Size = new Size(764, 436);
            tableLayoutPanelServices.TabIndex = 0;
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.AllowUserToAddRows = false;
            dataGridViewServices.AllowUserToDeleteRows = false;
            dataGridViewServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.Dock = DockStyle.Fill;
            dataGridViewServices.Location = new Point(3, 3);
            dataGridViewServices.MultiSelect = false;
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.ReadOnly = true;
            dataGridViewServices.RowHeadersVisible = false;
            dataGridViewServices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewServices.Size = new Size(758, 350);
            dataGridViewServices.TabIndex = 0;
            // 
            // buttonAddService
            // 
            buttonAddService.Location = new Point(3, 359);
            buttonAddService.Name = "buttonAddService";
            buttonAddService.Size = new Size(150, 23);
            buttonAddService.TabIndex = 1;
            buttonAddService.Text = "Добавить услугу";
            buttonAddService.UseVisualStyleBackColor = true;
            buttonAddService.Click += buttonAddService_Click;
            // 
            // buttonRemoveService
            // 
            buttonRemoveService.Location = new Point(159, 359);
            buttonRemoveService.Name = "buttonRemoveService";
            buttonRemoveService.Size = new Size(150, 23);
            buttonRemoveService.TabIndex = 2;
            buttonRemoveService.Text = "Удалить услугу";
            buttonRemoveService.UseVisualStyleBackColor = true;
            buttonRemoveService.Click += buttonRemoveService_Click;
            // 
            // labelServicesTotal
            // 
            labelServicesTotal.AutoSize = true;
            labelServicesTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelServicesTotal.Location = new Point(3, 385);
            labelServicesTotal.Name = "labelServicesTotal";
            labelServicesTotal.Size = new Size(149, 21);
            labelServicesTotal.TabIndex = 3;
            labelServicesTotal.Text = "Итого услуги: 0 ₽";
            // 
            // tabPageParts
            // 
            tabPageParts.Controls.Add(tableLayoutPanelParts);
            tabPageParts.Location = new Point(4, 24);
            tabPageParts.Name = "tabPageParts";
            tabPageParts.Padding = new Padding(3);
            tabPageParts.Size = new Size(770, 442);
            tabPageParts.TabIndex = 2;
            tabPageParts.Text = "Запчасти";
            tabPageParts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelParts
            // 
            tableLayoutPanelParts.ColumnCount = 1;
            tableLayoutPanelParts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelParts.Controls.Add(dataGridViewParts, 0, 0);
            tableLayoutPanelParts.Controls.Add(buttonAddPart, 0, 1);
            tableLayoutPanelParts.Controls.Add(buttonRemovePart, 0, 2);
            tableLayoutPanelParts.Controls.Add(labelPartsTotal, 0, 3);
            tableLayoutPanelParts.Dock = DockStyle.Fill;
            tableLayoutPanelParts.Location = new Point(3, 3);
            tableLayoutPanelParts.Name = "tableLayoutPanelParts";
            tableLayoutPanelParts.RowCount = 5;
            tableLayoutPanelParts.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelParts.RowStyles.Add(new RowStyle());
            tableLayoutPanelParts.RowStyles.Add(new RowStyle());
            tableLayoutPanelParts.RowStyles.Add(new RowStyle());
            tableLayoutPanelParts.RowStyles.Add(new RowStyle());
            tableLayoutPanelParts.Size = new Size(764, 436);
            tableLayoutPanelParts.TabIndex = 0;
            // 
            // dataGridViewParts
            // 
            dataGridViewParts.AllowUserToAddRows = false;
            dataGridViewParts.AllowUserToDeleteRows = false;
            dataGridViewParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewParts.Dock = DockStyle.Fill;
            dataGridViewParts.Location = new Point(3, 3);
            dataGridViewParts.MultiSelect = false;
            dataGridViewParts.Name = "dataGridViewParts";
            dataGridViewParts.ReadOnly = true;
            dataGridViewParts.RowHeadersVisible = false;
            dataGridViewParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewParts.Size = new Size(758, 350);
            dataGridViewParts.TabIndex = 0;
            // 
            // buttonAddPart
            // 
            buttonAddPart.Location = new Point(3, 359);
            buttonAddPart.Name = "buttonAddPart";
            buttonAddPart.Size = new Size(150, 23);
            buttonAddPart.TabIndex = 1;
            buttonAddPart.Text = "Добавить запчасть";
            buttonAddPart.UseVisualStyleBackColor = true;
            buttonAddPart.Click += buttonAddPart_Click;
            // 
            // buttonRemovePart
            // 
            buttonRemovePart.Location = new Point(159, 359);
            buttonRemovePart.Name = "buttonRemovePart";
            buttonRemovePart.Size = new Size(150, 23);
            buttonRemovePart.TabIndex = 2;
            buttonRemovePart.Text = "Удалить запчасть";
            buttonRemovePart.UseVisualStyleBackColor = true;
            buttonRemovePart.Click += buttonRemovePart_Click;
            // 
            // labelPartsTotal
            // 
            labelPartsTotal.AutoSize = true;
            labelPartsTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelPartsTotal.Location = new Point(3, 385);
            labelPartsTotal.Name = "labelPartsTotal";
            labelPartsTotal.Size = new Size(138, 21);
            labelPartsTotal.TabIndex = 3;
            labelPartsTotal.Text = "Итого запчасти: 0 ₽";
            // 
            // tabPageSummary
            // 
            tabPageSummary.Controls.Add(tableLayoutPanelSummary);
            tabPageSummary.Location = new Point(4, 24);
            tabPageSummary.Name = "tabPageSummary";
            tabPageSummary.Padding = new Padding(3);
            tabPageSummary.Size = new Size(770, 442);
            tabPageSummary.TabIndex = 3;
            tabPageSummary.Text = "Итого";
            tabPageSummary.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelSummary
            // 
            tableLayoutPanelSummary.ColumnCount = 2;
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelSummary.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelSummary.Controls.Add(labelTotalPrice, 0, 0);
            tableLayoutPanelSummary.Controls.Add(textBoxTotalPrice, 1, 0);
            tableLayoutPanelSummary.Dock = DockStyle.Fill;
            tableLayoutPanelSummary.Location = new Point(3, 3);
            tableLayoutPanelSummary.Name = "tableLayoutPanelSummary";
            tableLayoutPanelSummary.RowCount = 2;
            tableLayoutPanelSummary.RowStyles.Add(new RowStyle());
            tableLayoutPanelSummary.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelSummary.Size = new Size(764, 436);
            tableLayoutPanelSummary.TabIndex = 0;
            // 
            // labelTotalPrice
            // 
            labelTotalPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelTotalPrice.AutoSize = true;
            labelTotalPrice.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalPrice.Location = new Point(3, 10);
            labelTotalPrice.Name = "labelTotalPrice";
            labelTotalPrice.Size = new Size(200, 25);
            labelTotalPrice.TabIndex = 0;
            labelTotalPrice.Text = "Общая стоимость:";
            // 
            // textBoxTotalPrice
            // 
            textBoxTotalPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxTotalPrice.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxTotalPrice.Location = new Point(209, 6);
            textBoxTotalPrice.Name = "textBoxTotalPrice";
            textBoxTotalPrice.ReadOnly = true;
            textBoxTotalPrice.Size = new Size(552, 33);
            textBoxTotalPrice.TabIndex = 1;
            textBoxTotalPrice.Text = "0 ₽";
            // 
            // FormOrder
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(784, 511);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 550);
            Name = "FormOrder";
            Text = "Заявка";
            Load += FormOrder_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            tabPageServices.ResumeLayout(false);
            tableLayoutPanelServices.ResumeLayout(false);
            tableLayoutPanelServices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            tabPageParts.ResumeLayout(false);
            tableLayoutPanelParts.ResumeLayout(false);
            tableLayoutPanelParts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParts).EndInit();
            tabPageSummary.ResumeLayout(false);
            tableLayoutPanelSummary.ResumeLayout(false);
            tableLayoutPanelSummary.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TabControl tabControl;
        private TabPage tabPageMain;
        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelOrderNumber;
        private Label labelClient;
        private Label labelCar;
        private Label labelMaster;
        private Label labelServiceDateTime;
        private Label labelStatus;
        private TextBox textBoxOrderNumber;
        private ComboBox comboBoxClient;
        private ComboBox comboBoxCar;
        private ComboBox comboBoxMaster;
        private DateTimePicker dateTimePickerServiceDateTime;
        private Button buttonShowSchedule;
        private ComboBox comboBoxStatus;
        private TableLayoutPanel tableLayoutPanelClient;
        private Button buttonAddClient;
        private TableLayoutPanel tableLayoutPanelCar;
        private Button buttonAddCar;
        private TabPage tabPageServices;
        private TableLayoutPanel tableLayoutPanelServices;
        private DataGridView dataGridViewServices;
        private Button buttonAddService;
        private Button buttonRemoveService;
        private Label labelServicesTotal;
        private TabPage tabPageParts;
        private TableLayoutPanel tableLayoutPanelParts;
        private DataGridView dataGridViewParts;
        private Button buttonAddPart;
        private Button buttonRemovePart;
        private Label labelPartsTotal;
        private TabPage tabPageSummary;
        private TableLayoutPanel tableLayoutPanelSummary;
        private Label labelTotalPrice;
        private TextBox textBoxTotalPrice;
    }
}
