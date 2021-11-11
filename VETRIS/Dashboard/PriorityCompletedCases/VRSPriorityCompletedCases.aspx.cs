using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETRIS.Core;
using VETRIS.Core.Dashboard;
using VETRIS.Core.Radiologist;

namespace VETRIS.Dashboard.PriorityCompletedCases
{
    [AjaxPro.AjaxNamespace("VRSPriorityCompletedCases")]
    public partial class VRSPriorityCompletedCases : System.Web.UI.Page
    {
        #region Members & Variables
        VETRIS.Core.Dashboard.Dashboard objCore = null;
        classes.CommonClass objComm;
        int dashboardId = 0;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(VRSPriorityCompletedCases));
            SetPageValue();
            SetAttributes();
        }
        #region SetAttributes
        private void SetAttributes()
        {
            btnExcel.Attributes.Add("onclick", "javascript:btnExcel_OnClick();");
        }
        #endregion

        #region SetPageValue
        private void SetPageValue()
        {
            hdnRefreshTime.Value = Request.QueryString["sec"];
            hdnIsRefreshBtn.Value = Request.QueryString["isrefresh"];
            hdnDesc.Value = Request.QueryString["desc"];
            hdnreportTitle.Value = Request.QueryString["rt"];
            string strTheme = Request.QueryString["th"];
            hdnTheme.Value = strTheme;
            SetCSS(strTheme);
            GetModality();
        }
        #endregion

        #region SetCSS
        private void SetCSS(string strTheme)
        {
            string strServerPath = ConfigurationManager.AppSettings["ServerPath"];
            lnkSTYLE.Attributes["href"] = strServerPath + "/css/" + strTheme + "/style.css";
            //lnkTHEME.Attributes["href"] = strServerPath + "/css/" + strTheme + "/theme.css";
            dashboardSTYLE.Attributes["href"] = strServerPath + "/css/" + strTheme + "/dashboard.css";
            dashboardLightbox.Attributes["href"] = strServerPath + "/css/" + strTheme + "/lightbox.css";
        }
        #endregion

        #region GetModality (AjaxPro Method)
        [AjaxPro.AjaxMethod()]
        public void GetModality()
        {
            objCore = new Core.Dashboard.Dashboard();
            string strCatchMessage = "";
            bool bReturn = false;
            DataSet ds = new DataSet();

            try
            {
                bReturn = objCore.FetchModality(Server.MapPath("~"), ref ds, ref strCatchMessage);
                if (bReturn)
                {
                    #region Modality
                    DataRow dr1 = ds.Tables["Modality"].NewRow();
                    dr1["id"] = 0;
                    dr1["name"] = "All";
                    ds.Tables["Modality"].Rows.InsertAt(dr1, 0);
                    ds.Tables["Modality"].AcceptChanges();

                    ddlModality.DataSource = ds.Tables["Modality"];
                    ddlModality.DataValueField = "id";
                    ddlModality.DataTextField = "name";
                    ddlModality.DataBind();
                    #endregion
                }

            }
            catch (Exception ex)
            {

            }

        } 
        #endregion


        #region SearchRecord  (AjaxPro Method)
        [AjaxPro.AjaxMethod()]
        public DataSet SearchRecord(string[] arrRecord)
        {
            objCore = new Core.Dashboard.Dashboard();
            string strCatchMessage = ""; bool bReturn = false;
            DataSet ds = new DataSet();
            string strUserRole = string.Empty;
            objComm = new classes.CommonClass();
            LineData data = null;
            try
            {
                objComm.SetRegionalFormat();
                objCore.FROM_DATE = Convert.ToDateTime(arrRecord[0]);
                //objCore.TO_DATE = Convert.ToDateTime(arrRecord[1]);
                objCore.MODALITY_ID = Convert.ToInt32(arrRecord[1]);

                bReturn = objCore.SearchPriorityCompletedCases(Server.MapPath("~"), ref ds, ref strCatchMessage);

                if (bReturn)
                {
                    return ds;
                    //grdBrw.DataSource = ds.Tables["PriorityCompletedCases"];
                    //grdBrw.DataBind();
                    //spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"\" />";
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                ds.Dispose();
                objCore = null;
            }
            return ds;
        }
        #endregion

        #region PriorityCompletedCasesList (AjaxPro Method)
        [AjaxPro.AjaxMethod()]
        public PriorityCompletedCasesList GetPriorityCompletedCases(string[] args)
        {
            objCore = new Core.Dashboard.Dashboard();
            string strCatchMessage = "";
            bool bReturn = false;
            DataSet ds = new DataSet();
            PriorityCompletedCasesList data = new PriorityCompletedCasesList();
            List<DashboardData> list = new List<DashboardData>();
            try
            {
                objCore.FROM_DATE = Convert.ToDateTime(args[0]);
                objCore.MODALITY_ID = Convert.ToInt32(args[1]);
                bReturn = objCore.FetchPriorityCompletedCases(Server.MapPath("~"), ref ds, ref strCatchMessage);
                if (bReturn)
                {
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow r in ds.Tables["today"].Rows)
                        {
                            var d = new DashboardData();
                            d.name = r["short_desc"].ToString();
                            d.value = Convert.ToInt32(r["total"].ToString());
                            list.Add(d);
                        }
                        data.today = list;

                        list = new List<DashboardData>();
                        foreach (DataRow r in ds.Tables["yesterday"].Rows)
                        {
                            var d = new DashboardData();
                            d.name = r["short_desc"].ToString();
                            d.value = Convert.ToInt32(r["total"].ToString());
                            list.Add(d);
                        }
                        data.yesterday = list;

                        list = new List<DashboardData>();
                        foreach (DataRow r in ds.Tables["lastsevendays"].Rows)
                        {
                            var d = new DashboardData();
                            d.name = r["short_desc"].ToString();
                            d.value = Convert.ToInt32(r["total"].ToString());
                            list.Add(d);
                        }
                        data.last_seven_days = list;

                        list = new List<DashboardData>();
                        foreach (DataRow r in ds.Tables["lastfifteendays"].Rows)
                        {
                            var d = new DashboardData();
                            d.name = r["short_desc"].ToString();
                            d.value = Convert.ToInt32(r["total"].ToString());
                            list.Add(d);
                        }
                        data.last_fifteen_days = list;

                        list = new List<DashboardData>();
                        foreach (DataRow r in ds.Tables["lastthirtydays"].Rows)
                        {
                            var d = new DashboardData();
                            d.name = r["short_desc"].ToString();
                            d.value = Convert.ToInt32(r["total"].ToString());
                            list.Add(d);
                        }
                        data.last_thirty_days = list;

                        list = new List<DashboardData>();
                        foreach (DataRow r in ds.Tables["mtd"].Rows)
                        {
                            var d = new DashboardData();
                            d.name = r["short_desc"].ToString();
                            d.value = Convert.ToInt32(r["total"].ToString());
                            list.Add(d);
                        }
                        data.mtd = list;
                    }
                }

                return data;
            }
            catch (Exception ex)
            {

            }
            return data;
        }
        #endregion

        #region GenerateExcel(Ajaxpro Method)
        [AjaxPro.AjaxMethod()]
        public string[] GenerateExcel(string[] arrParams)
        {
            objCore = new Core.Dashboard.Dashboard();
            string[] arrRet = new string[0];
            string strCatchMessage = ""; bool bReturn = false;
            DataSet ds = new DataSet();
            string strRptFile = string.Empty;
            string strUserRole = string.Empty;


            try
            {
                objCore.MODALITY_ID = Convert.ToInt32(arrParams[0]);
                objCore.FROM_DATE = Convert.ToDateTime(arrParams[1]);
                bReturn = objCore.SearchPriorityCompletedCases(Server.MapPath("~"), ref ds, ref strCatchMessage);

                if (bReturn)
                {

                    strRptFile = CreateReportExcel(ds, objCore, arrParams[2].Trim(), ref strCatchMessage);
                    if (strCatchMessage.Trim() == string.Empty)
                    {
                        arrRet = new string[4];
                        arrRet[0] = "true";
                        arrRet[1] = "Dashboard/Temp/" + arrParams[2].Trim() + "/" + strRptFile;
                        arrRet[2] = Server.MapPath("Dashboard/Temp/" + arrParams[2].Trim() + "/" + strRptFile).Replace("ajaxpro\\", "");
                        arrRet[3] = "XLS";
                    }
                    else
                    {
                        arrRet = new string[2];
                        arrRet[0] = "catch";
                        arrRet[1] = strCatchMessage;
                    }
                }
                else
                {
                    arrRet = new string[2];
                    arrRet[0] = "false";
                    arrRet[1] = strCatchMessage;
                    //spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"" + strCatchMessage + "\" />";
                }

            }
            catch (Exception ex)
            {
                arrRet = new string[2];
                arrRet[0] = "catch";
                arrRet[1] = ex.Message.Trim();
                //spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"" + ex.Message.Trim() + "\" />";
            }
            finally
            {
                ds.Dispose();
                objCore = null;
            }
            return arrRet;
        }
        #endregion

        #region CreateReportExcel
        public string CreateReportExcel(DataSet ds, Core.Dashboard.Dashboard core, string strUserID,  ref string CatchMessage)
        {
            string strReportName = string.Empty;
            bool bReturn = false;
            SetLicenseKey();
            ExcelFile objExcelFile = null; string strRowfiltertring = string.Empty;
            ExcelWorksheet sheet = null;
            //ExcelWorksheet objExcelWorksheet2 = null;
            string strRName = "PriorityCompletedCases_" + string.Format("{0:yyyy_MM_dd_HH_mm_ss}", DateTime.Now) + ".xlsx";

            try
            {

                if (!System.IO.Directory.Exists(Server.MapPath("~") + "/Dashboard/Temp/" + strUserID)) { System.IO.Directory.CreateDirectory(Server.MapPath("~") + "/Dashboard/Temp/" + strUserID); }
                strReportName = Server.MapPath("~") + "/Dashboard/Temp/" + strUserID + "/" + strRName;
                strReportName = strReportName.Replace("ajaxpro\\", "");
                if (System.IO.File.Exists(strReportName) == true) { System.IO.File.Delete(strReportName); }

                objExcelFile = new ExcelFile();
                sheet = objExcelFile.Worksheets.Add("Priority Completed Cases");

                int intRowIndex = 0;


                #region Details
                DataTable tbl = null;

                tbl = ds.Tables["PriorityCompletedCases"];
                var data = tbl.TableToList<VETRIS.Core.Dashboard.PriorityCases>();

                #endregion

                CreateHeader(ref intRowIndex, sheet);
                foreach (var item in data)
                {
                    CreateBodyRow(ref intRowIndex, item, sheet);
                }
                sheet.Columns[0].AutoFit();
                sheet.Columns[1].AutoFit();
                sheet.Columns[2].AutoFit();
                sheet.Columns[3].AutoFit();
                sheet.Columns[4].AutoFit();

                var printOptions = sheet.PrintOptions;
                printOptions.Portrait = false;
                printOptions.LeftMargin = 0.50;
                printOptions.RightMargin = 0.3;
                printOptions.TopMargin = 0.3;
                printOptions.BottomMargin = 0.3;
                printOptions.PaperSize = 9;
                printOptions.AutomaticPageBreakScalingFactor = 80;

                objExcelFile.SaveXlsx(strReportName);
                strReportName = strRName;
            }
            catch (Exception expErr)
            {
                strReportName = "";
                CatchMessage = expErr.Message;
            }
            finally
            {
                if (objExcelFile != null) objExcelFile = null;
                if (sheet != null) sheet = null;
                //ds.Dispose();

            }
            return strReportName;
        }
        #endregion

        #region CreateHeader
        void CreateHeader(ref int row, ExcelWorksheet sheet)
        {
            var style = new CellStyle();
            style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            style.VerticalAlignment = VerticalAlignmentStyle.Center;
            style.Font.Weight = ExcelFont.BoldWeight;
            style.Borders.SetBorders(MultipleBorders.Bottom, Color.Gray, LineStyle.Thin);

            sheet.Cells.GetSubrange("A1", "E1").Style = style;

            //sheet.Cells[row, 0].Value = "Sl. No.";
            sheet.Cells[row, 0].Value = "PERIOD";
            sheet.Cells[row, 1].Value = "NORMAL";
            sheet.Cells[row, 2].Value = "1 HOUR STAT ";
            sheet.Cells[row, 3].Value = "2-4 HOUR STAT";
            sheet.Cells[row, 4].Value = "TOTAL";

            row++;
        }
        #endregion

        #region CreateBodyRow
        void CreateBodyRow(ref int row, VETRIS.Core.Dashboard.PriorityCases data, ExcelWorksheet sheet)
        {
            var style = new CellStyle();
            objComm = new classes.CommonClass();
            objComm.SetRegionalFormat();
            style.HorizontalAlignment = HorizontalAlignmentStyle.Left;
            style.VerticalAlignment = VerticalAlignmentStyle.Center;
            style.Borders.SetBorders(MultipleBorders.Bottom, Color.Gray, LineStyle.Thin);
            style.Borders.SetBorders(MultipleBorders.Top, Color.Gray, LineStyle.Thin);
            sheet.Cells.GetSubrange("A" + (row + 1).ToString(), "E" + (row + 1).ToString()).Style = style;

            sheet.Cells[row, 0].Value = data.days_name; //objComm.IMDateFormat(data.Received_Date, objComm.DateFormat);
            sheet.Cells[row, 1].Value = data.normal;
            sheet.Cells[row, 1].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
            sheet.Cells[row, 2].Value = data.one_hr_stat;
            sheet.Cells[row, 2].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
            sheet.Cells[row, 3].Value = data.two_four_hr_stat;
            sheet.Cells[row, 3].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
            sheet.Cells[row, 4].Value = data.normal + data.one_hr_stat + data.two_four_hr_stat;
            sheet.Cells[row, 4].Style.HorizontalAlignment = HorizontalAlignmentStyle.Right;
            row++;
            objComm = null;
        }


        #endregion

        #region SetLicenseKey
        private void SetLicenseKey()
        {
            try
            {
                VETRIS.Core.CoreCommon.GetReportLicenseKey(Server.MapPath("~"));
                SpreadsheetInfo.SetLicense(CoreCommon.REPORT_LICENSE_KEY);

            }
            catch (Exception expErr)
            {
                Response.Write(expErr.Message);
            }
        }
        #endregion
    }
}