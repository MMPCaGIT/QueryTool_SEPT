using COMPLETE_FLAT_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUERY_TOOL
{
    public partial class zaotrack : Form
    {
        public zaotrack()
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
            DateTime selectedDate1 = new DateTime();
            DateTime selectedDate2 = new DateTime();
            Boolean bth = false;
            String rValue = "";
            String txtValue = yr.Text+"%";

                PreviewDataList Vform = new PreviewDataList();
                rValue = "zaochk.txt";
                Vform.SubFormToShow(abrirFormEnPanel);
                Vform.DataQueriesProperties(QForm);
                Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                abrirFormEnPanel(Vform);
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
