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

public partial class Web_SalesQuotes_Xs_Sales_Quotes_Print : BasePage
{
    public string s_Company = "", s_LinkMan="",s_CustomerName="",s_DutypersonName="",s_Table="";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
                        //<tr>
                        //    <td width="8%" align="center">
                        //        1</td>
                        //    <td width="22%" align="center">
                        //        尼康A90</td>
                        //    <td width="25%" align="center">
                        //        黑色</td>
                        //    <td width="10%" align="center">
                        //        1.00台</td>
                        //    <td width="10%" align="center">
                        //        1,550.00</td>
                        //    <td width="10%" align="center">
                        //        1,550.00</td>
                        //    <td width="15%" align="center">
                        //    </td>
                        //</tr>
                        
                        //<tr>
                        //    <td style="text-align: left;" class="right" width="75">
                        //        <b>合 计</b></td>
                        //    <td colspan="7">
                        //        <span style="text-align: right;">￥1,550.00&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        //            人民币大写：壹仟伍佰伍拾圆零分整 </span>
                        //    </td>
                        //</tr>
        }
    }
}
