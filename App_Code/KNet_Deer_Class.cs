using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace KNet.Common
{
    /// <summary>
    /// dropdown 的摘要说明
    /// </summary>
    public static class KNet_Deer_Class
    {


        #region dropdownlist无限级下拉显示
        /// <summary>
        /// dropdownlist无限级下拉显示
        /// </summary>
        /// <param name="dt">所有的栏目的数据</param>
        /// <param name="cstring1">栏目名字(如name)</param>
        /// <param name="cstring2">栏目的value字段(如id)</param>
        /// <param name="cstring3">父目录排序的字段(如id)</param>
        /// <param name="cstring4">父目录字段名(如parentid)</param>
        /// <param name="big">父目录字段值(一般选0)</param>
        /// <param name="dp">绑定的dropdown控件</param>
        /// <param name="defaluta">是否加入静态项</param>
        public static void dropdownlistshow(DataTable dt, string cstring1, string cstring2, string cstring3, string cstring4, string big, System.Web.UI.WebControls.DropDownList dp, bool defaluta, string defalutaString)
        {
            //是否需要加一个主选则

            if (defaluta)
            {
                dp.Items.Add(new ListItem(defalutaString, "0"));
            }

            //得到根点
            DataRow[] rows = dt.Select(cstring4 + "='" + big + "'", cstring3 + " desc");
            //定义一个数字来表示低归的次数
            int xunhuan = 1;
            for (int i = 0; i < rows.Length; i++)
            {
                dp.Items.Add(new ListItem(rows[i][cstring1].ToString(), rows[i][cstring2].ToString()));
                //从根点循环调用显示节点函数
                dropdownlistchild(dt, cstring1, cstring2, cstring3, cstring4, big, dp, defaluta, rows[i][cstring2].ToString(), xunhuan);
            }
        }


        //列出传递过来所属这个分类的节点（如果这个节点又有小节点那么递归）
        public static void dropdownlistchild(DataTable dt, string cstring1, string cstring2, string cstring3, string cstring4, string big, System.Web.UI.WebControls.DropDownList dp, bool defaluta, string nowid, int cishu)
        {
            DataRow[] rows = dt.Select(cstring4 + "='" + nowid + "'", cstring3 + " desc");//取出id子节点进行绑定

            for (int i = 0; i < rows.Length; i++)
            {

                dp.Items.Add(new ListItem(fuhao(cishu) + rows[i][cstring1].ToString(), rows[i][cstring2].ToString()));
                if ((dt.Select(cstring4 + "='" + rows[i][cstring2].ToString() + "'", cstring3 + " desc")).Length > 0)
                {
                    int jj = cishu + 1;
                    dropdownlistchild(dt, cstring1, cstring2, cstring3, cstring4, big, dp, defaluta, rows[i][cstring2].ToString(), jj);
                }
            }
        }
        //生成下拉符号
        private static string fuhao(int cishu)
        {
            string fuhao = string.Empty;
            for (int i = 0; i < cishu; i++)
            {
                fuhao += "　";
            }
            return fuhao + "└";

        }
        #endregion


        #region  TreeView控件，分类的树目录列表

        //=====================
        /// <summary>
        /// 分类的树目录列表
        /// </summary>
        /// <param name="dt">所有的栏目的数据</param>
        /// <param name="cstring1">栏目名字(如name)</param>
        /// <param name="cstring2">栏目的value字段(如id)</param>
        /// <param name="cstring3">父目录排序的字段(如id)</param>
        /// <param name="cstring4">父目录字段名(如parentid)</param>
        /// <param name="big">父目录字段值(一般选0)</param>
        /// <param name="dp">绑定的dropdown控件</param>
        /// <param name="defaluta">是否加入静态项</param>
        public static void listshow(DataTable dt, string cstring1, string cstring2, string cstring3, string cstring4, string big, System.Web.UI.WebControls.TreeView dp, bool defaluta,string ThisUrlPage)
        {
            //是否需要加一个主选则
            if (defaluta)
            {}
            //得到根点
            DataRow[] rows = dt.Select(cstring4 + "='" + big + "'", cstring3 + " desc");
            //定义一个数字来表示低归的次数
            int xunhuan = 1;
            for (int i = 0; i < rows.Length; i++)
            {
                TreeNode newnote = new TreeNode(rows[i][cstring1].ToString(), rows[i][cstring2].ToString(), "");
                dp.Nodes.Add(newnote);
                newnote.NavigateUrl = ThisUrlPage + "&cid=" + rows[i][cstring2].ToString();
                //从根点循环调用显示节点函数
                dropdownlistchilda(dt, cstring1, cstring2, cstring3, cstring4, big, newnote, defaluta, rows[i][cstring2].ToString(), xunhuan, ThisUrlPage);
            }
        }

        //列出传递过来所属这个分类的节点（如果这个节点又有小节点那么递归）
        public static void dropdownlistchilda(DataTable dt, string cstring1, string cstring2, string cstring3, string cstring4, string big, System.Web.UI.WebControls.TreeNode dp, bool defaluta, string nowid, int cishu,string ThisUrlPage)
        {
            DataRow[] rows = dt.Select(cstring4 + "='" + nowid + "'", cstring3 + " desc");//取出id子节点进行绑定

            for (int i = 0; i < rows.Length; i++)
            {
                TreeNode newnote = new TreeNode(rows[i][cstring1].ToString(), rows[i][cstring2].ToString());
                dp.ChildNodes.Add(newnote);
                newnote.NavigateUrl = ThisUrlPage + "&cid=" + rows[i][cstring2].ToString();
                

                //dp.Items.Add(new ListItem(fuhao(cishu) + rows[i][cstring1].ToString(), rows[i][cstring2].ToString()));
                if ((dt.Select(cstring4 + "='" + rows[i][cstring2].ToString() + "'", cstring3 + " desc")).Length > 0)
                {

                    int jj = cishu + 1;
                    dropdownlistchilda(dt, cstring1, cstring2, cstring3, cstring4, big, newnote, defaluta, rows[i][cstring2].ToString(), jj, ThisUrlPage);
                }
            }
        }

        //====
        #endregion


    }
}


