using ClosedXML.Excel;
using Oracle.ManagedDataAccess.Client;
using QUERY_TOOL;
using System;
using System.Data;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace COMPLETE_FLAT_UI
{
    public partial class PreviewDataList : Form
    {
        Action<object> abrirFormEnPanel;
        DataQueries QForm;
        String fName = "";
        DataSet ds = new DataSet();
        public PreviewDataList()
        {
            InitializeComponent();
            button1.Hide();
        }

        internal void SubFormToShow(Action<object> abrirFormEnPanel)
        {
            this.abrirFormEnPanel = abrirFormEnPanel;
        }
        internal void DataQueriesProperties(DataQueries QFormOther)
        {
            this.QForm = QFormOther;
            String ID = QFormOther.ID;

            //Hide graph buttom
            if (QForm.ID.Equals("4"))
            {
                button1.Hide();
            }
        }

        private void BtnCerrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                string pathDesit = System.IO.Path.Combine(rootDir, "SMTT_TEST3.xlsx");
                var workbookDest = new XLWorkbook(pathDesit);
                var destworkSheet = workbookDest.Worksheet(1);
                workbookDest.SaveAs(rootDir + "destination.xlsx");
                QForm.SubFormToShow(abrirFormEnPanel);
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            abrirFormEnPanel(QForm);
        }
        public void DataBind(System.Data.DataTable dataTabl)
        {
            if (dataTabl.Rows.Count <= 60000)
            {
                dataGridView1.DataSource = dataTabl;
            }
            else
            {
                MessageBox.Show("Data Too large for preview(60000 Rows) ! \n Save and export to see data !");
            }
        }

        private String SheetName(String name)
        {
            name = name.Remove(6);
            return name;
        }
        public void QueryExport(String optionName, DateTime? selectedDate1, DateTime? selectedDate2, String txtValue, Boolean bth)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            PlsWait waitme = new PlsWait();
            waitme.Show();
            fName = optionName;
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
                string worksheetName = SheetName(optionName);
                //Declare root file path 
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                //decalre and edit full file path and qurey for sql stitching
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);
                if (bth == true)
                {
                    sql = sql.Replace("txtValue", txtValue);
                    sql = sql.Replace("frDate", frDate);
                    sql = sql.Replace("toDate", toDate);
                    sql = sql.Replace("shortFrDate", shortFrDate);
                    sql = sql.Replace("shortToDate", shortToDate);

                }
                else if (!txtValue.Equals("") && bth == false)
                {
                    sql = sql.Replace("txtValue", txtValue);
                }
                else
                {
                    sql = sql.Replace("frDate", frDate);
                    sql = sql.Replace("toDate", toDate);
                    sql = sql.Replace("shortFrDate", shortFrDate);
                    sql = sql.Replace("shortToDate", shortToDate);
                }
                Console.WriteLine(sql);

                //db connection
                if (optionName.Equals("PiCheck.txt") || optionName.Equals("bb1chk.txt") || optionName.Equals("jjchk.txt"))
                {
                    connetStr = "Data Source=172.16.3.62:1521/MMTWERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
                }

                else
                {
                    connetStr = "Data Source=172.23.64.5:1521/MMERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
                }
                OracleConnection conn = new OracleConnection(connetStr);
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //read data from db

                    OracleDataReader dr = cmd.ExecuteReader();
                    cmd.Connection = conn;
                    dt.Load(dr);
                    ds.Tables.Add(dt);
                    wbook.Worksheets.Add(dt, worksheetName);

                wbook.SaveAs(rootDir + "tempExcel.xlsx");
                wbook.SaveAs(rootDir + "destination.xlsx");

                DataBind(dt);
            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wbook.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            waitme.Close();
        }

        //QueryExportBatch will return Datatable for batch processing
        public DataTable QueryExportBatch(String optionName, DateTime? selectedDate1, DateTime? selectedDate2, String txtValue, Boolean bth)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
           // PlsWait waitme = new PlsWait();
            //waitme.Show();
            fName = optionName;
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
                if (bth == true)
                {
                    sql = sql.Replace("txtValue", txtValue);
                    sql = sql.Replace("frDate", frDate);
                    sql = sql.Replace("toDate", toDate);
                    sql = sql.Replace("shortFrDate", shortFrDate);
                    sql = sql.Replace("shortToDate", shortToDate);

                }
                else if (!txtValue.Equals("") && bth == false)
                {
                    sql = sql.Replace("txtValue", txtValue);
                }
                else
                {
                    sql = sql.Replace("frDate", frDate);
                    sql = sql.Replace("toDate", toDate);
                    sql = sql.Replace("shortFrDate", shortFrDate);
                    sql = sql.Replace("shortToDate", shortToDate);
                }
                Console.WriteLine(sql);

                //db connection
                if (optionName.Equals("PiCheck.txt") || optionName.Equals("bb1chk.txt") || optionName.Equals("jjchk.txt"))
                {
                    connetStr = "Data Source=172.16.3.62:1521/MMTWERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
                }

                else
                {
                    connetStr = "Data Source=172.23.64.5:1521/MMERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
                }
                OracleConnection conn = new OracleConnection(connetStr);
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //read data from db

                OracleDataReader dr = cmd.ExecuteReader();
                cmd.Connection = conn;
                dt.Load(dr);
                ds.Tables.Add(dt);
                return dt;
            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
           // waitme.Close();
            return dt;
        }

        //analyze the scan fail errors
        public void ScanErrorAnalyze(String name)
        {
            Prograssnoti prgrassForm = new Prograssnoti();


            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";

            string pathDesit = System.IO.Path.Combine(rootDir, "SMTT_TEST3.xlsx");
            var workbookClr = new XLWorkbook(pathDesit);
            var clrSheet = workbookClr.Worksheet(1);
            workbookClr.SaveAs(rootDir + "destination.xlsx");


            string pathDesit1 = System.IO.Path.Combine(rootDir, "data.xlsx");
            var workbookData = new XLWorkbook(pathDesit1);
            var dataworkSheet = workbookData.Worksheet(1);

            string pathDesit2 = System.IO.Path.Combine(rootDir, "tempExcel.xlsx");
            var workbookSrc = new XLWorkbook(pathDesit2);
            var srcworkSheet = workbookSrc.Worksheet(1);

            string pathDesit3 = System.IO.Path.Combine(rootDir, "destination.xlsx");
            var workbookDest = new XLWorkbook(pathDesit3);
            var destworkSheet = workbookDest.Worksheet(1);

            //clear sheet


            if (name.Equals("StErrorLine.txt"))
            {
                var genData = dataworkSheet.Range("A1:A42");
                destworkSheet.Cell(1, 1).Value = genData;
                workbookDest.SaveAs(rootDir + "destination.xlsx");

                var genData2 = dataworkSheet.Range("B1:B42");
                destworkSheet.Cell(1, 2).Value = genData2;
                workbookDest.SaveAs(rootDir + "destination.xlsx");

            }
            if (name.Equals("AsErrorLine.txt"))
            {
                var genData = dataworkSheet.Range("C1:C42");
                destworkSheet.Cell(1, 1).Value = genData;
                workbookDest.SaveAs(rootDir + "destination.xlsx");

                var genData2 = dataworkSheet.Range("B1:B42");
                destworkSheet.Cell(1, 2).Value = genData2;
                workbookDest.SaveAs(rootDir + "destination.xlsx");

            }
            int destRow = 0;
            prgrassForm.ShowLabelAna();
            prgrassForm.Show();
            prgrassForm.PrograssMax(40);
            for (destRow = 1; destRow <= 40; destRow++)
            {
                prgrassForm.ShowPrg();


                String srcValue = "";
                int rowCont = 1;
                while (!(srcValue == null))
                {

                    rowCont++;
                    String sunday = "";
                    String saturday = "";
                    // matching the line name
                    String stdData = Convert.ToString(destworkSheet.Cell(destRow, 1).Value);
                    String srcData = Convert.ToString(srcworkSheet.Cell(rowCont, 2).Value);

                    if (srcData.Equals(""))
                    {
                        srcValue = null;

                    }

                    var weDate = srcworkSheet.Cell(rowCont, 1).Value;
                    if (weDate.Equals(""))
                    {
                        break;
                    }
                    if (stdData.Equals(srcData))
                    {
                        if (!(srcData.Equals("")))
                        {
                            if (!(srcData.Equals("")))
                            {
                                int intDate = Convert.ToInt32(weDate);
                                String strDate = Convert.ToString(intDate);
                                String dateString = strDate.Substring(0, 4) + "-" + strDate.Substring(4, 2) + "-" + strDate.Substring(6, 2);
                                DateTime dt0 = Convert.ToDateTime(dateString);
                                DayOfWeek today = dt0.DayOfWeek;

                                if (today == DayOfWeek.Sunday)
                                {
                                    sunday = "1";
                                }
                                if (today == DayOfWeek.Saturday)
                                {
                                    saturday = "1";
                                    sunday = "1";
                                }
                                int column = 3;
                                if (sunday != "1")
                                {
                                    for (int index = 1; index <= 8; index++)
                                    {
                                        var strVar = srcworkSheet.Cell(rowCont + 1, column).Value;
                                        int strInt = Convert.ToInt32(strVar);
                                        String codation = Convert.ToString(strInt);
                                        if (codation.Equals("0") &&
                                            srcworkSheet.Cell(rowCont + 1, column + 1).Value.Equals(""))
                                        {

                                            destworkSheet.Cell(destRow, 2).Value = Convert.ToInt32((destworkSheet.Cell(destRow, 2).Value)) + 1;
                                            workbookDest.SaveAs(rootDir + "destination.xlsx");
                                            break;
                                        }
                                        column += 2;
                                    }
                                }
                                if (saturday == "1")
                                {
                                    for (int index = 1; index <= 4; index++)
                                    {
                                        var strVar = srcworkSheet.Cell(rowCont, column).Value;
                                        int strInt = Convert.ToInt32(strVar);
                                        String codation = Convert.ToString(strInt);
                                        String a = Convert.ToString(srcworkSheet.Cell(rowCont + 1, column + 1).Value);

                                        if (codation.Equals("0") &&
                                            srcworkSheet.Cell(rowCont + 1, column + 1).Value.Equals(""))
                                        {
                                            destworkSheet.Cell(destRow, 2).Value = Convert.ToInt32((destworkSheet.Cell(destRow, 2).Value)) + 1;
                                            workbookDest.SaveAs(rootDir + "destination.xlsx");
                                            break;
                                        }
                                        column += 2;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            workbookDest.SaveAs(rootDir + "tempExcel.xlsx");


            workbookSrc.Dispose();
            workbookDest.Dispose();
            workbookData.Dispose();
            InsertAnaData();
            prgrassForm.PrograssFull(40);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            prgrassForm.Close();

        }

        private void PreviewDataList_Load(object sender, EventArgs e)
        {

        }

        private void InsertAnaData()
        {

            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit1 = System.IO.Path.Combine(rootDir, "destination.xlsx");
            var workbookData = new XLWorkbook(pathDesit1);
            var dataworkSheet = workbookData.Worksheet(1);

            System.Data.DataTable dt = new System.Data.DataTable();
            //try
            //{
            dt.Columns.Add("Line Name");
            dt.Columns.Add("Error Count");
            String srcValue = "";
            int row = 1;
            do
            {
                srcValue = (String)dataworkSheet.Cell(row, 1).Value;
                dt.Rows.Add(Convert.ToString(dataworkSheet.Cell(row, 1).Value), Convert.ToString(dataworkSheet.Cell(row, 2).Value));
                row++;
            } while (srcValue != "Total");
            DataBind(dt);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        // need to change export method
        public void OrderEntryQuery(String OdrEntry, String fileName, DateTime? selectedDate1, DateTime? selectedDate2)
        {
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            string connetStr = "Data Source=172.23.64.5:1521/MMERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
            OracleConnection conn = new OracleConnection(connetStr);
            //Declare sheet name
            string worksheetName = fileName;
            string frDate = selectedDate1.Value.ToString("yyyyMMdd");
            string toDate = selectedDate2.Value.ToString("yyyyMMdd");
            System.Data.DataTable dt = new System.Data.DataTable();
            //Declare root file path
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";

            try
            {
                //decalre and edit full file path and qurey for sql stitching
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);
                sql = sql.Replace("txtValue", OdrEntry);
                sql = sql.Replace("frDate", frDate);
                sql = sql.Replace("toDate", toDate);

                Console.WriteLine(sql);
                //db connection
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //read data from db
                OracleDataReader dr = cmd.ExecuteReader();
                cmd.Connection = conn;

                dt.Load(dr);

                wbook.Worksheets.Add(dt, worksheetName);
                wbook.SaveAs(rootDir + "tempExcel.xlsx");
                wbook.SaveAs(rootDir + "destination.xlsx");
                DataBind(dt);
            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex + "/nPlease check your input Data !");
            }
            wbook.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();


        }
        //this function to test mail
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //Chart chartF = new Chart();
        //    //chartF.SubFormToShow(abrirFormEnPanel);
        //    //chartF.getQdata(ds);
        //    //abrirFormEnPanel(chartF);
        //    var fromAddress = new MailAddress("d.ayechan426@gmail.com", "DD");
        //    var toAddress = new MailAddress("sawdayechan.sdac@gmail.com", "other D");
        //    const string fromPassword = "everlastingGod";
        //    const string subject = "Mail check";
        //    const string body = "Hello";

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        //    };
        //    using (var message = new MailMessage(fromAddress, toAddress)
        //    {
        //        Subject = subject,
        //        Body = body
        //    })
        //    {
        //        smtp.Send(message);
        //    }
        //}

        public void ChkMat(String UpdString, String fileName)
        {
            fName = fileName;
            //Messagef Vform = new Messagef();
            //Vform.DataQueriesProperties(QForm);
            //Vform.SubFormToShow(abrirFormEnPanel);
            //abrirFormEnPanel(Vform);
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            string connetStr = "Data Source=172.23.64.5:1521/MMERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
            OracleConnection conn = new OracleConnection(connetStr);
            //Declare sheet name
            string worksheetName = fileName;
            System.Data.DataTable dt = new System.Data.DataTable();
            //Declare root file path 
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            try
            {
                //decalre and edit full file path and qurey for sql stitching
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);
                sql = sql.Replace("UpdString", UpdString);

                Console.WriteLine(sql);
                //db connection

                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //read data from db
                OracleDataReader dr = cmd.ExecuteReader();
                cmd.Connection = conn;

                dt.Load(dr);

                wbook.Worksheets.Add(dt, worksheetName);
                wbook.SaveAs(rootDir + "tempExcel.xlsx");
                wbook.SaveAs(rootDir + "destination.xlsx");
                DataBind(dt);
            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex + "/nPlease check your input Data !");
            }
            wbook.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (fName.Equals("Laminate.txt") || fName.Equals("Indisg.txt") || fName.Equals("Disg.txt"))
            {
                LikChk Vform = new LikChk();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }
            else if (fName.Equals("SMTTByPODD.txt") || fName.Equals("SMTTByCRD.txt") || fName.Equals("SMTTSHIPDATE.txt") || fName.Equals("SMTTbyOrder.txt") || fName.Equals("SMTTByOrderMLMID.txt"))
            {
                SMTT Vform = new SMTT();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (fName.Contains("micByAcc"))
            {
                micWithAcc Vform = new micWithAcc();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
             else if (fName.Contains("MatSearch"))
            {
                MatSearch Vform = new MatSearch();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (fName.Equals("PurdMatmSearch.txt"))
            {
                PurdmatSearch  Vform = new PurdmatSearch();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (fName.Equals("bb1chk.txt"))
            {
                rpmtrack Vform = new rpmtrack();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (fName.Equals("zaochk.txt"))
            {
                zaotrack Vform = new zaotrack();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (fName.Equals("LOrderStatusInquiryRECDATE.txt") || fName.Equals("LOrderStatusInquiryORDER.txt") || fName.Equals("POrderStatusInquiryORDER.txt")|| fName.Equals("POrderStatusInquiryRECDATE.txt"))
            {
                POstatus_inquiry Vform = new POstatus_inquiry();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (fName.Equals("MatPriceSearch_ByDate.txt") || fName.Equals("MatPriceSearch_ByMat.txt"))
            {
                MatPriceSearch Vform = new MatPriceSearch();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (fName.Equals("purf1-3.txt"))
            {
                purf13 Vform = new purf13();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }

            else
            {
                abrirFormEnPanel(QForm);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit1 = System.IO.Path.Combine(rootDir, "destination.xlsx");
            var workbookData = new XLWorkbook(pathDesit1);
            var dataworkSheet = workbookData.Worksheet(1);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //
            var blankData = (String)dataworkSheet.Cell(2, 1).Value;

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
                        workbookData.SaveAs(saveFileDialog.FileName);
                        workbookData.SaveAs(rootDir + "destination.xlsx");
                        MessageBox.Show("File Sucessfully Saved!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            workbookData.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        // for dispatch form
        public void DispatchForm(String optionName, DateTime? selectedDate1, DateTime? selectedDate2, String txtValue, Boolean bth)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            PlsWait waitme = new PlsWait();
            waitme.Show();
            fName = optionName;
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
                string worksheetName = SheetName(optionName);
                //Declare root file path 
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                //decalre and edit full file path and qurey for sql stitching
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);
                if (bth == true)
                {
                    sql = sql.Replace("txtValue", txtValue);
                    sql = sql.Replace("frDate", frDate);
                    sql = sql.Replace("toDate", toDate);
                    sql = sql.Replace("shortFrDate", shortFrDate);
                    sql = sql.Replace("shortToDate", shortToDate);

                }
                else if (!txtValue.Equals("") && bth == false)
                {
                    sql = sql.Replace("txtValue", txtValue);
                }
                else
                {
                    sql = sql.Replace("frDate", frDate);
                    sql = sql.Replace("toDate", toDate);
                    sql = sql.Replace("shortFrDate", shortFrDate);
                    sql = sql.Replace("shortToDate", shortToDate);
                }
                Console.WriteLine(sql);

                //db connection
                if (optionName.Equals("PiCheck.txt"))
                {
                    connetStr = "Data Source=172.16.3.62:1521/MMTWERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
                }
                else
                {
                    connetStr = "Data Source=172.23.64.5:1521/MMERP;User Id=TEAMPMA;Password=FF1EFAF44C;";
                }
                OracleConnection conn = new OracleConnection(connetStr);
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //read data from db

                var task = new Thread(() =>
                {
                    OracleDataReader dr = cmd.ExecuteReader();
                    cmd.Connection = conn;
                    dt.Load(dr);
                    ds.Tables.Add(dt);
                    wbook.Worksheets.Add(dt, worksheetName);
                });
                task.SetApartmentState(ApartmentState.STA);
                task.Start();
                task.Join();
                wbook.SaveAs(rootDir + "destination.xlsx");

                DataBind(dt);
            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wbook.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            waitme.Close();
        }
        public void QueryExportOderConsum(String optionName,String txtValue)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            fName = optionName;
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            try
            {
                string connetStr = "";
                string fileName = optionName;
                string worksheetName = SheetName(optionName);
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);
                sql = sql.Replace("txtValue", txtValue);
                Console.WriteLine(sql);
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
                    wbook.Worksheets.Add(dt, worksheetName);
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

        public void QueryExportSole(String optionName, DateTime? selectedDate1, DateTime? selectedDate2, String txtValue, Boolean bth)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            PlsWait waitme = new PlsWait();
            waitme.Show();
            fName = optionName;
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
                string worksheetName = SheetName(optionName);
                //Declare root file path 
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                //decalre and edit full file path and qurey for sql stitching
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);
 
                    sql = sql.Replace("txtValue", txtValue);
                    sql = sql.Replace("frDate", frDate);
                    sql = sql.Replace("toDate", toDate);

                Console.WriteLine(sql);

                //db connection
                if (optionName.Equals("PiCheck.txt") || optionName.Equals("micByAccSoleBB1.txt"))
                {
                    connetStr = "Data Source=chemicaldb.pouchen.com.mm/ORCL;User Id=pccchem_pym;Password=pymdcmisdb;";
                }

                else
                {
                    //connetStr = "Data Source=172.23.64.2:1521/ORCL;User Id=pccchem_pym;Password=pymdcmisdb;";
                    connetStr = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=chemicaldb.pouchen.com.mm)(PORT=1521)))(CONNECT_DATA=(SID=ORCL)));User ID=pccchem_pym;Password=pymdcmisdb";

                }
                OracleConnection conn = new OracleConnection(connetStr);
                conn.Open();
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //read data from db

                    OracleDataReader dr = cmd.ExecuteReader();
                    cmd.Connection = conn;
                    dt.Load(dr);
                    ds.Tables.Add(dt);
                    wbook.Worksheets.Add(dt, worksheetName);

                wbook.SaveAs(rootDir + "tempExcel.xlsx");
                wbook.SaveAs(rootDir + "destination.xlsx");

                DataBind(dt);
            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wbook.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            waitme.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        public void QueryExport(String optionName, DateTime? selectedDate1, DateTime? selectedDate2, String txtValue, String sttxt,String art)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            PlsWait waitme = new PlsWait();
            waitme.Show();
            fName = optionName;
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            try
            {
                string connetStr = "";
                string fileName = optionName;
                string worksheetName = SheetName(optionName);
                //Declare root file path 
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                //decalre and edit full file path and qurey for sql stitching
                string filePath = System.IO.Path.Combine(rootDir, fileName);
                string sql = File.ReadAllText(rootDir + fileName);
                sql = sql.Replace("txtValue", txtValue);
                sql = sql.Replace("stValue", sttxt);
                sql = sql.Replace("artValue", art);
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
                    wbook.Worksheets.Add(dt, worksheetName);
                wbook.SaveAs(rootDir + "destination.xlsx");

                DataBind(dt);
            }
            //Catching error
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                wbook.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            waitme.Close();
        }
    }
}
