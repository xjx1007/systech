using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;

public partial class Web_System_Document_MediaPlayer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string id = Request.QueryString["Id"].ToString();
            KNet.BLL.PB_Basic_Document bll = new KNet.BLL.PB_Basic_Document();
            KNet.Model.PB_Basic_Document Model = bll.GetModel(id);
            Label1.Text = MediaPlayer(500, 400, "F:/System_Mis/UpFile/Word/" + Model.PBM_DocName + "");

        }
    }
    /// <summary>//绑定视频播放
    /// 绑定视频播放
    /// </summary>
    /// <param name="width">播放器宽度</param>
    /// <param name="height">播放器高度</param>
    /// <param name="link">播放文件地址</param>
    /// <returns></returns>
    public  string MediaPlayer(int width, int height, string link)
    {
        string str = "";
        try
        {
            str += "<object id='player' height='" + height + "' width='" + width + "' classid='clsid:CFCDAA03-8BE4-11cf-B84B-0020AFBBCCFA'>";
            str += "<param NAME='AutoStart' VALUE='-1'>";
            //str += "<!--是否自动播放-->";
            str += "<param NAME='Balance' VALUE='0'>";
            //str += "<!--调整左右声道平衡,同上面旧播放器代码-->";
            str += "<param name='enabled' value='1'>";
            //str += "<!--播放器是否可人为控制-->";
            str += "<param NAME='EnableContextMenu' VALUE='-1'>";
            //str += "<!--是否启用上下文菜单-->";
            str += "<param NAME='url' value='" + link + "'>";
            //str += "<!--播放的文件地址-->";
            str += "<param NAME='PlayCount' VALUE='10'>";
            //str += "<!--播放次数控制,为整数-->";
            str += "<param name='rate' value='1'>";
            //str += "<!--播放速率控制,1为正常,允许小数,1.0-2.0-->";
            str += "<param name='currentPosition' value='0'>";
            //str += "<!--控件设置:当前位置-->";
            str += "<param name='currentMarker' value='0'>";
            //str += "<!--控件设置:当前标记-->";
            str += "<param name='defaultFrame' value=''>";
            //str += "<!--显示默认框架-->";
            str += "<param name='invokeURLs' value='0'>";
            //str += "<!--脚本命令设置:是否调用URL-->";
            str += "<param name='baseURL' value=''>";
            //str += "<!--脚本命令设置:被调用的URL-->";
            str += "<param name='stretchToFit' value='0'>";
            //str += "<!--是否按比例伸展-->";
            str += "<param name='volume' value='50'>";
            //str += "<!--默认声音大小0%-100%,50则为50%-->";
            str += "<param name='mute' value='0'>";
            //str += "<!--是否静音-->";
            str += "<param name='uiMode' value='Full'>";
            //str += "<!--播放器显示模式:Full显示全部;mini最简化;None不显示播放控制,只显示视频窗口;invisible全部不显示-->";
            str += "<param name='windowlessVideo' value='0'>";
            //str += "<!--如果是0可以允许全屏,否则只能在窗口中查看-->";
            str += "<param name='fullScreen' value='0'>";
            //str += "<!--开始播放是否自动全屏-->";
            str += "<param name='enableErrorDialogs' value='-1'>";
            //str += "<!--是否启用错误提示报告-->";
            str += "<param name='SAMIStyle' value>";
            //str += "<!--SAMI样式-->";
            str += "<param name='SAMILang' value>";
            //str += "<!--SAMI语言-->";
            str += "<param name='SAMIFilename' value>";
            //str += "<!--字幕ID-->";
            str += "</object>";

        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        return str;
    }
}