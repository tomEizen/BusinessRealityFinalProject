using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.IO;


/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string HelloWorld()
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize("halwo worde");
        return jsonString;
    }

    /// <summary>
    /// send the product basic info from js to code behind
    /// </summary>
    /// <param name="productId">product id</param>
    /// <param name="email">manager email for identification</param>
    /// <returns>a json string of the product info</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getProductsInfo(int productId, string email)
    {
        List<Product> products = new List<Product>();
        Product p = new Product();
        products = p.GetAllProductInfoBasic(email);
        foreach (Product pp in products)
        {
            if (pp.Id == productId)
                p = pp;
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(p);
        return jsonString;
    }

    /// <summary>
    /// send the properties of a product from js to code behind
    /// </summary>
    /// <param name="productId">product id</param>
    /// <param name="email">manager email for identification</param>
    /// <returns>a json string of the3  properties</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string GetProductPropertiesInfo(int productId, string email)
    {
        List<Property> properties = new List<Property>();
        Property p = new Property();
        properties = p.GetProductPropertiesInfo(email, productId);
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(properties);
        return jsonString;
    }

    /// <summary>
    /// insert a new category according to manager input in the form
    /// </summary>
    /// <param name="categoryName">the name of the new category</param>
    /// <param name="Description">the description of the new category</param>
    /// <param name="properties">properties string of the new category</param>
    /// <param name="Email">email for identification</param>
    /// <returns>num of rows changed</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string insertNewCategory(string categoryName, string Description, string properties, string Email)
    {
        string[] propertiesList = properties.Split(',');
        Category c = new Category();
        c.Name = categoryName;
        c.Description = Description;
        int change = c.insertNewCategory(c, propertiesList, Email);
        if (change==1)
        {
            return "1";
        }
        return "0";
    }

    /// <summary>
    /// gets the product counter
    /// </summary>
    /// <param name="orgID">The id of the organization</param>
    /// <param name="Email">email for identification</param>
    /// <returns>product counter</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getProductCounter(string email, string productId)
    {
        Product p = new Product();
        string productCounter = p.GetProductCounter(email, productId);
        return productCounter;
    }

    /// <summary>
    /// gets the product counter
    /// </summary>
    /// <param name="orgID">The id of the organization</param>
    /// <param name="Email">email for identification</param>
    /// <returns>product counter</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string deleteProduct(string email, string productId)
    {
        Product p = new Product();
        string productCounter = p.deleteProduct(email, productId);
        return productCounter;
    }


    /// <summary>
    /// get the chosen campaign info from the data base
    /// </summary>
    /// <param name="campaignId">the chosen campaign id</param>
    /// <param name="email">for identification</param>
    /// <returns>an object of the chosen campaign</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getCampaignInfo(int campaignId, string email)
    {
        List<Campaign> campaigns = new List<Campaign>();
        Campaign c = new Campaign();
        campaigns = c.GetCampaignList(email);
        foreach (Campaign cc in campaigns)
        {
            if (cc.Id == campaignId)
                c = cc;
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(c);
        return jsonString;
    }

    /// <summary>
    /// delete the chosen campiagn from the db
    /// </summary>
    /// <param name="campaignId">the chosen campaign id</param>
    /// <returns>num of row change</returns>
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public int deleteCampaign(int campaignID)
    {
        Campaign c=new Campaign();
        int camp = c.DeleteCampaign(campaignID);
        return camp;
    }


}
