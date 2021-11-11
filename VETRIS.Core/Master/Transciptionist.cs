﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using VETRIS.DAL;

namespace VETRIS.Core.Master
{
    public class Transciptionist
    {
        
        #region Constructor
        public Transciptionist()
        {

        }
        #endregion

        #region Variables
        int intMenuID               = 0;
        Guid UserID                 = new Guid("00000000-0000-0000-0000-000000000000");
        int intUserRoleID           = 0;
        string strUserName          = string.Empty;

        Guid Id                     = new Guid("00000000-0000-0000-0000-000000000000");
        string strCode              = string.Empty;
        string strName              = string.Empty;
        string strFname             = string.Empty;
        string strLname             = string.Empty;
        string strAddress1          = string.Empty;
        string strAddress2          = string.Empty;
        string strCity              = string.Empty;
        int intStateID              = 0;
        int intCountryID            = 0;
        string strZip               = string.Empty;
        string strPhone             = string.Empty;
        string strMobile            = string.Empty;
        string strEmail             = string.Empty;
        Guid LoginUserId            = new Guid("00000000-0000-0000-0000-000000000000");
        string strLoginID           = string.Empty;
        string strPwd               = string.Empty;
        decimal decDefaultFee       = 0;
        string strNotificationPref  = "B";
        string strNotes             = string.Empty;
        string strIsActive          = "Y";
        string strXML               = string.Empty;
        #endregion

        #region Properties
        public int MENU_ID
        {
            get { return intMenuID; }
            set { intMenuID = value; }
        }
        public Guid USER_ID
        {
            get { return UserID; }
            set { UserID = value; }
        }
        public int USER_ROLE_ID
        {
            get { return intUserRoleID; }
            set { intUserRoleID = value; }
        }
        public string USER_NAME
        {
            get { return strUserName; }
            set { strUserName = value; }
        }
        public Guid ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string CODE
        {
            get { return strCode; }
            set { strCode = value; }
        }
        public string FIRST_NAME
        {
            get { return strFname; }
            set { strFname = value; }
        }
        public string LAST_NAME
        {
            get { return strLname; }
            set { strLname = value; }
        }
        public string NAME
        {
            get { return strName; }
            set { strName = value; }
        }
        public string ADDRESS_LINE1
        {
            get { return strAddress1; }
            set { strAddress1 = value; }
        }
        public string ADDRESS_LINE2
        {
            get { return strAddress2; }
            set { strAddress2 = value; }
        }
        public string CITY
        {
            get { return strCity; }
            set { strCity = value; }
        }
        public int STATE_ID
        {
            get { return intStateID; }
            set { intStateID = value; }
        }
        public int COUNTRY_ID
        {
            get { return intCountryID; }
            set { intCountryID = value; }
        }
        public string ZIP
        {
            get { return strZip; }
            set { strZip = value; }
        }
        public string PHONE
        {
            get { return strPhone; }
            set { strPhone = value; }
        }
        public string MOBILE
        {
            get { return strMobile; }
            set { strMobile = value; }
        }
        public string EMAIL_ID
        {
            get { return strEmail; }
            set { strEmail = value; }
        }
        public Guid LOGIN_USER_ID
        {
            get { return LoginUserId; }
            set { LoginUserId = value; }
        }
        public string LOGIN_ID
        {
            get { return strLoginID; }
            set { strLoginID = value; }
        }
        public string LOGIN_PASSWORD
        {
            get { return strPwd; }
            set { strPwd = value; }
        }
        public decimal DEFAULT_FEE 
        {
            get { return decDefaultFee; }
            set { decDefaultFee = value; }
        }
        public string NOTIFICATION_PREFERENCE
        {
            get { return strNotificationPref; }
            set { strNotificationPref = value; }
        }
        public string NOTES
        {
            get { return strNotes; }
            set { strNotes = value; }
        }
        public string IS_ACTIVE
        {
            get { return strIsActive; }
            set { strIsActive = value; }
        }
        #endregion

        #region Browser Methods

