namespace View
{
    partial class FormService
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
            tableLayoutPanelServiceParams = new TableLayoutPanel();
            labelName = new Label();
            labelDescription = new Label();
            labelPrice = new Label();
            labelDuration = new Label();
            textBoxName = new TextBox();
            textBoxDescription = new TextBox();
            numericUpDownPrice = new NumericUpDown();
            numericUpDownDuration = new NumericUpDown();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelServiceParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).BeginInit();
            SuspendLayout();
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(539, 3);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(100, 23);
            buttonAccept.TabIndex = 4;
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
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelServiceParams, 0, 0);
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
            // tableLayoutPanelServiceParams
            // 
            tableLayoutPanelServiceParams.ColumnCount = 2;
            tableLayoutPanelServiceParams.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelServiceParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelServiceParams.Controls.Add(labelName, 0, 0);
            tableLayoutPanelServiceParams.Controls.Add(labelDescription, 0, 1);
            tableLayoutPanelServiceParams.Controls.Add(labelPrice, 0, 2);
            tableLayoutPanelServiceParams.Controls.Add(labelDuration, 0, 3);
            tableLayoutPanelServiceParams.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanelServiceParams.Controls.Add(textBoxDescription, 1, 1);
            tableLayoutPanelServiceParams.Controls.Add(numericUpDownPrice, 1, 2);
            tableLayoutPanelServiceParams.Controls.Add(numericUpDownDuration, 1, 3);
            tableLayoutPanelServiceParams.Dock = DockStyle.Fill;
            tableLayoutPanelServiceParams.Location = new Point(3, 3);
            tableLayoutPanelServiceParams.Name = "tableLayoutPanelServiceParams";
            tableLayoutPanelServiceParams.RowCount = 5;
            tableLayoutPanelServiceParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelServiceParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelServiceParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelServiceParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelServiceParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelServiceParams.Size = new Size(778, 190);
            tableLayoutPanelServiceParams.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelName.AutoSize = true;
            labelName.Location = new Point(3, 7);
            labelName.Name = "labelName";
            labelName.Size = new Size(104, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Наименование *";
            // 
            // labelDescription
            // 
            labelDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelDescription.AutoSize = true;
            labelDescription.Location = new Point(3, 36);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(104, 15);
            labelDescription.TabIndex = 1;
            labelDescription.Text = "Описание";
            // 
            // labelPrice
            // 
            labelPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(3, 65);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(104, 15);
            labelPrice.TabIndex = 2;
            labelPrice.Text = "Стоимость (₽) *";
            // 
            // labelDuration
            // 
            labelDuration.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelDuration.AutoSize = true;
            labelDuration.Location = new Point(3, 94);
            labelDuration.Name = "labelDuration";
            labelDuration.Size = new Size(104, 15);
            labelDuration.TabIndex = 3;
            labelDuration.Text = "Длительность (мин) *";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(113, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(662, 23);
            textBoxName.TabIndex = 4;
            // 
            // textBoxDescription
            // 
            textBoxDescription.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxDescription.Location = new Point(113, 32);
            textBoxDescription.Multiline = true;
            textBoxDescription.Name = "textBoxDescription";
            textBoxDescription.Size = new Size(662, 50);
            textBoxDescription.TabIndex = 5;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(113, 91);
            numericUpDownPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(150, 23);
            numericUpDownPrice.TabIndex = 6;
            // 
            // numericUpDownDuration
            // 
            numericUpDownDuration.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownDuration.Location = new Point(113, 120);
            numericUpDownDuration.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownDuration.Name = "numericUpDownDuration";
            numericUpDownDuration.Size = new Size(150, 23);
            numericUpDownDuration.TabIndex = 7;
            // 
            // FormService
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(784, 231);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 270);
            Name = "FormService";
            Text = "Услуга";
            Load += FormService_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelServiceParams.ResumeLayout(false);
            tableLayoutPanelServiceParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDuration).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelServiceParams;
        private Label labelName;
        private Label labelDescription;
        private Label labelPrice;
        private Label labelDuration;
        private TextBox textBoxName;
        private TextBox textBoxDescription;
        private NumericUpDown numericUpDownPrice;
        private NumericUpDown numericUpDownDuration;
    }
}
