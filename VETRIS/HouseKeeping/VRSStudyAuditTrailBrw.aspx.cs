﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.IO;
using System.Configuration;
using VETRIS.Core;
using eRADCls;

namespace VETRIS.HouseKeeping
{
    public partial class VRSStudyAuditTrailBrw : System.Web.UI.Page
    {
        #region Members & Variables
        VETRIS.Core.HouseKeeping.StudyAuditTrail objCore = null;
        classes.CommonClass objComm;
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!CallBackBrw.CausedCallback)
                SetPageValue();
            SetAttributes();
        }
        #endregion

        #region SetAttributes
        private void SetAttributes()
        {

            btnRefresh.Attributes.Add("onclick", "javascript:ResetRecord();view_Searchform();");
            btnSearch.Attributes.Add("onclick", "javascript:SearchRecord();view_Searchform();");
            btnClose.Attributes.Add("onclick", "javascript:btnBrwClose_Onclick();");
           
            txtFromDt.Attributes.Add("onblur", "javascript:ValidateDateEntered(this);");
            imgFrom.Attributes.Add("onclick", "javascript:SetSelectedDate('" + txtFromDt.ClientID + "','CalFrom');");
            txtTillDt.Attributes.Add("onblur", "javascript:ValidateDateEntered(this);");
            imgTill.Attributes.Add("onclick", "javascript:SetSelectedDate('" + txtTillDt.ClientID + "','CalTill');");
        }
        #endregion

        #region SetPageValue
        private void SetPageValue()
        {

            int intUserRoleID = Convert.ToInt32(Request.QueryString["urid"]);
            int intMenuID = Convert.ToInt32(Request.QueryString["mid"]);
            Guid UserID = new Guid(Request.QueryString["uid"].ToString());
            string strID = string.Empty;


            objComm = new classes.CommonClass();
            objComm.SetRegionalFormat();
            txtFromDt.Text = objComm.IMDateFormat(DateTime.Today, objComm.DateFormat);
            txtTillDt.Text = objComm.IMDateFormat(DateTime.Today, objComm.DateFormat);
            objComm = null;

            FetchSearchParameters(UserID);
            DeleteUserDirectory(UserID);
            string strTheme = Request.QueryString["th"];
            SetCSS(strTheme);
        }
        #endregion

        #region SetCSS
        private void SetCSS(string strTheme)
        {
            string strServerPath = ConfigurationManager.AppSettings["ServerPath"];
            lnkSTYLE.Attributes["href"] = strServerPath + "/css/" + strTheme + "/style.css";
            lnkGRID.Attributes["href"] = strServerPath + "/css/" + strTheme + "/grid_style.css";
            lnkCAL.Attributes["href"] = strServerPath + "/css/" + strTheme + "/CalendarStyle.css";
        }
        #endregion

        #region DeleteUserDirectory
        private void DeleteUserDirectory(Guid UserID)
        {
            string[] arrTemp = new string[0];

            if (Directory.Exists(Server.MapPath("~/HouseKeeping/Temp/" + UserID.ToString())))
            {
                if (Directory.Exists(Server.MapPath("~/HouseKeeping/Temp/" + UserID.ToString())))
                {
                    arrTemp = Directory.GetFiles(Server.MapPath("~") + "/HouseKeeping/Temp/" + UserID.ToString());
                    if (arrTemp.Length > 0)
                    {
                        for (int i = 0; i < arrTemp.Length; i++)
                        {
                            File.Delete(arrTemp[i]);
                        }
                    }

                }

                Directory.Delete(Server.MapPath("~") + "/HouseKeeping/Temp/" + UserID.ToString());

            }
        }
        #endregion

        #region FetchSearchParameters
        private void FetchSearchParameters(Guid UserID)
        {
            objCore = new Core.HouseKeeping.StudyAuditTrail();
            string strCatchMessage = ""; bool bReturn = false; int intCnt = 0;
            string strControlCode = string.Empty;
            DataSet ds = new DataSet();
            RadWebClass client = new RadWebClass();
            string strSession = string.Empty;
            string strErr = string.Empty;
            objComm = new classes.CommonClass();

            try
            {
                objCore.USER_ID = UserID;

                bReturn = objCore.FetchBrowserParameters(Server.MapPath("~"), ref ds, ref strCatchMessage);

                if (bReturn)
                {
                    #region Modality
                    DataRow dr1 = ds.Tables["Modality"].NewRow();
                    dr1["id"] = 0;
                    dr1["name"] = "Select One";
                    ds.Tables["Modality"].Rows.InsertAt(dr1, 0);
                    ds.Tables["Modality"].AcceptChanges();

                    ddlModality.DataSource = ds.Tables["Modality"];
                    ddlModality.DataValueField = "id";
                    ddlModality.DataTextField = "name";
                    ddlModality.DataBind();
                    #endregion

                    #region Status
                    DataRow dr2 = ds.Tables["Status"].NewRow();
                    dr2["status_id"] = -1;
                    dr2["status_desc"] = "Select One";
                    ds.Tables["Status"].Rows.InsertAt(dr2, 0);
                    ds.Tables["Status"].AcceptChanges();

                    ddlStatus.DataSource = ds.Tables["Status"];
                    ddlStatus.DataValueField = "status_id";
                    ddlStatus.DataTextField = "status_desc";
                    ddlStatus.DataBind();
                    #endregion

                    #region Institution
                    intCnt = ds.Tables["Institutions"].Rows.Count;
                    DataRow dr3 = ds.Tables["Institutions"].NewRow();
                    dr3["id"] = "00000000-0000-0000-0000-000000000000";
                    dr3["name"] = "Select One";
                    ds.Tables["Institutions"].Rows.InsertAt(dr3, 0);
                    ds.Tables["Institutions"].AcceptChanges();

                    ddlInstitution.DataSource = ds.Tables["Institutions"];
                    ddlInstitution.DataValueField = "id";
                    ddlInstitution.DataTextField = "name";
                    ddlInstitution.DataBind();

                    if (intCnt == 1) ddlInstitution.SelectedIndex = 1;
                    #endregion

                    #region Priority
                    var prio = ds.Tables["Priority"].NewRow();
                    prio["priority_id"] = 0;
                    prio["priority_desc"] = "Select One";
                    ds.Tables["Priority"].Rows.InsertAt(prio, 0);
                    ds.Tables["Priority"].AcceptChanges();

                    ddlPriority.DataSource = ds.Tables["Priority"];
                    ddlPriority.DataValueField = "priority_id";
                    ddlPriority.DataTextField = "priority_desc";
                    ddlPriority.DataBind();
                    #endregion

                    #region API Params
                    foreach (DataRow dr in ds.Tables["APIParams"].Rows)
                    {
                        strControlCode = Convert.ToString(dr["control_code"]).Trim();
                        switch (strControlCode)
                        {
                            case "APIVER":
                                hdnAPIVER.Value = Convert.ToString(dr["data_type_string"]).Trim();
                                break;
                            case "WS8SRVIP":
                                hdnWS8SRVIP.Value = Convert.ToString(dr["data_type_string"]).Trim();
                                break;
                            case "WS8CLTIP":
                                hdnWS8CLTIP.Value = Convert.ToString(dr["data_type_string"]).Trim();
                                break;
                            case "WS8SRVUID":
                                hdnWS8SRVUID.Value = Convert.ToString(dr["data_type_string"]).Trim();
                                break;
                            case "WS8SRVPWD":
                                hdnWS8SRVPWD.Value = CoreCommon.DecryptString(Convert.ToString(dr["data_type_string"]).Trim());
                                break;
                        }
                    }
                    #endregion

                    #region Create WS8 Session
                    //if (hdnAPIVER.Value != "7.2")
                    //{
                    //    bReturn = client.GetSession(hdnWS8CLTIP.Value, hdnWS8SRVIP.Value, hdnWS8SRVUID.Value,hdnWS8SRVPWD.Value, ref strSession, ref strCatchMessage, ref strErr);
                    //    if (bReturn)
                    //    {
                    //        hdnWS8Session.Value = strSession.Trim();
                    //    }
                    //    else
                    //    {
                    //        hdnError.Value = strErr.Trim();
                    //    }
                    //}
                    #endregion
                }
                else
                    hdnError.Value = strCatchMessage.Trim();



            }
            catch (Exception ex)
            {
                hdnError.Value = ex.Message.Trim();
            }
            finally
            {
                ds.Dispose();
                objCore = null;
            }

        }
        #endregion


        #region CallBackBrw_Callback
        protected void CallBackBrw_Callback(object sender, ComponentArt.Web.UI.CallBackEventArgs e)
        {
            SearchRecord(e.Parameters);
            grdBrw.Width = Unit.Percentage(100);
            grdBrw.RenderControl(e.Output);
            spnERR.RenderControl(e.Output);
        }
        #endregion

        #region SearchRecord
        private void SearchRecord(string[] arrRecord)
        {
            objCore = new Core.HouseKeeping.StudyAuditTrail();
            string strCatchMessage = ""; bool bReturn = false;
            DataSet ds = new DataSet();
            objComm = new classes.CommonClass();

            try
            {
                objComm.SetRegionalFormat();
                objCore.PATIENT_NAME = arrRecord[0].Trim();
                objCore.MODALITY_ID = Convert.ToInt32(arrRecord[1]);
               
                objCore.PACS_STATUS_ID= Convert.ToInt32(arrRecord[2]);
                objCore.FILTER_BY_STUDY_DATE = arrRecord[3].Trim();
                objCore.STUDY_DATE_FROM = Convert.ToDateTime(arrRecord[4]);
                objCore.STUDY_DATE_TILL = Convert.ToDateTime(arrRecord[5]);
                objCore.INSTITUTION_ID = new Guid(arrRecord[6]);
                objCore.STUDY_UID = arrRecord[7].Trim();
                objCore.USER_ID = new Guid(arrRecord[8].Trim());
                objCore.PRIORITY_ID = Convert.ToInt32(arrRecord[9]);


                bReturn = objCore.SearchBrowserList(Server.MapPath("~"), ref ds, ref strCatchMessage);

                if (bReturn)
                {

                    grdBrw.DataSource = ds.Tables["BrowserList"];
                    grdBrw.Levels[0].Columns[1].FormatString = objComm.DateFormat + " HH:mm";
                    grdBrw.Levels[0].Columns[9].FormatString = objComm.DateFormat + " HH:mm";
                    grdBrw.DataBind();
                    spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"\" />";
                }
                else
                    spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"" + strCatchMessage + "\" />";

            }
            catch (Exception ex)
            {
                spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"" + ex.Message.Trim() + "\" />";
            }
            finally
            {
                ds.Dispose();
                objCore = null;
            }

        }
        #endregion

    }
}