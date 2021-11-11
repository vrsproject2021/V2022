using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using VETRIS.DAL;

namespace VETRIS.Core.HouseKeeping
{
    public class StudyAuditTrail
    {
        #region Constructor
        public StudyAuditTrail()
        {
        }
        #endregion

        #region Variables
        int intMenuID = 0;
        Guid UserID = new Guid("00000000-0000-0000-0000-000000000000");
        int intUserRoleID = 0;
        string strUserName = string.Empty;

        Guid Id = new Guid("00000000-0000-0000-0000-000000000000");
        string strPatientID = string.Empty;
        string strPatientIDPACS = string.Empty;
        string strStudyUID = string.Empty;
        string strStudyDesc = string.Empty;
        string strAccnNoPACS = string.Empty;
        string strAccnNo = string.Empty;
        int intModalityID = 0;
        string strModality = string.Empty;
        string strModalityName = string.Empty;
        int intBodyPartID = 0;
        string strBodyPart = string.Empty;
        string strBodyPartName = string.Empty;
        int intStatus = 0;
        string strStatusDesc = string.Empty;
        string strFilterStudyDt = "N";
        string strFilterRecDt = "N";
        DateTime dtRecDateFrom = DateTime.Today.AddDays(-7);
        DateTime dtRecDateTill = DateTime.Today;
        DateTime dtStudyDateFrom = DateTime.Today.AddDays(-7);
        DateTime dtStudyDateTill = DateTime.Today;
        DateTime dtStudyDate = DateTime.Today;
        string strPatientName = string.Empty;
        string strPatientNamePACS = string.Empty;
        DateTime dtPatientDobPACS = DateTime.Today;
        string strPatientGender = string.Empty;
        string strPatientGenderPACS = string.Empty;
        string strSexNeutered = string.Empty;
        string strSexNeuteredPACS = string.Empty;
        DateTime dtPatientDob = DateTime.Today;
        int strPatientAgePACS = 0;
        string strPatientAge = string.Empty;
        decimal decPatientWt = 0;
        decimal decPatientWtPACS = 0;
        string strWtUOM = string.Empty;

        string strOwnerPACS = string.Empty;
        string strOwnerFN = string.Empty;
        string strOwnerLN = string.Empty;
        string strSpeciesPACS = string.Empty;
        int intSpeciesID = 0;
        string strSpeciesName = string.Empty;
        string strBreedPACS = string.Empty;
        Guid BreedID = new Guid("00000000-0000-0000-0000-000000000000");
        string strBreedName = string.Empty;
        Guid InstitutionID = new Guid("00000000-0000-0000-0000-000000000000");
        string strInstitutionName = string.Empty;
        string strInstitutionPACS = string.Empty;
        string strInstitutionEmailID = string.Empty;
        string strInstitutionMobileNo = string.Empty;
        Guid PhysicianID = new Guid("00000000-0000-0000-0000-000000000000");
        string strPhysicianName = string.Empty;
        string strRefPhy = string.Empty;
        string strPhysicianEmailID = string.Empty;
        string strPhysicianMobileNo = string.Empty;
        Guid StudyTypeID = new Guid("00000000-0000-0000-0000-000000000000");
        string strStudyTypeName = string.Empty;

        int intStatusIDPACS = 0;
        string strReason = string.Empty;
        string strReasonPACS = string.Empty;
        string strPhysNote = string.Empty;
        int intImgCntPACS = 0;
        int intImgCnt = 0;
        int intObjCnt = 0;
        string strImgCntAccepted = "N";
        string strWriteBack = "N";
        string strPACSURL = string.Empty;
        string strIMGVWRURL = string.Empty;
        string strRadiologistName = string.Empty;
        string strPrelimRpt = string.Empty;
        string strFinalRpt = string.Empty;
        string strPACIMGCNTURL = string.Empty;
        int intPriorityID = 0;
        string strPriorityDesc = string.Empty;
        string strTrackBy = "I";
        #endregion

