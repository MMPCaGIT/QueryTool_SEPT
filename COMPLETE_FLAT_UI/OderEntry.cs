using System;
using System.Windows.Forms;
namespace COMPLETE_FLAT_UI
{
    public partial class OderEntry : Form
    {
        public OderEntry()
        {
            InitializeComponent();
        }
        PreviewDataList Vform = new PreviewDataList();
        DataQueries QForm;
        Action<object> abrirFormEnPanel;
        String qType;
        internal void SubFormToShow(Action<object> abrirFormEnPanel)
        {
            this.abrirFormEnPanel = abrirFormEnPanel;
        }
         internal void DataQueriesProperties(DataQueries QForm)
        {
            this.QForm = QForm;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void setQueryType(String qType)
        {
            this.qType = qType;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate1 = dateTimePicker1.Value;
            DateTime selectedDate2 = dateTimePicker2.Value;
            Boolean errorFlag = ErrorChk();
            if (errorFlag == true)
            {
                MessageBox.Show("Please check your input data!");
            }
            else { Vform.OrderEntryQuery(OdrEntry.Text, qType, selectedDate1, selectedDate2);
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
                }
        }

        private Boolean ErrorChk()
        {
            Boolean erroFlag = false;
            if (!OdrEntry.Text.StartsWith("'") || !OdrEntry.Text.EndsWith("'") || OdrEntry.Text.Equals("") || OdrEntry.Text.Length <=2)
            {
                erroFlag = true;
            }
            return erroFlag;
        }
       
        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            QForm.DataQueriesProperties(QForm);
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
        }
    }
}
