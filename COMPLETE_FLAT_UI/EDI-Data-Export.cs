using ClosedXML.Excel;
using System;
using System.Linq;
using System.Windows.Forms;

namespace COMPLETE_FLAT_UI
{
    public partial class EDI_Data_Export : Form
    {
        public EDI_Data_Export()
        {
            InitializeComponent();
        }
        String impPath = "";
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
            #region
            if (impPath.Equals(""))
            {
                MessageBox.Show("Please select file.");
            }
            else { 
            String noValue = "";
            String tempvalue = "";
            String rValue = "";
            var browbook = new XLWorkbook(impPath);
            var browSheet = browbook.Worksheet(1);

                #region
                if (impPath.Equals("") || impPath.Equals(".xlsx"))
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
                        rValue = "EDICheck.txt";
                        Vform.SubFormToShow(abrirFormEnPanel);
                        Vform.DataQueriesProperties(QForm);
                        Vform.QueryExport(rValue, new DateTime(), new DateTime(), tempvalue, true);
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
    }
    }

