using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// XS_Compy_LinkMan
    /// </summary>
    public partial class XS_Compy_LinkMan
    {
        private readonly KNet.DAL.XS_Compy_LinkMan dal = new KNet.DAL.XS_Compy_LinkMan();
        public XS_Compy_LinkMan()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string XOL_ID)
        {
            return dal.Exists(XOL_ID);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsLinkMan(string XOL_Name,string XOL_CustomerValue,string XOL_ID)
        {
            return dal.ExistsLinkMan(XOL_Name, XOL_CustomerValue,XOL_ID);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.XS_Compy_LinkMan model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.XS_Compy_LinkMan model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateB(KNet.Model.XS_Compy_LinkMan model)
        {
            return dal.UpdateB(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string XOL_ID)
        {

            return dal.Delete(XOL_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string XOL_IDlist)
        {
            return dal.DeleteList(XOL_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.XS_Compy_LinkMan GetModel(string XOL_ID)
        {

            return dal.GetModel(XOL_ID);
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
        public List<KNet.Model.XS_Compy_LinkMan> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.XS_Compy_LinkMan> DataTableToList(DataTable dt)
        {
            List<KNet.Model.XS_Compy_LinkMan> modelList = new List<KNet.Model.XS_Compy_LinkMan>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.XS_Compy_LinkMan model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.XS_Compy_LinkMan();
                    if (dt.Rows[n]["XOL_ID"] != null && dt.Rows[n]["XOL_ID"].ToString() != "")
                    {
                        model.XOL_ID = dt.Rows[n]["XOL_ID"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Compy"] != null && dt.Rows[n]["XOL_Compy"].ToString() != "")
                    {
                        model.XOL_Compy = dt.Rows[n]["XOL_Compy"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Name"] != null && dt.Rows[n]["XOL_Name"].ToString() != "")
                    {
                        model.XOL_Name = dt.Rows[n]["XOL_Name"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Phone"] != null && dt.Rows[n]["XOL_Phone"].ToString() != "")
                    {
                        model.XOL_Phone = dt.Rows[n]["XOL_Phone"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Mail"] != null && dt.Rows[n]["XOL_Mail"].ToString() != "")
                    {
                        model.XOL_Mail = dt.Rows[n]["XOL_Mail"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Duty"] != null && dt.Rows[n]["XOL_Duty"].ToString() != "")
                    {
                        model.XOL_Duty = dt.Rows[n]["XOL_Duty"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Sex"] != null && dt.Rows[n]["XOL_Sex"].ToString() != "")
                    {
                        model.XOL_Sex = dt.Rows[n]["XOL_Sex"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Age"] != null && dt.Rows[n]["XOL_Age"].ToString() != "")
                    {
                        model.XOL_Age = dt.Rows[n]["XOL_Age"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Birthday"] != null && dt.Rows[n]["XOL_Birthday"].ToString() != "")
                    {
                        model.XOL_Birthday = dt.Rows[n]["XOL_Birthday"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Place"] != null && dt.Rows[n]["XOL_Place"].ToString() != "")
                    {
                        model.XOL_Place = dt.Rows[n]["XOL_Place"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Nation"] != null && dt.Rows[n]["XOL_Nation"].ToString() != "")
                    {
                        model.XOL_Nation = dt.Rows[n]["XOL_Nation"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Marriage"] != null && dt.Rows[n]["XOL_Marriage"].ToString() != "")
                    {
                        model.XOL_Marriage = dt.Rows[n]["XOL_Marriage"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Officephone"] != null && dt.Rows[n]["XOL_Officephone"].ToString() != "")
                    {
                        model.XOL_Officephone = dt.Rows[n]["XOL_Officephone"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Homephone"] != null && dt.Rows[n]["XOL_Homephone"].ToString() != "")
                    {
                        model.XOL_Homephone = dt.Rows[n]["XOL_Homephone"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Fax"] != null && dt.Rows[n]["XOL_Fax"].ToString() != "")
                    {
                        model.XOL_Fax = dt.Rows[n]["XOL_Fax"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Education"] != null && dt.Rows[n]["XOL_Education"].ToString() != "")
                    {
                        model.XOL_Education = dt.Rows[n]["XOL_Education"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Experience"] != null && dt.Rows[n]["XOL_Experience"].ToString() != "")
                    {
                        model.XOL_Experience = dt.Rows[n]["XOL_Experience"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Responsible"] != null && dt.Rows[n]["XOL_Responsible"].ToString() != "")
                    {
                        model.XOL_Responsible = dt.Rows[n]["XOL_Responsible"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Hobby"] != null && dt.Rows[n]["XOL_Hobby"].ToString() != "")
                    {
                        model.XOL_Hobby = dt.Rows[n]["XOL_Hobby"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Address"] != null && dt.Rows[n]["XOL_Address"].ToString() != "")
                    {
                        model.XOL_Address = dt.Rows[n]["XOL_Address"].ToString();
                    }
                    if (dt.Rows[n]["XOL_LogisticsAddress"] != null && dt.Rows[n]["XOL_LogisticsAddress"].ToString() != "")
                    {
                        model.XOL_LogisticsAddress = dt.Rows[n]["XOL_LogisticsAddress"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Evaluation"] != null && dt.Rows[n]["XOL_Evaluation"].ToString() != "")
                    {
                        model.XOL_Evaluation = dt.Rows[n]["XOL_Evaluation"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Remark"] != null && dt.Rows[n]["XOL_Remark"].ToString() != "")
                    {
                        model.XOL_Remark = dt.Rows[n]["XOL_Remark"].ToString();
                    }
                    if (dt.Rows[n]["XOL_Del"] != null && dt.Rows[n]["XOL_Del"].ToString() != "")
                    {
                        model.XOL_Del = int.Parse(dt.Rows[n]["XOL_Del"].ToString());
                    }
                    if (dt.Rows[n]["XOL_CDate"] != null && dt.Rows[n]["XOL_CDate"].ToString() != "")
                    {
                        model.XOL_CDate = DateTime.Parse(dt.Rows[n]["XOL_CDate"].ToString());
                    }
                    if (dt.Rows[n]["XOL_Creator"] != null && dt.Rows[n]["XOL_Creator"].ToString() != "")
                    {
                        model.XOL_Creator = dt.Rows[n]["XOL_Creator"].ToString();
                    }
                    if (dt.Rows[n]["XOL_MDate"] != null && dt.Rows[n]["XOL_MDate"].ToString() != "")
                    {
                        model.XOL_MDate = DateTime.Parse(dt.Rows[n]["XOL_MDate"].ToString());
                    }
                    if (dt.Rows[n]["XOL_Mender"] != null && dt.Rows[n]["XOL_Mender"].ToString() != "")
                    {
                        model.XOL_Mender = dt.Rows[n]["XOL_Mender"].ToString();
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

