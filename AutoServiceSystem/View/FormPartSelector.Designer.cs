namespace View
{
    partial class FormPartSelector
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
            dataGridViewParts = new DataGridView();
            buttonOK = new Button();
            buttonCancel = new Button();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParts).BeginInit();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewParts
            // 
            dataGridViewParts.AllowUserToAddRows = false;
            dataGridViewParts.AllowUserToDeleteRows = false;
            dataGridViewParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewParts.Dock = DockStyle.Fill;
            dataGridViewParts.Location = new Point(3, 4);
            dataGridViewParts.Margin = new Padding(3, 4, 3, 4);
            dataGridViewParts.MultiSelect = false;
            dataGridViewParts.Name = "dataGridViewParts";
            dataGridViewParts.ReadOnly = true;
            dataGridViewParts.RowHeadersVisible = false;
            dataGridViewParts.RowHeadersWidth = 51;
            dataGridViewParts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewParts.Size = new Size(776, 466);
            dataGridViewParts.TabIndex = 0;
            dataGridViewParts.CellDoubleClick += dataGridViewParts_CellDoubleClick;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(595, 4);
            buttonOK.Margin = new Padding(3, 4, 3, 4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(86, 31);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "Выбрать";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(687, 4);
            buttonCancel.Margin = new Padding(3, 4, 3, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 31);
            buttonCancel.TabIndex = 2;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // tableLayoutPanelWrapper
            // 
            tableLayoutPanelWrapper.ColumnCount = 1;
            tableLayoutPanelWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.Controls.Add(flowLayoutPanelButtons, 0, 1);
            tableLayoutPanelWrapper.Controls.Add(dataGridViewParts, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(782, 521);
            tableLayoutPanelWrapper.TabIndex = 1;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.Controls.Add(buttonCancel);
            flowLayoutPanelButtons.Controls.Add(buttonOK);
            flowLayoutPanelButtons.Dock = DockStyle.Fill;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 478);
            flowLayoutPanelButtons.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(776, 39);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // FormPartSelector
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(782, 521);
            Controls.Add(tableLayoutPanelWrapper);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(797, 558);
            Name = "FormPartSelector";
            Text = "Выбор запчасти";
            ((System.ComponentModel.ISupportInitialize)dataGridViewParts).EndInit();
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewParts;
        private Button buttonOK;
        private Button buttonCancel;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelButtons;
    }
}
