using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class BackOffice_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text != null & txtEmail.Text != null)
        {
            string email = txtEmail.Text;
            string passHTML = txtPassword.Text;
            DataBaseManager d = new DataBaseManager();

            if (d.VerifyUserPass(email, passHTML))//(sql==txtPassword.Text)
            {
                Session["Email"] = email;
                Response.Redirect("DashBoard.aspx");

            }
            else
            {
                Response.Write("<script LANGUAGE='JavaScript' >alert('שגיעת התחברות. נסה שנית..')</script>");
            }

        }

    }
    protected void SubmitNewProfile_Click(object sender, EventArgs e)
    {
        if (MP == MP2)
        {
            Manager m = new Manager();
            m.Lname = MName.Text;
            m.Fname = MLName.Text;
            m.EmailAdress = MEMail.Text;
            m.PassWord = MP.Text;
            Organization org = new Organization();
            org.Name = OName.Text;
            org.Description = Odescription.InnerText;
            org.WebSiteUrl = Site.Text;
            org.FbWebsite = FaceBook.Text;
            org.Address = Addres.Text;
            org.PhoneNumber = Phone.Text;
            org.LogoSrc = InsertPictureToDirectory();
            int change = m.insertNewOrg(m, org);
            if (change > 0)
            {
                Session["Email"] = m.EmailAdress;
                Response.Redirect("DashBoard.aspx");
            }
        }
        else
        {

        }
    }

    /// <summary>
    /// saving am uploaded image 
    /// </summary>
    private string InsertPictureToDirectory()
    {
        string Finalpath = ""; ;
        if (File1.HasFile)
            try
            {
                string filename = Path.GetFileName(File1.FileName);
                string path = Server.MapPath("~/BackOffice/img/gallery/products/");
                {
                    if (Path.GetExtension(File1.PostedFile.FileName).ToLower() == ".jpg"
                || Path.GetExtension(File1.PostedFile.FileName).ToLower() == ".png"
                || Path.GetExtension(File1.PostedFile.FileName).ToLower() == ".gif"
                || Path.GetExtension(File1.PostedFile.FileName).ToLower() == ".jpeg")
                    {

                        File1.SaveAs(path + filename);
                        Finalpath = "http://proj.ruppin.ac.il/bgroup16/prod/BackOffice/img/gallery/profilesLogoes/" + filename;// need to add profile logos to dir

                    }
                }
            }
            catch (Exception ex)
            {
            }
        return Finalpath;
    }

}
