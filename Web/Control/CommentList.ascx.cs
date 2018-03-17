using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;
using System.Data;

public partial class Web_Control_CommentList : UserControl
{
    private string _CommentFID = "";
    private int _CommentType = 0;

    public string CommentFID
    {
        get { return _CommentFID; }
        set { _CommentFID = value; }
    }    

    public int CommentType
    {
        get { return _CommentType; }
        set { _CommentType = value; }
    }

    public string GetUserName(string FromPerson)
    {
        BasePage page = new BasePage();
        return page.Base_GetUserName(FromPerson);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        // 隐藏域——被新增点评按钮事件 btnGetReturnValue_onclick（） 调用
        this.hidCommentFID.Value = CommentFID.ToString();
        this.hidCommentType.Value = this.CommentType.ToString();

        KNet.BLL.PB_Basic_Comment bllComment = new KNet.BLL.PB_Basic_Comment();
        string SqlWhere = "";
       if (CommentFID != "" )
        {
            SqlWhere = " PBC_FID='" + CommentFID + "' AND PBC_Type='" + CommentType + "' order by PBC_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();
            this.Btn_Create.Enabled = true;
        }
        else
        {
            this.Btn_Create.Enabled = false;
            SqlWhere = " PBC_FID='" + CommentFID + "' AND PBC_Type='" + CommentType + "' order by PBC_CTime desc";
            DataSet ds_Comment = bllComment.GetList(SqlWhere);
            GridView_Comment.DataSource = ds_Comment.Tables[0];
            GridView_Comment.DataBind();

        }
    }
}