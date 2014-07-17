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
    public string email;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Email"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            email = Session["Email"].ToString();
            ShowCampaignTable();
        }
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
                        return "http://proj.ruppin.ac.il/bgroup16/prod/BackOffice/img/gallery/campaigns/" + filename;
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
    /// select the table to show from the db and build the table in the page
    /// </summary>
    protected void ShowCampaignTable()
    {
        Campaign cam = new Campaign();
        List<Campaign> campaigns = cam.GetCampaignList(email);

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
            tc2.InnerHtml = c.Id.ToString();
            tc3.InnerHtml = c.Voucher;
            tc4.InnerHtml = c.ShareCount.ToString();
            if (c.IsActive == true)
                tc5.InnerHtml = "פעיל";
            else
                tc5.InnerHtml = "לא פעיל";
            tr.Cells.Add(tc);
            tr.Cells.Add(tc1);
            tr.Cells.Add(tc2);
            tr.Cells.Add(tc3);
            tr.Cells.Add(tc4);
            tr.Cells.Add(tc5);
            campaignsData.Controls.Add(tr);

        }
    }


    /// <summary>
    /// call the db to update a selected campaign
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCampaignSaveChanges_Click(object sender, EventArgs e)
    {
        int id;
        Campaign campaign = new Campaign();
        id= Convert.ToInt32(txtCampaignIdEdit.Text);
        campaign.Name = txtCampaignNameEdit.Text;
        campaign.Description = txtCampaignDescriptionEdit.Text;
        campaign.Voucher = txtVoucherEdit.Text;
        campaign.Expiration = Convert.ToInt32(ddlExpirationEdit.SelectedValue);
        campaign.LinkUrl = txtCampaignLinkEdit.Text;
        campaign.ImageUrl = InsertPictureToDirectory();
        campaign.EditCampaign(campaign, id);
        Response.Redirect("Campaign.aspx");

    }

    /// <summary>
    /// insert new campagin into the db
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveCampaign_Click(object sender, EventArgs e)
    {
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
        campaign.insertNewCampaign(campaign, email);
        Response.Redirect("Campaign.aspx");
    }
}