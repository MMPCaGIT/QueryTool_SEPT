using ClosedXML.Excel;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace COMPLETE_FLAT_UI
{
    public partial class SMTT : Form
    {
        public SMTT()
        {
            InitializeComponent();
            clearSMTTEMP();
        }
        String impPath = "";

        //To get file path of order excel
        String impPath_Odr = "";
        String txtlist = "";
        //Boolean dataGen = false;
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

        private String Opts()
        {
            String UpdString = "";
            if (SmttCombo.Text.Equals("By CRD"))
            {
                UpdString = "SMTTByCRD.txt";
            }
            else if (SmttCombo.Text.Equals("By PODD"))
            {
                UpdString = "SMTTByPODD.txt";
            }
            else if (SmttCombo.Text.Equals("Ship Date"))
            {
                UpdString = "SMTTSHIPDATE.txt";
            }
            else if (SmttCombo.Text.Equals("By Order"))
            {
                UpdString = "SMTTBYORDER.txt";
            }
            else
            {
                UpdString = "";
            }

            return UpdString;
        }
        private String ComOpts()
        {
            String UpdString = "SMTTSQL.txt";
            //if (SmttCombo.Text.Equals("By CRD"))
            //{
            //    UpdString = "ByCRD3STRING.txt";
            //}
            //else if (SmttCombo.Text.Equals("By PODD"))
            //{
            //    UpdString = "ByPODD3STRING.txt";
            //}
            return UpdString;
        }    

        private void startSmmt()
        {
            if (DateErroChkMonth() == false)
            {
                DateTime selectedDate1 = dateTimePicker1.Value;
                DateTime selectedDate2 = dateTimePicker2.Value;
                Boolean bth = false;
                String rValue = "";
                String txtValue = txtlist;
                PreviewDataList Vform = new PreviewDataList();
                rValue = Opts();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                abrirFormEnPanel(Vform);
            }

        }
        private int TimeDifference()
        {
            DateTime? selectedDate1 = dateTimePicker1.Value;
            DateTime? selectedDate2 = dateTimePicker2.Value;
            DateTime FirstDate = selectedDate1.Value;
            DateTime SecondDate = selectedDate2.Value;
            TimeSpan ts = SecondDate - FirstDate;
            return ts.Days;
        }
        private Boolean DateErroChkMonth()
        {
            if (TimeDifference() > 93)
            {
                MessageBox.Show("Query allow only 3 months range");
                return true;
            }
            return false;
        }

    private void BtnCerrar_Click(object sender, EventArgs e)
        {
            GenData.Text = "Generate";
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
        }       

        private void combineProcess()
        {
            Prograssnoti waitme = new Prograssnoti();
            waitme.Show();
            String srcValue = "";
            int rowCont = 1;
            DateTime selectedDate1 = dateTimePicker1.Value;
            DateTime selectedDate2 = dateTimePicker2.Value;

            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit1 = System.IO.Path.Combine(impPath);
            var browBook = new XLWorkbook(pathDesit1);
            var browSheet = browBook.Worksheet(1);

            string pathDesit2 = System.IO.Path.Combine(rootDir, "TEMP_SMTT.xlsx");
            var tempBook = new XLWorkbook(pathDesit2);
            var tempSheet = tempBook.Worksheet(1);

            string pathDesit3 = System.IO.Path.Combine(rootDir, "SMTT_COL_DATA.xlsx");
            var comBook = new XLWorkbook(pathDesit3);
            var conSheet = comBook.Worksheet(1);

            int genlastRow = browSheet.RowsUsed().Count();
            waitme.PrograssMax(genlastRow + 1);

            var TempData1 = conSheet.Range("A1:AB1");
            var TempData2 = tempSheet.Range("A1:AB1");
            TempData2.Cell(1, 1).Value = TempData1;
            tempBook.SaveAs(rootDir + "TEMP_SMTT.xlsx");

            conSheet = null;

            for (int i = 0; i< genlastRow-1;i++)
            {
                waitme.Show();
                waitme.ShowPrg();
                rowCont++;
                String brsCol1 = (String)browSheet.Cell(rowCont, 1).Value;
                String brsCol2 = (String)browSheet.Cell(rowCont, 2).Value;
                String brsCol3 = (String)browSheet.Cell(rowCont, 3).Value;
                String rValue = ComOpts();
                QueryExportSMTT(rValue, selectedDate1, selectedDate2, brsCol1, brsCol2, brsCol3, rowCont);
                srcValue = (String)browSheet.Cell(rowCont-1, 1).Value;
                sheetcombine();
            }
            waitme.Close();
        }
        public void QueryExportSMTT(String optionName, DateTime? selectedDate1, DateTime? selectedDate2, String brsCol1, String brsCol2, String brsCol3, int rowCont)
        {
            brosRowCount = rowCont;
            DataSet ds = new DataSet();
            System.Data.DataTable dt = new System.Data.DataTable();
            
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            try
            {
                string connetStr = "";
                string frDate = selectedDate1.Value.ToString("yyyyMMdd");
                string shortFrDate = selectedDate1.Value.ToString("yyyyMM");
                string toDate = selectedDate2.Value.ToString("yyyyMMdd");
                string shortToDate = selectedDate2.Value.ToString("yyyyMM");
                DateTime FirstDate = selectedDate1.Value;
                DateTime SecondDate = selectedDate2.Value;
                TimeSpan ts = SecondDate - FirstDate;
                int differenceInDays = ts.Days;
                string fileName = optionName;
                //Declare root file path 
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                //decalre and edit full file path and qurey for sql stitching
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);

                sql = sql.Replace("brsCol1", brsCol1);
                sql = sql.Replace("brsCol2", brsCol2);
                sql = sql.Replace("brsCol3", brsCol3);
                Console.WriteLine(sql);

                //db connection

                connetStr = "Data Source=172.23.64.5:1521/MMERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
                OracleConnection conn = new OracleConnection(connetStr);
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //read data from db

                    OracleDataReader dr = cmd.ExecuteReader();
                    cmd.Connection = conn;
                    dt.Load(dr);
                    ds.Tables.Add(dt);
                    wbook.Worksheets.Add(dt, "Sheet1");

                wbook.SaveAs(rootDir + "tempExcel.xlsx");
                wbook.SaveAs(rootDir + "destination.xlsx");


            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wbook.Dispose();
            }
            
        }
        private void sheetcombine(){
            String noValue = "";
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit1 = System.IO.Path.Combine(impPath);
            var browBook = new XLWorkbook(pathDesit1);
            var browSheet = browBook.Worksheet(1);

            string pathDesit2 = System.IO.Path.Combine(rootDir, "destination.xlsx");
            var genBook = new XLWorkbook(pathDesit2);
            var genSheet = genBook.Worksheet(1);

            string pathDesit3 = System.IO.Path.Combine(rootDir, "TEMP_SMTT.xlsx");
            var comBook = new XLWorkbook(pathDesit3);
            var conSheet = comBook.Worksheet(1);

            noValue = (String)genSheet.Cell(2, 1).Value;
            if (!(noValue == null))
            {

                int genlastRow = genSheet.RowsUsed().Count();
                int conlastRow = conSheet.RowsUsed().Count();

                if (genlastRow > 1)
                {
                    var genData = genSheet.Range("A2:R" + genlastRow);
                    conSheet.Cell(conlastRow + 1, genlastRow - 1).Value = genData;
                    comBook.SaveAs(rootDir + "TEMP_SMTT.xlsx");
                    var broData = browSheet.Range("D" + brosRowCount + ":K" + brosRowCount);
                    for (int i = 1; i < genlastRow; i++)
                    {
                        conSheet.Cell(conlastRow+1, 19).Value = broData;
                        comBook.SaveAs(rootDir + "TEMP_SMTT.xlsx");
                        conlastRow++;
                    }

                    comBook.SaveAs(rootDir + "TEMP_SMTT.xlsx");
                }
            }
            comBook.Dispose();
            genBook.Dispose();
            browBook.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void combineBtn_Click_1(object sender, EventArgs e)
        {
                if (impPath.Equals("") || impPath.Equals(".xlsx"))
                {
                    MessageBox.Show("Please Import data first !");
                }
                else
                {
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                string pathDesi1 = System.IO.Path.Combine(rootDir, "SMTT_COL_DATA.xlsx");
                var tempBook = new XLWorkbook(pathDesi1);
                var tempSheet = tempBook.Worksheet(1);
                tempSheet.Clear();
                tempBook.SaveAs(rootDir + "TEMP_SMTT.xlsx");
                combineProcess();
                MessageBox.Show("successfully Combined");
                tempBook.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        //Get browse file
        //currently remove excel data checking.
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
                impPath = browseXLSX.FileName;
                browTxt.Text = browseXLSX.FileName;
            }
        }
        //Check import data has same data or not.
        //private Boolean UploadItemChk(String fileLocation)
        //{
        //    SMTTpBar.Value = 0;
        //    String erorMsg = "Please  Check Following Error -";
        //    Boolean browFlag = false;
        //    Workbook browBook;
        //    Worksheet browSheet;
        //    Microsoft.Office.Interop.Excel.Application excelapp;
        //    excelapp = new Microsoft.Office.Interop.Excel.Application();
        //    excelapp.Visible = false;
        //    excelapp.DisplayAlerts = false;
        //    excelapp.Workbooks.Add();
        //    browBook = excelapp.Workbooks.Open(fileLocation);
        //    browSheet = browBook.Sheets.get_Item(1);
        //    int browlastRow = browSheet.UsedRange.Rows.Count;
        //    SMTTpBar.Maximum = browlastRow;
        //    statusSMTT.Text = "Please wiat!. Checking Excel file";
        //    for (int i = 1; i <= browlastRow; i++)
        //    {
        //        String dataa = (String)browSheet.Cells[i, 1].Value;
        //        String datab = (String)browSheet.Cells[i, 2].Value;
        //        String datac = (String)browSheet.Cells[i, 3].Value;
        //        for (int index = 1; index <= browlastRow; index++)
        //        {
        //            browTxt.Text = browseXLSX.FileName;
        //            String data1 = (String)browSheet.Cells[index, 1].Value;
        //            String data2 = (String)browSheet.Cells[index, 2].Value;
        //            String data3 = (String)browSheet.Cells[index, 3].Value;
        //            if (i != index)
        //            {
        //                String a = (String)(browSheet.Cells[i + 1, 1].Value);
        //                if (dataa.Equals(data1) && datab.Equals(data2) && datac.Equals(data3))
        //                {
        //                    richTextBox1.ForeColor = Color.Red;
        //                    erorMsg = erorMsg + "\n Duplicate data -- row no. " + i + " and " + index + " are the same ";
        //                    richTextBox1.Text = erorMsg;
                            
        //                }
        //                else
        //                {
        //                    browFlag = true;
        //                    richTextBox1.ForeColor = Color.Green;
        //                    richTextBox1.Text = "NO Error !";
        //                }
        //            }
        //        }
        //        SMTTpBar.Value++;
        //    }
        //    statusSMTT.Text = "Checking Finished";
        //    MessageBox.Show("Check Finished");
        //    browSheet = null;
        //    browBook.Close();
        //    return browFlag;
        //}


        private void GenData_Click(object sender, EventArgs e)
        {
            if (SmttCombo.Text.Equals("By PODD") || SmttCombo.Text.Equals("By CRD") || SmttCombo.Text.Equals("Ship Date"))
            {
                startSmmt();
            }
            else
            {
                if (SmttCombo.Text.Equals("By Order"))
                {

                    //do code
                    ReadExcelandExport(opt_MLM_ID.Checked);
                    button1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please chose query type");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesi1 = System.IO.Path.Combine(rootDir, "destination.xlsx");
            var tempBook = new XLWorkbook(pathDesi1);
            var destworkSheet = tempBook.Worksheet(1);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //
            string pathDesit = System.IO.Path.Combine(rootDir, "destination.xlsx");
            //
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
                saveFileDialog.Filter = "excel|*.xlsx|All File|*.*";
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    try
                    {
                        tempBook.SaveAs(rootDir + "tempExcel.xlsx");
                        tempBook.SaveAs(rootDir + "destination.xlsx");
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
        }

        private void button3_Click(object sender, EventArgs e)
        { }

        private void GenData_Click_1(object sender, EventArgs e)
        {
            if (!SmttCombo.Text.Equals(""))
            {
                ReadExcelandExport(opt_MLM_ID.Checked);
               // startSmmt();
            }
            else
            {
                MessageBox.Show("Please chose query type");
            }
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesi1 = System.IO.Path.Combine(rootDir, "TEMP_SMTT.xlsx");
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
                    saveFileDialog.Filter = "excel|*.xlsx|All File|*.*";
                    if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        try
                        {
                        tempBook.SaveAs(saveFileDialog.FileName);
                        tempBook.SaveAs(rootDir + "destination.xlsx");
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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesi1 = System.IO.Path.Combine(rootDir, "destination.xlsx");
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
                saveFileDialog.Filter = "excel|*.xlsx|All File|*.*";
                if (saveFileDialog.ShowDialog() != DialogResult.Cancel)
                {
                    try
                    {
                        tempBook.SaveAs(saveFileDialog.FileName);
                        tempBook.SaveAs(rootDir + "destination.xlsx");
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

        }

        private void button2_Click(object sender, EventArgs e)
        {

            clearSMTTEMP();
            QForm.DataQueriesProperties(QForm);
            QForm.SubFormToShow(abrirFormEnPanel);

            this.Close();
            abrirFormEnPanel(QForm);
        }

        private void clearSMTTEMP()
        {
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesi1 = System.IO.Path.Combine(rootDir, "CLEAR_SMTT.xlsx");
            var tempBook = new XLWorkbook(pathDesi1);
            var destworkSheet = tempBook.Worksheet(1);
            tempBook.SaveAs(rootDir + "TEMP_SMTT.xlsx");
            tempBook.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void browTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void SmttCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SmttCombo.SelectedItem.Equals("By Order"))
            {
                lbl_import_file_path.Visible = true;
                lbl_import_file.Visible = true;
                btn_import.Enabled = true;
                opt_MLM_ID.Visible = true;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;


            }
            else
            {
                btn_import.Enabled = false;
                lbl_import_file.Visible = false;
                lbl_import_file_path.Visible = false;
                opt_MLM_ID.Visible = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;

            }
        }

        private void SMTT_Load(object sender, EventArgs e)
        {
            btn_import.Enabled = false;
            lbl_import_file.Visible = false;
            lbl_import_file_path.Visible = false;
            opt_MLM_ID.Visible = false;
            label1.Hide();
            label2.Hide();
          
        }


        //Read Excel oder format
        void ReadExcelandExport(bool mlm_id)
        {
            DateTime selectedDate1 = dateTimePicker1.Value;
            DateTime selectedDate2 = dateTimePicker2.Value;
            #region
            if (impPath_Odr.Equals(""))
            {
                MessageBox.Show("Please select file.");
            }
            else
            {
                String noValue = "";
                String tempvalue = "";
                String rValue = "";
                var browbook = new XLWorkbook(impPath_Odr);
                var browSheet = browbook.Worksheet(1);

                #region
                if (impPath_Odr.Equals("") || impPath_Odr.Equals(".xlsx"))
                {
                    MessageBox.Show("Please Import data first !");
                }
                #endregion
                #region
                else
                {
                    noValue = (String)browSheet.Cell(2, 1).Value;
                    if (!(noValue.Equals("")))
                    {
                        int genlastRow = browSheet.RowsUsed().Count();
                        #region
                        //MessageBox.Show(genlastRow + " ");
                        for (int i = 0; i < genlastRow; i++)
                        {
                            var aa = browSheet.Cell(1, 1).Value;
                            if (browSheet.Cell(i + 2, 1).Value != null)
                            {
                                #region
                                if (i != (genlastRow - 1))
                                {
                                    tempvalue += "'" + browSheet.Cell(i + 2, 1).Value + "'" + ",";
                                }
                                else
                                {
                                    tempvalue += "'" + browSheet.Cell(i + 2, 1).Value + "'";

                                }
                                #endregion
                            }
                            else
                            {
                                break;
                            }
                        }
                        #endregion
                        //MessageBox.Show(tempvalue);
                        PreviewDataList Vform = new PreviewDataList();

                        if (mlm_id == true)
                        {
                            rValue = "SMTTByOrderMLMID.txt";
                        }
                        else
                        {
                            rValue = "SMTTByOrder.txt";
                        }
                        Vform.SubFormToShow(abrirFormEnPanel);
                        Vform.DataQueriesProperties(QForm);
                        Vform.QueryExport(rValue, selectedDate1, selectedDate2, tempvalue, true);
                        abrirFormEnPanel(Vform);
                        //browBook.Close();
                        browSheet = null;
                        //file.Close();
                    }
                }
                #endregion
            }
            #endregion
        }
        private string l()
        {
            string aa = "test";
            return aa;
        }

        private void btn_import_Click(object sender, EventArgs e)
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
                lbl_import_file_path.Text = browseXLSX.FileName;
                impPath_Odr = browseXLSX.FileName;
            }
            lbl_import_file.Visible = true;
            lbl_import_file_path.Visible = true;
        }
    }
}
