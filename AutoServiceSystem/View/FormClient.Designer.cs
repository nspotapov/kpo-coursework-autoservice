namespace View
{
    partial class FormClient
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
            tableLayoutPanelClientParams = new TableLayoutPanel();
            labelType = new Label();
            labelLastName = new Label();
            labelFirstName = new Label();
            labelMiddleName = new Label();
            labelPhone = new Label();
            labelEmail = new Label();
            labelAddress = new Label();
            labelInn = new Label();
            comboBoxType = new ComboBox();
            textBoxLastName = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxMiddleName = new TextBox();
            maskedTextBoxPhone = new MaskedTextBox();
            textBoxEmail = new TextBox();
            textBoxAddress = new TextBox();
            textBoxInn = new TextBox();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelClientParams.SuspendLayout();
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
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelClientParams, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(784, 341);
            tableLayoutPanelWrapper.TabIndex = 2;
            //
            // flowLayoutPanelFormControl
            //
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonAccept);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 309);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(778, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelClientParams
            // 
            tableLayoutPanelClientParams.ColumnCount = 2;
            tableLayoutPanelClientParams.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelClientParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelClientParams.Controls.Add(labelType, 0, 0);
            tableLayoutPanelClientParams.Controls.Add(labelLastName, 0, 1);
            tableLayoutPanelClientParams.Controls.Add(labelFirstName, 0, 2);
            tableLayoutPanelClientParams.Controls.Add(labelMiddleName, 0, 3);
            tableLayoutPanelClientParams.Controls.Add(labelPhone, 0, 4);
            tableLayoutPanelClientParams.Controls.Add(labelEmail, 0, 5);
            tableLayoutPanelClientParams.Controls.Add(labelAddress, 0, 6);
            tableLayoutPanelClientParams.Controls.Add(labelInn, 0, 7);
            tableLayoutPanelClientParams.Controls.Add(comboBoxType, 1, 0);
            tableLayoutPanelClientParams.Controls.Add(textBoxLastName, 1, 1);
            tableLayoutPanelClientParams.Controls.Add(textBoxFirstName, 1, 2);
            tableLayoutPanelClientParams.Controls.Add(textBoxMiddleName, 1, 3);
            tableLayoutPanelClientParams.Controls.Add(maskedTextBoxPhone, 1, 4);
            tableLayoutPanelClientParams.Controls.Add(textBoxEmail, 1, 5);
            tableLayoutPanelClientParams.Controls.Add(textBoxAddress, 1, 6);
            tableLayoutPanelClientParams.Controls.Add(textBoxInn, 1, 7);
            tableLayoutPanelClientParams.Dock = DockStyle.Fill;
            tableLayoutPanelClientParams.Location = new Point(3, 3);
            tableLayoutPanelClientParams.Name = "tableLayoutPanelClientParams";
            tableLayoutPanelClientParams.RowCount = 9;
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelClientParams.Size = new Size(778, 300);
            tableLayoutPanelClientParams.TabIndex = 1;
            // 
            // labelType
            // 
            labelType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelType.AutoSize = true;
            labelType.Location = new Point(3, 7);
            labelType.Name = "labelType";
            labelType.Size = new Size(104, 15);
            labelType.TabIndex = 0;
            labelType.Text = "Тип клиента";
            // 
            // labelLastName
            // 
            labelLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(3, 36);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(104, 15);
            labelLastName.TabIndex = 1;
            labelLastName.Text = "Фамилия *";
            // 
            // labelFirstName
            // 
            labelFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(3, 65);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(104, 15);
            labelFirstName.TabIndex = 2;
            labelFirstName.Text = "Имя *";
            // 
            // labelMiddleName
            // 
            labelMiddleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelMiddleName.AutoSize = true;
            labelMiddleName.Location = new Point(3, 94);
            labelMiddleName.Name = "labelMiddleName";
            labelMiddleName.Size = new Size(104, 15);
            labelMiddleName.TabIndex = 3;
            labelMiddleName.Text = "Отчество";
            // 
            // labelPhone
            // 
            labelPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(3, 123);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(104, 15);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Телефон *";
            // 
            // labelEmail
            // 
            labelEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(3, 152);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(104, 15);
            labelEmail.TabIndex = 5;
            labelEmail.Text = "Email";
            // 
            // labelAddress
            // 
            labelAddress.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(3, 181);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(104, 15);
            labelAddress.TabIndex = 6;
            labelAddress.Text = "Адрес";
            // 
            // labelInn
            // 
            labelInn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelInn.AutoSize = true;
            labelInn.Location = new Point(3, 210);
            labelInn.Name = "labelInn";
            labelInn.Size = new Size(104, 15);
            labelInn.TabIndex = 7;
            labelInn.Text = "ИНН (необязательно)";
            // 
            // comboBoxType
            // 
            comboBoxType.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "Физическое лицо", "Юридическое лицо" });
            comboBoxType.Location = new Point(113, 3);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(662, 23);
            comboBoxType.TabIndex = 8;
            comboBoxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxLastName.Location = new Point(113, 32);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(662, 23);
            textBoxLastName.TabIndex = 9;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxFirstName.Location = new Point(113, 61);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(662, 23);
            textBoxFirstName.TabIndex = 10;
            // 
            // textBoxMiddleName
            // 
            textBoxMiddleName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxMiddleName.Location = new Point(113, 90);
            textBoxMiddleName.Name = "textBoxMiddleName";
            textBoxMiddleName.Size = new Size(662, 23);
            textBoxMiddleName.TabIndex = 11;
            // 
            // maskedTextBoxPhone
            // 
            maskedTextBoxPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            maskedTextBoxPhone.Location = new Point(113, 119);
            maskedTextBoxPhone.Mask = "+7 (000) 000-00-00";
            maskedTextBoxPhone.Name = "maskedTextBoxPhone";
            maskedTextBoxPhone.Size = new Size(200, 23);
            maskedTextBoxPhone.TabIndex = 12;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxEmail.Location = new Point(113, 148);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(662, 23);
            textBoxEmail.TabIndex = 13;
            // 
            // textBoxAddress
            // 
            textBoxAddress.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxAddress.Location = new Point(113, 177);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(662, 23);
            textBoxAddress.TabIndex = 14;
            // 
            // textBoxInn
            // 
            textBoxInn.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxInn.Location = new Point(113, 206);
            textBoxInn.Name = "textBoxInn";
            textBoxInn.Size = new Size(662, 23);
            textBoxInn.TabIndex = 15;
            // 
            // FormClient
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(784, 341);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 380);
            Name = "FormClient";
            Text = "Клиент";
            Load += FormClient_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelClientParams.ResumeLayout(false);
            tableLayoutPanelClientParams.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelClientParams;
        private Label labelType;
        private Label labelLastName;
        private Label labelFirstName;
        private Label labelMiddleName;
        private Label labelPhone;
        private Label labelEmail;
        private Label labelAddress;
        private Label labelInn;
        private ComboBox comboBoxType;
        private TextBox textBoxLastName;
        private TextBox textBoxFirstName;
        private TextBox textBoxMiddleName;
        private MaskedTextBox maskedTextBoxPhone;
        private TextBox textBoxEmail;
        private TextBox textBoxAddress;
        private TextBox textBoxInn;
    }
}
