namespace View
{
    partial class FormChecksList
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
            dataGridViewChecks = new DataGridView();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonClose = new Button();
            buttonDelete = new Button();
            buttonCreate = new Button();
            labelTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChecks).BeginInit();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewChecks
            // 
            dataGridViewChecks.AllowUserToAddRows = false;
            dataGridViewChecks.AllowUserToDeleteRows = false;
            dataGridViewChecks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChecks.Dock = DockStyle.Fill;
            dataGridViewChecks.Location = new Point(3, 4);
            dataGridViewChecks.Margin = new Padding(3, 4, 3, 4);
            dataGridViewChecks.MultiSelect = false;
            dataGridViewChecks.Name = "dataGridViewChecks";
            dataGridViewChecks.ReadOnly = true;
            dataGridViewChecks.RowHeadersVisible = false;
            dataGridViewChecks.RowHeadersWidth = 51;
            dataGridViewChecks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChecks.Size = new Size(1119, 586);
            dataGridViewChecks.TabIndex = 0;
            // 
            // tableLayoutPanelWrapper
            // 
            tableLayoutPanelWrapper.ColumnCount = 1;
            tableLayoutPanelWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.Controls.Add(flowLayoutPanelButtons, 0, 1);
            tableLayoutPanelWrapper.Controls.Add(dataGridViewChecks, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(1125, 641);
            tableLayoutPanelWrapper.TabIndex = 1;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.Controls.Add(buttonClose);
            flowLayoutPanelButtons.Controls.Add(buttonDelete);
            flowLayoutPanelButtons.Controls.Add(buttonCreate);
            flowLayoutPanelButtons.Dock = DockStyle.Fill;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 598);
            flowLayoutPanelButtons.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(1119, 39);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(1030, 4);
            buttonClose.Margin = new Padding(3, 4, 3, 4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(86, 31);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(933, 4);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(91, 31);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(801, 4);
            buttonCreate.Margin = new Padding(3, 4, 3, 4);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(126, 31);
            buttonCreate.TabIndex = 0;
            buttonCreate.Text = "Создать чек";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // labelTotal
            // 
            labelTotal.Anchor = AnchorStyles.Left;
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(3, 580);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(107, 20);
            labelTotal.TabIndex = 3;
            labelTotal.Text = "Всего чеков: 0";
            // 
            // FormChecksList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 641);
            Controls.Add(labelTotal);
            Controls.Add(tableLayoutPanelWrapper);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(1140, 678);
            Name = "FormChecksList";
            Text = "Чеки";
            Load += FormChecksList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewChecks).EndInit();
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewChecks;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonCreate;
        private Button buttonDelete;
        private Button buttonClose;
        private Label labelTotal;
    }
}
