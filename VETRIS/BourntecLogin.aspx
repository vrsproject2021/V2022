<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BourntecLogin.aspx.cs" Inherits="VETRIS.BourntecLogin" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Radiology Information System</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.5.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="css/bournCss/style.css">
    <link rel="stylesheet" href="css/bournCss/responsive.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <link href='https://fonts.googleapis.com/css?family=Lato:100,300,400,700,900,100italic,300italic,400italic,700italic,900italic&subset=latin,latin-ext' rel='stylesheet' type='text/css'>
</head>
<body>
    <!-- partial:index.partial.html -->
    <div class="row loging-bg">

        <div class="col-md-6 right">
            <div class="login-right-inner">
                <div class="login-logo">
                    <img src="images/bourntecImages/logo-blue.svg" />
                </div>

                <div class="login-welcome">
                    Welcome to
       
                    <span>Radiology Information System</span>
                    <p>Please login to your account</p>
                </div>

              <form id="form1" runat="server">

                    <div class="form-group">
                        <label class="control-label">User Login ID</label>
                        <asp:textbox id="txtLoginID" runat="server" placeholder="" title="Please enter you Login ID" cssclass="form-control"></asp:textbox>
                        <span class="help-block small">Enter your unique Login ID for the application</span>

                    </div>
                    <div class="form-group">
                        <label class="control-label" for="txtPwd">Password</label>
                        <asp:TextBox ID="txtPwd" runat="server" placeholder="******" title="lease enter your password" CssClass="" TextMode="Password"></asp:TextBox>
                        <span class="help-block small">Enter your strong password</span>
                    </div>
                    <div class="login-checkbox-outer">


                        <div class="login-checkbox-left">
                            <%--     <input type="checkbox" id="vehicle1" name="vehicle1" value="Bike">
  <label for="vehicle1">Remember Password!</label>--%>
                            <label>
                                <asp:checkbox id="chkRemember" runat="server" cssclass="i-checks" />
                                Remember me
                            </label>
                            <a href="javascript:void(0);" style="float: right; color: red;" onclick="javascript:PWDHelp();">Forgot Password?</a>
                        </div>
                        <div class="login-checkbox-right ">
                            <a href="#">Forget Password?</a>
                        </div>
                    </div>
                    <%--<input type="submit" value="Login" class="login-submit">--%>

                    <button id="btnLogin" type="button" class="btn btn-success btn-block loginbtn" runat="server">
                        Login
                    </button>
                </form>
            </div>
        </div>

        <div class="col-md-6 left">
        </div>

        <div class="login-left-copy-write copy-wirte-block">Copyright © 2021. All Rights Reserved.</div>
    </div>


    <!-- partial -->

    <input type="hidden" id="hdnError" runat="server" value="" />
    <input type="hidden" id="hdnDivider" runat="server" value="" />
    <input type="hidden" id="hdnDBVer" runat="server" />
    <input type="hidden" id="hdnRootDirectory" runat="server" />
    <input type="hidden" id="hdnMailTaskRefNo" runat="server" value="" />
    <input type="hidden" id="hdnMailAssignType" runat="server" value="" />
    <input type="hidden" id="hdnUID" runat="server" value="" />
    <input type="hidden" id="hdnPwd" runat="server" value="" />
    <input type="hidden" id="hdnTheme" runat="server" value="" />
    <input type="hidden" id="hdnInstCode" runat="server" value="" />
    <input type="hidden" id="hdnMenuID" runat="server" value="0" />
    <input type="hidden" id="hdnTempInstID" runat="server" value="00000000-0000-0000-0000-000000000000" />
</body>
<script type="text/javascript">
    var objhdnRootDirectory = document.getElementById('<%=hdnRootDirectory.ClientID%>');
    var objhdnError = document.getElementById('<%=hdnError.ClientID%>');
    var objhdnDivider = document.getElementById('<%=hdnDivider.ClientID%>');
    var objtxtLoginID = document.getElementById('<%=txtLoginID.ClientID%>');
    var objtxtPwd = document.getElementById('<%=txtPwd.ClientID%>');
    var objchkRemember = document.getElementById('<%=chkRemember.ClientID%>');
    var objhdnDBVer = document.getElementById('<%=hdnDBVer.ClientID%>');
    var objhdnUID = document.getElementById('<%=hdnUID.ClientID%>');
    var objhdnPwd = document.getElementById('<%=hdnPwd.ClientID%>');
    var objhdnInstCode = document.getElementById('<%=hdnInstCode.ClientID%>');
    var objhdnMenuID = document.getElementById('<%=hdnMenuID.ClientID%>');
    var objhdnTempInstID = document.getElementById('<%=hdnTempInstID.ClientID%>');
    var objhdnTheme = document.getElementById('<%=hdnTheme.ClientID%>');
   <%-- var objlblVersion = document.getElementById('<%=lblVersion.ClientID%>');--%>
    var GsLaunchURL = "";
    var strForm = "VRSLogin";
</script>
<script src="scripts/custome-javascript.js" type="text/javascript"></script>
<script src="scripts/Login.js?v=<%=DateTime.Now.Ticks%>" type="text/javascript"></script>
</html>

