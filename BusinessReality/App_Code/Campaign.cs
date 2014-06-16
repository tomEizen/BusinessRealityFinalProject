using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Campaign
/// </summary>
public class Campaign
{
    private string name;
    private int id;
    private string description;
    private string imageUrl;
    private string linkUrl;
    private DateTime dateCreated;
    private int shareCount;
    private string voucher;
    private int expiration;
    private bool isActive;

	public Campaign()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Id
    {
        get { return this.id; }
        set { this.id = value; }
    }

    

    public string Description
    {
        get { return this.description; }
        set { this.description = value; }
    }

    public string ImageUrl
    {
        get { return this.imageUrl; }
        set { this.imageUrl = value; }
    }

    public string LinkUrl
    {
        get { return this.linkUrl; }
        set { this.linkUrl = value; }
    }

    public DateTime DateCreated
    {
        get { return this.dateCreated; }
        set { this.dateCreated = value; }
    }

    public int Expiration
    {
        get { return this.expiration; }
        set { this.expiration = value; }
    }

    public int ShareCount
    {
        get { return this.shareCount; }
        set { this.shareCount = value; }
    }

    public string Voucher
    {
        get { return this.voucher; }
        set { this.voucher = value; }
    }

    public bool IsActive
    {
        get { return this.isActive; }
        set { this.isActive = value; }
    }

    /// <summary>
    /// calls the db class to get a list of fb campaigns and their info from the db to show at the campaign table
    /// </summary>
    /// <param name="email">manager's email for identification</param>
    /// <returns>a list of campaigns objects</returns>
    public List<Campaign> GetCampaignList(string email)
    {
        DataBaseManager db = new DataBaseManager();
        List<Campaign> campaigns = db.GetCampaignsList(email);
        return campaigns;
    }

    /// <summary>
    /// calls the db class to get the campaigns share count
    /// </summary>
    /// <param name="managerEmail">manager's email for identification</param>
    /// <returns>a list of campaigns and their share count</returns>
    public Dictionary<string, int> getCampaignsShare(string managerEmail)
    {
        DataBaseManager db = new DataBaseManager();
        Dictionary<string,int> campaigns = db.GetCampaignsShare(managerEmail);
        return campaigns;
    }

    /// <summary>
    /// calls the db class to get info about the current active campaign
    /// </summary>
    /// <param name="managerEmail">manager's email for identification</param>
    /// <returns>a grid of data about the active campaign</returns>
    public GridView getActiveCampaignStatistics(string managerEmail)
    {
        DataBaseManager db = new DataBaseManager();
        return db.getActiveCampaignStatistics(managerEmail);
    }

    public int insertNewCampaign(Campaign campaign, string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.insertNewCampaign(campaign, email);
    }

    public int DeleteCampaign(int campaignId)
    {
        DataBaseManager db = new DataBaseManager();
        return 0;
    }
}