﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VRSCaseArchivelDlg.aspx.cs" Inherits="VETRIS.CaseList.VRSCaseArchivelDlg" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
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
     <link id="lnkSTYLE" runat="server" href = "../css/style.css" rel="stylesheet" type="text/css" />
    <link id="lnkGRID" runat="server" href = "../css/grid_style.css" rel="stylesheet" type="text/css" />

    <script src="ckeditor/ckeditor.js"></script>
    <script src="../scripts/jquery.min.js"></script>
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="scripts/CaseArchiveDlgHdr.js?v=<%=DateTime.Now.Ticks%>" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            <div class="sparklineHeader mt-b-10 marginTP10">
                <div class="sparkline10-hd">
                    <div class="row">
                        <div class="col-sm-2 col-xs-12">
                            <h2>Study Details </h2>
                        </div>
                        <%--<div class="col-sm-2 col-xs-12">
                            <button type="button" class="btn btn-custon-four btn-danger" id="btnDel1" runat="server">
                                <i class="fa fa-trash-o edu-danger-error" aria-hidden="true"></i>&nbsp;DELETE CASE
                            </button>
                        </div>--%>
                        <div class="col-sm-4 col-xs-12 text-center">
                            <button type="button" class="btn btn-custon-four btn-primary" id="btnSave1" runat="server">
                                <i class="fa fa-floppy-o edu-danger-error" aria-hidden="true"></i>&nbsp;Save       
                            </button>
                            <button type="button" class="btn btn-custon-four btn-primary" id="btnSaveTrans1" runat="server" style="display: none;">
                                <i class="fa fa-floppy-o edu-danger-error" aria-hidden="true"></i>&nbsp;Save       
                            </button>
                            <button type="button" class="btn btn-custon-four btn-warning" id="btnReset1" runat="server">
                                <i class="fa fa-repeat edu-danger-error" aria-hidden="true"></i>&nbsp;Reset   
                            </button>

                            <button type="button" class="btn btn-custon-four btn-danger" id="btnClose1" runat="server">
                                <i class="fa fa-times edu-danger-error" aria-hidden="true"></i>&nbsp;Close   
                            </button>

                        </div>
                        <div class="col-sm-6 col-xs-12 text-right">
                            
                            <button type="button" runat="server" class="btn btn-custon-four btn-primary" id="btnDownload1">
                                 <i class="fa fa-download" aria-hidden="true"></i>&nbsp;Download Image(s) Of Current Study
                                       
                            </button>
                            <button type="button" runat="server" class="btn btn-custon-four btn-success" id="btnView1">
                                <i class="fa fa-eye edu-danger-error" aria-hidden="true"></i>&nbsp;View Image(s) Of Current Study
                                       
                            </button>
                        </div>
                    </div>
                </div>
            </div>
            <div class="sparklineHeader mt-b-10">
                <div class="sparkline10-hd">

                    <div class="row">
                        <div class="col-sm-12 col-xs-12 text-right" id="divDisclaimer" runat="server">
                        </div>
                    </div>


                </div>
            </div>
            <div class="sparkline10-list mt-b-10" id="divStudyUID">
                <div class="sparkline10-hd">
                    <div class="row">
                        <div class="col-sm-8 col-xs-8">
                            Study UID : 
                            <asp:Label ID="lblSUID" runat="server"></asp:Label>
                        </div>
                        <div class="col-sm-4 col-xs-4">
                            &nbsp;
                        </div>

                    </div>
                </div>
            </div>
            <div class="sparkline10-list mt-b-10">
                <div class="row">
                    <div class="col-sm-6 col-xs-12">
                        <div class="searchSection">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">

                                    <div class="pull-left">
                                        <h3 class="h3Text">Study Details</h3>
                                    </div>

                                    <div class="borderSearch pull-left"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="row">
                                        <div class="col-sm-4 col-xs-12">
                                            Study Date
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblDOS" runat="server"></asp:Label>
                                        </div>

                                    </div>

                                    <div class="row marginTP10">
                                        <div class="col-sm-4 col-xs-12">
                                            Modality
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblModality" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="row marginTP10">
                                        <div class="col-sm-4 col-xs-12">
                                            Category
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblCategory" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="row marginTP10">
                                        <div class="col-sm-4 col-xs-12">
                                            Institution
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblInstitution" runat="server"></asp:Label>
                                        </div>

                                    </div>

                                    <div class="row marginTP10">
                                        <div class="col-sm-4 col-xs-12">
                                            Referring Physician
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblPhys" runat="server"></asp:Label>

                                        </div>

                                    </div>

                                    <div class="row marginTP10">
                                        <div class="col-sm-4 col-xs-12">
                                            Accession No.
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblAccnNo" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="row marginTP10">
                                        <div class="col-sm-4 col-xs-12">
                                            Priority
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblPriority" runat="server"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="row marginTP10">
                                        <div class="col-sm-4 col-xs-12">
                                            Service(s)
                                        </div>
                                        <div class="col-sm-8 col-xs-12">
                                            <asp:Label ID="lblServices" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row marginTP10">
                                       <div class="col-sm-4 col-xs-12">
                                            No. of
                                            <asp:Label ID="lblImg" runat="server" Text="Image(s)"></asp:Label>
                                            <asp:Label ID="lblObj" runat="server" Text="Object(s)"></asp:Label>
                                        </div>
                                        <div class="col-sm-4 col-xs-12">
                                            <asp:Label ID="lblCnt" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-sm-4 col-xs-12">
                                            <button type="button" class="btn btn-custon-four btn-success" title="click to refresh the count" id="btnRefreshCount" runat="server" style="cursor: pointer; float: left; margin-left: 2px; margin-left: 2px;display:none;">
                                                <i class="fa fa-refresh" aria-hidden="true"></i>
                                            </button>
                                        </div>
                                       
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xs-12">
                        <div class="searchSection">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="pull-left">
                                        <h3 class="h3Text">Patient Details</h3>
                                    </div>
                                    <div class="borderSearch pull-left"></div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-4 col-xs-12">
                                    Patient ID
                                </div>
                                <div class="col-sm-8 col-xs-12">
                                    <asp:Label ID="lblPatientID" runat="server"></asp:Label>
                                </div>

                            </div>

                            <div class="row marginTP10">
                                <div class="col-sm-4 col-xs-12">
                                    Patient Name
                                </div>
                                <div class="col-sm-8 col-xs-12">
                                    <asp:Label ID="lblPatientName" runat="server"></asp:Label>
                                </div>

                            </div>
                             <div class="row marginTP10">
                                <div class="col-sm-4 col-xs-12">
                                    Date Of Birth/Age
                                </div>
                                <div class="col-sm-8 col-xs-12">
                                    <asp:Label ID="lblDOB" runat="server"></asp:Label>
                                    /
                                    <asp:Label ID="lblAge" runat="server"></asp:Label>
                                </div>
                               
                            </div>
                            <div class="row marginTP10">

                                <div class="col-sm-4 col-xs-12">
                                    Sex
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <asp:Label ID="lblSex" runat="server"></asp:Label>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    Country
                                </div>
                                <div class="col-sm-4 col-xs-12">
                                    <asp:Label ID="lblCountry" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row marginTP10">

                                <div class="col-sm-4 col-xs-12">
                                    Spayed/Neutered
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <asp:Label ID="lblSN" runat="server"></asp:Label>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    State
                                </div>
                                <div class="col-sm-4 col-xs-12">
                                    <asp:Label ID="lblState" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row marginTP10">
                                <div class="col-sm-4 col-xs-12">
                                    Weight
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    <asp:Label ID="lblPWt" runat="server"></asp:Label>
                                </div>
                                <div class="col-sm-2 col-xs-12">
                                    City
                                </div>
                                <div class="col-sm-4 col-xs-12">
                                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row marginTP10">

                                <div class="col-sm-4 col-xs-12">
                                    Species
                                </div>
                                <div class="col-sm-8 col-xs-12">
                                    <asp:Label ID="lblSpecies" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row marginTP10">

                                <div class="col-sm-4 col-xs-12">
                                    Breed
                                </div>
                                <div class="col-sm-8 col-xs-12">
                                    <asp:Label ID="lblBreed" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row marginTP10">

                                <div class="col-sm-4 col-xs-12">
                                    Owner Name
                                </div>
                                <div class="col-sm-8 col-xs-12">
                                    <asp:Label ID="lblOwner" runat="server"></asp:Label>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="pull-left">
                                        <h3 class="h3Text">History/Reason for study</h3>
                                    </div>
                                    <div class="borderSearch pull-left"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12 marginTP5">
                                    <div id="divHistory" runat="server" style="height: 80px; overflow: auto"></div>
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="pull-left">
                                        <h3 class="h3Text">Note For Physician</h3>
                                    </div>
                                    <div class="borderSearch pull-left"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12 marginTP5">
                                    <div id="divPhysNote" runat="server" style="height: 80px; overflow: auto"></div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="col-sm-5 col-xs-5 pull-left marginTP5">
                                        <h3 class="h3Text">Study Types</h3>
                                    </div>
                                    <div class="col-sm-3 col-xs-3 pull-left marginTP5">
                                        <h3 class="h3Text">
                                            <span id="spnSTCount" style="display: none;"></span>
                                        </h3>
                                    </div>
                                    <div class="col-sm-4 col-xs-4 text-right" >
                                        <button type="button" id="btnEditST" runat="server" class="btn btn-custon-four btn-success" title="click to add/delete study types" style="display: none;padding:1px 6px;">
                                            <i class="fa fa-pencil-square-o" aria-hidden="true"></i>
                                        </button>
                                    </div>
                                    <div class="borderSearch pull-left"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12 marginMobileTP5">
                                    <div class="table-responsive">
                                        <ComponentArt:CallBack ID="CallBackSelST" runat="server" OnCallback="CallBackSelST_Callback">
                                            <Content>
                                                <ComponentArt:Grid
                                                    ID="grdSelST"
                                                    CssClass="Grid"
                                                    DataAreaCssClass="GridData4"
                                                    SearchOnKeyPress="true"
                                                    EnableViewState="true"
                                                    ShowSearchBox="false"
                                                    SearchBoxPosition="TopRight"
                                                    SearchTextCssClass="GridHeaderText" AutoFocusSearchBox="false"
                                                    ShowHeader="false"
                                                    FooterCssClass="GridFooter"
                                                    GroupingNotificationText=""
                                                    PageSize="4"
                                                    ScrollBar="Auto"
                                                    ScrollTopBottomImagesEnabled="true"
                                                    ScrollTopBottomImageHeight="2"
                                                    ScrollTopBottomImageWidth="16"
                                                    ScrollImagesFolderUrl="../images/scroller/"
                                                    ScrollButtonWidth="16"
                                                    ScrollButtonHeight="17" ShowFooter="false"
                                                    ScrollBarCssClass="ScrollBar"
                                                    ScrollGripCssClass="ScrollGrip"
                                                    ScrollBarWidth="16"
                                                    PagerTextCssClass="GridFooterText"
                                                    ImagesBaseUrl="../images/"
                                                    LoadingPanelFadeDuration="1000"
                                                    LoadingPanelFadeMaximumOpacity="80"
                                                    LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                                    LoadingPanelPosition="MiddleCenter"
                                                    Width="99%"
                                                    runat="server" HeaderCssClass="GridHeader"
                                                    GroupingNotificationPosition="TopRight">

                                                    <Levels>
                                                        <ComponentArt:GridLevel
                                                            AllowGrouping="false"
                                                            DataKeyField="srl_no"
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
                                                            SortAscendingImageUrl="col-asc.png"
                                                            SortDescendingImageUrl="col-desc.png"
                                                            SortImageWidth="10"
                                                            SortImageHeight="19">
                                                            <ConditionalFormats>
                                                                <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdSelST.get_recordOffset()) % 2) > 0" RowCssClass="AltRow" SelectedRowCssClass="AltRow" />
                                                                <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdSelST.get_recordOffset()) % 2) == 0" RowCssClass="Row" SelectedRowCssClass="Row" />
                                                            </ConditionalFormats>
                                                            <Columns>
                                                                <ComponentArt:GridColumn DataField="srl_no" Align="left" HeadingText="#" AllowGrouping="false" Width="30" />
                                                                <ComponentArt:GridColumn DataField="study_type_id" Align="left" HeadingText="study_type_id" AllowGrouping="false" Visible="false" />
                                                                <ComponentArt:GridColumn DataField="study_type_name" Align="left" HeadingText="Study Type" AllowGrouping="false" Width="300" />

                                                            </Columns>

                                                        </ComponentArt:GridLevel>
                                                    </Levels>
                                                      <ClientEvents>
                                                        <RenderComplete EventHandler="grdSelST_onRenderComplete" />
                                                    </ClientEvents>

                                                </ComponentArt:Grid>
                                                <span id="spnErrSelST" runat="server"></span>
                                            </Content>
                                            <LoadingPanelClientTemplate>
                                                <table style="height: 170px; width: 100%;" border="0">
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <table border="0" style="width: 70px; display: inline-block;">
                                                                <tr>
                                                                    <td>
                                                                        <img src="../images/spinner-darkgrey.gif" width="50" height="65" border="0" alt="" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </LoadingPanelClientTemplate>
                                            <ClientEvents>
                                                <CallbackComplete EventHandler="grdSelST_onCallbackComplete" />
                                            </ClientEvents>
                                        </ComponentArt:CallBack>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">
                                    <div class="row">
                                        <div class="col-sm-8 col-xs-8">
                                            <h3 class="h3Text">Uploaded Document(s)</h3>
                                        </div>
                                        <div class="col-sm-4 col-xs-4 text-right">
                                            &nbsp;
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-12 col-xs-12">
                                    <div class="borderSearch"></div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12 marginMobileTP5">
                                    <div class="table-responsive">
                                        <ComponentArt:CallBack ID="CallBackDoc" runat="server" OnCallback="CallBackDoc_Callback">
                                            <Content>
                                                <ComponentArt:Grid
                                                    ID="grdDoc"
                                                    CssClass="Grid"
                                                    DataAreaCssClass="GridData4"
                                                    SearchOnKeyPress="true"
                                                    EnableViewState="true"
                                                    ShowSearchBox="true"
                                                    SearchBoxPosition="TopRight"
                                                    SearchTextCssClass="GridHeaderText"
                                                    ShowHeader="false"
                                                    FooterCssClass="GridFooter"
                                                    GroupingNotificationText=""
                                                    PageSize="4"
                                                    ScrollBar="Auto"
                                                    ScrollTopBottomImagesEnabled="true"
                                                    ScrollTopBottomImageHeight="2"
                                                    ScrollTopBottomImageWidth="16"
                                                    ScrollImagesFolderUrl="../images/scroller/"
                                                    ScrollButtonWidth="16"
                                                    ScrollButtonHeight="17" ShowFooter="false"
                                                    ScrollBarCssClass="ScrollBar"
                                                    ScrollGripCssClass="ScrollGrip"
                                                    ScrollBarWidth="16"
                                                    PagerTextCssClass="GridFooterText"
                                                    ImagesBaseUrl="../images/"
                                                    LoadingPanelFadeDuration="1000"
                                                    LoadingPanelFadeMaximumOpacity="80"
                                                    LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                                    LoadingPanelPosition="MiddleCenter"
                                                    Width="99%"
                                                    runat="server" HeaderCssClass="GridHeader"
                                                    GroupingNotificationPosition="TopLeft">

                                                    <Levels>
                                                        <ComponentArt:GridLevel
                                                            AllowGrouping="false"
                                                            DataKeyField="document_srl_no"
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
                                                            SortAscendingImageUrl="col-asc.png"
                                                            SortDescendingImageUrl="col-desc.png"
                                                            SortImageWidth="10"
                                                            SortImageHeight="19">
                                                            <ConditionalFormats>
                                                                <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdDoc.get_recordOffset()) % 2) > 0" RowCssClass="AltRow" SelectedRowCssClass="AltRow" />
                                                                <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdDoc.get_recordOffset()) % 2) == 0" RowCssClass="Row" SelectedRowCssClass="Row" />
                                                            </ConditionalFormats>
                                                            <Columns>
                                                                <ComponentArt:GridColumn DataField="document_srl_no" Align="left" HeadingText="#" AllowGrouping="false" Width="30" />
                                                                <ComponentArt:GridColumn DataField="document_id" Align="left" HeadingText="document_id" AllowGrouping="false" Visible="false" />
                                                                <ComponentArt:GridColumn DataField="document_name" Align="left" HeadingText="Document Name" AllowGrouping="false" Width="150" />
                                                                <ComponentArt:GridColumn DataField="document_link" Align="left" HeadingText="Document Link" AllowGrouping="false" DataCellClientTemplateId="FILE_LINK" FixedWidth="True" Width="150" />
                                                                <ComponentArt:GridColumn DataField="document_file_type" Align="left" HeadingText="document_file_type" AllowGrouping="false" Visible="false" />
                                                                <ComponentArt:GridColumn DataField="del_doc" Align="center" AllowGrouping="false" DataCellClientTemplateId="DELDOC" HeadingText=" " FixedWidth="True" Width="30" Visible="false" />
                                                            </Columns>

                                                        </ComponentArt:GridLevel>
                                                    </Levels>

                                                    <ClientEvents>
                                                        <RenderComplete EventHandler="grdDoc_onRenderComplete" />
                                                    </ClientEvents>
                                                    <ClientTemplates>
                                                        <ComponentArt:ClientTemplate ID="FILE_LINK">
                                                            <a href="#" style="color: blue; text-decoration: underline" id="lnkDoc_## DataItem.GetMember('document_srl_no').Value ##" title="## DataItem.GetMember('document_link').Value ##" onclick="ShowDocument('## DataItem.GetMember('document_srl_no').Value ##','## DataItem.GetMember('document_link').Value ##')">## DataItem.GetMember('document_link').Value ##</a>
                                                        </ComponentArt:ClientTemplate>
                                                        <ComponentArt:ClientTemplate ID="DELDOC">
                                                            <button type="button" id="btnDelDoc_## DataItem.GetMember('document_srl_no').Value ##" class="btn btn-danger btn_grd" onclick="javascript:DeleteDocument('## DataItem.GetMember('document_srl_no').Value ##')"><i class="fa fa-trash" aria-hidden="true"></i></button>
                                                        </ComponentArt:ClientTemplate>
                                                    </ClientTemplates>
                                                </ComponentArt:Grid>
                                                <span id="spnERRDoc" runat="server"></span>
                                            </Content>
                                            <LoadingPanelClientTemplate>
                                                <table style="height: 170px; width: 100%;" border="0">
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <table border="0" style="width: 70px; display: inline-block;">
                                                                <tr>
                                                                    <td>
                                                                        <img src="../images/spinner-darkgrey.gif" width="50" height="65" border="0" alt="" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </LoadingPanelClientTemplate>
                                            <ClientEvents>
                                                <CallbackComplete EventHandler="grdDoc_onCallbackComplete" />
                                            </ClientEvents>
                                        </ComponentArt:CallBack>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12 col-xs-12">

                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">

                                    <div class="pull-left">
                                        <h3 class="h3Text">Observations</h3>
                                    </div>

                                    <div class="borderSearch pull-left"></div>
                                </div>
                            </div>
                            <div class="row">

                                  <div class="col-sm-12 col-xs-12">
                                    <div id="divFindings" runat="server" style="height: 150px; overflow: auto; display: block;"></div>
                                </div>
                                <div class="col-sm-12 col-xs-12" id="rptEditor" style="display: none;">
                                    <CKEditor:CKEditorControl ID="editorFindings" runat="server" DisableNativeSpellChecker="false" RemovePlugins="scayt,contextmenu"
                                        Toolbar="Source|-|NewPage|Preview|-|Templates
                                                                                Cut|Copy|Paste|PasteText|PasteFromWord|-|Print
                                                                                Undo|Redo|-|Find|Replace|-|Bold|Italic|Underline|-|Subscript|Superscript
                                                                                NumberedList|BulletedList|-|Outdent|Indent
                                                                                JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock
                                                                                Table|HorizontalRule|SpecialChar|PageBreak|-|TextColor|BGColor|-|Maximize|ShowBlocks
                                                                                /
                                                                                Styles|Format|Font|FontSize"
                                        Height="250px" Width="100%"></CKEditor:CKEditorControl>

                                </div>
                                <div class="col-sm-12 col-xs-12" id="rptTB" style="display: none;">
                                    <asp:TextBox ID="txtReport" runat="server" CssClass="form-control" TextMode="MultiLine" Height="250px"></asp:TextBox>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">

                                    <div class="pull-left">
                                        <h3 class="h3Text">List of Addendums
                                        </h3>
                                    </div>

                                    <div class="borderSearch pull-left"></div>
                                </div>


                            </div>
                            <div class="row">

                                <div class="col-sm-12 col-xs-12 marginMobileTP5">
                                    <div class="table-responsive">
                                        <ComponentArt:CallBack ID="CallBackAddn" runat="server" OnCallback="CallBackAddn_Callback">
                                            <Content>
                                                <ComponentArt:Grid
                                                    ID="grdAddn"
                                                    CssClass="Grid"
                                                    DataAreaCssClass="GridData4"
                                                    SearchOnKeyPress="true"
                                                    EnableViewState="true"
                                                    ShowSearchBox="false"
                                                    SearchBoxPosition="TopRight"
                                                    SearchTextCssClass="GridHeaderText" AutoFocusSearchBox="false"
                                                    ShowHeader="false"
                                                    FooterCssClass="GridFooter"
                                                    GroupingNotificationText=""
                                                    PageSize="4"
                                                    ScrollBar="Auto"
                                                    ScrollTopBottomImagesEnabled="true"
                                                    ScrollTopBottomImageHeight="2"
                                                    ScrollTopBottomImageWidth="16"
                                                    ScrollImagesFolderUrl="../images/scroller/"
                                                    ScrollButtonWidth="16"
                                                    ScrollButtonHeight="17" ShowFooter="false"
                                                    ScrollBarCssClass="ScrollBar"
                                                    ScrollGripCssClass="ScrollGrip"
                                                    ScrollBarWidth="16"
                                                    PagerTextCssClass="GridFooterText"
                                                    ImagesBaseUrl="../images/"
                                                    LoadingPanelFadeDuration="1000"
                                                    LoadingPanelFadeMaximumOpacity="80"
                                                    LoadingPanelClientTemplateId="LoadingFeedbackTemplate"
                                                    LoadingPanelPosition="MiddleCenter"
                                                    Width="99%"
                                                    runat="server" HeaderCssClass="GridHeader"
                                                    GroupingNotificationPosition="TopRight">

                                                    <Levels>
                                                        <ComponentArt:GridLevel
                                                            AllowGrouping="false"
                                                            DataKeyField="addendum_srl"
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
                                                            SortAscendingImageUrl="col-asc.png"
                                                            SortDescendingImageUrl="col-desc.png"
                                                            SortImageWidth="10"
                                                            SortImageHeight="19">
                                                            <ConditionalFormats>
                                                                <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdAddn.get_recordOffset()) % 2) > 0" RowCssClass="AltRow" SelectedRowCssClass="AltRow" />
                                                                <ComponentArt:GridConditionalFormat ClientFilter="((DataItem.get_index() + grdAddn.get_recordOffset()) % 2) == 0" RowCssClass="Row" SelectedRowCssClass="Row" />
                                                            </ConditionalFormats>
                                                            <Columns>
                                                                <ComponentArt:GridColumn DataField="addendum_srl" Align="left" HeadingText="#" AllowGrouping="false" Width="30" />
                                                                <ComponentArt:GridColumn DataField="addendum_text" Align="left" HeadingText="Addendum Text" AllowGrouping="false" Width="500" />
                                                                <ComponentArt:GridColumn Align="center" HeadingText=" " AllowGrouping="false" Width="30" DataCellClientTemplateId="VIEWADDN" FixedWidth="True" />
                                                            </Columns>

                                                        </ComponentArt:GridLevel>
                                                    </Levels>
                                                    <ClientTemplates>
                                                        <ComponentArt:ClientTemplate ID="VIEWADDN">
                                                            <button type="button" id="btnViewAddn_## DataItem.GetMember('addendum_srl').Value ##" class="btn btn-warning btn_grd" title="click to view" onclick="javascript:btnViewAddn_OnClick('## DataItem.GetMember('addendum_srl').Value ##');">
                                                                <i class="fa fa-eye" aria-hidden="true"></i>
                                                            </button>
                                                        </ComponentArt:ClientTemplate>
                                                    </ClientTemplates>

                                                </ComponentArt:Grid>
                                                <span id="spnADDNErr" runat="server"></span>
                                            </Content>
                                            <LoadingPanelClientTemplate>
                                                <table style="height: 170px; width: 100%;" border="0">
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <table border="0" style="width: 70px; display: inline-block;">
                                                                <tr>
                                                                    <td>
                                                                        <img src="../images/spinner-darkgrey.gif" width="50" height="65" border="0" alt="" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </LoadingPanelClientTemplate>
                                            <ClientEvents>
                                                <CallbackComplete EventHandler="grdAddn_onCallbackComplete" />
                                            </ClientEvents>
                                        </ComponentArt:CallBack>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">

                                    <div class="pull-left">
                                        <h3 class="h3Text">Addendum <span class="mandatory">*</span></h3>
                                    </div>

                                    <div class="borderSearch pull-left"></div>
                                </div>


                            </div>
                            <div class="row">
                                 <div class="col-sm-12 col-xs-12">
                                    <div id="divAddendum" runat="server" style="height: 80px; overflow: auto; display: block;"></div>
                               </div>
                                   <div class="col-sm-12 col-xs-12" id="addnEditor" style="display: none;">

                                    <CKEditor:CKEditorControl ID="editorAddendum" runat="server" DisableNativeSpellChecker="false" RemovePlugins="scayt,contextmenu"
                                        Toolbar="Source|-|NewPage|Preview|-|Templates
                                                                                Cut|Copy|Paste|PasteText|PasteFromWord|-|Print
                                                                                Undo|Redo|-|Find|Replace|-|Bold|Italic|Underline|-|Subscript|Superscript
                                                                                NumberedList|BulletedList|-|Outdent|Indent
                                                                                JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock
                                                                                Table|HorizontalRule|SpecialChar|PageBreak|-|TextColor|BGColor|-|Maximize|ShowBlocks
                                                                                /
                                                                                Styles|Format|Font|FontSize"
                                        Height="80px" Width="100%">
                                    </CKEditor:CKEditorControl>
                                </div>
                                <div class="col-sm-12 col-xs-12" id="addnTB" style="display: none;">
                                    <asp:TextBox ID="txtAddendum" runat="server" CssClass="form-control" TextMode="MultiLine" Height="80px"></asp:TextBox>
                                </div>


                            </div>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-12 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                <div class="col-sm-12 col-xs-12">

                                    <div class="pull-left">
                                        <h3 class="h3Text">Report Disclaimer Reason</h3>
                                    </div>

                                    <div class="borderSearch pull-left"></div>
                                </div>


                            </div>
                            <div class="row">

                                <div class="col-sm-12 col-xs-12">
                                    <div class="form-select-list">
                                        <asp:DropDownList ID="ddlDisclReason" runat="server" CssClass="form-control custom-select-value"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-xs-12 marginTP5">
                                      <asp:TextBox ID="txtRptDisclText" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px"></asp:TextBox>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="sparkline10-list mt-b-10">
                <div class="row">
                    <div class="col-sm-12 col-xs-12">
                        <div class="searchSection marginTP10">
                            <div class="row">
                                  <div class="col-sm-10 col-xs-12">&nbsp;</div>
                                  <div class="col-sm-2 col-xs-12">
                                    <div class="optSwitch pull-left" style="margin-bottom: 20px;">
                                        <asp:CheckBox ID="chkTeach" runat="server" />
                                        <label for="chkTeach" class="label-default"></label>
                                    </div>
                                    <div class="pull-left" style="margin-top: 10px; margin-left: 20px;">Mark for teaching</div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="sparklineHeader marginTP10">
                <div class="sparkline10-hd">
                    <div class="row">
                        <div class="col-sm-2 col-xs-12">
                        </div>
                        <%--<div class="col-sm-2 col-xs-12">
                              <button type="button" class="btn btn-custon-four btn-danger" id="btnDel2" runat="server">
                                <i class="fa fa-trash-o edu-danger-error" aria-hidden="true"></i>&nbsp;DELETE CASE   
                            </button>
                        </div>--%>
                        <div class="col-sm-4 col-xs-12 text-center">
                            <button type="button" class="btn btn-custon-four btn-primary" id="btnSave2" runat="server">
                                <i class="fa fa-floppy-o edu-danger-error" aria-hidden="true"></i>&nbsp;Save   
                            </button>
                            <button type="button" class="btn btn-custon-four btn-primary" id="btnSaveTrans2" runat="server" style="display: none;">
                                <i class="fa fa-floppy-o edu-danger-error" aria-hidden="true"></i>&nbsp;Save       
                            </button>
                            <button type="button" class="btn btn-custon-four btn-warning" id="btnReset2" runat="server">
                                <i class="fa fa-repeat edu-danger-error" aria-hidden="true"></i>&nbsp;Reset 
                            </button>

                            <button type="button" class="btn btn-custon-four btn-danger" id="btnClose2" runat="server">
                                <i class="fa fa-times edu-danger-error" aria-hidden="true"></i>&nbsp;Close     
                            </button>

                        </div>
                        <div class="col-sm-6 col-xs-12 text-right">
                             <button type="button" runat="server" class="btn btn-custon-four btn-primary" id="btnDownload2">
                                 <i class="fa fa-download" aria-hidden="true"></i>&nbsp;Download Image(s) Of Current Study
                                       
                            </button>
                            <button type="button" runat="server" class="btn btn-custon-four btn-success" id="btnView2">
                                <i class="fa fa-eye edu-danger-error" aria-hidden="true"></i>&nbsp;View Image(s) Of Current Study
                                       
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <input type="hidden" id="hdnError" runat="server" value="" />
        <input type="hidden" id="hdnID" runat="server" value="00000000-0000-0000-0000-000000000000" />
        <input type="hidden" id="hdnRptID" runat="server" value="00000000-0000-0000-0000-000000000000" />
        <input type="hidden" id="hdnCF" runat="server" value="" />
        <input type="hidden" id="hdnSUID" runat="server" value="" />
        <input type="hidden" id="hdnFilename" runat="server" value="" />
        <input type="hidden" id="hdnFilePath" runat="server" value="" />
        <input type="hidden" id="hdnModalityID" runat="server" value="0" />
        <input type="hidden" id="hdnCurrStatusID" runat="server" value="0" />
        <input type="hidden" id="hdnPACSURL" runat="server" value="" />
        <input type="hidden" id="hdnImgVwrURL" runat="server" value="" />
        <input type="hidden" id="hdnAPIVER" runat="server" value="" />
        <input type="hidden" id="hdnWS8SRVIP" runat="server" value="" />
        <input type="hidden" id="hdnWS8CLTIP" runat="server" value="" />
        <input type="hidden" id="hdnWS8SRVUID" runat="server" value="" />
        <input type="hidden" id="hdnWS8SRVPWD" runat="server" value="" />
        <input type="hidden" id="hdnWS8SYVWRURL" runat="server" value="" />
        <input type="hidden" id="hdnWS8IMGVWRURL" runat="server" value="" />
        <input type="hidden" id="hdnVRSAPPLINK" runat="server" value="" />
        <input type="hidden" id="hdnStudyDelUrl" runat="server" value="" />
        <input type="hidden" id="hdnRadFnRights" runat="server" value="" />
        <input type="hidden" id="hdnLockedUser" runat="server" value="" />
        <input type="hidden" id="hdnPrelimRadID" runat="server" value="00000000-0000-0000-0000-000000000000" />
        <input type="hidden" id="hdnAssnRadID" runat="server" value="00000000-0000-0000-0000-000000000000" />
        <input type="hidden" id="hdnPACSCred" runat="server" value="" />
         <input type="hidden" id="hdnInvBy" runat="server" value="" />
        <input type="hidden" id="hdnTrackBy" runat="server" value="" />
        <input type="hidden" id="hdnSyncMode" runat="server" value="" />
    </form>
