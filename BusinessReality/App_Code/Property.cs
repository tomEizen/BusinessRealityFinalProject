using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{
    private string name;
    private string description;

    public Property()
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


    public string Description
    { 
        get { return this.description; } 
        set { this.description = value; } 
    }


    /// <summary>
    /// call the db class to gets all the properties of a specific organizations
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>dictionary of property name and id</returns>
    public Dictionary<string, int> getAllProp(string managerEmail)
    {

        DataBaseManager db = new DataBaseManager();
        return db.getAllProp(managerEmail);
    }

    /// <summary>
    /// call the db class to get the properties info of a specific product from the db
    /// </summary>
    /// <param name="managerEmail">manager's email for identification</param>
    /// <param name="productId">to select a specific product from the db</param>
    /// <returns>a list of the product info</returns>
    public List<Property> GetProductPropertiesInfo(string managerEmail, int productId)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetProductPropertiesInfo(managerEmail,productId);
    }

}


