using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;

public partial class BackOffice_CatalogManager : System.Web.UI.Page
{
    Dictionary<string, int> categories;
    Dictionary<string, int> properties;//number of properties in addProduct table
    Dictionary<int, string> propertiesOfCategory;
    Dictionary<string, int> allProp;
    string ProductpicPath;
    protected void Page_Load(object sender, EventArgs e)
    {
        GetAllProductInfoBasic();
        GetCategoriesNames();
        insertCategoryProperties();
        InsertPictureToDirectory();
        addPropToDrop();
        if (Session["numOfRows"] != null)
        {
            Product p =(Product) Session["product"];
            Page.ClientScript.RegisterStartupScript(this.GetType(), "callproductInsertedToDb", "productInsertedToDb('" + p.Id + "')", true);
            Session["numOfRows"] = null;
        }
    }


    /// <summary>
    /// insert the organization catagories to the addProduct form
    /// </summary>
    private void GetCategoriesNames()
    {
        Category c = new Category();
        categoriesNamesDDL.Items.Add("בחר");
        editCategoryCategoriesDDL.Items.Add("בחר");
        categories = c.getCategoriesNames("aviv@gmail.com");//צריך zלעשות משתנה של משתמש 
        foreach (KeyValuePair<string, int> pair in categories)
        {
            categoriesNamesDDL.Items.Add(pair.Key);
            editCategoryCategoriesDDL.Items.Add(pair.Key);
        }
    }

