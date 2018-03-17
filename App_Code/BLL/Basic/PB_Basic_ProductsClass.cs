using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// PB_Basic_ProductsClass
    /// </summary>
    public partial class PB_Basic_ProductsClass
    {
        private readonly KNet.DAL.PB_Basic_ProductsClass dal = new KNet.DAL.PB_Basic_ProductsClass();
        public PB_Basic_ProductsClass()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PBP_ID)
        {
            return dal.Exists(PBP_ID);
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
                    s_Return += "<a href='Pb_Basic_ProductsClass_Add.aspx?ID=1&Type=M'>\n";
                    s_Return += "<img src='../../themes/softed/images/Rolesadd.gif' align='absmiddle' border='0' alt='添加分类'title='添加分类'  target=\"_blank\"></a>\n";
                    s_Return += "<a href='Pb_Basic_ProductsClass_Add.aspx?ID=1' target=\"_blank\">\n";
                    s_Return += "<img src='../../themes/softed/images/RolesEdit.gif' align='absmiddle' border='0' alt='编辑分类'title='编辑分类'></a>\n";
                    s_Return += "<a href='Pb_Basic_ProductsClass_Add.aspx?ID=1&Type=D' target=\"_blank\">\n";
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
        public string bindTree(string s_PID,int i_Type)
        {
            string s_Tree = "";
            try
            {
                if (s_PID != "")
                {
                    DataSet Dts_Table = GetList(" PBP_FaterID='" + s_PID + "' Order by cast (PBP_Order as int) ");//
                    if (Dts_Table.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < Dts_Table.Tables[0].Rows.Count; i++)
                        {
                            string s_ID = Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString();
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
                                s_Tree += " <a href=\"javascript:;\" class=\"x\" id=\"user_H" + s_PID + "\">" + Dts_Table.Tables[0].Rows[i]["PBP_Name"].ToString()+" ("+Dts_Table.Tables[0].Rows[i]["PBP_Code"].ToString()+")" + "</a>\n";
                           
                            }
                            else
                            {
                                s_Tree += " <a href=\"KnetProductsSetting.aspx?ProductsClass="+s_ID+"\" class=\"x\" id=\"user_H" + s_PID + "\">" + Dts_Table.Tables[0].Rows[i]["PBP_Name"].ToString()+" ("+Dts_Table.Tables[0].Rows[i]["PBP_Code"].ToString()+")" + "</a>\n";
                           
                            }
                            s_Tree += "</td>\n";
                            s_Tree += "<td nowrap>\n";

                            s_Tree += "<div id=\"layer_H" + s_ID + "\" class=\"drag_Element\">\n";
                            if (i_Type == 0)
                            {
                                s_Tree += "<a href='Pb_Basic_ProductsClass_Add.aspx?ID=" + s_ID + "&Type=M'>\n";
                                s_Tree += "<img src='../../themes/softed/images/Rolesadd.gif' align='absmiddle' border='0' alt='添加分类'title='添加分类'></a>\n";
                                s_Tree += "<a href='Pb_Basic_ProductsClass_Add.aspx?ID=" + s_ID + "'>\n";
                                s_Tree += "<img src='../../themes/softed/images/RolesEdit.gif' align='absmiddle' border='0' alt='编辑分类'title='编辑分类'></a>\n";
                                s_Tree += "<a href='Pb_Basic_ProductsClass_Add.aspx?ID=" + s_ID + "&Type=D'>\n";
                                s_Tree += "<img src='../../themes/softed/images/RolesDelete.gif' align='absmiddle' border='0' alt='删除分类'title='删除分类'></a>\n";
                            } 
                            s_Tree += "</div>\n";
                            s_Tree += " </td>\n</tr></table></li>";
                            s_Tree += bindTree(Dts_Table.Tables[0].Rows[i]["PBP_ID"].ToString(),i_Type);
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

        /// <summary>
        /// 是否有子项
        /// </summary>
        public bool ExistsFaterID(string PBP_ID)
        {
            return dal.ExistsFaterID(PBP_ID);
        }
        /// 得到子项的ID
        /// </summary>
        public string GetSonID(string PBP_ID,int i_Type)
        {
            return dal.GetSonID(PBP_ID, i_Type);
        }
        /// 得到全部子项的ID
        /// </summary>
        public string GetSonIDs(string PBP_ID)
        {
            return dal.GetSonIDs(PBP_ID);
        }
        /// 得到全部子项的ID
        /// </summary>
        public string GetSonIDss(string PBP_ID)
        {
            return dal.GetSonIDss(PBP_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.PB_Basic_ProductsClass model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.PB_Basic_ProductsClass model)
        {
            return dal.Update(model);
        }

        public string GetProductsName(string s_ID)
        {
            return dal.GetProductsName(s_ID);
        }
        /// <summary>
        /// 得到最大编码
        /// </summary>
        public string GetMaxCode(string s_ID)
        {
            return dal.GetMaxCode(s_ID);
        }
        /// <summary>
        /// 得到最大序号
        /// </summary>
        public string GetMaxOrder(string s_ID)
        {
            return dal.GetMaxOrder(s_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PBP_ID)
        {

            return dal.Delete(PBP_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PBP_IDlist)
        {
            return dal.DeleteList(PBP_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.PB_Basic_ProductsClass GetModel(string PBP_ID)
        {

            return dal.GetModel(PBP_ID);
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
        public List<KNet.Model.PB_Basic_ProductsClass> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.PB_Basic_ProductsClass> DataTableToList(DataTable dt)
        {
            List<KNet.Model.PB_Basic_ProductsClass> modelList = new List<KNet.Model.PB_Basic_ProductsClass>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.PB_Basic_ProductsClass model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.PB_Basic_ProductsClass();
                    if (dt.Rows[n]["PBP_ID"] != null && dt.Rows[n]["PBP_ID"].ToString() != "")
                    {
                        model.PBP_ID = dt.Rows[n]["PBP_ID"].ToString();
                    }
                    if (dt.Rows[n]["PBP_Code"] != null && dt.Rows[n]["PBP_Code"].ToString() != "")
                    {
                        model.PBP_Code = dt.Rows[n]["PBP_Code"].ToString();
                    }
                    if (dt.Rows[n]["PBP_Name"] != null && dt.Rows[n]["PBP_Name"].ToString() != "")
                    {
                        model.PBP_Name = dt.Rows[n]["PBP_Name"].ToString();
                    }
                    if (dt.Rows[n]["PBP_FaterID"] != null && dt.Rows[n]["PBP_FaterID"].ToString() != "")
                    {
                        model.PBP_FaterID = dt.Rows[n]["PBP_FaterID"].ToString();
                    }
                    if (dt.Rows[n]["PBP_Order"] != null && dt.Rows[n]["PBP_Order"].ToString() != "")
                    {
                        model.PBP_Order = int.Parse(dt.Rows[n]["PBP_Order"].ToString());
                    }
                    if (dt.Rows[n]["PBP_Creator"] != null && dt.Rows[n]["PBP_Creator"].ToString() != "")
                    {
                        model.PBP_Creator = dt.Rows[n]["PBP_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PBP_CTime"] != null && dt.Rows[n]["PBP_CTime"].ToString() != "")
                    {
                        model.PBP_CTime = DateTime.Parse(dt.Rows[n]["PBP_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PBP_MTime"] != null && dt.Rows[n]["PBP_MTime"].ToString() != "")
                    {
                        model.PBP_MTime = DateTime.Parse(dt.Rows[n]["PBP_MTime"].ToString());
                    }
                    if (dt.Rows[n]["PBP_Mender"] != null && dt.Rows[n]["PBP_Mender"].ToString() != "")
                    {
                        model.PBP_Mender = dt.Rows[n]["PBP_Mender"].ToString();
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

