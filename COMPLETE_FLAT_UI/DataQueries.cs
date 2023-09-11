using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Point = System.Drawing.Point;
using Application = System.Windows.Forms.Application;
using ClosedXML.Excel;
using NPOI.POIFS.FileSystem;
using System.IO;
using NPOI.POIFS.Crypt;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using Color = System.Drawing.Color;
using QUERY_TOOL;
//add function//
//1 - ShowAllOp() - to show option
//2 - HideAllOp() - to hide option
//3 - CostingPermis()/PurchasePermis()/OtherPermis() - to add function i
//4 - add in on click mehtod for if need according to function is need date or buttone chang name
//5 - GetRadioOption() - when function checkd - to call the main process 
namespace COMPLETE_FLAT_UI
{
    public partial class DataQueries : Form
    {
        public String username = ""; public String dept = ""; public String role = ""; public String ID = ""; public String pass = ""; public String ip = "";
        public String[] menuPermis = new string[10];
        public String[] Permis = new string[30];
        public DataQueries()
        {
            InitializeComponent();
            UIpty();
           
            DataGen.Location = new Point(690, 10);
        }
        Action<object> abrirFormEnPanel;
        DataQueries QForm;
        internal void SubFormToShow(Action<object> abrirFormEnPanel)
        {
            this.abrirFormEnPanel = abrirFormEnPanel;
        }
        internal void DataQueriesProperties(DataQueries QForm, String deptID)
        {
            HideAllOp();
            this.QForm = QForm;
            ArrangeRadioBtn(deptID);
        }
        public void ArrangeRadioBtn(String deptID)
        {
            if (deptID.Equals("Customs"))
            {
                UIpty();
                HideAllOp();
                CustomsPermis();

            }
            else if (deptID.Equals("Costing"))
            {
                UIpty();
                HideAllOp();
                CostingPermis();
            }
            else if (deptID.Equals("Purchasing"))
            {
                UIpty();
                HideAllOp();
                PurchasePermis();
            }
            else if (deptID.Equals("QIP"))
            {
                UIpty();
                HideAllOp();
                QIPPmis();
            }
            else if (deptID.Equals("Warehouse"))
            {
                UIpty();
                HideAllOp();
                WHPmis();
            }
            else if (deptID.Equals("Others"))
            {
                UIpty();
                HideAllOp();
                OtherPermis();
            }
        }
        internal void DataQueriesProperties(DataQueries QForm)
        {
            this.QForm = QForm;
        }
        //Hide all radio button
        private void ShowAllOp()
        {
            odrCancel.Show();
            odrAndQtyChange.Show();
            LikChk.Show();
            OdrConsum.Show();
            piCheck.Show();
            asError.Show();
            stError.Show();
            MatSearch.Show();
            SMTT.Show();
            dr_odr_line_chk.Show();
            cargoList.Show();
            cartoonWeight.Show();
            matWeight.Show();
            blkMat.Show();
            EMCExport.Show();
            EDI.Show();
            DB1.Show();
            dsorderdata.Show();
            pListINV.Show();
            micByAcc.Show();
            sno.Show();
            jjtrack.Show();
            zaochk.Show();
            trackInv.Show();
            opt_po_status_inquiry.Show();
            opt_bwlst_mlm_id.Show();
            opt_matprice_search.Show();
            purf13.Show();

        }
        //Hide all radio button
        public void HideAllOp()
        {
            odrCancel.Hide();
            odrAndQtyChange.Hide();
            LikChk.Hide();
            OdrConsum.Hide();
            piCheck.Hide();
            asError.Hide();
            stError.Hide();
            MatSearch.Hide();
            SMTT.Hide();
            dr_odr_line_chk.Hide();
            cargoList.Hide();
            cartoonWeight.Hide();
            matWeight.Hide();
            blkMat.Hide();
            EDI.Hide();
            EMCExport.Hide();
            DB1.Hide();
            dsorderdata.Hide();
            pListINV.Hide();
            micByAcc.Hide();
            sno.Hide();
            jjtrack.Hide();
            zaochk.Hide();
            trackInv.Hide();
            opt_po_status_inquiry.Hide();
            opt_bwlst_mlm_id.Hide();
            opt_matprice_search.Hide();
            purf13.Hide();
        }
        public void SubFormToShow(FormMenuPrincipal formShowPass)
        {
        }
        public void SetTheme(String theme)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
            LikChk.ForeColor = Color.FromArgb(0, 0, 0);
        }
        public Boolean Setrole(String username, String password)
        {
            return Role(username, password);
        }
        public void SetroleInfo(String username, String dept, String role, String ID, String pass)
        {
            this.username = username;
            this.dept = dept;
            this.role = role;
            this.ID = ID;
            this.pass = pass;
        }
        //-------------------********* 
        public String GetUserID()
        {
            return ID;
        }
        public String[] GetmenuPermis()
        {
            return Permis;
        }
        public string GetUserPass()
        {
            return pass;
        }
        public String GetUserName()
        {
            return this.username;
        }
        public String GetUserDept()
        {
            return this.dept;
        }
        public String GetUserRole()
        {
            return this.role;
        }
        //get IP address from user
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
        private void UIpty()
        {
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            txtLabel.Hide();
            text.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            label1.Show();
            label2.Show();
            jjtrack.Show();
            purTypeTW.Hide();
            purTypeOS.Hide();
            matText.Hide();
            MatLable.Hide();
            MoveNor();
            //dsorderdata.Show();


        }
        private Boolean Role(String user, String pwd)
        {
            HideAllOp();
            username = user;
            Boolean valid = false;
            //Boolean ipcor = false;
            String permis = "";
            string[] result = new String[30];
            //Delcare require dll
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            string pathDesit = System.IO.Path.Combine(rootDir, "login.xlsx");
            FileStream file = new FileStream(pathDesit, FileMode.Open, FileAccess.Read);
           
                //DirectoryNode dn = new DirectoryNode();
                NPOIFSFileSystem fs = new NPOIFSFileSystem(file);

                EncryptionInfo info = new EncryptionInfo(fs);
                Decryptor.GetInstance(info).VerifyPassword("1@admin");
                //d.verifyPassword(Decryptor.DEFAULT_PASSWORD);
                XSSFWorkbook wb = new XSSFWorkbook(Decryptor.GetInstance(info).GetDataStream(fs));
            ISheet dataworkSheet = wb.GetSheetAt(0);

            String srcValue = "";
            int rowCont = 0;
            Boolean accesIP = false;
            while (srcValue != null)
            {
                rowCont++;

                if (rowCont == 46)
                {
                    var username = dataworkSheet.GetRow(rowCont + 1);
                    String test = dataworkSheet.GetRow(rowCont).GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                }
                if (dataworkSheet.GetRow(rowCont) == null)
                {
                    srcValue = null;
                    var username = dataworkSheet.GetRow(rowCont + 1);
                    break;
                }
                else
                {
                    String username = dataworkSheet.GetRow(rowCont).GetCell(1, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                    String password = dataworkSheet.GetRow(rowCont).GetCell(2, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                    if (username.Equals(user) && pwd.Equals(password))
                    {
                        dept = dataworkSheet.GetRow(rowCont).GetCell(3, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                        role = dataworkSheet.GetRow(rowCont).GetCell(4, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                        ip = dataworkSheet.GetRow(rowCont).GetCell(5, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                        ID = dataworkSheet.GetRow(rowCont).GetCell(0, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                        permis = dataworkSheet.GetRow(rowCont).GetCell(8, MissingCellPolicy.RETURN_NULL_AND_BLANK).ToString();
                        Permis = permis.Split(',');
                        pass = pwd;
                        valid = true;
                        accesIP = true;
                        srcValue = null;
                        break;

                    }
                }
            }
            //close excel
            wb.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();


            if (accesIP == false || valid == false)
            {
                MessageBox.Show("Access denied");
            }

            return valid;
        }
        public String[] MenuPermis()
        {
            HideAllOp();
            for (int i = 0; i < Permis.Length; i++)
            {
                switch (Permis[i])
                {
                    case "A":
                        menuPermis[0] = Permis[i];
                        break;
                    case "B":
                        menuPermis[1] = Permis[i];
                        break;
                    case "C":
                        menuPermis[2] = Permis[i];
                        break;
                    case "a":
                        menuPermis[3] = Permis[i];
                        break;
                    case "b":
                        menuPermis[4] = Permis[i];
                        break;
                    case "c":
                        menuPermis[5] = Permis[i];
                        break;
                    case "d":
                        menuPermis[6] = Permis[i];
                        break;
                    case "e":
                        menuPermis[7] = Permis[i];
                        break;
                    case "f":
                        menuPermis[7] = Permis[i];
                        break;
                }
            }
            return menuPermis;
        }
        public void CostingPermis()
        {
            int x = 25;
            int y = 150;
            int countOpt = 0;
            for (int i = 0; i < Permis.Length; i++)
            {

                if (countOpt + 1 >= 1 && countOpt + 1 <= 4)
                {
                    y = 150;
                }
                if (countOpt + 1 >= 5 && countOpt + 1 <= 8)
                {
                    if (countOpt == 4)
                    {
                        x = 25;
                    }
                    y = 200;
                }
                if (countOpt + 1 >= 9 && countOpt + 1 <= 12)
                {
                    x = 22;
                    y = 250;
                }
                switch (Permis[i])
                {              
                    case "1":
                        countOpt++;
                        odrCancel.Location = new Point(x, y);
                        odrCancel.Show();
                        x += 200;
                        break;
                    case "2":
                        countOpt++;
                        odrAndQtyChange.Location = new Point(x, y);
                        odrAndQtyChange.Show();
                        x += 200;
                        break;
                    case "3":
                        countOpt++;
                        LikChk.Location = new Point(x, y);
                        LikChk.Show();
                        x += 200;
                        break;
                    case "5":
                        countOpt++;
                        OdrConsum.Location = new Point(x, y);
                        OdrConsum.Show();
                        x += 200;
                        break;
                    case "16":
                        countOpt++;
                        EMCExport.Location = new Point(x, y);
                        EMCExport.Show();
                        x += 200;
                        break;
                    case "17":
                        countOpt++;
                        DB1.Location = new Point(x, y);
                        DB1.Show();
                        x += 200;
                        break;
                    case "30":
                        countOpt++;
                        purf13.Location = new Point(x, y);
                        purf13.Show();
                        x += 200;
                        break;
                }
            }
        }
        public void CustomsPermis()
        {
            int x = 25;
            int y = 150;
            int countOpt = 0;
            for (int i = 0; i < Permis.Length; i++)
            {

                if (countOpt + 1 >= 1 && countOpt + 1 <= 4)
                {
                    y = 150;
                }
                if (countOpt + 1 >= 5 && countOpt + 1 <= 8)
                {
                    if (countOpt == 4)
                    {
                        x = 25;
                    }
                    y = 200;
                }
                if (countOpt + 1 >= 9 && countOpt + 1 <= 12)
                {
                    x = 22;
                    y = 250;
                }
                switch (Permis[i])
                {
                    
                    case "6":
                        countOpt++;
                        cargoList.Location = new Point(x, y);
                        cargoList.Show();
                        x += 200;
                        break;
                    case "7":
                        countOpt++;
                        cartoonWeight.Location = new Point(x, y);
                        cartoonWeight.Show();
                        x += 200;
                        break;
                    case "8":
                        countOpt++;
                        matWeight.Location = new Point(x, y);
                        matWeight.Show();
                        x += 200;
                        break;
                    case "19":
                        countOpt++;
                        pListINV.Location = new Point(x, y);
                        pListINV.Show();
                        x += 200;
                        break;
                    case "20":
                        countOpt++;
                        micByAcc.Location = new Point(x, y);
                        micByAcc.Show();
                        x += 200;
                        break;
                }
            }
        }
        public void PurchasePermis()
        {
            int x = 25;
            int y = 150;
            int countOpt = 0;
            for (int i = 0; i < Permis.Length; i++)
            {

                if (countOpt + 1 >= 1 && countOpt + 1 <= 4)
                {
                    y = 150;
                }
                if (countOpt + 1 >= 5 && countOpt + 1 <= 8)
                {
                    if (countOpt == 4)
                    {
                        x = 25;
                    }
                    y = 200;
                }
                if (countOpt + 1 >= 9 && countOpt + 1 <= 12)
                {
                    x = 22;
                    y = 250;
                }

          
                switch (Permis[i])
                {
                    
                    case "4":
                        countOpt++;
                        piCheck.Location = new Point(x, y);
                        piCheck.Show();
                        x += 200;
                        break;
                   
                    case "9":
                        countOpt++;
                        SMTT.Location = new Point(x, y);
                        SMTT.Show();
                        x += 200;
                        break;
                    case "15":
                        countOpt++;
                        EDI.Location = new Point(x, y);
                        EDI.Show();
                        x += 200;
                        break;

                    case "24":
                        countOpt++;
                        zaochk.Location = new Point(x, y);
                        zaochk.Show();
                        x += 200;
                        break;

                    case "25":
                        countOpt++;
                        trackInv.Location = new Point(x, y);
                        trackInv.Show();
                        x += 200;
                        break;
                    case "26":
                        countOpt++;
                        opt_po_status_inquiry.Location = new Point(x, y);
                        opt_po_status_inquiry.Show();
                        x += 250;
                        break;
                    case "28":
                        countOpt++;
                        opt_matprice_search.Location = new Point(x, y);
                        opt_matprice_search.Show();
                        x += 200;
                        break;

                }
            }
        }
        public void OtherPermis()
        {
            int x = 25;
            int y = 150;
            int countOpt = 0;
            for (int i = 0; i < Permis.Length; i++)
            {

                if (countOpt + 1 >= 1 && countOpt + 1 <= 4)
                {
                    y = 150;
                }
                if (countOpt + 1 >= 5 && countOpt + 1 <= 8)
                {
                    if (countOpt == 4)
                    {
                        x = 25;
                    }
                    y = 200;
                }
                if (countOpt + 1 >= 9 && countOpt + 1 <= 12)
                {
                    x = 25;
                    y = 250;
                }
                switch (Permis[i])
                {
                    case "10":
                        countOpt++;
                        asError.Location = new Point(x, y);
                        asError.Show();
                        x += 200;
                        break;
                    case "11":
                        countOpt++;
                        stError.Location = new Point(x, y);
                        stError.Show();
                        x += 200;
                        break;
                    case "12":
                        countOpt++;
                        MatSearch.Location = new Point(x, y);
                        MatSearch.Show();
                        x += 200;
                        break;

                    case "14":
                        countOpt++;
                        blkMat.Location = new Point(x, y);
                        blkMat.Show();
                        x += 200;
                        break;

                    case "18":
                        countOpt++;
                        dsorderdata.Location = new Point(x, y);
                        dsorderdata.Show();
                        x += 200;
                        break;
                    //It is for RS_PMAT[KKH]
                    case "27":
                        countOpt++;
                        opt_bwlst_mlm_id.Location = new Point(x, y);
                        opt_bwlst_mlm_id.Show();
                        x += 200;
                        break;
                        //It is for BW_List_MLM_ID[KKH]



                }
            }
        }
        public void QIPPmis()
        {
            int x = 25;
            int y = 150;
            int countOpt = 0;
            for (int i = 0; i < Permis.Length; i++)
            {

                if (countOpt + 1 >= 1 && countOpt + 1 <= 4)
                {
                    y = 150;
                }
                if (countOpt + 1 >= 5 && countOpt + 1 <= 8)
                {
                    if (countOpt == 4)
                    {
                        x = 25;
                    }
                    y = 200;
                }
                if (countOpt + 1 >= 9 && countOpt + 1 <= 12)
                {
                    x = 25;
                    y = 250;
                }
                switch (Permis[i])
                {
                    
                    case "13":
                        countOpt++;
                        dr_odr_line_chk.Location = new Point(x, y);
                        dr_odr_line_chk.Show();
                        x += 200;
                        break;

                }
            }
        }
        public void WHPmis()
        {
            int x = 25;
            int y = 150;
            int countOpt = 0;
            for (int i = 0; i < Permis.Length; i++)
            {

                if (countOpt + 1 >= 1 && countOpt + 1 <= 4)
                {
                    y = 150;
                }
                if (countOpt + 1 >= 5 && countOpt + 1 <= 8)
                {
                    if (countOpt == 4)
                    {
                        x = 25;
                    }
                    y = 200;
                }
                if (countOpt + 1 >= 9 && countOpt + 1 <= 12)
                {
                    x = 25;
                    y = 250;
                }
                switch (Permis[i])
                {

                    case "21":
                        countOpt++;
                        sno.Location = new Point(x, y);
                        sno.Show();
                        x += 200;
                        break;

                    case "23":
                        countOpt++;
                        jjtrack.Location = new Point(x, y);
                        jjtrack.Show();
                        x += 200;
                        break;



                }
            }
        }

        private void DataGen_Click(object sender, EventArgs e)
        {
            GetRadioOption();
             
        }


        private void Work_Done(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Complete");
        }
        private Boolean DateErroChkMonth()
        {

            if (dateTimePicker1 == null || dateTimePicker2 == null)
            {
                MessageBox.Show("Please input date range!");
                return true;
            }

            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;
            if (ts.Days == 0)
            {
                return false;
            }
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("'From' date must be less than 'To' date");
                return true;
            }
            if (TimeDifference() > 93)
            {
                MessageBox.Show("Query allow only 3 months range");
                return true;
            }
            return false;
        }

        private Boolean DateErroChk()
        {

            if (dateTimePicker1 == null || dateTimePicker2 == null)
            {
                MessageBox.Show("Please input date range!");
                return true;
            }

            TimeSpan ts = dateTimePicker2.Value - dateTimePicker1.Value;
            if (ts.Days == 0)
            {
                return false;
            }
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("'From' date must be less than 'To' date");
                return true;
            }
            return false;
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
        private void GenerateData()
        {

            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";

            string pathDesit = System.IO.Path.Combine(rootDir, "destination.xlsx");
            var workbookClr = new XLWorkbook(pathDesit);
            var clrSheet = workbookClr.Worksheet(1);
            workbookClr.SaveAs(rootDir + "destination.xlsx");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //
            var blankData = clrSheet.Cell(1, 1).Value;

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
                    workbookClr.SaveAs(saveFileDialog.FileName);
                    workbookClr.SaveAs(rootDir + "destination.xlsx");
                    MessageBox.Show("File Sucessfully Saved!");
                }
            }
            workbookClr.Dispose();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        // the fiunction is to get hte Radio button value.
        private void GetRadioOption()
        {

            DateTime selectedDate1 = dateTimePicker1.Value;
            DateTime selectedDate2 = dateTimePicker2.Value;
            Boolean bth = false;
            String rValue = "";
            String txtValue = "";
            if (piCheck.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    //show dialog and close from it
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "PiCheck.txt";
                    Vform.DataQueriesProperties(QForm);
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                    //formShow.PreviewDataList(Qform);
                }
            }
            else if (cartoonWeight.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "cartoonWeight.txt";
                    Vform.DataQueriesProperties(QForm);
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }
            }
            if (micByAcc.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    //show dialog and close from it
                    micWithAcc Vform = new micWithAcc();
                    Vform.DataQueriesProperties(QForm);
                    Vform.SubFormToShow(abrirFormEnPanel);
                    abrirFormEnPanel(Vform);

                }
            }
            else if (odrCancel.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "OrderCancel.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }
            }
            else if (odrAndQtyChange.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "odrAndChang.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }
            }
            else if (stError.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "StErrorLine.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    Vform.ScanErrorAnalyze(rValue);
                    abrirFormEnPanel(Vform);
                }
            }
            else if (asError.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "AsErrorLine.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    Vform.ScanErrorAnalyze(rValue);
                    abrirFormEnPanel(Vform);
                }
            }
            else if (cargoList.Checked == true)
            {
                if (purTypeOS.Checked == false && purTypeTW.Checked == false)
                {
                    MessageBox.Show("Please check Purchase type!");
                }
                else
                {
                    if (purTypeOS.Checked == true)
                    {
                        if (dateCheck.Checked || valueCheck.Checked)
                        {
                            if (DateErroChkMonth() == false)
                            {
                                if (dateCheck.Checked == true)
                                {
                                    rValue = "CargoList.txt";
                                }
                                if (valueCheck.Checked == true)
                                {
                                    rValue = "CargoListID.txt";
                                    txtValue = text.Text;
                                }
                                if (valueCheck.Checked == true && dateCheck.Checked == true)
                                {
                                    rValue = "CargoListIDD.txt";
                                    bth = true;
                                    txtValue = text.Text;
                                }
                                PreviewDataList Vform = new PreviewDataList();
                                Vform.SubFormToShow(abrirFormEnPanel);
                                Vform.DataQueriesProperties(QForm);
                                Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                                abrirFormEnPanel(Vform);
                                text.Text = "";
                            }

                        }
                        else
                        {
                            MessageBox.Show("Please check query type!");
                        }
                    }
                    if (purTypeTW.Checked == true)
                    {
                        if (dateCheck.Checked || valueCheck.Checked)
                        {
                            if (DateErroChkMonth() == false)
                            {
                                if (dateCheck.Checked == true)
                                {
                                    rValue = "CargoListTW.txt";
                                }
                                if (valueCheck.Checked == true)
                                {
                                    rValue = "CargoListIDTW.txt";
                                    txtValue = text.Text;
                                }
                                if (valueCheck.Checked == true && dateCheck.Checked == true)
                                {
                                    rValue = "CargoListIDDTW.txt";
                                    bth = true;
                                    txtValue = text.Text;
                                }
                                PreviewDataList Vform = new PreviewDataList();
                                Vform.SubFormToShow(abrirFormEnPanel);
                                Vform.DataQueriesProperties(QForm);
                                Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                                abrirFormEnPanel(Vform);
                                text.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please check query type!");
                        }
                    }

                }
            }
            else if (SMTT.Checked == true)
            {
                SMTT Vform = new SMTT();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (EDI.Checked == true)
            {
                EDI_Data_Export Vform = new EDI_Data_Export();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (pListINV.Checked == true)
            {
                pListbyINV Vform = new pListbyINV();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (EMCExport.Checked == true)
            {
                EMC Vform = new EMC();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (OdrConsum.Checked == true)
            {
                bth = false;
                OderEntry Vform = new OderEntry();
                Vform.setQueryType("OrderConsu.txt");
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }
            else if (matWeight.Checked == true)
            {
                bth = false;
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "matWeight.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(new PreviewDataList());
                    abrirFormEnPanel(Vform);
                }
            }
            else if (LikChk.Checked == true)
            {

                LikChk Vform = new LikChk();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }
            else if (MatSearch.Checked == true)
            {
                MatSearch Vform = new MatSearch();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }


            else if (dr_odr_line_chk.Checked == true)
            {
                PreviewDataList Vform = new PreviewDataList();
                rValue = "DRData.txt";
                txtValue = matText.Text;
                Vform.SubFormToShow(abrirFormEnPanel);
                Vform.DataQueriesProperties(QForm);
                Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                abrirFormEnPanel(new PreviewDataList());
                abrirFormEnPanel(Vform);

            }

            else if (DB1.Checked == true)
            {
                Dispatch Vform = new Dispatch();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }
            else if (blkMat.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "BlkMat.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }


            }

            else if (dsorderdata.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "Orders Data_DispatchAndShipOut.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }


            }
            else if (sno.Checked == true)
            {
                rpmtrack Vform = new rpmtrack();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }
            else if (jjtrack.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "jjchk.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(Vform);
                }
            }
            else if (trackInv.Checked == true)
            {
                if (DateErroChkMonth() == false)
                {
                    PreviewDataList Vform = new PreviewDataList();
                    rValue = "trackInv.txt";
                    Vform.SubFormToShow(abrirFormEnPanel);
                    Vform.DataQueriesProperties(QForm);
                    Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                    abrirFormEnPanel(new PreviewDataList());
                    abrirFormEnPanel(Vform);
                }
            }
            else if (zaochk.Checked == true)
            {

                zaotrack Vform = new zaotrack();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }
            else if (opt_po_status_inquiry.Checked == true)
            {

                POstatus_inquiry Vform = new POstatus_inquiry();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);
            }
            else if (opt_bwlst_mlm_id.Checked == true)
            {

                PreviewDataList Vform = new PreviewDataList();
                rValue = "BandWList_MLMID.txt";
                Vform.SubFormToShow(abrirFormEnPanel);
                Vform.DataQueriesProperties(QForm);
                Vform.QueryExport(rValue, selectedDate1, selectedDate2, txtValue, bth);
                abrirFormEnPanel(new PreviewDataList());
                abrirFormEnPanel(Vform);

            }
            else if (opt_matprice_search.Checked == true)
            {
                MatPriceSearch Vform = new MatPriceSearch();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else if (purf13.Checked == true)
            {
                purf13 Vform = new purf13();
                Vform.DataQueriesProperties(QForm);
                Vform.SubFormToShow(abrirFormEnPanel);
                abrirFormEnPanel(Vform);

            }
            else
            {
                bth = false;
                MessageBox.Show("Please select the option to generate !!");
            }
            }
            private void OrderEntry()
        {
            FormMenuPrincipal subWindow = new FormMenuPrincipal();
            subWindow.AbrirFormEnPanel(new OderEntry());
        }         
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (purTypeTW.Checked)
            {
                dateCheck.Enabled = true;
                valueCheck.Enabled = true;
                purTypeOS.Checked = false;
            }
            else
            {
                dateCheck.Enabled = false;
                valueCheck.Enabled = false;
                dateCheck.Checked = false;
                valueCheck.Checked = false;
            }
        }

        private void purTypeOS_Click(object sender, EventArgs e)
        {
            if (purTypeOS.Checked)
            {
                dateCheck.Enabled = true;
                valueCheck.Enabled = true;
                purTypeTW.Checked = false;
            }
            else
            {
                dateCheck.Enabled = false;
                valueCheck.Enabled = false;
                dateCheck.Checked = false;
                valueCheck.Checked = false;
            }
        }

            

        private void PosCos()
        {
            DataGen.Top = 10;
            LikChk.Top = 100;
            DataGen.Text = "Continue";
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            label1.Hide();
            label2.Hide();

        }

        private void MoveTop()
        {
            DataGen.Top = 10;
            LikChk.Top = 100;
        }
        private void MoveNor()
        {
            DataGen.Top = 60;
            odrCancel.Top = 150;
            odrAndQtyChange.Top = 150;
            LikChk.Top = 200;
            OdrConsum.Top = 200;
            piCheck.Top = 250;
            cargoList.Top = 300;
            cartoonWeight.Top = 300;
            matWeight.Top = 300;
            stError.Top = 350;
            asError.Top = 350;



        }

        private void disPatchMat_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            matText.Hide();
            MatLable.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void disPatchMat_CheckedChanged(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Show();
            MatLable.Show();
        } 
        private void odrCancel_Click_1(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            DataGen.Text = "Generate";
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void dsorderdata_Click_1(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            DataGen.Text = "Generate";
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void odrAndQtyChange_Click_1(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            DataGen.Text = "Generate";
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void LikChk_Click_1(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Hide();
            MatLable.Hide();
        }

        private void OdrConsum_Click_1(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            valueCheck.Hide();
            dateCheck.Hide();

        }

        private void piCheck_Click_1(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            DataGen.Text = "Generate";
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void SMTT_Click_2(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Hide();
            MatLable.Hide();
        }
        private void EDI_Click_1(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Hide();
            MatLable.Hide();
        }

        private void matWeight_Click_1(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            label1.Hide();
            label2.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void dr_odr_line_chk_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Hide();
            MatLable.Hide();
        }

        private void MatSearch_Click_1(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            MatLable.Show();
            matText.Show();
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void EDI_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Hide();
            MatLable.Hide();
            label1.Hide();
            label2.Hide();
        }

        private void EMCExport_CheckedChanged(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Hide();
            MatLable.Hide();
        }

        private void DB1_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            matText.Hide();
            MatLable.Hide();
        }
        private void dsorderdata_Click1(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            DataGen.Text = "Generate";
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }




        private void pListINV_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            label1.Hide();
            label2.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            purTypeOS.Hide();
            purTypeTW.Hide();
        }

        private void cartoonWeight_Click(object sender, EventArgs e)
        {
            label1.Show();
            label2.Show();
            DataGen.Text = "Generate";
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            purTypeTW.Hide();
            purTypeOS.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void purTypeOS_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (purTypeOS.Checked)
                {
                    dateCheck.Enabled = true;
                    valueCheck.Enabled = true;
                    purTypeTW.Checked = false;
                }
                else
                {
                    dateCheck.Enabled = false;
                    valueCheck.Enabled = false;
                    dateCheck.Checked = false;
                    valueCheck.Checked = false;
                }
            }
        }

        private void cargoList_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            valueCheck.Enabled = false;
            dateCheck.Enabled = false;
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            purTypeOS.Show();
            purTypeTW.Show();
            // dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            text.Enabled = false;
            dateCheck.Checked = false;
            valueCheck.Checked = false;
            purTypeOS.Checked = false;
            purTypeTW.Checked = false;
            text.Text = "";
            text.Show();
            txtLabel.Text = "Custom ID";
            txtLabel.Show();
            valueCheck.Show();
            dateCheck.Show();
        }

        private void purTypeTW_Click(object sender, EventArgs e)
        {
            if (purTypeTW.Checked)
            {
                dateCheck.Enabled = true;
                valueCheck.Enabled = true;
                purTypeOS.Checked = false;
            }
            else
            {
                dateCheck.Enabled = false;
                valueCheck.Enabled = false;
                dateCheck.Checked = false;
                valueCheck.Checked = false;
            }
        }

        private void dateCheck_Click_1(object sender, EventArgs e)
        {
            {
                if (dateCheck.Checked)
                {
                    dateTimePicker1.Enabled = true;
                    dateTimePicker2.Enabled = true;
                }
                else
                {
                    dateTimePicker1.Enabled = false;
                    dateTimePicker2.Enabled = false;
                }
            }
        }

        private void valueCheck_Click_1(object sender, EventArgs e)
        {
            if (valueCheck.Checked)
            {
                text.Enabled = true;
            }
            else
            {
                text.Enabled = false;
            }
        }

        private void matWeight_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            label1.Hide();
            label2.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            purTypeOS.Hide();
            purTypeTW.Hide();
        }

