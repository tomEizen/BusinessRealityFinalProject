using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Branch
/// </summary>
public class Branch
{

    private string name;
    private string adrress;
    private string phone;
    private double lat;
    private double lng;
    
	public Branch()
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

    public string Adress
    {
        get { return this.adrress; }
        set { this.adrress = value; }
    }

    public string Phone
    {
        get { return this.phone; }
        set { this.phone = value; }
    }

    public double Lat
    {
        get { return this.lat; }
        set { this.lat = value; }
    }

    public double Lng
    {
        get { return this.lng; }
        set { this.lng = value; }
    }
}