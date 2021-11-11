﻿var REFRESH_LIST = "N"; var DLPROC = "N"; var SYID = ""; var ROWID = "";
$(document).ready($(function () {
    window.scrollTo(0, 0);
}))
function view_Searchform() {
    $("#searchSection").slideToggle(800);
    $("#searchIcon").toggleClass("icon", 800);
}

function CheckError() {
    var arrErr = new Array();
    if (parent.Trim(objhdnError.value) != "") {
        arrErr = objhdnError.value.split(Divider);
        switch (arrErr[0]) {
            case "catch":
            case "false":
                parent.PopupMessage(RootDirectory, strForm, "OnLoad()", arrErr[1], "true");
                break;
        }
    }
    objhdnError.value = "";
    if (UserRoleCode != "RDL") {
        document.getElementById("divRadiologist").style.display = "inline";
        document.getElementById("divCategory").style.display = "inline";
    }
    if (objhdnSCHCASVCENBL.value == "N") {
        objbtnDV.style.display = "inline";
    }
    if (UserRoleCode == "SUPP") {
        $('#divLblStudyUID').css('display', 'block');
        $('#divTxtStudyUID').css('display', 'block');
    } else {
        $('#divLblStudyUID').css('display', 'none');
        $('#divTxtStudyUID').css('display', 'none');
    }
    //alert(document.getElementById("grdBrw").style.bottom);
}
function SetFilterValues() {
    if (parent.GsFilter.length > 0) {
        objtxtPatientName.value = parent.GsFilter[0];
        objddlModality.value = parent.GsFilter[1];
        if (parent.GsFilter[2] == "Y") objchkRecDt.checked = true;
        objtxtFromDt.value = parent.GsFilter[3];
        objtxtTillDt.value = parent.GsFilter[4];
        objddlInstitution.value = parent.GsFilter[5];
        objddlStatus.value = parent.GsFilter[6];
        objddlCategory.value = parent.GsFilter[7];
        objddlRadiologist.value = parent.GsFilter[8];
        objddlSpecies.value = parent.GsFilter[9];
        objddlPriority.value=parent.GsFilter[10];
        objtxtStudyUID.value=parent.GsFilter[11];
    }
    else
        parent.GsFilter.length = 0;
}
function SearchRecord() {
    var ArrRecords = new Array();
    var strDtFrom = ""; var strDtTill = "";
    var AccessLockedStudy = "N";
    var RadFnRights = objhdnRadFnRights.value;
    if (RadFnRights.indexOf("ACCLOCKSTUDY") > -1) {
        AccessLockedStudy = "Y";
    }

    if (parent.Trim(objtxtFromDt.value) == "") strDtFrom = "01Jan1900";
    else {
        if (document.all)
            strDtFrom = parent.SetDateFormat(objtxtFromDt.value, parent.GsDateFormat, parent.GsDateSep);
        else
            strDtFrom = parent.SetDateFormat1(objtxtFromDt.value, parent.GsDateFormat, parent.GsDateSep);
    }

    if (parent.Trim(objtxtTillDt.value) == "") strDtTill = "01Jan1900";
    else {
        if (document.all)
            strDtTill = parent.SetDateFormat(objtxtTillDt.value, parent.GsDateFormat, parent.GsDateSep);
        else
            strDtTill = parent.SetDateFormat1(objtxtTillDt.value, parent.GsDateFormat, parent.GsDateSep);
    }
    
    ArrRecords[0] = objtxtPatientName.value;
    ArrRecords[1] = objddlModality.value;
    ArrRecords[2] = "N"; if (objchkRecDt.checked) ArrRecords[2] = "Y";
    ArrRecords[3] = strDtFrom;
    ArrRecords[4] = strDtTill;
    ArrRecords[5] = objddlInstitution.value;
    ArrRecords[6] = objddlStatus.value;
    ArrRecords[7] = objddlCategory.value;
    ArrRecords[8] = objddlRadiologist.value;
    ArrRecords[9] = objddlSpecies.value;
    ArrRecords[10] = AccessLockedStudy;
    ArrRecords[11] = UserID;
    ArrRecords[12] = UserRoleCode;
    ArrRecords[13] = MenuID;
    ArrRecords[14] = SessionID;
    ArrRecords[15] = objtxtStudyUID.value;
    ArrRecords[16] = objddlPriority.value;
    PreserveFilterValues();
    CallBackBrw.callback(ArrRecords);
}
function PreserveFilterValues() {
    parent.GsFilter.length = 0;
    parent.GsFilter[0] = parent.Trim(objtxtPatientName.value);
    parent.GsFilter[1] = parent.Trim(objddlModality.value);
    if (objchkRecDt.checked) parent.GsFilter[2] = "Y"; else parent.GsFilter[2] == "N";
    parent.GsFilter[3] = objtxtFromDt.value;
    parent.GsFilter[4] = objtxtTillDt.value;
    parent.GsFilter[5] = parent.Trim(objddlInstitution.value);
    parent.GsFilter[6] = parent.Trim(objddlStatus.value);
    parent.GsFilter[7] = parent.Trim(objddlCategory.value);
    parent.GsFilter[8] = parent.Trim(objddlRadiologist.value);
    parent.GsFilter[9] = parent.Trim(objddlSpecies.value);
    parent.GsFilter[10] = parent.Trim(objddlPriority.value);
    parent.GsFilter[11] = objtxtStudyUID.value;
}
function ResetRecord() {
    var strDtFrom = ""; var strDtTill = "";

    var dtFrom = new Date(); var dtTill = new Date();
    dtFrom = dtFrom.addDays(-7);
    if (parent.GsDateFormat == "dd" + parent.objhdnDateSep.value + "MM" + parent.objhdnDateSep.value + "yyyy")
        strDtFrom = parent.padZeroPlaces(dtFrom.getDate(), 2) + parent.objhdnDateSep.value + parent.padZeroPlaces((parseInt(dtFrom.getMonth()) + 1), 2) + parent.objhdnDateSep.value + dtFrom.getFullYear();
    else if (parent.GsDateFormat == "MM" + parent.objhdnDateSep.value + "dd" + parent.objhdnDateSep.value + "yyyy")
        strDtFrom = parent.padZeroPlaces((parseInt(dtFrom.getMonth()) + 1), 2) + parent.objhdnDateSep.value + parent.padZeroPlaces(dtFrom.getDate(), 2) + parent.objhdnDateSep.value + dtFrom.getFullYear();
    else if (parent.GsDateFormat == "yyyy" + parent.objhdnDateSep.value + "MM" + parent.objhdnDateSep.value + "dd")
        strDtFrom = dtFrom.getFullYear() + parent.objhdnDateSep.value + parent.padZeroPlaces((parseInt(dtFrom.getMonth()) + 1), 2) + parent.objhdnDateSep.value + parent.padZeroPlaces(dtFrom.getDate(), 2);

    if (parent.GsDateFormat == "dd" + parent.objhdnDateSep.value + "MM" + parent.objhdnDateSep.value + "yyyy")
        strDtTill = parent.padZeroPlaces(dtTill.getDate(), 2) + parent.objhdnDateSep.value + parent.padZeroPlaces((parseInt(dtTill.getMonth()) + 1), 2) + parent.objhdnDateSep.value + dtTill.getFullYear();
    else if (parent.GsDateFormat == "MM" + parent.objhdnDateSep.value + "dd" + parent.objhdnDateSep.value + "yyyy")
        strDtTill = parent.padZeroPlaces((parseInt(dtTill.getMonth()) + 1), 2) + parent.objhdnDateSep.value + parent.padZeroPlaces(dtTill.getDate(), 2) + parent.objhdnDateSep.value + dtTill.getFullYear();
    else if (parent.GsDateFormat == "yyyy" + parent.objhdnDateSep.value + "MM" + parent.objhdnDateSep.value + "dd")
        strDtTill = dtTill.getFullYear() + parent.objhdnDateSep.value + parent.padZeroPlaces((parseInt(dtTill.getMonth()) + 1), 2) + parent.objhdnDateSep.value + parent.padZeroPlaces(dtTill.getDate(), 2);

    
    objtxtPatientName.value = "";
    objddlModality.value = "0";
    objddlCategory.value = "0";
    objtxtPatientName.value = "";
    objchkRecDt.checked = false;
    objtxtFromDt.value = strDtFrom;
    objtxtTillDt.value = strDtTill;
    objddlInstitution.value = "00000000-0000-0000-0000-000000000000";
    objddlStatus.value = "-1";
    objddlRadiologist.value = "00000000-0000-0000-0000-000000000000";
    objddlSpecies.value = "0";
    objddlPriority.value = "0";
    objtxtStudyUID.value = "";
    
    SearchRecord();
    parent.FetchMenuRecordCount();
}
function btnDV_OnClick() {

    try {
        if (parent.Trim(objhdnSelSUID.value) != "") {
            if (UserRoleCode == "RDL") {
                RadiologistSelfAssignment();
            }
            else {
                location.href = "vetrisepacs://open?uid=" + objhdnSelSUID.value + "&c=" + objhdnPACSCred.value;
            }
        }
        else {
            parent.PopupMessage(RootDirectory, strForm, "btnDV_OnClick()", "471", "true");
        }
    }
    catch (expErr) {
        parent.HideMessage();
        parent.PopupMessage(RootDirectory, strForm, "btnDV_OnClick()", expErr.message, "true");

    }
}
function RadiologistSelfAssignment() {
    var ArrRecords = new Array();
    var arrSUID = new Array();
    parent.GsPopupText = "Assigning...";
    parent.PopupProcess("N");

    try {


        ArrRecords[0] = parent.objhdnRadiologistID.value;
        ArrRecords[1] = UserID;
        ArrRecords[2] = MenuID;
        ArrRecords[3] = SessionID;

        if (objhdnSelSUID.value.indexOf(";") >= 0) arrSUID = objhdnSelSUID.value.split(";");
        else arrSUID[0] = objhdnSelSUID.value;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.RadiologistSelfAssignmentSave(ArrRecords, arrSUID, ShowProcess);

    }
    catch (expErr) {
        parent.HideProcess();
        parent.PopupMessage(RootDirectory, strForm, "CopyFolder()", PatientName + "..." + expErr.message, "true");
    }
}
function ProcessRadiologistSelfAssignmentSave(Result) {
    var arrRes = new Array();
    arrRes = Result.value;
    switch (arrRes[0]) {
        case "catch":
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessRadiologistSelfAssignmentSave()", arrRes[1], "true");
            objhdnSelSUID.value = "";
            SearchRecord();
            break;
        case "true":
            location.href = "vetrisepacs://open?uid=" + objhdnSelSUID.value + "&c=" + objhdnPACSCred.value;
            objhdnSelSUID.value = "";
            SearchRecord();
            break;
    }

    parent.FetchMenuRecordCount();
}
function Status_OnClick(ID, URL) {
    URL = URL.replace("#V2", PACSUID);
    URL = URL.replace("#V3", PACSPwd);
    parent.NavigatePACS(URL);
}

