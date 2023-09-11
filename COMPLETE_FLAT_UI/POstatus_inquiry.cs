using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COMPLETE_FLAT_UI;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.IO;

namespace QUERY_TOOL
{
    public partial class POstatus_inquiry : Form
    {
        public string impPath_Odr;
        public bool finalflag = false;// To control excel export EOF
        public int row_count_main;
        public POstatus_inquiry()
        {
            InitializeComponent();
        }
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
        private void button2_Click(object sender, EventArgs e)
        {
            QForm.DataQueriesProperties(QForm);
            QForm.SubFormToShow(abrirFormEnPanel);
            this.Close();
            abrirFormEnPanel(QForm);
        }

        private void POstatus_inquiry_Load(object sender, EventArgs e)
        {
            gb_order.Enabled = false;
            gb_receipt.Enabled = false;
            gb_blank.Enabled = false;

           
        }

  
        private void cbo_exportby_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(cbo_exportby.SelectedIndex == 0) // It is for receipt order 
            {
                gb_receipt.Enabled = true;
                gb_order.Enabled = false;
                gb_blank.Enabled = true;
            }
            if (cbo_exportby.SelectedIndex == 1) // it is for excel import order
            {
                gb_receipt.Enabled = false;
                gb_order.Enabled = true;
                gb_blank.Enabled = true;
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            {
                opd_xlsx.FileName = "";
                opd_xlsx.InitialDirectory = @"D:\";
                opd_xlsx.Title = "Browse xlsx Files";
                opd_xlsx.CheckFileExists = true;
                opd_xlsx.CheckPathExists = true;
                opd_xlsx.DefaultExt = "";
                opd_xlsx.Filter = "xlsx files (*.xlsx)|*.xlsx";
                opd_xlsx.FilterIndex = 2;
                opd_xlsx.RestoreDirectory = true;
                opd_xlsx.ShowDialog();
                txt_path.Text = opd_xlsx.FileName;
                impPath_Odr = opd_xlsx.FileName;
            }
           
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            try
            {

           
            string txtValue="";
            Boolean bth = false;

            //Progress bar region-------------------
            Pbar_status.Value = 0;
            Pbar_status.Visible = false;

            // there is no select export by dropdown
            if (cbo_exportby.SelectedIndex < 0)
            { MessageBox.Show("Please select Export Type to generate data","Export");return; }

            #region Receipt order date
            // Export type is receipt order date
            if (cbo_exportby.SelectedIndex == 0)
            {
                //    MessageBox.Show("Please select Export Type to generate data", "Export"); return;
                if (DateErroChkMonth() == false)
                {
                    if (opt_1.Checked == false && opt_2.Checked == false)
                    {
                        MessageBox.Show("Please select order status to generate data","Order Status");
                    }
                    else
                    {
                        if (opt_1.Checked == true)
                        {
                            #region Purchase order status with received date [Main]

                            // Receipt purchase order with date
                            PreviewDataList Vform = new PreviewDataList();
                            string rValue = "POrderStatusInquiryRECDATE.txt";
                            Vform.DataQueriesProperties(QForm);
                            Vform.SubFormToShow(abrirFormEnPanel);
                            Vform.QueryExport(rValue, dtp_from.Value, dtp_to.Value, txtValue, bth);
                            abrirFormEnPanel(Vform);

                            #endregion
                        }
                        if(opt_2.Checked == true)
                        {
                            #region Lamination order status with received data [Main]

                            // Receipt purchase order with date
                            PreviewDataList Vform = new PreviewDataList();
                            string rValue = "LOrderStatusInquiryRECDATE.txt";
                            Vform.DataQueriesProperties(QForm);
                            Vform.SubFormToShow(abrirFormEnPanel);
                            Vform.QueryExport(rValue, dtp_from.Value, dtp_to.Value, txtValue, bth);
                            abrirFormEnPanel(Vform);

                            #endregion
                        }
                    }

                }
            }
            #endregion

            #region Excel import
            // Export type is excel import
            if (cbo_exportby.SelectedIndex == 1)
            {
                if(txt_path.Text == "")
                {
                    MessageBox.Show("Please import order data excel first", "Import");return;
                }
                else
                {
                    if (opt_1.Checked == false && opt_2.Checked == false)
                    {
                        MessageBox.Show("Please select order status to generate data", "Order Status");
                    }
                    else
                    {
                        if (opt_1.Checked == true)
                        {
                            Pbar_status.Visible = true;
                            Pbar_status.Value = 5;
                            #region Purchase order status by order [Main]

                            //Receipt purchase order with date
                            //PreviewDataList Vform = new PreviewDataList();
                            //string rValue = "POrderStatusInquiryRECDATE.txt";
                            //Vform.DataQueriesProperties(QForm);
                            //Vform.SubFormToShow(abrirFormEnPanel);
                            //Vform.QueryExport(rValue, dtp_from.Value, dtp_to.Value, txtValue, bth);
                            //abrirFormEnPanel(Vform);
                            ReadExcelandExportBatch(true);
                            #endregion
                        }
                        if (opt_2.Checked == true)
                        {
                            #region Lamination order status by order [Main]

                            Pbar_status.Visible = true;
                            Pbar_status.Value = 5;
                            //// Receipt purchase order with date
                            //PreviewDataList Vform = new PreviewDataList();
                            //string rValue = "LOrderStatusInquiryRECDATE.txt";
                            //Vform.DataQueriesProperties(QForm);
                            //Vform.SubFormToShow(abrirFormEnPanel);
                            //Vform.QueryExport(rValue, dtp_from.Value, dtp_to.Value, txtValue, bth);
                            //abrirFormEnPanel(Vform);
                            ReadExcelandExportBatch(false);
                            #endregion
                        }
                    }
                }
            }
                #endregion

                //End progress bar region-------------------

                Pbar_status.Value = 0;
                Pbar_status.Visible = false;
               
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2147024864)
                {
                    MessageBox.Show("Please close the import file first." + ex.HResult, "Error info",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Please contact system administrator. Error: " + ex.HResult, "Error info");
                }
                RollBack();
            }
        }

