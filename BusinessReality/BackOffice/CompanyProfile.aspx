<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompanyProfile.aspx.cs" Inherits="BusinessReality.BackOffice.CompanyProfile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="css/reset.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/text.css" media="screen" />
    <link href="css/reports.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/grid.css" media="screen" />
    <link href="css/profile.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/layout.css" media="screen" />
    <link href="css/profile.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/nav.css" media="screen" />
    <!--[if IE 6]><link rel="stylesheet" type="text/css" href="css/ie6.css" media="screen" /><![endif]-->
    <!--[if IE 7]><link rel="stylesheet" type="text/css" href="css/ie.css" media="screen" /><![endif]-->
    <link href="css/table/demo_page.css" rel="stylesheet" type="text/css" />
    <!-- BEGIN: load jquery -->
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-ui/jquery.ui.core.min.js"></script>
    <script src="js/jquery-ui/jquery.ui.widget.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.accordion.min.js" type="text/javascript"></script>
    <script src="js/profile.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.core.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.slide.min.js" type="text/javascript"></script>
    <script src="js/jquery.lightbox_me.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.mouse.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.sortable.min.js" type="text/javascript"></script>
    <script src="js/reports.js" type="text/javascript"></script>
    <script src="js/table/jquery.dataTables.min.js" type="text/javascript"></script>
    <!-- END: load jquery -->
    <!-- BEGIN: load jqplot -->
    <link rel="stylesheet" type="text/css" href="css/jquery.jqplot.min.css" />
    <!--[if lt IE 9]><script language="javascript" type="text/javascript" src="js/jqPlot/excanvas.min.js"></script><![endif]-->
    <script language="javascript" type="text/javascript" src="js/jqPlot/jquery.jqplot.min.js"></script>
    <script type="text/javascript" src="js/jqPlot/plugins/jqplot.canvasTextRenderer.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/jqPlot/jquery.jqplot.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/jqPlot/plugins/jqplot.barRenderer.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/jqPlot/plugins/jqplot.pieRenderer.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/jqPlot/plugins/jqplot.categoryAxisRenderer.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/jqPlot/plugins/jqplot.highlighter.min.js"></script>
    <script language="javascript" type="text/javascript" src="js/jqPlot/plugins/jqplot.pointLabels.min.js"></script>
    <script type="text/javascript" src="js/jqPlot/plugins/jqplot.donutRenderer.min.js"></script>
    <script type="text/javascript" src="js/jqPlot/plugins/jqplot.bubbleRenderer.min.js"></script>
    <!-- END: load jqplot -->
    <script src="js/setup.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            drawBubbleChart('bubble-chart');
            drawCitiesChart('donuts-chart');
            drawPointsChart('points-chart');
            setupProductViews('chart1');
            setupLeftMenu();
            setSidebarHeight();


        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container_12">
            <div class="grid_12 header-repeat">
                <div id="branding">
                    <div class="floatright">
                        <img src="img/logo.png" alt="Logo" /></div>
                    <div class="floatleft">
                        <div class="floatleft marginleft10">
                            <ul class="inline-ul floatleft">
                                <li>שלום מנהל</li>
                                <li><a href="#">פרופיל</a></li>
                                <li><a href="#">יציאה</a></li>
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
                    <li class="ic-dashboard"><a href="DashBoard.aspx"><span>דוחות</span></a> </li>
                    <li class="ic-form-style"><a href="CatalogManager.aspx"><span>ניהול קטלוג</span></a>
                    </li>
                    <li class="ic-typography"><a href="Campaign.aspx"><span>ניהול קמפיין</span></a></li>
                </ul>
            </div>
            <div class="clear">
            </div>
            <div class="grid_6">
                <div class="box round first">
                    <h2 style="text-align: center">
                        פרטי המשתמש</h2>
                    <table>
                        <tr>
                            <th>
                                אימייל:
                            </th>
                            <td>
                                avivpaz43556@gmail.com
                            </td>
                        </tr>
                        <tr>
                            <th>
                                סיסמא:
                            </th>
                            <td>
                                *********
                            </td>
                        </tr>
                    </table>
                    <section class="updateSection">
                        <a href="#" id="try-2" class="myButton">עדכן פרטים</a></section>
                </div>
            </div>
            <div class="grid_6">
                <div class="box round first">
                    <h2 style="text-align: center">
                        פרטי החברה</h2>
                    <div class="block" id="companyProfile">
                        <!-- paragraphs -->
                        <div id="logoDiv">
                            <img src="img/gallery/products/IMG_3988.JPG" runat="server" alt="comapanyLogo" id="comapanyLogo" /></div>
                        <table>
                            <tr>
                                <th>
                                    שם האירגון
                                </th>
                                <td id="name" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    שוק/תעשייה:
                                </th>
                                <td id="industry" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    כתובת בית העסק:
                                </th>
                                <td id="address" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    טלפון:
                                </th>
                                <td id="phone" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    אודות בית העסק:
                                </th>
                                <td id="description" runat="server">
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    עמוד פייסבוק:
                                </th>
                                <td>
                                    <a id="fbPage" runat="server" href=""></a>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    אתר העסק:
                                </th>
                                <td>
                                    <a id="website" runat="server" href=""></a>
                                </td>
                            </tr>
                        </table>
                        <section class="updateSection">
                            <a href="#" id="try-1" class="myButton">עדכן פרטים</a></section>
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
            <div id="sign_up">
                <h3 id="see_id" class="sprited">
                    עדכון פרופיל עסק</h3>
                <div id="sign_up_form">
                    <label>
                        <strong>שם האירגון:</strong>
                        <input class="sprited" id="formName" runat="server" /></label>
                    <label>
                        <strong>שוק/תעשייה:</strong>
                        <br />
                        <asp:DropDownList ID="formIndustry" runat="server">
                            <asp:ListItem>בחר</asp:ListItem>
                        </asp:DropDownList>
                    </label>
                    <label>
                        <strong>כתובת בית העסק:</strong>
                        <input class="sprited" id="formAddress" runat="server" /></label>
                    <label>
                        <strong>טלפון:</strong>
                        <input class="sprited" id="formPhone" runat="server" /></label>
                    <label>
                        <strong>אודות בית העסק:</strong>
                        <textarea id="formDescription" runat="server" rows="5" style="resize: none; height: 50px"
                            name="Text1"></textarea></label>
                    <label>
                        <strong>עמוד פייסבוק:</strong>
                        <input class="sprited" id="formFbpage" runat="server" /></label>
                    <label>
                        <strong>אתר החברה:</strong>
                        <input class="sprited" id="formWebsite" runat="server" /></label>
                    <input type="text" class="file" name="file_info">
                    <div class="file_upload" runat="server">
                        <input type="file" id="file_upload" runat="server" name="file_upload">
                    </div>
                    <div id="actions">
                        <br />
                    </div>
                    <asp:Button ID="update" runat="server" Text="עדכן" onclick="update_Click" />
                </div>
            </div>
            <div id="updatePassword">
                <h3 id="H1" class="sprited">
                    עדכון סיסמא</h3>
                <div id="updatePassword_form">
                    <label>
                        <strong>אימייל:</strong>
                        <input class="sprited" /></label>
                    <label>
                        <strong>סיסמא חדשה:</strong>
                        <input class="sprited" /></label>
                    <label>
                        <strong>סיסמא חדשה:</strong>
                        <input class="sprited" /></label>
                    <div id="Div3">
                        <a href="#" id="A1" class="myButton">עדכן פרטים</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