function btnDisc_OnClick(ID) {
    parent.GsLaunchURL = "CaseList/VRSApplyPromotion.aspx?id=" + ID + "&mid=" + MenuID + "&uid=" + UserID + "&sid=" + SessionID + "&th=" + selTheme;
    parent.PopupGeneralMedium();
}
function btnImg_OnClick(ID, StudyUID, AccnNo, PatientID, URL) {
    if (APIVER == "7.2") {
        URL = URL.replace("#V1", StudyUID);
        URL = URL.replace("#V2", PACSUID);
        URL = URL.replace("#V3", PACSPwd);
    }
    else if (APIVER == "8") {
        URL = URL.replace("#V1", AccnNo);
        URL = URL.replace("#V2", PatientID);
        URL = URL.replace("#V3", WSSessionID);
        URL = URL.replace("#V4", WS8SRVUID);
        URL = URL.replace("#V5", WS8SRVPWD);

    }

    parent.NavigatePACS(URL);
}
function btnImgViewer_OnClick(StudyUID) {

    try {
        location.href = "vetrisepacs://open?uid=" + StudyUID + "&c=" + objhdnPACSCred.value;
    }
    catch (expErr) {
        parent.HideMessage();
        parent.PopupMessage(RootDirectory, strForm, "btnImgViewer_OnClick()", expErr.message, "true");

    }
}
function btnActivity_OnClick(ID, SUID) {
    strValidate = "N";
    btnBrwEditUI_Onclick("HouseKeeping/VRSStudyRadiologistActivity.aspx?cf=" + MenuID + "&suid=" + SUID);
}
function ProcessGeneralMedium(ArgsRet) {
    if (ArgsRet == "Y") {
        SearchRecord();
    }
}
function btnEditRpt_OnClick(ID, StatusID) {
    objhdnID.value = ID;
    if (UserRoleCode == "RDL" || UserRoleCode == "SUPP" || UserRoleCode == "SYSADMIN") {
        CheckRadiologistLock(StatusID);
    }
    else {
        btnBrwEditUI_Onclick("CaseList/VRSInProgressDlg.aspx");
    }
}

