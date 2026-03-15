namespace View
{
    partial class FormMastersList
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
            dataGridViewMasters = new DataGridView();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonClose = new Button();
            buttonDelete = new Button();
            buttonEdit = new Button();
            buttonCreate = new Button();
            labelTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMasters).BeginInit();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewMasters
            // 
            dataGridViewMasters.AllowUserToAddRows = false;
            dataGridViewMasters.AllowUserToDeleteRows = false;
            dataGridViewMasters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMasters.Dock = DockStyle.Fill;
            dataGridViewMasters.Location = new Point(3, 4);
            dataGridViewMasters.Margin = new Padding(3, 4, 3, 4);
            dataGridViewMasters.MultiSelect = false;
            dataGridViewMasters.Name = "dataGridViewMasters";
            dataGridViewMasters.ReadOnly = true;
            dataGridViewMasters.RowHeadersVisible = false;
            dataGridViewMasters.RowHeadersWidth = 51;
            dataGridViewMasters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMasters.Size = new Size(890, 520);
            dataGridViewMasters.TabIndex = 0;
            dataGridViewMasters.CellDoubleClick += dataGridViewMasters_CellDoubleClick;
            //
            // tableLayoutPanelWrapper
            // 
            tableLayoutPanelWrapper.ColumnCount = 1;
            tableLayoutPanelWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.Controls.Add(flowLayoutPanelButtons, 0, 1);
            tableLayoutPanelWrapper.Controls.Add(dataGridViewMasters, 0, 0);
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
            flowLayoutPanelButtons.Controls.Add(buttonClose);
            flowLayoutPanelButtons.Controls.Add(buttonDelete);
            flowLayoutPanelButtons.Controls.Add(buttonEdit);
            flowLayoutPanelButtons.Controls.Add(buttonCreate);
            flowLayoutPanelButtons.Dock = DockStyle.Fill;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 532);
            flowLayoutPanelButtons.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(890, 39);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(801, 4);
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
            buttonDelete.Location = new Point(704, 4);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(91, 31);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(612, 4);
            buttonEdit.Margin = new Padding(3, 4, 3, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(86, 31);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(503, 4);
            buttonCreate.Margin = new Padding(3, 4, 3, 4);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(103, 31);
            buttonCreate.TabIndex = 0;
            buttonCreate.Text = "Создать";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // labelTotal
            // 
            labelTotal.Anchor = AnchorStyles.Left;
            labelTotal.AutoSize = true;
            labelTotal.Location = new Point(3, 511);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(133, 20);
            labelTotal.TabIndex = 3;
            labelTotal.Text = "Всего мастеров: 0";
            // 
            // FormMastersList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 575);
            Controls.Add(labelTotal);
            Controls.Add(tableLayoutPanelWrapper);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 611);
            Name = "FormMastersList";
            Text = "Управление мастерами";
            Load += FormMastersList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewMasters).EndInit();
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewMasters;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonCreate;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonClose;
        private Label labelTotal;
    }
}
