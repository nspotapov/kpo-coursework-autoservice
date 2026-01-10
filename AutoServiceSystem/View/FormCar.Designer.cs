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
            labelCarBrand = new Label();
            labelCarModel = new Label();
            labelCarStateMark = new Label();
            maskedTextBoxCarStateMark = new MaskedTextBox();
            labelCarProductionYear = new Label();
            maskedTextBoxCarProductionYear = new MaskedTextBox();
            labelCarColor = new Label();
            comboBoxCarColor = new ComboBox();
            comboBoxCarBrand = new ComboBox();
            comboBoxCarModel = new ComboBox();
            labelCarVinNumber = new Label();
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
            buttonAccept.TabIndex = 1;
            buttonAccept.Text = "Сохранить";
            buttonAccept.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(700, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 0;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
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
            tableLayoutPanelWrapper.Size = new Size(784, 231);
            tableLayoutPanelWrapper.TabIndex = 2;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonAccept);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 199);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(778, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelCarParams
            // 
            tableLayoutPanelCarParams.ColumnCount = 2;
            tableLayoutPanelCarParams.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelCarParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelCarParams.Controls.Add(labelCarBrand, 0, 0);
            tableLayoutPanelCarParams.Controls.Add(labelCarModel, 0, 1);
            tableLayoutPanelCarParams.Controls.Add(labelCarStateMark, 0, 2);
            tableLayoutPanelCarParams.Controls.Add(maskedTextBoxCarStateMark, 1, 2);
            tableLayoutPanelCarParams.Controls.Add(labelCarProductionYear, 0, 3);
            tableLayoutPanelCarParams.Controls.Add(maskedTextBoxCarProductionYear, 1, 3);
            tableLayoutPanelCarParams.Controls.Add(labelCarColor, 0, 4);
            tableLayoutPanelCarParams.Controls.Add(comboBoxCarColor, 1, 4);
            tableLayoutPanelCarParams.Controls.Add(comboBoxCarBrand, 1, 0);
            tableLayoutPanelCarParams.Controls.Add(comboBoxCarModel, 1, 1);
            tableLayoutPanelCarParams.Controls.Add(labelCarVinNumber, 0, 5);
            tableLayoutPanelCarParams.Controls.Add(maskedTextBoxCarVinNumber, 1, 5);
            tableLayoutPanelCarParams.Dock = DockStyle.Fill;
            tableLayoutPanelCarParams.Location = new Point(3, 3);
            tableLayoutPanelCarParams.Name = "tableLayoutPanelCarParams";
            tableLayoutPanelCarParams.RowCount = 7;
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelCarParams.Size = new Size(778, 190);
            tableLayoutPanelCarParams.TabIndex = 1;
            // 
            // labelCarBrand
            // 
            labelCarBrand.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarBrand.AutoSize = true;
            labelCarBrand.Location = new Point(3, 7);
            labelCarBrand.Name = "labelCarBrand";
            labelCarBrand.Size = new Size(104, 15);
            labelCarBrand.TabIndex = 0;
            labelCarBrand.Text = "Марка";
            // 
            // labelCarModel
            // 
            labelCarModel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarModel.AutoSize = true;
            labelCarModel.Location = new Point(3, 36);
            labelCarModel.Name = "labelCarModel";
            labelCarModel.Size = new Size(104, 15);
            labelCarModel.TabIndex = 4;
            labelCarModel.Text = "Модель";
            // 
            // labelCarStateMark
            // 
            labelCarStateMark.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarStateMark.AutoSize = true;
            labelCarStateMark.Location = new Point(3, 65);
            labelCarStateMark.Name = "labelCarStateMark";
            labelCarStateMark.Size = new Size(104, 15);
            labelCarStateMark.TabIndex = 5;
            labelCarStateMark.Text = "Госномер";
            // 
            // maskedTextBoxCarStateMark
            // 
            maskedTextBoxCarStateMark.Location = new Point(113, 61);
            maskedTextBoxCarStateMark.Mask = "L 000 LL 009";
            maskedTextBoxCarStateMark.Name = "maskedTextBoxCarStateMark";
            maskedTextBoxCarStateMark.Size = new Size(100, 23);
            maskedTextBoxCarStateMark.TabIndex = 6;
            // 
            // labelCarProductionYear
            // 
            labelCarProductionYear.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarProductionYear.AutoSize = true;
            labelCarProductionYear.Location = new Point(3, 94);
            labelCarProductionYear.Name = "labelCarProductionYear";
            labelCarProductionYear.Size = new Size(104, 15);
            labelCarProductionYear.TabIndex = 7;
            labelCarProductionYear.Text = "Год производства";
            // 
            // maskedTextBoxCarProductionYear
            // 
            maskedTextBoxCarProductionYear.Location = new Point(113, 90);
            maskedTextBoxCarProductionYear.Mask = "0000";
            maskedTextBoxCarProductionYear.Name = "maskedTextBoxCarProductionYear";
            maskedTextBoxCarProductionYear.Size = new Size(100, 23);
            maskedTextBoxCarProductionYear.TabIndex = 8;
            // 
            // labelCarColor
            // 
            labelCarColor.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarColor.AutoSize = true;
            labelCarColor.Location = new Point(3, 123);
            labelCarColor.Name = "labelCarColor";
            labelCarColor.Size = new Size(104, 15);
            labelCarColor.TabIndex = 9;
            labelCarColor.Text = "Цвет кузова";
            // 
            // comboBoxCarColor
            // 
            comboBoxCarColor.Dock = DockStyle.Fill;
            comboBoxCarColor.FormattingEnabled = true;
            comboBoxCarColor.Location = new Point(113, 119);
            comboBoxCarColor.Name = "comboBoxCarColor";
            comboBoxCarColor.Size = new Size(662, 23);
            comboBoxCarColor.TabIndex = 10;
            // 
            // comboBoxCarBrand
            // 
            comboBoxCarBrand.Dock = DockStyle.Fill;
            comboBoxCarBrand.FormattingEnabled = true;
            comboBoxCarBrand.Location = new Point(113, 3);
            comboBoxCarBrand.Name = "comboBoxCarBrand";
            comboBoxCarBrand.Size = new Size(662, 23);
            comboBoxCarBrand.TabIndex = 11;
            // 
            // comboBoxCarModel
            // 
            comboBoxCarModel.Dock = DockStyle.Fill;
            comboBoxCarModel.FormattingEnabled = true;
            comboBoxCarModel.Location = new Point(113, 32);
            comboBoxCarModel.Name = "comboBoxCarModel";
            comboBoxCarModel.Size = new Size(662, 23);
            comboBoxCarModel.TabIndex = 12;
            // 
            // labelCarVinNumber
            // 
            labelCarVinNumber.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelCarVinNumber.AutoSize = true;
            labelCarVinNumber.Location = new Point(3, 152);
            labelCarVinNumber.Name = "labelCarVinNumber";
            labelCarVinNumber.Size = new Size(104, 15);
            labelCarVinNumber.TabIndex = 13;
            labelCarVinNumber.Text = "VIN";
            // 
            // maskedTextBoxCarVinNumber
            // 
            maskedTextBoxCarVinNumber.Dock = DockStyle.Fill;
            maskedTextBoxCarVinNumber.Location = new Point(113, 148);
            maskedTextBoxCarVinNumber.Mask = "AAAAAAAAAAAAAAAAA";
            maskedTextBoxCarVinNumber.Name = "maskedTextBoxCarVinNumber";
            maskedTextBoxCarVinNumber.Size = new Size(662, 23);
            maskedTextBoxCarVinNumber.TabIndex = 14;
            // 
            // FormCar
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(784, 231);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 270);
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
        private Label labelCarBrand;
        private Label labelCarModel;
        private Label labelCarStateMark;
        private MaskedTextBox maskedTextBoxCarStateMark;
        private Label labelCarProductionYear;
        private MaskedTextBox maskedTextBoxCarProductionYear;
        private Label labelCarColor;
        private ComboBox comboBoxCarColor;
        private ComboBox comboBoxCarBrand;
        private ComboBox comboBoxCarModel;
        private Label labelCarVinNumber;
        private MaskedTextBox maskedTextBoxCarVinNumber;
    }
}