/****************Release Case Assigned********************/
function btnRelCase_OnClick(ID) {
    SYID = ID;
    parent.GsDlgConfAction = "DEL";
    parent.PopupConfirm("481");
}
function ReleaseAssignedStudy() {
    parent.PopupProcess("N");
    var ArrParams = new Array();

    try {
        ArrParams[0] = SYID;
        ArrParams[1] = UserID;
        ArrParams[2] = MenuID;
        ArrParams[3] = SessionID;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.ReleaseStudyAssignment(ArrParams, ShowProcess);

    }
    catch (expErr) {
        parent.HideProcess();
        parent.PopupMessage(RootDirectory, strForm, "ReleaseAssignedStudy()", expErr.message, "true");
    }
}
function ProcessReleaseStudyAssignment(Result) {
    var arrRes = new Array();
    arrRes = Result.value;
    var cnt = 0;
    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "ProcessReleaseStudyAssignment()", arrRes[1], "true");
            break;
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessReleaseStudyAssignment()", arrRes[1], "true");
            break;
        case "true":
            SearchRecord();
            parent.FetchMenuRecordCount();
            break;
    }
}
/****************Release Case Assigned********************/

/****************Get Case********************/
function btnGetCase_OnClick() {
    parent.PopupProcess("N");
    var ArrParams = new Array();

    try {
        ArrParams[0] = UserID;
        ArrParams[1] = MenuID;
        ArrParams[2] = SessionID;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.GetCase(ArrParams, ShowProcess);

    }
    catch (expErr) {
        parent.HideProcess();
        parent.PopupMessage(RootDirectory, strForm, "GetCase()", expErr.message, "true");
    }
}
function ProcessGetCase(Result) {
    var arrRes = new Array();
    arrRes = Result.value;
    var cnt = 0;
    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "ProcessGetCase()", arrRes[1], "true");
            break;
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessGetCase()", arrRes[1], "true");
            break;
        case "true":
            parent.PopupMessage(RootDirectory, strForm, "ProcessGetCase()", arrRes[1], "false");
            SearchRecord();
            break;
    }
}
/****************Get Case********************/

