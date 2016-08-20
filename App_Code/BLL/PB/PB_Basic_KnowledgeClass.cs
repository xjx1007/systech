using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_KnowledgeClass
    /// </summary>
    public partial class PB_Basic_KnowledgeClass
    {
        private readonly KNet.DAL.PB_Basic_KnowledgeClass dal = new KNet.DAL.PB_Basic_KnowledgeClass();
        public PB_Basic_KnowledgeClass()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBK_ID)
        {
            return dal.Exists(PBK_ID);
        }
        public string GetKnowledgeName(string PBK_ID)
        {
            return dal.GetKnowledgeName(PBK_ID);
        }
        public string GetMaxCode(string PBK_ID)
        {
            return dal.GetMaxCode(PBK_ID);
        }
        public string GetMaxOrder(string PBK_ID)
        {
            return dal.GetMaxOrder(PBK_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public string GetTypeName(string PKM_ID)
        {
            return dal.GetTypeName(PKM_ID);
        }
        public string BuildTree(int i_Type)
        {
            string s_Return = "";
            try
            {
                s_Return += "<ul class=\"ui0l\" id=\"H\" style=\"display: block; list-style-type: none;\">\n";
                s_Return += "<li style=\"margin-top: -5px;\">\n";
                s_Return += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" onmouseover=\"fnVisible('layer_H')\" onmouseout=\"fnInVisible('layer_H')\">\n";
                s_Return += "<tr>\n";
                s_Return += "<td nowrap>\n";
                s_Return += "<img src=\"../../themes/softed/images/base.gif\" id=\"img_H\" border=\"0\" alt=\"根目录\" title=\"根目录\" align=\"absmiddle\">&nbsp; <b class=\"genHeaderGray\">根目录</b>\n";

                s_Return += "</td>\n";
                s_Return += "<td nowrap>\n";
                s_Return += "<div id=\"layer_H\" class=\"drag_Element\">\n";
                if (i_Type == 0)
                {
                    s_Return += "<a href='PB_Basic_KnowledgeClass_Add.aspx?ID=1'>\n";
                    s_Return += "<img src='../../themes/softed/images/Rolesadd.gif' align='absmiddle' border='0' alt='添加分类'title='添加分类'></a>\n";
                    s_Return += "<a href='PB_Basic_KnowledgeClass_Add.aspx?ID=1&Type=M'>\n";
                    s_Return += "<img src='../../themes/softed/images/RolesEdit.gif' align='absmiddle' border='0' alt='编辑分类'title='编辑分类'></a>\n";
                    s_Return += "<a href='PB_Basic_KnowledgeClass_Add.aspx?ID=1&Type=D'>\n";
                    s_Return += "<img src='../../themes/softed/images/RolesDelete.gif' align='absmiddle' border='0' alt='删除分类'title='删除分类'></a>\n";
                }
                s_Return += "</div>\n";
                s_Return += "</td>\n";
                s_Return += "</tr></table></li>\n";
                s_Return += bindTree("1", i_Type);
                s_Return += "</ul>\n";
            }
            catch
            { }
            return s_Return;
        }
        public string bindTree(string s_PID, int i_Type)
        {
            string s_Tree = "";
            try
            {
                if (s_PID != "")
                {
                    DataSet Dts_Table = GetList(" PBK_FaterID='" + s_PID + "' Order by cast (PBK_Order as int) ");//
                    if (Dts_Table.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                        {
                            string s_ID = Dts_Table.Tables[0].Rows[i]["PBK_ID"].ToString();
                            s_Tree += "<ul class=\"uil\" id=\"H" + s_ID + "\" style=\"display: ";
                            if (s_PID == "1")
                            {
                                s_Tree += "block";
                            }
                            else
                            {
                                if (i_Type == 0)
                                {

                                    s_Tree += "block";
                                }
                                else
                                {

                                    s_Tree += "none";
                                }
                            }
                            //if (ExistsFaterID(s_ID))
                            //{
                            //}
                            //else
                            //{
                            //    s_Tree += "none";
                            //}
                            s_Tree += "; list-style-type: none;\">";
                            s_Tree += "<li style=\"margin-top: -5px;\">\n";
                            s_Tree += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" onmouseover=\"fnVisible('layer_H" + s_ID + "')\" onmouseout=\"fnInVisible('layer_H" + s_ID + "')\">\n";
                            s_Tree += "<tr>\n";
                            s_Tree += "<td nowrap>\n";
                            if (ExistsFaterID(s_ID))
                            {

                                if (i_Type == 0)
                                {
                                    s_Tree += "<img src=\"../../themes/softed/images/minus.gif\" id=\"img_" + s_ID + "\" border=\"0\"  alt=\"展开/收缩\" title=\"展开/收缩\" align=\"absmiddle\" onClick=\"showhide('" + GetSonID(s_ID, 0) + "','img_" + s_ID + "')\" style=\"cursor:pointer;\"> <img  id=\"img_" + s_ID + "_dir\" src=\"../../themes/softed/images/";
                                    s_Tree += "folderopen.gif";
                                }
                                else
                                {
                                    s_Tree += "<img src=\"../../themes/softed/images/plus.gif\" id=\"img_" + s_ID + "\" border=\"0\"  alt=\"展开/收缩\" title=\"展开/收缩\" align=\"absmiddle\" onClick=\"showhide('" + GetSonID(s_ID, 0) + "','img_" + s_ID + "')\" style=\"cursor:pointer;\"> <img  id=\"img_" + s_ID + "_dir\" src=\"../../themes/softed/images/";
                                    s_Tree += "folder.gif";
                                }
                            }
                            else
                            {
                                s_Tree += "<img src=\"../../themes/softed/images/";

                                s_Tree += "page.gif";

                            }

                            s_Tree += "\" id=\"img_H" + s_ID + "\" border=\"0\" >&nbsp;";
                            if (i_Type == 0)
                            {
                                s_Tree += " <a href=\"javascript:;\" class=\"x\" id=\"user_H" + s_PID + "\">" + Dts_Table.Tables[0].Rows[i]["PBK_Name"].ToString() + " (" + Dts_Table.Tables[0].Rows[i]["PBK_Code"].ToString() + ")" + "</a>\n";

                            }
                            else
                            {
                                s_Tree += " <a href=\"KnetProductsSetting.aspx?ProductsClass=" + s_ID + "\" class=\"x\" id=\"user_H" + s_PID + "\">" + Dts_Table.Tables[0].Rows[i]["PBK_Name"].ToString() + " (" + Dts_Table.Tables[0].Rows[i]["PBK_Code"].ToString() + ")" + "</a>\n";

                            }
                            s_Tree += "</td>\n";
                            s_Tree += "<td nowrap>\n";

                            s_Tree += "<div id=\"layer_H" + s_ID + "\" class=\"drag_Element\">\n";
                            if (i_Type == 0)
                            {
                                s_Tree += "<a href='PB_Basic_KnowledgeClass_Add.aspx?ID=" + s_ID + "'>\n";
                                s_Tree += "<img src='../../themes/softed/images/Rolesadd.gif' align='absmiddle' border='0' alt='添加分类'title='添加分类'></a>\n";
                                s_Tree += "<a href='PB_Basic_KnowledgeClass_Add.aspx?ID=" + s_ID + "&Type=M'>\n";
                                s_Tree += "<img src='../../themes/softed/images/RolesEdit.gif' align='absmiddle' border='0' alt='编辑分类'title='编辑分类'></a>\n";
                                s_Tree += "<a href='PB_Basic_KnowledgeClass_Add.aspx?ID=" + s_ID + "&Type=D'>\n";
                                s_Tree += "<img src='../../themes/softed/images/RolesDelete.gif' align='absmiddle' border='0' alt='删除分类'title='删除分类'></a>\n";
                            }
                            s_Tree += "</div>\n";
                            s_Tree += " </td>\n</tr></table></li>";
                            s_Tree += bindTree(Dts_Table.Tables[0].Rows[i]["PBK_ID"].ToString(), i_Type);
                            s_Tree += "</ul>";
                        }

                    }

                }
                else
                {
                    s_Tree = "";
                }
            }
            catch
            { }
            return s_Tree;

        }
        public bool ExistsFaterID(string PBK_ID)
        {
            return dal.ExistsFaterID(PBK_ID);
        }

        /// 得到子项的ID
        /// </summary>
        public string GetSonID(string PBP_ID, int i_Type)
        {
            return dal.GetSonID(PBP_ID, i_Type);
        }
        /// 得到全部子项的ID
        /// </summary>
        public string GetSonIDs(string PBP_ID)
        {
            return dal.GetSonIDs(PBP_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_KnowledgeClass model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_KnowledgeClass model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBK_ID)
        {

            return dal.Delete(PBK_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBK_IDlist)
        {
            return dal.DeleteList(PBK_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_KnowledgeClass GetModel(string PBK_ID)
        {

            return dal.GetModel(PBK_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_KnowledgeClass> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_KnowledgeClass> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_KnowledgeClass> modelList = new List<KNet.Model.PB_Basic_KnowledgeClass>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_KnowledgeClass model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_KnowledgeClass();
                    if (dt.Rows[n]["PBK_ID"] != null && dt.Rows[n]["PBK_ID"].ToString() != "")
                    {
                        model.PBK_ID = dt.Rows[n]["PBK_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBK_Code"] != null && dt.Rows[n]["PBK_Code"].ToString() != "")
                    {
                        model.PBK_Code = dt.Rows[n]["PBK_Code"].ToString();
                    }
                    if (dt.Rows[n]["PBK_Name"] != null && dt.Rows[n]["PBK_Name"].ToString() != "")
                    {
                        model.PBK_Name = dt.Rows[n]["PBK_Name"].ToString();
                    }
                    if (dt.Rows[n]["PBK_FaterID"] != null && dt.Rows[n]["PBK_FaterID"].ToString() != "")
                    {
                        model.PBK_FaterID = dt.Rows[n]["PBK_FaterID"].ToString();
                    }
                    if (dt.Rows[n]["PBK_Order"] != null && dt.Rows[n]["PBK_Order"].ToString() != "")
                    {
                        model.PBK_Order = dt.Rows[n]["PBK_Order"].ToString();
                    }
                    if (dt.Rows[n]["PBK_Creator"] != null && dt.Rows[n]["PBK_Creator"].ToString() != "")
                    {
                        model.PBK_Creator = dt.Rows[n]["PBK_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PBK_CTime"] != null && dt.Rows[n]["PBK_CTime"].ToString() != "")
                    {
                        model.PBK_CTime = DateTime.Parse(dt.Rows[n]["PBK_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PBK_MTime"] != null && dt.Rows[n]["PBK_MTime"].ToString() != "")
                    {
                        model.PBK_MTime = DateTime.Parse(dt.Rows[n]["PBK_MTime"].ToString());
                    }
                    if (dt.Rows[n]["PBK_Mender"] != null && dt.Rows[n]["PBK_Mender"].ToString() != "")
                    {
                        model.PBK_Mender = dt.Rows[n]["PBK_Mender"].ToString();
                    }
                    if (dt.Rows[n]["PBK_Days"] != null && dt.Rows[n]["PBK_Days"].ToString() != "")
                    {
                        model.PBK_Days = int.Parse(dt.Rows[n]["PBK_Days"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

