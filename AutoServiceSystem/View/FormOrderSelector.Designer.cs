namespace View
{
    partial class FormOrderSelector
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
            dataGridViewOrders = new DataGridView();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCancel = new Button();
            buttonOK = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AllowUserToDeleteRows = false;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Dock = DockStyle.Fill;
            dataGridViewOrders.Location = new Point(3, 4);
            dataGridViewOrders.Margin = new Padding(3, 4, 3, 4);
            dataGridViewOrders.MultiSelect = false;
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.ReadOnly = true;
            dataGridViewOrders.RowHeadersVisible = false;
            dataGridViewOrders.RowHeadersWidth = 51;
            dataGridViewOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewOrders.Size = new Size(890, 520);
            dataGridViewOrders.TabIndex = 0;
            dataGridViewOrders.CellDoubleClick += dataGridViewOrders_CellDoubleClick;
            // 
            // tableLayoutPanelWrapper
            // 
            tableLayoutPanelWrapper.ColumnCount = 1;
            tableLayoutPanelWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.Controls.Add(flowLayoutPanelButtons, 0, 1);
            tableLayoutPanelWrapper.Controls.Add(dataGridViewOrders, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(896, 575);
            tableLayoutPanelWrapper.TabIndex = 1;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.Controls.Add(buttonCancel);
            flowLayoutPanelButtons.Controls.Add(buttonOK);
            flowLayoutPanelButtons.Dock = DockStyle.Fill;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 532);
            flowLayoutPanelButtons.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(890, 39);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(801, 4);
            buttonCancel.Margin = new Padding(3, 4, 3, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(86, 31);
            buttonCancel.TabIndex = 3;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(684, 4);
            buttonOK.Margin = new Padding(3, 4, 3, 4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(111, 31);
            buttonOK.TabIndex = 1;
            buttonOK.Text = "Выбрать";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // FormOrderSelector
            // 
            AcceptButton = buttonOK;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(896, 575);
            Controls.Add(tableLayoutPanelWrapper);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 611);
            Name = "FormOrderSelector";
            Text = "Выбор заявки";
            Load += FormOrderSelector_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewOrders;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonCancel;
        private Button buttonOK;
    }
}
