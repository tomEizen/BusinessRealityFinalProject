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
        change();
        InsertPictureToDirectory();
        addPropToDrop();
        if (Session["numOfRows"] != null)
        {
            string s = "www.one.co.il";
            Page.ClientScript.RegisterStartupScript(this.GetType(), "callproductInsertedToDb", "productInsertedToDb('" + s + "',3)", true);
            Session["numOfRows"] = null;
        }
        enterProductInfo();
    }

    private void enterProductInfo()
    {

    }
    //get the catagories to the addProduct form
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

    protected void change()
    {
        Category c = new Category();
        properties = new Dictionary<string, int>();
        if (categoriesNamesDDL.SelectedValue.ToString() != "בחר")
        {
            properties = c.getCategoryProperties(categories[categoriesNamesDDL.SelectedValue.ToString()]);
            HtmlTable tb = new HtmlTable();
            tb.Style.Add("text-align", "right");
            tb.Attributes.Add("class", "form");
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
    //add the currect properties 
    protected void categoriesNamesDDL_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }

    //on click on the addProduct BTN
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
                TextBox tb = Page.FindControl("txProperty" + counter) as TextBox;//לא מזהה את הערך בפנים
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
            product.Price = Convert.ToDouble(ProductPriceTB.Text);
            if (discountTB.Text == "") { }
            else
                product.Discount = discountTB.Text;
            product.ImageUrl = ProductpicPath;//מכניס ריק לא מזהה את התמונה אחרי הקריאה לצד שרת הראשונה
            int numOfRows = product.insertNewProduct(product, categories[categoriesNamesDDL.SelectedValue.ToString()], propertiesOfCategory, "aviv@gmail.com");
            if (numOfRows > 0)//מוציא הודעה האם המוצר הוכנס כמו שצריך
            {
                Session.Add("numOfRows", numOfRows);
                Session.Add("product", product);
                Response.Redirect("");
            }
        }
        catch (Exception)
        {

        }
    }
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
            tc.InnerHtml = product.Category.Name;
            tc1.InnerHtml = product.Name;
            tc2.InnerHtml = product.Id.ToString();
            tc3.InnerHtml = product.Price.ToString();
            CheckBox cb = new CheckBox();

            if (product.Discount != null && product.Discount != " ")
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


    // insert the uploaded picture to the server dic'
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
                        ProductpicPath = path + filename;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        else if (uploadImgFU.HasFile == false && ProductpicPath == null)
        {
            ProductpicPath = "";
        }
    }


    private void addPropToDrop()
    {

        Property p = new Property();
        allProp = p.getAllProp("aviv@gmail.com");
        foreach (KeyValuePair<string, int> pair in allProp)
        {
            NewCampaignProp.Items.Add(pair.Key);
        }
    }
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
                tr.Attributes.Add("Class", "odd gradeX");
                tc.InnerHtml = pair.Key;
                tr.Controls.Add(tc);
                EditCategoryPropTable.Controls.Add(tr);
            }
        }
   
    }
    protected void addCategoryBTN_Click(object sender, EventArgs e)
    {

    }
}
