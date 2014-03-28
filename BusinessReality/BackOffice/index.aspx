<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="BackOffice_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="css/catalog.css" rel="stylesheet" type="text/css" />
    <link href="css/css_LoginPage/style.css" rel="stylesheet" type="text/css" />
    <script src="js/index.js" type="text/javascript"></script>
</head>
<body>
    <form id="form2" runat="server">
       <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="wrap">
        <div class="content">
            <div class="logo">
                <a href="index.aspx">
                    <img src="img/logo.png" id="logo" /></a>
            </div>
            <p>
               מהיום תוכלו להפיק מידע עסקי חכם אודות לקוחות הארגון, להציע להם חווית קנייה יחודית ותוך כדי לשווק את הארגון ברשתות החברתיות</p>
            <br />
            <div id="general">
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnSubmit" runat="server" Text="התחבר" />
                <br />
                <a href="" style="color: White" onclick="show('register')">צור פרופיל חדש</a>
            </div>
            <div id="register" class="displayNone">
                <img src="img/img_LoginPage/bg.jpg" />  
            </div>
        </div>
        <div class="footer">
            <div class="social-icons">
                <a href="#"><span class="simptip-position-bottom simptip-movable" data-tooltip="Facebook">
                    <img src="img/img_LoginPage/f.png"></span></a> <a href="#"><span class="simptip-position-bottom simptip-movable"
                        data-tooltip="Rss">
                        <img src="img/img_LoginPage/r.png"></span></a> <a href="#"><span class="simptip-position-bottom simptip-movable"
                            data-tooltip="Twitter">
                            <img src="img/img_LoginPage/t1.png"></span></a>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
