namespace View
{
    partial class FormPart
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
            tableLayoutPanelPartParams = new TableLayoutPanel();
            labelName = new Label();
            labelArticle = new Label();
            labelPrice = new Label();
            labelQuantity = new Label();
            textBoxName = new TextBox();
            textBoxArticle = new TextBox();
            numericUpDownPrice = new NumericUpDown();
            numericUpDownQuantity = new NumericUpDown();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelPartParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).BeginInit();
            SuspendLayout();
            // 
            // buttonAccept
            // 
            buttonAccept.Location = new Point(671, 4);
            buttonAccept.Margin = new Padding(3, 4, 3, 4);
            buttonAccept.Name = "buttonAccept";
            buttonAccept.Size = new Size(124, 31);
            buttonAccept.TabIndex = 4;
            buttonAccept.Text = "Сохранить";
            buttonAccept.UseVisualStyleBackColor = true;
            buttonAccept.Click += buttonAccept_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(801, 4);
            buttonCancel.Margin = new Padding(3, 4, 3, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 31);
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
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelPartParams, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(896, 308);
            tableLayoutPanelWrapper.TabIndex = 2;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonAccept);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 265);
            flowLayoutPanelFormControl.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(890, 39);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelPartParams
            // 
            tableLayoutPanelPartParams.ColumnCount = 2;
            tableLayoutPanelPartParams.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanelPartParams.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelPartParams.Controls.Add(labelName, 0, 0);
            tableLayoutPanelPartParams.Controls.Add(labelArticle, 0, 1);
            tableLayoutPanelPartParams.Controls.Add(labelPrice, 0, 2);
            tableLayoutPanelPartParams.Controls.Add(labelQuantity, 0, 3);
            tableLayoutPanelPartParams.Controls.Add(textBoxName, 1, 0);
            tableLayoutPanelPartParams.Controls.Add(textBoxArticle, 1, 1);
            tableLayoutPanelPartParams.Controls.Add(numericUpDownPrice, 1, 2);
            tableLayoutPanelPartParams.Controls.Add(numericUpDownQuantity, 1, 3);
            tableLayoutPanelPartParams.Dock = DockStyle.Fill;
            tableLayoutPanelPartParams.Location = new Point(3, 4);
            tableLayoutPanelPartParams.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelPartParams.Name = "tableLayoutPanelPartParams";
            tableLayoutPanelPartParams.RowCount = 5;
            tableLayoutPanelPartParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelPartParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelPartParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelPartParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelPartParams.RowStyles.Add(new RowStyle());
            tableLayoutPanelPartParams.Size = new Size(890, 253);
            tableLayoutPanelPartParams.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelName.AutoSize = true;
            labelName.Location = new Point(3, 7);
            labelName.Name = "labelName";
            labelName.Size = new Size(126, 20);
            labelName.TabIndex = 0;
            labelName.Text = "Наименование *";
            // 
            // labelArticle
            // 
            labelArticle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelArticle.AutoSize = true;
            labelArticle.Location = new Point(3, 42);
            labelArticle.Name = "labelArticle";
            labelArticle.Size = new Size(126, 20);
            labelArticle.TabIndex = 1;
            labelArticle.Text = "Артикул";
            // 
            // labelPrice
            // 
            labelPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(3, 77);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(126, 20);
            labelPrice.TabIndex = 2;
            labelPrice.Text = "Стоимость (₽) *";
            // 
            // labelQuantity
            // 
            labelQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            labelQuantity.AutoSize = true;
            labelQuantity.Location = new Point(3, 112);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(126, 20);
            labelQuantity.TabIndex = 3;
            labelQuantity.Text = "На складе (шт) *";
            // 
            // textBoxName
            // 
            textBoxName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxName.Location = new Point(135, 4);
            textBoxName.Margin = new Padding(3, 4, 3, 4);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(752, 27);
            textBoxName.TabIndex = 4;
            // 
            // textBoxArticle
            // 
            textBoxArticle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBoxArticle.Location = new Point(135, 39);
            textBoxArticle.Margin = new Padding(3, 4, 3, 4);
            textBoxArticle.Name = "textBoxArticle";
            textBoxArticle.Size = new Size(752, 27);
            textBoxArticle.TabIndex = 5;
            // 
            // numericUpDownPrice
            // 
            numericUpDownPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownPrice.DecimalPlaces = 2;
            numericUpDownPrice.Location = new Point(135, 74);
            numericUpDownPrice.Margin = new Padding(3, 4, 3, 4);
            numericUpDownPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownPrice.Name = "numericUpDownPrice";
            numericUpDownPrice.Size = new Size(752, 27);
            numericUpDownPrice.TabIndex = 6;
            // 
            // numericUpDownQuantity
            // 
            numericUpDownQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            numericUpDownQuantity.Location = new Point(135, 109);
            numericUpDownQuantity.Margin = new Padding(3, 4, 3, 4);
            numericUpDownQuantity.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownQuantity.Name = "numericUpDownQuantity";
            numericUpDownQuantity.Size = new Size(752, 27);
            numericUpDownQuantity.TabIndex = 7;
            // 
            // FormPart
            // 
            AcceptButton = buttonAccept;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(896, 308);
            Controls.Add(tableLayoutPanelWrapper);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 344);
            Name = "FormPart";
            Text = "Запчасть";
            Load += FormPart_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelPartParams.ResumeLayout(false);
            tableLayoutPanelPartParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownQuantity).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonAccept;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelPartParams;
        private Label labelName;
        private Label labelArticle;
        private Label labelPrice;
        private Label labelQuantity;
        private TextBox textBoxName;
        private TextBox textBoxArticle;
        private NumericUpDown numericUpDownPrice;
        private NumericUpDown numericUpDownQuantity;
    }
}
