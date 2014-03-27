using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data;

namespace BusinessReality.BackOffice
{
    public partial class DashBoard : System.Web.UI.Page
    {
        StringBuilder script;
        Dictionary<string, int> categories;
        Dictionary<string, int> categoryProducts;
        protected void Page_Load(object sender, EventArgs e)
        {
            categoryProducts = new Dictionary<string, int>();
            script = new StringBuilder();
            updateGeneralDetails();
            UpdateAgesStatistics();
            Top5ScanedProducts();
            GetCategoriesNames();
            GeneralDetailsPlots();
            getCamapaignsShareStatistics();
            getActiveCampaignStatistics();
            UpdateCampaignShareAgesStatistics();
            UpdateCampaignShareGender();
            proc_5mostScanedCategories();
            scriptActive();
        }
        private void scriptActive()
        {
            script.Append("scanProduct();");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "age", script.ToString(), true);
        }
        private void updateGeneralDetails()
        {
            User us = new User();
            Dictionary<string, int> gender = us.getGenderStatistics("aviv@gmail.com");
            script.Append("drawGenderChart('gender','" + gender["male"] + "','" + gender["female"] + "');");

        }

        private void UpdateAgesStatistics()
        {
            User us = new User();
            Dictionary<string, int> ages = us.getAgesStatistics("aviv@gmail.com");

            int range1 = 0;
            int range2 = 0;
            int range3 = 0;
            int range4 = 0;
            int range5 = 0;
            int range6 = 0;
            int range7 = 0;
            int range8 = 0;

            foreach (var item in ages)
            {

                int age = item.Value;

                if (age > 0 && age < 13)
                    ++range1;
                else if (age >= 13 && age < 18)
                    ++range2;
                else if (age >= 18 && age < 25)
                    ++range3;
                else if (age >= 25 && age < 35)
                    ++range4;
                else if (age >= 35 && age < 45)
                    ++range5;
                else if (age >= 45 && age < 55)
                    ++range6;
                else if (age >= 55 && age < 65)
                    ++range7;
                else
                    ++range8;
            }
            script.Append("drawAgesChart('ages','" + range1 + "','" + range2 + "','" + range3 + "','" + range4 + "','" + range5 + "','" + range6 + "','" + range7 + "','" + range8 + "' );");

        }
        private void Top5ScanedProducts()
        {
            Product p = new Product();
            Dictionary<string, int> mostScaned = p.Top5ScanedProducts("aviv@gmail.com");
            int counter = 1;
            foreach (KeyValuePair<string, int> product in mostScaned)
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell tc = new HtmlTableCell();
                HtmlTableCell tc1 = new HtmlTableCell();
                HtmlTableCell tc2 = new HtmlTableCell();
                tc2.InnerHtml = counter.ToString();
                tc.InnerHtml = product.Key;
                tc1.InnerHtml = product.Value.ToString();
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc);
                tr.Controls.Add(tc1);
                mostScanedTbody.Controls.Add(tr);
                counter++;
            }
        }
        private void proc_5mostScanedCategories()
        {
            Category c = new Category();
            Dictionary<string, int> mostScaned = c.proc_5mostScanedCategories("aviv@gmail.com");
            int counter = 1;
            foreach (KeyValuePair<string, int> product in mostScaned)
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell tc = new HtmlTableCell();
                HtmlTableCell tc1 = new HtmlTableCell();
                HtmlTableCell tc2 = new HtmlTableCell();
                tc2.InnerHtml = counter.ToString();
                tc.InnerHtml = product.Key;
                tc1.InnerHtml = product.Value.ToString();
                tr.Controls.Add(tc2);
                tr.Controls.Add(tc);
                tr.Controls.Add(tc1);
                mostScanedCategories.Controls.Add(tr);
                counter++;
            }
        }
        private void getActiveCampaignStatistics()
        {
            Campaign cp = new Campaign();
            GridView dt = cp.getActiveCampaignStatistics("aviv@gmail.com");
            hourCampaign.InnerHtml = dt.Rows[0].Cells[0].Text;
            ageCampaign.InnerHtml = dt.Rows[0].Cells[2].Text;
            string day = "";
            switch (dt.Rows[0].Cells[1].Text)
            {
                case "1":
                    day = "ראשון";
                    break;
                case "2":
                    day = "שני";
                    break;
                case "3":
                    day = "שלישי";
                    break;
                case "4":
                    day = "רביעי";
                    break;
                case "5":
                    day = "חמישי";
                    break;
                case "6":
                    day = "שישי";
                    break;
                case "7":
                    day = "שבת";
                    break;
                default:
                    break;
            }
            dayCampaign.InnerHtml = day;
        }
        private void GeneralDetailsPlots()
        {
            Scan s = new Scan();
            GridView dv = s.GeneralDetailsPlots("aviv@gmail.com");
            campaignShareGeneral.InnerHtml = dv.Rows[0].Cells[0].Text;
            amountOfScans.InnerHtml = dv.Rows[0].Cells[1].Text;
        }
        private void GetCategoriesNames()
        {
            Category c = new Category();
            categoriesNamesDDL.Items.Add("בחר");
            categories = c.getCategoriesNames("aviv@gmail.com");//צריך zלעשות משתנה של משתמש 
            foreach (KeyValuePair<string, int> pair in categories)
                categoriesNamesDDL.Items.Add(pair.Key);
        }
        protected void categoriesNamesDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            productNamesDDL.Items.Clear();
            Category c = new Category();
            productNamesDDL.Items.Add("בחר");
            try
            {
                categoryProducts = c.GetAllCategoryProducts(categories[categoriesNamesDDL.Text].ToString());
                foreach (KeyValuePair<string, int> pair in categoryProducts)
                    productNamesDDL.Items.Add(pair.Key);
            }
            catch (Exception)
            {
                productNamesDDL.Items.Clear();
                productNamesDDL.Items.Add("בחר");
            }
        }
        protected void productNamesDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product p = new Product();
            GridView gvProperties = new GridView();
            Category c = new Category();
            categoryProducts = c.GetAllCategoryProducts(categories[categoriesNamesDDL.Text].ToString());
            gvProperties = p.productPropertiesStatistics(categoryProducts[productNamesDDL.Text]);
            foreach (GridViewRow row in gvProperties.Rows)
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell tc = new HtmlTableCell();
                HtmlTableCell tc1 = new HtmlTableCell();
                HtmlTableCell tc2 = new HtmlTableCell();
                tc.InnerHtml = row.Cells[0].Text;
                tc1.InnerHtml = row.Cells[1].Text;
                tc2.InnerHtml = row.Cells[2].Text;
                tr.Controls.Add(tc);
                tr.Controls.Add(tc1);
                tr.Controls.Add(tc2);
                productPropertiesStatistics.Controls.Add(tr);
            }
        }


        private void getCamapaignsShareStatistics()
        {
            Campaign cam = new Campaign();
            Dictionary<string, int> camList = cam.getCampaignsShare("aviv@gmail.com");
            string paramList = "";

            for (int i = 0; i < camList.Count; i++)
            {
                if (i != camList.Count)
                    paramList += camList.ElementAt(i).Key.Trim() + "','" + Convert.ToInt32(camList.ElementAt(i).Value) + "','";
                else
                    paramList += camList.ElementAt(i).Key.Trim() + "','" + Convert.ToInt32(camList.ElementAt(i).Value);

            }

            script.Append("drawCamgaignShareChart('campaignsShare','" + paramList + "');");
        }



        private void UpdateCampaignShareAgesStatistics()
        {
            User us = new User();
            Dictionary<string, int> ages = us.GetCampignsShareAges("aviv@gmail.com");

            int range1 = 0;
            int range2 = 0;
            int range3 = 0;
            int range4 = 0;
            int range5 = 0;
            int range6 = 0;
            int range7 = 0;
            int range8 = 0;

            foreach (var item in ages)
            {

                int age = item.Value;

                if (age > 0 && age < 13)
                    ++range1;
                else if (age >= 13 && age < 18)
                    ++range2;
                else if (age >= 18 && age < 25)
                    ++range3;
                else if (age >= 25 && age < 35)
                    ++range4;
                else if (age >= 35 && age < 45)
                    ++range5;
                else if (age >= 45 && age < 55)
                    ++range6;
                else if (age >= 55 && age < 65)
                    ++range7;
                else
                    ++range8;
            }
            script.Append("drawCampaignShareAgesChart('campaignsAges','" + range1 + "','" + range2 + "','" + range3 + "','" + range4 + "','" + range5 + "','" + range6 + "','" + range7 + "','" + range8 + "' );");


        }


        private void UpdateCampaignShareGender()
        {
            User us = new User();
            Dictionary<string, int> gender = us.GetCampignsShareGender("aviv@gmail.com");
            script.Append("drawCampaignShareGenderChart('campaignsGender','" + gender["male"] + "','" + gender["female"] + "');");

        }

    }
}