using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.ComponentModel;

namespace COMPLETE_FLAT_UI
{
    public partial class Notifier : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;
        public Notifier()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            login = new NetworkCredential("sawdayechan.sdac@pouchen.com.mm", "Abc666xyz@");
            client = new SmtpClient("chmail.pouchen.com");
            client.Port = 465;
            client.EnableSsl = true;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress("sawdayechan.sdac@gmail.com")};
            msg.To.Add("mpc.erp@pouchen.com.mm");
            msg.Subject = "test";
            msg.Body = "test";
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.Send(msg);
            }
            catch(Exception error)
            {
                MessageBox.Show("Unexpected Error: " + error);
            }
        }


        public static void SendCompleteCallback(object sender , AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show(String.Format("{0}send canceled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.Error != null)
            {
                MessageBox.Show(String.Format("{0}{1} ", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("your message has been sucessfully sent.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
