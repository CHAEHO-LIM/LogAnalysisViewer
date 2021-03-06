﻿namespace LogAnalyzer2
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonLocalConnect = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.groupBoxLogType = new System.Windows.Forms.GroupBox();
            this.radioButtonFunctionLog = new System.Windows.Forms.RadioButton();
            this.radioButtonUseLog = new System.Windows.Forms.RadioButton();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.radioButtonByCompany = new System.Windows.Forms.RadioButton();
            this.radioButtonByVersion = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxDetail = new System.Windows.Forms.GroupBox();
            this.textBoxUserID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCompanyName = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.buttonSave = new System.Windows.Forms.Button();
            this.groupBoxExcelWrite = new System.Windows.Forms.GroupBox();
            this.dataGridViewResult = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.groupBox1.SuspendLayout();
            this.groupBoxLogType.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.groupBoxDetail.SuspendLayout();
            this.groupBoxExcelWrite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonLocalConnect);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxProduct);
            this.groupBox1.Controls.Add(this.comboBoxCountry);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(661, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // buttonLocalConnect
            // 
            this.buttonLocalConnect.Location = new System.Drawing.Point(558, 18);
            this.buttonLocalConnect.Name = "buttonLocalConnect";
            this.buttonLocalConnect.Size = new System.Drawing.Size(92, 23);
            this.buttonLocalConnect.TabIndex = 12;
            this.buttonLocalConnect.Text = "Existing Data";
            this.buttonLocalConnect.UseVisualStyleBackColor = true;
            this.buttonLocalConnect.Click += new System.EventHandler(this.buttonLocalConnect_Click);
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(447, 17);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(92, 23);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "DB Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Product :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Country :";
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Items.AddRange(new object[] {
            "CADRobo(Drawing)",
            "CADRobo(eGen)",
            "midas Drawing",
            "midas eGen",
            "midas iGen"});
            this.comboBoxProduct.Location = new System.Drawing.Point(65, 17);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(160, 20);
            this.comboBoxProduct.TabIndex = 1;
            this.comboBoxProduct.SelectedIndexChanged += new System.EventHandler(this.comboBoxProduct_SelectedIndexChanged);
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Items.AddRange(new object[] {
            "JP"});
            this.comboBoxCountry.Location = new System.Drawing.Point(301, 17);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(118, 20);
            this.comboBoxCountry.TabIndex = 0;
            this.comboBoxCountry.SelectedIndexChanged += new System.EventHandler(this.comboBoxCountry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(8, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "¦";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CustomFormat = "yyyy-mm-dd";
            this.dateTimePickerTo.Location = new System.Drawing.Point(6, 65);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(144, 19);
            this.dateTimePickerTo.TabIndex = 4;
            this.dateTimePickerTo.ValueChanged += new System.EventHandler(this.dateTimePickerTo_ValueChanged);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CustomFormat = "yyyy-mm-dd";
            this.dateTimePickerFrom.Location = new System.Drawing.Point(6, 24);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(144, 19);
            this.dateTimePickerFrom.TabIndex = 2;
            this.dateTimePickerFrom.ValueChanged += new System.EventHandler(this.dateTimePickerFrom_ValueChanged);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Enabled = false;
            this.buttonUpdate.Location = new System.Drawing.Point(698, 81);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(85, 37);
            this.buttonUpdate.TabIndex = 9;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // groupBoxLogType
            // 
            this.groupBoxLogType.Controls.Add(this.radioButtonFunctionLog);
            this.groupBoxLogType.Controls.Add(this.radioButtonUseLog);
            this.groupBoxLogType.Location = new System.Drawing.Point(12, 71);
            this.groupBoxLogType.Name = "groupBoxLogType";
            this.groupBoxLogType.Size = new System.Drawing.Size(225, 47);
            this.groupBoxLogType.TabIndex = 2;
            this.groupBoxLogType.TabStop = false;
            this.groupBoxLogType.Text = "LogType";
            // 
            // radioButtonFunctionLog
            // 
            this.radioButtonFunctionLog.AutoSize = true;
            this.radioButtonFunctionLog.Location = new System.Drawing.Point(114, 19);
            this.radioButtonFunctionLog.Name = "radioButtonFunctionLog";
            this.radioButtonFunctionLog.Size = new System.Drawing.Size(89, 16);
            this.radioButtonFunctionLog.TabIndex = 1;
            this.radioButtonFunctionLog.TabStop = true;
            this.radioButtonFunctionLog.Text = "Function Log";
            this.radioButtonFunctionLog.UseVisualStyleBackColor = true;
            // 
            // radioButtonUseLog
            // 
            this.radioButtonUseLog.AutoSize = true;
            this.radioButtonUseLog.Checked = true;
            this.radioButtonUseLog.Location = new System.Drawing.Point(19, 20);
            this.radioButtonUseLog.Name = "radioButtonUseLog";
            this.radioButtonUseLog.Size = new System.Drawing.Size(65, 16);
            this.radioButtonUseLog.TabIndex = 0;
            this.radioButtonUseLog.TabStop = true;
            this.radioButtonUseLog.Text = "Use Log";
            this.radioButtonUseLog.UseVisualStyleBackColor = true;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.radioButtonByCompany);
            this.groupBoxResult.Controls.Add(this.radioButtonByVersion);
            this.groupBoxResult.Location = new System.Drawing.Point(252, 71);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(247, 47);
            this.groupBoxResult.TabIndex = 3;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "ResutType";
            // 
            // radioButtonByCompany
            // 
            this.radioButtonByCompany.AutoSize = true;
            this.radioButtonByCompany.Location = new System.Drawing.Point(128, 19);
            this.radioButtonByCompany.Name = "radioButtonByCompany";
            this.radioButtonByCompany.Size = new System.Drawing.Size(88, 16);
            this.radioButtonByCompany.TabIndex = 1;
            this.radioButtonByCompany.TabStop = true;
            this.radioButtonByCompany.Text = "By Company";
            this.radioButtonByCompany.UseVisualStyleBackColor = true;
            // 
            // radioButtonByVersion
            // 
            this.radioButtonByVersion.AutoSize = true;
            this.radioButtonByVersion.Checked = true;
            this.radioButtonByVersion.Location = new System.Drawing.Point(22, 20);
            this.radioButtonByVersion.Name = "radioButtonByVersion";
            this.radioButtonByVersion.Size = new System.Drawing.Size(80, 16);
            this.radioButtonByVersion.TabIndex = 0;
            this.radioButtonByVersion.TabStop = true;
            this.radioButtonByVersion.Text = "By Version";
            this.radioButtonByVersion.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Company Name :";
            // 
            // groupBoxDetail
            // 
            this.groupBoxDetail.Controls.Add(this.textBoxUserID);
            this.groupBoxDetail.Controls.Add(this.label6);
            this.groupBoxDetail.Controls.Add(this.textBoxCompanyName);
            this.groupBoxDetail.Controls.Add(this.label5);
            this.groupBoxDetail.Location = new System.Drawing.Point(12, 124);
            this.groupBoxDetail.Name = "groupBoxDetail";
            this.groupBoxDetail.Size = new System.Drawing.Size(487, 46);
            this.groupBoxDetail.TabIndex = 11;
            this.groupBoxDetail.TabStop = false;
            this.groupBoxDetail.Text = "Detail";
            // 
            // textBoxUserID
            // 
            this.textBoxUserID.Location = new System.Drawing.Point(346, 18);
            this.textBoxUserID.Name = "textBoxUserID";
            this.textBoxUserID.Size = new System.Drawing.Size(135, 19);
            this.textBoxUserID.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "User ID :";
            // 
            // textBoxCompanyName
            // 
            this.textBoxCompanyName.Location = new System.Drawing.Point(103, 18);
            this.textBoxCompanyName.Name = "textBoxCompanyName";
            this.textBoxCompanyName.Size = new System.Drawing.Size(162, 19);
            this.textBoxCompanyName.TabIndex = 11;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 550);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1037, 10);
            this.progressBar1.TabIndex = 12;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(19, 18);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(85, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // groupBoxExcelWrite
            // 
            this.groupBoxExcelWrite.Controls.Add(this.buttonSave);
            this.groupBoxExcelWrite.Location = new System.Drawing.Point(679, 124);
            this.groupBoxExcelWrite.Name = "groupBoxExcelWrite";
            this.groupBoxExcelWrite.Size = new System.Drawing.Size(118, 45);
            this.groupBoxExcelWrite.TabIndex = 14;
            this.groupBoxExcelWrite.TabStop = false;
            this.groupBoxExcelWrite.Text = "Excel Output";
            // 
            // dataGridViewResult
            // 
            this.dataGridViewResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResult.Location = new System.Drawing.Point(12, 177);
            this.dataGridViewResult.Name = "dataGridViewResult";
            this.dataGridViewResult.RowTemplate.Height = 21;
            this.dataGridViewResult.Size = new System.Drawing.Size(1048, 367);
            this.dataGridViewResult.TabIndex = 15;
            this.dataGridViewResult.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewResult_CellMouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.dateTimePickerTo);
            this.groupBox2.Controls.Add(this.dateTimePickerFrom);
            this.groupBox2.Location = new System.Drawing.Point(512, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(161, 95);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Date";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Menu;
            this.listView1.Location = new System.Drawing.Point(805, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(244, 161);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1061, 562);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridViewResult);
            this.Controls.Add(this.groupBoxExcelWrite);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBoxDetail);
            this.Controls.Add(this.groupBoxResult);
            this.Controls.Add(this.groupBoxLogType);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogAnalyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxLogType.ResumeLayout(false);
            this.groupBoxLogType.PerformLayout();
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.groupBoxDetail.ResumeLayout(false);
            this.groupBoxDetail.PerformLayout();
            this.groupBoxExcelWrite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResult)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.GroupBox groupBoxLogType;
        private System.Windows.Forms.RadioButton radioButtonUseLog;
        private System.Windows.Forms.RadioButton radioButtonFunctionLog;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.RadioButton radioButtonByVersion;
        private System.Windows.Forms.RadioButton radioButtonByCompany;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxDetail;
        private System.Windows.Forms.TextBox textBoxCompanyName;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxUserID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.GroupBox groupBoxExcelWrite;
        private System.Windows.Forms.DataGridView dataGridViewResult;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonLocalConnect;
        private System.Windows.Forms.ListView listView1;
    }
}

