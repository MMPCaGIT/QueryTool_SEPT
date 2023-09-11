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
    public partial class MatSearch : Form
    {
        public MatSearch()
        {
            InitializeComponent();
        }
        //Boolean dataGen = false;
        PreviewDataList Vform = new PreviewDataList();
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
            PreviewDataList Vform = new PreviewDataList();
            Vform.DataQueriesProperties(QForm);
            Vform.SubFormToShow(abrirFormEnPanel);
            Vform.QueryExport(getQuery(), new DateTime(), new DateTime(), mattxt.Text,sttxt.Text,art.Text);
            abrirFormEnPanel(Vform);
        }
        String getQuery()
        {
            String querytxt = "";
            if (mlmid.Checked == true)
            {
                querytxt = "MatSearchmlmid.txt";
            }else
            {
                querytxt = "MatSearch.txt";
            }

            //if (mlmid.Checked == true && art.Text.Equals(""))
            //{
            //    querytxt = "matSerArtml.txt";
            //}
            //if(mlmid.Checked == false && (!art.Text.Equals("")))
            //{
            //    querytxt = "matSerArt.txt";
            //}
            return querytxt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QForm.DataQueriesProperties(QForm);
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
    }
    }
}
