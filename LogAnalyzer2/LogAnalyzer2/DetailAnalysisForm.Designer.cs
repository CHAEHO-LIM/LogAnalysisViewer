namespace LogAnalyzer2
{
    partial class DetailAnalysisForm
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
            this.textBoxCompany = new System.Windows.Forms.TextBox();
            this.dataGridView_DetailAnalysis = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetailAnalysis)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCompany
            // 
            this.textBoxCompany.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCompany.Location = new System.Drawing.Point(182, 33);
            this.textBoxCompany.Name = "textBoxCompany";
            this.textBoxCompany.Size = new System.Drawing.Size(637, 19);
            this.textBoxCompany.TabIndex = 1;
            this.textBoxCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataGridView_DetailAnalysis
            // 
            this.dataGridView_DetailAnalysis.AllowUserToDeleteRows = false;
            this.dataGridView_DetailAnalysis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_DetailAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_DetailAnalysis.Location = new System.Drawing.Point(29, 58);
            this.dataGridView_DetailAnalysis.Name = "dataGridView_DetailAnalysis";
            this.dataGridView_DetailAnalysis.ReadOnly = true;
            this.dataGridView_DetailAnalysis.RowTemplate.Height = 21;
            this.dataGridView_DetailAnalysis.Size = new System.Drawing.Size(1045, 509);
            this.dataGridView_DetailAnalysis.TabIndex = 2;
            // 
            // DetailAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 568);
            this.Controls.Add(this.dataGridView_DetailAnalysis);
            this.Controls.Add(this.textBoxCompany);
            this.Name = "DetailAnalysisForm";
            this.Text = "DetailAnalysisForm";
            this.Load += new System.EventHandler(this.DetailAnalysisForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_DetailAnalysis)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCompany;
        private System.Windows.Forms.DataGridView dataGridView_DetailAnalysis;
    }
}