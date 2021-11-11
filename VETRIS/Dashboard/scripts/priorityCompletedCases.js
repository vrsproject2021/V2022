var RootDirectory = parent.parent.objhdnRootDirectory.value;
google.charts.load('visualization', '1.0', { packages: ["corechart"] });

// date range store
var currentDate = new Date().getDate();
var addDate = new Date().setDate(currentDate);
var range = [new Date(addDate), new Date()];
// default date format from setting compatible to Flatpicker
// if setting is 'dd-MM-yyyy' it will be 'd-m-Y'
// if setting is 'MM/dd/yyyy' it will be 'm/d/Y'

var dateFormat = parent.parent.GsDateFormat.replace(/y{1,}/, 'Y').replace(/M{1,}/, 'm').replace(/d{1,}/, 'd')
/*
* Initialize date controls from and to
*/
var fromDate, toDate;
var _y = (new Date()).getFullYear(), _fromD = new Date(_y, 0, 1), _toD = new Date();
fromDate = flatpickr("#fromDate", {
    defaultDate: range[0],
    enable: [{
        from: _fromD,
        to: _toD
    }],
    dateFormat: dateFormat,

    onClose: function (selectedDates, dateStr, instance) {
        var from = selectedDates[0];
        if (toDate && from > toDate.selectedDates[0]) {
            toDate.setDate(from);
        }

        //$(".apply").trigger("click");
    }
});
//toDate = flatpickr("#toDate", {
//    defaultDate: range[1],
//    dateFormat: dateFormat,
//    enable: [{
//        from: _fromD,
//        to: _toD
//    }],
//    onClose: function (selectedDates, dateStr, instance) {
//        var to = selectedDates[0];
//        if (to < fromDate.selectedDates[0]) {
//            fromDate.setDate(to);
//        }
//    }
//});
function callSlotTime() {
    var strDtFrom = moment(fromDate.selectedDates[0], 'date').format("DDMMMyyyy");

    var ArrRecords = new Array();
    ArrRecords[0] = strDtFrom;
    ArrRecords[1] = $('#ddlModality option:selected').val();
    VRSPriorityCompletedCases.SearchRecord(ArrRecords, apply_callback);

}
function apply_callback(lineData) {
    var setTr = '';
    var trTotal = 0;
    if (lineData.value.Tables[0].Rows.length > 0) {
        $('#btnExcel').css('display', 'inline');
    }
    else {
        $('#btnExcel').css('display', 'none');
    }
    for (var i = 0; i < lineData.value.Tables[0].Rows.length; i++) {
        trTotal = (lineData.value.Tables[0].Rows[i].normal == null ? 0 : parseInt(lineData.value.Tables[0].Rows[i].normal)) +
                  (lineData.value.Tables[0].Rows[i].one_hr_stat == null ? 0 : parseInt(lineData.value.Tables[0].Rows[i].one_hr_stat)) +
                  (lineData.value.Tables[0].Rows[i].two_four_hr_stat == null ? 0 : parseInt(lineData.value.Tables[0].Rows[i].two_four_hr_stat));

        setTr += '<tr>' +
        '<td style="width:21%;">' + lineData.value.Tables[0].Rows[i].days_name + '</td>' +
        '<td>' + (lineData.value.Tables[0].Rows[i].normal == null ? 0 : parseInt(lineData.value.Tables[0].Rows[i].normal)) + '</td>' +
        '<td>' + (lineData.value.Tables[0].Rows[i].one_hr_stat == null ? 0 : parseInt(lineData.value.Tables[0].Rows[i].one_hr_stat)) + '</td>' +
        '<td>' + (lineData.value.Tables[0].Rows[i].two_four_hr_stat == null ? 0 : parseInt(lineData.value.Tables[0].Rows[i].two_four_hr_stat)) + '</td>' +
        '<td>' + trTotal + '</td>' +
        '</tr>';
    }

    if (setTr == '') {
        $('#lblTxt').css('display', 'block');
        $('#data').css('display', 'none');
    } else {
        $('#lblTxt').css('display', 'none');
        $('#data').css('display', 'block');
    }
    $('.tbody-main').html('');
    $('.tbody-main').html(setTr);

    $('#iframeDashboard').css('height', 'auto');
    var frame = parent.getElement("iframeDashboard");
    frame.style.height = '1285px';

}
callSlotTime();
if ($('#hdnreportTitle').val() === '')
    parent.$('#txtDescription').html('<span style="font-size:18px;">' + $('#hdnDesc').val() + '</span>');
else
    parent.$('#txtDescription').html('<span style="font-size:18px;">' + $('#hdnreportTitle').val() + '</span>');

$(document).ready(function () {
    if ($('#hdnIsRefreshBtn').val() == 'Y')
        parent.$('#btnReset').css('display', 'inline');
    else
        parent.$('#btnReset').css('display', 'none');
    parent.$('#btnReset').click(function () {
        callSlotTime();
        getPriorityCompletedCases();
    });
    if (parseInt($('#hdnRefreshTime').val()) > 0) {
        setInterval(function () {
            callSlotTime();
            getPriorityCompletedCases();
        }, $('#hdnRefreshTime').val() * 1000);
    }

});

