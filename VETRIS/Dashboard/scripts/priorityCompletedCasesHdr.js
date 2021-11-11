function grdBrw_onCallbackComplete(sender, eventArgs) {
    grdBrw.Width = "99%";
    //parent.adjustFrameHeight();
    var strErr = parent.parent.Trim(document.getElementById("hdnCBErr").value);
    if (strErr != "") {
        parent.parent.PopupMessage(RootDirectory, strForm, "grdBrw_onCallbackComplete()", strErr, "true");
    }

    
}
function grdBrw_onRenderComplete(sender, eventArgs) {
    var itemIndex = 0; var gridItem;
    var RowId = "";
    var val1 = '';
    var val2 = '';
    var val3 = '';

    while (gridItem = grdBrw.get_table().getRow(itemIndex)) {
        RowId = gridItem.get_cells()[0].get_value().toString();
        val1 = gridItem.get_cells()[1].get_value().toString();
        val2 = gridItem.get_cells()[2].get_value().toString();
        val3 = gridItem.Data[3].toString();
        var total = (val1 == '' ? 0 : parseInt(val1)) + (val2 == '' ? 0 : parseInt(val2)) + (val3==''?0:parseInt(val3));
        grdBrw.beginUpdate();
        grdBrw.get_table().getRow(itemIndex).Data[4] = total;
        grdBrw.endUpdate();
        itemIndex++;
    }
}