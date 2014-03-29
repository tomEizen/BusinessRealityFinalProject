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
public class WebService : System.Web.Services.WebService {

    public WebService () {

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
    public string getProductsInfo(int productId)
    {
        List<Product> products = new List<Product>(); 
        Product p = new Product();
        products = p.GetAllProductInfoBasic("aviv@gmail.com");
        foreach (Product pp in products)
        {
            if (pp.Id == productId)
                p = pp;
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(p);
        return jsonString;
    }
    
}
