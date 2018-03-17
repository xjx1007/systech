using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using System.Text;

public partial class Web_Test : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.KD.DataSource = this.Dtb_Result;
            this.KD.DataTextField = "PBW_Name";
            this.KD.DataValueField = "PBW_Code";
            this.KD.DataBind();
        }
    }

    protected void Btn_Click(object sender, EventArgs e)
    {
        String url = "http://api.ickd.cn/?com=" + this.KD.SelectedValue + "&nu=" + this.Code.Text + "&id=F358C662FEC3E1CAA2C8C20DD2F9A448&type=Html";


        this.BeginQuery("Select * from PB_Basic_Wl where PBW_Name='" + this.KD.SelectedItem.Text + "'");
        this.QueryForDataTable();
        if(this.Dtb_Result.Rows.Count>0)
        {
            if (this.Dtb_Result.Rows[0]["PBW_Code"].ToString() == "")
            {
                WebPage webInfo = new WebPage(this.Dtb_Result.Rows[0]["PBW_Url"].ToString() + this.Code.Text);

               // webInfo.Context;//不包含html标签的所有内容  
                this.Lbl_wl.Text = webInfo.M_html.Replace("请输入运单编号", "");
                this.Lbl_wl.Text = this.Lbl_wl.Text.Replace("<textarea name=\"ID\" rows=\"5\" id=\"ID\"></textarea>", "");
                this.Lbl_wl.Text = this.Lbl_wl.Text.Replace("<input type=\"submit\" name=\"Submit\" value=\"提交\">", "");
                this.Lbl_wl.Text = this.Lbl_wl.Text.Replace("<input type=\"reset\" name=\"Submit2\" value=\"重置\">", "");
            }
            else
            {
                this.Lbl_wl.Text = getPageInfo(url);
 
            }
        }

        // this.Lbl_wl.Text = getPageInfo(url);


        //s_Return+="<table width=\"520px\" cellspacing=\"0\" cellpadding=\"0\" border=\"0\" style=\"border-collapse: collapse; border-spacing: 0pt;\">'";
        //s_Return+="<tr>";                   
        //s_Return+="<td width=\"163\" style=\"background-color:#e6f9fa;border:1px solid #75c2ef;font-size:14px;font-weight:bold;height:20px;text-indent:15px;\">";                   
        //s_Return+="时间";                   
        //s_Return+="</td>";                   
        //s_Return+="<td width=\"354\" style=\"background-color:#e6f9fa;border:1px solid #75c2ef;font-size:14px;font-weight:bold;height:20px;text-indent:15px;\">";                   
        //s_Return+="地点和跟踪进度";                   
        //s_Return+="</td>";      
        //s_Return+="<tr>";                  
        //输出data的子对象变量                   
        //      $.each(dataObj.data,function(idx,item){                           
        //          html+='<tr>';                           
        //          html+='<td width="163" style="border:1px solid #dddddd;font-size: 12px;line-height:22px;padding:3px 5px;">';                           
        //          html+=item.time;// 每条数据的时间                           
        //          html+='</td>';                           
        //          html+='<td width="354" style="border:1px solid #dddddd;font-size: 12px;line-height:22px;padding:3px 5px;">';                           
        //          html+=item.context;// 每条数据的状态                          
        //          html+='</td>';                          
        //        html+='</tr>';                  
        //       });                   
        //      html+='</table>';           
        //}else{
        //    //查询不到                   
        //    html+='<span style="color:#f00">Sorry！ '+dataObj.message+'</span>';          
        //}      
        //    html+='</td></tr>';           
        //    $("#shipping_detail").append(html);

    }
    public static string getPageInfo(String url)
    {
        WebResponse wr_result = null;
        StringBuilder txthtml = new StringBuilder();
        try
        {
            WebRequest wr_req = WebRequest.Create(url);
            wr_req.Timeout = 50;
            wr_result = wr_req.GetResponse();
            Stream ReceiveStream = wr_result.GetResponseStream();
            Encoding encode = System.Text.Encoding.GetEncoding("gb2312");
            StreamReader sr = new StreamReader(ReceiveStream, encode);
            if (true)
            {
                Char[] read = new Char[256];
                int count = sr.Read(read, 0, 256);
                while (count > 0)
                {
                    String str = new String(read, 0, count);
                    txthtml.Append(str);
                    count = sr.Read(read, 0, 256);
                }
            }
        }
        catch (Exception)
        {
            txthtml.Append("err");
        }
        finally
        {
            if (wr_result != null)
            {
                wr_result.Close();
            }
        }
        return txthtml.ToString();
    } 
}
