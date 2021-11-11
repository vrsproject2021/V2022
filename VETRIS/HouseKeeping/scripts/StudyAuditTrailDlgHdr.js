var grdRowID = "0"; var cb = "N"; var DOCADD = "N";
function grdST_onCallbackComplete(sender, eventArgs) {
    grdST.Width = "99%";
   // parent.adjustFrameHeight();
    var strErr = parent.Trim(document.getElementById("hdnCBErrST").value);
    if (strErr != "") {
        parent.PopupMessage(RootDirectory, strForm, "grdST_onCallbackComplete()", strErr, "true");
    }
}
function grdST_onRenderComplete(sender, eventArgs) {

    if (document.getElementById("hdnModTrackBy").value == "I") { objlblImgCnt.style.display = "inline"; objlblObjCnt.style.display = "none"; }
    else if (document.getElementById("hdnModTrackBy").value == "O") { objlblImgCnt.style.display = "none"; objlblObjCnt.style.display = "inline"; }
}
//function grdDoc_onCallbackComplete(sender, eventArgs) {
//    grdDoc.Width = "99%";
//   // parent.adjustFrameHeight();
//    var strErr = parent.Trim(document.getElementById("hdnCBErrDoc").value);
//    if (strErr != "") {
//        parent.PopupMessage(RootDirectory, strForm, "grdDoc_onCallbackComplete()", strErr, "true");
//    }
//}
//function grdDoc_onRenderComplete(sender, eventArgs) {
//   // parent.adjustFrameHeight();
//    if (DOCADD == "N") parent.GsRetStatus = "false";
//    else parent.GsRetStatus = "true";
//}

function grdSF_onCallbackComplete(sender, eventArgs) {
    grdSF.Width = "99%";
    parent.adjustFrameHeight();
    var strErr = parent.Trim(document.getElementById("hdnCBErr").value);
}
function grdSF_onRenderComplete(sender, eventArgs) {
    var rc = 0;
    if (grdSF.recordNumber != null) rc = grdSF.get_recordCount();
    else if (grdSF.RecordCount != null) rc = grdSF.get_recordCount();
    
    if (rc > 0) {
        var e = $('#aRUploadCollapse').closest(".searchSection"),
                     t = $('#aRUploadCollapse').find("i"),
                     n = e.find("#divUpload");
        if ($('#aRUploadCollapse>i').attr('class') == "fa fa-chevron-down") {
            e.attr("style") ? n.slideToggle(200, function () {
                e.removeAttr("style")
            }) : (n.slideToggle(200), e.css("height", "auto")), t.toggleClass("fa-chevron-up fa-chevron-down")
        }

        //disable delete button
        var itemIndex = 0; var gridItem; var RowId = "0";
        var serial_no = ""; var upload_id = "";
        while (gridItem = grdSF.get_table().getRow(itemIndex)) {
            RowId = gridItem.Data[0].toString();
            if (RowId != '00000000-0000-0000-0000-000000000000') {
                serial_no = gridItem.Data[1].toString();
                if (document.getElementById("btnDelDCM_" + serial_no)!=null) {
                    document.getElementById("btnDelDCM_" + serial_no).style.display = "none";
                }
                
            }
            
            itemIndex++;
        }
    }
    else {
        var e = $('#aRUploadCollapse').closest(".searchSection"),
                     t = $('#aRUploadCollapse').find("i"),
                     n = e.find("#divUpload");
        if ($('#aRUploadCollapse>i').attr('class') == "fa fa-chevron-up") {
            e.attr("style") ? n.slideToggle(200, function () {
                e.removeAttr("style")
            }) : (n.slideToggle(200), e.css("height", "auto")), t.toggleClass("fa-chevron-up fa-chevron-down")
        }
    }

}


