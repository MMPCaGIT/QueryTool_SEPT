
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
    public partial class UserPassChange : Form
    {
        public UserPassChange()
        {
            InitializeComponent();
            OldPass.UseSystemPasswordChar = true;
            NewPass.UseSystemPasswordChar = true;
            ConPass.UseSystemPasswordChar = true;
        }
        DataQueries QForm;
       
        internal void DataQueriesProperties(DataQueries QForm)
        {
            this.QForm = QForm;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PassChange();
        }
        private void PassChange()
        {
            if (CheckError() == false)
            {
            }
        }
        private Boolean CheckError()
        {
            if (OldPass.Text.Equals("") || NewPass.Text.Equals("") || ConPass.Text.Equals(""))
            {
                MessageBox.Show("Please Fill all require information !");
                return true;
            }
            else if (!OldPass.Text.Equals(QForm.GetUserPass()))
            {
                MessageBox.Show("incorrect old password !");
                return true;
            }
            else if (OldPass.Text.Equals(NewPass.Text))
            {
                MessageBox.Show("Old Password and New Password are the same !");
                return true;
            }
            else if (!NewPass.Text.Equals(ConPass.Text))
            {
                MessageBox.Show("New Password and Confirm Password are not the same !");
                return true;
            }
            else if (ConPass.Text.Length < 5)
            {
                MessageBox.Show("Password Character must be more than 4 !");
                return true;
            }
            
            else
            {
                return false;
            }
        } 


        private void UserPassChange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PassChange();
            }
        }

        private void OldPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NewPass.Focus();
            }
        }

        private void NewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConPass.Focus();
            }
        }
    }
}
