namespace View
{
    partial class FormUsersList
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
            dataGridViewUsers = new DataGridView();
            ColumnUserId = new DataGridViewTextBoxColumn();
            ColumnUsername = new DataGridViewTextBoxColumn();
            ColumnFullName = new DataGridViewTextBoxColumn();
            ColumnRole = new DataGridViewTextBoxColumn();
            ColumnCreatedAt = new DataGridViewTextBoxColumn();
            ColumnStatus = new DataGridViewTextBoxColumn();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelButtons = new FlowLayoutPanel();
            buttonCreate = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            buttonClose = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).BeginInit();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewUsers
            // 
            dataGridViewUsers.AllowUserToAddRows = false;
            dataGridViewUsers.AllowUserToDeleteRows = false;
            dataGridViewUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewUsers.Columns.AddRange(new DataGridViewColumn[] { ColumnUserId, ColumnUsername, ColumnFullName, ColumnRole, ColumnCreatedAt, ColumnStatus });
            dataGridViewUsers.Dock = DockStyle.Fill;
            dataGridViewUsers.Location = new Point(3, 4);
            dataGridViewUsers.Margin = new Padding(3, 4, 3, 4);
            dataGridViewUsers.MultiSelect = false;
            dataGridViewUsers.Name = "dataGridViewUsers";
            dataGridViewUsers.ReadOnly = true;
            dataGridViewUsers.RowHeadersVisible = false;
            dataGridViewUsers.RowHeadersWidth = 51;
            dataGridViewUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsers.Size = new Size(890, 493);
            dataGridViewUsers.TabIndex = 0;
            dataGridViewUsers.CellDoubleClick += dataGridViewUsers_CellDoubleClick;
            // 
            // ColumnUserId
            // 
            ColumnUserId.HeaderText = "Id";
            ColumnUserId.MinimumWidth = 6;
            ColumnUserId.Name = "ColumnUserId";
            ColumnUserId.ReadOnly = true;
            ColumnUserId.Visible = false;
            ColumnUserId.Width = 125;
            // 
            // ColumnUsername
            // 
            ColumnUsername.HeaderText = "Логин";
            ColumnUsername.MinimumWidth = 6;
            ColumnUsername.Name = "ColumnUsername";
            ColumnUsername.ReadOnly = true;
            ColumnUsername.Width = 125;
            // 
            // ColumnFullName
            // 
            ColumnFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColumnFullName.HeaderText = "ФИО";
            ColumnFullName.MinimumWidth = 6;
            ColumnFullName.Name = "ColumnFullName";
            ColumnFullName.ReadOnly = true;
            // 
            // ColumnRole
            // 
            ColumnRole.HeaderText = "Роль";
            ColumnRole.MinimumWidth = 6;
            ColumnRole.Name = "ColumnRole";
            ColumnRole.ReadOnly = true;
            ColumnRole.Width = 125;
            // 
            // ColumnCreatedAt
            // 
            ColumnCreatedAt.HeaderText = "Создан";
            ColumnCreatedAt.MinimumWidth = 6;
            ColumnCreatedAt.Name = "ColumnCreatedAt";
            ColumnCreatedAt.ReadOnly = true;
            ColumnCreatedAt.Width = 125;
            // 
            // ColumnStatus
            // 
            ColumnStatus.HeaderText = "Статус";
            ColumnStatus.MinimumWidth = 6;
            ColumnStatus.Name = "ColumnStatus";
            ColumnStatus.ReadOnly = true;
            ColumnStatus.Width = 125;
            // 
            // tableLayoutPanelWrapper
            // 
            tableLayoutPanelWrapper.ColumnCount = 1;
            tableLayoutPanelWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.Controls.Add(flowLayoutPanelButtons, 0, 1);
            tableLayoutPanelWrapper.Controls.Add(dataGridViewUsers, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(896, 548);
            tableLayoutPanelWrapper.TabIndex = 1;
            // 
            // flowLayoutPanelButtons
            // 
            flowLayoutPanelButtons.AutoSize = true;
            flowLayoutPanelButtons.Controls.Add(buttonCreate);
            flowLayoutPanelButtons.Controls.Add(buttonEdit);
            flowLayoutPanelButtons.Controls.Add(buttonDelete);
            flowLayoutPanelButtons.Controls.Add(buttonClose);
            flowLayoutPanelButtons.Dock = DockStyle.Fill;
            flowLayoutPanelButtons.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelButtons.Location = new Point(3, 505);
            flowLayoutPanelButtons.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            flowLayoutPanelButtons.Size = new Size(890, 39);
            flowLayoutPanelButtons.TabIndex = 0;
            // 
            // buttonCreate
            // 
            buttonCreate.Location = new Point(801, 4);
            buttonCreate.Margin = new Padding(3, 4, 3, 4);
            buttonCreate.Name = "buttonCreate";
            buttonCreate.Size = new Size(86, 31);
            buttonCreate.TabIndex = 0;
            buttonCreate.Text = "Создать";
            buttonCreate.UseVisualStyleBackColor = true;
            buttonCreate.Click += buttonCreate_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Location = new Point(709, 4);
            buttonEdit.Margin = new Padding(3, 4, 3, 4);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(86, 31);
            buttonEdit.TabIndex = 1;
            buttonEdit.Text = "Изменить";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Location = new Point(612, 4);
            buttonDelete.Margin = new Padding(3, 4, 3, 4);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(91, 31);
            buttonDelete.TabIndex = 2;
            buttonDelete.Text = "Удалить";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // buttonClose
            // 
            buttonClose.Location = new Point(520, 4);
            buttonClose.Margin = new Padding(3, 4, 3, 4);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(86, 31);
            buttonClose.TabIndex = 3;
            buttonClose.Text = "Закрыть";
            buttonClose.UseVisualStyleBackColor = true;
            buttonClose.Click += buttonClose_Click;
            // 
            // FormUsersList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 548);
            Controls.Add(tableLayoutPanelWrapper);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(912, 584);
            Name = "FormUsersList";
            Text = "Управление пользователями";
            Load += FormUsersList_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewUsers).EndInit();
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridViewUsers;
        private DataGridViewTextBoxColumn ColumnUserId;
        private DataGridViewTextBoxColumn ColumnUsername;
        private DataGridViewTextBoxColumn ColumnFullName;
        private DataGridViewTextBoxColumn ColumnRole;
        private DataGridViewTextBoxColumn ColumnCreatedAt;
        private DataGridViewTextBoxColumn ColumnStatus;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonCreate;
        private Button buttonEdit;
        private Button buttonDelete;
        private Button buttonClose;
    }
}
