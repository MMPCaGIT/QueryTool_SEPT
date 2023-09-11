using QUERY_TOOL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class FormMenuPrincipal : Form
    {
        public String[] menuPermis = new string[10];
        //Constructor
        public FormMenuPrincipal()
        {
            InitializeComponent();
            //Estas lineas eliminan los parpadeos del formulario o controles en la interfaz grafica (Pero no en un 100%)
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
        }
        DataQueries DataQueries;
        internal void SubFormToShow(DataQueries DataQueries)
        {
            this.DataQueries = DataQueries;
        }
        //METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO  TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 15;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedorPrincipal.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {

            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(55, 61, 69));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent, sizeGripRectangle);
        }
       
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //METODOS PARA CERRAR,MAXIMIZAR, MINIMIZAR FORMULARIO------------------------------------------------------
        int lx, ly;
        int sw, sh;
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            btnMaximizar.Visible = false;
            btnNormal.Visible = true;

        }

        private void btnNormal_Click(object sender, EventArgs e)
        {
            this.Size = new Size(sw, sh);
            this.Location = new Point(lx, ly);
            btnNormal.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the program", "Quit?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        // METHODS FOR SLIDING MENU ANIMATION--
        private void btnMenu_Click(object sender, EventArgs e)
        {

            //-------CON EFECTO SLIDING
            //if (panelMenu.Width == 230)
            //{
            //    this.tmContraerMenu.Start();
            //}
            //else if (panelMenu.Width == 55)
            //{
            //    this.tmExpandirMenu.Start();


            //-------WITHOUT EFFECT
            if (panelMenu.Width == 70)
            {
                panelMenu.Width = 230;
            }
            else
            {
                panelMenu.Width = 70;
            }
        }

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width >= 230)
                this.tmExpandirMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width + 5;
            
        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {
            if (panelMenu.Width <= 55)
                this.tmContraerMenu.Stop();
            else
                panelMenu.Width = panelMenu.Width - 5;
        }

        //METHOD FOR OPENING FORM INSIDE PANEL-----------------------------------------------------
        public void AbrirFormEnPanel(object formHijo)
        {
            if (panelContenedorForm.Controls.Count > 0)
                panelContenedorForm.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;            
            panelContenedorForm.Controls.Add(fh);
            panelContenedorForm.Tag = fh;
            fh.Show();
        }
        public void PreviewDataList(PreviewDataList previewForm)
        {
            AbrirFormEnPanel(previewForm);
        }
        //METHOD TO DISPLAY LOGO FORM AT START ----------------------------------------------------------
        private void MostrarFormLogo()
        {
            AbrirFormEnPanel(new FormLogo());
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            MostrarFormLogo();
        }
        //METODO PARA MOSTRAR FORMULARIO DE LOGO Al CERRAR OTROS FORM ----------------------------------------------------------
        private void MostrarFormLogoAlCerrarForms(object sender, FormClosedEventArgs e)
        {
            MostrarFormLogo();
        }
        //METODOS PARA ABRIR OTROS FORMULARIOS Y MOSTRAR FORM DE LOGO Al CERRAR ----------------------------------------------------------
        private void btnListaClientes_Click(object sender, EventArgs e)
        {
            PreviewDataList fm = new PreviewDataList();
            fm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(fm);
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            UserPassChange frm = new UserPassChange();
            frm.FormClosed += new FormClosedEventHandler(MostrarFormLogoAlCerrarForms);
            AbrirFormEnPanel(frm);
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Log out from the program", "Logout?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Login lgin = new Login();
                this.Close();
                lgin.Show();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        private void PanelBarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (qryDptPnl.Visible == false) {
            qryDptPnl.Visible = true;
            }
            else
            {
                qryDptPnl.Visible = false;
            }
        }
        private void Query_EMC_Click(object sender, EventArgs e)
        {
            if (qryDptPnl.Visible == false)
            {
                qryDptPnl.Visible = true;
            }
            else
            {
                qryDptPnl.Visible = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        //METODO PARA HORA Y FECHA ACTUAL ----------------------------------------------------------
        //private void tmFechaHora_Tick(object sender, EventArgs e)
        //{
        //    lbFecha.Text = DateTime.Now.ToLongDateString();
        //    lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        //}
        

        private void button5_Click(object sender, EventArgs e)
        {

            if (panel4.Visible == false)
            {
                panel4.Visible = true;
            }
            else
            {
                panel4.Visible = false;
            }
           
        }

        private void notifier_Click(object sender, EventArgs e)
        {
            Notifier notifier = new Notifier();
            AbrirFormEnPanel(notifier);
        }

        private void button2_Click(object sender, EventArgs e)
        {

                LuckDraw dataq = new LuckDraw();
                AbrirFormEnPanel(dataq);

        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(55, 61, 69);
            button6.BackColor = Color.FromArgb(55, 61, 69);
            button7.BackColor = Color.FromArgb(55, 61, 69);
            button11.BackColor = Color.FromArgb(55, 61, 69);
            button12.BackColor = Color.FromArgb(55, 61, 69);
            DataQueries dataqueryForm = DataQueries;
            dataqueryForm.DataQueriesProperties(dataqueryForm,"Customs");
            dataqueryForm.SubFormToShow(AbrirFormEnPanel);
            AbrirFormEnPanel(dataqueryForm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.Gray;
            button2.BackColor = Color.FromArgb(55, 61, 69);
            button6.BackColor = Color.FromArgb(55, 61, 69);
            button7.BackColor = Color.FromArgb(55, 61, 69);
            button11.BackColor = Color.FromArgb(55, 61, 69);
            button12.BackColor = Color.FromArgb(55, 61, 69);
            DataQueries dataqueryForm = DataQueries;
            dataqueryForm.DataQueriesProperties(dataqueryForm, "Costing");
            dataqueryForm.SubFormToShow(AbrirFormEnPanel);
            AbrirFormEnPanel(dataqueryForm);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            button6.BackColor = Color.Gray;
            button2.BackColor = Color.FromArgb(55, 61, 69);
            button4.BackColor = Color.FromArgb(55, 61, 69);
            button7.BackColor = Color.FromArgb(55, 61, 69);
            button11.BackColor = Color.FromArgb(55, 61, 69);
            button12.BackColor = Color.FromArgb(55, 61, 69);
            button12.BackColor = Color.FromArgb(55, 61, 69);
            DataQueries dataqueryForm = DataQueries;
            dataqueryForm.DataQueriesProperties(dataqueryForm, "Others");
            dataqueryForm.SubFormToShow(AbrirFormEnPanel);
            AbrirFormEnPanel(dataqueryForm);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button7.BackColor = Color.Gray;
            button2.BackColor = Color.FromArgb(55, 61, 69);
            button4.BackColor = Color.FromArgb(55, 61, 69);
            button6.BackColor = Color.FromArgb(55, 61, 69);
            button11.BackColor = Color.FromArgb(55, 61, 69);
            button12.BackColor = Color.FromArgb(55, 61, 69);
            DataQueries dataqueryForm = DataQueries;
            dataqueryForm.DataQueriesProperties(dataqueryForm, "Purchasing");
            dataqueryForm.SubFormToShow(AbrirFormEnPanel);
            AbrirFormEnPanel(dataqueryForm);
        }
        private void HideMenu()
        {
            button1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button6.Hide();
            button7.Hide();
            button11.Hide();
            button12.Hide();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BIRPT BIRPTForm = new BIRPT();
            BIRPTForm.SubFormToShow(AbrirFormEnPanel);
            AbrirFormEnPanel(BIRPTForm);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PermissionSetting perSetting = new PermissionSetting();
            AbrirFormEnPanel(perSetting);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UserPassChange PassChangeForm = new UserPassChange();
            PassChangeForm.DataQueriesProperties(DataQueries);
            AbrirFormEnPanel(PassChangeForm);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UserRegister registerForm = new UserRegister();
            AbrirFormEnPanel(registerForm);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(55, 61, 69);
            button2.BackColor = Color.FromArgb(55, 61, 69);
            button4.BackColor = Color.FromArgb(55, 61, 69);
            button7.BackColor = Color.FromArgb(55, 61, 69);
            button12.BackColor = Color.FromArgb(55, 61, 69);
            button11.BackColor = Color.Gray;
            DataQueries dataqueryForm = DataQueries;
            dataqueryForm.DataQueriesProperties(dataqueryForm, "QIP");
            dataqueryForm.SubFormToShow(AbrirFormEnPanel);
            AbrirFormEnPanel(dataqueryForm);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(55, 61, 69);
            button2.BackColor = Color.FromArgb(55, 61, 69);
            button4.BackColor = Color.FromArgb(55, 61, 69);
            button7.BackColor = Color.FromArgb(55, 61, 69);
            button11.BackColor = Color.FromArgb(55, 61, 69);
            button12.BackColor = Color.Gray;
            DataQueries dataqueryForm = DataQueries;
            dataqueryForm.DataQueriesProperties(dataqueryForm, "Warehouse");
            dataqueryForm.SubFormToShow(AbrirFormEnPanel);
            AbrirFormEnPanel(dataqueryForm);
        }

        public void MenuAccess(String[] menuPermis)
        {
            HideMenu();
            for (int i = 0; i < menuPermis.Length; i++)
            {
                switch (menuPermis[i])
                {
                    case "A":
                        button3.Show();
                        break;
                    case "B":
                        button1.Show();
                        break;
                    case "C":
                        button5.Show();
                        break;
                    case "a":
                        button4.Show();
                        break;
                    case "b":
                        button2.Show();
                        break;
                    case "c":
                        button7.Show();
                        break;
                    case "d":
                        button6.Show();
                        break;
                    case "e":
                        button11.Show();
                        break;
                    case "f":
                        button12.Show();
                        break;
                }
            }

            }
        public void SetUserInfo(String name, String dept, String role)
        {
            nameLable.Text = name;
            deptLable.Text = dept;
            roleLable.Text = role;
        }

    }
}
