using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using KNet.DBUtility;

namespace KNet.Common
{
    /// <summary>
    /// dropdown 的摘要说明
    /// </summary>
    public static class dropdown
    {
        
        #region 分类的树目录列表
        //=====================
        /// <summary>
        /// 分类的树目录列表
        /// </summary>
        /// <param name="dt">数据源</param>
        /// <param name="cstring1">栏目名称（StrucName）</param>
        /// <param name="cstring2">栏目唯一值（StrucValue）</param>
        /// <param name="cstring3">父目录排序的字段（StrucPai）</param>
        /// <param name="cstring4">父目录字段名（StrucPID）</param>
        /// <param name="big">父目录字段值（一般选0）</param>
        /// <param name="dp">绑定的dropdown控件</param>
        /// <param name="defaluta">是否加入静态项</param>
        public static void listshow(DataTable dt, string cstring1, string cstring2, string cstring3, string cstring4, string big, System.Web.UI.WebControls.TreeView dp, bool defaluta)
        {

            //是否需要加一个主选则

            if (defaluta)
            {
                AdminloginMess AM = new AdminloginMess();

                TreeNode newnote = new TreeNode("<B>"+AM.KNet_Sys_CompanyName+"</B>", "0");
                dp.Nodes.Add(newnote);
            }

            //得到根点
            DataRow[] rows = dt.Select(cstring4 + "='" + big + "'", cstring3 + " desc");
            //定义一个数字来表示低归的次数
            int xunhuan = 1;
            for (int i = 0; i < rows.Length; i++)
            {
                    TreeNode newnote = new TreeNode(rows[i][cstring1].ToString(), rows[i][cstring2].ToString(), "");
                    dp.Nodes.Add(newnote);
                    dropdownlistchilda(dt, cstring1, cstring2, cstring3, cstring4, big, newnote, defaluta, rows[i][cstring2].ToString(), xunhuan);
            }
        }

        //列出传递过来所属这个分类的节点（如果这个节点又有小节点那么递归）
        public static void dropdownlistchilda(DataTable dt, string cstring1, string cstring2, string cstring3, string cstring4, string big, System.Web.UI.WebControls.TreeNode dp, bool defaluta, string nowid, int cishu)
        {
            DataRow[] rows = dt.Select(cstring4 + "='" + nowid + "'", cstring3 + " desc");//取出id子节点进行绑定

            for (int i = 0; i < rows.Length; i++)
            {
                TreeNode newnote = new TreeNode(rows[i][cstring1].ToString(), rows[i][cstring2].ToString());
                dp.ChildNodes.Add(newnote);
                if ((dt.Select(cstring4 + "='" + rows[i][cstring2].ToString() + "'", cstring3 + " desc")).Length > 0)
                {

                    int jj = cishu + 1;
                    dropdownlistchilda(dt, cstring1, cstring2, cstring3, cstring4, big, newnote, defaluta, rows[i][cstring2].ToString(), jj);
                }
            }
        }

        //====
        #endregion


    }
}