/**************Procss Download ******************/
function btnDLImg_OnClick(ID, SUID, InstCode,  PhysCode) {
    //parent.GsLaunchURL = "CaseList/VRSInProgressBrw.aspx?id=" + ID + "&mid=" + MenuID + "&uid=" + UserID + "&arch=N";
    //parent.PopupGeneralMedium();
    var InstName = ""; PatientName = "";
    var itemIndex = 0; var gridItem; var RowId = "0";
    while (gridItem = grdBrw.get_table().getRow(itemIndex)) {
        RowId = gridItem.Data[0].toString();
        if (RowId == ID) {
            PatientName = gridItem.Data[2].toString();
            InstName = gridItem.Data[33].toString();
            break;
        }
        itemIndex++;
    }

    document.getElementById("btnDLImg_" + ID).style.display = "none";
    document.getElementById("imgDLProc_" + ID).style.display = "inline";
    CopyFolder(ID, SUID, InstCode, InstName, PhysCode, PatientName);
}
function CopyFolder(ID, SUID, InstCode, InstName, PhysCode, PatientName) {
    var ArrRecords = new Array();
    var arrRes = new Array();

    try {
        ArrRecords[0] = ID;
        ArrRecords[1] = SUID;
        ArrRecords[2] = InstCode;
        ArrRecords[3] = InstName;
        ArrRecords[4] = PhysCode;
        ArrRecords[5] = PatientName;
        ArrRecords[6] = objhdnPACSARCHIVEFLDR.value;
        ArrRecords[7] = objhdnPACSARCHALTFLDR.value;
        ArrRecords[8] = objhdnDCMMODIFYEXEPATH.value;
        ArrRecords[9] = "N"; if (objhdnRadFnRights.value.indexOf("VWINSTINFO") > -1) ArrRecords[8] = "Y";
        ArrRecords[10] = UserID;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.CopyFolder(ArrRecords, ShowDownloadProcess);

    }
    catch (expErr) {
        document.getElementById("btnDLImg_" + ID).style.display = "inline";
        document.getElementById("imgDLProc_" + ID).style.display = "none";
        parent.PopupMessage(RootDirectory, strForm, "CopyFolder()", PatientName + "..." + expErr.message, "true");
    }

}
function ProcessCopy(Result) {
    var arrRes = new Array();
    var ID = ""; var PatientName = ""; var TgtFolder = "";
    arrRes = Result.value;

    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "ProcessCopy()", arrRes[1], "true");
            document.getElementById("btnDLImg_" + arrRes[2]).style.display = "inline";
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";
            break;
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessCopy()", arrRes[1], "true", arrRes[3]);
            document.getElementById("btnDLImg_" + arrRes[2]).style.display = "inline";
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";
            break;
        case "true":
            ID = arrRes[1];
            PatientName = arrRes[2];
            TgtFolder = arrRes[3];
            CompressFolder(ID, PatientName, TgtFolder);
            break;
    }
}
function CompressFolder(ID, PatientName, TgtFolder) {
    var ArrRecords = new Array();
    var arrRes = new Array();

    try {

        ArrRecords[0] = ID;
        ArrRecords[1] = PatientName;
        ArrRecords[2] = TgtFolder;
        ArrRecords[3] = UserID;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.CompressFolder(ArrRecords, ShowDownloadProcess);
    }
    catch (expErr) {
        document.getElementById("btnDLImg_" + ID).style.display = "inline";
        document.getElementById("imgDLProc_" + ID).style.display = "none";
        parent.PopupMessage(RootDirectory, strForm, "CompressFolder()", PatientName + "..." + expErr.message, "true");
    }
}
function ProcessCompress(Result) {
    var arrRes = new Array();
    arrRes = Result.value;
    var cnt = 0;

    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "ProcessCopy()", arrRes[1], "true");
            document.getElementById("btnDLImg_" + arrRes[2]).style.display = "inline";
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";
            break;
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessCopy()", arrRes[1], "true", arrRes[3]);
            document.getElementById("btnDLImg_" + arrRes[2]).style.display = "inline";
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";
            break;
        case "true":
            location.href = "Temp/" + UserID + "/" + arrRes[1];
            document.getElementById("btnDLImg_" + arrRes[2]).style.display = "inline";
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";
            break;
    }
}
function btnDLImgDsbl_OnClick(ID, SUID, InstCode) {
    var InstName = ""; PatientName = "";
    var itemIndex = 0; var gridItem; var RowId = "0";
    while (gridItem = grdBrw.get_table().getRow(itemIndex)) {
        RowId = gridItem.Data[0].toString();
        if (RowId == ID) {
            PatientName = gridItem.Data[2].toString();
            InstName = gridItem.Data[33].toString();
            break;
        }
        itemIndex++;
    }

    document.getElementById("btnDLImgDsbl_" + ID).style.display = "none";
    document.getElementById("imgDLProc_" + ID).style.display = "inline";
    CheckFileCount(ID, SUID, InstCode, InstName, PatientName);
}
function CheckFileCount(ID, SUID, InstCode, InstName, PatientName) {
    var ArrRecords = new Array();
    var arrRes = new Array();

    try {
        ROWID = ID;
        ArrRecords[0] = ID;
        ArrRecords[1] = SUID;
        ArrRecords[2] = InstCode;
        ArrRecords[3] = InstName;
        ArrRecords[4] = PatientName;
        ArrRecords[5] = objhdnPACSARCHIVEFLDR.value;
        ArrRecords[6] = objhdnPACSARCHALTFLDR.value;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.CheckFileCount(ArrRecords, ShowDownloadProcess);

    }
    catch (expErr) {
        document.getElementById("btnDLImgDsbl_" + ID).style.display = "inline";
        document.getElementById("imgDLProc_" + ID).style.display = "none";
        parent.PopupMessage(RootDirectory, strForm, "CheckFileCount()", PatientName + "..." + expErr.message, "true");
    }

}
function ProcessCount(Result) {
    var arrRes = new Array();
    var itemIndex = 0; var gridItem; var RowId = "0";
    var ID = ""; var PatientName = ""; var TgtFolder = "";
    arrRes = Result.value;

    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "ProcessCount()", arrRes[1], "true");
            document.getElementById("btnDLImgDsbl_" + arrRes[2]).style.display = "inline";
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";
            break;
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessCount()", arrRes[1], "true", arrRes[3]);
            document.getElementById("btnDLImgDsbl_" + arrRes[2]).style.display = "inline";
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";
            break;
        case "true":
            ID = arrRes[1];
            PatientName = arrRes[3];
            document.getElementById("imgDLProc_" + arrRes[2]).style.display = "none";

            if (arrRes[1] == "490") {
                parent.PopupMessage(RootDirectory, strForm, "ProcessCount()", arrRes[1], "true", arrRes[3], arrRes[4]);
                document.getElementById("btnDLImgDsbl_" + arrRes[2]).style.display = "inline";
            }
            else if (arrRes[1] == "491") {
                parent.PopupMessage(RootDirectory, strForm, "ProcessCount()", arrRes[1], "false", arrRes[3]);
                document.getElementById("btnDLImg_" + arrRes[2]).style.display = "inline";
                document.getElementById("btnDLImgDsbl_" + arrRes[2]).style.display = "none";

                while (gridItem = grdBrw.get_table().getRow(itemIndex)) {
                    RowId = gridItem.Data[0].toString();
                    if (RowId == ROWID) {
                        gridItem.Data[37] = "Y";
                        gridItem.Data[15] = arrRes[5];
                        document.getElementById("spnFileCnt_" + arrRes[2]).innerHTML = arrRes[5];
                        break;
                    }
                    itemIndex++;
                }
            }

            break;
    }
}
function ShowDownloadProcess(Result, MethodName) {
    var strMethod = MethodName.method;
    switch (strMethod) {
        case "CopyFolder":
            ProcessCopy(Result);
            break;
        case "CompressFolder":
            ProcessCompress(Result);
            break;
        case "CheckFileCount":
            ProcessCount(Result);
            break;

    }
}
/**************Procss Download ******************/