        #region Properties
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string MergeStatus { get; set; }
        public Guid USER_SESSION_ID { get; set; }
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
        public string PATIENT_ID
        {
            get { return strPatientID; }
            set { strPatientID = value; }
        }
        public string PATIENT_ID_PACS
        {
            get { return strPatientIDPACS; }
            set { strPatientIDPACS = value; }
        }
        public string PATIENT_NAME
        {
            get { return strPatientName; }
            set { strPatientName = value; }
        }
        public string PATIENT_NAME_PACS
        {
            get { return strPatientNamePACS; }
            set { strPatientNamePACS = value; }
        }
        public string PATIENT_GENDER
        {
            get { return strPatientGender; }
            set { strPatientGender = value; }
        }
        public string PATIENT_GENDER_PACS
        {
            get { return strPatientGenderPACS; }
            set { strPatientGenderPACS = value; }
        }
        public string SEX_NEUTERED
        {
            get { return strSexNeutered; }
            set { strSexNeutered = value; }
        }
        public string SEX_NEUTERED_PACS
        {
            get { return strSexNeuteredPACS; }
            set { strSexNeuteredPACS = value; }
        }
        public DateTime PATIENT_DOB
        {
            get { return dtPatientDob; }
            set { dtPatientDob = value; }
        }
        public DateTime PATIENT_DOB_PACS
        {
            get { return dtPatientDobPACS; }
            set { dtPatientDobPACS = value; }
        }
        public decimal PATIENT_WEIGHT
        {
            get { return decPatientWt; }
            set { decPatientWt = value; }
        }
        public decimal PATIENT_WEIGHT_PACS
        {
            get { return decPatientWtPACS; }
            set { decPatientWtPACS = value; }
        }
        public string WEIGHT_UOM
        {
            get { return strWtUOM; }
            set { strWtUOM = value; }
        }
        public int PATIENT_AGE_PACS
        {
            get { return strPatientAgePACS; }
            set { strPatientAgePACS = value; }
        }
        public string PATIENT_AGE
        {
            get { return strPatientAge; }
            set { strPatientAge = value; }
        }
        public string OWNER_NAME_PACS
        {
            get { return strOwnerPACS; }
            set { strOwnerPACS = value; }
        }
        public string OWNER_FIRST_NAME
        {
            get { return strOwnerFN; }
            set { strOwnerFN = value; }
        }
        public string OWNER_LAST_NAME
        {
            get { return strOwnerLN; }
            set { strOwnerLN = value; }
        }
        public int SPECIES_ID
        {
            get { return intSpeciesID; }
            set { intSpeciesID = value; }
        }
        public string SPECIES_NAME
        {
            get { return strSpeciesName; }
            set { strSpeciesName = value; }
        }
        public string SPECIES_PACS
        {
            get { return strSpeciesPACS; }
            set { strSpeciesPACS = value; }
        }
        public Guid BREED_ID
        {
            get { return BreedID; }
            set { BreedID = value; }
        }
        public string BREED_NAME
        {
            get { return strBreedName; }
            set { strBreedName = value; }
        }
        public string BREED_PACS
        {
            get { return strBreedPACS; }
            set { strBreedPACS = value; }
        }
        public Guid PHYSICIAN_ID
        {
            get { return PhysicianID; }
            set { PhysicianID = value; }
        }
        public string PHYSICIAN_NAME
        {
            get { return strPhysicianName; }
            set { strPhysicianName = value; }
        }
        public string REFERRING_PHYSICIAN
        {
            get { return strRefPhy; }
            set { strRefPhy = value; }
        }
        public string PHYSICIAN_EMAIL_ID
        {
            get { return strPhysicianEmailID; }
            set { strPhysicianEmailID = value; }
        }
        public string PHYSICIAN_MOBILE_NUMBER
        {
            get { return strPhysicianMobileNo; }
            set { strPhysicianMobileNo = value; }
        }
        public string STUDY_UID
        {
            get { return strStudyUID; }
            set { strStudyUID = value; }
        }
        public string ACCESSION_NO_PACS
        {
            get { return strAccnNoPACS; }
            set { strAccnNoPACS = value; }
        }
        public string ACCESSION_NO
        {
            get { return strAccnNo; }
            set { strAccnNo = value; }
        }
        public string STUDY_DESCRIPTION
        {
            get { return strStudyDesc; }
            set { strStudyDesc = value; }
        }
        public int MODALITY_ID
        {
            get { return intModalityID; }
            set { intModalityID = value; }
        }
        public string MODALITY_NAME
        {
            get { return strModalityName; }
            set { strModalityName = value; }
        }
        public string MODALITY
        {
            get { return strModality; }
            set { strModality = value; }
        }
        public int BODY_PART_ID
        {
            get { return intBodyPartID; }
            set { intBodyPartID = value; }
        }
        public string BODY_PART_NAME
        {
            get { return strBodyPartName; }
            set { strBodyPartName = value; }
        }
        public string BODY_PART
        {
            get { return strBodyPart; }
            set { strBodyPart = value; }
        }
        public int STATUS
        {
            get { return intStatus; }
            set { intStatus = value; }
        }
        public string STATUS_DESC
        {
            get { return strStatusDesc; }
            set { strStatusDesc = value; }
        }
        public string FILTER_BY_RECEIVED_DATE
        {
            get { return strFilterRecDt; }
            set { strFilterRecDt = value; }
        }
        public DateTime RECEIVED_DATE_FROM
        {
            get { return dtRecDateFrom; }
            set { dtRecDateFrom = value; }
        }
        public DateTime RECEIVED_DATE_TILL
        {
            get { return dtRecDateTill; }
            set { dtRecDateTill = value; }
        }
        public string FILTER_BY_STUDY_DATE
        {
            get { return strFilterStudyDt; }
            set { strFilterStudyDt = value; }
        }
        public DateTime STUDY_DATE_FROM
        {
            get { return dtStudyDateFrom; }
            set { dtStudyDateFrom = value; }
        }
        public DateTime STUDY_DATE_TILL
        {
            get { return dtStudyDateTill; }
            set { dtStudyDateTill = value; }
        }
        public DateTime STUDY_DATE
        {
            get { return dtStudyDate; }
            set { dtStudyDate = value; }
        }
        public Guid INSTITUTION_ID
        {
            get { return InstitutionID; }
            set { InstitutionID = value; }
        }
        public string INSTITUTION_NAME
        {
            get { return strInstitutionName; }
            set { strInstitutionName = value; }
        }
        public string INSTITUTION_PACS
        {
            get { return strInstitutionPACS; }
            set { strInstitutionPACS = value; }
        }
        public string INSTITUTION_EMAIL_ID
        {
            get { return strInstitutionEmailID; }
            set { strInstitutionEmailID = value; }
        }
        public string INSTITUTION_MOBILE_NUMBER
        {
            get { return strInstitutionMobileNo; }
            set { strInstitutionMobileNo = value; }
        }
        public string REASON
        {
            get { return strReason; }
            set { strReason = value; }
        }
        public string REASON_PACS
        {
            get { return strReasonPACS; }
            set { strReasonPACS = value; }
        }
        public string PHYSICIAN_NOTE
        {
            get { return strPhysNote; }
            set { strPhysNote = value; }
        }
        public int IMAGE_COUNT
        {
            get { return intImgCnt; }
            set { intImgCnt = value; }
        }
        public int IMAGE_COUNT_PACS
        {
            get { return intImgCntPACS; }
            set { intImgCntPACS = value; }
        }
        public int OBJECT_COUNT
        {
            get { return intObjCnt; }
            set { intObjCnt = value; }
        }
        public string IMAGE_COUNT_ACCEPTED
        {
            get { return strImgCntAccepted; }
            set { strImgCntAccepted = value; }
        }
        public string WRITE_BACK
        {
            get { return strWriteBack; }
            set { strWriteBack = value; }
        }
        public Guid STUDY_TYPE_ID
        {
            get { return StudyTypeID; }
            set { StudyTypeID = value; }
        }
        public string STUDY_TYPE_NAME
        {
            get { return strStudyTypeName; }
            set { strStudyTypeName = value; }
        }
        public string PACS_URL
        {
            get { return strPACSURL; }
            set { strPACSURL = value; }
        }
        public string PACS_IMAGE_VIEWER_URL
        {
            get { return strIMGVWRURL; }
            set { strIMGVWRURL = value; }
        }
        public int PACS_STATUS_ID
        {
            get { return intStatusIDPACS; }
            set { intStatusIDPACS = value; }
        }
        public string RADIOLOGIST_NAME
        {
            get { return strRadiologistName; }
            set { strRadiologistName = value; }
        }
        public string PRELIMINARY_REPORT
        {
            get { return strPrelimRpt; }
            set { strPrelimRpt = value; }
        }
        public string FINAL_REPORT
        {
            get { return strFinalRpt; }
            set { strFinalRpt = value; }
        }
        public string PACS_IMAGE_COUNT_URL
        {
            get { return strPACIMGCNTURL; }
            set { strPACIMGCNTURL = value; }
        }
        public int PRIORITY_ID
        {
            get { return intPriorityID; }
            set { intPriorityID = value; }
        }
        public string PRIORITY_DESCRIPTION
        {
            get { return strPriorityDesc; }
            set { strPriorityDesc = value; }
        }
        #endregion

