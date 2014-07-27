<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatalogManager.aspx.cs" Inherits="BackOffice_CatalogManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Catalog| Business Reality</title>
    <link rel="stylesheet" type="text/css" href="css/reset.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/text.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/grid.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/layout.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/nav.css" media="screen" />
    <link href="css/catalog.css" rel="stylesheet" type="text/css" />
    <link href="css/table/demo_page.css" rel="stylesheet" type="text/css" />
    <!-- BEGIN: load jquery -->
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-ui/jquery.ui.core.min.js"></script>
    <script src="js/jquery-ui/jquery.ui.widget.min.js" type="text/javascript"></script>
    <script src="js/qrcode.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.accordion.min.js" type="text/javascript"></script>
    <script src="js/qrcode.min.js" type="text/javascript"></script>
    <script src="js/qrcode.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.core.min.js" type="text/javascript"></script>
    <script src="js/jquery.lightbox_me.js" type="text/javascript"></script>
    <script src="js/qrcode.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.slide.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.mouse.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.sortable.min.js" type="text/javascript"></script>
    <script src="js/table/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="js/catalog.js" type="text/javascript"></script>
    <!-- END: load jquery -->
    <script type="text/javascript" src="js/table/jquery.dataTables.min.js"></script>
    <script src="js/setup.js" type="text/javascript"></script>
    <script type="text/ecmascript">        var email = "<%=email%>";</script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container_12" dir="rtl">
        <div class="grid_12 header-repeat">
            <div id="branding">
                <div class="floatright">
                    <img id="logo" src="img/logo.png" alt="Logo" /></div>
                <div class="floatleft">
                    <div class="floatleft marginleft10">
                        <ul class="inline-ul floatleft">
                            <li id="hellowManager">שלום אביב</li>
                            <li><a href="CompanyProfile.aspx">פרופיל החברה</a></li>
                            <li><a href="Default.aspx">יציאה</a></li>
                        </ul>
                    </div>
                    <%--                    <div class="floatleft">
                        <img src="img/img-profile.jpg" alt="Profile Pic" /></div>--%>
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
                        ניהול קטלוג מוצרים</h2>
                    <div class="block">
                        <table class="data display datatable" id="productTable">
                            <thead>
                                <tr>
                                    <th style="text-align: right">
                                        קטגוריה
                                    </th>
                                    <th style="text-align: right">
                                        שם המוצר
                                    </th>
                                    <th style="text-align: right">
                                        מק"ט
                                    </th>
                                    <th style="text-align: right">
                                        מחיר
                                    </th>
                                    <th style="text-align: right">
                                        במבצע
                                    </th>
                                </tr>
                            </thead>
                            <tbody id="productsData" class="tableData" runat="server">
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <div id="addProduct" class="displayNone">
            <div class="container_12">
                <div class="grid_10">
                    <div class="box round first fullpage">
                        <h2>
                            הוסף מוצר חדש</h2>
                        <div class="block ">
                            <table id="addProductTable">
                                <tr>
                                    <th>
                                        <label>
                                            בחר קטגוריה</label>
                                    </th>
                                    <td>
                                        <asp:DropDownList class="text" ID="categoriesNamesDDL" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="categoriesNamesDDL_SelectedIndexChanged1">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="categoriesNamesDDLValidator" runat="server" ControlToValidate="categoriesNamesDDL"
                                            InitialValue="בחר" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            מק"ט מוצר</label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="productIdTB" class="text" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="productIdTBValidator" ControlToValidate="productIdTB"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="productIdTBValidator2" runat="server" ErrorMessage="יש להכניס ערך מספרי שלם בלבד"
                                            ControlToValidate="productIdTB" MinimumValue="0" MaximumValue="100000000" Type="Integer"
                                            ForeColor="Red"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            שם המוצר</label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="productNameTB" class="text" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="productNameTBValidator" ControlToValidate="productNameTB"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            תיאור המוצר</label>
                                    </th>
                                    <td>
                                        <asp:TextBox ID="productDescriptionTB" class="text" runat="server" Rows="4"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="productDescriptionTBValidator" ControlToValidate="productDescriptionTB"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            מחיר</label>
                                    </th>
                                    <td>
                                        <asp:TextBox class="text" ID="ProductPriceTB" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="ProductPriceTBValidator" ControlToValidate="ProductPriceTB"
                                            runat="server" ErrorMessage="שדה זה הינו שדה חובה" Display="Dynamic" ForeColor="Red"
                                            SetFocusOnError="True" EnableClientScript="true"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="ProductPriceTBValidator2" runat="server" ErrorMessage="יש להכניס ערך מספרי בלבד"
                                            ControlToValidate="ProductPriceTB" MinimumValue="0" MaximumValue="1000000" Type="Double"
                                            ForeColor="Red"></asp:RangeValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            מוצר במבצע</label>
                                    </th>
                                    <td>
                                        <asp:RadioButtonList class="text" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                            ID="RadioButtonList1" runat="server">
                                            <asp:ListItem Selected="True">לא</asp:ListItem>
                                            <asp:ListItem>כן</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <asp:TextBox ID="discountTB" class="text" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <th>
                                        <label>
                                            הוסף תמונה</label>
                                    </th>
                                    <td>
                                        <asp:FileUpload class="text" ID="uploadImgFU" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:PlaceHolder runat="server" ID="propertiesAddPH"></asp:PlaceHolder>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="categoriesNamesDDL" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:Button ID="btnAddProduct" runat="server" Text="הוסף מוצר" class="btn" OnClick="btnAddProduct_Click" />
                            <input id="Button1" type="button" class="btn" value="ביטול" onclick="show('general')" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="prodectInserted">
            <h3 id="H1" class="sprited">
                מוצר הוכנס בהצלחה</h3>
            <div id="prodectInserted_form">
                <div id="Div3">
                    <div id="qrcode" style="width: 100px; height: 100px; margin-top: 15px;">
                    </div>
                    <div id="ProductInsertedName" runat="server">
                    </div>
                    <br />
                    <div id="productInsertedQR">
                    </div>
                    <input type="button" value="הדפסת הברקוד" onclick="printDiv('productInsertedQR', 'ProductInsertedName')" />
                </div>
            </div>
        </div>
        <div id="addCategory" class="displayNone" runat="server">
            <div class="container_12">
                <div class="grid_10">
                    <div class="box round first fullpage">
                        <h2>
                            הוספת קטגוריה חדשה</h2>
                        <div>
                            <table id="addCategoryTable">
                                <thead>
                                    <tr>
                                        <th>
                                            <label>
                                                שם הקטגוריה</label>
                                        </th>
                                        <td>
                                            <input class="text" type="text" id="newCategoryName" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label>
                                                תיאור הקטגוריה</label>
                                        </th>
                                        <td>
                                            <input class="text" type="text" id="newCategoryDescruption" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>
                                            <label>
                                                בחר תכונה לקטגוריה</label>
                                        </th>
                                        <td>
                                            <asp:DropDownList class="text" ID="NewCategoryProp" runat="server">
                                            </asp:DropDownList>
                                            <input type="button" class="btn" id="addPropBtn" runat="server" value="הוסף תכונה"
                                                onclick="addPropBtn_Click" />
                                        </td>
                                        <th>
                                            <label>
                                                &nbsp;&nbsp;&nbsp;&nbsp; הוספת תכונה חדשה</label>
                                        </th>
                                        <td>
                                            <asp:TextBox ID="newPropTB" class="text" runat="server"></asp:TextBox>
                                        </td>
                                        <td>
                                            <input type="button" class="btn" id="addNewPropBtn" runat="server" value="הוסף תכונה" />
                                        </td>
                                    </tr>
                                </thead>
                            </table>
                            <b>תכונות בקטגוריה</b>
                            <table id="AddCategoryProperties" runat="server" class="form">
                            </table>
                            <input type="button" class="btn" id="addCategoryBTN" value="הוסף קטגוריה" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="editCategory" class="displayNone">
            <div class="container_12">
                <div class="grid_10">
                    <div class="box round first fullpage">
                        <h2>
                            ערוך קטגוריה</h2>
                        <table id="editCategoryTable">
                            <tr>
                                <td>
                                    <label>
                                        בחר קטגוריה לתצוגה</label>
                                </td>
                                <td>
                                    <asp:DropDownList class="text" ID="editCategoryCategoriesDDL" AutoPostBack="true"
                                        runat="server" OnSelectedIndexChanged="editCategoryCategoriesDDL_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <img alt="plusBtn" id="plusImg" title="הוסף קטגוריה חדשה" src="img/plus.png" onclick="show('addCategory')" />
                                </td>
                            </tr>
                        </table>
                        <div class="block">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <table class="form">
                                        <thead>
                                            <tr>
                                                <th dir="rtl">
                                                    שם תכונה
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody class="tableDataCategory" id="EditCategoryPropTable" runat="server">
                                        </tbody>
                                    </table>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="editCategoryCategoriesDDL" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="editProduct" class="displayNone">
            <div class="container_12">
                <div class="grid_10">
                    <div class="box round first fullpage">
                        <h2>
                            ערוך מוצר</h2>
                        <div class="block ">
                            <table class="form">
                                <tr>
                                    <td class="col1">
                                        <label>
                                            בחר קטגוריה</label>
                                    </td>
                                    <td class="col2">
                                        <asp:DropDownList class="text" ID="categoryNameEdit" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            מק"ט מוצר</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="productIdEdit" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            שם המוצר</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            תיאור המוצר</label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox10" class="large" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <asp:PlaceHolder ID="propertiesUpdate" runat="server"></asp:PlaceHolder>
                                <tr>
                                    <td>
                                        <label>
                                            מוצר במבצע</label>
                                    </td>
                                    <td>
                                        <asp:RadioButton Checked="true" ID="RadioButton5" name="rdlDiscount" runat="server" />
                                        לא
                                        <asp:RadioButton ID="RadioButton6" name="rdlDiscount" runat="server" />
                                        כן
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            הוסף תמונה</label>
                                    </td>
                                    <td>
                                        <asp:FileUpload ID="FileUpload2" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="Button2" runat="server" Text="שמור שינויים" Width="100px" />
                                        <input id="Button3" type="button" value="ביטול" onclick="show('general')" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="grid_2">
            <div class="box sidemenu">
                <div class="block" id="Div1">
                    <ul class="section menu">
                        <li><a class="menuitem" onclick="show('addProduct')">הוסף מוצר חדש</a>
                        <li><a class="menuitem" onclick="show('editCategory')">ערוך קטגוריות</a> </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="clear">
        </div>
        <div id="productInfo">
            <h3 id="infoName" class="sprited">
            </h3>
            <div id="productInfo_form">
                <img id="productInfoImage" runat="server" />
                <table id="productInfoTB" class="form">
                    <thead>
                        <tr>
                            <td class="col1">
                                <label>
                                    קטגוריה:</label>
                            </td>
                            <td class="col2">
                                <asp:Label ID="lblCategory" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    מק"ט מוצר:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblproductID" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    תיאור המוצר:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblProductDescription" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    מחיר המוצר:</label>
                            </td>
                            <td>
                                <asp:Label ID="lblProductPrice" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <label>
                                    מוצר במבצע:</label>
                            </td>
                            <td>
                                <asp:Label ID="productInfoDiscount" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                             
                            </td>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
                <div style="text-align: center" id="productInfoButtons">
                    <input id="btnEditProduct" type="button" class="btn" value="ערוך מוצר" onclick="edit()" />
                    <input type="button" id="btnPrintCode" class="btn" value="הדפס ברקוד" onclick="printDiv('qrcode','infoName')" />
                    <input id="btnCloseBox" type="button" class="btn" value="ביטול" onclick="CloseLightBox()" />
                    <input id="btnDelete" type="button" class="btnRed" value="מחיקת המוצר" onclick="DeleteProduct()" />
                </div>
                   <div id="qrCodeInfo">
                                </div>
            </div>
        </div>
        <div id="actions">
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
</body>
</html>