    /// <summary>
    /// insert the category properties to the addProduct form
    /// </summary>
    protected void insertCategoryProperties()
    {
        Category c = new Category();
        properties = new Dictionary<string, int>();
        if (categoriesNamesDDL.SelectedValue.ToString() != "בחר")
        {
            properties = c.getCategoryProperties(categories[categoriesNamesDDL.SelectedValue.ToString()]);
            HtmlTable tb = new HtmlTable();
            tb.Style.Add("text-align", "right");
            tb.Attributes.Add("runat", "Server");
            tb.ID = "propertiesTable";
            int counter = 1;
            foreach (KeyValuePair<string, int> pair in properties)
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell tc = new HtmlTableCell("th");
                Label l = new Label();
                l.Text = pair.Key;
                HtmlTableCell tc1 = new HtmlTableCell();
                TextBox tx = new TextBox();
                tx.ID = "txProperty" + counter;
                tx.CssClass = "text";
                tc.Controls.Add(l);
                tc1.Controls.Add(tx);
                tr.Controls.Add(tc);
                tr.Controls.Add(tc1);
                tb.Controls.Add(tr);
                counter++;
            }
            propertiesAddPH.Controls.Add(tb);
        }
        else
        {
            propertiesAddPH.Controls.Clear();
        }
    }


    /// <summary>
    /// exist to activate the post back of the categories names ddl 
    /// </summary>
    protected void categoriesNamesDDL_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }


    /// <summary>
    /// adding a new product
    /// </summary>
    protected void btnAddProduct_Click(object sender, EventArgs e)
    {
        try
        {
            int counter = 1;
            Category c = new Category();
            properties = c.getCategoryProperties(categories[categoriesNamesDDL.SelectedValue.ToString()]);
            propertiesOfCategory = new Dictionary<int, string>();
            foreach (KeyValuePair<string, int> pair in properties)//getting the propery id and its description
            {
                TextBox tb = Page.FindControl("txProperty" + counter) as TextBox;
                if (tb != null)
                {
                    string property = tb.Text;
                    ProductProperty productProp = new ProductProperty();
                    productProp.Description = property;
                    Property pr = new Property();
                    pr.Name = pair.Key;
                    propertiesOfCategory.Add(properties[pr.Name], productProp.Description);
                }
                counter++;
            }

            Product product = new Product();
            product.Id = Convert.ToInt32(productIdTB.Text);
            product.Name = productNameTB.Text;
            product.Description = productDescriptionTB.Text;
            DateTime currentTime = DateTime.Now;
            product.DateModified = currentTime;
            InsertPictureToDirectory();
            product.ImageUrl = ProductpicPath;
            product.Price = Convert.ToDouble(ProductPriceTB.Text);
            if (discountTB.Text == "") { }
            else
                product.Discount = discountTB.Text;
            int numOfRows = product.insertNewProduct(product, categories[categoriesNamesDDL.SelectedValue.ToString()], propertiesOfCategory, "aviv@gmail.com");
            if (numOfRows > 0)//מוציא הודעה האם המוצר הוכנס כמו שצריך
            {
                ProductInsertedName.InnerHtml = product.Name;
                Session.Add("numOfRows", numOfRows);
                Session.Add("product", product);
                Response.Redirect("CatalogManager.aspx");
            }
        }
        catch (Exception)
        {

        }
    }

    /// <summary>
    /// insert the organization products to the products table
    /// </summary>
    private void GetAllProductInfoBasic()
    {
        Product p = new Product();
        List<Product> lProduct = p.GetAllProductInfoBasic("aviv@gmail.com");
        foreach (Product product in lProduct)
        {
            HtmlTableRow tr = new HtmlTableRow();
            tr.Attributes.Add("class", "odd gradeA");
            HtmlTableCell tc = new HtmlTableCell();
            HtmlTableCell tc1 = new HtmlTableCell();
            HtmlTableCell tc2 = new HtmlTableCell();
            HtmlTableCell tc3 = new HtmlTableCell();
            HtmlTableCell tc4 = new HtmlTableCell();
            tc.InnerHtml = product.CategoryName;
            tc1.InnerHtml = product.Name;
            tc2.InnerHtml = product.Id.ToString();
            tc3.InnerHtml = product.Price.ToString();
            CheckBox cb = new CheckBox();

            if (product.Discount != null && product.Discount != "")
            {
                cb.Checked = true;
                tc4.Controls.Add(cb);
            }
            tr.Controls.Add(tc);
            tr.Controls.Add(tc1);
            tr.Controls.Add(tc2);
            tr.Controls.Add(tc3);
            tr.Controls.Add(tc4);
            productsData.Controls.Add(tr);
        }
    }


    /// <summary>
    /// saving am uploaded image 
    /// </summary>
    private void InsertPictureToDirectory()
    {
        if (uploadImgFU.HasFile)
            try
            {
                string filename = Path.GetFileName(uploadImgFU.FileName);
                string path = Server.MapPath("~/BackOffice/img/gallery/products/");
                if (path + filename != ProductpicPath)
                {
                    if (Path.GetExtension(uploadImgFU.PostedFile.FileName).ToLower() == ".jpg"
                || Path.GetExtension(uploadImgFU.PostedFile.FileName).ToLower() == ".png"
                || Path.GetExtension(uploadImgFU.PostedFile.FileName).ToLower() == ".gif"
                || Path.GetExtension(uploadImgFU.PostedFile.FileName).ToLower() == ".jpeg")
                    {

                        uploadImgFU.SaveAs(path + filename);
                        ProductpicPath = "BackOffice/img/gallery/products/" + filename;

                    }
                }
            }
            catch (Exception ex)
            {
            }
        else if (uploadImgFU.HasFile == false && ProductpicPath == null)
        {
            ProductpicPath = " ";
        }
    }

    /// <summary>
    /// insert all the oranization properties
    /// </summary>
    private void addPropToDrop()
    {
        NewCategoryProp.Items.Clear();
        Property p = new Property();
        allProp = p.getAllProp("aviv@gmail.com");
        foreach (KeyValuePair<string, int> pair in allProp)
        {
            NewCategoryProp.Items.Add(pair.Key);
        }
    }

    /// <summary>
    /// insert the updateCategory properties to the table
    /// </summary>
    protected void editCategoryCategoriesDDL_SelectedIndexChanged(object sender, EventArgs e)
    {
        EditCategoryPropTable.Controls.Clear();
        Category c = new Category();
        properties = new Dictionary<string, int>();
        if (editCategoryCategoriesDDL.SelectedValue.ToString() != "בחר")
        {
            properties = c.getCategoryProperties(categories[editCategoryCategoriesDDL.SelectedValue.ToString()]);
            foreach (KeyValuePair<string, int> pair in properties)
            {
                HtmlTableRow tr = new HtmlTableRow();
                HtmlTableCell tc = new HtmlTableCell();
                HtmlTableCell tc1 = new HtmlTableCell();
                Button btn = new Button();
                Button btn1 = new Button();
                btn.Text = "עריכה";
                btn.OnClientClick = "updateRowInEditCategory()";
                btn1.OnClientClick = "deleteRow()";
                btn1.Text = "הסרה";
                tc1.Controls.Add(btn);
                tc1.Controls.Add(btn1);
                tr.Attributes.Add("Class", "odd gradeX");
                tc.InnerHtml = pair.Key;
                tr.Controls.Add(tc);
                tr.Controls.Add(tc1);
                EditCategoryPropTable.Controls.Add(tr);
            }
        }
    }
}
