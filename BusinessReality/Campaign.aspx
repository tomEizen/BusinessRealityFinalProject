<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Campaign.aspx.cs" Inherits="BackOffice_Campaign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Campaign| Business Reality</title>
    <link rel="stylesheet" type="text/css" href="css/reset.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/text.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/grid.css" media="screen" />  
    <link rel="stylesheet" type="text/css" href="css/layout.css" media="screen"  />
    <link rel="stylesheet" type="text/css" href="css/nav.css" media="screen" />
    <link href="css/catalog.css" rel="stylesheet" type="text/css" />
    <!--[if IE 6]><link rel="stylesheet" type="text/css" href="css/ie6.css" media="screen" /><![endif]-->
    <!--[if IE 7]><link rel="stylesheet" type="text/css" href="css/ie.css" media="screen" /><![endif]-->
    <link href="css/table/demo_page.css" rel="stylesheet" type="text/css" />
    <!-- BEGIN: load jquery -->
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-ui/jquery.ui.core.min.js"></script>
    <script src="js/jquery-ui/jquery.ui.widget.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.accordion.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.core.min.js" type="text/javascript"></script>
    <script src="js/jquery.lightbox_me.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.slide.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.mouse.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.sortable.min.js" type="text/javascript"></script>
    <script src="js/table/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="js/campaign.js" type="text/javascript"></script>
    <!-- END: load jquery -->
    <script type="text/javascript" src="js/table/jquery.dataTables.min.js"></script>
    <script src="js/setup.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            setupLeftMenu();

            $('.datatable').dataTable();
            setSidebarHeight();


        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container_12" dir="rtl">
        <div class="grid_12 header-repeat">
            <div id="branding">
                <div class="floatright">
                    <img src="img/logo.png" alt="Logo" /></div>
                <div class="floatleft">
                    <div class="floatleft marginleft10">
                        <ul class="inline-ul floatleft">
                            <li>שלום מנהל</li>
                            <li><a href="CompanyProfile.aspx">פרופיל</a></li>
                            <li><a href="Default.aspx">יציאה</a></li>
                        </ul>
                    </div>
                    <div class="floatleft">
                        <img src="img/img-profile.jpg" alt="Profile Pic" /></div>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div class="grid_12">
            <ul class="nav main">
                <li class="ic-dashboard"><a href="DashBoard.aspx"><span>הפקת דוחות</span></a> </li>
                <li class="ic-form-style"><a href="CatalogManager.aspx"><span>ניהול קטלוג מוצרים</span></a>
                </li>
                <li class="ic-typography"><a href="Campaign.aspx"><span>ניהול קמפיין פייסבוק</span></a></li>
            </ul>
        </div>
        <div class="clear">
        </div>
        <div id="general">
            <div class="grid_10">
                <div class="box round first grid">
                    <h2>
                        ניהול קמפיין</h2>
                    <div class="block">
                        <table class="data display datatable" id="CampaignTable">
                            <thead>
                                <tr>
                                    <th style="text-align: right">
                                        שם הקמפיין
                                    </th>
                                    <th style="text-align: right">
                                        תאריך הוספה
                                    </th>
                                    <th style="text-align: right">
                                        מק"ט
                                    </th>
                                    <th style="text-align: right">
                                        תיאור ההטבה
                                    </th>
                                    <th style="text-align: right">
                                        שיתופים
                                    </th>
                                    <th style="text-align: right">
                                        סטטוס
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="campaignsData" class="tableData" runat="server">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div id="addCampaign" class="displayNone">
            <div class="container_12">
                <div class="grid_10">
                    <div class="box round first fullpage">
                        <h2 dir="rtl" class="style1">
                            צור קמפיין חדש
                        </h2>
                        <div class="block ">
                            <table dir="rtl" style="text-align: right">
                                <tr>
                                    <th class="col1">
                                        <label>
                                            שם הקמפיין</label>
                                    </th>
                                    <td class="col2">
                                        <asp:TextBox class="text" ID="txtCampaignName" runat="server" Rows="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="CampaignNameValidator" ControlToValidate="txtCampaignName"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col1">
                                        <label>
                                            נוסח הקמפיין ברשת החברתית</label>
                                    </th>
                                    <td class="col2">
                                        <asp:TextBox class="text" ID="txtCampaignDescription" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="CampaignDescriptionValidator" ControlToValidate="txtCampaignDescription"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col1">
                                        <label>
                                            ההטבה ללקוח</label>
                                    </th>
                                    <td class="col2">
                                        <asp:TextBox class="text" ID="txtVoucher" runat="server" Rows="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="txtVoucherValidator" ControlToValidate="txtVoucher"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            תוקף ההטבה לאחר השיתוף</label>
                                    </th>
                                    <td>
                                        <asp:DropDownList class="text" ID="ddlExpirationTime" runat="server">
                                            <asp:ListItem Value="0">בחר</asp:ListItem>
                                            <asp:ListItem Value="1">שעה</asp:ListItem>
                                            <asp:ListItem Value="2">שעתיים</asp:ListItem>
                                            <asp:ListItem Value="4">ארבע שעות</asp:ListItem>
                                            <asp:ListItem Value="6">שש שעות</asp:ListItem>
                                            <asp:ListItem Value="8">שמונה שעות</asp:ListItem>
                                            <asp:ListItem Value="24">יממה</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="ddlExpirationTimeValidator" runat="server" ControlToValidate="ddlExpirationTime"
                                            InitialValue="0" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            צרף תמונה לקמפיין</label>
                                    </th>
                                    <td>
                                        <asp:FileUpload class="text" ID="uploadCampaignImgFU" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <strong>צרף קישור לקמפיין</strong>
                                    </th>
                                    <td>
                                        <asp:TextBox class="text" ID="txtCampaignLink" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="btnSaveCampaign" class="btn" runat="server" Text="שמור קמפיין" OnClick="btnSaveCampaign_Click" />
                            <input id="Button1" type="button" class="btn" value="ביטול" onclick="show('general')" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="editCampaign" class="displayNone">
            <div class="container_12">
                <div class="grid_10">
                    <div class="box round first fullpage">
                        <h2 dir="rtl" class="style1">
                           ערוך קמפיין
                        </h2>
                        <div class="block ">
                            <table dir="rtl" style="text-align: right">
                                                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtCampaignIdEdit" class="text" runat="server" style="display:none"></asp:TextBox>
                     
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col1">
                                        <label>
                                            שם הקמפיין</label>
                                    </th>
                                    <td class="col2">
                                        <asp:TextBox class="text" ID="txtCampaignNameEdit" runat="server" Rows="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="editNameValidator" ControlToValidate="txtCampaignNameEdit"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col1">
                                        <label>
                                            נוסח הקמפיין ברשת החברתית</label>
                                    </th>
                                    <td class="col2">
                                        <asp:TextBox class="text" ID="txtCampaignDescriptionEdit" runat="server" Rows="4"></asp:TextBox>
                                    </td>
                                    <td>
                                    <asp:RequiredFieldValidator ID="editDescriptionValidator" ControlToValidate="txtCampaignDescriptionEdit"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th class="col1">
                                        <label>
                                            ההטבה ללקוח</label>
                                    </th>
                                    <td class="col2">
                                        <asp:TextBox class="text" ID="txtVoucherEdit" runat="server" Rows="4"></asp:TextBox>
                                    </td>
                                    <td>
                                     <asp:RequiredFieldValidator ID="editVoucherValidator" ControlToValidate="txtVoucherEdit"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            תוקף ההטבה לאחר השיתוף</label>
                                    </th>
                                    <td>
                                        <asp:DropDownList class="text" ID="ddlExpirationEdit" runat="server">
                                            <asp:ListItem Value="1">שעה</asp:ListItem>
                                            <asp:ListItem Value="2">שעתיים</asp:ListItem>
                                            <asp:ListItem Value="4">ארבע שעות</asp:ListItem>
                                            <asp:ListItem Value="6">שש שעות</asp:ListItem>
                                            <asp:ListItem Value="8">שמונה שעות</asp:ListItem>
                                            <asp:ListItem Value="24">יממה</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            צרף תמונה לקמפיין</label>
                                    </th>
                                    <td>
                                        <asp:FileUpload class="text" ID="uploadCampaignImgEdit" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <strong>צרף קישור לקמפיין</strong>
                                    </th>
                                    <td>
                                        <asp:TextBox class="text" ID="txtCampaignLinkEdit" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                            <asp:Button ID="btnCampaignSaveChanges" class="btn" runat="server" 
                                Text="שמור שינויים" OnClick="btnCampaignSaveChanges_Click" 
                                CausesValidation="False" />
                            <input id="btnClosePopUp" type="button" class="btn" value="ביטול" onclick="show('general')" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="grid_2">
            <div class="box sidemenu">
                <div class="block" id="Div1">
                    <ul class="section menu">
                        <li><a class="menuitem" onclick="show('addCampaign')">צור קמפיין חדש</a>
                    </ul>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="productInfo" class="displayNone">
            <h3 id="infoCampaignName" class="sprited">
            </h3>
            <div id="productInfo_form">
                <img id="productInfoImage" runat="server" />
                <table id="productInfoTB" class="form">
                    <thead>
                        <tr>
                            <td>
                                <label>
                                    מק"ט:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblCampsignId" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="col1">
                                <label>
                                    נוסח הקמפיין בפייסבוק:</label>
                            </td>
                            <td class="col2">
                                <asp:Label ID="lblCampaignDescription" runat="server" Width="250px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    ההטבה ללקוח:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblVoucher" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    תוקף ההטבה לאחר השיתוף:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblExpirationTime" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    קישור מצורף:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblCampaignLink" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    סטטוס:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblIsActive" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    מספר השיתופים:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblShareCount" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                <div style="text-align: center" id="productInfoButtons">
                    <input id="btnEditProduct" type="button" class="btn" value="ערוך קמפיין" onclick="edit()" />
                    <input id="btnActivateCampaign" type="button" class="btn" value="הפוך לפעיל" />
                    <input id="btnCloseBox" type="button" class="btn" value="ביטול" onclick="CloseLightBox()" />
                    <input id="btnDeleteCampaign" type="button" class="btnRed" value="מחק קמפיין" onclick="DeleteCampaign()"/>
                </div>
            </div>
        </div>
        <div id="actions">
        </div>
        <div class="clear">
        </div>
    </form>
</body>
</html>
