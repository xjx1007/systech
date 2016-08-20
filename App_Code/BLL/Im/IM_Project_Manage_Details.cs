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
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// IM_Project_Manage_Details
    /// </summary>
    public partial class IM_Project_Manage_Details
    {
        private readonly KNet.DAL.IM_Project_Manage_Details dal = new KNet.DAL.IM_Project_Manage_Details();
        public IM_Project_Manage_Details()
        { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string IPMD_ID)
        {
            return dal.Exists(IPMD_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(KNet.Model.IM_Project_Manage_Details model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Load(string s_TID,string s_ID)
        {
            return dal.Load(s_TID,s_ID);
            
        }
        /// <summary>
        /// 修改一条数据
        /// </summary>
        public bool Update(KNet.Model.IM_Project_Manage_Details model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string IPMD_ID)
        {
            return dal.Delete(IPMD_ID);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public bool UpdateDel(KNet.Model.IM_Project_Manage_Details model)
        {
            return dal.UpdateDel(model);
        }
        /// <summary>
        /// 批量删除一条数据
        /// </summary>
        public bool DeleteList(string IPMD_ID)
        {
            return dal.DeleteList(IPMD_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public bool DeleteByFID(string IPMD_ID)
        {
            return dal.DeleteByFID(IPMD_ID);
        }
        /// <summary>
        ///删除父节点数据
        /// </summary>
        public KNet.Model.IM_Project_Manage_Details GetModel(string IPMD_ID)
        {
            return dal.GetModel(IPMD_ID);
        }
        /// <summary>
        ///获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        public void BindDrop(DropDownList Ddl_Drop,string s_FID,string s_Type)
        {
            string s_SqlWhere = "1=1";
            if (s_FID != "")
            {
                s_SqlWhere += " and IPMD_IPMID='" + s_FID + "'";
            }
            if (s_Type != "")
            {
                 s_SqlWhere+=" and IPMD_Type='" + s_Type + "'";
            }

            DataSet Dts_Table = dal.GetList(s_SqlWhere);
            Ddl_Drop.DataSource = Dts_Table;
            Ddl_Drop.DataTextField = "IPMD_Name";
            Ddl_Drop.DataValueField = "IPMD_ID";
            Ddl_Drop.DataBind();
            ListItem item = new ListItem("------", ""); //默认值
            Ddl_Drop.Items.Insert(0, item);

        }
    }
}
