function grdInst_onCallbackComplete(sender, eventArgs) {
    grdInst.Width = "99%";
    parent.adjusDataListFrameHeight();
    var strErr = parent.Trim(document.getElementById("hdnCBErr").value);
    if (strErr != "") {
        objlblMsg.innerHTML = "<font color='red'>" + strErr + "</font>";
    }
    
    // - Paging setup
    //var gridItem = grdInst.get_table().getRow(0);
    //if (gridItem) {
    //    objhdnTotalRecords.value = gridItem.get_cells()[4].get_value().toString();
    //}
    //else {
    //    objhdnTotalRecords.value = "0";
    //}
    //if (document.all) document.getElementById("spnTotRecs").innerText = objhdnTotalRecords.value;
    //else document.getElementById("spnTotRecs").textContent = objhdnTotalRecords.value;
    //Render_Paging();
}
function grdInst_onRenderComplete(sender, eventArgs) {
    var itemIndex = 0; var gridItem;
    var RowId = ""; var sel = "";
   
    while (gridItem = grdInst.get_table().getRow(itemIndex)) {
        RowId = gridItem.get_cells()[0].get_value().toString();
        sel = gridItem.Data[3].toString();
        if (document.getElementById("chkSel_" + RowId) != null) {
            if (sel == "Y") document.getElementById("chkSel_" + RowId).checked = true;
            else document.getElementById("chkSel_" + RowId).checked = false;
        }

        
        itemIndex++;
    }


}