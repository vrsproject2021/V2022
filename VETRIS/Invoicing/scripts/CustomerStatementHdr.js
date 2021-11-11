
function grdBrw_onCallbackComplete(sender, eventArgs) {
    grdBrw.Width = "99%";
    parent.adjustFrameHeight();
    //var strErr = parent.Trim(document.getElementById("hdnCBErr").value);
    //if (strErr != "") {
    //    parent.PopupMessage(RootDirectory, strForm, "grdBrw_onCallbackComplete()", strErr, "true");
    //}
}
function grdBrw_onItemSelect(sender, eventArgs) {
    parent.adjustFrameHeight();
}
function grdBrw_onRenderComplete(sender, eventArgs) {
    grdBrw.Width = "99%";
    var itemIndex = 0;
    var gridItem;
    var totalOutstanding = 0.00;
    while (gridItem = grdBrw.get_table().getRow(itemIndex)) {
        totalOutstanding +=parseFloat(parseFloat(gridItem.get_cells()[4].get_value().toString()).toFixed(2));

        itemIndex++;
    }
    $('#totalOutstanding').html(totalOutstanding.toFixed(2));
    parent.adjustFrameHeight();
}

function grdBrw_onItemExpand(sender, eventArgs) {
    parent.adjustFrameHeight();
}
function grdBrw_onItemCollapse(sender, eventArgs) {
    parent.adjustFrameHeight();
}
