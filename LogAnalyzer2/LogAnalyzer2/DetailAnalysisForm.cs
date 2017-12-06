using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogAnalyzer2
{
    public partial class DetailAnalysisForm : Form
    {
        public System.Windows.Forms.TextBox GetTextBox()
        {
            return this.textBoxCompany;
        }

        public System.Windows.Forms.DataGridView GetGridView()
        {
            return this.dataGridView_DetailAnalysis;
        }

        public DetailAnalysisForm()
        {
            InitializeComponent();
        }

        private void DetailAnalysisForm_Load(object sender, EventArgs e)
        {
//            DetailAnalysisForm.Form1Instance = this;

        }
    }
}
