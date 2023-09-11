using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();

        }
        private void LoadFile()
        {
            string sourceDir = System.IO.Path.Combine(Environment.CurrentDirectory);
            string backupDir = @"D:\QueryTool\";
            string[] filelist = Directory.GetFiles(sourceDir, "*.*");
            bool exists = System.IO.Directory.Exists(backupDir);
            if (!exists)
                System.IO.Directory.CreateDirectory(backupDir);
            //porgress bar
            progressBar1.Maximum = filelist.Length;
            try
            {


                // Copy picture files.
                foreach (string f in filelist)
                {
                    // Remove path from the file name.
                    string fName = f.Substring(sourceDir.Length + 1);
                    progressBar1.Value += 1;
                    // Use the Path.Combine method to safely append the file name to the path.
                    // Will overwrite if the destination file already exists.
                    File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);

                }
            }

            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFile();
            Process.Start("D:\\QueryTool\\Query Tool.exe");
        }

    }
}
