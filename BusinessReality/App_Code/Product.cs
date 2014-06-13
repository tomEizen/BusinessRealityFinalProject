using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Class representing an SQL product table entry
/// </summary>
public class Product
{
    private int id;
    string categoryName;
    private string name;
    private string description;
    private double price;
    private string imageUrl;
    private string discount;
    private DateTime dateModified;
    private Category category;

    public string CategoryName { get { return this.categoryName; } set { this.categoryName = value; } }
    public int Id { get { return this.id; } set { this.id = value; } }
    public string Name { get { return this.name; } set { this.name = value; } }
    public string Description { get { return this.description; } set { this.description = value; } }
    public double Price { get { return this.price; } set { this.price = value; } }
    public string Discount { get { return this.discount; } set { this.discount = value; } }
    public string ImageUrl { get { return this.imageUrl; } set { this.imageUrl = value; } }
    public DateTime DateModified { get { return this.dateModified; } set { this.dateModified = value; } }
    public Category Category { get { return this.category; } set { this.category = value; } }


    /// <summary>
    /// call the db class to insert a new product into the db && the properties description to the db
    /// </summary>
    /// <param name="product">new product's object</param>
    /// <param name="categoryID">the category to which the product belong</param>
    /// <param name="pp">the properties of the product</param>
    /// <param name="emailManager">manager email for identification</param>
    /// <returns>num of rows changed</returns>
    public int insertNewProduct(Product product, int categoryName, Dictionary<int, string> pp, string emailManager)
    {
        DataBaseManager db = new DataBaseManager();
        return db.insertNewProduct(product, categoryName, pp, emailManager);
    }

    /// <summary>
    /// call the db class to get the basic info (not incude properties) of all the existing products of an organization
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>a list of product objects</returns>
    public List<Product> GetAllProductInfoBasic(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetAllProductInfoBasic(email);
    }

    /// <summary>
    /// gets the 5 most scaned products
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>a dictionary of product name and amount</returns>
    public Dictionary<string, int> Top5ScanedProducts(string managerEmail)
    {
        DataBaseManager db = new DataBaseManager();
        return db.Top5ScanedProducts(managerEmail);
    }

    /// <summary>
    /// call the db class to get product most viewed properties
    /// </summary>
    /// <param name="productCounter">the uniq id of the organization's product</param>
    /// <returns>grid view of the details</returns>
    public GridView productPropertiesStatistics(int productCounter)
    {
        DataBaseManager db = new DataBaseManager();
        return db.productPropertiesStatistics(productCounter);
    }

    /// <summary>
    /// call the db class to get the history of products scan by users
    /// </summary>
    /// <param name="productCounter">the uniq id of the organization's product</param>
    /// <returns>a gridview of the details</returns>
    public GridView GetHistoryScan(int productCounter)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetHistoryScan(productCounter);
    }
    public string GetProductCounter(string email, string productID)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetProductCounterWithEmail(email, productID);
    }

    public string deleteProduct(string email, string productId)
    {
        DataBaseManager db = new DataBaseManager();
        return db.deleteProduct(email, productId);
    }
}


