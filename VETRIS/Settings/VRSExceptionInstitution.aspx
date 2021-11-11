<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VRSExceptionInstitution.aspx.cs" Inherits="VETRIS.Settings.VRSExceptionInstitution" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ OutputCache Location="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="x-ua-compatible" content="ie=edge" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,700,900" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,700,900" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/responsive.css" rel="stylesheet" />

    <link id="lnkSTYLE" runat="server" href="../css/style.css" rel="stylesheet" type="text/css" />
    <link id="lnkGRID" runat="server" href="../css/grid_style.css" rel="stylesheet" type="text/css" />
    <link id="lnkTHEME" runat="server" href="" rel="stylesheet" type="text/css" />

    <script src="../scripts/jquery-1.7.1.js"></script>
    <script src="../scripts/jquery.soverlay.min.js"></script>
    <script src="scripts/ExceptionInstitutionHdr.js?v=<%=DateTime.Now.Ticks%>"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="sparklineHeader mt-b-10 marginTP10">
                <div class="sparkline10-hd">
                    <div class="row">
                        <div class="col-sm-6 col-xs-12">
                            <h2>Exception Institution(s)
                                <span id="spnAfterHrs"></span>
                            </h2>
                        </div>
                        <div class="col-sm-6 col-xs-12 text-right">

                            <button type="button" id="btnOk1" runat="server" class="btn btn-success">
                                <i class="fa fa-check" aria-hidden="true"></i>&nbsp;Ok</button>

                            <button type="button" class="btn btn-custon-four btn-danger" id="btnClose1" runat="server">
                                <i class="fa fa-times" aria-hidden="true"></i>&nbsp;Close</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="sparkline10-list mt-b-10">
                <div class="sparkline10-graph">
                    <div class="searchSection">

                                    <ComponentArt:CallBack ID="CallBackInst" runat="server" OnCallback="CallBackInst_Callback">
                                        <Content>
                                            <ComponentArt:Grid
                                                ID="grdInst"
                                                CssClass="Grid"
                                                AutoTheming="true"
                                                DataAreaCssClass="GridData12"
                                                SearchOnKeyPress="true"
                                                EnableViewState="true" 
                                                ShowSearchBox="true"
                                                SearchBoxPosition="TopLeft"
                                                SearchTextCssClass="GridHeaderText" AutoFocusSearchBox="True"
                                                ShowHeader="true"
                                                FooterCssClass="GridFooter"
                                                GroupingNotificationText=""
                                                PageSize="12"
                                                PagerPosition="BottomRight"
                                                PagerInfoPosition="BottomLeft"
                                                PagerStyle="Buttons"
                                                PagerButtonWidth="24"
                                                PagerButtonHeight="24"
                                                PagerButtonHoverEnabled="true"
                                                SliderHeight="26"
                                                SliderWidth="150"
                                                SliderGripWidth="9"
                                                SliderPopupOffsetX="80"
                                                SliderPopupClientTemplateId="SliderTemplate"
                                                SliderPopupCachedClientTemplateId="CachedSliderTemplate"
                                                PagerTextCssClass="GridFooterText"
                                                ImagesBaseUrl="../images/"
                                                PagerImagesFolderUrl="../images/pager/"
                                                LoadingPanelFadeDuration="1000"
                                                LoadingPanelFadeMaximumOpacity="80"
                                                LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                                LoadingPanelPosition="MiddleCenter"
                                                Width="99%"
                                                runat="server"
                                                HeaderCssClass="GridHeader"
                                                GroupingNotificationPosition="TopRight" EnableTheming="False" EditOnClickSelectedItem="False">
                                                <Levels>
                                                    <ComponentArt:GridLevel AllowGrouping="false"
                                                        DataKeyField="institution_id"
                                                        ShowTableHeading="false"
                                                        TableHeadingCssClass="GridHeader"
                                                        RowCssClass="Row"
                                                        HoverRowCssClass="HoverRow"
                                                        ColumnReorderIndicatorImageUrl="reorder.gif"
                                                        DataCellCssClass="DataCell"
                                                        HeadingCellCssClass="HeadingCell"
                                                        HeadingRowCssClass="HeadingRow"
                                                        HeadingTextCssClass="HeadingCellText"
                                                        EditCellCssClass="active"
                                                        SortedDataCellCssClass="SortedDataCell"
                                                        SelectedRowCssClass="SelectedRow"
                                                        SortAscendingImageUrl="col-asc.png"
                                                        SortDescendingImageUrl="col-desc.png"
                                                        SortImageWidth="10"
                                                        SortImageHeight="19"
                                                        SelectorCellWidth="20"
                                                        ShowSelectorCells="false">
                                                        <ConditionalFormats>
                                                            <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdInst.get_recordOffset()) % 2) > 0" RowCssClass="AltRow" SelectedRowCssClass="SelectedRow" />
                                                        </ConditionalFormats>
                                                        <Columns>
                                                            <ComponentArt:GridColumn DataField="institution_id" Align="left" HeadingText="institution_id" AllowGrouping="false" Visible="false" />
                                                            <ComponentArt:GridColumn DataField="code" Align="left" HeadingText="Code" AllowGrouping="false" Width="80" />
                                                            <ComponentArt:GridColumn DataField="name" Align="left" HeadingText="Name" AllowGrouping="false" Width="200" />
                                                            <ComponentArt:GridColumn DataField="sel" Align="left" HeadingText="Select" AllowGrouping="false" Width="50" DataCellClientTemplateId="SEL" FixedWidth="true" AllowSorting="False" />
                                                           
                                                        </Columns>

                                                    </ComponentArt:GridLevel>

                                                </Levels>
                                                <ClientEvents>
                                                    <RenderComplete EventHandler="grdInst_onRenderComplete" />
                                                </ClientEvents>
                                                <ClientTemplates>
                                                    <ComponentArt:ClientTemplate ID="SEL">
                                                        <div class="grid_option optSwitch pull-left">
                                                            <input type="checkbox" id="chkSel_## DataItem.GetMember('institution_id').Value ##" onclick="javascript: chkSel_OnClick('## DataItem.GetMember('institution_id').Value ##');" />
                                                            <label for="chkSel_## DataItem.GetMember('institution_id').Value ##" class="label-default"></label>
                                                        </div>
                                                    </ComponentArt:ClientTemplate>

                                                </ClientTemplates>
                                            </ComponentArt:Grid>
                                            <span id="spnERR" runat="server"></span>

                                        </Content>
                                        <LoadingPanelClientTemplate>
                                            <table style="height: 375px; width: 100%;" border="0">
                                                <tr>
                                                    <td style="text-align: center;">
                                                        <table border="0" style="width: 70px; display: inline-block;">
                                                            <tr>
                                                                <td>
                                                                    <img src="../images/spinner-darkgrey.gif" border="0" alt="" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </LoadingPanelClientTemplate>
                                        <ClientEvents>
                                            <CallbackComplete EventHandler="grdInst_onCallbackComplete" />
                                        </ClientEvents>
                                    </ComponentArt:CallBack>

                                    <%--<nav aria-label="Page navigation">
                                        <ul class="pagination">
                                            <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                                            <li class="page-item"><a class="page-link" href="#">1</a></li>
                                            <li class="page-item"><a class="page-link" href="#">Next</a></li>
                                        </ul>
                                        <ul class="pagination1" id="ulTotRecs" style="float: right">
                                            <li class="page-item active"><a class="page-link" href="#" style="cursor: default;">Total Record(s)
                                            </a></li>
                                            <li class="page-item"><a class="page-link" href="#" style="cursor: default;">
                                                <span id="spnTotRecs"></span>
                                            </a></li>
                                        </ul>
                                    </nav>--%>
                    </div>
                    
                </div>
            </div>
            <div class="sparklineHeader marginTP10" id="divMsg">
                <div class="sparkline10-hd">
                    <div class="row">
                        <div class="col-sm-12 col-xs-12">
                            <asp:Label ID="lblMsg" runat="server">&nbsp;</asp:Label>
                        </div>
                    </div>
                </div>
            </div>
            <div class="sparklineHeader mt-b-10 marginTP10">
                <div class="sparkline10-hd">
                    <div class="row">
                        <div class="col-sm-6 hidden-xs">
                        </div>
                        <div class="col-sm-6 col-xs-12 text-right">
                            <button type="button" id="btnOk2" runat="server" class="btn btn-success">
                                <i class="fa fa-check" aria-hidden="true"></i>&nbsp;Ok</button>

                            <button type="button" class="btn btn-custon-four btn-danger" id="btnClose2" runat="server">
                                <i class="fa fa-times" aria-hidden="true"></i>&nbsp; Close</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" id="hdnError" runat="server" value="" />
        <input type="hidden" id="hdnFilter" runat="server" value="" />
        <input type="hidden" id="hdnRecordID" runat="server" value="0" />
        <input type="hidden" id="hdnSvcID" runat="server" value="0" />
        <input type="hidden" id="hdnAvbl" runat="server" value="" />
        <input type="hidden" id="hdnDispMsg" runat="server" value="" />
        <input type="hidden" id="hdnAfterHrs" runat="server" value="" />
        <input type="hidden" id="hdnTotalRecords" runat="server" value="0" />
        <input type="hidden" id="hdnPageSize" runat="server" value="12" />
        <input type="hidden" id="hdnPageNo" runat="server" value="1" />
    </form>

