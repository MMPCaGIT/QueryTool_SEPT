using COMPLETE_FLAT_UI;
using System;
using System.Windows.Forms;

namespace QUERY_TOOL
{
    public partial class rpmtrack : Form
    {
        public rpmtrack()
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

        private void GetRadioOption()
        {
            DateTime selectedDate1 = dateTimePicker1.Value;
            DateTime selectedDate2 = dateTimePicker2.Value;
            Boolean bth = false;
            String rValue = "";
            String txtValue = "";
            if (sno.Checked == true)
            {

                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "sno.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }
            }
            else if (bb1.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "bb1chk.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }
            }
            else
            {
                MessageBox.Show("Please select the option to generate !!");
            }
        }

        private Boolean DateErroChkMonth()
        {

            if (dateTimePicker1 == null || dateTimePicker2 == null)
            {
                MessageBox.Show("Please input date range!");
                return true;
            }

            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;
            if (ts.Days == 0)
            {
                return false;
            }
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("'From' date must be less than 'To' date");
                return true;
            }
            if (TimeDifference() > 186)
            {
                MessageBox.Show("Query allow only 6 months range");
                return true;
            }
            return false;
        }

        private int TimeDifference()
        {
            DateTime? selectedDate1 = dateTimePicker1.Value;
            DateTime? selectedDate2 = dateTimePicker2.Value;
            DateTime FirstDate = selectedDate1.Value;
            DateTime SecondDate = selectedDate2.Value;
            TimeSpan ts = SecondDate - FirstDate;
            return ts.Days;
        }

        private void DataGen_Click(object sender, EventArgs e)
        {
            GetRadioOption();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
        }
    }
}
