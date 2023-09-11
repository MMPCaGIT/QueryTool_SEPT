using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Diagnostics;

namespace COMPLETE_FLAT_UI
{
    public partial class Login : Form
    {
        string appPath,MainPath;
        public Login()
        { 
            InitializeComponent();
            appPath = System.AppContext.BaseDirectory;
            //string substringToRemove = @"\Debug\";
            string substringToRemove = @"\Query Tool\";
            int lastIndex = appPath.LastIndexOf(substringToRemove);
            MainPath = appPath.Substring(0, lastIndex) + @"\";
            ShowVersion();
            versionCheck();
        }

        private void ShowVersion()
        {
            
            bool exists = System.IO.Directory.Exists(appPath);
            if (exists)
            {
                verLbl.Text = "Version - " + System.IO.File.ReadAllText(appPath + "\\version.txt");
            }
        }
        
        private void versionCheck()
        {

            String udVersion = System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\version.txt");
            if (!(System.IO.File.ReadAllText(@"\\172.23.64.122\AppShare\Query Tool\version.txt").Equals(udVersion)))
            {
                button3.Show();
            }
            else
            {
                button3.Hide();
            }
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(user.Text == "USERNAME")
            {
                user.Text = "";
                user.ForeColor = Color.White;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (user.Text == "")
            {
                user.Text = "USERNAME";
                user.ForeColor = Color.White;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (pass.Text == "PASSWORD")
            {
                pass.Text = "";
                pass.ForeColor = Color.White;
                pass.UseSystemPasswordChar = true;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (pass.Text == "")
            {
                pass.Text = "PASSWORD";
                pass.ForeColor = Color.White;
                pass.UseSystemPasswordChar = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the program ?", "Quit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
        private void button1_Click(object sender, EventArgs e)
        {     
            ValidUser();
        }
        private void ValidUser()
        {
        Boolean valid = false;
        FormMenuPrincipal menuForm = new FormMenuPrincipal();
        DataQueries QForm = new DataQueries();
        //String fileP = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)+ "\\log.txt";
        //if ((fileP.StartsWith("D:")))
        //{

            valid = QForm.Setrole(user.Text, pass.Text);
            if (valid == true)
            {
                String name = QForm.GetUserName();
                String dept = QForm.GetUserDept();
                String role = QForm.GetUserRole();
                menuForm.SetUserInfo(name, dept, role);
                menuForm.MenuAccess(QForm.GetmenuPermis());
                menuForm.SubFormToShow(QForm);
                menuForm.Show();
                this.Hide();
            }

        //}
        //else
        //{
        //    String lastLog = System.IO.File.ReadAllText(fileP);
        //    String logtxt = lastLog + "\n" + GetLocalIPAddress() + ";" + DateTime.Now.ToString() + ";" + user.Text;
        //    File.WriteAllText(fileP, logtxt);
        //    MessageBox.Show("Wrong file path");
        //}
        
            
        }

        private void user_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                pass.Focus();
            }
        }

        private void pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ValidUser();
            }
        }

        private void updateTxt_Click(object sender, EventArgs e)
        {
            try
            {
                //Process.Start(@"\\172.23.64.122\AppShare\Query Tool\QueryToolLoader.exe");
                Process.Start(appPath + "\\Query Tool Loader\\QueryToolLoader.exe - Shortcut");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Process.Start(@"r\\");
                Process.Start(MainPath + "\\Query Tool Loader\\QueryToolLoader.exe");
                // Process.Start(appPath + "\\loader\\QueryToolLoader.exe");
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                this.Close();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
        }
    }
}
