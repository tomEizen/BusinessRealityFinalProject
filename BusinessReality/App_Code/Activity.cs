using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Activity
/// </summary>
public class Activity
{
    private DateTime logIn;

	public Activity()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    
    public DateTime LogIn
    {
        get { return this.logIn; }
        set { this.logIn = value; }
    }

}