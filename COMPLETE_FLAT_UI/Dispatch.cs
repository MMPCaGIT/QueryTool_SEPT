using ClosedXML.Excel;
using COMPLETE_FLAT_UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUERY_TOOL
{
    public partial class Dispatch : Form
    {
        public Dispatch()
        {
            InitializeComponent();
        }
        String impPath = "";

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
        private void Odr_Import_Click(object sender, EventArgs e)
        {
            {
                browseXLSX.FileName = "";
                browseXLSX.InitialDirectory = @"D:\";
                browseXLSX.Title = "Browse xlsx Files";
                browseXLSX.CheckFileExists = true;
                browseXLSX.CheckPathExists = true;
                browseXLSX.DefaultExt = "";
                browseXLSX.Filter = "xlsx files (*.xlsx)|*.xlsx";
                browseXLSX.FilterIndex = 2;
                browseXLSX.RestoreDirectory = true;
                browseXLSX.ShowDialog();
                browseFile.Text = browseXLSX.FileName;
                //if (!(browseXLSX.FileName.Equals(".xlsx") || browseXLSX.FileName.Equals("")))
                //{
                //    if (UploadItemChk(browseXLSX.FileName) == false)
                //    {
                //        browseXLSX.FileName = "";
                //        impPath = browseXLSX.FileName;

                //    }
                //    else
                //    {
                impPath = browseXLSX.FileName;
                //}
                //}
                browseFile.Text = browseXLSX.FileName;


            }
        }

        private void Query_EMC_Click(object sender, EventArgs e)
        {
            string remote = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\file";

            foreach (string newPath in Directory.GetFiles(remote, "*.*", SearchOption.AllDirectories))
            {
                File.Delete(newPath);
            }
            PlsWait waitme = new PlsWait();
            waitme.Show();
            progressBar1.Value = 0;
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit3 = System.IO.Path.Combine(rootDir, "DISPA_COL_DATA.xlsx");
            var comBook = new XLWorkbook(pathDesit3);
            var conSheet = comBook.Worksheet(1);
            comBook.SaveAs(rootDir + "TEMP_DISP.xlsx");

            List<int> rowBatchStart = new List<int>();
            List<int> rowBatchEnd = new List<int>();
            if (impPath.Equals(""))
            {
                MessageBox.Show("Please select file.");
            }
            else
            {
                String noValue = "";
                String tempvalue = "";
                String rValue = "";
                var browbook = new XLWorkbook(impPath);
                var browSheet = browbook.Worksheet(1);


                if (impPath.Equals("") || impPath.Equals(".xlsx"))
                {
                    MessageBox.Show("Please Import data first !");
                }

                else
                {
                    noValue = (String)browSheet.Cell(2, 1).Value;
                    if (!(noValue.Equals("")))
                    {

                        int genlastRow = browSheet.RowsUsed().Count() - 1;
                        if (genlastRow > 999)
                        {
                            int batchs = (genlastRow / 999) + 1;
                            for (int i = 0; i < batchs; i++)
                            {

                                if (rowBatchStart.Count == 0)
                                {
                                    rowBatchStart.Add((i * 1000) + 1);
                                }
                                else
                                {
                                    rowBatchStart.Add(i * 1000);
                                }
                                if (rowBatchEnd.Count == 0)
                                {
                                    rowBatchEnd.Add((i + 1 * 1000 - 1));
                                }
                                else
                                {
                                    rowBatchEnd.Add((((i + 2) - 1) * 1000 - 1));
                                }


                            }
                            progressBar1.Maximum = batchs;
                            //MessageBox.Show(genlastRow + " ");
                            for (int i = 0; i < batchs; i++)
                            {
                                progressBar1.Value++;
                                for (int index = rowBatchStart[i]; index < rowBatchEnd[i] + 1; index++)
                                {
                                    if (index == genlastRow + 2)
                                    {
                                        tempvalue = tempvalue.Remove(tempvalue.Length - 1, 1);
                                        break;
                                    }
                                    if (index != (rowBatchEnd[i]))
                                    {
                                        var a = browSheet.Cell(index, 1).Value;

                                        tempvalue += "'" + browSheet.Cell(index, 1).Value + "'" + ",";

                                    }
                                    else
                                    {
                                        tempvalue += "'" + browSheet.Cell(index, 1).Value + "'";
                                    }
                                }
                                PreviewDataList Vform = new PreviewDataList();
                                rValue = "Dispatching.txt";
                                Vform.SubFormToShow(abrirFormEnPanel);
                                Vform.DataQueriesProperties(QForm);
                                Vform.QueryExportOderConsum(rValue, tempvalue);
                                sheetcombine(rowBatchStart[i], rowBatchEnd[i]);
                                tempvalue = "";

                            }
                        }
                        else
                        {
                            //MessageBox.Show(genlastRow + " ");
                            for (int i = 0; i < genlastRow; i++)
                            {
                                progressBar1.Maximum = genlastRow;
                                if (browSheet.Cell(i + 2, 1).Value != null)
                                {
                                    if (i != (genlastRow - 1))
                                    {
                                        tempvalue += "'" + browSheet.Cell(i + 2, 1).Value + "'" + ",";
                                    }
                                    else
                                    {
                                        tempvalue += "'" + browSheet.Cell(i + 2, 1).Value + "'";

                                    }
                                }
                                else
                                {
                                    break;
                                }
                                progressBar1.Value++;
                            }
                            //MessageBox.Show(tempvalue);
                            PreviewDataList Vform = new PreviewDataList();
                            rValue = "Dispatching.txt";
                            Vform.SubFormToShow(abrirFormEnPanel);
                            Vform.DataQueriesProperties(QForm);
                            Vform.QueryExportOderConsum(rValue, tempvalue);
                            sheetcombine(1, 999);

                            browSheet = null;

                        }

                    }
                }
            }
            waitme.Close();
            MessageBox.Show("Query Finished !");
        }
        private void sheetcombine(int start,int end)
        {
            try
            {
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";

                string pathDesit2 = System.IO.Path.Combine(rootDir, "destination.xlsx");
                var genBook = new XLWorkbook(pathDesit2);
                genBook.SaveAs(rootDir + @"\file\"+"B8"+start + "-" + end + ".xlsx");
                genBook.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlsWait waitme = new PlsWait();
            waitme.Show();
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesi1 = System.IO.Path.Combine(rootDir, "TEMP_DISP.xlsx");
            var tempBook = new XLWorkbook(pathDesi1);
            var destworkSheet = tempBook.Worksheet(1);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            var blankData = (String)destworkSheet.Cell(2, 1).Value;
            if (blankData == null)
            {
                MessageBox.Show("NO data to save !! \nPlease generate data first!");
            }
            else
            {
                saveFileDialog.InitialDirectory = "C:";
                saveFileDialog.Title = "Export";
                saveFileDialog.FileName = "";
                saveFileDialog.Filter = "File Name|*.|All File|*.*";
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    try
                    {
                        string remote = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\file";
                        string local = saveFileDialog.FileName;
                        string sourceDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\file";
                        string backupDir = saveFileDialog.FileName;
                        string[] filelist = Directory.GetFiles(sourceDir, "*.*");
                        bool exists = System.IO.Directory.Exists(backupDir);
                        if (!exists)
                            System.IO.Directory.CreateDirectory(backupDir);
                        try
                        {
                            int count = 0;
                            int count2 = 0;
                            foreach (string dirPath in Directory.GetDirectories(remote, "*", SearchOption.AllDirectories))
                            {
                                count2++;
                                Directory.CreateDirectory(dirPath.Replace(remote, local));
                            }

                            // Copy all the files & Replaces any files with the same name.
                            foreach (string newPath in Directory.GetFiles(remote, "*.*", SearchOption.AllDirectories))
                            {
                                if (!newPath.Contains("~$"))
                                {
                                    File.Copy(newPath, newPath.Replace(remote, local), true);
                                    count++;
                                }
                            }
                        }
                        catch (DirectoryNotFoundException dirNotFound)
                        {
                            Console.WriteLine(dirNotFound.Message);
                        }
                        MessageBox.Show("File Sucessfully Saved!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            tempBook.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            waitme.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QForm.DataQueriesProperties(QForm);
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
        }
    }
}

