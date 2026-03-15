namespace View
{
    partial class FormUser
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
            tableLayoutPanelUserParams = new TableLayoutPanel();
            labelUsername = new Label();
            labelPassword = new Label();
            labelLastName = new Label();
            labelFirstName = new Label();
            labelMiddleName = new Label();
            labelPhone = new Label();
            labelBirthDate = new Label();
            labelRole = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            textBoxLastName = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxMiddleName = new TextBox();
            maskedTextBoxPhone = new MaskedTextBox();
            dateTimePickerBirthDate = new DateTimePicker();
            comboBoxRole = new ComboBox();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelUserParams.SuspendLayout();
            SuspendLayout();
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(539, 3);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(100, 23);
            buttonAccept.TabIndex = 8;
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
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelUserParams, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(784, 411);
            tableLayoutPanelWrapper.TabIndex = 2;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonAccept);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 379);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(778, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelUserParams
            // 
            tableLayoutPanelUserParams.ColumnCount = 2;
            tableLayoutPanelUserParams.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelUserParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelUserParams.Controls.Add(labelUsername, 0, 0);
            tableLayoutPanelUserParams.Controls.Add(labelPassword, 0, 1);
            tableLayoutPanelUserParams.Controls.Add(labelLastName, 0, 2);
            tableLayoutPanelUserParams.Controls.Add(labelFirstName, 0, 3);
            tableLayoutPanelUserParams.Controls.Add(labelMiddleName, 0, 4);
            tableLayoutPanelUserParams.Controls.Add(labelPhone, 0, 5);
            tableLayoutPanelUserParams.Controls.Add(labelBirthDate, 0, 6);
            tableLayoutPanelUserParams.Controls.Add(labelRole, 0, 7);
            tableLayoutPanelUserParams.Controls.Add(textBoxUsername, 1, 0);
            tableLayoutPanelUserParams.Controls.Add(textBoxPassword, 1, 1);
            tableLayoutPanelUserParams.Controls.Add(textBoxLastName, 1, 2);
            tableLayoutPanelUserParams.Controls.Add(textBoxFirstName, 1, 3);
            tableLayoutPanelUserParams.Controls.Add(textBoxMiddleName, 1, 4);
            tableLayoutPanelUserParams.Controls.Add(maskedTextBoxPhone, 1, 5);
            tableLayoutPanelUserParams.Controls.Add(dateTimePickerBirthDate, 1, 6);
            tableLayoutPanelUserParams.Controls.Add(comboBoxRole, 1, 7);
            tableLayoutPanelUserParams.Dock = DockStyle.Fill;
            tableLayoutPanelUserParams.Location = new Point(3, 3);
            tableLayoutPanelUserParams.Name = "tableLayoutPanelUserParams";
            tableLayoutPanelUserParams.RowCount = 9;
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelUserParams.Size = new Size(778, 370);
            tableLayoutPanelUserParams.TabIndex = 1;
            // 
            // labelUsername
            // 
            labelUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelUsername.AutoSize = true;
            labelUsername.Location = new Point(3, 7);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(104, 15);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Логин *";
            // 
            // labelPassword
            // 
            labelPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(3, 36);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(104, 15);
            labelPassword.TabIndex = 1;
            labelPassword.Text = "Пароль";
            // 
            // labelLastName
            // 
            labelLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(3, 65);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(104, 15);
            labelLastName.TabIndex = 2;
            labelLastName.Text = "Фамилия *";
            // 
            // labelFirstName
            // 
            labelFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(3, 94);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(104, 15);
            labelFirstName.TabIndex = 3;
            labelFirstName.Text = "Имя *";
            // 
            // labelMiddleName
            // 
            labelMiddleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelMiddleName.AutoSize = true;
            labelMiddleName.Location = new Point(3, 123);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(104, 15);
            labelMiddleName.TabIndex = 4;
            labelMiddleName.Text = "Отчество";
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(3, 152);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(104, 15);
            labelPhone.TabIndex = 5;
            labelPhone.Text = "Телефон";
            // 
            // labelBirthDate
            // 
            labelBirthDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelBirthDate.AutoSize = true;
            labelBirthDate.Location = new Point(3, 181);
            labelBirthDate.Name = "labelBirthDate";
            labelBirthDate.Size = new Size(104, 15);
            labelBirthDate.TabIndex = 6;
            labelBirthDate.Text = "Дата рождения";
            // 
            // labelRole
            // 
            labelRole.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelRole.AutoSize = true;
            labelRole.Location = new Point(3, 210);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(104, 15);
            labelRole.TabIndex = 7;
            labelRole.Text = "Роль";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxUsername.Location = new Point(113, 3);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(662, 23);
            textBoxUsername.TabIndex = 8;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Location = new Point(113, 32);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Требуется только при создании";
            textBoxPassword.Size = new Size(662, 23);
            textBoxPassword.TabIndex = 9;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxLastName.Location = new Point(113, 61);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(662, 23);
            textBoxLastName.TabIndex = 10;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxFirstName.Location = new Point(113, 90);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(662, 23);
            textBoxFirstName.TabIndex = 11;
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxMiddleName.Location = new Point(113, 119);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(662, 23);
            textBoxMiddleName.TabIndex = 12;
            // 
            // maskedTextBoxPhone
            // 
            maskedTextBoxPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            maskedTextBoxPhone.Location = new Point(113, 148);
            maskedTextBoxPhone.Mask = "+7 (000) 000-00-00";
            maskedTextBoxPhone.Name = "maskedTextBoxPhone";
            maskedTextBoxPhone.Size = new Size(200, 23);
            maskedTextBoxPhone.TabIndex = 13;
            // 
            // dateTimePickerBirthDate
            // 
            dateTimePickerBirthDate.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dateTimePickerBirthDate.Format = DateTimePickerFormat.Short;
            dateTimePickerBirthDate.Location = new Point(113, 177);
            dateTimePickerBirthDate.Name = "dateTimePickerBirthDate";
            dateTimePickerBirthDate.Size = new Size(200, 23);
            dateTimePickerBirthDate.TabIndex = 14;
            // 
            // comboBoxRole
            // 
            comboBoxRole.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Items.AddRange(new object[] { "Администратор", "Менеджер" });
            comboBoxRole.Location = new Point(113, 206);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(662, 23);
            comboBoxRole.TabIndex = 15;
            // 
            // FormUser
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(784, 411);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 450);
            Name = "FormUser";
            Text = "Пользователь";
            Load += FormUser_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelUserParams.ResumeLayout(false);
            tableLayoutPanelUserParams.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelUserParams;
        private Label labelUsername;
        private Label labelPassword;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelMiddleName;
        private Label labelPhone;
        private Label labelBirthDate;
        private Label labelRole;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private TextBox textBoxLastName;
        private TextBox textBoxFirstName;
        private TextBox textBoxMiddleName;
        private MaskedTextBox maskedTextBoxPhone;
        private DateTimePicker dateTimePickerBirthDate;
        private ComboBox comboBoxRole;
    }
}
