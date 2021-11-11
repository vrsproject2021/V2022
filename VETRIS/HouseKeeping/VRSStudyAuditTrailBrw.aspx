﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VRSStudyAuditTrailBrw.aspx.cs" Inherits="VETRIS.HouseKeeping.VRSStudyAuditTrailBrw" %>

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
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/responsive.css" rel="stylesheet" />

    <link id="lnkSTYLE" runat="server" href="../css/style.css" rel="stylesheet" type="text/css" />
    <link id="lnkGRID" runat="server" href="../css/grid_style.css" rel="stylesheet" type="text/css" />
    <link id="lnkCAL" runat="server" href="../css/CalendarStyle.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery-1.7.1.js"></script>
    <script src="scripts/StudyAuditTrailBrwHdr.js?v=<%=DateTime.Now.Ticks%>"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="sparklineHeader mt-b-10 marginTP10">
                <div class="sparkline10-hd">
                    <div class="row">
                        <div class="col-sm-6 col-xs-12">
                            <h2>Study List</h2>
                        </div>
                        <div class="col-sm-6 col-xs-12 text-right">
                            <button type="button" class="btn btn-custon-four btn-default" onclick="view_Searchform();">
                                <span class="pull-left searchBySpan">Search By
                                </span>
                                <span id="Span1" class="pull-right">

                                    <i style="font-size: 12px;" class="fa fa-search searchBySpan" aria-hidden="true"></i>
                                </span>
                            </button>

                            <button type="button" class="btn btn-custon-four btn-danger" id="btnClose" runat="server">
                                <i class="fa fa-times edu-danger-error" aria-hidden="true"></i>&nbsp;Close
                                       
                            </button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="searchSection searchPanelBg" id="searchSection">
                <div>
                    <div>
                        <div class="row">
                            <div class="col-sm-4 col-xs-12">
                                <div class="form-group">
                                    <label class="control-label" for="username">Patient Name</label>
                                    <asp:TextBox ID="txtPatientName" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <div class="form-select-list">
                                    <label class="control-label">Modality</label>
                                    <asp:DropDownList ID="ddlModality" runat="server" CssClass="form-control custom-select-value"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4 col-xs-12">
                                <div class="form-select-list">
                                    <label class="control-label">Status</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control custom-select-value"></asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-sm-4">
                                <div class="optSwitch pull-left" style="margin-left: 10%; margin-bottom: 20px;">
                                    <asp:CheckBox ID="chkRecDt" runat="server" Checked="true" />
                                    <label for="chkRecDt" class="label-default"></label>
                                </div>
                                <div class="pull-left" style="margin-top: 10px; margin-left: 20px;">Received Date Between</div>

                                <div class="clearfix"></div>
                            </div>
                            <div class="col-sm-4 col-xs-12" style="margin-top: 10px;">
                                Institution
                            </div>
                            <div class="col-sm-4 col-xs-12" style="margin-top: 10px;">
                                Study UID
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-4">
                                <asp:TextBox ID="txtFromDt" runat="server" CssClass="form-control" MaxLength="10" Width="30%" placeholder="" Style="float: left;"></asp:TextBox>
                                <img id="imgFrom" runat="server" alt="" style="border: 0; cursor: pointer; float: left; margin-top: 8px; margin-left: 5px;" src="../images/cal.gif" align="absmiddle" />

                                <ComponentArt:Calendar runat="server" ID="CalFrom" AllowMonthSelection="false" AllowMultipleSelection="false"
                                    AllowWeekSelection="false" CalendarCssClass="calendar" CalendarTitleCssClass="title"
                                    ControlType="Calendar" DayCssClass="day" DayHeaderCssClass="dayheader" DayHoverCssClass="dayhover"
                                    DayNameFormat="FirstTwoLetters" ImagesBaseUrl="../images/" MonthCssClass="month"
                                    NextImageUrl="cal_nextMonth.gif" NextPrevCssClass="nextprev" OtherMonthDayCssClass="othermonthday"
                                    PopUp="Custom" PopUpExpandControlId="imgFrom" PrevImageUrl="cal_prevMonth.gif"
                                    SelectedDayCssClass="selectedday" SelectMonthCssClass="selector" SelectMonthText="&curren;"
                                    SelectWeekCssClass="selector" ReactOnSameSelection="true" SelectWeekText="&raquo;"
                                    SwapDuration="300" SwapSlide="Linear" MinDate="01/01/1900" MaxDate="01/01/2050">
                                    <ClientEvents>
                                        <SelectionChanged EventHandler="CalFrom_onSelectionChanged" />
                                    </ClientEvents>
                                </ComponentArt:Calendar>
                                <asp:TextBox ID="txtTillDt" runat="server" CssClass="form-control" MaxLength="10" Width="30%" placeholder="" Style="float: left; margin-left: 20px;"></asp:TextBox>
                                <img id="imgTill" runat="server" alt="" style="border: 0; cursor: pointer; float: left; margin-top: 8px; margin-left: 5px;" src="../images/cal.gif" align="absmiddle" />
                                <ComponentArt:Calendar runat="server" ID="CalTill" AllowMonthSelection="false" AllowMultipleSelection="false"
                                    AllowWeekSelection="false" CalendarCssClass="calendar" CalendarTitleCssClass="title"
                                    ControlType="Calendar" DayCssClass="day" DayHeaderCssClass="dayheader" DayHoverCssClass="dayhover"
                                    DayNameFormat="FirstTwoLetters" ImagesBaseUrl="../images/" MonthCssClass="month"
                                    NextImageUrl="cal_nextMonth.gif" NextPrevCssClass="nextprev" OtherMonthDayCssClass="othermonthday"
                                    PopUp="Custom" PopUpExpandControlId="imgTill" PrevImageUrl="cal_prevMonth.gif"
                                    SelectedDayCssClass="selectedday" SelectMonthCssClass="selector" SelectMonthText="&curren;"
                                    SelectWeekCssClass="selector" ReactOnSameSelection="true" SelectWeekText="&raquo;"
                                    SwapDuration="300" SwapSlide="Linear" MinDate="01/01/1900" MaxDate="01/01/2050">
                                    <ClientEvents>
                                        <SelectionChanged EventHandler="CalTill_onSelectionChanged" />
                                    </ClientEvents>
                                </ComponentArt:Calendar>
                                <div class="clearfix"></div>
                            </div>

                            <div class="col-sm-4 marginMobileTP10">
                                <div class="form-select-list">
                                    <asp:DropDownList ID="ddlInstitution" runat="server" CssClass="form-control custom-select-value"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-4 marginMobileTP10">
                                <div class="form-group">
                                    <asp:TextBox ID="txtStudyUID" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-4 col-xs-12" style="margin-top: 0px;margin-bottom: 5px;">
                                Priority
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4 marginMobileTP10">
                                <div class="form-select-list">
                                    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control custom-select-value"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-12 col-xs-12 text-right marginTP5">
                                <button type="button" class="btn btn-custon-four btn-warning" id="btnSearch" runat="server">
                                    <i class="fa fa-search edu-warning-danger" aria-hidden="true"></i>&nbsp;Search
                                           
                                </button>
                                <button type="button" class="btn btn-custon-four btn-success" id="btnRefresh" runat="server">
                                    <i class="fa fa-repeat edu-danger-error" aria-hidden="true"></i>&nbsp;Refresh
                                           
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>



            <div class="sparkline10-list mt-b-10">
                <div class="sparkline10-graph">
                    <div class="static-table-list">
                        <div class="table-responsive">
                            <ComponentArt:CallBack ID="CallBackBrw" runat="server" OnCallback="CallBackBrw_Callback">
                                <Content>
                                    <ComponentArt:Grid
                                        ID="grdBrw"
                                        CssClass="Grid"
                                        DataAreaCssClass="GridData20"
                                        SearchOnKeyPress="true"
                                        EnableViewState="true"
                                        RunningMode="Client"
                                        ShowSearchBox="false"
                                        SearchBoxPosition="TopLeft"
                                        SearchTextCssClass="GridHeaderText"
                                        ShowHeader="false"
                                        FooterCssClass="GridFooter"
                                        GroupingNotificationText=""
                                        PageSize="20"
                                        PagerPosition="BottomRight"
                                        PagerInfoPosition="BottomLeft"
                                        PagerStyle="Buttons"
                                        PagerTextCssClass="GridFooterText"
                                        PagerButtonWidth="24"
                                        PagerButtonHeight="24"
                                        PagerButtonHoverEnabled="true"
                                        SliderHeight="26"
                                        SliderWidth="150"
                                        SliderGripWidth="9"
                                        SliderPopupOffsetX="80"
                                        SliderPopupClientTemplateId="SliderTemplate"
                                        SliderPopupCachedClientTemplateId="CachedSliderTemplate"
                                        ImagesBaseUrl="../images/"
                                        PagerImagesFolderUrl="../images/pager/"
                                        LoadingPanelFadeDuration="1000"
                                        LoadingPanelFadeMaximumOpacity="80"
                                        LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                        LoadingPanelPosition="MiddleCenter"
                                        Width="99%"
                                        runat="server"
                                        HeaderCssClass="GridHeader"
                                        GroupingNotificationPosition="TopRight"
                                        SearchBoxCssClass="EditTextBoxStyle">

                                        <Levels>
                                            <ComponentArt:GridLevel
                                                AllowGrouping="false"
                                                DataKeyField="id"
                                                ShowTableHeading="false"
                                                TableHeadingCssClass="GridHeader"
                                                RowCssClass="Row"
                                                HoverRowCssClass="HoverRow"
                                                ColumnReorderIndicatorImageUrl="reorder.gif"
                                                DataCellCssClass="DataCell"
                                                HeadingCellCssClass="HeadingCell"
                                                HeadingRowCssClass="HeadingRow"
                                                HeadingTextCssClass="HeadingCellText"
                                                SortedDataCellCssClass="SortedDataCell"
                                                SelectedRowCssClass="SelectedRow"
                                                SortAscendingImageUrl="col-asc.png"
                                                SortDescendingImageUrl="col-desc.png"
                                                SortImageWidth="10"
                                                SortImageHeight="19">
                                                <ConditionalFormats>

                                                    <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdBrw.get_recordOffset()) % 2) > 0" RowCssClass="AltRow" SelectedRowCssClass="SelectedRow" />
                                                </ConditionalFormats>
                                                <Columns>
                                                    <ComponentArt:GridColumn DataField="id" Align="left" HeadingText="id" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="received_date" Align="left" HeadingText="Received On/At" AllowGrouping="false" Width="100" />
                                                    <ComponentArt:GridColumn DataField="study_uid" Align="left" HeadingText="Study UID" AllowGrouping="false" DataCellClientTemplateId="SUID" FixedWidth="True" Width="190" />
                                                    <ComponentArt:GridColumn DataField="patient_name" Align="left" HeadingText="Patient" AllowGrouping="false" DataCellClientTemplateId="PATIENT" FixedWidth="True" Width="110" />
                                                    <ComponentArt:GridColumn DataField="category" Align="left" HeadingText="Category" AllowGrouping="false" FixedWidth="True" Width="70" />
                                                    <%--4--%>
                                                    <ComponentArt:GridColumn DataField="modality_name" Align="left" HeadingText="Modality" AllowGrouping="false" DataCellClientTemplateId="MODALITY" FixedWidth="True" Width="100" />
                                                    <ComponentArt:GridColumn DataField="institution_name" Align="left" HeadingText="Institution" AllowGrouping="false" DataCellClientTemplateId="INSTITUTION" FixedWidth="True" Width="150" />
                                                    <ComponentArt:GridColumn DataField="priority_desc" Align="left" HeadingText="Priority" AllowGrouping="false" Width="70" />
                                                    <%--7--%>
                                                    <ComponentArt:GridColumn DataField="status_desc" Align="left" HeadingText="Status" AllowGrouping="false" Width="70" />
                                                    <ComponentArt:GridColumn DataField="date_updated" Align="left" HeadingText="Last Update On" AllowGrouping="false" Width="100" />
                                                    <ComponentArt:GridColumn Align="center" HeadingText=" " AllowGrouping="false" DataCellClientTemplateId="ACTION" FixedWidth="True" Width="120" />
                                                    <ComponentArt:GridColumn DataField="PACLOGINURL" Align="left" HeadingText="PACLOGINURL" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="PACSRPTVWRURL" Align="left" HeadingText="PACSRPTVWRURL" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="PACIMGVWRURL" Align="left" HeadingText="PACIMGVWRURL" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="study_status_pacs" Align="center" HeadingText="study_status_pacs" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="custom_report" Align="center" HeadingText="custom_report" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="accession_no" Align="center" HeadingText="accession_no" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="patient_id" Align="center" HeadingText="patient_id" AllowGrouping="false" Visible="false" />
                                                    <ComponentArt:GridColumn DataField="rpt_fmt" Align="center" HeadingText="rpt_fmt" AllowGrouping="false" Visible="false" />
                                                </Columns>

                                            </ComponentArt:GridLevel>
                                        </Levels>
                                        <ClientEvents>
                                            <RenderComplete EventHandler="grdBrw_onRenderComplete" />
                                        </ClientEvents>

                                        <ClientTemplates>

                                            <ComponentArt:ClientTemplate ID="PATIENT">
                                                <span id="spnUCust_## DataItem.GetMember('id').Value ##" title="## DataItem.GetMember('patient_name').Value ##">## DataItem.GetMember('patient_name').Value ##</span>
                                            </ComponentArt:ClientTemplate>
                                            <ComponentArt:ClientTemplate ID="SUID">
                                                <a href="javascript:void(0);" id="spnUSUID_## DataItem.GetMember('id').Value ##" title="## DataItem.GetMember('study_uid').Value ##" class="spanLink" style="text-decoration: none;" onclick="javascript:StudyUID_OnClick('## DataItem.GetMember('id').Value ##','## DataItem.GetMember('study_uid').Value ##');">## DataItem.GetMember('study_uid').Value ##</a>
                                            </ComponentArt:ClientTemplate>
                                            <ComponentArt:ClientTemplate ID="MODALITY">
                                                <span id="spnMod_## DataItem.GetMember('id').Value ##" title="## DataItem.GetMember('modality_name').Value ##">## DataItem.GetMember('modality_name').Value ##</span>
                                            </ComponentArt:ClientTemplate>
                                            <ComponentArt:ClientTemplate ID="INSTITUTION">
                                                <span id="spnInst_## DataItem.GetMember('id').Value ##" title="## DataItem.GetMember('institution_name').Value ##">## DataItem.GetMember('institution_name').Value ##</span>
                                            </ComponentArt:ClientTemplate>
                                            <ComponentArt:ClientTemplate ID="ACTION">
                                                <button type="button" id="btnAL_## DataItem.GetMember('id').Value ##" class="btn btn-info btn_grd" title="click to view the status audit trail of this study" onclick="javascript:btnAL_OnClick('## DataItem.GetMember('id').Value ##' ,'## DataItem.GetMember('study_uid').Value ##');">
                                                    <i class="fa fa-history" aria-hidden="true"></i>
                                                </button>
                                                <button type="button" id="btnRpt_## DataItem.GetMember('id').Value ##" style="display:none;" class="btn btn-success btn_grd" title="Report" onclick="javascript:btnRpt_OnClick('## DataItem.GetMember('id').Value ##','## DataItem.GetMember('PACSRPTVWRURL').Value ##','## DataItem.GetMember('patient_name').Value ##','## DataItem.GetMember('custom_report').Value ##','## DataItem.GetMember('rpt_fmt').Value ##');">
                                                    <i class="fa fa-file-text-o" aria-hidden="true"></i>
                                                </button>
                                                <button type="button" id="btnImg_## DataItem.GetMember('id').Value ##" style="display:none;" class="btn btn-warning btn_grd" title="Image(s)" onclick="javascript:btnImg_OnClick('## DataItem.GetMember('id').Value ##','## DataItem.GetMember('study_uid').Value ##','## DataItem.GetMember('accession_no').Value ##','## DataItem.GetMember('patient_id').Value ##','## DataItem.GetMember('PACIMGVWRURL').Value ##');">
                                                    <i class="fa fa-file-image-o" aria-hidden="true"></i>
                                                </button>
                                            </ComponentArt:ClientTemplate>

                                        </ClientTemplates>
                                    </ComponentArt:Grid>
                                    <span id="spnERR" runat="server"></span>
                                </Content>
                                <LoadingPanelClientTemplate>
                                    <table style="height: 830px; width: 100%;" border="0">
                                        <tr>
                                            <td style="text-align: center;">
                                                <table border="0" style="width: 70px; display: inline-block;">
                                                    <tr>
                                                        <td>
                                                            <img src="../images/Searching.gif" border="0" alt="" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </LoadingPanelClientTemplate>
                                <ClientEvents>
                                    <CallbackComplete EventHandler="grdBrw_onCallbackComplete" />
                                </ClientEvents>
                            </ComponentArt:CallBack>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <input type="hidden" id="hdnError" runat="server" value="" />
        <input type="hidden" id="hdnID" runat="server" value="00000000-0000-0000-0000-000000000000" />
        <input type="hidden" id="hdnAPIVER" runat="server" value="" />
        <input type="hidden" id="hdnWS8SRVIP" runat="server" value="" />
        <input type="hidden" id="hdnWS8CLTIP" runat="server" value="" />
        <input type="hidden" id="hdnWS8SRVUID" runat="server" value="" />
        <input type="hidden" id="hdnWS8SRVPWD" runat="server" value="" />
        <input type="hidden" id="hdnWS8Session" runat="server" value="" />

    </form>
