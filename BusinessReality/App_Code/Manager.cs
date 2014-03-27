using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Manager
/// </summary>
public class Manager
{
    private string emailAdress;
    private string passWord;
    private string fName;
    private string lName;

    public Manager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string EmailAdress { get { return this.emailAdress; } set { this.emailAdress = value; } }
    public string PassWord { get { return this.passWord; } set { this.passWord = value; } }
    public string Fname { get { return this.fName; } set { this.fName = value; } }
    public string Lname { get { return this.lName; } set { this.lName = value; } }

}