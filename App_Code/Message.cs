using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Web;
using System.Text.RegularExpressions;
using System.Net;

public class Message
{
    public string GetHtmlFromUrl(string url)
    {
        string strRet = null;
        if (url == null || url.Trim().ToString() == "")
        {
            return strRet;
        }
        string targeturl = url.Trim().ToString();
        try
        {
            HttpWebRequest hr = (HttpWebRequest)WebRequest.Create(targeturl);
            hr.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            hr.Method = "GET";
            hr.Timeout = 30 * 60 * 1000;
            WebResponse hs = hr.GetResponse();
            Stream sr = hs.GetResponseStream();
            StreamReader ser = new StreamReader(sr, Encoding.Default);
            strRet = ser.ReadToEnd();
        }
        catch (Exception ex)
        {
            strRet = null;
        }
        return strRet;
    }
    public string SendMessage(string s_PhoneNumber, string s_Text)
    {
        string s_UID = "bremax";
        string s_Key = "4334982f7bdcb568e7ae";
        string s_URL = "http://utf8.sms.webchinese.cn/?Uid=" + s_UID + "&Key=" + s_Key + "&smsMob=" + s_PhoneNumber + "&smsText=" + s_Text + "";
        string s_Return = "";
        try
        {
            s_Return = GetHtmlFromUrl(s_URL);
            //if (s_Return == null)
            //{
            //    s_URL = "http://gbk.sms.webchinese.cn/?Uid=" + s_UID + "&Key=" + s_Key + "&smsMob=" + s_PhoneNumber + "&smsText=" + s_Text + "";
            //    s_Return = GetHtmlFromUrl(s_URL);
            //}
        }
        catch { }
        return GetSendError(s_Return);
    }
    public string GetSendError(string s_Error)
    {
        switch (s_Error)
        {
            case "-1":
                return "没有该用户账户";
            case "-2":
                return "密钥不正确";
            case "-3":
                return "短信数量不足";
            case "-11":
                return "该用户被禁用";
            case "-14":
                return "短信内容出现非法字符";
            case "-4":
                return "手机号格式不正确";
            case "-41":
                return "手机号码为空";
            case "-42":
                return "短信内容为空";
            default:
                return "已发送 " + s_Error + " 条短信";
        }

    }
}