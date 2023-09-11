using Microsoft.Office.Interop.Excel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using DataTable = System.Data.DataTable;

namespace COMPLETE_FLAT_UI
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent1();
        }
        String impPath = "";
        int brosRowCount = 0;
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void browseFile_Click(object sender, EventArgs e)
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
                browTxt.Text = browseXLSX.FileName;
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
                browTxt.Text = browseXLSX.FileName;


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string rootDir = System.IO.Path.Combine(Environment.CurrentDirectory, @"data\");
            Worksheet destworkSheet;
            Workbook workbookDest;
            Microsoft.Office.Interop.Excel.Application excelapp;
            excelapp = new Microsoft.Office.Interop.Excel.Application();
            excelapp.Visible = false;
            excelapp.DisplayAlerts = false;
            excelapp.Workbooks.Add();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //
            string pathDesit = System.IO.Path.Combine(rootDir, "TEMP_SMTT.xlsx");
            workbookDest = excelapp.Workbooks.Open(pathDesit);
            destworkSheet = workbookDest.Sheets.get_Item(1);
            //
            var blankData = destworkSheet.Cells[2, 1].value;

            if (blankData is null)
            {
                MessageBox.Show("NO data to save !! \nPlease generate data first!");
            }
            else
            {
                saveFileDialog.InitialDirectory = "C:";
                saveFileDialog.Title = "Export";
                saveFileDialog.FileName = "";
                saveFileDialog.Filter = "excel|*.xlsx|All File|*.*";
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    try
                    {
                        workbookDest.SaveAs(saveFileDialog.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing);
                        MessageBox.Show("File Sucessfully Saved!");

                        workbookDest.SaveAs(rootDir + "destination.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            workbookDest.Close();
            excelapp.Quit();
            excelapp = null;
            workbookDest = null;
        }

        private void browTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
