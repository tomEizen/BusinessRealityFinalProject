<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BackOffice_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <link href="css/deafult.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form2" runat="server">
       <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="wrap">
        <div class="content">
            <div class="logo">
                <a href="Default.aspx">
                    <img src="img/logo.png" id="logo" /></a>
            </div>
            <p>
               מהיום תוכלו להפיק מידע עסקי חכם אודות לקוחותיכם, להציע להם חווית קנייה ייחודית ובו זמנית לשווק את הארגון ברשתות החברתיות</p>
            <br />
            <div id="general">
                <asp:TextBox ID="txtEmail" class="textbox" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" class="textbox" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="btnSubmit" class="button" runat="server" Text="התחבר" 
                    onclick="btnSubmit_Click"/>
                <br />
                <a href="" style="color: White" onclick="show('register')">צור פרופיל חדש</a>
            </div>
            <div id="register" class="displayNone">

            </div>
        </div>
        <div class="footer">
            <div class="social-icons">
                <a href="#"><span class="simptip-position-bottom simptip-movable" data-tooltip="Facebook">
                    <img src="img/LoginPage/f.png"></span></a> <a href="#"><span class="simptip-position-bottom simptip-movable"
                        data-tooltip="Rss">
                        <img src="img/LoginPage/r.png"></span></a> <a href="#"><span class="simptip-position-bottom simptip-movable"
                            data-tooltip="Twitter">
                            <img src="img/LoginPage/t1.png"></span></a>
                <div class="clear">
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
