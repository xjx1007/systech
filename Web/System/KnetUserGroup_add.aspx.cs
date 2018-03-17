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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;


/// <summary>
/// 仓库管理
/// </summary>
public partial class Knet_Web_System_KnetUserGroup_add : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("用户组权限设置") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
        }

    }

    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string GroupValue = DateTime.Now.ToFileTimeUtc().ToString();
        string GroupName = KNetPage.KHtmlEncode(this.GroupName.Text.Trim());


        int GroupPai = 10;
        if (KNetPage.IsNumber(this.GroupPai.Text.ToString()) == true)
        {
            GroupPai = int.Parse(this.GroupPai.Text.ToString());
        }

        KNet.BLL.KNet_Sys_AuthorityUserGroup BLL = new KNet.BLL.KNet_Sys_AuthorityUserGroup();
        KNet.Model.KNet_Sys_AuthorityUserGroup model = new KNet.Model.KNet_Sys_AuthorityUserGroup();

        model.GroupValue = GroupValue;
        model.GroupName = GroupName;
        model.GroupPai = GroupPai;


        try
        {
            if (BLL.Exists(GroupName) == false)
            {
                BLL.Add(model);

                AdminloginMess LogAM = new AdminloginMess();
                LogAM.Add_Logs("系统管理--->用户组及权限--->用户组  添加 操作成功！用户组名称：" + GroupName);

                Response.Write("<script>alert('用户组 添加 成功！');location.href='KnetUserGroup.aspx';</script>");
                Response.End();
            }
            else
            {
                Response.Write("<script>alert('用户组 添加 失败（用户组名称已存在）！');history.back(-1);</script>");
                Response.End();
            }
        }
        catch
        {
            Response.Write("<script>alert('用户组 添加 失败！');history.back(-1);</script>");
            Response.End();
        }
    }
}
