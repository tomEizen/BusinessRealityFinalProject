using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{
    private string fName;
    private string lName;
    private string city;
    private int age;


    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Fname { get { return this.fName; } set { this.fName = value; } }
    public string Lname { get { return this.lName; } set { this.lName = value; } }
    public string City { get { return this.city; } set { this.city = value; } }
    public int Age { get { return this.age; } set { this.age = value; } }

    public Dictionary<string, int> getGenderStatistics(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.getGenderStatistics(email);
    }


    /// <summary>
    /// calls the db class and gets the users ages list from the db 
    /// </summary>
    /// <param name="email">the manager's email for identification</param>
    /// <returns>a list of the users ages</returns>
    public Dictionary<string, int> getAgesStatistics(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.getAgeStatistics(email);   
    
    }

    /// <summary>
    /// calls the db class and gets the users ages list of users whe shared a campaihn from the db 
    /// </summary>
    /// <param name="email">the manager's email for identification</param>
    /// <returns>a list of the users ages</returns>
    public Dictionary<string, int> GetCampignsShareAges(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetCampignsShareAges(email);
    }

    public Dictionary<string, int> GetCampignsShareGender(string email)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetCampaignShareGender(email);
    }


}