using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;


public partial class BackOffice_Campaign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowCampaignTable();
    }

    /// <summary>
    /// saving the uploaded picture 
    /// </summary>
    private string InsertPictureToDirectory()
    {
        if (uploadCampaignImgFU.HasFile)
            try
            {
                if (Path.GetExtension(uploadCampaignImgFU.PostedFile.FileName).ToLower() == ".jpg"
            || Path.GetExtension(uploadCampaignImgFU.PostedFile.FileName).ToLower() == ".png"
            || Path.GetExtension(uploadCampaignImgFU.PostedFile.FileName).ToLower() == ".gif"
            || Path.GetExtension(uploadCampaignImgFU.PostedFile.FileName).ToLower() == ".jpeg")
                {
                    if (uploadCampaignImgFU.PostedFile.ContentLength < 102400)
                    {
                        string filename = Path.GetFileName(uploadCampaignImgFU.FileName);
                        string path = Server.MapPath("~/BackOffice/img/gallery/campaigns/");
                        uploadCampaignImgFU.SaveAs(path + filename);
                        return path + filename;
                    }

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        return "";
    }

    /// <summary>
    /// insert the campaign into the db
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveCampaign_Click(object sender, EventArgs e)
    {
        DataBaseManager db = new DataBaseManager();
        Campaign campaign = new Campaign();
        campaign.Name = txtCampaignName.Text;
        campaign.Description = txtCampaignDescription.Text;
        campaign.ShareCount = 0;//temporary
        campaign.Voucher = txtVoucher.Text;
        campaign.Expiration = Convert.ToInt32(ddlExpirationTime.SelectedValue);
        campaign.LinkUrl = txtCampaignLink.Text;
        campaign.ImageUrl = InsertPictureToDirectory();
        campaign.DateCreated = DateTime.Now;
        campaign.IsActive = true;
        db.insertNewCampaign(campaign, "aviv@gmail.com");
        Response.Redirect("Campaign.aspx");

    }

    /// <summary>
    /// select the table to show from the db and build the table in the page
    /// </summary>
    protected void ShowCampaignTable()
    {
        Campaign cam = new Campaign();
        List<Campaign> campaigns = cam.GetCampaignList("Aviv@gmail.com");

        foreach (Campaign c in campaigns)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell tc = new HtmlTableCell();
            HtmlTableCell tc1 = new HtmlTableCell();
            HtmlTableCell tc2 = new HtmlTableCell();
            HtmlTableCell tc3 = new HtmlTableCell();
            HtmlTableCell tc4 = new HtmlTableCell();
            HtmlTableCell tc5 = new HtmlTableCell();
            tc.InnerHtml = c.Name;
            tc1.InnerHtml = c.DateCreated.ToString();
            tc2.InnerHtml = c.Description;
            tc3.InnerHtml = c.Voucher;
            tc4.InnerHtml = c.ShareCount.ToString();
            tc5.InnerHtml = c.IsActive.ToString();
            tr.Cells.Add(tc);
            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            tr.Cells.Add(tc3);
            tr.Cells.Add(tc4);
            tr.Cells.Add(tc5);
            campaignsData.Controls.Add(tr);

        }
    }

}