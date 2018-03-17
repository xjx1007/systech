using System;
using System.Data;
using System.Collections.Generic;
using KNet.Common;
using KNet.Model;
namespace KNet.BLL
{
    /// <summary>
    /// Pb_Products_Sample
    /// </summary>
    public partial class Pb_Products_Sample
    {
        private readonly KNet.DAL.Pb_Products_Sample dal = new KNet.DAL.Pb_Products_Sample();
        public Pb_Products_Sample()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PPS_ID)
        {
            return dal.Exists(PPS_ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Pb_Products_Sample model)
        {
            KNet.BLL.Pb_Products_Sample_Images Bll_Details=new KNet.BLL.Pb_Products_Sample_Images();
            dal.Add(model);
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.Pb_Products_Sample_Images Model_details = (KNet.Model.Pb_Products_Sample_Images)model.arr_Details[i];
                    Bll_Details.Add(Model_details);
                }
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(KNet.Model.Pb_Products_Sample model)
        {

            KNet.BLL.Pb_Products_Sample_Images Bll_Details = new KNet.BLL.Pb_Products_Sample_Images();
            Bll_Details.Delete(model.PPS_ID,"0");
            if (model.arr_Details != null)
            {
                for (int i = 0; i < model.arr_Details.Count; i++)
                {
                    KNet.Model.Pb_Products_Sample_Images Model_details = (KNet.Model.Pb_Products_Sample_Images)model.arr_Details[i];
                    Bll_Details.Add(Model_details);
                }
            }
            return dal.Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool UpdateDept(KNet.Model.Pb_Products_Sample model)
        {
            return dal.UpdateDept(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string PPS_ID)
        {

            return dal.Delete(PPS_ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PPS_IDlist)
        {
            return dal.DeleteList(PPS_IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Pb_Products_Sample GetModel(string PPS_ID)
        {

            return dal.GetModel(PPS_ID);
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
        public List<KNet.Model.Pb_Products_Sample> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<KNet.Model.Pb_Products_Sample> DataTableToList(DataTable dt)
        {
            List<KNet.Model.Pb_Products_Sample> modelList = new List<KNet.Model.Pb_Products_Sample>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                KNet.Model.Pb_Products_Sample model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new KNet.Model.Pb_Products_Sample();
                    if (dt.Rows[n]["PPS_ID"] != null && dt.Rows[n]["PPS_ID"].ToString() != "")
                    {
                        model.PPS_ID = dt.Rows[n]["PPS_ID"].ToString();
                    }
                    if (dt.Rows[n]["PPS_Name"] != null && dt.Rows[n]["PPS_Name"].ToString() != "")
                    {
                        model.PPS_Name = dt.Rows[n]["PPS_Name"].ToString();
                    }
                    if (dt.Rows[n]["PPS_Stime"] != null && dt.Rows[n]["PPS_Stime"].ToString() != "")
                    {
                        model.PPS_Stime = DateTime.Parse(dt.Rows[n]["PPS_Stime"].ToString());
                    }
                    if (dt.Rows[n]["PPS_Needtime"] != null && dt.Rows[n]["PPS_Needtime"].ToString() != "")
                    {
                        model.PPS_Needtime = DateTime.Parse(dt.Rows[n]["PPS_Needtime"].ToString());
                    }
                    if (dt.Rows[n]["PPS_CustomerValue"] != null && dt.Rows[n]["PPS_CustomerValue"].ToString() != "")
                    {
                        model.PPS_CustomerValue = dt.Rows[n]["PPS_CustomerValue"].ToString();
                    }
                    if (dt.Rows[n]["PPS_LinkMan"] != null && dt.Rows[n]["PPS_LinkMan"].ToString() != "")
                    {
                        model.PPS_LinkMan = dt.Rows[n]["PPS_LinkMan"].ToString();
                    }
                    if (dt.Rows[n]["PPS_DutyPeson"] != null && dt.Rows[n]["PPS_DutyPeson"].ToString() != "")
                    {
                        model.PPS_DutyPeson = dt.Rows[n]["PPS_DutyPeson"].ToString();
                    }
                    if (dt.Rows[n]["PPS_Dept"] != null && dt.Rows[n]["PPS_Dept"].ToString() != "")
                    {
                        model.PPS_Dept = dt.Rows[n]["PPS_Dept"].ToString();
                    }
                    if (dt.Rows[n]["PPS_DemoPicture"] != null && dt.Rows[n]["PPS_DemoPicture"].ToString() != "")
                    {
                        model.PPS_DemoPicture = dt.Rows[n]["PPS_DemoPicture"].ToString();
                    }
                    if (dt.Rows[n]["PPS_Picture"] != null && dt.Rows[n]["PPS_Picture"].ToString() != "")
                    {
                        model.PPS_Picture = dt.Rows[n]["PPS_Picture"].ToString();
                    }
                    if (dt.Rows[n]["PPS_Requirement"] != null && dt.Rows[n]["PPS_Requirement"].ToString() != "")
                    {
                        model.PPS_Requirement = dt.Rows[n]["PPS_Requirement"].ToString();
                    }
                    if (dt.Rows[n]["PPS_Remarks"] != null && dt.Rows[n]["PPS_Remarks"].ToString() != "")
                    {
                        model.PPS_Remarks = dt.Rows[n]["PPS_Remarks"].ToString();
                    }
                    if (dt.Rows[n]["PPS_CTime"] != null && dt.Rows[n]["PPS_CTime"].ToString() != "")
                    {
                        model.PPS_CTime = DateTime.Parse(dt.Rows[n]["PPS_CTime"].ToString());
                    }
                    if (dt.Rows[n]["PPS_Creator"] != null && dt.Rows[n]["PPS_Creator"].ToString() != "")
                    {
                        model.PPS_Creator = dt.Rows[n]["PPS_Creator"].ToString();
                    }
                    if (dt.Rows[n]["PPS_MTime"] != null && dt.Rows[n]["PPS_MTime"].ToString() != "")
                    {
                        model.PPS_MTime = DateTime.Parse(dt.Rows[n]["PPS_MTime"].ToString());
                    }
                    if (dt.Rows[n]["PPS_Mender"] != null && dt.Rows[n]["PPS_Mender"].ToString() != "")
                    {
                        model.PPS_Mender = dt.Rows[n]["PPS_Mender"].ToString();
                    }
                    if (dt.Rows[n]["PPS_Del"] != null && dt.Rows[n]["PPS_Del"].ToString() != "")
                    {
                        model.PPS_Del = int.Parse(dt.Rows[n]["PPS_Del"].ToString());
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

