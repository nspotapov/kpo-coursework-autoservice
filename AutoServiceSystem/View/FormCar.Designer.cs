namespace View
{
    partial class FormCar
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
            tableLayoutPanelCarParams = new TableLayoutPanel();
            labelCarClient = new Label();
            labelCarBrand = new Label();
            labelCarModel = new Label();
            labelCarStateMark = new Label();
            labelCarProductionYear = new Label();
            labelCarColor = new Label();
            labelCarVinNumber = new Label();
            comboBoxCarClient = new ComboBox();
            comboBoxCarBrand = new ComboBox();
            comboBoxCarModel = new ComboBox();
            maskedTextBoxCarStateMark = new MaskedTextBox();
            maskedTextBoxCarProductionYear = new MaskedTextBox();
            comboBoxCarColor = new ComboBox();
            maskedTextBoxCarVinNumber = new MaskedTextBox();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelCarParams.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(619, 3);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(75, 23);
            buttonAccept.TabIndex = 7;
            buttonAccept.Text = "Сохранить";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(700, 3);
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
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelCarParams, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(784, 281);
            tableLayoutPanelWrapper.TabIndex = 2;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonAccept);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 249);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(778, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelCarParams
            // 
            tableLayoutPanelCarParams.ColumnCount = 2;
            tableLayoutPanelCarParams.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelCarParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelCarParams.Controls.Add(labelCarClient, 0, 0);
            tableLayoutPanelCarParams.Controls.Add(labelCarBrand, 0, 1);
            tableLayoutPanelCarParams.Controls.Add(labelCarModel, 0, 2);
            tableLayoutPanelCarParams.Controls.Add(labelCarStateMark, 0, 3);
            tableLayoutPanelCarParams.Controls.Add(labelCarProductionYear, 0, 4);
            tableLayoutPanelCarParams.Controls.Add(labelCarColor, 0, 5);
            tableLayoutPanelCarParams.Controls.Add(labelCarVinNumber, 0, 6);
            tableLayoutPanelCarParams.Controls.Add(comboBoxCarClient, 1, 0);
            tableLayoutPanelCarParams.Controls.Add(comboBoxCarBrand, 1, 1);
            tableLayoutPanelCarParams.Controls.Add(comboBoxCarModel, 1, 2);
            tableLayoutPanelCarParams.Controls.Add(maskedTextBoxCarStateMark, 1, 3);
            tableLayoutPanelCarParams.Controls.Add(maskedTextBoxCarProductionYear, 1, 4);
            tableLayoutPanelCarParams.Controls.Add(comboBoxCarColor, 1, 5);
            tableLayoutPanelCarParams.Controls.Add(maskedTextBoxCarVinNumber, 1, 6);
            tableLayoutPanelCarParams.Dock = DockStyle.Fill;
            tableLayoutPanelCarParams.Location = new Point(3, 3);
            tableLayoutPanelCarParams.Name = "tableLayoutPanelCarParams";
            tableLayoutPanelCarParams.RowCount = 8;
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.Size = new Size(778, 240);
            tableLayoutPanelCarParams.TabIndex = 1;
            // 
            // labelCarClient
            // 
            labelCarClient.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarClient.AutoSize = true;
            labelCarClient.Location = new Point(3, 7);
            labelCarClient.Name = "labelCarClient";
            labelCarClient.Size = new Size(104, 15);
            labelCarClient.TabIndex = 0;
            labelCarClient.Text = "Клиент";
            // 
            // labelCarBrand
            // 
            labelCarBrand.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarBrand.AutoSize = true;
            labelCarBrand.Location = new Point(3, 36);
            labelCarBrand.Name = "labelCarBrand";
            labelCarBrand.Size = new Size(104, 15);
            labelCarBrand.TabIndex = 1;
            labelCarBrand.Text = "Марка";
            // 
            // labelCarModel
            // 
            labelCarModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarModel.AutoSize = true;
            labelCarModel.Location = new Point(3, 65);
            labelCarModel.Name = "labelCarModel";
            labelCarModel.Size = new Size(104, 15);
            labelCarModel.TabIndex = 2;
            labelCarModel.Text = "Модель";
            // 
            // labelCarStateMark
            // 
            labelCarStateMark.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarStateMark.AutoSize = true;
            labelCarStateMark.Location = new Point(3, 94);
            labelCarStateMark.Name = "labelCarStateMark";
            labelCarStateMark.Size = new Size(104, 15);
            labelCarStateMark.TabIndex = 3;
            labelCarStateMark.Text = "Госномер";
            // 
            // labelCarProductionYear
            // 
            labelCarProductionYear.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarProductionYear.AutoSize = true;
            labelCarProductionYear.Location = new Point(3, 123);
            labelCarProductionYear.Name = "labelCarProductionYear";
            labelCarProductionYear.Size = new Size(104, 15);
            labelCarProductionYear.TabIndex = 4;
            labelCarProductionYear.Text = "Год производства";
            // 
            // labelCarColor
            // 
            labelCarColor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarColor.AutoSize = true;
            labelCarColor.Location = new Point(3, 152);
            labelCarColor.Name = "labelCarColor";
            labelCarColor.Size = new Size(104, 15);
            labelCarColor.TabIndex = 5;
            labelCarColor.Text = "Цвет кузова";
            // 
            // labelCarVinNumber
            // 
            labelCarVinNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarVinNumber.AutoSize = true;
            labelCarVinNumber.Location = new Point(3, 181);
            labelCarVinNumber.Name = "labelCarVinNumber";
            labelCarVinNumber.Size = new Size(104, 15);
            labelCarVinNumber.TabIndex = 6;
            labelCarVinNumber.Text = "VIN";
            // 
            // comboBoxCarClient
            // 
            comboBoxCarClient.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCarClient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxCarClient.FormattingEnabled = true;
            comboBoxCarClient.Location = new Point(113, 3);
            comboBoxCarClient.Name = "comboBoxCarClient";
            comboBoxCarClient.Size = new Size(662, 23);
            comboBoxCarClient.TabIndex = 7;
            // 
            // comboBoxCarBrand
            // 
            comboBoxCarBrand.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCarBrand.FormattingEnabled = true;
            comboBoxCarBrand.Items.AddRange(new object[] { "Audi", "BMW", "Chevrolet", "Ford", "Honda", "Hyundai", "Kia", "Lada", "Lexus", "Mazda", "Mercedes-Benz", "Mitsubishi", "Nissan", "Renault", "Skoda", "Toyota", "Volkswagen", "Volvo", "Другая" });
            comboBoxCarBrand.Location = new Point(113, 32);
            comboBoxCarBrand.Name = "comboBoxCarBrand";
            comboBoxCarBrand.Size = new Size(662, 23);
            comboBoxCarBrand.TabIndex = 8;
            // 
            // comboBoxCarModel
            // 
            comboBoxCarModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCarModel.FormattingEnabled = true;
            comboBoxCarModel.Location = new Point(113, 61);
            comboBoxCarModel.Name = "comboBoxCarModel";
            comboBoxCarModel.Size = new Size(662, 23);
            comboBoxCarModel.TabIndex = 9;
            // 
            // maskedTextBoxCarStateMark
            // 
            maskedTextBoxCarStateMark.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            maskedTextBoxCarStateMark.Location = new Point(113, 90);
            maskedTextBoxCarStateMark.Mask = "L 000 LL 009";
            maskedTextBoxCarStateMark.Name = "maskedTextBoxCarStateMark";
            maskedTextBoxCarStateMark.Size = new Size(100, 23);
            maskedTextBoxCarStateMark.TabIndex = 10;
            // 
            // maskedTextBoxCarProductionYear
            // 
            maskedTextBoxCarProductionYear.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            maskedTextBoxCarProductionYear.Location = new Point(113, 119);
            maskedTextBoxCarProductionYear.Mask = "0000";
            maskedTextBoxCarProductionYear.Name = "maskedTextBoxCarProductionYear";
            maskedTextBoxCarProductionYear.Size = new Size(100, 23);
            maskedTextBoxCarProductionYear.TabIndex = 11;
            // 
            // comboBoxCarColor
            // 
            comboBoxCarColor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxCarColor.FormattingEnabled = true;
            comboBoxCarColor.Items.AddRange(new object[] { "Белый", "Черный", "Серый", "Серебристый", "Красный", "Синий", "Голубой", "Зеленый", "Желтый", "Оранжевый", "Коричневый", "Бежевый", "Золотой", "Другой" });
            comboBoxCarColor.Location = new Point(113, 148);
            comboBoxCarColor.Name = "comboBoxCarColor";
            comboBoxCarColor.Size = new Size(662, 23);
            comboBoxCarColor.TabIndex = 12;
            // 
            // maskedTextBoxCarVinNumber
            // 
            maskedTextBoxCarVinNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            maskedTextBoxCarVinNumber.Location = new Point(113, 177);
            maskedTextBoxCarVinNumber.Mask = "AAAAAAAAAAAAAAAAA";
            maskedTextBoxCarVinNumber.Name = "maskedTextBoxCarVinNumber";
            maskedTextBoxCarVinNumber.Size = new Size(150, 23);
            maskedTextBoxCarVinNumber.TabIndex = 13;
            // 
            // FormCar
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(784, 281);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 320);
            Name = "FormCar";
            Text = "Автомобиль";
            Load += FormCar_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelCarParams.ResumeLayout(false);
            tableLayoutPanelCarParams.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelCarParams;
        private Label labelCarClient;
        private Label labelCarBrand;
        private Label labelCarModel;
        private Label labelCarStateMark;
        private Label labelCarProductionYear;
        private Label labelCarColor;
        private Label labelCarVinNumber;
        private ComboBox comboBoxCarClient;
        private ComboBox comboBoxCarBrand;
        private ComboBox comboBoxCarModel;
        private MaskedTextBox maskedTextBoxCarStateMark;
        private MaskedTextBox maskedTextBoxCarProductionYear;
        private ComboBox comboBoxCarColor;
        private MaskedTextBox maskedTextBoxCarVinNumber;
    }
}
