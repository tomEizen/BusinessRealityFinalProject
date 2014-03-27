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
    private string name;
    private string description;
    private double price;
    private string imageUrl;
    private string discount;
    private DateTime dateModified;
    private Category category;

    public int Id { get { return this.id; } set { this.id = value; } }
    public string Name { get { return this.name; } set { this.name = value; } }
    public string Description { get { return this.description; } set { this.description = value; } }
    public double Price { get { return this.price; } set { this.price = value; } }
    public string Discount { get { return this.discount; } set { this.discount = value; } }
    public string ImageUrl { get { return this.imageUrl; } set { this.imageUrl = value; } }
    public DateTime DateModified { get { return this.dateModified; } set { this.dateModified = value; } }
    public Category Category { get { return this.category; } set { this.category = value; } }
    public int insertNewProduct(Product product,int categoryName, Dictionary<int, string> pp, string emailManager)
    {
        DataBaseManager db = new DataBaseManager();
        return db.insertNewProduct(product,categoryName, pp, emailManager);
    }
    public List<Product> GetAllProductInfoBasic(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetAllProductInfoBasic(email);
    }

    public Dictionary<string, int> Top5ScanedProducts(string managerEmail)
    {
        DataBaseManager db = new DataBaseManager();
        return db.Top5ScanedProducts(managerEmail);
    }
    public GridView productPropertiesStatistics(int productCounter)
    {
        DataBaseManager db = new DataBaseManager();
        return db.productPropertiesStatistics(productCounter);
    }
}


