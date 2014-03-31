using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Industry
/// </summary>
public class Industry
{
    private int id;
    private string name;
	public Industry()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID
    {
        get { return this.id; }
        set { this.id = value; }
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    /// <summary>
    ///call the db class to get all the existing industries
    /// </summary>
    /// <returns> returen a list of industries</returns>
    public List<Industry> GetAllIndustries()
    {
        DataBaseManager db = new DataBaseManager();
        return db.GetAllIndustries();
    }
}