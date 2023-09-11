using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class Prograssnoti : Form
    {
        public Prograssnoti()
        {
            InitializeComponent();

        }
        public void PrograssMax(int max)
        {
            progressBar1.Maximum = max;
        }
        public void PrograssFull(int max)
        {
            progressBar1.Value = max;
        }

        public void ShowPrg()
        {
            progressBar1.Value++;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void ShowLabelAna()
        {
            prograssLabel.Text = "Analysing...";
        }
        public void ShowLabeload()
        {
            prograssLabel.Text = "Loading...";
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
