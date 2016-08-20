using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// Copyright by LAOLI
/// 字符串生成MD5值
/// QQ:334818149
/// Blog:http://www.j9s.net 可以解答关于程序上的问题
/// WEB:http://www.5itla.com
/// WEB:http://www.uqishi.com
/// WEB:http://www.clube.cn
/// </summary>
public class MD5
{
	public MD5()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static string strToMD5(string toMD5)
    {
        string _md5 = FormsAuthentication.HashPasswordForStoringInConfigFile(toMD5, "MD5");
        return FormsAuthentication.HashPasswordForStoringInConfigFile(_md5, "MD5");
    }
}
