using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for DataBaseManager
/// </summary>
public class DataBaseManager
{

    /////////////////////////connection/////////////////////

    /// <summary>
    /// the connection string to the database
    /// </summary>
    private string connectionString;

    /// <summary>
    /// Creates a new data base manager
    /// </summary>
    public DataBaseManager()
    {
        this.connectionString = WebConfigurationManager.ConnectionStrings["databaseConnection"].ConnectionString;
    }
    /// <summary>
    /// Get an open connection to the data base
    /// </summary>
    /// <returns>n SqlConnection instance of an open connection</returns>
    private SqlConnection GetOpenConnection()
    {
        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();
        return connection;
    }

    private void closeConnection()
    {
        SqlConnection con = GetOpenConnection();
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
    
    }
    ///////////////////////////////////  End of connection ///////////////////////////



    /////////////////////////////////////// plots /////////////////////////////////////

    /// <summary>
    /// get the general users gender statistic
    /// </summary>
    /// <param name="managerEmail">manager's email for identification</param>
    /// <returns>dictionary of male and female count</returns>
    public Dictionary<string, int> getGenderStatistics(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@email", managerEmail));
            SqlDataReader dr = ActivateStoredProc("getGenderStatistics", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add("male", Convert.ToInt32(dr["male"]));
                names.Add("female", Convert.ToInt32(dr["female"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        finally
        {
            closeConnection();
        }
        return names;
    }

    /// <summary>
    /// get a gender count from the db of the users who shared a campiagn
    /// </summary>
    /// <param name="managerEmail">the manager's email for identification</param>
    /// <returns>dictionary of male and female count</returns>
    public Dictionary<string, int> GetCampaignShareGender(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@emailAddress", managerEmail));
            SqlDataReader dr = ActivateStoredProc("proc_GetCampaignShareGender", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add("male", Convert.ToInt32(dr["male"]));
                names.Add("female", Convert.ToInt32(dr["female"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }


    /// <summary>
    /// gets all the users ages list
    /// </summary>
    /// <param name="managerEmail">the manager's email for identification</param>
    /// <returns>dictionary of ages</returns>
    public Dictionary<string, int> getAgeStatistics(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> ages = new Dictionary<string, int>();
        try
        {
            int counter = 0;
            paraList.Add(new SqlParameter("@email", managerEmail));
            SqlDataReader dr = ActivateStoredProc("getAgeStatistics", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                counter++;
                ages.Add("Age" + counter + "'", Convert.ToInt32(dr["Age"]));
            }

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return ages;
    }

    /// <summary>
    /// get a list of ages from the db of the users who shared a campiagn
    /// </summary>
    /// <param name="managerEmail">the email of the organization's manager</param>
    /// <returns>a dictionary of ages</returns>
    public Dictionary<string, int> GetCampignsShareAges(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> ages = new Dictionary<string, int>();
        try
        {
            int counter = 0;
            paraList.Add(new SqlParameter("@emailAddress", managerEmail));
            SqlDataReader dr = ActivateStoredProc("proc_GetCampignsShareAges", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                counter++;
                ages.Add("Age" + counter + "'", Convert.ToInt32(dr["Age"]));
            }

        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return ages;
    }


    /// <summary>
    /// gets the 5 most scaned categoreis
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>a dictionary of category name and amount</returns>
    public Dictionary<string, int> proc_5mostScanedCategories(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@email", managerEmail));
            SqlDataReader dr = ActivateStoredProc("proc_5mostScanedCategories", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add(dr["Name"].ToString(), Convert.ToInt32(dr["amount"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }

    /// <summary>
    /// gets the 5 most scaned products
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>a dictionary of product name and amount</returns>
    public Dictionary<string, int> Top5ScanedProducts(string managerEmail)
    {

        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@email", managerEmail));
            SqlDataReader dr = ActivateStoredProc("proc_top5_most_scaned", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add(dr["Name"].ToString(), Convert.ToInt32(dr["amount"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }

    /// <summary>
    /// get info about the current active campaign
    /// </summary>
    /// <param name="managerEmail">manager's email for identification</param>
    /// <returns>a grid of data about the active campaign</returns>
    public GridView getActiveCampaignStatistics(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        GridView camp = new GridView();

        try
        {
            paraList.Add(new SqlParameter("@email", managerEmail));
            SqlDataReader dr = ActivateStoredProc("CampaignStatistics", paraList);
            camp.DataSource = dr;
            camp.DataBind();
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return camp;
    }

    /// <summary>
    /// get product most viewed properties
    /// </summary>
    /// <param name="productCounter">the uniq id of the organization's product</param>
    /// <returns>grid view of the details</returns>
    public GridView productPropertiesStatistics(int productCounter)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        GridView camp = new GridView();

        try
        {
            paraList.Add(new SqlParameter("@productCounter", productCounter.ToString()));
            SqlDataReader dr = ActivateStoredProc("productPropertiesStatistics", paraList);
            camp.DataSource = dr;
            camp.DataBind();
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return camp;
    }

    /// <summary>
    /// get general details about the users
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>gridview of details</returns>
    public GridView GeneralDetailsPlots(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        GridView camp = new GridView();

        try
        {
            paraList.Add(new SqlParameter("@email", managerEmail));
            SqlDataReader dr = ActivateStoredProc("GeneralDetailsPlots", paraList);
            camp.DataSource = dr;
            camp.DataBind();
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return camp;
    }

    /// <summary>
    /// get all theexisting  products in a category
    /// </summary>
    /// <param name="id">the category id</param>
    /// <returns>dictionary of product name and uniq id</returns>
    public Dictionary<string, int> GetAllCategoryProducts(string id)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@categoryId", id));
            SqlDataReader dr = ActivateStoredProc("GetAllCategoryProducts", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add(dr["Name"].ToString(), Convert.ToInt32(dr["productCounter"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }

    /// <summary>
    /// get the history of products scan by users
    /// </summary>
    /// <param name="productCounter">the uniq id of the organization's product</param>
    /// <returns>a gridview of the details</returns>
    public GridView GetHistoryScan(int productCounter)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        GridView camp = new GridView();

        try
        {
            paraList.Add(new SqlParameter("@productCounter", productCounter));
            SqlDataReader dr = ActivateStoredProc("GetHistoryScan", paraList);
            camp.DataSource = dr;
            camp.DataBind();
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return camp;
    }

    //////////////////////////////////////End of plots///////////////////////////////////////


    ///////////////////////////////////// Onload procedurs && functions /////////////////////


    /// <summary>
    ///gets the properties of all the existing organizations
    /// </summary>
    /// <returns> Dictionary of property name and id</returns>
    public Dictionary<string, int> getAllProp()
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            SqlDataReader dr = ActivateStoredProc("getAllProperties", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add(dr["Name"].ToString(), Convert.ToInt32(dr["PropertyId"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }

    /// <summary>
    /// gets all the properties of a specific organizations
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>dictionary of property name and id</returns>
    public Dictionary<string, int> getAllProp(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@email", managerEmail));
            SqlDataReader dr = ActivateStoredProc("GetAllPropertiesOrganization", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add(dr["Name"].ToString(), Convert.ToInt32(dr["PropertyId"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }


    /// <summary>
    /// get the profile info about the organization
    /// </summary>
    /// <param name="emailAddress">manager email for identification</param>
    /// <returns>an organization object</returns>
    public Organization getComapnyProfile(string emailAddress)
    {
        Organization org = new Organization();
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@managerEmail", emailAddress));
            SqlDataReader dr = ActivateStoredProc("CompanyProfile", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                org.Name = dr["Name"].ToString();
                org.Industry = dr["indusry"].ToString();
                org.WebSiteUrl = dr["Website"].ToString();
                org.LogoSrc = dr["LogoURL"].ToString();
                org.PhoneNumber = dr["PhoneNumber"].ToString();
                org.Address = dr["Address"].ToString();
                org.Description = dr["Description"].ToString();
                org.FbWebsite = dr["FbWebsite"].ToString();
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return org;
    }

    /// <summary>
    /// get the basic info (not incude properties) of all the existing products of an organization
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>a list of product objects</returns>
    public List<Product> GetAllProductInfoBasic(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        List<Product> products = new List<Product>();
        try
        {
            paraList.Add(new SqlParameter("@emailAddress", managerEmail));
            SqlDataReader dr = ActivateStoredProc("GetAllProductInfoBasic", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                Product product = new Product();
                product.CategoryName = dr["Name"].ToString();
                product.Id = Convert.ToInt32(dr["ProductId"]);
                product.Name = dr["productName"].ToString();
                product.Price = Convert.ToDouble(dr["Price"]);
                if (dr["Discount"] != null || dr["Discount"] != "")
                    product.Discount = dr["Discount"].ToString();
                product.ImageUrl = dr["img"].ToString();
                product.Description = dr["ShortDescription"].ToString();
                products.Add(product);
            }
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return products;
    }


    /// <summary>
    /// get the properties info of a specific product from the db
    /// </summary>
    /// <param name="managerEmail">manager's email for identification</param>
    /// <param name="productId">to select a specific product from the db</param>
    /// <returns>a list of the product info</returns>
    public List<Property> GetProductPropertiesInfo(string managerEmail, int productId)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        List<Property> properties = new List<Property>();

        try
        {
            paraList.Add(new SqlParameter("@emailAddress", managerEmail));
            paraList.Add(new SqlParameter("@productId", productId));
            SqlDataReader dr = ActivateStoredProc("proc_GetProductPropertiesInfo", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                Property prop = new Property();
                prop.Name = dr["Name"].ToString();
                prop.Description = dr["description"].ToString();
                properties.Add(prop);
            }
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return properties;
    }


    /// <summary>
    /// gets the existing catagories names
    /// </summary>
    /// <param name="managerEmail">manager email for identification</param>
    /// <returns>dictionary of category name and id</returns>
    public Dictionary<string, int> getCategoriesNames(string managerEmail)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@managerEmail", managerEmail));
            SqlDataReader dr = ActivateStoredProc("proc_Categories_list", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add(dr["Name"].ToString(), Convert.ToInt32(dr["CatagoryId"]));
            }

        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            closeConnection();
        }
        return names;
    }

    /// <summary>
    /// gets all the proporties of an existing  catagory
    /// </summary>
    /// <param name="categoryID">id of the specific category</param>
    /// <returns>dictionary of property name and id</returns>
    public Dictionary<string, int> getCategoryProperties(int categoryID)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> names = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@categoryID", categoryID));
            SqlDataReader dr = ActivateStoredProc("proc_GetProperties", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                names.Add(dr["Name"].ToString(), Convert.ToInt32(dr["PCID"]));
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }


    /// <summary>
    ///gets all the existing industries
    /// </summary>
    /// <returns> returen a list of industries</returns>
    public List<Industry> GetAllIndustries()
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        List<Industry> names = new List<Industry>();
        try
        {
            SqlDataReader dr = ActivateStoredProc("GetAllIndustries", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                Industry n = new Industry();
                n.Name = dr["Name"].ToString();
                n.ID = Convert.ToInt32(dr["IndusryId"]);
                names.Add(n);
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return names;
    }


    /// <summary>
    /// get a list of fb campaigns and their info from the db to show at the campaign table
    /// </summary>
    /// <param name="email">the manager email</param>
    /// <returns>a list of the campaigns</returns>
    public List<Campaign> GetCampaignsList(string email)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        List<Campaign> campaigns = new List<Campaign>();
        try
        {
            paraList.Add(new SqlParameter("@emailAddress", email));
            SqlDataReader dr = ActivateStoredProc("GetCampaignsTable", paraList);

            while (dr.Read())
            {// Read till the end of the data into a row
                Campaign cam = new Campaign();
                cam.Name = dr["Name"].ToString();
                cam.Description = dr["Description"].ToString();
                cam.Voucher = dr["Voucher"].ToString();
                cam.ShareCount = Convert.ToInt32(dr["ShareCount"]);
                cam.DateCreated = Convert.ToDateTime(dr["DateCreated"]);
                cam.IsActive = Convert.ToBoolean(dr["IsActive"]);
                campaigns.Add(cam);
            }
            //Name, Description, Voucher,ShareCount,DateCreated,IsActive
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return campaigns;
    }

    /// <summary>
    /// get a list of campaigns names and share count from the db
    /// </summary>
    /// <param name="email">the manager email</param>
    /// <returns>a list of the campaigns</returns>
    public Dictionary<string, int> GetCampaignsShare(string email)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        Dictionary<string, int> campaigns = new Dictionary<string, int>();
        try
        {
            paraList.Add(new SqlParameter("@emailAddress", email));
            SqlDataReader dr = ActivateStoredProc("getTop5campaigns", paraList);

            while (dr.Read())
            {// Read till the end of the data into a row

                campaigns.Add(dr["Name"].ToString(), Convert.ToInt32(dr["ShareCount"]));
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        finally
        {
            closeConnection();
        }
        return campaigns;
    }

    /// <summary>
    ///  create a uniq id for an organization product
    /// </summary>
    /// <param name="o">org id</param>
    /// <param name="p">product id</param>
    /// <returns>the product counter string</returns>
    private string GetProductCounter(string o, string p)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        string productCounter = "";
        try
        {
            paraList.Add(new SqlParameter("@oragnizationId", o));
            paraList.Add(new SqlParameter("@productID", p));
            SqlDataReader dr = ActivateStoredProc("getProductCounter", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                productCounter = dr["productCounter"].ToString();
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            closeConnection();
        }
        return productCounter;
    }

    /// <summary>
    /// get the manager id by his email to match organization
    /// </summary>
    /// <param name="email">email for identification</param>
    /// <returns>string represent the organization</returns>
    private string getManagerId(string email)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        string organizaion = "";
        try
        {
            paraList.Add(new SqlParameter("@emailAddress", email));
            SqlDataReader dr = ActivateStoredProc("GetManagerOrganizationProc", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                organizaion = dr["OrganizationID"].ToString();
            }
            return organizaion;
        }
        catch (Exception ex)
        {
            return organizaion;
        }
        finally
        {
            closeConnection();
        }
    }


    /// <summary>
    /// insert a new product into the db && the properties description to the db
    /// </summary>
    /// <param name="product">new product's object</param>
    /// <param name="categoryID">the category to which the product belong</param>
    /// <param name="pp">the properties of the product</param>
    /// <param name="emailManager">manager email for identification</param>
    /// <returns>num of rows changed</returns>
    public int insertNewProduct(Product product, int categoryID, Dictionary<int, string> pp, string emailManager)
    {
        List<SqlParameter> paraList = new List<SqlParameter>();
        string organizaion = "";
        try
        {
            organizaion = getManagerId(emailManager);
            paraList.Add(new SqlParameter("@emailAddress", emailManager));
            SqlDataReader dr = ActivateStoredProc("GetManagerOrganizationProc", paraList);
            while (dr.Read())
            {// Read till the end of the data into a row
                // read first field from the row into the list collection
                organizaion = dr["OrganizationID"].ToString();
            }
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }
        int rowChangeProduct;
        String prefix;
        String command;
        StringBuilder sb = new StringBuilder();
        if (product.Discount != null)
        {
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')", product.Id.ToString(), product.Name, product.Description, product.Price.ToString(), product.DateModified.ToString("yyyy-MM-dd HH:mm:ss"), product.Discount, organizaion, categoryID, product.ImageUrl);
            prefix = "INSERT INTO Product " + "(ProductId,Name,ShortDescription,Price,DateModified,Discount,OrganizationID,CatagoryId,img)";
        }
        else
        {
            sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", product.Id.ToString(), product.Name, product.Description, product.Price.ToString(), product.DateModified.ToString("yyyy-MM-dd HH:mm:ss"), organizaion, categoryID, product.ImageUrl);
            prefix = "INSERT INTO Product " + "(ProductId,Name,ShortDescription,Price,DateModified,OrganizationID,CatagoryId,img)";
        }
        command = prefix + sb.ToString();
        rowChangeProduct = insertCommand(command);
        if (rowChangeProduct > 0)
        {
            string productCounter = GetProductCounter(organizaion, product.Id.ToString());
            foreach (KeyValuePair<int, string> pair in pp)
            {
                sb.Clear();
                command = "";
                prefix = "";
                sb.AppendFormat("Values('{0}', '{1}', '{2}')", productCounter, pair.Key, pair.Value);
                prefix = "INSERT INTO productPC " + "(productCounter,PCID,description)";
                command = prefix + sb.ToString();
                rowChangeProduct = insertCommand(command);
                if (rowChangeProduct == 0)
                    return 0;
            }
            return rowChangeProduct;
        }
        else
        {
            return 0;
        }

    }

    /// <summary>
    /// insert a new category to the db
    /// </summary>
    /// <param name="c">object of the new category</param>
    /// <param name="lProperty">an array of the properties</param>
    /// <param name="email">manager email for identification</param>
    /// <returns>num of rows changed</returns>
    public int insertNewCategory(Category c, string[] lProperty, string email)
    {

        try
        {
            Dictionary<string, int> categories = getCategoriesNames(email);
            int rowChanged;
            String command;
            StringBuilder sb = new StringBuilder();
            if (!categories.ContainsKey(c.Name))
            {
                sb.AppendFormat("Values('{0}', '{1}', '{2}')", c.Name, c.Description, email);
                String prefix = "INSERT INTO Category " + "(Name, Description,Email_address)";
                command = prefix + sb.ToString();
                rowChanged = insertCommand(command);
                if (rowChanged > 0)
                {
                    Dictionary<string, int> props = getAllProp();
                    foreach (string p in lProperty)
                    {

                        if (!props.ContainsKey(p))
                        {
                            sb.Clear();
                            sb.AppendFormat("Values('{0}')", p);
                            prefix = "INSERT INTO Property " + "(Name)";
                            command = prefix + sb.ToString();
                            rowChanged = insertCommand(command);
                        }
                        props = getAllProp();
                        categories = getCategoriesNames(email);
                        sb.Clear();
                        sb.AppendFormat("Values('{0}','{1}')", categories[c.Name], props[p]);
                        prefix = "INSERT INTO Property_of_Category " + "(CatagoryId,PropertyId)";
                        command = prefix + sb.ToString();
                        rowChanged = insertCommand(command);
                    }
                    return 1;
                }
            }
            return 0;
        }
        catch (Exception)
        {
            return 0;
        }

    }


    /// <summary>
    /// insert a new campaign into the db
    /// </summary>
    /// <param name="campaign">an object of a new campaign</param>
    /// <param name="emailManager">manager email for identification</param>
    /// <returns>num of rows changed</returns>
    public int insertNewCampaign(Campaign campaign, string emailManager)
    {
        int rowChangedCampaign;
        String command;
        StringBuilder sb = new StringBuilder();
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}','{5}','{6}','{7}','{8}')", campaign.Name, campaign.Description, campaign.Voucher, campaign.Expiration, campaign.ImageUrl, campaign.LinkUrl,campaign.DateCreated.ToString("yyyy-MM-dd HH:mm:ss"), emailManager, campaign.IsActive);
        String prefix = "INSERT INTO Campaign " + "(Name, Description, Voucher, Expiration,Img,Link,DateCreated,Email_address,IsActive)";
        command = prefix + sb.ToString();
        rowChangedCampaign = insertCommand(command);

        return rowChangedCampaign;
    }

    ///////////////////////////////////////End of onlaod procedurs && functions /////////////////////


    /////////////////////////////////////// Execution of commands && procedures  ///////////////////


    /// <summary>
    /// activate stored procedure
    /// </summary>
    /// <param name="procName">procedure name</param>
    /// <param name="parametersList">a list of input parameters for the procedure</param>
    /// <returns>sqlreader object</returns>
    private SqlDataReader ActivateStoredProc(string procName, List<SqlParameter> parametersList)
    {
        SqlConnection con;
        SqlDataReader dr;
        Dictionary<string, int> names = new Dictionary<string, int>();

        try
        {

            con = GetOpenConnection(); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            SqlCommand cmd = new SqlCommand(procName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parametersList)
            {
                cmd.Parameters.Add(parameter);
            }
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        return dr;
    }

    /// <summary>
    /// insert the command
    /// </summary>
    /// <param name="command">command string</param>
    /// <returns>num of rows changed</returns>
    private int insertCommand(string command)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = GetOpenConnection(); // create a connection to the database using the connection String defined in the web config file
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommand(command, con);  // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
            // write to log

        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }
    }

    /// <summary>
    /// create the command
    /// </summary>
    /// <param name="CommandSTR">command string</param>
    /// <param name="con">connetion string</param>
    /// <returns>sqlcommand object</returns>
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    ////////////////////////////////////// End of Execution of commands && procedures  ///////////////////

}//class