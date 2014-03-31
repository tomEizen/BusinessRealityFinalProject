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

    /// <summary>
    /// call the db class to get the existing catagories names
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>dictionary of category name and id</returns>
    public Dictionary<string, int> getCategoriesNames(string managerEmail)
    {
        DataBaseManager dbs = new DataBaseManager();
        return dbs.getCategoriesNames(managerEmail);
    }

    /// <summary>
    /// call the db class to gets all the proporties of an existing  catagory
    /// </summary>
    /// <param name="categoryID">id of the specific category</param>
    /// <returns>dictionary of property name and id</returns>
    public Dictionary<string, int> getCategoryProperties(int categoryID)
    {
        DataBaseManager dbs = new DataBaseManager();
        return dbs.getCategoryProperties(categoryID);
    }

    /// <summary>
    /// call the db class to gets the 5 most scaned categoreis
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>a dictionary of category name and amount</returns>
    public Dictionary<string, int> proc_5mostScanedCategories(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.proc_5mostScanedCategories(email);
    }

    /// <summary>
    /// call the db class to get all theexisting  products in a category
    /// </summary>
    /// <param name="id">the category id</param>
    /// <returns>dictionary of product name and uniq id</returns>
    public Dictionary<string, int> GetAllCategoryProducts(string id)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetAllCategoryProducts(id);
    }

    /// <summary>
    /// call the db class to insert a new category to the db
    /// </summary>
    /// <param name="c">object of the new category</param>
    /// <param name="lProperty">an array of the properties</param>
    /// <param name="email">manager email for identification</param>
    /// <returns>num of rows changed</returns>
    public int insertNewCategory(Category c, string[] lProperty, string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.insertNewCategory(c, lProperty, email);
    }
}
