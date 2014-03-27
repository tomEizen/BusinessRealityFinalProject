using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for Scan
/// </summary>
public class Scan
{
    private DateTime timeOfScan;

	public Scan()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DateTime TimeOfScan
    {
        get { return this.timeOfScan; }
        set { this.timeOfScan = value; }
    }
    public GridView GeneralDetailsPlots(string managerEmail)
    {
        DataBaseManager db = new DataBaseManager();
        return db.GeneralDetailsPlots(managerEmail);
    }
}