        #region FetchBrowserParameters
        public bool FetchBrowserParameters(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;

            try
            {
                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "master_brw_fetch_params");
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Country";
                }
                bReturn = true;
            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #region SearchBrowserList
        public bool SearchBrowserList(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;
            SqlParameter[] SqlRecordParams = new SqlParameter[8];
            SqlRecordParams[0] = new SqlParameter("@code", SqlDbType.NVarChar, 5); SqlRecordParams[0].Value = strCode;
            SqlRecordParams[1] = new SqlParameter("@name", SqlDbType.NVarChar, 100); SqlRecordParams[1].Value = strName;
            SqlRecordParams[2] = new SqlParameter("@city", SqlDbType.NVarChar, 100); SqlRecordParams[2].Value = strCity;
            SqlRecordParams[3] = new SqlParameter("@mobile_no", SqlDbType.NVarChar, 20); SqlRecordParams[3].Value = strMobile;
            SqlRecordParams[4] = new SqlParameter("@country_id", SqlDbType.NVarChar, 20); SqlRecordParams[4].Value = intCountryID;
            SqlRecordParams[5] = new SqlParameter("@state_id", SqlDbType.NVarChar, 20); SqlRecordParams[5].Value = intStateID;
            SqlRecordParams[6] = new SqlParameter("@is_active", SqlDbType.NChar, 1); SqlRecordParams[6].Value = strIsActive;
            SqlRecordParams[7] = new SqlParameter("@user_id", SqlDbType.UniqueIdentifier); SqlRecordParams[7].Value = UserID;


            try
            {
                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, "master_transciptionists_fetch_brw", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "BrowserList";
                }
                bReturn = true;
            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #endregion

        #region Dialog Methods

        #region LoadDetails
        public bool LoadDetails(string ConfigPath, ref DataSet ds, ref string ReturnMessage, ref string CatchMessage)
        {
            bool bReturn = false;

            SqlParameter[] SqlRecordParams = new SqlParameter[5];


            try
            {
                SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;
                SqlRecordParams[1] = new SqlParameter("@menu_id", SqlDbType.Int); SqlRecordParams[1].Value = intMenuID;
                SqlRecordParams[2] = new SqlParameter("@user_id", SqlDbType.UniqueIdentifier); SqlRecordParams[2].Value = UserID;
                SqlRecordParams[3] = new SqlParameter("@error_code", SqlDbType.VarChar, 10); SqlRecordParams[3].Direction = ParameterDirection.Output;
                SqlRecordParams[4] = new SqlParameter("@return_status", SqlDbType.Int); SqlRecordParams[4].Direction = ParameterDirection.Output;

                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "master_transciptionists_fetch_dtls", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Details";
                    ds.Tables[1].TableName = "Country";
                    ds.Tables[2].TableName = "States";

                    #region Details

                    foreach (DataRow dr in ds.Tables["Details"].Rows)
                    {
                        strCode             = Convert.ToString(dr["code"]).Trim();
                        strFname            = Convert.ToString(dr["fname"]).Trim();
                        strLname            = Convert.ToString(dr["lname"]).Trim();
                        strName             = Convert.ToString(dr["name"]).Trim();
                        strAddress1         = Convert.ToString(dr["address_1"]).Trim();
                        strAddress2         = Convert.ToString(dr["address_2"]).Trim();
                        strCity             = Convert.ToString(dr["city"]).Trim();
                        intStateID          = Convert.ToInt32(dr["state_id"]);
                        intCountryID        = Convert.ToInt32(dr["country_id"]);
                        strZip              = Convert.ToString(dr["zip"]).Trim();
                        strEmail            = Convert.ToString(dr["email_id"]).Trim();
                        strPhone            = Convert.ToString(dr["phone_no"]).Trim();
                        strMobile           = Convert.ToString(dr["mobile_no"]).Trim();

                        LoginUserId         = new Guid(Convert.ToString(dr["login_user_id"]));
                        strLoginID          = Convert.ToString(dr["login_id"]).Trim();
                        if (Convert.ToString(dr["login_pwd"]).Trim() != string.Empty) 
                            strPwd          = CoreCommon.DecryptString(Convert.ToString(dr["login_pwd"]).Trim());
                        else 
                            strPwd          = string.Empty;
                        strNotificationPref = Convert.ToString(dr["notification_pref"]).Trim();
                        strNotes            = Convert.ToString(dr["notes"]).Trim();
                        strIsActive         = Convert.ToString(dr["is_active"]).Trim();
                    }

                    #endregion

                    bReturn = true;
                }
                else
                {
                    bReturn = false;
                    ReturnMessage = Convert.ToString(SqlRecordParams[3].Value);
                }

            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #region LoadModality
        public bool LoadModality(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;
            SqlParameter[] SqlRecordParams = new SqlParameter[1];
            SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;

            try
            {
                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, "master_transcriptionist_modality_fetch", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Modality";
                }
                bReturn = true;
            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #region FetchCountryWiseStates
        public bool FetchCountryWiseStates(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;

            SqlParameter[] SqlRecordParams = new SqlParameter[1];


            try
            {
                SqlRecordParams[0] = new SqlParameter("@country_id", SqlDbType.Int); SqlRecordParams[0].Value = intCountryID;

                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "country_wise_state_fetch", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "States";
                    bReturn = true;
                }
                else
                {
                    bReturn = false;
                }

            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #region SaveRecord
        public bool SaveRecord(string ConfigPath, TranscriptionistModalityList[] ArrObj, ref string ReturnMessage, ref string CatchMessage)
        {
            bool bReturn = false;
            int intReturnValue = 0; int intExecReturn = 0;

            if (ValidateRecord(ArrObj,ref ReturnMessage))
            {
                if (GenerateModalityXML(ArrObj, ref CatchMessage))
                {
                    try
                    {
                        SqlParameter[] SqlRecordParams = new SqlParameter[23];
                        SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value                  = Id; SqlRecordParams[0].Direction = ParameterDirection.InputOutput;
                        SqlRecordParams[1] = new SqlParameter("@fname", SqlDbType.NVarChar, 80); SqlRecordParams[1].Value                   = strFname;
                        SqlRecordParams[2] = new SqlParameter("@lname", SqlDbType.NVarChar, 80); SqlRecordParams[2].Value                   = strLname;
                        SqlRecordParams[3] = new SqlParameter("@address_Line1", SqlDbType.NVarChar, 100); SqlRecordParams[3].Value          = strAddress1;
                        SqlRecordParams[4] = new SqlParameter("@address_Line2", SqlDbType.NVarChar, 100); SqlRecordParams[4].Value          = strAddress2;
                        SqlRecordParams[5] = new SqlParameter("@city", SqlDbType.NVarChar, 100); SqlRecordParams[5].Value                   = strCity;
                        SqlRecordParams[6] = new SqlParameter("@zip", SqlDbType.NVarChar, 20); SqlRecordParams[6].Value                     = strZip;
                        SqlRecordParams[7] = new SqlParameter("@state_id", SqlDbType.Int); SqlRecordParams[7].Value                         = intStateID;
                        SqlRecordParams[8] = new SqlParameter("@country_id", SqlDbType.Int); SqlRecordParams[8].Value                       = intCountryID;
                        SqlRecordParams[9] = new SqlParameter("@email_id", SqlDbType.NVarChar, 50); SqlRecordParams[9].Value                = strEmail;
                        SqlRecordParams[10] = new SqlParameter("@phone", SqlDbType.NVarChar, 30); SqlRecordParams[10].Value                 = strPhone;
                        SqlRecordParams[11] = new SqlParameter("@mobile", SqlDbType.NVarChar, 20); SqlRecordParams[11].Value                = strMobile;
                        SqlRecordParams[12] = new SqlParameter("@login_id", SqlDbType.NVarChar, 10); SqlRecordParams[12].Value              = strLoginID;
                        SqlRecordParams[13] = new SqlParameter("@login_pwd", SqlDbType.NVarChar, 200); SqlRecordParams[13].Value            = strPwd;
                        SqlRecordParams[14] = new SqlParameter("@is_active", SqlDbType.NChar, 1); SqlRecordParams[14].Value                 = strIsActive;
                        SqlRecordParams[15] = new SqlParameter("@notification_pref", SqlDbType.NChar, 1); SqlRecordParams[15].Value         = strNotificationPref;
                        SqlRecordParams[16] = new SqlParameter("@notes", SqlDbType.NVarChar,500); SqlRecordParams[16].Value                 = strNotes;
                        SqlRecordParams[17] = new SqlParameter("@xml_modality", SqlDbType.NText); SqlRecordParams[17].Value                 = strXML;
                        SqlRecordParams[18] = new SqlParameter("@user_id", SqlDbType.UniqueIdentifier); SqlRecordParams[18].Value           = UserID;
                        SqlRecordParams[19] = new SqlParameter("@menu_id", SqlDbType.Int); SqlRecordParams[19].Value                        = intMenuID;
                        SqlRecordParams[20] = new SqlParameter("@user_name", SqlDbType.NVarChar, 700); SqlRecordParams[20].Direction        = ParameterDirection.Output;
                        SqlRecordParams[21] = new SqlParameter("@error_code", SqlDbType.NVarChar, 10); SqlRecordParams[21].Direction        = ParameterDirection.Output;
                        SqlRecordParams[22] = new SqlParameter("@return_status", SqlDbType.Int); SqlRecordParams[22].Direction              = ParameterDirection.Output;


                        if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                        intExecReturn = DAL.DataHelper.ExecuteNonQuery(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "master_transciptionists_save", SqlRecordParams);
                        intReturnValue = Convert.ToInt32(SqlRecordParams[22].Value);
                        if (intReturnValue == 1)
                            bReturn = true;
                        else
                            bReturn = false;

                        strUserName = Convert.ToString(SqlRecordParams[20].Value).Trim();
                        ReturnMessage = Convert.ToString(SqlRecordParams[21].Value);

                    }
                    catch (Exception expErr)
                    { bReturn = false; CatchMessage = expErr.Message; }

                }
                else
                    bReturn = false;

            }
            else
            {
                bReturn = false;
            }

            return bReturn;
        }
        #endregion

        #region ValidateRecord
        private bool ValidateRecord(TranscriptionistModalityList[] ArrObj, ref string ReturnMessage)
        {
            bool bReturn = true;

            //if (strCode.Trim() == string.Empty)
            //{
            //    ReturnMessage = "075";
            //}
            if ((strFname.Trim() + " " + strLname.Trim()).Trim() == string.Empty)
            {
                if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                ReturnMessage = "076";
            }
            if ((strNotificationPref == "E") || (strNotificationPref == "B"))
            {
                if (strEmail.Trim() == string.Empty)
                {
                    if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                    ReturnMessage = "082";
                }
                else
                {
                    if (!CoreCommon.IsEmailValid(strEmail))
                    {
                        if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                        ReturnMessage += "084";
                    }
                }
            }

            if ((strNotificationPref == "S") || (strNotificationPref == "B"))
            {
                if (strMobile.Trim() == string.Empty)
                {
                    if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                    ReturnMessage = "090";
                }
            }

            if (strLoginID.Trim() == string.Empty)
            {
                if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                ReturnMessage = "112";
            }
            if (strPwd.Trim() == string.Empty)
            {
                if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                ReturnMessage = "120";
            }
            if (strNotes.Trim() != string.Empty)
            {
                if (strNotes.Trim().Length > 500)
                {
                    if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                    ReturnMessage = "322";
                }
            }
            if (ArrObj.Length == 0)
            {
                if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                ReturnMessage = "205";
            }

            if (ReturnMessage.Trim() != string.Empty)
                bReturn = false;

            return bReturn;
        }

        #endregion

        #region GenerateModalityXML
        private bool GenerateModalityXML(TranscriptionistModalityList[] ArrObj, ref string CatchMessage)
        {
            bool bReturn = false;
            StringBuilder sbXML = new StringBuilder();

            try
            {
                if (ArrObj.Length > 0)
                {

                    sbXML.Append("<modality>");

                    for (int i = 0; i < ArrObj.Length; i = i + 1)
                    {
                        sbXML.Append("<row>");
                        sbXML.Append("<modality_id>" + ArrObj[i].ID.ToString() + "</modality_id>");
                        sbXML.Append("<default_fee>" + ArrObj[i].DEFAULT_FEE.ToString() + "</default_fee>");
                        sbXML.Append("<addl_STAT_fee>" + ArrObj[i].ADDITION_FEE_FOR_STAT_PRELIM.ToString() + "</addl_STAT_fee>");
                        sbXML.Append("<row_id>" + Convert.ToString(i + 1) + "</row_id>");
                        sbXML.Append("</row>");
                    }

                    sbXML.Append("</modality>");
                    strXML = sbXML.ToString();


                }
                bReturn = true;
            }
            catch (Exception LexpErr)
            {
                bReturn = false;
                CatchMessage = LexpErr.Message;
            }
            return bReturn;
        }
        #endregion

        #endregion
    }

    public class TranscriptionistModalityList
    {
        #region Constructor
        public TranscriptionistModalityList()
        {
        }
        #endregion

        #region Variables
        int inID = 0;
        int intSrlNo = 0;
        double dblDefaultFee = 0;
        double dblAddlFee = 0;
        #endregion

        #region Properties
        public int ID
        {
            get { return inID; }
            set { inID = value; }
        }
        public int SERIAL_NUMBER
        {
            get { return intSrlNo; }
            set { intSrlNo = value; }
        }
        public double DEFAULT_FEE
        {
            get { return dblDefaultFee; }
            set { dblDefaultFee = value; }
        }
        public double ADDITION_FEE_FOR_STAT_PRELIM
        {
            get { return dblAddlFee; }
            set { dblAddlFee = value; }
        }
        #endregion
    }
}
