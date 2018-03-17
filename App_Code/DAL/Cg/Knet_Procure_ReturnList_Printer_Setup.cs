using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;

namespace KNet.DAL
{
    /// <summary>
    /// 数据访问类Knet_Procure_ReturnList_Printer_Setup。
    /// </summary>
    public class Knet_Procure_ReturnList_Printer_Setup
    {
        public Knet_Procure_ReturnList_Printer_Setup()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string PrinterTitle)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@PrinterTitle", SqlDbType.NVarChar,50)};
            parameters[0].Value = PrinterTitle;

            int result = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Printer_Setup_Exists", parameters, out rowsAffected);
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_ReturnList_Printer_Setup model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					
					new SqlParameter("@Tex_ID", SqlDbType.NVarChar,50),
					new SqlParameter("@PrinterTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@PrinterYN", SqlDbType.Bit,1),
					new SqlParameter("@PrinterDatetime", SqlDbType.DateTime),
					new SqlParameter("@TopComtont", SqlDbType.NText),
					new SqlParameter("@BotComtont", SqlDbType.NText),
					new SqlParameter("@PrintStatShow", SqlDbType.Bit,1),
					new SqlParameter("@PrintAmount_Recodor", SqlDbType.Bit,1),
					new SqlParameter("@PrintAmount_Sum", SqlDbType.Bit,1),
					new SqlParameter("@PrintDiscount_Sum", SqlDbType.Bit,1),
					new SqlParameter("@PrintTotalNet_Sum", SqlDbType.Bit,1),
					new SqlParameter("@PrintTotalNet_BigWrite", SqlDbType.Bit,1)};

           
            parameters[0].Value = model.Tex_ID;
            parameters[1].Value = model.PrinterTitle;
            parameters[2].Value = model.PrinterYN;
            parameters[3].Value = model.PrinterDatetime;
            parameters[4].Value = model.TopComtont;
            parameters[5].Value = model.BotComtont;
            parameters[6].Value = model.PrintStatShow;
            parameters[7].Value = model.PrintAmount_Recodor;
            parameters[8].Value = model.PrintAmount_Sum;
            parameters[9].Value = model.PrintDiscount_Sum;
            parameters[10].Value = model.PrintTotalNet_Sum;
            parameters[11].Value = model.PrintTotalNet_BigWrite;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Printer_Setup_ADD", parameters, out rowsAffected);
        }

        /// <summary>
        ///  更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_ReturnList_Printer_Setup model)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50),
					
					new SqlParameter("@PrinterTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@PrinterYN", SqlDbType.Bit,1),
					new SqlParameter("@PrinterDatetime", SqlDbType.DateTime),
					new SqlParameter("@TopComtont", SqlDbType.NText),
					new SqlParameter("@BotComtont", SqlDbType.NText),
					new SqlParameter("@PrintStatShow", SqlDbType.Bit,1),
					new SqlParameter("@PrintAmount_Recodor", SqlDbType.Bit,1),
					new SqlParameter("@PrintAmount_Sum", SqlDbType.Bit,1),
					new SqlParameter("@PrintDiscount_Sum", SqlDbType.Bit,1),
					new SqlParameter("@PrintTotalNet_Sum", SqlDbType.Bit,1),
					new SqlParameter("@PrintTotalNet_BigWrite", SqlDbType.Bit,1)};

            parameters[0].Value = model.ID;
           
            parameters[1].Value = model.PrinterTitle;
            parameters[2].Value = model.PrinterYN;
            parameters[3].Value = model.PrinterDatetime;
            parameters[4].Value = model.TopComtont;
            parameters[5].Value = model.BotComtont;
            parameters[6].Value = model.PrintStatShow;
            parameters[7].Value = model.PrintAmount_Recodor;
            parameters[8].Value = model.PrintAmount_Sum;
            parameters[9].Value = model.PrintDiscount_Sum;
            parameters[10].Value = model.PrintTotalNet_Sum;
            parameters[11].Value = model.PrintTotalNet_BigWrite;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Printer_Setup_Update", parameters, out rowsAffected);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string ID)
        {
            int rowsAffected;
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Printer_Setup_Delete", parameters, out rowsAffected);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReturnList_Printer_Setup GetModel(string ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;

            KNet.Model.Knet_Procure_ReturnList_Printer_Setup model = new KNet.Model.Knet_Procure_ReturnList_Printer_Setup();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Printer_Setup_GetModelByID", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.Tex_ID = ds.Tables[0].Rows[0]["Tex_ID"].ToString();
                model.PrinterTitle = ds.Tables[0].Rows[0]["PrinterTitle"].ToString();
                if (ds.Tables[0].Rows[0]["PrinterYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrinterYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrinterYN"].ToString().ToLower() == "true"))
                    {
                        model.PrinterYN = true;
                    }
                    else
                    {
                        model.PrinterYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrinterDatetime"].ToString() != "")
                {
                    model.PrinterDatetime = DateTime.Parse(ds.Tables[0].Rows[0]["PrinterDatetime"].ToString());
                }
                model.TopComtont = ds.Tables[0].Rows[0]["TopComtont"].ToString();
                model.BotComtont = ds.Tables[0].Rows[0]["BotComtont"].ToString();
                if (ds.Tables[0].Rows[0]["PrintStatShow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintStatShow"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintStatShow"].ToString().ToLower() == "true"))
                    {
                        model.PrintStatShow = true;
                    }
                    else
                    {
                        model.PrintStatShow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintAmount_Recodor"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintAmount_Recodor"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintAmount_Recodor"].ToString().ToLower() == "true"))
                    {
                        model.PrintAmount_Recodor = true;
                    }
                    else
                    {
                        model.PrintAmount_Recodor = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintAmount_Sum"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintAmount_Sum"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintAmount_Sum"].ToString().ToLower() == "true"))
                    {
                        model.PrintAmount_Sum = true;
                    }
                    else
                    {
                        model.PrintAmount_Sum = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintDiscount_Sum"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintDiscount_Sum"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintDiscount_Sum"].ToString().ToLower() == "true"))
                    {
                        model.PrintDiscount_Sum = true;
                    }
                    else
                    {
                        model.PrintDiscount_Sum = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintTotalNet_Sum"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintTotalNet_Sum"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintTotalNet_Sum"].ToString().ToLower() == "true"))
                    {
                        model.PrintTotalNet_Sum = true;
                    }
                    else
                    {
                        model.PrintTotalNet_Sum = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintTotalNet_BigWrite"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintTotalNet_BigWrite"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintTotalNet_BigWrite"].ToString().ToLower() == "true"))
                    {
                        model.PrintTotalNet_BigWrite = true;
                    }
                    else
                    {
                        model.PrintTotalNet_BigWrite = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["DefaultPrinter"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["DefaultPrinter"].ToString() == "1") || (ds.Tables[0].Rows[0]["DefaultPrinter"].ToString().ToLower() == "true"))
                    {
                        model.DefaultPrinter = true;
                    }
                    else
                    {
                        model.DefaultPrinter = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Pai"].ToString() != "")
                {
                    model.Pai = int.Parse(ds.Tables[0].Rows[0]["Pai"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_ReturnList_Printer_Setup GetModelB(string Tex_ID)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@Tex_ID", SqlDbType.NVarChar,50)};
            parameters[0].Value = Tex_ID;

            KNet.Model.Knet_Procure_ReturnList_Printer_Setup model = new KNet.Model.Knet_Procure_ReturnList_Printer_Setup();
            DataSet ds = DbHelperSQL.RunProcedure("Proc_Knet_Procure_ReturnList_Printer_Setup_GetModelByNo", parameters, "ds");
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.ID = ds.Tables[0].Rows[0]["ID"].ToString();
                model.Tex_ID = ds.Tables[0].Rows[0]["Tex_ID"].ToString();
                model.PrinterTitle = ds.Tables[0].Rows[0]["PrinterTitle"].ToString();
                if (ds.Tables[0].Rows[0]["PrinterYN"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrinterYN"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrinterYN"].ToString().ToLower() == "true"))
                    {
                        model.PrinterYN = true;
                    }
                    else
                    {
                        model.PrinterYN = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrinterDatetime"].ToString() != "")
                {
                    model.PrinterDatetime = DateTime.Parse(ds.Tables[0].Rows[0]["PrinterDatetime"].ToString());
                }
                model.TopComtont = ds.Tables[0].Rows[0]["TopComtont"].ToString();
                model.BotComtont = ds.Tables[0].Rows[0]["BotComtont"].ToString();
                if (ds.Tables[0].Rows[0]["PrintStatShow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintStatShow"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintStatShow"].ToString().ToLower() == "true"))
                    {
                        model.PrintStatShow = true;
                    }
                    else
                    {
                        model.PrintStatShow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintAmount_Recodor"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintAmount_Recodor"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintAmount_Recodor"].ToString().ToLower() == "true"))
                    {
                        model.PrintAmount_Recodor = true;
                    }
                    else
                    {
                        model.PrintAmount_Recodor = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintAmount_Sum"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintAmount_Sum"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintAmount_Sum"].ToString().ToLower() == "true"))
                    {
                        model.PrintAmount_Sum = true;
                    }
                    else
                    {
                        model.PrintAmount_Sum = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintDiscount_Sum"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintDiscount_Sum"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintDiscount_Sum"].ToString().ToLower() == "true"))
                    {
                        model.PrintDiscount_Sum = true;
                    }
                    else
                    {
                        model.PrintDiscount_Sum = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintTotalNet_Sum"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintTotalNet_Sum"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintTotalNet_Sum"].ToString().ToLower() == "true"))
                    {
                        model.PrintTotalNet_Sum = true;
                    }
                    else
                    {
                        model.PrintTotalNet_Sum = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PrintTotalNet_BigWrite"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PrintTotalNet_BigWrite"].ToString() == "1") || (ds.Tables[0].Rows[0]["PrintTotalNet_BigWrite"].ToString().ToLower() == "true"))
                    {
                        model.PrintTotalNet_BigWrite = true;
                    }
                    else
                    {
                        model.PrintTotalNet_BigWrite = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["DefaultPrinter"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["DefaultPrinter"].ToString() == "1") || (ds.Tables[0].Rows[0]["DefaultPrinter"].ToString().ToLower() == "true"))
                    {
                        model.DefaultPrinter = true;
                    }
                    else
                    {
                        model.DefaultPrinter = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["Pai"].ToString() != "")
                {
                    model.Pai = int.Parse(ds.Tables[0].Rows[0]["Pai"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Tex_ID,PrinterTitle,PrinterYN,PrinterDatetime,TopComtont,BotComtont,PrintStatShow,PrintAmount_Recodor,PrintAmount_Sum,PrintDiscount_Sum,PrintTotalNet_Sum,PrintTotalNet_BigWrite,DefaultPrinter,Pai ");
            strSql.Append(" FROM Knet_Procure_ReturnList_Printer_Setup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,Tex_ID,PrinterTitle,PrinterYN,PrinterDatetime,TopComtont,BotComtont,PrintStatShow,PrintAmount_Recodor,PrintAmount_Sum,PrintDiscount_Sum,PrintTotalNet_Sum,PrintTotalNet_BigWrite,DefaultPrinter,Pai ");
            strSql.Append(" FROM Knet_Procure_ReturnList_Printer_Setup ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }



        #endregion  成员方法
    }
}