        private void micByAcc_Click(object sender, EventArgs e)
        {
            purTypeOS.Hide();
            purTypeTW.Hide();
            DataGen.Text = "Continue";
            MatLable.Hide();
            matText.Hide();
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void MatSearch_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            MatLable.Show();
            matText.Show();
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            MatLable.Hide();
            matText.Hide();
        }

     
        private void SMTT_CheckedChanged(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
        }

        private void piCheck_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            label1.Show();
            label2.Show();
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
     
        }

        private void odrCancel_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            ShowDateTimePicker();
            label1.Show();
            label2.Show();
        }

        private void ShowDateTimePicker()
        {
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
        }

        private void odrAndQtyChange_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
            label1.Show();
            label2.Show();
        }

        private void OdrConsum_Click(object sender, EventArgs e)
        {
            ShowDateTimePicker();
        }

        private void EMCExport_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label1.Hide();
            label2.Hide();
        }

        private void DB1_Click_1(object sender, EventArgs e)
        {

        }

        private void LikChk_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label1.Hide();
            label2.Hide();
        }

        private void sno_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            MatLable.Show();
            matText.Show();
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            MatLable.Hide();
            matText.Hide();
        }

        private void dr_odr_line_chk_Click_1(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label1.Hide();
            label2.Hide();
        }

        private void asError_Click(object sender, EventArgs e)
        {
            MatLable.Hide();
            matText.Hide();
            DataGen.Text = "Generate";
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void stError_Click(object sender, EventArgs e)
        {
            MatLable.Hide();
            matText.Hide();
            DataGen.Text = "Generate";
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
        }

        private void blkMat_Click_1(object sender, EventArgs e)
        {
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            label1.Show();
            label2.Show();
        }

        private void dsorderdata_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            label1.Show();
            label2.Show();
        }

        private void opt_RS_purd_and_mat_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            MatLable.Show();
            matText.Show();
            label1.Show();
            label2.Show();
            dateTimePicker1.Show();
            dateTimePicker2.Show();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            MatLable.Hide();
            matText.Hide();
        }

        private void zaochk_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            MatLable.Show();
            matText.Show();
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Hide();
            dateTimePicker2.Hide();
            text.Hide();
            txtLabel.Hide();
            valueCheck.Hide();
            dateCheck.Hide();
            MatLable.Hide();
            matText.Hide();
        }

        private void trackInv_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            label1.Show();
            label2.Show();
            dateTimePicker1.Visible = true;
            dateTimePicker2.Visible = true;
        }

        private void opt_po_status_inquiry_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
        }

        private void opt_bwlst_mlm_id_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
        }

        private void opt_matprice_search_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Generate";
            label1.Hide();
            label2.Hide();
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
        }

        private void purf13_Click(object sender, EventArgs e)
        {
            DataGen.Text = "Continue";
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label1.Hide();
            label2.Hide();
        }
    }
}
