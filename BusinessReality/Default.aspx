<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="BackOffice_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/deafult.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="js/default.js" type="text/javascript"></script>

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
                מהיום תוכלו להפיק מידע עסקי חכם אודות לקוחותיכם, להציע להם חווית קנייה ייחודית ובו
                זמנית לשווק את הארגון ברשתות החברתיות</p>
            <br />
            <div id="general">
                <asp:TextBox ID="txtEmail" class="textbox" runat="server" ></asp:TextBox>
                <br />
                <asp:TextBox ID="txtPassword" TextMode="Password" class="textbox" runat="server" ForeColor="Black"></asp:TextBox>
                <br />
                <asp:Button ID="btnSubmit" class="button" runat="server" Text="התחבר"  OnClick="btnSubmit_Click" />
                <br />
                <input type="button" class="registerBtn" id="addNewProfile" value="צור פרופיל חדש" />
            </div>
        </div>
    </div>
    <div class="wrap">
            <div id="register">
                <div dir="rtl" align="center">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                <strong>שם פרטי*:</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="MName" class="textbox" runat="server"></asp:TextBox>
                            </td>
                              <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required Field." ControlToValidate="MName" ForeColor="Red" ValidationGroup="Submit">
                                </asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th>
                                <strong>שם משפחה*:</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="MLName" class="textbox" runat="server"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required Field." ControlToValidate="MLName" ForeColor="Red" ValidationGroup="Submit">
                                </asp:RequiredFieldValidator>
                            </td>

                        </tr>
                        <tr>
                            <th>
                                <strong>שם משתמש (כתובת מייל*):</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="MEMail" class="textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <strong>סיסמא* :</strong>
                            </th>
                            <td>
                                <asp:TextBox TextMode="Password"  ID="MP" class="textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <strong>אימות סיסמא* :</strong>
                            </th>
                            <td>
                                <asp:TextBox TextMode="Password" ID="MP2" class="textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    
                     <br />
                      <br />
                    <input class="registerBtn" type="button" value="הקודם" id="priBtn" style="font-size: medium" />
                    &nbsp&nbsp&nbsp
                      <input class="registerBtn" type="button" value="ביטול" id="cancelRegisteration" style="font-size: medium" />
                      &nbsp&nbsp&nbsp 
                    <asp:Button ID="SubmitNewProfile" class="button" runat="server" Text="הוסף פרופיל"
                        OnClick="SubmitNewProfile_Click" Font-Size="Medium" Width="120" />
                </div>
            </div>
            <div id="companyRegister">
                <div dir="rtl" align="center">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>
                                <strong>*שם האירגון:</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="OName" class="textbox" runat="server"></asp:TextBox>
                            </td>
                            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required Field." ControlToValidate="OName" ForeColor="Red" ValidationGroup="Submit">
                                </asp:RequiredFieldValidator></td>
                        </tr>
                        <tr>
                            <th>
                                <strong>כתובת בית העסק:</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="Addres" class="textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <strong dir="rtl">*טלפון:</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="Phone" class="textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <strong style"top: auto">אודות בית העסק:</strong>
                            </th>
                            <td>
                                <textarea id="Odescription" runat="server" class="textbox" rows="5" style="height: 50px" name="Text1"></textarea>
                            </td>
                        </tr>
  
                        <tr>
                         </tr>
                          <tr>
                            <th>
                                <strong>עמוד פייסבוק:</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="FaceBook" class="textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <strong>אתר החברה:</strong>
                            </th>
                            <td>
                                <asp:TextBox ID="Site" class="textbox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th>
                                <strong>לוגו</strong>
                            </th>
                            <td>
                                <asp:FileUpload ID="File1" runat="server" />
                            </td>
                        </tr>
                    </table>

                     <br />
                      <br />

                    <input class="registerBtn" type="button" value="הבא" id="nextToRegister" style="font-size: medium" />
                    &nbsp&nbsp&nbsp
                    <input class="registerBtn" type="button" value="ביטול" id="cancelCompanyRegisteration" style="font-size: medium" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>


