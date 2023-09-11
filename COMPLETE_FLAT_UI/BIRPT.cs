using QUERY_TOOL;
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
    public partial class BIRPT : Form
    {
        public BIRPT()
        {
            InitializeComponent();
        }
        browzer browseLink = new browzer();
        Action<object> abrirFormEnPanel;
        DataQueries QForm = null;
        internal void SubFormToShow(Action<object> abrirFormEnPanel)
        {
            this.abrirFormEnPanel = abrirFormEnPanel;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadPage();
        }
        private void LoadPage()
        {
            if (LinkChk() != 0)
            {

                browseLink.SetLinkID(LinkChk());
                browseLink.LoadePage();
                browseLink.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(browseLink);
            }
            else if (IEData.Checked == true)
            {
                IE Vform = new IE();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else
            {
                MessageBox.Show("Please select the option to generate !!");
            }
        }
        public void BrowseNew()
        {
            ShowDialog(browseLink);
        }
        public int  LinkChk()
        {
            if(ticana.Checked == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private void IEData_Click(object sender, EventArgs e)
        {
            button1.Text = "Continue";
        }

        private void ticana_Click(object sender, EventArgs e)
        {
            button1.Text = "Generate";
        }
    }
}
