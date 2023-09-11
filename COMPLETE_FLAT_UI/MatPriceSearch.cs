using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMPLETE_FLAT_UI;

namespace QUERY_TOOL
{
    public partial class MatPriceSearch : Form
    {
        public MatPriceSearch()
        {
            InitializeComponent();
        }
        PreviewDataList vform = new PreviewDataList();
        DataQueries QForm;
        Action<object> abrirFormEnPanel;

        internal void SubFormToShow(Action<object> abrirFormEnPanel)
        {
            this.abrirFormEnPanel = abrirFormEnPanel;
        }
        internal void DataQueriesProperties(DataQueries QForm)
        {
            this.QForm = QForm;
        }

        private void MatPriceSearch_Load(object sender, EventArgs e)
        {
            opt_date.Checked = true;
            lbl_matname.Enabled = false;
            txt_mat.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QForm.DataQueriesProperties(QForm);
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
        }

        private void DataGen_Click(object sender, EventArgs e)
        {
            string txtValue = "";
            Boolean bth = false;

            if (opt_date.Checked == true)
            {
                if (!DateErroChkMonth())
                {
                    PreviewDataList Vform = new PreviewDataList();
                    Vform.DataQueriesProperties(QForm);
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.QueryExport("MatPriceSearch_ByDate.txt", dt_from.Value, dt_to.Value, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }
            }

            if(opt_bymaterial.Checked == true)
            {
                if(txt_mat.Text =="")
                {
                    MessageBox.Show("Please enter material code to search", "Unit Price", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PreviewDataList Vform = new PreviewDataList();
                    Vform.DataQueriesProperties(QForm);
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.QueryExport("MatPriceSearch_byMat.txt", new DateTime(), new DateTime(),txt_mat.Text, bth);
                    abrirFormEnPanel(Vform);
                }
            }

        }
   
        private void opt_bymaterial_Click(object sender, EventArgs e)
        {
            lbl_matname.Enabled = true;
            txt_mat.Enabled = true;
            dt_from.Enabled = false;
            dt_to.Enabled = false;
        }

        private void opt_date_Click(object sender, EventArgs e)
        {
            lbl_matname.Enabled = false;
            txt_mat.Enabled = false;
            dt_from.Enabled = true;
            dt_to.Enabled = true;
        }

        private Boolean DateErroChkMonth()
        {

            if (dt_from == null || dt_from == null)
            {
                MessageBox.Show("Please input date range!");
                return true;
            }

            TimeSpan ts = dt_to.Value - dt_from.Value;
            if (ts.Days == 0)
            {
                return false;
            }
            if (dt_to.Value < dt_from.Value)
            {
                MessageBox.Show("'From' date must be less than 'To' date");
                return true;
            }
            if (TimeDifference() > 365)
            {
                MessageBox.Show("Query allow only a year range");
                return true;
            }
            return false;
        }
        private Boolean DateErroChk()
        {

            if (dt_from == null || dt_to == null)
            {
                MessageBox.Show("Please input date range!");
                return true;
            }

            TimeSpan ts = dt_to.Value - dt_from.Value;
            if (ts.Days == 0)
            {
                return false;
            }
            if (dt_to.Value < dt_from.Value)
            {
                MessageBox.Show("'From' date must be less than 'To' date");
                return true;
            }
            return false;
        }
        private int TimeDifference()
        {
            DateTime? selectedDate1 = dt_from.Value;
            DateTime? selectedDate2 = dt_to.Value;
            DateTime FirstDate = selectedDate1.Value;
            DateTime SecondDate = selectedDate2.Value;
            TimeSpan ts = SecondDate - FirstDate;
            return ts.Days;
        }
    }
}