function btnTrans_OnClick(ID, StatusID) {
    if (UserRoleCode == "TRS") {
        objhdnID.value = ID;
        CheckRadiologistLock(StatusID);
    }
}
function CheckRadiologistLock(StatusID) {
    parent.PopupProcess("N");
    var ArrRecords = new Array();

    try {

        ArrRecords[0] = objhdnID.value;
        ArrRecords[1] = StatusID;
        ArrRecords[2] = UserID;
        ArrRecords[3] = MenuID;
        ArrRecords[4] = SessionID;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.CheckRadiologistLock(ArrRecords, ShowProcess);
    }
    catch (expErr) {
        parent.HideProcess();
        parent.PopupMessage(RootDirectory, strForm, "CheckRadiologistLock()", expErr.message, "true");
    }
}
function ProcessRadiologistLock(Result) {

    var arrRes = new Array(); var url = ""; var refresh = "N"; var user_name = ""; var in_team = "N";
    arrRes = Result.value;

    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "ProcessRadiologistLock()", arrRes[1], "true");
            break;
        case "false":
            refresh = arrRes[1];
            in_team = arrRes[5];
            var RadFnRights = objhdnRadFnRights.value;
            if ((UserRoleCode == "RDL" && RadFnRights.indexOf("ACCLOCKSTUDY") > -1) || UserRoleCode == "SUPP" || UserRoleCode == "SYSADMIN") {
                if (arrRes[2] == "303") {
                    if (UserRoleCode == "RDL" && in_team == "N") {
                        parent.PopupMessage(RootDirectory, strForm, "ProcessRadiologistLock()", arrRes[2], "true");
                        if (refresh == "Y") {
                            SearchRecord();
                            parent.FetchMenuRecordCount();
                        }
                    }
                    else {
                        REFRESH_LIST = refresh;
                        parent.GsDlgConfAction = "FET";
                        parent.PopupConfirm("385", arrRes[4]);
                    }
                }
                else {
                    parent.PopupMessage(RootDirectory, strForm, "ProcessRadiologistLock()", arrRes[2], "true", arrRes[3]);
                    if (refresh == "Y") {
                        SearchRecord();
                        parent.FetchMenuRecordCount();
                    }
                }
            }
            else {
                if (arrRes[2] == "296") parent.PopupMessage(RootDirectory, strForm, "ProcessRadiologistLock()", arrRes[2], "true", arrRes[3]);
                else parent.PopupMessage(RootDirectory, strForm, "ProcessRadiologistLock()", arrRes[2], "true", arrRes[4]);
                if (refresh == "Y") {
                    SearchRecord();
                    parent.FetchMenuRecordCount();
                }
            }
            break;
        case "true":
            refresh = arrRes[1];
            user_name = arrRes[3];
            if (refresh == "Y") {
                SearchRecord();
                parent.FetchMenuRecordCount();
            }

            if (user_name == "") btnBrwEditUI_Onclick("CaseList/VRSInProgressDlg.aspx");
            else btnBrwEditUI_Onclick("CaseList/VRSInProgressDlg.aspx?unm=" + user_name);
            //if (parent.Trim(arrRes[3]) != "") parent.PopupMessage(RootDirectory, strForm, "ProcessRadiologistLock()", arrRes[2], "false", arrRes[3]);
            break;
    }
}
function ProcessPostConfirm(ArgsRet) {
    if (ArgsRet == "N") {
        if (REFRESH_LIST == "Y") {
            SearchRecord();
            parent.FetchMenuRecordCount();
        }
    }
    else if (ArgsRet == "Y") {
        AquireLock();
    }
}
function AquireLock() {
    parent.GsPopupText = "Acquiring Lock...";
    parent.PopupProcess("N");
    var ArrRecords = new Array();

    try {

        ArrRecords[0] = objhdnID.value;
        ArrRecords[1] = UserID;
        ArrRecords[2] = MenuID;
        ArrRecords[3] = SessionID;

        AjaxPro.timeoutPeriod = 1800000;
        VRSInProgressBrw.AcquireRecordLock(ArrRecords, ShowProcess);
    }
    catch (expErr) {
        parent.HideProcess();
        parent.PopupMessage(RootDirectory, strForm, "AquireLock()", expErr.message, "true");
    }
}
function ProcessAcquireLock(Result) {
    var arrRes = new Array();
    arrRes = Result.value;
    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "ProcessAcquireLock()", arrRes[1], "true");
            break;
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessAcquireLock()", arrRes[1], "true");
            break;
        case "true":
            btnBrwEditUI_Onclick("CaseList/VRSInProgressDlg.aspx");
            break;
    }
}
function SetSelectedDate(objCtrlID, CalName, LsImgID) {
    var strDate = ""; var strClass = "";
    var dt;
    objCtrl = document.getElementById(objCtrlID.id); if (objCtrl == null) objCtrl = objCtrlID;
    strDate = document.getElementById(objCtrl).value;

    if (parent.Trim(strDate) != "") {
        if (document.all) {
            dt = new Date(parent.SetDateFormat(strDate, parent.GsDateFormat, parent.GsDateSep));
        }
        else {
            dt = new Date(parent.SetDateFormat1(strDate, parent.GsDateFormat, parent.GsDateSep));
        }
    }
    else
        dt = new Date();
    switch (CalName) {
        case "CalFrom":
            CalFrom.setSelectedDate(dt); CalFrom.show();
            break;
        case "CalTill":
            CalTill.setSelectedDate(dt); CalTill.show();
            break;
    }


}
function ValidateDateEntered(objCtrl) {
    var strDate = "";
    strDate = document.getElementById(objCtrl.id).value;

    if (parent.ValidateDate(strDate))
        return true;
}
function ShowProcess(Result, MethodName) {
    parent.HideProcess();
    parent.GsPopupText = "";
    var strMethod = MethodName.method;
    switch (strMethod) {
        case "UpdatePriority":
            ProcessPriorityUpdate(Result);
            break;
        case "CheckRadiologistLock":
            ProcessRadiologistLock(Result);
            break;
        case "AcquireRecordLock":
            ProcessAcquireLock(Result);
            break;
        case "RadiologistSelfAssignmentSave":
            ProcessRadiologistSelfAssignmentSave(Result);
            break;
        case "ReleaseStudyAssignment":
            ProcessReleaseStudyAssignment(Result);
            break;
        case "GetCase":
            ProcessGetCase(Result);
            break;
    }
}
function ddlPriority_OnChange(ID) {
    var ArrRecords = new Array();
    var itemIndex = 0; var gridItem; var RowId = "0";
    var PriorityId = "";
    while (gridItem = grdBrw.get_table().getRow(itemIndex)) {
        RowId = gridItem.Data[0].toString();
        if (RowId == ID) {
            PriorityId = document.getElementById("ddlPriority_" + ID).value;
            parent.PopupProcess("N");
            try {
                ArrRecords[0] = ID;
                ArrRecords[1] = PriorityId.toString();
                ArrRecords[2] = UserID;

                AjaxPro.timeoutPeriod = 1800000;
                VRSInProgressBrw.UpdatePriority(ArrRecords, ShowProcess);
            }
            catch (expErr) {
                parent.HideProcess();
                parent.PopupMessage(RootDirectory, strForm, "ddlPriority_OnChange()", expErr.message, "true");
            }

            break;
        }

        itemIndex++;
    }

}
function ProcessPriorityUpdate(Result) {
    var arrRes = new Array(); var url = "";
    arrRes = Result.value;
    switch (arrRes[0]) {
        case "catch":
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "ProcessPriorityUpdate()", arrRes[1], "true");
            break;
        case "true":
            break;
    }
    SearchRecord();
}
function btnSel_OnClick(ID, StudyUID) {
    if (parent.Trim(objhdnSelSUID.value) != "") objhdnSelSUID.value += ";";
    objhdnSelSUID.value += StudyUID;

    document.getElementById("btnSel_" + ID).style.display = "none";
    document.getElementById("btnCheck_" + ID).style.display = "inline";
}
function btnCheck_OnClick(ID, StudyUID) {
    var suid = objhdnSelSUID.value;
    var arrSUID = new Array();

    if (parent.Trim(suid) != "") {
        if (suid.indexOf(";") >= 0) {
            arrSUID = suid.split(";");
            objhdnSelSUID.value = "";
            for (var i = 0; i < arrSUID.length; i++) {
                if (arrSUID[i] != StudyUID) {
                    if (parent.Trim(objhdnSelSUID.value) != "") objhdnSelSUID.value += ";";
                    objhdnSelSUID.value += arrSUID[i];
                }
            }
        }
        else {
            objhdnSelSUID.value = "";
        }
    }

    document.getElementById("btnSel_" + ID).style.display = "inline";
    document.getElementById("btnCheck_" + ID).style.display = "none";
}
function DeleteRecord() {
    ReleaseAssignedStudy();
}