</body>
<script type="text/javascript">
    
    var objhdnError = document.getElementById('<%=hdnError.ClientID %>');
    var objhdnFilter= document.getElementById('<%=hdnFilter.ClientID %>');
    var objhdnRecordID = document.getElementById('<%=hdnRecordID.ClientID %>');
    var objhdnSvcID = document.getElementById('<%=hdnSvcID.ClientID %>');//--
    var objhdnAvbl = document.getElementById('<%=hdnAvbl.ClientID %>');
    var objhdnDispMsg = document.getElementById('<%=hdnDispMsg.ClientID %>');
    var objhdnAfterHrs = document.getElementById('<%=hdnAfterHrs.ClientID %>');
    var objlblMsg = document.getElementById('<%=lblMsg.ClientID %>');
    var objhdnTotalRecords = document.getElementById('<%=hdnTotalRecords.ClientID %>');
    var objhdnPageSize = document.getElementById('<%=hdnPageSize.ClientID %>');
    var objhdnPageNo = document.getElementById('<%=hdnPageNo.ClientID %>');
    var strForm = "VRSExceptionInstitution";

</script>
<script src="../scripts/custome-javascript.js"></script>
<script src="scripts/ExceptionInstitution.js?v=<%=DateTime.Now.Ticks%>"></script>
<script type="text/javascript">
    SetPageValue();
</script>
</html>
