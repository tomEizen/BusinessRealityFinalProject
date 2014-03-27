using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Discount
/// </summary>
public class Discount
{
    private bool isDiscount;
    private string discountDescription;

    public Discount()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool IsDiscount
    {
        get { return this.isDiscount; }
        set { this.isDiscount = value; }
    }
    public string DiscountDescription
    {
        get { return this.discountDescription; }
        set { this.discountDescription = value; }
    }
}