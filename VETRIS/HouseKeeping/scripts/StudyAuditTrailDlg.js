var strRowID = "0";
var ErrFlag = 0;
function CheckError() {
    var arrErr = new Array();
    if (parent.Trim(objhdnError.value) != "") {
        arrErr = objhdnError.value.split(Divider);
        switch (arrErr[0]) {
            case "catch":
            case "false":
                if (arrErr[1] == "094") {
                    parent.PopupMessage(RootDirectory, strForm, "CheckError()", arrErr[1], "true");
                    strLoadPopup = "N";
                    parent.GsRetStatus = "false";
                    btnClose_OnClick();
                }
                else
                    parent.PopupMessage(RootDirectory, strForm, "OnLoad()", arrErr[1], "true");
                break;
        }
    }
    objhdnError.value = "";
    SetPageValue();
}
function SetPageValue() {
    //CallBackDoc.callback(objhdnID.value, UserID);
    iframeUploadSF.src = "../CaseList/VRSUploadStudyFiles.aspx?uid=" + UserID + "&path=CaseList_Temp&th=" + selTheme;
    //LoadStudyTypes();

    if (objhdnInstConsAppl.value == "Y") document.getElementById("divCons").style.display = "inline";
    CallBackSF.callback("L", objhdnID.value, UserID);
    CallBackST.callback(objhdnID.value, objhdnModalityID.value);


}
function btnSubmit_OnClick(WriteBack, MergeStatus) {
    parent.PopupProcess("Y");
    var ArrRecords = new Array();
    var arrDocs = new Array();
    var arrDCM = new Array();
    WRITE_BACK = WriteBack;

    try {

        ArrRecords[0] = objhdnID.value;
        ArrRecords[1] = objtxtReason.value;
        ArrRecords[2] = WriteBack;
        ArrRecords[3] = MergeStatus;
        ArrRecords[4] = objtxtPhysNote.value;
        ArrRecords[5] = UserID;
        ArrRecords[6] = MenuID;
        ArrRecords[7] = objhdnSUID.value;
        ArrRecords[8] = $('#lblInstitution').html();
        arrDocs = GetDocList();
        arrDCM = GetDCMList();
        if (ErrFlag == 0) {
            //if (objddlInstitution.value != "00000000-0000-0000-0000-000000000000") {
            AjaxPro.timeoutPeriod = 1800000;
            VRSStudyAuditTrailDlg.SaveRecord(ArrRecords, arrDocs, arrDCM, ShowProcess);
            //}
            //else {
            //    parent.HideProcess();
            //    parent.PopupMessage(RootDirectory, strForm, "SubmitStudy()", "055", "true");
            //}
        }
    }
    catch (expErr) {
        parent.HideProcess();
        parent.PopupMessage(RootDirectory, strForm, "SubmitStudy()", expErr.message, "true");
    }
}
function btnClose_OnClick() {
    parent.GsNavURL = "HouseKeeping/VRSStudyAuditTrailBrw.aspx?uid=" + UserID + "&urid=" + UserRoleID + "&mid=" + MenuID;
    if (parent.GsRetStatus == "false")
        btnDlgClose_Onclick();
    else {
        parent.GsDlgConfAction = "CLS";
        parent.PopupConfirm("028");
    }
}
function btnRefreshCount_OnClick() {
    parent.PopupProcess("N");
    var strSUID = ""; var strURL = "";

    try {
        strSUID = objhdnSUID.value;
        strURL = objhdnImgCntURL.value.replace("qf_SYUI=", "qf_SYUI=" + strSUID);
        strURL = strURL.replace("#V2", PACSUID);
        strURL = strURL.replace("#V3", PACSPwd);

        AjaxPro.timeoutPeriod = 1800000;
        VRSCaseRADlg.GetImageCount(strURL, ShowProcess);
    }
    catch (expErr) {
        parent.HideProcess();
        parent.PopupMessage(RootDirectory, strForm, "btnRefreshCount_OnClick()", expErr.message, "true");
    }
}
function SaveRecord(Result) {
    var arrRes = new Array();
    parent.GsPopupText = "";
    arrRes = Result.value;
    var cnt = 0;
    debugger;
    switch (arrRes[0]) {
        case "catch":
            parent.PopupMessage(RootDirectory, strForm, "SaveRecord()", arrRes[1], "true");
            break;
        case "false":
            if (arrRes[1] == "094") {
                parent.PopupMessage(RootDirectory, strForm, "SaveRecord()", arrRes[1], "true", arrRes[2]);
                parent.GsRetStatus = "false";
                btnClose_OnClick();
            }
                //else if (arrRes[1] == "165") {
                //    parent.GsLaunchURL = "CaseList/VRSMergeConfirm.aspx";
                //    strLoadPopup = "N";
                //    parent.PopupGeneralSmall();
                //}
            else if (arrRes[1] == "331") {
                parent.PopupMessage(RootDirectory, strForm, "SaveRecord()", arrRes[1], "true", arrRes[2], arrRes[3]);
            }
            else
                parent.PopupMessage(RootDirectory, strForm, "SaveRecord()", arrRes[1], "true", arrRes[2]);
            break;
        case "true":
            parent.GsRetStatus = "false";
            if (WRITE_BACK == "Y") {
                if (arrRes[2] != "") {
                    parent.PopupMessage(RootDirectory, strForm, "SaveRecord()", arrRes[1], "false", arrRes[2]);
                }
                btnClose_OnClick();
            }
            else {
                parent.PopupMessage(RootDirectory, strForm, "SaveRecord()", arrRes[1], "false", arrRes[2]);
                //ddlModality_OnChange();
            }
            break;
    }
}
function GetImageCount(Result) {

    var arrRes = new Array(); var url = "";
    arrRes = Result.value;
    switch (arrRes[0]) {
        case "catch":
        case "false":
            parent.PopupMessage(RootDirectory, strForm, "GetImageCount()", arrRes[1], "true");
            break;
        case "true":
            objtxtImgCnt.value = arrRes[1];
            break;
    }

}
function ShowDocument(ID, FileName) {
    var strFilePath = "/" + RootDirectory + "/HouseKeeping/Temp/" + UserID + "/" + FileName;
    var win = window.open(strFilePath, '_blank');
    win.focus();
}
/********Study File Grid*****************************/
function ToggleUpload() {
    var e = $('#aRUploadCollapse').closest(".searchSection"),
                       t = $('#aRUploadCollapse').find("i"),
                       n = e.find("#divUpload");

    e.attr("style") ? n.slideToggle(200, function () {
        e.removeAttr("style")
    }) : (n.slideToggle(200), e.css("height", "auto")), t.toggleClass("fa-chevron-up fa-chevron-down")
}
function ProcessStudyFileUpload(ArgsRet) {
    var arrFiles = new Array();
    var strExistingDtls = ""; var strNewDtls = "";
    var strFileType = "";
    if (ArgsRet != null) {
        parent.GsRetStatus = "true";
        arrFiles = ArgsRet[0].split(Divider);
        strExistingDtls = GetGridDetails();
        for (var i = 0; i < arrFiles.length; i = i + 2) {
            if (strNewDtls != "") strNewDtls += SecDivider;
            strNewDtls += arrFiles[i] + SecDivider;
            strNewDtls += arrFiles[i + 1]
        }
        objiframeUploadSF.src = "../CaseList/VRSUploadStudyFiles.aspx?uid=" + UserID + "&path=CaseList_Temp&th=" + selTheme;
        CallBackSF.callback("A", strExistingDtls, strNewDtls, UserID);

    }
}
function GetGridDetails() {
    var strDtls = "";
    var itemIndex = 0;
    var gridItem;

    while (gridItem = grdSF.get_table().getRow(itemIndex)) {
        if (strDtls != "") strDtls = strDtls + SecDivider;
        strDtls += gridItem.get_cells()[0].get_value().toString() + SecDivider;
        strDtls += gridItem.get_cells()[1].get_value().toString() + SecDivider;
        strDtls += gridItem.get_cells()[2].get_value().toString() + SecDivider;
        strDtls += gridItem.get_cells()[3].get_value().toString() + SecDivider;
        strDtls += gridItem.get_cells()[4].get_value().toString();

        itemIndex++;
    }
    return strDtls;
}
function DeleteStudyFile(ID) {
    strRowID = ID;
    DEL_FLAG = "SF";
    parent.GsDlgConfAction = "DEL";
    parent.PopupConfirm("032");
}
function ClearFiles() {
    var strExistingDtls = GetGridDetails();
    CallBackSF.callback("C", strExistingDtls, objhdnTempSFFolder.value);
}
function DeleteRecord() {
    var Flg = DEL_FLAG;
    var strExistingDtls = "";
    switch (Flg) {
        case "SF":
            strExistingDtls = GetGridDetails();
            CallBackSF.callback("D", strRowID, strExistingDtls, objhdnTempSFFolder.value);
            break;
        case "STUDY":
            DeleteStudy();
            break;
    }


}
function GetDocList() {
    var itemIndex = 0;
    var gridItem;
    var arrDoc = new Array(); var idx = 0; var fileType = ""; var srl = 0;
    while (gridItem = grdSF.get_table().getRow(itemIndex)) {
        if (gridItem.get_cells()[0].get_value().toString() == '00000000-0000-0000-0000-000000000000') {
            fileType = gridItem.get_cells()[3].get_value().toString();
            if (fileType == "P" || fileType == "I") {
                srl = srl + 1;
                arrDoc[idx] = srl.toString();
                arrDoc[idx + 1] = gridItem.get_cells()[0].get_value().toString();
                arrDoc[idx + 2] = gridItem.get_cells()[2].get_value().toString();
                idx = idx + 3;
            }
        }
        itemIndex++;
    }
    return arrDoc;
}
function GetDCMList() {
    var itemIndex = 0;
    var gridItem;
    var arrDCM = new Array(); var idx = 0; var fileType = ""; var srl = 0;
    while (gridItem = grdSF.get_table().getRow(itemIndex)) {
        if (gridItem.get_cells()[0].get_value().toString() == '00000000-0000-0000-0000-000000000000') {
            fileType = gridItem.get_cells()[3].get_value().toString();
            if (fileType == "D") {
                srl = srl + 1;
                arrDCM[idx] = gridItem.get_cells()[0].get_value().toString();
                arrDCM[idx + 1] = srl.toString();
                arrDCM[idx + 2] = gridItem.get_cells()[2].get_value().toString();
                idx = idx + 3;
            }
        }
        itemIndex++;
    }
    return arrDCM;
}
/********Study File Grid*****************************/
function ShowProcess(Result, MethodName) {
    parent.HideProcess();
    var strMethod = MethodName.method;
    debugger;
    switch (strMethod) {
        case "SaveRecord":
            SaveRecord(Result);
            break;
    }

}