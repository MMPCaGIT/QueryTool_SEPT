using COMPLETE_FLAT_UI;
using System;
using System.Windows.Forms;

namespace QUERY_TOOL
{
    public partial class micWithAcc : Form
    {
        public micWithAcc()
        {
            InitializeComponent();
        }
        String impPath = "";
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
        private void DataGen_Click(object sender, EventArgs e)
        {
            GetRadioOption();
        }

        private void GetRadioOption()
        {

            DateTime selectedDate1 = dateTimePicker1.Value;
            DateTime selectedDate2 = dateTimePicker2.Value;
            Boolean bth = false;
            String rValue = "";
            if (shoe.Checked == true && (byDate.Checked == true || byId.Checked == true))
            {
                    if (DateErroChkMonth() == false)
                    {
                        //show dialog and close from it
                        PreviewDataList Vform = new PreviewDataList();
                        if (byDate.Checked == true && byId.Checked == false) { rValue = "micByAccD.txt"; }
                        else if (byId.Checked == true && byDate.Checked == false) { rValue = "micByAccID.txt"; }
                        else if (byDate.Checked == true && byId.Checked == true) { rValue = "micByAccDID.txt"; }
                        Vform.DataQueriesProperties(QForm);
                        Vform.SubFormToShow(abrirFormEnPanel);
                        Vform.QueryExport(rValue, selectedDate1, selectedDate2, textID.Text, bth);
                        abrirFormEnPanel(Vform);
                        //formShow.PreviewDataList(Qform);
                    }
            }
            else if (sole.Checked == true && (byDate.Checked == true || byId.Checked == true))
            {
                if (DateErroChkMonth() == false)
                {
                    //show dialog and close from it
                    PreviewDataList Vform = new PreviewDataList();
                    if (byDate.Checked == true && byId.Checked == false) { rValue = "micByAccSoleD.txt"; }
                    else if (byId.Checked == true && byDate.Checked == false) { rValue = "micByAccSoleID.txt"; }
                    else if (byDate.Checked == true && byId.Checked == true ) { rValue = "micByAccSoleDID.txt"; }
                    Vform.DataQueriesProperties(QForm);
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.QueryExportSole(rValue, selectedDate1, selectedDate2, textID.Text, bth);
                    abrirFormEnPanel(Vform);
                    //formShow.PreviewDataList(Qform);
                }
            }
            else if (BB1.Checked == true && (byDate.Checked == true || byId.Checked == true))
            {
                if (DateErroChkMonth() == false)
                {
                    //show dialog and close from it
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "micByAccBB1.txt";
                    Vform.DataQueriesProperties(QForm);
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, textID.Text, bth);
                    abrirFormEnPanel(Vform);
                    //formShow.PreviewDataList(Qform);
                }
            }
            else
            {
                bth = false;
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
            if (TimeDifference() > 93)
            {
                MessageBox.Show("Query allow only 1 month range");
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

        private void button2_Click(object sender, EventArgs e)
        {
            QForm.DataQueriesProperties(QForm);
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
        }

        private void micWithAcc_Load(object sender, EventArgs e)
        {
            byDate.Checked = false;
            byId.Checked = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            textID.Enabled = false;
        }

        private void byDate_Click(object sender, EventArgs e)
        {
            {
                if (byDate.Checked)
                {
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                }
                else
                {
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                }
            }
        }

        private void byId_Click(object sender, EventArgs e)
        {
                if (byId.Checked)
                {
                    textID.Enabled = true;

                }
                else
                {
                    textID.Enabled = false;
                }
        }

        private void BB1_Click(object sender, EventArgs e)
        {
            byId.Enabled = false;
            textID.Enabled = false;
        }

        private void sole_Click(object sender, EventArgs e)
        {
            textID.Enabled = true;
            byId.Enabled = true;
        }

        private void shoe_Click(object sender, EventArgs e)
        {
            textID.Enabled = true;
            byId.Enabled = true;
        }
    }
}