        private void RollBack()
        {
            Pbar_status.Value = 0;
            Pbar_status.Visible = false;
            gb_order.Enabled = false;
            gb_receipt.Enabled = false;
            gb_blank.Enabled = false;
            opt_1.Checked = false;
            opt_2.Checked = false;
            txt_path.Text = "";
            cbo_exportby.SelectedIndex = -1;  
        }

        private int TimeDifference()
        {
            DateTime? varfrom = dtp_from.Value;
            DateTime? varto = dtp_to.Value;
            DateTime FirstDate = varfrom.Value;
            DateTime SecondDate = varto.Value;
            TimeSpan ts = SecondDate - FirstDate;
            return ts.Days;
        }
        private Boolean DateErroChkMonth()
        {
            if (TimeDifference() > 186)
            {
                MessageBox.Show("Query allow only 3 months range","Over 3 Months");
                return true;
            }
            return false;
        }

        //Read Excel oder format
        void ReadExcelandExportBatch(bool order_status)
        {
         
            DateTime selectedDate1 = dtp_from.Value;
            DateTime selectedDate2 = dtp_to.Value;
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
                        row_count_main = genlastRow;// EOF row count of excel
                        #region Import Excel and Export Excel
                        int dividend, start_val = 0, end_val = 0;

                        // adding one is to reach final seperated data such as 789 row ,650 ros
                        dividend = genlastRow / 1000 + 1;
                        int pg_val = 75 / dividend;

                        for (int i = 0; i < dividend; i++)
                        {
                            Pbar_status.Value = Pbar_status.Value + pg_val;
                            if (i != 0)
                            {
                                start_val = end_val + 1;
                            }
                            else
                            {
                                start_val = i;
                            }

                            end_val = end_val + 1000;

                            Import_Excel_Main(order_status, selectedDate1, selectedDate2, tempvalue, out rValue, browbook, browSheet, start_val, end_val);

                        }
                        Pbar_status.Value = Pbar_status.Value + 10;
                        RemoveImportSheet();
                        Pbar_status.Value = Pbar_status.Value + 10;
                        SaveAndCopyExcel();
                       
                        return;
                        #endregion
                    }
                }
                #endregion
               
            }
            #endregion
        }

        private static void RemoveImportSheet()
        {
            var inputtxt = Directory.GetCurrentDirectory() + "\\Data\\OrderStatus_Inquiry.xlsx";
            var DeleteBook = new XLWorkbook(inputtxt);
            bool ChkName = false;
            // Removing Import Sheet
            foreach (var item in DeleteBook.Worksheets)
            {
                if(item.Name == "Sheet1")
                {
                    ChkName = true;
                }
            }
            if (ChkName == true)
            {
                DeleteBook.Worksheet("Sheet1").Delete();
                DeleteBook.Save();
            }
            DeleteBook.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }


        //
        private void Import_Excel_Main(bool order_status, DateTime selectedDate1, DateTime selectedDate2, string tempvalue, out string rValue,IXLWorkbook browBook, IXLWorksheet browSheet, int startvalue,int lastrow)
        {
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            //MessageBox.Show(tempvalue);
            PreviewDataList Vform = new PreviewDataList();

            if (order_status == true)
            {
                rValue = "POrderStatusInquiryORDER.txt";
            }
            else
            {
                rValue = "LOrderStatusInquiryORDER.txt";
            }
            // This is adding query result to datatable main region
            ////
            ////
            DataTable dt = new DataTable();
            tempvalue = Over1000(order_status,tempvalue,browSheet,startvalue,lastrow);
            dt = Vform.QueryExportBatch(rValue, selectedDate1, selectedDate2, tempvalue, true);

            browBook.Worksheets.Add(dt,"Sheet " + startvalue.ToString() +" to "+ lastrow.ToString());
            if (finalflag == true)
            {
                //browBook.Worksheet(0).Delete();
                browBook.SaveAs(rootDir + "OrderStatus_Inquiry.xlsx");
                //MessageBox.Show((lastrow - 1).ToString());
            }
            ///
           // abrirFormEnPanel(Vform);
            //browBook.Close();
            browSheet = null;
            //file.Close();
        }

        private  string Over1000(bool order_status,string tempvalue,IXLWorksheet browSheet,int start_val, int genlastRow)
        {
            for (int i = start_val; i < genlastRow; i++)
            {
                if(i==row_count_main+1)
                {
                    finalflag = true;
                }
                var aa = browSheet.Cell(1, 1).Value;
                if (genlastRow == 1000)
                {
                    if (browSheet.Cell(i + 2, 1).Value != null)
                    {
                        #region Under 1000
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
                }
                else
                {

                    if (browSheet.Cell(i, 1).Value != null)
                    {
                        #region Over 1000
                        if (i != (genlastRow - 1))
                        {
                            tempvalue += "'" + browSheet.Cell(i, 1).Value + "'" + ",";
                        }
                        else
                        {
                            tempvalue += "'" + browSheet.Cell(i, 1).Value + "'";

                        }
                        #endregion
                    }
                }

            }

            return tempvalue;
        }
   
        //Read Excel oder format
        void ReadExcelandExport(bool order_status)
        {
            DateTime selectedDate1 = dtp_from.Value;
            DateTime selectedDate2 = dtp_to.Value;
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

                        if (order_status == true)
                        {
                            rValue = "POrderStatusInquiryORDER.txt";
                        }
                        else
                        {
                            rValue = "LOrderStatusInquiryORDER.txt";
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveExcel();
        }

        public void SaveExcel()
        {
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit1 = System.IO.Path.Combine(rootDir, "OrderStatus_Inquiry.xlsx");
            var workbookData = new XLWorkbook(pathDesit1);
            var dataworkSheet = workbookData.Worksheet(1);
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //
            var blankData = (String)dataworkSheet.Cell(2, 1).Value;

            if (blankData == null || blankData =="")
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

        public void SaveAndCopyExcel()
        {
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit1 = System.IO.Path.Combine(rootDir, "OrderStatus_Inquiry.xlsx");
            var workbookData = new XLWorkbook(pathDesit1);
            var dataworkSheet = workbookData.Worksheet(1);
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            //
            var blankData = (String)dataworkSheet.Cell(2, 1).Value;

            if (blankData == null || blankData == "")
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
                        //workbookData.SaveAs(rootDir + "destination.xlsx");
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


    }

    public partial class Odrm
    {

        public string fact_odr_no { get; set; }
        public string purplan_seq { get; set; }
        public string mat_no { get; set; }
        public int pld_req_qty { get; set; }
        public int nonpur_qty { get; set; }
        public int pured_qty { get; set; }
        public int insped_qty { get; set; }
        public int billed_qty { get; set; }
        public string ans_etd_date { get; set; }
        public string mat_name { get; set; }
        public string matm_unit { get; set; }
    }

}