</body>
<script type="text/javascript">
    var objhdnID = document.getElementById('<%=hdnID.ClientID %>');
    var objhdnRptID = document.getElementById('<%=hdnRptID.ClientID %>');
    var objhdnError = document.getElementById('<%=hdnError.ClientID %>');
    var objhdnCF = document.getElementById('<%=hdnCF.ClientID %>');
    var objhdnSUID = document.getElementById('<%=hdnSUID.ClientID %>');
    var objhdnFilename = document.getElementById('<%=hdnFilename.ClientID %>');
    var objhdnFilePath = document.getElementById('<%=hdnFilePath.ClientID %>');
    var objlblPatientID = document.getElementById('<%=lblPatientID.ClientID %>');
    var objlblAccnNo = document.getElementById('<%=lblAccnNo.ClientID %>');
    var objdivFindings = document.getElementById('<%=divFindings.ClientID %>');
    var objtxtReport = document.getElementById('<%=txtReport.ClientID %>');
    var objdivAddendum = document.getElementById('<%=divAddendum.ClientID %>');
    var objtxtAddendum = document.getElementById('<%=txtAddendum.ClientID %>');
    var objddlDisclReason = document.getElementById('<%=ddlDisclReason.ClientID %>');
    var objtxtRptDisclText = document.getElementById('<%=txtRptDisclText.ClientID %>');
    var objchkTeach = document.getElementById('<%=chkTeach.ClientID %>');
    var objhdnModalityID = document.getElementById('<%=hdnModalityID.ClientID %>');
    var objhdnCurrStatusID = document.getElementById('<%=hdnCurrStatusID.ClientID %>');
    var objhdnWS8SRVIP = document.getElementById('<%=hdnWS8SRVIP.ClientID %>');
    var objhdnWS8CLTIP = document.getElementById('<%=hdnWS8CLTIP.ClientID %>');
    var objhdnWS8SRVUID = document.getElementById('<%=hdnWS8SRVUID.ClientID %>');
    var objhdnWS8SRVPWD = document.getElementById('<%=hdnWS8SRVPWD.ClientID %>');
    var objhdnAPIVER = document.getElementById('<%=hdnAPIVER.ClientID %>');
    var objhdnStudyDelUrl = document.getElementById('<%=hdnStudyDelUrl.ClientID %>');
    var objhdnWS8SYVWRURL = document.getElementById('<%=hdnWS8SYVWRURL.ClientID %>');
    var objhdnWS8IMGVWRURL = document.getElementById('<%=hdnWS8IMGVWRURL.ClientID %>');
    var objhdnVRSAPPLINK = document.getElementById('<%=hdnVRSAPPLINK.ClientID %>');
    var objhdnRadFnRights = document.getElementById('<%=hdnRadFnRights.ClientID %>');
    var objhdnPrelimRadID = document.getElementById('<%=hdnPrelimRadID.ClientID %>');
    var objhdnAssnRadID = document.getElementById('<%=hdnAssnRadID.ClientID %>');
    var objhdnLockedUser = document.getElementById('<%=hdnLockedUser.ClientID %>');
    var objhdnInvBy = document.getElementById('<%=hdnInvBy.ClientID %>');
    var objhdnPACSCred = document.getElementById('<%=hdnPACSCred.ClientID %>');
    var objlblCnt = document.getElementById('<%=lblCnt.ClientID %>');
    var objhdnTrackBy = document.getElementById('<%=hdnTrackBy.ClientID %>');
    var objhdnSyncMode = document.getElementById('<%=hdnSyncMode.ClientID %>');
    var objbtnSave1 = document.getElementById('<%=btnSave1.ClientID %>');
    var objbtnSave2 = document.getElementById('<%=btnSave2.ClientID %>');
    var objbtnEditST = document.getElementById('<%=btnEditST.ClientID %>');
    var objbtnRefreshCount = document.getElementById('<%=btnRefreshCount.ClientID %>');
    var strForm = "VRSCaseArchivelDlg";

</script>
<script src="../scripts/custome-javascript.js"></script>
<script src="../scripts/AppPages.js?v=<%=DateTime.Now.Ticks%>"></script>
<script src="scripts/CaseArchiveDlg.js?v=<%=DateTime.Now.Ticks%>"></script>
</html>
