using COMPLETE_FLAT_UI;
using System;
using System.Windows.Forms;

namespace QUERY_TOOL
{
    public partial class purf13 : Form
    {
        public purf13()
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

        private void DataGen_Click(object sender, EventArgs e)
        {
            PreviewDataList Vform = new PreviewDataList();
            Vform.DataQueriesProperties(QForm);
            Vform.SubFormToShow(abrirFormEnPanel);
            Vform.QueryExport("purf1-3.txt", new DateTime(), new DateTime(), matTxt.Text, false);
            abrirFormEnPanel(Vform);

        }
    }
}
