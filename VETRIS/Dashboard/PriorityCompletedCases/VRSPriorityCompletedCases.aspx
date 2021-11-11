<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VRSPriorityCompletedCases.aspx.cs" Inherits="VETRIS.Dashboard.PriorityCompletedCases.VRSPriorityCompletedCases" %>

<%@ Register Assembly="ComponentArt.Web.UI" Namespace="ComponentArt.Web.UI" TagPrefix="ComponentArt" %>
<%@ OutputCache Location="None" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Priority Completed Cases</title>
    <!-- Google Fonts
		============================================ -->
    <link href="https://fonts.googleapis.com/css?family=Roboto:100,300,400,700,900" rel="stylesheet" />
    <!-- Bootstrap CSS
		============================================ -->
    <link rel="stylesheet" href="../../css/bootstrap.min.css" />
    <!-- Bootstrap CSS
		============================================ -->
    <link rel="stylesheet" href="../../css/font-awesome.min.css" />
    <!-- metisMenu CSS
		============================================ -->
    <link rel="stylesheet" href="../../css/metisMenu/metisMenu.min.css" />
    <link rel="stylesheet" href="../../css/metisMenu/metisMenu-vertical.css?1" />
    <!-- style CSS
		============================================ -->
    <link id="lnkSTYLE" runat="server" href="../../css/style.css" rel="stylesheet" type="text/css" />
    <link id="dashboardSTYLE" runat="server" href="../css/dashboard.css" rel="stylesheet" type="text/css" />
    <link id="dashboardLightbox" runat="server" href="../../css/DARK/lightbox.css" rel="stylesheet" type="text/css" />
    <!-- responsive CSS
		============================================ -->
    <link rel="stylesheet" href="../../css/responsive.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css" />
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/css/select2.min.css" rel="stylesheet" />
        <script src="../../scripts/jquery-1.7.1.js"></script>
    
    <style>
        /*.table-responsive {
            overflow-x: hidden;
        }*/

        .Grid {
            width: 100%;
        }
        #btnExcel{
            float: right;
            margin-right: 13px;
            margin-top: 10px;
        }
        .flex-new-cases > div{
            width: 100%;
            /* height: 36rem; */
            height:auto;
            margin: 10px;
            padding: 2rem;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <header style="margin-top: 5px;">
            <div class="form-inline mt-2">

                <div class="form-group">
                    <label for="fromDate">As on Date:</label>
                    <input type="text" id="fromDate" placeholder="From" name="from" style="padding: 2px 4px; width: 92px;" class="date form-control" />
                </div>

                <div class="form-group">
                    <label for="md">Modality:</label>
                    <asp:DropDownList ID="ddlModality" AppendDataBoundItems="true" Style="padding: 2px 4px; width: 220px;" runat="server" CssClass="form-control custom-select-value"></asp:DropDownList>
                </div>
                <button id="btnApply" type="button" class="btn btn-custon-four btn-success btn-new-cases" onclick="callSlotTime();getPriorityPie();">
                    &nbsp;Apply
                </button>
                
            </div>

        </header>
        <%--<div class="flex-new-cases">
            <div id="line_chart"></div>
        </div>--%>
        <div class="flex-new-cases">
            <div>
                <table class="styled-table" id="data" style="display:none;">
                    <thead>
                        <tr>
                            <th>PERIOD</th>
                            <th>NORMAL</th>
                            <th>1 HOUR STAT</th>
                            <th>2-4 HOUR STAT</th>
                            <th>TOTAL</th>
                        </tr>
                    </thead>
                    <tbody class="tbody-main">
                        
                    </tbody>
                </table>
                <label id="lblTxt" style="display:none;text-align:center;font-size:16px;">No data found</label>
                <button type="button" class="btn btn-custon-four btn-success" id="btnExcel" style="display:none;" runat="server">
                    <i class="fa fa-file-excel-o" aria-hidden="true"></i>&nbsp;Generate Excel
                </button>
            </div>

        </div>

        <div class="flex-container-div" id="first_div" style="display:none;">
            <div class="chart-container" id="pieCaseToday_div" style="display:none;">
                <div class="chart-header ">For the selected date</div>
                <div id="pieCaseToday" class="chart-body "></div>
            </div>
            <div class="chart-container" id="pieCaseYesterday_div"  style="display:none;">
                <div class="chart-header ">Day before the selected date</div>
                <div id="pieCaseYesterday" class="chart-body"></div>
            </div>
            <div class="chart-container" id="pieSevenDays_div"  style="display:none;">
                <div class="chart-header ">Within last 7 days from the selected date</div>
                <div id="pieSevenDays" class="chart-body "></div>
            </div>

            <div class="chart-container" id="pieFifteenDays_div"  style="display:none;">
                <div class="chart-header ">Within last 15 days from the selected date</div>
                <div id="pieFifteenDays" class="chart-body "></div>
            </div>
            <div class="chart-container" id="pieThirtyDays_div"  style="display:none;">
                <div class="chart-header ">Within last 30 days from the selected date</div>
                <div id="pieThirtyDays" class="chart-body "></div>
            </div>
            <div class="chart-container" id="pieMtd_div"  style="display:none;">
                <div class="chart-header ">Between 1st day of the selected date month - selected date</div>
                <div id="pieMtd" class="chart-body "></div>
            </div>
        </div>

        <%--<div class="flex-container-div" id="second_div"  style="display:none;">
            
        </div>--%>
        <input type="hidden" runat="server" id="hdnRefreshTime" value="0" />
        <input type="hidden" runat="server" id="hdnIsRefreshBtn" value="N" />
        <input type="hidden" runat="server" id="hdnDesc" value="" />
        <input type="hidden" runat="server" id="hdnreportTitle" value="" />
        <input type="hidden" runat="server" id="hdnTheme" value="" />
    </form>


</body>

<%--<script src="../../scripts/windows-iana/dist/windows-iana.esm.js" crossorigin="anonymous"></script>--%>
<script src="../../scripts/moment.min.js" crossorigin="anonymous"></script>
<script src="../../scripts/moment-timezone-with-data.min.js" crossorigin="anonymous"></script>
<%--<script src="../../scripts/jquery-1.12.4.min.js" type="text/javascript"></script>--%>
<%--<script src="../../scripts/bootstrap.min.js" type="text/javascript"></script>--%>
<%--<script src="../../scripts/jquery-1.7.1.js" type="text/javascript"></script>--%>

<script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/flatpickr"></script>
<script src="https://cdn.jsdelivr.net/npm/flatpickr/dist/plugins/rangePlugin.js"></script>
<script>
    var strForm = "VRSPriorityCompletedCases";
</script>
<script src="../../scripts/custome-javascript.js"></script>
   
<script src="../scripts/Chart.2.9.4.js"></script>
<script src="https://cdn.jsdelivr.net/gh/emn178/chartjs-plugin-labels/src/chartjs-plugin-labels.js"></script>

<script src="../scripts/chartTools.js"></script>
<script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
<script src="../scripts/priorityCompletedCases.js?t=<%=DateTime.Now.Ticks%>"></script>
</html>

<script>
    //$(document).scrollTop($(document).height());
    //$('#dashboardreportcontainer').css('height', 'auto');
    parent.adjustDashboardFrameHeight();
</script>