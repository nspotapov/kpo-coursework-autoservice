namespace View
{
    partial class FormAuth
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
            label1 = new Label();
            textBoxPassword = new TextBox();
            textBoxUsername = new TextBox();
            buttonSubmit = new Button();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            groupBoxAuthForm = new GroupBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            statusStrip.SuspendLayout();
            groupBoxAuthForm.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(62, 10);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 0;
            label1.Text = "Авторизация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxPassword.Location = new Point(6, 69);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PlaceholderText = "Пароль";
            textBoxPassword.Size = new Size(190, 23);
            textBoxPassword.TabIndex = 2;
            textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            textBoxUsername.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxUsername.Location = new Point(6, 34);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.PlaceholderText = "Имя пользователя";
            textBoxUsername.Size = new Size(190, 23);
            textBoxUsername.TabIndex = 1;
            // 
            // buttonSubmit
            // 
            buttonSubmit.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            buttonSubmit.Location = new Point(71, 98);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(60, 23);
            buttonSubmit.TabIndex = 3;
            buttonSubmit.Text = "Войти";
            buttonSubmit.UseVisualStyleBackColor = true;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 419);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(624, 22);
            statusStrip.TabIndex = 4;
            statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(112, 17);
            toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // groupBoxAuthForm
            // 
            groupBoxAuthForm.Controls.Add(label1);
            groupBoxAuthForm.Controls.Add(textBoxPassword);
            groupBoxAuthForm.Controls.Add(buttonSubmit);
            groupBoxAuthForm.Controls.Add(textBoxUsername);
            groupBoxAuthForm.Dock = DockStyle.Fill;
            groupBoxAuthForm.Location = new Point(211, 142);
            groupBoxAuthForm.Name = "groupBoxAuthForm";
            groupBoxAuthForm.Size = new Size(202, 133);
            groupBoxAuthForm.TabIndex = 5;
            groupBoxAuthForm.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(groupBoxAuthForm, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(624, 419);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // FormAuth
            // 
            AcceptButton = buttonSubmit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 441);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(statusStrip);
            MinimumSize = new Size(640, 480);
            Name = "FormAuth";
            Text = "ИС Автосервис";
            Load += FormAuth_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            groupBoxAuthForm.ResumeLayout(false);
            groupBoxAuthForm.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxPassword;
        private TextBox textBoxUsername;
        private Button buttonSubmit;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private GroupBox groupBoxAuthForm;
        private TableLayoutPanel tableLayoutPanel1;
    }
}