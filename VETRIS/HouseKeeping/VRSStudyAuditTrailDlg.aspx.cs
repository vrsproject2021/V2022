using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text;
using System.Data;
using System.IO;
using System.Net;
using VETRIS.Core;
using AjaxPro;
using System.Diagnostics;

namespace VETRIS.HouseKeeping
{
    [AjaxPro.AjaxNamespace("VRSStudyAuditTrailDlg")]
    public partial class VRSStudyAuditTrailDlg : System.Web.UI.Page
    {
        #region Members & Variables
        classes.CommonClass objComm;
        VETRIS.Core.HouseKeeping.StudyAuditTrail objCore;
        #endregion

        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(VRSStudyAuditTrailDlg));
            SetAttributes();
            if ((!CallBackST.CausedCallback) && (!CallBackSF.CausedCallback))
                SetPageValue();
        }
        #endregion

        #region SetAttributes
        private void SetAttributes()
        {
            int intMenuID = Convert.ToInt32(Request.QueryString["mid"]);

            btnSave1.Attributes.Add("onclick", "javascript:btnSubmit_OnClick('N','X');");
            btnSave2.Attributes.Add("onclick", "javascript:btnSubmit_OnClick('N','X');");
            btnClose1.Attributes.Add("onclick", "javascript:btnClose_OnClick();");
            btnClose2.Attributes.Add("onclick", "javascript:btnClose_OnClick();");

        }
        #endregion

        #region SetPageValue
        private void SetPageValue()
        {
            hdnID.Value = Request.QueryString["id"];
            int intMenuID = Convert.ToInt32(Request.QueryString["mid"]);
            Guid UserID = new Guid(Request.QueryString["uid"]);

            hdnFilePath.Value = Server.MapPath("~");
            LoadHeader(intMenuID, UserID);

            SetCSS(Request.QueryString["th"]);
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

        #region CreateUserDirectory
        private void CreateUserDirectory(Guid UserID)
        {
            if (!Directory.Exists(Server.MapPath("~/HouseKeeping/Temp/" + UserID.ToString())))
            {
                Directory.CreateDirectory(Server.MapPath("~/HouseKeeping/Temp/" + UserID.ToString()));
            }
        }
        #endregion

        #region LoadHeader
        private void LoadHeader(int intMenuID, Guid UserID)
        {
            objCore = new Core.HouseKeeping.StudyAuditTrail();
            string strCatchMessage = ""; string strReturnMessage = string.Empty; bool bReturn = false;
            DataSet ds = new DataSet();
            objComm = new classes.CommonClass();

            try
            {
                objCore.ID = new Guid(hdnID.Value);
                objCore.MENU_ID = intMenuID;
                objCore.USER_ID = UserID;

                bReturn = objCore.LoadHeader(Server.MapPath("~"), ref ds, ref strReturnMessage, ref strCatchMessage);

                if (bReturn)
                {
                    objComm.SetRegionalFormat();

                    if (objCore.STUDY_UID != string.Empty)
                    {


                        lblSUID.Text = objCore.STUDY_UID; hdnSUID.Value = objCore.STUDY_UID;
                        lblPName.Text = objCore.PATIENT_NAME;
                        lblPID.Text = objCore.PATIENT_ID;
                        lblSex.Text = objCore.PATIENT_GENDER;


                        lblSN.Text = objCore.SEX_NEUTERED;

                        lblWt.Text = objComm.IMNumeric(objCore.PATIENT_WEIGHT, 3);
                        lblUOM.Text = objCore.WEIGHT_UOM;
                        if (objCore.PATIENT_DOB.Year > 1900) lblFromDt.Text = objComm.IMDateFormat(objCore.PATIENT_DOB, objComm.DateFormat);


                        lblAge.Text = objCore.PATIENT_AGE;
                        lblSpecies.Text = objCore.SPECIES_NAME.ToString();
                        lblBreed.Text = objCore.BREED_NAME.ToString();
                        lblOwnerFN.Text = objCore.OWNER_FIRST_NAME; lblOwnerLN.Text = objCore.OWNER_LAST_NAME;
                        lblStudyDt.Text = objComm.IMDateFormat(objCore.STUDY_DATE, objComm.DateFormat);
                        divReason.InnerHtml = objCore.REASON;
                        txtReason.Text = objCore.REASON;
                        divPhysNote.InnerHtml = objCore.PHYSICIAN_NOTE;
                        txtPhysNote.Text = objCore.PHYSICIAN_NOTE;
                        lblAccnNo.Text = objCore.ACCESSION_NO;
                        lblPriority.Text = objCore.PRIORITY_DESCRIPTION;
                        lblModality.Text = objCore.MODALITY_NAME;
                        hdnModalityID.Value = objCore.MODALITY_ID.ToString();
                        lblInstitution.Text = objCore.INSTITUTION_NAME;
                        lblPhys.Text = objCore.PHYSICIAN_NAME;

                        lblImgCnt.Text = objCore.IMAGE_COUNT.ToString();
                        lblObjCnt.Text = objCore.OBJECT_COUNT.ToString();
                        lblConfImgCnt.Text = objCore.IMAGE_COUNT_ACCEPTED;

                        lblCountry.Text = objCore.Country;
                        lblState.Text = objCore.State;
                        lblCity.Text = objCore.City;

                    }
                    else
                    {
                        hdnError.Value = "false" + objComm.RecordDivider + "094";
                    }
                }
                else
                {
                    if (strCatchMessage.Trim() != string.Empty)
                        hdnError.Value = "catch" + objComm.RecordDivider + strCatchMessage.Trim();
                    else
                        hdnError.Value = "false" + objComm.RecordDivider + strReturnMessage.Trim();
                }

                CreateUserDirectory(UserID);
            }
            catch (Exception ex)
            {
                hdnError.Value = "catch" + objComm.RecordDivider + ex.Message.Trim();
            }
            finally
            {
                ds.Dispose(); objComm = null; objCore = null;
            }
        }
        #endregion

        #region Study Type Grid

        #region CallBackST_Callback
        protected void CallBackST_Callback(object sender, ComponentArt.Web.UI.CallBackEventArgs e)
        {
            LoadStudyTypes(e.Parameters);
            grdST.Width = Unit.Percentage(100);
            grdST.RenderControl(e.Output);
            spnErrST.RenderControl(e.Output);
            spnTrackBy.RenderControl(e.Output);
        }
        #endregion

        #region LoadStudyTypes
        private void LoadStudyTypes(string[] arrParams)
        {
            objCore = new Core.HouseKeeping.StudyAuditTrail();
            string strCatchMessage = ""; bool bReturn = false;
            DataSet ds = new DataSet();
            Guid UserID = Guid.Empty;
            string strFileName = "";

            try
            {

                objCore.ID = new Guid(arrParams[0]);
                objCore.MODALITY_ID = Convert.ToInt32(arrParams[1]);

                bReturn = objCore.LoadStudyTypes(Server.MapPath("~"), ref ds, ref strCatchMessage);
                if (bReturn)
                {
                    grdST.DataSource = ds.Tables["StudyTypes"];
                    grdST.DataBind();
                    spnTrackBy.InnerHtml = "<input type=\"hidden\" id=\"hdnModTrackBy\" value=\"I\" />";

                    foreach (DataRow dr in ds.Tables["TrackBy"].Rows)
                    {
                        spnTrackBy.InnerHtml = "<input type=\"hidden\" id=\"hdnModTrackBy\" value=\"" + Convert.ToString(dr["track_by"]) + "\" />";
                    }


                    spnErrST.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErrST\" value=\"\" />";
                }
                else
                {
                    spnTrackBy.InnerHtml = "<input type=\"hidden\" id=\"hdnModTrackBy\" value=\"I\" />";
                    spnErrST.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErrST\" value=\"" + strCatchMessage + "\" />";
                }



            }
            catch (Exception ex)
            {
                spnErrST.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErrST\" value=\"" + ex.Message.Trim() + "\" />";
                spnTrackBy.InnerHtml = "<input type=\"hidden\" id=\"hdnModTrackBy\" value=\"I\" />";
            }
            finally
            {
                ds.Dispose();
                objCore = null;
            }
        }
        #endregion

        #endregion

        #region Study File Grid

        #region CallBackSF_Callback
        protected void CallBackSF_Callback(object sender, ComponentArt.Web.UI.CallBackEventArgs e)
        {
            string strAction = e.Parameters[0];

            switch (strAction)
            {
                case "L":
                    LoadFiles(e.Parameters);
                    break;
                case "A":
                    AddFiles(e.Parameters);
                    break;
                case "D":
                    DeleteFiles(e.Parameters);
                    break;
                case "C":
                    ClearFiles(e.Parameters);
                    break;
            }
            grdSF.Width = Unit.Percentage(100);
            grdSF.RenderControl(e.Output);
            spnERR.RenderControl(e.Output);
        }
        #endregion

        #region LoadFiles
        private void LoadFiles(string[] arrParams)
        {
            objCore = new VETRIS.Core.HouseKeeping.StudyAuditTrail();
            string strCatchMessage = ""; bool bReturn = false;
            DataSet ds = new DataSet();
            Guid UserID = Guid.Empty;
            string strFileName = "";

            try
            {

                objCore.ID = new Guid(arrParams[1]);
                UserID = new Guid(arrParams[2]);

                bReturn = objCore.LoadStudyFiles(Server.MapPath("~"), ref ds, ref strCatchMessage);
                if (bReturn)
                {
                    grdSF.DataSource = ds.Tables["Files"];
                    grdSF.DataBind();

                    foreach (DataRow dr in ds.Tables["Files"].Rows)
                    {

                        strFileName = Convert.ToString(dr["file_name"]);
                        SetFile((byte[])dr["file_content"], Convert.ToString(dr["file_name"]).Trim(), "CaseList/Temp/" + UserID.ToString());

                    }

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

        #region AddFiles
        private void AddFiles(string[] arrParams)
        {
            DataTable dtbl = new DataTable();
            objComm = new classes.CommonClass();
            string[] arrSep = { objComm.SecondaryRecordDivider };
            string[] arrRecords = arrParams[1].Split(arrSep, StringSplitOptions.None);
            string[] arrNew = arrParams[2].Split(arrSep, StringSplitOptions.None);
            int intSrl = 0;
            string strAccnNo = string.Empty;
            string strPID = string.Empty;
            string strFile = string.Empty;
            string strMimeType = string.Empty;
            string strUserID = arrParams[3];
            DICOMLib.DicomDecoder dd = new DICOMLib.DicomDecoder();

            try
            {
                dtbl = CreateStudyFileTable();
                if (arrRecords.Length > 0)
                {
                    if (arrRecords[0].Trim() != "")
                    {
                        for (int i = 0; i < arrRecords.Length; i = i + 5)
                        {
                            DataRow dr = dtbl.NewRow();
                            intSrl = intSrl + 1;
                            dr["id"] = arrRecords[i];
                            dr["file_srl_no"] = intSrl;
                            dr["file_name"] = strFile = arrRecords[i + 2].Trim().Substring(arrRecords[i + 2].Trim().LastIndexOf("/") + 1, (arrRecords[i + 2].Trim().Length - (arrRecords[i + 2].Trim().LastIndexOf("/") + 1)));
                            dr["file_type"] = arrRecords[i + 3].Trim();
                            if (arrRecords[i + 3].Trim() == "D") dr["file_type_desc"] = "DICOM";
                            else if (arrRecords[i + 3].Trim() == "I")
                            {
                                strMimeType = classes.MIMEAssistant.GetMIMEType(Server.MapPath("~") + "/CaseList/Temp/" + strUserID + "/" + strFile);
                                switch (strMimeType)
                                {
                                    case "image/jpeg":
                                        dr["file_type_desc"] = "JPG/JPEG";
                                        break;
                                    case "image/gif":
                                        dr["file_type_desc"] = "GIF";
                                        break;
                                    case "image/png":
                                        dr["file_type_desc"] = "PNG";
                                        break;
                                    case "image/bmp":
                                        dr["file_type_desc"] = "BMP";
                                        break;
                                }

                            }
                            else if (arrRecords[i + 3].Trim() == "P") dr["file_type_desc"] = "PDF";
                            dtbl.Rows.Add(dr);


                        }

                    }
                }

                for (int i = 0; i < arrNew.Length; i = i + 2)
                {
                    DataRow drNew = dtbl.NewRow();
                    intSrl = intSrl + 1;
                    drNew["id"] = "00000000-0000-0000-0000-000000000000";
                    drNew["file_srl_no"] = intSrl;
                    drNew["file_name"] = strFile = arrNew[i].Trim().Substring(arrNew[i].Trim().LastIndexOf("/") + 1, (arrNew[i].Trim().Length - (arrNew[i].Trim().LastIndexOf("/") + 1)));
                    drNew["file_type"] = arrNew[i + 1];
                    if (arrNew[i + 1].Trim() == "D") drNew["file_type_desc"] = "DICOM";
                    else if (arrNew[i + 1].Trim() == "I")
                    {
                        strMimeType = classes.MIMEAssistant.GetMIMEType(Server.MapPath("~") + "/CaseList/Temp/" + strUserID + "/" + strFile);
                        switch (strMimeType)
                        {
                            case "image/jpeg":
                                drNew["file_type_desc"] = "JPG/JPEG";
                                break;
                            case "image/gif":
                                drNew["file_type_desc"] = "GIF";
                                break;
                            case "image/png":
                                drNew["file_type_desc"] = "PNG";
                                break;
                            case "image/bmp":
                                drNew["file_type_desc"] = "BMP";
                                break;
                        }

                    }
                    else if (arrNew[i + 1].Trim() == "P") drNew["file_type_desc"] = "PDF";

                    dtbl.Rows.Add(drNew);



                }

                grdSF.DataSource = dtbl;
                grdSF.DataBind();
                spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"\" />";
            }
            catch (Exception ex)
            {
                spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"" + ex.Message.Trim() + "\" />";
            }
            finally
            {
                dtbl.Dispose();
                objComm = null;
                dd = null;
            }
        }
        #endregion

        #region DeleteFiles
        private void DeleteFiles(string[] arrParams)
        {
            DataTable dtbl = new DataTable();
            objComm = new classes.CommonClass();
            int intID = Convert.ToInt32(arrParams[1]);
            string[] arrSep = { objComm.SecondaryRecordDivider };
            string[] arrRecords = arrParams[2].Split(arrSep, StringSplitOptions.None);
            string strFolder = arrParams[3];
            string strFileName = string.Empty;
            int intSrl = 0;
            int intLoop = 0;
            string strAccnNo = string.Empty;
            string strPID = string.Empty;

            try
            {
                dtbl = CreateStudyFileTable();
                strFolder = strFolder.Replace("\\", "/");

                if (arrRecords[0].Trim() != "")
                {
                    for (int i = 0; i < arrRecords.Length; i = i + 5)
                    {
                        if (Convert.ToInt32(arrRecords[i + 1]) != intID)
                        {
                            DataRow dr = dtbl.NewRow();
                            intSrl = intSrl + 1;
                            dr["id"] = arrRecords[i].Trim(); ;
                            dr["file_srl_no"] = intSrl;
                            dr["file_name"] = arrRecords[i + 2].Trim();
                            dr["file_type"] = arrRecords[i + 3].Trim();
                            dr["file_type_desc"] = arrRecords[i + 4].Trim();
                            dtbl.Rows.Add(dr);
                            intLoop = intLoop + 1;
                        }
                        else
                            strFileName = arrRecords[i + 2].Trim();
                    }
                }

                grdSF.DataSource = dtbl;
                grdSF.DataBind();
                spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"\" />";

                if (strFileName.Trim() != string.Empty)
                {
                    if (File.Exists(strFolder + "/" + strFileName))
                    {
                        File.Delete(strFolder + "/" + strFileName);
                    }
                }

            }
            catch (Exception ex)
            {
                spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"" + ex.Message.Trim() + "\" />";
            }
            finally
            {
                dtbl.Dispose();
                objComm = null;
            }
        }
        #endregion

        #region ClearFiles
        private void ClearFiles(string[] arrParams)
        {
            DataTable dtbl = new DataTable();
            objComm = new classes.CommonClass();

            string[] arrSep = { objComm.SecondaryRecordDivider };
            string[] arrRecords = arrParams[0].Split(arrSep, StringSplitOptions.None);
            string strFolder = arrParams[1];
            string strFileName = string.Empty;


            try
            {
                dtbl = CreateStudyFileTable();
                if (arrRecords[0].Trim() != "")
                {
                    strFolder = strFolder.Replace("\\", "/");
                    for (int i = 0; i < arrRecords.Length; i = i + 5)
                    {
                        strFileName = arrRecords[i + 2].Trim();
                        if (strFileName.Trim() != string.Empty)
                        {
                            if (File.Exists(strFolder + "/" + strFileName))
                            {
                                File.Delete(strFolder + "/" + strFileName);
                            }
                        }
                    }
                }

                grdSF.DataSource = dtbl;
                grdSF.DataBind();
                spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"\" />";


            }
            catch (Exception ex)
            {
                spnERR.InnerHtml = "<input type=\"hidden\" id=\"hdnCBErr\" value=\"" + ex.Message.Trim() + "\" />";

            }
            finally
            {
                dtbl.Dispose();
                objComm = null;
            }
        }
        #endregion

        #region CreateStudyFileTable
        private DataTable CreateStudyFileTable()
        {
            DataTable dtbl = new DataTable();
            dtbl.Columns.Add("id", System.Type.GetType("System.String"));
            dtbl.Columns.Add("file_srl_no", System.Type.GetType("System.Int32"));
            dtbl.Columns.Add("file_name", System.Type.GetType("System.String"));
            dtbl.Columns.Add("file_type", System.Type.GetType("System.String"));
            dtbl.Columns.Add("file_type_desc", System.Type.GetType("System.String"));
            dtbl.TableName = "files";
            return dtbl;
        }
        #endregion

        #endregion

        #region File Methods

        #region SetFile
        private void SetFile(byte[] DocData, string strFileName, string strPath)
        {
            string strFilePath = Server.MapPath("~") + "/" + strPath + "/" + strFileName;

            if (!Directory.Exists(Server.MapPath("~") + "/" + strPath)) Directory.CreateDirectory(Server.MapPath("~") + "/" + strPath);

            using (FileStream fs = new FileStream(strFilePath, FileMode.OpenOrCreate, FileAccess.Write))
            {
                fs.Write(DocData, 0, DocData.Length);
                fs.Flush();
                fs.Close();
            }

        }
        #endregion

        #region GetFileBytes
        private byte[] GetFileBytes(string strFileName)
        {
            byte[] buff = File.ReadAllBytes(strFileName);
            return buff;
        }
        #endregion

        #endregion

        #region DICOM File Methods

        #region GetStudyUID
        private string GetStudyUID(List<string> str)
        {

            string StudyUID = string.Empty;
            string s1, s4, s5, s11, s12;

            // Add items to the List View Control
            for (int i = 0; i < str.Count; ++i)
            {
                s1 = str[i];

                ExtractStrings(s1, out s4, out s5, out s11, out s12);

                if ((s11.ToUpper() == "0020") && (s12.ToUpper() == "000D"))
                {
                    StudyUID = s5.Replace("\0", "");
                    break;
                }

            }
            return StudyUID;

        }
        #endregion

        #region GetallTags
        private string[] GetallTags(List<string> str)
        {

            string strDescription = string.Empty;
            string StudyUID = string.Empty;
            string ModalityID = string.Empty;
            string StrPName = string.Empty;
            string StudyDt = string.Empty;
            string StudyTime = string.Empty;
            string sDt = string.Empty;
            string sTime = string.Empty;
            string studyDtTime = string.Empty;
            string UserSeriesID = string.Empty;
            string SeriesNumber = string.Empty;
            string InstitutionName = string.Empty;
            string PatientID = string.Empty;
            string AccnNo = string.Empty;
            string RefPhys = string.Empty;
            string Manufacturer = string.Empty;
            string StationName = string.Empty;
            string Model = string.Empty;
            string ModalityAETitle = string.Empty;
            string Reason = string.Empty;
            string BirthDt = string.Empty;
            string bDt = string.Empty;
            string PatientSex = string.Empty;
            string PatientAge = string.Empty;
            //string PatientWt = string.Empty;//(0010,1030)
            //string Species = string.Empty;//(0010,2201)
            //string Breed = string.Empty;//(0010,2292)
            //string Owner = string.Empty;//(0010,2297)
            string PriorityID = string.Empty;


            // Add items to the List View Control
            for (int i = 0; i < str.Count; ++i)
            {
                string s1, s4, s5, s11, s12;
                s1 = str[i];

                ExtractStrings(s1, out s4, out s5, out s11, out s12);

                #region commented
                /*if ((s11.ToUpper() == "0008") && (s12.ToUpper() == "103E"))
                {
                    strDescription = s5.Replace("\0", "");
                    strDescription = s5.Replace("<", " ");
                    strDescription = s5.Replace(">", " ");

                }

                else if ((s11.ToUpper() == "0008") && (s12.ToUpper() == "0060"))
                {
                    ModalityID = s5.Replace("\0", "");

                }


                else if ((s11.ToUpper() == "0010") && (s12.ToUpper() == "0010"))
                {
                    Strname = s5.Replace("\0", "");
                    Strname = s5.Replace("^", " ");

                }
                else if ((s11.ToUpper() == "0010") && (s12.ToUpper() == "0030"))
                {
                    DOB = s5.Replace("\0", "");
                    DOB = DOB.Trim();
                    if (DOB != "")
                    {
                        string yy = DOB.Substring(0, 4);
                        string MM = DOB.Substring(4, 2);
                        string DD = DOB.Substring(6, 2);
                        result = yy + "-" + MM + "-" + DD;
                    }
                    else
                    {
                        result = "0000-00-00";
                    }
                }

                else */
                #endregion

                #region Tags
                s5 = s5.Replace("\t", "");
                s5 = s5.Replace("\n", "");

                switch (s11.ToUpper())
                {
                    case "0008":
                        #region s11 =0008
                        switch (s12.ToUpper())
                        {
                            case "0020":
                                StudyDt = s5.Replace("\0", "");
                                StudyDt = StudyDt.Trim();
                                if ((StudyDt.Length == 8))
                                {
                                    string yyyy = StudyDt.Substring(0, 4);
                                    string MM = StudyDt.Substring(4, 2);
                                    string DD = StudyDt.Substring(6, 2);
                                    sDt = yyyy + "-" + MM + "-" + DD;
                                }
                                else
                                {
                                    sDt = "0000-00-00";
                                }
                                break;
                            case "0030":
                                StudyTime = s5.Replace("\0", "");
                                StudyTime = StudyTime.Trim();
                                if ((StudyTime.Length == 6))
                                {
                                    string Hr = StudyTime.Substring(0, 2);
                                    string Min = StudyTime.Substring(2, 2);
                                    string Sec = StudyTime.Substring(4, 2);
                                    sTime = Hr + ":" + Min + ":" + Sec;
                                }
                                else
                                {
                                    sTime = "00:00:00";
                                }
                                break;
                            case "0050":
                                AccnNo = s5.Replace("\0", "");
                                break;
                            case "0060":
                                ModalityID = s5.Replace("\0", "");
                                break;
                            case "0070":
                                Manufacturer = s5.Replace("\0", "");
                                break;
                            case "0080":
                                if (InstitutionName.Trim() == string.Empty)
                                {
                                    InstitutionName = s5.Replace("\0", "");
                                    InstitutionName = s5.Replace("^", " ");
                                }
                                break;
                            case "0090":
                                RefPhys = s5.Replace("\0", "");
                                RefPhys = s5.Replace("^", " ");
                                break;
                            case "1010":
                                StationName = s5.Replace("\0", "");
                                break;
                            case "1090":
                                Model = s5.Replace("\0", "");
                                break;
                            default:
                                break;
                        }
                        #endregion
                        break;
                    case "0010":
                        #region s11 =0010
                        switch (s12.ToUpper())
                        {
                            case "0010":
                                StrPName = s5.Replace("\0", "");
                                StrPName = s5.Replace("^", " ");
                                break;
                            case "0020":
                                PatientID = s5.Replace("\0", "");
                                break;
                            case "0030":
                                BirthDt = s5.Replace("\0", "");
                                BirthDt = BirthDt.Trim();
                                if ((BirthDt.Length == 8))
                                {
                                    string yyyy = BirthDt.Substring(0, 4);
                                    string MM = BirthDt.Substring(4, 2);
                                    string DD = BirthDt.Substring(6, 2);
                                    bDt = yyyy + "-" + MM + "-" + DD;
                                }
                                else
                                {
                                    bDt = "0000-00-00";
                                }
                                break;
                            case "0040":
                                PatientSex = s5.Replace("\0", "");
                                break;
                            case "1010":
                                PatientAge = s5.Replace("\0", "");
                                break;
                        }
                        #endregion
                        break;
                    case "0020":
                        #region s11 =0020
                        switch (s12.ToUpper())
                        {
                            case "000D":
                                if (StudyUID.Trim() == string.Empty)
                                {
                                    StudyUID = s5.Replace("\0", "");
                                }
                                break;
                            case "000E":
                                UserSeriesID = s5.Replace("\0", "");
                                break;
                            case "0011":
                                SeriesNumber = s5.Replace("\0", "");
                                break;
                        }
                        #endregion
                        break;
                    case "0032":
                        #region s11 =0032
                        switch (s12.ToUpper())
                        {
                            case "000C":
                                PriorityID = s5.Replace("\0", "");
                                break;
                        }
                        #endregion
                        break;
                    case "0040":
                        #region s11 =0040
                        switch (s12.ToUpper())
                        {
                            case "0241":
                                ModalityAETitle = s5.Replace("\0", "");
                                break;
                            case "1002":
                                Reason = s5.Replace("\0", "");
                                break;

                        }
                        #endregion
                        break;
                    default:
                        break;
                }
                #endregion
            }

            studyDtTime = sDt + " " + sTime;

            string[] arr = new string[17];
            arr[0] = StudyUID;
            arr[1] = ModalityID;
            arr[2] = PatientID;
            arr[3] = StrPName;
            arr[4] = studyDtTime;
            arr[5] = InstitutionName;
            arr[6] = AccnNo;
            arr[7] = RefPhys;
            arr[8] = Manufacturer;
            arr[9] = StationName;
            arr[10] = Model;
            arr[11] = ModalityAETitle;
            arr[12] = Reason;
            arr[13] = bDt;
            arr[14] = PatientSex;
            arr[15] = PatientAge;
            arr[16] = PriorityID;

            return arr;

        }
        #endregion

        #region ExtractStrings
        void ExtractStrings(string s1, out string s4, out string s5, out string s11, out string s12)
        {
            int ind;
            string s2, s3;
            ind = s1.IndexOf("//");
            s2 = s1.Substring(0, ind);
            s11 = s1.Substring(0, 4);
            s12 = s1.Substring(4, 4);
            s3 = s1.Substring(ind + 2);
            ind = s3.IndexOf(":");
            s4 = s3.Substring(0, ind);
            s5 = s3.Substring(ind + 1);
        }
        #endregion

        #region ModifyDCMFile
        private bool ModifyDCMFile(string strDCMMODIFYEXEPATH, string strInsName, string strSUID, string strDCMPath, ref string strOutputMsg, ref string strReturnMessage)
        {
            bool bRet = false;
            string strProcOutput = string.Empty;
            string strProcError = string.Empty;

            try
            {
                Process ProcModSUID = new Process();
                ProcModSUID.StartInfo.UseShellExecute = false;
                ProcModSUID.StartInfo.FileName = strDCMMODIFYEXEPATH;
                ProcModSUID.StartInfo.Arguments = "-i \"(0020,000D)=" + strSUID + "\"" + " " + strDCMPath;
                ProcModSUID.StartInfo.RedirectStandardOutput = true;
                ProcModSUID.StartInfo.RedirectStandardError = true;
                ProcModSUID.Start();
                strProcOutput = ProcModSUID.StandardOutput.ReadToEnd();
                strProcError = ProcModSUID.StandardError.ReadToEnd();
                strOutputMsg = strProcOutput.Trim();
                bRet = true;


            }
            catch (Exception ex)
            {
                strReturnMessage = ex.Message.Trim();
            }


            if (bRet)
            {
                try
                {
                    Process ProcModInst = new Process();
                    ProcModInst.StartInfo.UseShellExecute = false;
                    ProcModInst.StartInfo.FileName = strDCMMODIFYEXEPATH;
                    ProcModInst.StartInfo.Arguments = "-i \"(0008,0080)=" + strInsName + "\"" + " " + strDCMPath;
                    ProcModInst.StartInfo.RedirectStandardOutput = true;
                    ProcModInst.StartInfo.RedirectStandardError = true;
                    ProcModInst.Start();
                    strProcOutput = ProcModInst.StandardOutput.ReadToEnd();
                    strProcError = ProcModInst.StandardError.ReadToEnd();
                    strOutputMsg = strProcOutput.Trim();
                    bRet = true;


                }
                catch (Exception ex)
                {
                    strReturnMessage = ex.Message.Trim();
                }

            }

            return bRet;
        }
        #endregion

        #endregion

        #region SaveRecord (Ajaxpro Method)
        [AjaxPro.AjaxMethod()]
        public string[] SaveRecord(string[] ArrRecord,string[] ArrDocs, string[] ArrDCM)
        {
            bool bReturn = false; bool bFileValid = true;
            string[] arrRet = new string[0];
            string strReturnMsg = string.Empty; string strCatchMessage = string.Empty;
            string strSUID = string.Empty; string strOutputMsg = string.Empty;
            Guid UserID = Guid.Empty;

            objComm = new classes.CommonClass();
            objCore = new Core.HouseKeeping.StudyAuditTrail();
            Core.Case.HeaderDocumentList[] objDocs = new Core.Case.HeaderDocumentList[0];
            Core.Case.HeaderDICOMList[] objDCM = new Core.Case.HeaderDICOMList[0];
            DICOMLib.DicomDecoder dd = new DICOMLib.DicomDecoder();
            string strFileName = string.Empty;
            string strExtn = string.Empty;
            string strFile = string.Empty;
            string strDCMMODIFYEXEPATH = string.Empty;
            string strInsName = string.Empty;
            int intListIndex = 0;

            try
            {
                #region Header Values
                objCore.ID = new Guid(ArrRecord[0]);
                objCore.REASON = ArrRecord[1].Trim();
                objCore.WRITE_BACK = ArrRecord[2].Trim();
                objCore.MergeStatus = ArrRecord[3].Trim();
                objCore.PHYSICIAN_NOTE = ArrRecord[4].Trim();
                objCore.USER_ID = UserID = new Guid(ArrRecord[5]);
                objCore.MENU_ID = Convert.ToInt32(ArrRecord[6]);
                strSUID = ArrRecord[7].Trim();
                strInsName = ArrRecord[8].Trim();
                #endregion

                #region Populate Documents
                intListIndex = 0;
                objDocs = new Core.Case.HeaderDocumentList[(ArrDocs.Length / 3)];

                for (int i = 0; i < objDocs.Length; i++)
                {
                    strFileName = Server.MapPath("~/CaseList/Temp/" + UserID.ToString() + "/") + ArrDocs[intListIndex + 2].Trim();
                    strFileName = strFileName.Replace("ajaxpro\\", "");
                    strExtn = Path.GetExtension(strFileName);

                    objDocs[i] = new Core.Case.HeaderDocumentList();
                    objDocs[i].SERIAL_NUMBER = Convert.ToInt32(ArrDocs[intListIndex]);
                    objDocs[i].ID = new Guid(ArrDocs[intListIndex + 1]);
                    objDocs[i].NAME = ArrDocs[intListIndex + 2].Trim();
                    objDocs[i].FILE_NAME = ArrDocs[intListIndex + 2].Trim();
                    objDocs[i].FILE_TYPE = strExtn;
                    objDocs[i].FILE_CONTENT = GetFileBytes(strFileName);

                    intListIndex = intListIndex + 3;
                }
                #endregion

                #region DICOM files
                intListIndex = 0;
                objDCM = new Core.Case.HeaderDICOMList[(ArrDCM.Length / 3)];

                for (int i = 0; i < objDCM.Length; i++)
                {
                    strFile = ArrDCM[intListIndex + 2].Trim();
                    strFileName = Server.MapPath("~/CaseList/Temp/" + UserID.ToString() + "/") + ArrDCM[intListIndex + 2].Trim();
                    strFileName = strFileName.Replace("ajaxpro\\", "");
                    dd.DicomFileName = strFileName;
                    List<string> str = dd.dicomInfo;

                    if (GetStudyUID(str).Trim() != strSUID)
                    {
                        if (ModifyDCMFile(strDCMMODIFYEXEPATH, strInsName, strSUID, strFileName, ref strOutputMsg, ref strReturnMsg))
                        {
                            dd.DicomFileName = strFileName;
                            str = dd.dicomInfo;
                            if (GetStudyUID(str).Trim() != strSUID)
                            {
                                bFileValid = false;
                                strReturnMsg = strOutputMsg;
                            }
                            else
                                bFileValid = true;
                        }
                        else
                            bFileValid = false;
                    }

                    if (bFileValid)
                    {

                        objDCM[i] = new Core.Case.HeaderDICOMList();
                        objDCM[i].ID = new Guid(ArrDCM[intListIndex]);
                        objDCM[i].SERIAL_NUMBER = Convert.ToInt32(ArrDCM[intListIndex + 1]);
                        objDCM[i].FILE_NAME = ArrDCM[intListIndex + 2].Trim();
                        objDCM[i].FILE_CONTENT = GetFileBytes(strFileName);
                        intListIndex = intListIndex + 3;

                        if (File.Exists(strFileName + ".bak"))
                        {
                            File.Delete(strFileName + ".bak");
                        }
                    }
                    else
                    {

                        break;
                    }
                }
                #endregion
                intListIndex = 0;

                if (bFileValid)
                {
                    bReturn = objCore.SaveRecord(Server.MapPath("~"), objDocs, objDCM, ref strReturnMsg, ref strCatchMessage);

                    #region Post Saving
                    if (bReturn)
                    {
                        arrRet = new string[3];
                        arrRet[0] = "true";
                        strReturnMsg = strReturnMsg.Trim();


                        if ((objCore.WRITE_BACK == "N"))
                        {
                            strReturnMsg = strReturnMsg; //+objComm.RecordDivider + "078";
                        }


                        if (objCore.MergeStatus == "M")
                        {
                            strReturnMsg = strReturnMsg + objComm.RecordDivider + "174";
                        }
                        else if (objCore.MergeStatus == "C")
                        {
                            strReturnMsg = strReturnMsg + objComm.RecordDivider + "175";
                        }
                        else
                            arrRet[2] = string.Empty;


                        arrRet[1] = strReturnMsg.Trim();
                    }
                    else
                    {

                        if (strCatchMessage.Trim() != "")
                        {
                            arrRet = new string[2];
                            arrRet[0] = "catch";
                            arrRet[1] = strCatchMessage.Trim();

                        }
                        else
                        {
                            arrRet = new string[3];
                            arrRet[0] = "false";
                            arrRet[1] = strReturnMsg.Trim();
                            arrRet[2] = objCore.USER_NAME;
                        }
                    }
                    #endregion
                }
                else
                {
                    arrRet = new string[4];
                    arrRet[0] = "false";
                    arrRet[1] = "331";
                    arrRet[3] = strReturnMsg;

                }
            }
            catch (Exception expErr)
            {
                bReturn = false;
                arrRet = new string[2];
                arrRet[0] = "catch";
                arrRet[1] = expErr.Message.Trim();
            }
            finally
            {
                objCore = null; objComm = null;
                strReturnMsg = null; strCatchMessage = null;
            }
            return arrRet;
        }
        #endregion
    }
}