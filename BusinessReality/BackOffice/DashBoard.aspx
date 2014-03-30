<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="BusinessReality.BackOffice.DashBoard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard | Business Reality</title>
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="css/reset.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/text.css" media="screen" />
    <link href="css/reports.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/grid.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/layout.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="css/nav.css" media="screen" />
    <!--[if IE 6]><link rel="stylesheet" type="text/css" href="css/ie6.css" media="screen" /><![endif]-->
    <!--[if IE 7]><link rel="stylesheet" type="text/css" href="css/ie.css" media="screen" /><![endif]-->
    <link href="css/table/demo_page.css" rel="stylesheet" type="text/css" />
    <!-- BEGIN: load jquery -->
    <script src="js/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/jquery-ui/jquery.ui.core.min.js"></script>
    <script src="js/jquery-ui/jquery.ui.widget.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.ui.accordion.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.core.min.js" type="text/javascript"></script>
    <script src="js/jquery-ui/jquery.effects.slide.min.js" type="text/javascript"></script>
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
    <script src="js/jqPlot/plugins/jqplot.dateAxisRenderer.min.js" type="text/javascript"></script>
    <script src="js/jqPlot/plugins/jqplot.canvasAxisTickRenderer.min.js" type="text/javascript"></script>
    <script src="js/jqPlot/plugins/jqplot.categoryAxisRenderer.min.js" type="text/javascript"></script>
    <script src="js/jqPlot/plugins/jqplot.barRenderer.min.js" type="text/javascript"></script>
    <script src="js/jqPlot/plugins/jqplot.canvasTextRenderer.min.js" type="text/javascript"></script>
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
            $('#demographicsBtn').click(function () {
                drawBubbleChart('bubble-chart');
            });
            //            $('#campaignBtn').click(function () {
            //                drawPointsChart('points-chart');
            //            });
            setupLeftMenu();
            setSidebarHeight();
        });
    </script>
    <style type="text/css">
        .style1
        {
            width: 299px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <div class="container_12">
            <div id="manuUl">
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
                        <li class="ic-typography"><a href="Campaign.aspx"><span> ניהול קמפיין פייסבוק</span></a></li>
                    </ul>
                </div>
                <div class="clear">
                </div>
            </div>
            <div id="general">
                <div class="grid_10">
                    <div class="box round first" id="monthlyStatistics">
                        <h2>
                            נתונים כלליים חודשיים</h2>
                        <div class="block">
                            <div class="stat-col">
                                <span>סה"כ ביקורים</span>
                                <p id="totalVisit" class="purple">
                                    500</p>
                            </div>
                            <div class="stat-col">
                                <span>סה"כ סריקות החודש</span>
                                <p id="amountOfScans" runat="server" class="yellow">
                                </p>
                            </div>
                            <div class="stat-col">
                                <span>סה"כ שיתופי קמפיין</span>
                                <p id="campaignShareGeneral" runat="server" class="green">
                                </p>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <div class="grid_6">
                        <div class="box round ">
                            <h2>
                                חמשת המוצרים הנצפים</h2>
                            <div class="block">
                                <div id="mostScaned">
                                    <table class="tablecss">
                                        <thead>
                                            <tr>
                                                <th>
                                                    דירוג
                                                </th>
                                                <th>
                                                    שם המוצר
                                                </th>
                                                <th>
                                                    כמות סריקות
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="mostScanedTbody" runat="server">
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="grid_6">
                        <div class="box round">
                            <h2>
                                חמשת הקטגוריות הנצפות</h2>
                            <div class="block">
                                <div id="mostScanedCat">
                                    <table class="tablecss">
                                        <thead>
                                            <tr>
                                                <th>
                                                    דירוג
                                                </th>
                                                <th>
                                                    שם המוצר
                                                </th>
                                                <th>
                                                    כמות סריקות
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody id="mostScanedCategories" runat="server">
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="grid_6">
                        <div class="box round">
                            <h2>
                                מגדר</h2>
                            <div id="gender">
                            </div>
                        </div>
                    </div>
                    <div class="grid_6">
                        <div class="box round">
                            <h2>
                                גילאים</h2>
                            <div id="ages">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="act" class="displayNone">
                <div class="grid_10">
                    <div class="box round first">
                        <h2>
                            בחירת קטגוריה/מוצר לצפייה</h2>
                        <div class="block">
                            <div>
                                <span><b>בחירת קטגוריה</b>:</span>
                                <asp:DropDownList ID="categoriesNamesDDL" AutoPostBack="true" runat="server" OnSelectedIndexChanged="categoriesNamesDDL_SelectedIndexChanged">
                                </asp:DropDownList>
                                <br />
                                <br />
                                <br />
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <span><b>בחירת מוצר</b>:</span>
                                        <asp:DropDownList ID="productNamesDDL" runat="server" AutoPostBack="true" OnSelectedIndexChanged="productNamesDDL_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="categoriesNamesDDL" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div class="grid_6">
                                <div class="box round  ">
                                    <h2>
                                        חמשת המאפיינים הבולטים</h2>
                                    <div class="block">
                                        <div id="Div2">
                                            <table class="tablecss">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            שם המאפיין
                                                        </th>
                                                        <th>
                                                            כמות כניסות
                                                        </th>
                                                        <th>
                                                            אחוז מסה"כ הכניסות
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="productPropertiesStatistics" runat="server">
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="grid_6">
                                <div class="box round  ">
                                    <h2>
                                        היסטוריית סריקות המוצר</h2>
                                    <div class="block">
                                        <div id="Div5">
                                            <table class="tablecss">
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            חודש
                                                        </th>
                                                        <th>
                                                            כמות סריקות
                                                        </th>
                                                        <th>
                                                            אחוז מסה"כ הסריקות
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody id="prodyctHistoryStatistics" runat="server">
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="productNamesDDL" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div id="campaign" class="displayNone">
                <div class="grid_10">
                    <div class="box round" id="Div1">
                        <h2>
                            נתוני קמפיין נוכחי</h2>
                        <div class="block" style="text-align: right">
                            <div class="stat-col">
                                <span>ממוצע שעת שיתוף</span>
                                <p id="hourCampaign" class="purple" runat="server">
                                </p>
                            </div>
                            <div class="stat-col">
                                <span>יום עיקרי של שיתופים</span>
                                <p id="dayCampaign" class="yellow" runat="server">
                                </p>
                            </div>
                            <div class="stat-col">
                                <span>גיל ממוצע של משתפי הקמפיין</span>
                                <p id="ageCampaign" runat="server" class="green">
                                </p>
                            </div>
                            <div class="stat-col">
                                <span>כמות סריקות חודשיות</span>
                                <p class="blue">
                                    99.9%</p>
                            </div>
                            <div class="clear">
                            </div>
                        </div>
                    </div>
                    <%--<div class="grid_10">--%>
                    <div class="box round first">
                        <h2>
                            חמשת הקמפיינים המובילים בשיתוף</h2>
                        <div class="block">
                            <div id="campaignsShare">
                            </div>
                        </div>
                    </div>
                    <%-- </div>--%>
                    <div class="grid_6">
                        <div class="box round">
                            <h2>
                                גילאי משתפי הקמפיין</h2>
                            <div id="campaignsAges">
                            </div>
                        </div>
                    </div>
                    <div class="grid_6">
                        <div class="box round">
                            <h2>
                                מגדר משתפי הקמפיין</h2>
                            <div id="campaignsGender">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="grid_2">
                <div class="box sidemenu">
                    <div class="block" id="section-menu">
                        <ul class="section menu">
                            <li><a class="menuitem" onclick="show('general')">דו"ח סקירה כללי</a>
                                <%--     להשתמש במידה ורוצים אקורדיון--%>
                                <%--                           <ul class="submenu">
                                    <li><a>Submenu 1</a> </li>
                                    <li><a>Submenu 2</a> </li>
                                </ul>--%>
                            </li>
                            <li><a class="menuitem " id="actBtn" onclick="show('act')">דו"ח התנהגותי</a> </li>
                            <li><a class="menuitem " id="campaignBtn" onclick="show('campaign')">דו"ח קמפיין</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="clear">
        </div>
    </div>
    </form>
</body>
</html>
