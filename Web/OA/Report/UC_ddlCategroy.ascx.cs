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
using KNet.DBUtility;
using KNet.Common;
using System.Data.SqlClient;
using System.Text;

public partial class Web_OA_Report_UC_ddlCategroy : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM=new AdminloginMess();
            DataTable datatable = this.GetDataTable(AM.KNet_StaffNo);
            if (datatable.Rows.Count > 0)
            {
                //this.ddlCategory.Items.Add("全部分类");
                this.ddlCategory.Items.Add(new ListItem(AM.KNet_StaffName, AM.KNet_StaffNo));
                foreach (DataRow row in datatable.Rows)
                {
                    string name = row["StaffName"].ToString();
                    if (row["StaffNo"].ToString()!= AM.KNet_StaffNo)
                    {
                        this.ddlCategory.Items.Add(new ListItem(row["StaffName"].ToString(), row["StaffNo"].ToString()));
                    }
                    else
                    {
                        
                    } 
                        //addSonCategory(string.Empty, row["StaffNo"].ToString(), datatable, 1);
                    if (row["StaffNo"].ToString()!= AM.KNet_StaffNo)
                    {
                        addSonCategory(string.Empty, row["StaffNo"].ToString(), 1);
                    }
                    else
                    {
                        
                    }   
                   
                }
            }
        }
    }

    /// <summary>
    /// 添加子节点
    /// </summary>
    /// <param name="strPading">空格</param>
    /// <param name="DirId">父路径ID</param>
    /// <param name="datatable">返回的datatable</param>
    /// <param name="deep">树形的深度</param>
    private void addSonCategory(string strPading, string s_FID,int deep)
    {
        //DataRow[] rowlist = datatable.Select("StaffNo='" + id + "'");
        KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
        string s_SonID = Bll.GetSonIDs1(s_FID);
        s_SonID = s_SonID.Replace(",", "','");
        string SqlWhere = " and StaffNo in ('" + s_SonID + "') ";
        DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' " + SqlWhere + " Order By StaffDepart ");
        if (Dts_Table.Tables[0].Rows.Count>=1&& s_FID!= Dts_Table.Tables[0].Rows[0]["StaffNo"].ToString())
        {
            foreach (DataRow row in Dts_Table.Tables[0].Rows)
            {
                string name = row["StaffName"].ToString();
                strPading = string.Empty;
                for (int j = 0; j < deep; j++)
                {
                    strPading += "　";  //用全角的空格（智能abc输入法状态下的v11字符）
                }
                // 添加节点
                ListItem li = new ListItem(strPading + "|--" + row["StaffName"].ToString(), row["StaffNo"].ToString());
                this.ddlCategory.Items.Add(li);
                // 递归调用addSonCategory函数，在函数中把deep加1
                addSonCategory(strPading, row["StaffNo"].ToString(), deep + 1);
            }
        }
        else
        {
            
        }
        
    }

    /// <summary>
    /// 从数据库中读取数据返回datatable
    /// </summary>
    /// <returns></returns>
    private DataTable GetDataTable(string s_FID)
    {
        KNet.BLL.KNet_Resource_Staff Bll = new KNet.BLL.KNet_Resource_Staff();
        string s_SonID = Bll.GetSonIDs1(s_FID);
        s_SonID = s_SonID.Replace(",", "','");
        string SqlWhere = " and StaffNo in ('" + s_SonID + "') ";
        DataSet Dts_Table = Bll.GetList(" StaffNo<>'admin' " + SqlWhere + " Order By StaffDepart ");
       
        return Dts_Table.Tables[0];
    }

    /// <summary>
    /// SelectedValue属性（暴露给外部使用）
    /// 只有Get方法，没有Set方法，保证只读
    /// </summary>
    public string SelectedValue
    {
        get
        {
            string strSelectedValue = this.ddlCategory.SelectedValue;

            if (strSelectedValue.Contains("　") && (strSelectedValue.Contains("|--")))
            { // 如果是子类别
                int iStartIndex = strSelectedValue.LastIndexOf("|--") + 3;               // 字符串截取的起始位置
                strSelectedValue = strSelectedValue.Substring(iStartIndex);
            }

            return strSelectedValue;
        }
    }
}
