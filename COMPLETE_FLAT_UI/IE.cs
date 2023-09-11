using COMPLETE_FLAT_UI;
using System;
using System.Windows.Forms;
using Npgsql;
using System.Data;
using NpgsqlTypes;
using System.Collections.Generic;
using System.Collections;
using ClosedXML.Excel;
using System.Threading;

namespace QUERY_TOOL
{
    public partial class IE : Form
    {
        public IE()
        {
            InitializeComponent();
        }
        string conString = "Server=172.23.86.145;Port=5432;User Id=postgres;Password=12345;Database=IE_DB";
        Action<object> abrirFormEnPanel;
        Label[] lbllist;
        TextBox[] tblist;
        String operationSql = "";
        DataTable currTable = new DataTable();
        DataQueries QForm;
        DataGridViewRow dgvr;
        DataTable Cbodt = new DataTable();
        internal void SubFormToShow(Action<object> abrirFormEnPanel)
        {
            this.abrirFormEnPanel = abrirFormEnPanel;
        }
        internal void DataQueriesProperties(DataQueries QForm)
        {
            this.QForm = QForm;
        }
        void lblShow()
        {
            int i = 0;
            Label[] showLbl = { label1, label2, label3, label4, label5, label6, label7, label8, label9 };
            TextBox[] showTb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };
            lbllist = showLbl;
            tblist = showTb;
            foreach (DataColumn column in currTable.Columns)
            {
                showLbl[i].Text = column.ColumnName;
                showLbl[i].Show();
                showTb[i].Show();
                i++;
            }
        }
        void lblHide()
        {
            Label[] showLbl = { label1, label2, label3, label4, label5, label6, label7, label8, label9};
            TextBox[] showTb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9};
            for (int i = 0; i <showLbl.Length;i++)
            {
                showLbl[i].Hide();
                showTb[i].Hide();
            }
        }
        void hidbtn()
        {
            save.Hide();
            btnCancelar.Hide();
        }
        void showbtn()
        {
            save.Show();
            btnCancelar.Show();
        }
        void disBtn()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            comboBox1.Enabled = true;
        }
        void enBtn()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            comboBox1.Enabled = false;
        }
        void txtClr()
        {
            TextBox[] showTb = { textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };
            for (int i = 0; i < showTb.Length; i++)
            {
                showTb[i].Clear();
            }

        }
        void loadCobo()
        {
            lblHide();
            DataTable dt = new DataTable();
            NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
            string strpostgracecommand = "Select ROW_NUMBER () OVER (ORDER BY relname) rowno,t1.des,t1.relname from (SELECT obj_description(oid) DES, *FROM pg_class where obj_description(oid) IS NOT NULL) t1";
            NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
            DA.SelectCommand = new NpgsqlCommand(strpostgracecommand, connection);
            DA.Fill(dt);
            
            comboBox1.ValueMember = "rowno";
            comboBox1.DisplayMember = "relname";
            DataRow topItem = dt.NewRow();
            topItem[0] = 0;
            topItem[1] = "-Select Table-";
            topItem[2] = "-Select Table-";
            dt.Rows.InsertAt(topItem, 0);
            comboBox1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (operationSql.Equals("insert"))
                {
                        insertRow();
                        dataQuery();

                }
                else
                {
                        updateRow();
                        dataQuery();
                }
                lblHide();
                disBtn();
                hidbtn();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void insertRow()
        {
            int dataCount = 0;
            String columnanme = "";
            String valuename = "";
            NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
            string strpostgracecommand = "INSERT INTO public." + comboBox1.Text + " (";
            foreach (DataColumn column in currTable.Columns)
            {
                if (columnanme.Equals(""))
                {
                    columnanme += columnanme + "\"" + column.ColumnName + "\"";
                }
                else
                {
                    columnanme += ",\"" + column.ColumnName + "\"";
                }
                dataCount++;
            }
            strpostgracecommand = strpostgracecommand + columnanme + ") VALUES(";
            for (int i = 0; i < dataCount; i++)
            {
                if (valuename.Equals(""))
                {
                    valuename += "'" + tblist[i].Text + "'";
                }
                else
                {
                    valuename += ",'" + tblist[i].Text + "'";
                }

            }
            strpostgracecommand += valuename + ");";
            NpgsqlCommand SqlCmd = new NpgsqlCommand(strpostgracecommand, connection);
            int affectCount = SqlCmd.ExecuteNonQuery();
            txtClr();
            MessageBox.Show("Sucessfully Saved ");
        }
        void updateRow()
        {
            int count = 0;
            String columnanme = "";
            String firstCol = "";
            NpgsqlConnection connection = new NpgsqlConnection(conString);
            connection.Open();
            string strpostgracecommand = "UPDATE public." + comboBox1.Text + " SET ";
            foreach (DataColumn column in currTable.Columns)
            {
                if (columnanme.Equals(""))
                {
                    firstCol = column.ColumnName;
                    columnanme += columnanme + "\"" + column.ColumnName + "\"";
                }
                else
                {
                    columnanme += ",\"" + column.ColumnName + "\"";
                }
                columnanme += " = '" + tblist[count].Text + "'";
                count++;
            }
            strpostgracecommand = strpostgracecommand + columnanme + " WHERE " +"\"" + firstCol + "\""  + " = " + "'" + tblist[0].Text + "'";
            NpgsqlCommand SqlCmd = new NpgsqlCommand(strpostgracecommand, connection);
            int affectCount = SqlCmd.ExecuteNonQuery();
            txtClr();
            MessageBox.Show("Sucessfully Saved ");
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if(dataGridView1.CurrentRow != null)
            {
                dgvr = dataGridView1.CurrentRow;
                NpgsqlConnection connection = new NpgsqlConnection(conString);
                NpgsqlCommand SqlCmd = new NpgsqlCommand("call insertdept(:deptid, :deptn, :modid, :isdele)", connection);
               // SqlCmd.Parameters.AddWithValue("deptid", dgvr.Cells["DEPT_ID"].Value);
                SqlCmd.Parameters.AddWithValue("deptid", DbType.String).Value =  dgvr.Cells["DEPT_ID"].Value;
                SqlCmd.Parameters.AddWithValue("deptn", DbType.String).Value = dgvr.Cells["DPT_NAME"].Value;
                SqlCmd.Parameters.AddWithValue("modid", DbType.String).Value = dgvr.Cells["MODIFY_DATE"].Value;
                SqlCmd.Parameters.AddWithValue("isdele", DbType.String).Value = dgvr.Cells["IS_DELETE"].Value;
                SqlCmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                //SqlCmd.Parameters.AddWithValue("$1", dgvr.Cells["DEPT_ID"].Value == DBNull.Value ?"": dgvr.Cells["DEPT_ID"].Value);
                //SqlCmd.Parameters.AddWithValue("$2", dgvr.Cells["DPT_NAME"].Value == DBNull.Value ? "" : dgvr.Cells["DPT_NAME"].Value);
                //SqlCmd.Parameters.AddWithValue("$3", dgvr.Cells["MODIFY_DATE"].Value == DBNull.Value ? "" : dgvr.Cells["MODIFY_DATE"].Value);
                //SqlCmd.Parameters.AddWithValue("$4", dgvr.Cells["IS_DELETE"].Value == DBNull.Value ? "" : dgvr.Cells["IS_DELETE"].Value);
                int affectCount = SqlCmd.ExecuteNonQuery();
            }
        }
        void dataQuery()
        {
            dgvr = null;
            DataTable dt = new DataTable();
            var selectedTable = comboBox1.Text;
            if (!selectedTable.Equals("-Select Table-"))
            {
                NpgsqlConnection connection = new NpgsqlConnection(conString);
                connection.Open();
                string strpostgracecommand = "Select * from \"" + selectedTable + "\"";
                NpgsqlDataAdapter DA = new NpgsqlDataAdapter();
                DA.SelectCommand = new NpgsqlCommand(strpostgracecommand, connection);
                DA.Fill(dt);
                currTable = dt;
                dataGridView1.DataSource = dt;
                loadExport(dt);
                dgvr = dataGridView1.CurrentRow;
                dgvr.Selected = true;
            }
            else
            {
                MessageBox.Show("Please select a table !");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataQuery();
        }

        private void IE_Load(object sender, EventArgs e)
        {
            hidbtn();
            loadCobo();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            operationSql = "insert";
            if (dgvr != null)
            {
                lblHide();
                txtClr();
                enBtn();
                lblHide();
                lblShow();
                showbtn();
            }
            else
            {
                MessageBox.Show("Please query a table first");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            operationSql = "modify";
            enBtn();
            if (dgvr != null)
            {
                dgvr = dgvr = dataGridView1.CurrentRow;
                showbtn();
                lblShow();
                int i = 0;

                foreach (DataColumn column in currTable.Columns)
                {
                    if (dgvr.Cells[column.ColumnName].Value != null)
                    {
                        String colNmae = (String)dgvr.Cells[column.ColumnName].Value;
                        tblist[i].Text = colNmae;
                        i++;
                    }
                }
                lblShow();
            }else

            {
                MessageBox.Show("Please query data first");
                disBtn();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvr = dataGridView1.CurrentRow;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            operationSql = "";
            txtClr();
            disBtn();
            hidbtn();
            lblHide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvr != null)
            {
                dgvr = dgvr = dataGridView1.CurrentRow;
                int i = 0;
                lblShow();
                foreach (DataColumn column in currTable.Columns)
                {
                    if (dgvr.Cells[column.ColumnName].Value != null)
                    {
                        String colNmae = (String)dgvr.Cells[column.ColumnName].Value;
                        tblist[i].Text = colNmae;
                        i++;
                    }
                }
                DialogResult res = MessageBox.Show("Are you sure you want to Delete", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    {
                        NpgsqlConnection connection = new NpgsqlConnection(conString);
                        connection.Open();
                        string strpostgracecommand = "DELETE FROM public." + comboBox1.Text + " WHERE " + "\"" + lbllist[0].Text + "\"" + " = '" + tblist[0].Text + "'";
                        //DELETE FROM table_name WHERE[condition];
                        NpgsqlCommand SqlCmd = new NpgsqlCommand(strpostgracecommand, connection);
                        int affectCount = SqlCmd.ExecuteNonQuery();
                        dataQuery();
                        MessageBox.Show("Sucessfully Deleted ");
                    }


                }
                txtClr();
                disBtn();
                hidbtn();
                lblHide();
            }else
            {
                MessageBox.Show("Please query data first !");
            }
        }
        void loadExport(System.Data.DataTable dt)
        {
            string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
            ClosedXML.Excel.XLWorkbook wbook = new ClosedXML.Excel.XLWorkbook();
            DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                wbook.Worksheets.Add(dt, comboBox1.Text);
            wbook.SaveAs(rootDir + "tempIE.xlsx");
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvr != null)
            {
                string rootDir = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\data\";
                string pathDesit1 = System.IO.Path.Combine(rootDir, "tempIE.xlsx");
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
            }else
            {
                MessageBox.Show("Please Query Data first!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
                    BIRPT Vform = new BIRPT();
                    Vform.SubFormToShow(abrirFormEnPanel);
                    abrirFormEnPanel(Vform);

            }
       }
}
