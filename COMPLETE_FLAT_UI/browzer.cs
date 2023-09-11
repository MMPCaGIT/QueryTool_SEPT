using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;


namespace COMPLETE_FLAT_UI
{
    public partial class browzer : Form
    {
        public ChromiumWebBrowser browser;
        int linkID = 0;
        public browzer()
        {
            InitializeComponent();
        }
        public void SetLinkID(int ID)
        {
            linkID = ID;
        }
        Action<object> abrirFormEnPanel;
        internal void SubFormToShow(Action<object> abrirFormEnPanel)
        {
            this.abrirFormEnPanel = abrirFormEnPanel;
        }
        public void LoadePage()
        {
                browser = new ChromiumWebBrowser(GetLink(linkID));
                this.Controls.Add(browser);
                browser.Dock = DockStyle.Fill;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            BIRPT Bireport = new BIRPT();
            Bireport.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(Bireport);
        }
        public String GetLink(int id)
        {
            //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet dataworkSheet;
            //string rootDir = System.IO.Path.Combine(Environment.CurrentDirectory, @"data\");
            //string filePath = System.IO.Path.Combine(rootDir, "login.xlsx");
            //xlWorkBook = xlApp.Workbooks.Open(filePath.ToString(), 0, false, 5, "1@admin", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            //dataworkSheet = xlWorkBook.Sheets.get_Item(2);
            //String link = (String)dataworkSheet.Cells[id +1, 3].Value;
            //xlWorkBook.Close();
            //dataworkSheet = null;
            //xlApp = null;
            String link = "";
            return link;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            PopWeb newWeb = new PopWeb();
            ChromiumWebBrowser popBrowse = new ChromiumWebBrowser(GetLink(linkID));
            newWeb.LoadePage(popBrowse);
            newWeb.Show();
        }
    }
}
