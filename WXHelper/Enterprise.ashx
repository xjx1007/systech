<%@ WebHandler Language="C#" Class="Enterprise" %>

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Tencent;


public class Enterprise : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        if (context.Request.HttpMethod.ToLower().Equals("get"))
        {

            CheckServer();

        }
        else
        {
            //WXHttpHelper wx = new WXHttpHelper("ww444122a81d0b7922", "abc123", "k1HliFMZJBNRwsZln9L5SMcXxx4fU2ug3xqSICl2OHr", "5UzU1a3SoTk6c45spUSAztIkvZ74UHPD_katnYiAasA");
            //wx.Get_WXDate(context);
            //if (wx.MsgText=="")
            //{
            //     //context.Response.Write(wx.ResponseWX(MsgImage, requestToUserID, "你好"));
            //}

            //BSRequest(context);
        }
    }
    /// <summary>
    /// 校验url
    /// </summary>
    private void CheckServer()
    {

        #region 获取关键参数  
        string token = ConfigurationManager.AppSettings["CorpToken"];//从配置文件获取Token  
        string encodingAESKey = ConfigurationManager.AppSettings["EncodingAESKey"];//从配置文件获取EncodingAESKey  
        string corpId = ConfigurationManager.AppSettings["CorpId"];//从配置文件获取corpId  
        #endregion

        string echoString = HttpContext.Current.Request.QueryString["echoStr"];
        string signature = HttpContext.Current.Request.QueryString["msg_signature"];//企业号的 msg_signature  
        string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
        string nonce = HttpContext.Current.Request.QueryString["nonce"];
        System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("/") + "a.txt", echoString + "," + signature + "," + timestamp + "," + nonce);
        string decryptEchoString = "";
        if (CheckSignature(token, signature, timestamp, nonce, corpId, encodingAESKey, echoString, ref decryptEchoString))
        {
            if (!string.IsNullOrEmpty(decryptEchoString))
            {
                HttpContext.Current.Response.Write(decryptEchoString);
                HttpContext.Current.Response.End();
            }
        }
    }



    public bool CheckSignature(string token, string signature, string timestamp, string nonce, string corpId, string encodingAESKey, string echostr, ref string retEchostr)
    {
        WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(token, encodingAESKey, corpId);
        int result = wxcpt.VerifyURL(signature, timestamp, nonce, echostr, ref retEchostr);
        if (result != 0)
        {
            //LogTextHelper.Error("ERR: VerifyURL fail, ret: " + result);

            return false;
        }

        return true;
        //ret==0表示验证成功，retEchostr参数表示明文，用户需要将retEchostr作为get请求的返回参数，返回给企业号。  
        // HttpUtils.SetResponse(retEchostr);  
    }
    /// <summary>
    /// 接受消息，反馈消息
    /// </summary>
    /// <param name="context"></param>
    public void Enter(HttpContext context)
    {

        string sToken = "abc123";
        string sEncodingAESKey = "k1HliFMZJBNRwsZln9L5SMcXxx4fU2ug3xqSICl2OHr";
        string sAppID = "wxa6bfcd91a60d6225";
        WXBizMsgCrypt wxcpt = new WXBizMsgCrypt(sToken, sEncodingAESKey, sAppID);//初始化加解密类

        string sReqMsgSig = context.Request["msg_signature"];
        string sReqNonce = context.Request["nonce"];
        string sReqTimeStamp = context.Request["timestamp"];

        var reader = XmlReader.Create(context.Request.InputStream);//获取加密的xml文件
        var doc = XDocument.Load(reader);
        var xml = doc.Element("xml");
        string sReqData = xml.ToString();
        //对收到的密文进行解析处理
        string sMsg = "";  // 解析之后的明文
        int flag = wxcpt.DecryptMsg(sReqMsgSig, sReqTimeStamp, sReqNonce, sReqData, ref sMsg);
        if (flag != 0)
        {
            //解密失败
            return;
        }

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(sMsg);
        XmlNode root = xmlDoc.FirstChild;//root["title"].OuterXml          
        string requestFromUserID = root["FromUserName"].InnerText;//用户账号
        string requestToUserID = root["ToUserName"].InnerText;//公众号         
        string sEncryptMsg = ""; //xml格式的密文
        wxcpt.EncryptMsg(ToXmlString("你好!!我叫阿圣", requestFromUserID, requestToUserID), DateTime.Now.ToBinary().ToString(), sReqNonce, ref sEncryptMsg);
        context.Response.ContentEncoding = Encoding.UTF8;
        context.Response.Write(sEncryptMsg);

    }
    private string ToXmlString(string content, string username, string requestToUserID)
    {
        string s = "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Content><![CDATA[{4}]]></Content></xml>";
        s = string.Format(s, "mr.self", "ww444122a81d0b7922", DateTime.Now.ToBinary().ToString(), "text", content + username + requestToUserID);
        return s;
    }

    /// <summary>
    /// 主动给微信用户推送消息
    /// </summary>
    public void BSRequest(HttpContext context)
    {
        string corpid = ConfigurationManager.AppSettings["CorpId"];
        string corpsecret = ConfigurationManager.AppSettings["Secret"];
        //if (context.Request.QueryString["TypeId"].ToString()=="1")
        //{
        string wx_Code = GenerateRandomNumber(4);//获取6位验证码
                                                 //}
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" + GeTokenJsonResult(corpid, corpsecret));
        string json = "{\"touser\":\"@all\",\"toparty\":\"\",\"totag\":\"\",\"msgtype\":\"text\",\"agentid\":1000002, \"text\":{\"content\":\"您ERP登陆微信验证码为：" + wx_Code + "\"},\"safe\":0}";
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentType = "application/json; charset=UTF-8";
        httpWebRequest.Timeout = 20000;
        byte[] bytes = Encoding.UTF8.GetBytes(json);
        Stream sendStream = httpWebRequest.GetRequestStream();
        sendStream.Write(bytes, 0, bytes.Length);
        sendStream.Close();
        //得到返回值  
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
        string responseContent = streamReader.ReadToEnd();
        //转化成json对象处理  
        //List<GetOrderQuantity> getOrderQuantity = sr.Deserialize<List<GetOrderQuantity>>(OrderQuantity); 
        context.Response.Write(wx_Code);
        streamReader.Close();
        httpWebResponse.Close();
        httpWebRequest.Abort();


    }
    /// <summary>
    /// 获取token
    /// </summary>
    /// <param name="corpid"></param>
    /// <param name="corpsecret"></param>
    /// <returns></returns>
    public static string GeTokenJsonResult(string corpid, string corpsecret)
    {
        string url = string.Format(
                "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}", corpid, corpsecret);
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
        string responseContent = streamReader.ReadToEnd();
        JObject jo = (JObject)JsonConvert.DeserializeObject(responseContent);
        string zone = jo["access_token"].ToString();
        //string zone_en = jo["zone_en"].ToString();

        return zone;
    }

    private static char[] constant = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    public static string GenerateRandomNumber(int Length)//调用时想生成几位就几位；Length等于多少就多少位。
    {
        StringBuilder newRandom = new StringBuilder(10);
        Random rd = new Random();
        for (int i = 0; i < Length; i++)
        {
            newRandom.Append(constant[rd.Next(10)]);
        }
        return newRandom.ToString();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}