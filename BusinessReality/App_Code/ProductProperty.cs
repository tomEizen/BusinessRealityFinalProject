using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductProperty
/// </summary>
public class ProductProperty
{
    private string description;

    public ProductProperty()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string Description { get { return this.description; } set { this.description = value; } }
}