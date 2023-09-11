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
    public partial class LikChk : Form
    {
        public LikChk()
        {
            InitializeComponent();
        }
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
        private String Opts()
        {

            String UpdString = "";
            if (Limi.Checked)
            {
                UpdString = "Laminate.txt";
            }
            else if (dishG.Checked)
            {
                UpdString = "Disg.txt";

            }
            else
            {
                UpdString = "Indisg.txt";
            }
            return UpdString;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);

        }

        private void DataGen_Click(object sender, EventArgs e)
        {
            //PlsLable.Text = "";
            if (Limi.Checked == false && dishG.Checked == false && IndishG.Checked == false)

            {
               // PlsLable.Text = "T";
                MessageBox.Show("Please select query option !");
            }
            else
            {
                String UpdString = Opts();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                Vform.ChkMat(ChkMat.Text + "%", UpdString);
                abrirFormEnPanel(Vform);
            }
            
        }
    }
}

