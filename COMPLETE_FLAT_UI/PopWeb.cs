using CefSharp.WinForms;
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
    public partial class PopWeb : Form
    {
        public PopWeb()
        {
            InitializeComponent();
        }

        public void LoadePage(ChromiumWebBrowser browser)
        {
            BIRPT link = new BIRPT();
            this.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

        }
    }
}
