function tvRights_onCallbackComplete(sender, eventArgs) {
    //parent.adjustFrameHeight();
}
function tvRights_onNodeCheckChanged(sender, eventArgs) {
    var node = eventArgs.get_node()
    var parentnode = node.get_parentNode();
    var check = false;
    //node.ExpandAll(); node.Expanded = true;
    //node.SaveState();
    
    if (parentnode) {
        if (parentnode.Checked & node.Checked) check = true;
        else {
            if (parentnode.Checked) {
                var x = parentnode.Nodes();
                var numofnodes = x.length;
                for (var i = 0; i < x.length; i++) {
                    if (x[i].Checked) { check = true; break;}
                }
            }
        }
        checkParentNode(parentnode, node, check);
        //Check if all items are selected
    }
    else {
        checkChildNodes(node);
    }

    tvRights.Render();

}
function checkChildNodes(node) {
    if (node.Checked) {
        node.checkAll();
    }
    else {
        node.unCheckAll();
    }
    //node.ExpandAll();
    node.SaveState();
}
function checkParentNode(parentnode, node,check) {
    var x = parentnode.Nodes();
    var numofnodes = x.length;
    var numofcheckednodes = 0;
    var parNode1; var parNode2; var parNode3; var parNode4;

    for (var i = 0; i < x.length; i++) {
        if (x[i].Checked) { numofcheckednodes++; }
    }
    //If all selected Select the Parent
    //if (numofcheckednodes > 0) {
    if (check) {
        if (numofcheckednodes > 0) {
            parentnode.set_checked(true); if (node.Nodes().length > 0) node.checkAll();
            parNode1 = parentnode.get_parentNode(); if (parNode1) parNode1.set_checked(true);
            if (parNode1) { parNode2 = parNode1.get_parentNode(); if (parNode2) parNode2.set_checked(true); }
            if (parNode2) { parNode3 = parNode2.get_parentNode(); if (parNode3) parNode3.set_checked(true); }
            if (parNode3) { parNode4 = parNode3.get_parentNode(); if (parNode4) parNode4.set_checked(true); }
        }
    }
    else {
        if (numofcheckednodes > 0) {
            parentnode.set_checked(false); if (node.Nodes().length > 0) node.unCheckAll();
            parNode1 = parentnode.get_parentNode(); if (parNode1) parNode1.set_checked(false);
            if (parNode1) { parNode2 = parNode1.get_parentNode(); if (parNode2) parNode2.set_checked(false); }
            if (parNode2) { parNode3 = parNode2.get_parentNode(); if (parNode3) parNode3.set_checked(false); }
            if (parNode3) { parNode4 = parNode3.get_parentNode(); if (parNode4) parNode4.set_checked(false); }
        }
    }

    //parentnode.ExpandAll();
    //node.ExpandAll();
    node.SaveState();
    parentnode.SaveState();
}
