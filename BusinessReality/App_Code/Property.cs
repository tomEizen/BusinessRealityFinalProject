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


    public Dictionary<string, int> getAllProp(string managerEmail)
    {

        DataBaseManager db = new DataBaseManager();
        return db.getAllProp(managerEmail);



    }

    public Dictionary<String, string> GetProductPropertiesInfo(string managerEmail,int productId)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetProductPropertiesInfo(managerEmail,productId);
    }

}


