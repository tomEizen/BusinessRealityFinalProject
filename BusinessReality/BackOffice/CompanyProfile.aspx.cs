using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BusinessReality.BackOffice
{
    public partial class CompanyProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            insertCompanyProfile();
            insertCompanyProfileIntoForm();
        }

        //insert the comapany details
        protected void insertCompanyProfile()
        {
            Organization org = new Organization();
            org = org.getComapnyProfile("aviv@gmail.com");
            name.InnerHtml = org.Name;
            industry.InnerHtml = org.Industry;
            description.InnerHtml = org.Description;
            address.InnerHtml = org.Address;
            phone.InnerHtml = org.PhoneNumber;
            fbPage.InnerHtml = org.FbWebsite;
            fbPage.HRef = org.FbWebsite;
            website.InnerHtml = org.WebSiteUrl;
            website.HRef = org.WebSiteUrl;
        }

        //insert the company information to the edit from
        protected void insertCompanyProfileIntoForm()
        {
            Organization org = new Organization();
            org = org.getComapnyProfile("aviv@gmail.com");
            List<Industry> indList = new List<Industry>();
            indList.AddRange((new Industry()).GetAllIndustries());
            foreach (Industry ind in indList)
            {
                formIndustry.Items.Add(ind.Name);
                if (ind.Name == industry.InnerText)
                {
                    formIndustry.Items.FindByText(ind.Name).Selected = true;
                }
            }
            formName.Value = org.Name;
            formDescription.Value = org.Description;
            formAddress.Value = org.Address;
            formPhone.Value = org.PhoneNumber;
            formFbpage.Value = org.FbWebsite;
            formWebsite.Value = org.WebSiteUrl;
        }

        //update company profile
        protected void update_Click(object sender, EventArgs e)////לא מזהה לחיצה
        {
            Organization org = new Organization();
            org.Name = formName.Value;
            org.Description = formDescription.Value;
            org.Address = formAddress.Value;
            org.PhoneNumber = formPhone.Value;
            org.FbWebsite = formFbpage.Value;
            org.WebSiteUrl = formWebsite.Value;
            org.Industry = formIndustry.SelectedValue;
            if (file_upload.Value != null)
            {
                org.LogoSrc = file_upload.Value;
            }
          
        }
    }
}