</body>
<script type="text/javascript">
    var objhdnID = document.getElementById('<%=hdnID.ClientID %>');
    var objhdnError = document.getElementById('<%=hdnError.ClientID %>');
    var objtxtPatientName = document.getElementById('<%=txtPatientName.ClientID %>');
    var objddlModality = document.getElementById('<%=ddlModality.ClientID %>');
    var objddlStatus = document.getElementById('<%=ddlStatus.ClientID %>');
    var objchkRecDt = document.getElementById('<%=chkRecDt.ClientID %>');
    var objtxtFromDt = document.getElementById('<%=txtFromDt.ClientID %>');
    var objtxtTillDt = document.getElementById('<%=txtTillDt.ClientID %>');
    var objddlInstitution = document.getElementById('<%=ddlInstitution.ClientID %>');
    var objtxtStudyUID = document.getElementById('<%=txtStudyUID.ClientID %>');
    var objhdnAPIVER = document.getElementById('<%=hdnAPIVER.ClientID %>');
    var objhdnWS8SRVIP = document.getElementById('<%=hdnWS8SRVIP.ClientID %>');
    var objhdnWS8CLTIP = document.getElementById('<%=hdnWS8CLTIP.ClientID %>');
    var objhdnWS8SRVUID = document.getElementById('<%=hdnWS8SRVUID.ClientID %>');
    var objhdnWS8SRVPWD = document.getElementById('<%=hdnWS8SRVPWD.ClientID %>');
    var objhdnWS8Session = document.getElementById('<%=hdnWS8Session.ClientID %>');
    var objddlPriority = document.getElementById('<%=ddlPriority.ClientID %>');
    var strForm = "VRSStudyAuditTrailBrw";

</script>
<script src="../scripts/custome-javascript.js"></script>
<script src="../scripts/AppPages.js?25042020"></script>
<script src="scripts/StudyAuditTrailBrw.js?v=<%=DateTime.Now.Ticks%>"></script>
</html>