        #region Browser Methods

        #region FetchBrowserParameters
        public bool FetchBrowserParameters(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;
            SqlParameter[] SqlRecordParams = new SqlParameter[1];

            try
            {
                SqlRecordParams[0] = new SqlParameter("@user_id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = UserID;

                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "case_list_brw_fetch_params", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Modality";
                    ds.Tables[1].TableName = "Species";
                    ds.Tables[2].TableName = "Institutions";
                    ds.Tables[3].TableName = "InProgressStatus";
                    ds.Tables[4].TableName = "Status";
                    ds.Tables[6].TableName = "Category";
                    ds.Tables[7].TableName = "Priority";
                    ds.Tables[8].TableName = "APIParams";
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
            SqlParameter[] SqlRecordParams = new SqlParameter[10];
            SqlRecordParams[0] = new SqlParameter("@study_uid", SqlDbType.NVarChar, 100); SqlRecordParams[0].Value = strStudyUID;
            SqlRecordParams[1] = new SqlParameter("@patient_name", SqlDbType.NVarChar, 100); SqlRecordParams[1].Value = strPatientName;
            SqlRecordParams[2] = new SqlParameter("@modality_id", SqlDbType.Int); SqlRecordParams[2].Value = intModalityID;
            SqlRecordParams[3] = new SqlParameter("@institution_id", SqlDbType.UniqueIdentifier); SqlRecordParams[3].Value = InstitutionID;
            SqlRecordParams[4] = new SqlParameter("@consider_received_date", SqlDbType.NChar, 1); SqlRecordParams[4].Value = strFilterStudyDt;
            SqlRecordParams[5] = new SqlParameter("@received_date_from", SqlDbType.DateTime); SqlRecordParams[5].Value = dtStudyDateFrom;
            SqlRecordParams[6] = new SqlParameter("@received_date_till", SqlDbType.DateTime); SqlRecordParams[6].Value = dtStudyDateTill;
            SqlRecordParams[7] = new SqlParameter("@status_id", SqlDbType.Int); SqlRecordParams[7].Value = intStatusIDPACS;
            SqlRecordParams[8] = new SqlParameter("@user_id", SqlDbType.UniqueIdentifier); SqlRecordParams[8].Value = UserID;
            SqlRecordParams[9] = new SqlParameter("@priority_id", SqlDbType.Int); SqlRecordParams[9].Value = intPriorityID;


            try
            {
                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, "hk_study_status_audit_trail_fetch_brw", SqlRecordParams);
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

        #region FetchAuditTrail
        public bool FetchAuditTrail(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;
            SqlParameter[] SqlRecordParams = new SqlParameter[1];

            try
            {
                SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;

                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "hk_study_status_audit_trail_fetch", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "AuditTrail";
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

        #region LoadHeader
        public bool LoadHeader(string ConfigPath, ref DataSet ds, ref string ReturnMessage, ref string CatchMessage)
        {
            bool bReturn = false; string strControlCode = string.Empty;

            SqlParameter[] SqlRecordParams = new SqlParameter[1];


            try
            {
                SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;


                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "hk_study_hdr_fetch", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Details";

                    #region Details

                    foreach (DataRow dr in ds.Tables["Details"].Rows)
                    {

                        strStudyUID = Convert.ToString(dr["study_uid"]).Trim();
                        dtStudyDate = Convert.ToDateTime(dr["study_date"]);
                        strStudyDesc = Convert.ToString(dr["study_desc"]).Trim();
                        strAccnNo = Convert.ToString(dr["accession_no"]).Trim();
                        strPatientID = Convert.ToString(dr["patient_id"]).Trim();
                        strPatientName = Convert.ToString(dr["patient_name"]).Trim();
                        strPatientGender = Convert.ToString(dr["patient_sex"]).Trim();
                        strSexNeutered = Convert.ToString(dr["sex_neutered_accepted"]).Trim();
                        decPatientWt = Convert.ToDecimal(dr["patient_weight"]);
                        strWtUOM = Convert.ToString(dr["wt_uom"]).Trim();
                        dtPatientDob = Convert.ToDateTime(dr["patient_dob_accepted"]);
                        strPatientAge = Convert.ToString(dr["patient_age_accepted"]);
                        strOwnerFN = Convert.ToString(dr["owner_first_name"]).Trim();
                        strOwnerLN = Convert.ToString(dr["owner_last_name"]).Trim();
                        intSpeciesID = Convert.ToInt32(dr["species_id"]);
                        strSpeciesName = Convert.ToString(dr["species_name"]).Trim();
                        BreedID = new Guid(Convert.ToString(dr["breed_id"]));
                        strBreedName = Convert.ToString(dr["breed_name"]).Trim();
                        intModalityID = Convert.ToInt32(dr["modality_id"]);
                        strModalityName = Convert.ToString(dr["modality_name"]).Trim();
                        InstitutionID = new Guid(Convert.ToString(dr["institution_id"]));
                        strInstitutionName = Convert.ToString(dr["institution_name"]).Trim();
                        PhysicianID = new Guid(Convert.ToString(dr["physician_id"]));
                        strPhysicianName = Convert.ToString(dr["physician_name"]).Trim();
                        strReason = Convert.ToString(dr["reason_accepted"]).Trim();
                        intImgCnt = Convert.ToInt32(dr["img_count"]);
                        intObjCnt = Convert.ToInt32(dr["object_count"]);
                        strImgCntAccepted = Convert.ToString(dr["img_count_accepted"]).Trim();
                        intPriorityID = Convert.ToInt32(dr["priority_id"]);
                        strPriorityDesc = Convert.ToString(dr["priority_desc"]).Trim();
                        strPhysNote = Convert.ToString(dr["physician_note"]).Trim();

                        Country = Convert.ToString(dr["country"]).Trim();
                        State = Convert.ToString(dr["state"]).Trim();
                        City = Convert.ToString(dr["patient_city"]).Trim();
                        
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

        #region LoadStudyTypes
        public bool LoadStudyTypes(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;
            SqlParameter[] SqlRecordParams = new SqlParameter[2];
            SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;
            SqlRecordParams[1] = new SqlParameter("@modality_id", SqlDbType.Int); SqlRecordParams[1].Value = intModalityID;

            try
            {
                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, "hk_study_types_fetch", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "StudyTypes";
                    ds.Tables[1].TableName = "TrackBy";
                }
                bReturn = true;
            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #region LoadHeaderDocuments
        public bool LoadHeaderDocuments(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;
            SqlParameter[] SqlRecordParams = new SqlParameter[1];
            SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;


            try
            {
                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, "hk_documents_fetch", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Documents";
                }
                bReturn = true;
            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #endregion

        #region SaveRecord
        public bool SaveRecord(string ConfigPath, Core.Case.HeaderDocumentList[] ArrObjDocs, Core.Case.HeaderDICOMList[] ArrObjDCM, ref string ReturnMessage, ref string CatchMessage)
        {
            bool bReturn = false;
            DataTable dtblDoc = new DataTable();
            DataTable dtblDCM = new DataTable();
            int intReturnValue = 0; int intExecReturn = 0;
            if ( (GenerateDocumentTable(ArrObjDocs, ref dtblDoc, ref CatchMessage)) && (GenerateDCMTable(ArrObjDCM, ref dtblDCM, ref CatchMessage)))
            {
                if (ValidateRecord(ref ReturnMessage))
                {

                    SqlParameter[] SqlRecordParams = new SqlParameter[12];
                    try
                    {
                        SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;
                        SqlRecordParams[1] = new SqlParameter("@reason_accepted", SqlDbType.NVarChar, 2000); SqlRecordParams[1].Value = strReason;
                        SqlRecordParams[2] = new SqlParameter("@updated_by", SqlDbType.UniqueIdentifier); SqlRecordParams[2].Value = UserID;
                        SqlRecordParams[3] = new SqlParameter("@menu_id", SqlDbType.Int); SqlRecordParams[3].Value = intMenuID;
                        SqlRecordParams[4] = new SqlParameter("@session_id", SqlDbType.UniqueIdentifier); SqlRecordParams[4].Value = USER_SESSION_ID;
                        SqlRecordParams[5] = new SqlParameter("@physician_note", SqlDbType.NVarChar, 2000); SqlRecordParams[5].Value = strPhysNote;
                        SqlRecordParams[6] = new SqlParameter("@TVP_docs", SqlDbType.Structured); SqlRecordParams[6].Value = dtblDoc;
                        SqlRecordParams[7] = new SqlParameter("@TVP_dcm", SqlDbType.Structured); SqlRecordParams[7].Value = dtblDCM;
                        SqlRecordParams[8] = new SqlParameter("@message_display", SqlDbType.NVarChar, 500); SqlRecordParams[8].Direction = ParameterDirection.Output;
                        SqlRecordParams[9] = new SqlParameter("@user_name", SqlDbType.NVarChar, 500); SqlRecordParams[9].Direction = ParameterDirection.Output;
                        SqlRecordParams[10] = new SqlParameter("@error_code", SqlDbType.VarChar, 500); SqlRecordParams[10].Direction = ParameterDirection.Output;
                        SqlRecordParams[11] = new SqlParameter("@return_status", SqlDbType.Int); SqlRecordParams[11].Direction = ParameterDirection.Output;

                        if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                        intExecReturn = DAL.DataHelper.ExecuteNonQuery(CoreCommon.CONNECTION_STRING, CommandType.StoredProcedure, "hk_study_status_audit_trail_save", SqlRecordParams);
                        intReturnValue = Convert.ToInt32(SqlRecordParams[11].Value);
                        if (intReturnValue == 1)
                            bReturn = true;
                        else
                            bReturn = false;
                        strUserName = Convert.ToString(SqlRecordParams[9].Value).Trim();
                        ReturnMessage = Convert.ToString(SqlRecordParams[10].Value);

                    }
                    catch (Exception expErr)
                    { bReturn = false; CatchMessage = expErr.Message; }

                }
                else
                {
                    bReturn = false;
                }
            }
            return bReturn;
        }
        #endregion

        #region ValidateRecord
        private bool ValidateRecord( ref string ReturnMessage)
        {
            bool bReturn = true;
           
            if (strReason.Trim().Length > 2000)
            {
                if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                ReturnMessage += "085";
                bReturn = false;
            }

            if (strPhysNote.Trim().Length > 2000)
            {
                if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                ReturnMessage += "288";
                bReturn = false;
            }
           
            //if (strWriteBack.Trim() == "Y")
            //{
                if (strReason.Trim() == string.Empty)
                {
                    if (ReturnMessage != string.Empty) ReturnMessage += CoreCommon.STRING_DIVIDER;
                    ReturnMessage += "077";
                    bReturn = false;
                }

            //}
            return bReturn;
        }

        #endregion

        #region LoadStudyFiles
        public bool LoadStudyFiles(string ConfigPath, ref DataSet ds, ref string CatchMessage)
        {
            bool bReturn = false;
            SqlParameter[] SqlRecordParams = new SqlParameter[1];
            SqlRecordParams[0] = new SqlParameter("@id", SqlDbType.UniqueIdentifier); SqlRecordParams[0].Value = Id;


            try
            {
                if (CoreCommon.CONNECTION_STRING == string.Empty) CoreCommon.GetConnectionString(ConfigPath);
                ds = DAL.DataHelper.ExecuteDataset(CoreCommon.CONNECTION_STRING, "case_list_fetch_study_files", SqlRecordParams);
                if (ds.Tables.Count > 0)
                {
                    ds.Tables[0].TableName = "Files";
                }
                bReturn = true;
            }
            catch (Exception expErr)
            { bReturn = false; CatchMessage = expErr.Message; }


            return bReturn;
        }
        #endregion

        #region GenerateDocumentTable
        private bool GenerateDocumentTable(Core.Case.HeaderDocumentList[] ArrObj, ref DataTable dtblDoc, ref string CatchMessage)
        {
            bool bReturn = false;

            dtblDoc.Columns.Add("document_id", System.Type.GetType("System.Guid"));
            dtblDoc.Columns.Add("document_name", System.Type.GetType("System.String"));
            dtblDoc.Columns.Add("document_srl_no", System.Type.GetType("System.Int32"));
            dtblDoc.Columns.Add("document_link", System.Type.GetType("System.String"));
            dtblDoc.Columns.Add("document_file_type", System.Type.GetType("System.String"));
            dtblDoc.Columns.Add("document_file", System.Type.GetType("System.Byte[]"));


            try
            {
                if (ArrObj.Length > 0)
                {
                    for (int i = 0; i < ArrObj.Length; i++)
                    {
                        DataRow dr = dtblDoc.NewRow();
                        dr["document_id"] = ArrObj[i].ID;
                        dr["document_name"] = ArrObj[i].NAME;
                        dr["document_srl_no"] = ArrObj[i].SERIAL_NUMBER;
                        dr["document_link"] = ArrObj[i].FILE_NAME;
                        dr["document_file_type"] = ArrObj[i].FILE_TYPE;
                        dr["document_file"] = ArrObj[i].FILE_CONTENT;
                        dtblDoc.Rows.Add(dr);
                    }

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

        #region GenerateDCMTable
        private bool GenerateDCMTable(Core.Case.HeaderDICOMList[] ArrObj, ref DataTable dtblDCM, ref string CatchMessage)
        {
            bool bReturn = false;

            dtblDCM.Columns.Add("dcm_file_id", System.Type.GetType("System.Guid"));
            dtblDCM.Columns.Add("dcm_file_srl_no", System.Type.GetType("System.Int32"));
            dtblDCM.Columns.Add("dcm_file_name", System.Type.GetType("System.String"));
            dtblDCM.Columns.Add("dcm_file", System.Type.GetType("System.Byte[]"));


            try
            {
                if (ArrObj.Length > 0)
                {
                    for (int i = 0; i < ArrObj.Length; i++)
                    {
                        DataRow dr = dtblDCM.NewRow();
                        dr["dcm_file_id"] = ArrObj[i].ID;
                        dr["dcm_file_srl_no"] = ArrObj[i].SERIAL_NUMBER;
                        dr["dcm_file_name"] = ArrObj[i].FILE_NAME;
                        dr["dcm_file"] = ArrObj[i].FILE_CONTENT;
                        dtblDCM.Rows.Add(dr);
                    }

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
    }
}
