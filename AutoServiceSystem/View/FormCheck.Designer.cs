namespace View
{
    partial class FormCheck
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
            buttonCreateCheck = new Button();
            buttonCancel = new Button();
            buttonPrintHtml = new Button();
            tableLayoutPanelWrapper = new TableLayoutPanel();
            flowLayoutPanelFormControl = new FlowLayoutPanel();
            tableLayoutPanelMain = new TableLayoutPanel();
            labelOrderNumber = new Label();
            labelClientName = new Label();
            labelCarInfo = new Label();
            labelMasterName = new Label();
            labelManagerName = new Label();
            labelServiceDateTime = new Label();
            labelOrderNumberLabel = new Label();
            labelClientNameLabel = new Label();
            labelCarInfoLabel = new Label();
            labelMasterNameLabel = new Label();
            labelManagerNameLabel = new Label();
            labelServiceDateTimeLabel = new Label();
            dataGridViewServices = new DataGridView();
            dataGridViewParts = new DataGridView();
            labelServicesTotal = new Label();
            labelPartsTotal = new Label();
            labelTotalAmount = new Label();
            labelServicesTotalLabel = new Label();
            labelPartsTotalLabel = new Label();
            labelTotalAmountLabel = new Label();
            tableLayoutPanelWrapper.SuspendLayout();
            flowLayoutPanelFormControl.SuspendLayout();
            tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParts).BeginInit();
            SuspendLayout();
            // 
            // buttonCreateCheck
            // 
            buttonCreateCheck.Location = new Point(520, 3);
            buttonCreateCheck.Name = "buttonCreateCheck";
            buttonCreateCheck.Size = new Size(120, 23);
            buttonCreateCheck.TabIndex = 0;
            buttonCreateCheck.Text = "✅ Создать чек";
            buttonCreateCheck.UseVisualStyleBackColor = true;
            buttonCreateCheck.BackColor = Color.LightGreen;
            buttonCreateCheck.Click += buttonCreateCheck_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(646, 3);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 1;
            buttonCancel.Text = "Закрыть";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonPrintHtml
            // 
            buttonPrintHtml.Location = new Point(400, 3);
            buttonPrintHtml.Name = "buttonPrintHtml";
            buttonPrintHtml.Size = new Size(114, 23);
            buttonPrintHtml.TabIndex = 2;
            buttonPrintHtml.Text = "🖨 Печать HTML";
            buttonPrintHtml.UseVisualStyleBackColor = true;
            buttonPrintHtml.Click += buttonPrintHtml_Click;
            // 
            // tableLayoutPanelWrapper
            // 
            tableLayoutPanelWrapper.ColumnCount = 1;
            tableLayoutPanelWrapper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.Controls.Add(flowLayoutPanelFormControl, 0, 1);
            tableLayoutPanelWrapper.Controls.Add(tableLayoutPanelMain, 0, 0);
            tableLayoutPanelWrapper.Dock = DockStyle.Fill;
            tableLayoutPanelWrapper.Location = new Point(0, 0);
            tableLayoutPanelWrapper.Name = "tableLayoutPanelWrapper";
            tableLayoutPanelWrapper.RowCount = 2;
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelWrapper.RowStyles.Add(new RowStyle());
            tableLayoutPanelWrapper.Size = new Size(800, 650);
            tableLayoutPanelWrapper.TabIndex = 0;
            // 
            // flowLayoutPanelFormControl
            // 
            flowLayoutPanelFormControl.AutoSize = true;
            flowLayoutPanelFormControl.Controls.Add(buttonCancel);
            flowLayoutPanelFormControl.Controls.Add(buttonCreateCheck);
            flowLayoutPanelFormControl.Controls.Add(buttonPrintHtml);
            flowLayoutPanelFormControl.Dock = DockStyle.Fill;
            flowLayoutPanelFormControl.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanelFormControl.Location = new Point(3, 618);
            flowLayoutPanelFormControl.Name = "flowLayoutPanelFormControl";
            flowLayoutPanelFormControl.Size = new Size(794, 29);
            flowLayoutPanelFormControl.TabIndex = 0;
            // 
            // tableLayoutPanelMain
            // 
            tableLayoutPanelMain.ColumnCount = 2;
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanelMain.Controls.Add(labelOrderNumberLabel, 0, 0);
            tableLayoutPanelMain.Controls.Add(labelClientNameLabel, 0, 1);
            tableLayoutPanelMain.Controls.Add(labelCarInfoLabel, 0, 2);
            tableLayoutPanelMain.Controls.Add(labelMasterNameLabel, 0, 3);
            tableLayoutPanelMain.Controls.Add(labelManagerNameLabel, 0, 4);
            tableLayoutPanelMain.Controls.Add(labelServiceDateTimeLabel, 0, 5);
            tableLayoutPanelMain.Controls.Add(labelOrderNumber, 1, 0);
            tableLayoutPanelMain.Controls.Add(labelClientName, 1, 1);
            tableLayoutPanelMain.Controls.Add(labelCarInfo, 1, 2);
            tableLayoutPanelMain.Controls.Add(labelMasterName, 1, 3);
            tableLayoutPanelMain.Controls.Add(labelManagerName, 1, 4);
            tableLayoutPanelMain.Controls.Add(labelServiceDateTime, 1, 5);
            tableLayoutPanelMain.Controls.Add(dataGridViewServices, 0, 6);
            tableLayoutPanelMain.Controls.Add(dataGridViewParts, 1, 6);
            tableLayoutPanelMain.Controls.Add(labelServicesTotalLabel, 0, 7);
            tableLayoutPanelMain.Controls.Add(labelPartsTotalLabel, 1, 7);
            tableLayoutPanelMain.Controls.Add(labelServicesTotal, 0, 8);
            tableLayoutPanelMain.Controls.Add(labelPartsTotal, 1, 8);
            tableLayoutPanelMain.Controls.Add(labelTotalAmountLabel, 0, 9);
            tableLayoutPanelMain.Controls.Add(labelTotalAmount, 1, 9);
            tableLayoutPanelMain.Dock = DockStyle.Fill;
            tableLayoutPanelMain.Location = new Point(3, 3);
            tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            tableLayoutPanelMain.RowCount = 10;
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.RowStyles.Add(new RowStyle());
            tableLayoutPanelMain.Size = new Size(794, 609);
            tableLayoutPanelMain.TabIndex = 1;
            // 
            // labelOrderNumberLabel
            // 
            labelOrderNumberLabel.AutoSize = true;
            labelOrderNumberLabel.Location = new Point(3, 0);
            labelOrderNumberLabel.Name = "labelOrderNumberLabel";
            labelOrderNumberLabel.Size = new Size(84, 15);
            labelOrderNumberLabel.TabIndex = 0;
            labelOrderNumberLabel.Text = "№ заявки:";
            // 
            // labelClientNameLabel
            // 
            labelClientNameLabel.AutoSize = true;
            labelClientNameLabel.Location = new Point(3, 25);
            labelClientNameLabel.Name = "labelClientNameLabel";
            labelClientNameLabel.Size = new Size(52, 15);
            labelClientNameLabel.TabIndex = 1;
            labelClientNameLabel.Text = "Клиент:";
            // 
            // labelCarInfoLabel
            // 
            labelCarInfoLabel.AutoSize = true;
            labelCarInfoLabel.Location = new Point(3, 50);
            labelCarInfoLabel.Name = "labelCarInfoLabel";
            labelCarInfoLabel.Size = new Size(76, 15);
            labelCarInfoLabel.TabIndex = 2;
            labelCarInfoLabel.Text = "Автомобиль:";
            // 
            // labelMasterNameLabel
            // 
            labelMasterNameLabel.AutoSize = true;
            labelMasterNameLabel.Location = new Point(3, 75);
            labelMasterNameLabel.Name = "labelMasterNameLabel";
            labelMasterNameLabel.Size = new Size(48, 15);
            labelMasterNameLabel.TabIndex = 3;
            labelMasterNameLabel.Text = "Мастер:";
            // 
            // labelManagerNameLabel
            // 
            labelManagerNameLabel.AutoSize = true;
            labelManagerNameLabel.Location = new Point(3, 100);
            labelManagerNameLabel.Name = "labelManagerNameLabel";
            labelManagerNameLabel.Size = new Size(63, 15);
            labelManagerNameLabel.TabIndex = 4;
            labelManagerNameLabel.Text = "Менеджер:";
            // 
            // labelServiceDateTimeLabel
            // 
            labelServiceDateTimeLabel.AutoSize = true;
            labelServiceDateTimeLabel.Location = new Point(3, 125);
            labelServiceDateTimeLabel.Name = "labelServiceDateTimeLabel";
            labelServiceDateTimeLabel.Size = new Size(113, 15);
            labelServiceDateTimeLabel.TabIndex = 5;
            labelServiceDateTimeLabel.Text = "Дата/время услуги:";
            // 
            // labelOrderNumber
            // 
            labelOrderNumber.AutoSize = true;
            labelOrderNumber.Location = new Point(400, 0);
            labelOrderNumber.Name = "labelOrderNumber";
            labelOrderNumber.Size = new Size(0, 15);
            labelOrderNumber.TabIndex = 6;
            // 
            // labelClientName
            // 
            labelClientName.AutoSize = true;
            labelClientName.Location = new Point(400, 25);
            labelClientName.Name = "labelClientName";
            labelClientName.Size = new Size(0, 15);
            labelClientName.TabIndex = 7;
            // 
            // labelCarInfo
            // 
            labelCarInfo.AutoSize = true;
            labelCarInfo.Location = new Point(400, 50);
            labelCarInfo.Name = "labelCarInfo";
            labelCarInfo.Size = new Size(0, 15);
            labelCarInfo.TabIndex = 8;
            // 
            // labelMasterName
            // 
            labelMasterName.AutoSize = true;
            labelMasterName.Location = new Point(400, 75);
            labelMasterName.Name = "labelMasterName";
            labelMasterName.Size = new Size(0, 15);
            labelMasterName.TabIndex = 9;
            // 
            // labelManagerName
            // 
            labelManagerName.AutoSize = true;
            labelManagerName.Location = new Point(400, 100);
            labelManagerName.Name = "labelManagerName";
            labelManagerName.Size = new Size(0, 15);
            labelManagerName.TabIndex = 10;
            // 
            // labelServiceDateTime
            // 
            labelServiceDateTime.AutoSize = true;
            labelServiceDateTime.Location = new Point(400, 125);
            labelServiceDateTime.Name = "labelServiceDateTime";
            labelServiceDateTime.Size = new Size(0, 15);
            labelServiceDateTime.TabIndex = 11;
            // 
            // dataGridViewServices
            // 
            dataGridViewServices.AllowUserToAddRows = false;
            dataGridViewServices.AllowUserToDeleteRows = false;
            dataGridViewServices.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewServices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewServices.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "ServiceName", HeaderText = "Услуга", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Кол-во", Width = 60 },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Цена", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Сумма", Width = 80 }
            });
            dataGridViewServices.Dock = DockStyle.Fill;
            dataGridViewServices.Location = new Point(3, 143);
            dataGridViewServices.MultiSelect = false;
            dataGridViewServices.Name = "dataGridViewServices";
            dataGridViewServices.ReadOnly = true;
            dataGridViewServices.RowHeadersVisible = false;
            dataGridViewServices.Size = new Size(391, 200);
            dataGridViewServices.TabIndex = 12;
            // 
            // dataGridViewParts
            // 
            dataGridViewParts.AllowUserToAddRows = false;
            dataGridViewParts.AllowUserToDeleteRows = false;
            dataGridViewParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewParts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewParts.Columns.AddRange(new DataGridViewColumn[] {
                new DataGridViewTextBoxColumn { Name = "PartName", HeaderText = "Запчасть", Width = 150 },
                new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "Кол-во", Width = 60 },
                new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Цена", Width = 80 },
                new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Сумма", Width = 80 }
            });
            dataGridViewParts.Dock = DockStyle.Fill;
            dataGridViewParts.Location = new Point(400, 143);
            dataGridViewParts.MultiSelect = false;
            dataGridViewParts.Name = "dataGridViewParts";
            dataGridViewParts.ReadOnly = true;
            dataGridViewParts.RowHeadersVisible = false;
            dataGridViewParts.Size = new Size(391, 200);
            dataGridViewParts.TabIndex = 13;
            // 
            // labelServicesTotalLabel
            // 
            labelServicesTotalLabel.AutoSize = true;
            labelServicesTotalLabel.Location = new Point(3, 346);
            labelServicesTotalLabel.Name = "labelServicesTotalLabel";
            labelServicesTotalLabel.Size = new Size(52, 15);
            labelServicesTotalLabel.TabIndex = 14;
            labelServicesTotalLabel.Text = "Услуги:";
            // 
            // labelPartsTotalLabel
            // 
            labelPartsTotalLabel.AutoSize = true;
            labelPartsTotalLabel.Location = new Point(400, 346);
            labelPartsTotalLabel.Name = "labelPartsTotalLabel";
            labelPartsTotalLabel.Size = new Size(66, 15);
            labelPartsTotalLabel.TabIndex = 15;
            labelPartsTotalLabel.Text = "Запчасти:";
            // 
            // labelServicesTotal
            // 
            labelServicesTotal.AutoSize = true;
            labelServicesTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelServicesTotal.Location = new Point(3, 371);
            labelServicesTotal.Name = "labelServicesTotal";
            labelServicesTotal.Size = new Size(0, 15);
            labelServicesTotal.TabIndex = 16;
            // 
            // labelPartsTotal
            // 
            labelPartsTotal.AutoSize = true;
            labelPartsTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelPartsTotal.Location = new Point(400, 371);
            labelPartsTotal.Name = "labelPartsTotal";
            labelPartsTotal.Size = new Size(0, 15);
            labelPartsTotal.TabIndex = 17;
            // 
            // labelTotalAmountLabel
            // 
            labelTotalAmountLabel.AutoSize = true;
            labelTotalAmountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalAmountLabel.Location = new Point(3, 396);
            labelTotalAmountLabel.Name = "labelTotalAmountLabel";
            labelTotalAmountLabel.Size = new Size(47, 15);
            labelTotalAmountLabel.TabIndex = 18;
            labelTotalAmountLabel.Text = "Итого:";
            // 
            // labelTotalAmount
            // 
            labelTotalAmount.AutoSize = true;
            labelTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelTotalAmount.Location = new Point(400, 396);
            labelTotalAmount.Name = "labelTotalAmount";
            labelTotalAmount.Size = new Size(0, 21);
            labelTotalAmount.TabIndex = 19;
            // 
            // FormCheck
            // 
            AcceptButton = buttonCreateCheck;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonCancel;
            ClientSize = new Size(800, 650);
            Controls.Add(tableLayoutPanelWrapper);
            MinimumSize = new Size(800, 650);
            Name = "FormCheck";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Создание чека";
            Load += FormCheck_Load;
            tableLayoutPanelWrapper.ResumeLayout(false);
            tableLayoutPanelWrapper.PerformLayout();
            flowLayoutPanelFormControl.ResumeLayout(false);
            tableLayoutPanelMain.ResumeLayout(false);
            tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewServices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewParts).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button buttonCreateCheck;
        private Button buttonCancel;
        private Button buttonPrintHtml;
        private TableLayoutPanel tableLayoutPanelWrapper;
        private FlowLayoutPanel flowLayoutPanelFormControl;
        private TableLayoutPanel tableLayoutPanelMain;
        private Label labelOrderNumberLabel;
        private Label labelClientNameLabel;
        private Label labelCarInfoLabel;
        private Label labelMasterNameLabel;
        private Label labelManagerNameLabel;
        private Label labelServiceDateTimeLabel;
        private Label labelOrderNumber;
        private Label labelClientName;
        private Label labelCarInfo;
        private Label labelMasterName;
        private Label labelManagerName;
        private Label labelServiceDateTime;
        private DataGridView dataGridViewServices;
        private DataGridView dataGridViewParts;
        private Label labelServicesTotalLabel;
        private Label labelPartsTotalLabel;
        private Label labelServicesTotal;
        private Label labelPartsTotal;
        private Label labelTotalAmountLabel;
        private Label labelTotalAmount;
    }
}
