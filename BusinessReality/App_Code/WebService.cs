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
}
