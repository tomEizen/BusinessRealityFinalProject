using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Class representing the categories to which each product belongs
/// </summary>
public class Category
{
    private string name;
    private string description;
    private DateTime dateModified;

    public Category()
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

    public DateTime DateModified
    {
        get { return this.dateModified; }
        set { this.dateModified = value; }
    }
    public Dictionary<string, int> getCategoriesNames(string managerEmail)
    {

        DataBaseManager dbs = new DataBaseManager();
        return dbs.getCategoriesNames(managerEmail);

    }
    public Dictionary<string, int> getCategoryProperties(int categoryID)
    {

        DataBaseManager dbs = new DataBaseManager();
        return dbs.getCategoryProperties(categoryID);

    }
    public Dictionary<string, int> proc_5mostScanedCategories(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.proc_5mostScanedCategories(email);
    }
    public Dictionary<string, int> GetAllCategoryProducts(string id )
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetAllCategoryProducts(id);
    }
}
