using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Property
/// </summary>
public class Property
{
    private string name;

	public Property()
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

    public Dictionary<string, int> getAllProp(string managerEmail)
    {

        DataBaseManager db = new DataBaseManager();
        return db.getAllProp(managerEmail);

  
    
    }



}


