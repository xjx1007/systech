using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Tencent;

/// <summary>
/// HttpRequest 的摘要说明
/// </summary>
public class WXHttpHelper
{
   
    private string WX_AsseccToken;
    private WXBizMsgCrypt wxcpt;
    public string UserName;//用户名
    public string MsgText= "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Content><![CDATA[{4}]]></Content></xml>";//内容为文本
    private string MsgImage ="<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></ FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><PicUrl><![CDATA[{4}]]></PicUrl><MediaId><![CDATA[{5}]]></MediaId></xml>";//内容为图片
    /// <summary>
    /// 企业ID
    /// </summary>
    public WXHttpHelper(string corpId,string corptoken,string sEncodingaeskey,string Secret)
    {
        //this.corpId
        wxcpt = new WXBizMsgCrypt(corptoken, sEncodingaeskey, corpId);//初始化加解密类
        WX_AsseccToken = GeTokenJsonResult(corpId, Secret);
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
        return zone;
    }
    /// <summary>
    /// 主动给微信服务器发消息
    /// </summary>
    /// <param name="touser">用户</param>
    /// <param name="toparty">部门ID</param>
    /// <param name="totag">标签ID</param>
    /// <param name="msgtype">内容类型</param>
    /// <param name="agentid">应用ID</param>
    /// <param name="text">发送内容</param>
    /// <returns></returns>
    public string WX_ActiveSend(string touser, string toparty, string totag, string msgtype, string agentid, string text)
    {
        HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token=" +WX_AsseccToken );
        string json = "{\"touser\":\""+touser+"\",\"toparty\":\""+toparty+"\",\"totag\":\""+totag+"\",\"msgtype\":\""+msgtype+"\",\"agentid\":"+ agentid + ", \"text\":{\"content\":\"" + text + "\"},\"safe\":0}";
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
        streamReader.Close();
        httpWebResponse.Close();
        httpWebRequest.Abort();
        return responseContent;


    }
   
    /// <summary>
    /// 获取用户发来的信息
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public void Get_WXDate(HttpContext context)
    {
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
        
        XmlNode root = xmlDoc.FirstChild;
        string requestFromUserID = root["FromUserName"].InnerText;//用户账号
        string requestToUserID = root["ToUserName"].InnerText;//公众号
        string content = root["Content"].InnerText;//消息内容
        string MsgType= root["MsgType"].InnerText;//内容类型
        UserName = requestFromUserID;
        MsgText = sMsg;
        //if (MsgType == "text")
        //{
        //    context.Response.ContentEncoding = Encoding.UTF8;
        //    context.Response.Write(ResponseWX(MsgText, requestToUserID, "你好"));
           
        //}
        //else
        //{
        //    context.Response.ContentEncoding = Encoding.UTF8;
        //    context.Response.Write(ResponseWX(MsgImage, requestToUserID, "你好"));
        //}
    }
    /// <summary>
    /// 需要返回用户的信息
    /// </summary>
    /// <param name="MsgText"></param>
    /// <param name="requestToUserID"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    public string ResponseWX(string MsgText, string requestToUserID,string text)
    {
        //string s = "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[{3}]]></MsgType><Content><![CDATA[{4}]]></Content></xml>";
       string s = string.Format(MsgText, UserName, requestToUserID, DateTime.Now.ToBinary().ToString(), "text", text);
        return s;
    }
}