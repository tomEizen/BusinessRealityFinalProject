using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for QrCode
/// </summary>
public class QrCode
{
    private string qrPicUrl;

	public QrCode()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string QrPicUrl  { get { return this.qrPicUrl; } set { this.qrPicUrl = value; } }
}