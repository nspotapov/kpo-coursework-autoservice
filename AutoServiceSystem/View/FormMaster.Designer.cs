namespace View
{
    partial class FormMaster
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
            tableLayoutPanelMasterParams = new TableLayoutPanel();
            labelLastName = new Label();
            labelFirstName = new Label();
            labelMiddleName = new Label();
            labelPhone = new Label();
            labelBirthDate = new Label();
            labelExperience = new Label();
            textBoxLastName = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxMiddleName = new TextBox();
            maskedTextBoxPhone = new MaskedTextBox();
            dateTimePickerBirthDate = new DateTimePicker();
            numericUpDownExperience = new NumericUpDown();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelMasterParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExperience).BeginInit();
            SuspendLayout();
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(539, 3);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(100, 23);
            buttonAccept.TabIndex = 6;
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
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelMasterParams, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(784, 291);
            tableLayoutPanelWrapper.TabIndex = 2;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonAccept);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 259);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(778, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelMasterParams
            // 
            tableLayoutPanelMasterParams.ColumnCount = 2;
            tableLayoutPanelMasterParams.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelMasterParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelMasterParams.Controls.Add(labelLastName, 0, 0);
            tableLayoutPanelMasterParams.Controls.Add(labelFirstName, 0, 1);
            tableLayoutPanelMasterParams.Controls.Add(labelMiddleName, 0, 2);
            tableLayoutPanelMasterParams.Controls.Add(labelPhone, 0, 3);
            tableLayoutPanelMasterParams.Controls.Add(labelBirthDate, 0, 4);
            tableLayoutPanelMasterParams.Controls.Add(labelExperience, 0, 5);
            tableLayoutPanelMasterParams.Controls.Add(textBoxLastName, 1, 0);
            tableLayoutPanelMasterParams.Controls.Add(textBoxFirstName, 1, 1);
            tableLayoutPanelMasterParams.Controls.Add(textBoxMiddleName, 1, 2);
            tableLayoutPanelMasterParams.Controls.Add(maskedTextBoxPhone, 1, 3);
            tableLayoutPanelMasterParams.Controls.Add(dateTimePickerBirthDate, 1, 4);
            tableLayoutPanelMasterParams.Controls.Add(numericUpDownExperience, 1, 5);
            tableLayoutPanelMasterParams.Dock = DockStyle.Fill;
            tableLayoutPanelMasterParams.Location = new Point(3, 3);
            tableLayoutPanelMasterParams.Name = "tableLayoutPanelMasterParams";
            tableLayoutPanelMasterParams.RowCount = 7;
            tableLayoutPanelMasterParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelMasterParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelMasterParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelMasterParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelMasterParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelMasterParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelMasterParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelMasterParams.Size = new Size(778, 250);
            tableLayoutPanelMasterParams.TabIndex = 1;
            // 
            // labelLastName
            // 
            labelLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(3, 7);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(104, 15);
            labelLastName.TabIndex = 0;
            labelLastName.Text = "Фамилия *";
            // 
            // labelFirstName
            // 
            labelFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(3, 36);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(104, 15);
            labelFirstName.TabIndex = 1;
            labelFirstName.Text = "Имя *";
            // 
            // labelMiddleName
            // 
            labelMiddleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelMiddleName.AutoSize = true;
            labelMiddleName.Location = new Point(3, 65);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(104, 15);
            labelMiddleName.TabIndex = 2;
            labelMiddleName.Text = "Отчество";
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(3, 94);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(104, 15);
            labelPhone.TabIndex = 3;
            labelPhone.Text = "Телефон";
            // 
            // labelBirthDate
            // 
            labelBirthDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelBirthDate.AutoSize = true;
            labelBirthDate.Location = new Point(3, 123);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(104, 15);
            labelBirthDate.TabIndex = 4;
            labelBirthDate.Text = "Дата рождения";
            // 
            // labelExperience
            // 
            labelExperience.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelExperience.AutoSize = true;
            labelExperience.Location = new Point(3, 152);
            labelExperience.Name = "labelExperience";
            labelExperience.Size = new Size(104, 15);
            labelExperience.TabIndex = 5;
            labelExperience.Text = "Стаж (лет)";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxLastName.Location = new Point(113, 3);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(662, 23);
            textBoxLastName.TabIndex = 6;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxFirstName.Location = new Point(113, 32);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(662, 23);
            textBoxFirstName.TabIndex = 7;
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxMiddleName.Location = new Point(113, 61);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(662, 23);
            textBoxMiddleName.TabIndex = 8;
            // 
            // maskedTextBoxPhone
            // 
            maskedTextBoxPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            maskedTextBoxPhone.Location = new Point(113, 90);
            maskedTextBoxPhone.Mask = "+7 (000) 000-00-00";
            maskedTextBoxPhone.Name = "maskedTextBoxPhone";
            maskedTextBoxPhone.Size = new Size(200, 23);
            maskedTextBoxPhone.TabIndex = 9;
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerBirthDate.Format = DateTimePickerFormat.Short;
            dateTimePickerBirthDate.Location = new Point(113, 119);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(200, 23);
            dateTimePickerBirthDate.TabIndex = 10;
            // 
            // numericUpDownExperience
            // 
            numericUpDownExperience.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownExperience.Location = new Point(113, 148);
            numericUpDownExperience.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numericUpDownExperience.Name = "numericUpDownExperience";
            numericUpDownExperience.Size = new Size(100, 23);
            numericUpDownExperience.TabIndex = 11;
            // 
            // FormMaster
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(784, 291);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 330);
            Name = "FormMaster";
            Text = "Мастер";
            Load += FormMaster_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelMasterParams.ResumeLayout(false);
            tableLayoutPanelMasterParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownExperience).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelMasterParams;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelMiddleName;
        private Label labelPhone;
        private Label labelBirthDate;
        private Label labelExperience;
        private TextBox textBoxLastName;
        private TextBox textBoxFirstName;
        private TextBox textBoxMiddleName;
        private MaskedTextBox maskedTextBoxPhone;
        private DateTimePicker dateTimePickerBirthDate;
        private NumericUpDown numericUpDownExperience;
    }
}