function btnExcel_OnClick() {
    var ArrRecords = new Array();
    var strDtFrom = ""; var strDtTill = "";
    var strDtFrom = moment(fromDate.selectedDates[0], 'date').format("DDMMMyyyy");
    try {
        parent.parent.PopupProcess("N");

        ArrRecords[0] = $('#ddlModality option:selected').val();
        ArrRecords[1] = strDtFrom;
        ArrRecords[2] = parent.parent.objhdnUserID.value;
        //AjaxPro.timeoutPeriod = 1800000;
        VRSPriorityCompletedCases.GenerateExcel(ArrRecords, ShowProcess);
    }
    catch (expErr) {
        parent.parent.HideProcess();
        parent.parent.PopupMessage(RootDirectory, strForm, "btnExcel_OnClick()", expErr.message, "true");
    }

}

function ShowProcess(Result, MethodName) {
    parent.parent.HideProcess();
    var strMethod = MethodName.method;
    switch (strMethod) {
        case "GenerateExcel":
            ProcessReport(Result);
            break;
    }

}

function ProcessReport(Result) {
    var arrRet = new Array();
    arrRet = Result.value;
    switch (arrRet[0]) {
        case "catch":
            parent.parent.PopupMessage(RootDirectory, strForm, "ProcessReport()", arrRet[1], "true");
            break;
        case "false":
            parent.parent.PopupMessage(RootDirectory, strForm, "ProcessReport()", arrRet[1], "true");
            break;
        case "true":
            parent.parent.GsLaunchURL = arrRet[1];
            parent.parent.GsFilePath = arrRet[2];
            parent.parent.GsFileType = "XLS";
            parent.parent.PopupReportViewer();
            break;
    }
}
getPriorityCompletedCases();
var chartData = [];
function getPriorityPie() {
    getPriorityCompletedCases();
}

function getPriorityCompletedCases() {
    var strDtFrom = moment(fromDate.selectedDates[0], 'date').format("DDMMMyyyy");
    var ArrRecords = new Array();
    ArrRecords[0] = strDtFrom;
    ArrRecords[1] = $('#ddlModality option:selected').val();
    VRSPriorityCompletedCases.GetPriorityCompletedCases(ArrRecords, createArrayOfData_callback);
}

function createArrayOfData_callback(dataObj) {
    chartData = [];
    var data = {
        title: 'For the selected date',
        divId: 'pieCaseToday',
        data: dataObj.value.today,
        fillColor: $('#hdnTheme').val() == 'DARK' ? '#2C2C2C' : '#fff',
        isDark: $('#hdnTheme').val() == 'DARK' ? true : false
    };
    chartData.push(data);
    data = {
        title: 'Day before the selected date',
        divId: 'pieCaseYesterday',
        data: dataObj.value.yesterday,
        fillColor: $('#hdnTheme').val() == 'DARK' ? '#2C2C2C' : '#fff',
        isDark: $('#hdnTheme').val() == 'DARK' ? true : false
    };
    chartData.push(data);
    data = {
        title: 'Within last 7 days from the selected date',
        divId: 'pieSevenDays',
        data: dataObj.value.last_seven_days,
        fillColor: $('#hdnTheme').val() == 'DARK' ? '#2C2C2C' : '#fff',
        isDark: $('#hdnTheme').val() == 'DARK' ? true : false
    };
    chartData.push(data);
    data = {
        title: 'Within last 15 days from the selected date',
        divId: 'pieFifteenDays',
        data: dataObj.value.last_fifteen_days,
        fillColor: $('#hdnTheme').val() == 'DARK' ? '#2C2C2C' : '#fff',
        isDark: $('#hdnTheme').val() == 'DARK' ? true : false
    };
    chartData.push(data);
    data = {
        title: 'Within last 30 days from the selected date',
        divId: 'pieThirtyDays',
        data: dataObj.value.last_thirty_days,
        fillColor: $('#hdnTheme').val() == 'DARK' ? '#2C2C2C' : '#fff',
        isDark: $('#hdnTheme').val() == 'DARK' ? true : false
    };
    chartData.push(data);
    data = {
        title: 'Between 1st day of the selected date month - selected date',
        divId: 'pieMtd',
        data: dataObj.value.mtd,
        fillColor: $('#hdnTheme').val() == 'DARK' ? '#2C2C2C' : '#fff',
        isDark: $('#hdnTheme').val() == 'DARK' ? true : false
    };
    chartData.push(data);
    for (var i = 0; i < chartData.length; i++) {
        $('#' + chartData[i].divId + '_div').css('display', 'none');
        if (chartData[i].data.length > 0) {
            $('#first_div').css('display', 'flex');
            $('#' + chartData[i].divId + '_div').css('display', 'inline');
            loadGoogleChart(chartData[i]);
        }

    }

}