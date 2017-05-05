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
using System.IO;
using System.Text;
using System.Data.SqlClient;

using KNet.DBUtility;
using KNet.Common;

using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.HSSF.Record.CF;
public partial class Web_Report_Details : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime datetime = DateTime.Now;
            this.StartDate.Text = datetime.AddMonths(-1).AddDays(1 - datetime.Day).ToShortDateString();
            this.EndDate.Text = datetime.AddDays(1 - datetime.Day).AddDays(-1).ToShortDateString();
            base.Base_DropWareHouseBind(this.HouseNo, " KSW_Type='0' ");
            Tbx_Year.Text = datetime.Year.ToString();
            this.Tbx_Month.Text = datetime.AddMonths(-1).Month.ToString();
            this.Tbx_ProductsTypeNo.Text = "M160818111423567";
            this.Tbx_ProductsTypeName.Text = "采购类产品 (02)";
        }
    }

    protected void Btn_SaveOnClick(object sender, EventArgs e)
    {
        NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
        NPOI.SS.UserModel.ISheet sheet = book.CreateSheet("Sheet1");
        NPOI.SS.UserModel.IRow headerrow = sheet.CreateRow(0);
        ICellStyle style = book.CreateCellStyle();
        style.Alignment = HorizontalAlignment.Center;
        style.VerticalAlignment = VerticalAlignment.Center;



        string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
        string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
        string s_HouseNo = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();

        string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
        string s_ProductsEdition = Request.QueryString["ProductsEdtion"] == null ? "" : Request.QueryString["ProductsEdtion"].ToString();
        string s_Number = Request.QueryString["Number"] == null ? "" : Request.QueryString["Number"].ToString();
        
        string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
        string s_Sql = "select b.KSP_CwReamrks,b.ksp_Code,a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType,b.KSP_ProdutsType,Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInAmount else 0 end)  as QCAmount  ";


        s_Sql += ",Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInTotalNet else 0 end)  as QCMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='102'  then DirectInAmount else 0 end)  as CgAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='102'  then DirectInTotalNet else 0 end)  as CgMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='106'  then DirectInAmount else 0 end)  as DbinAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='106'  then DirectInTotalNet else 0 end)  as DbinMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='105'  then -DirectInAmount else 0 end)  as DboutAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type='105'  then -DirectInTotalNet else 0 end)  as DboutMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108') and TypeName<>'材料调整'  then -DirectInAmount else 0 end)  as XhAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108') and TypeName<>'材料调整'  then -DirectInTotalNet else 0 end)  as XhMoney ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')   and (a.ProductsType<>'M130704050932527' ) then -DirectInAmount else 0 end)+Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')   and ((a.ProductsType='M130704050932527' and  typeName='部门领用') ) then -DirectInAmount else 0 end)   as DbrAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')  and (a.ProductsType<>'M130704050932527' ) then -DirectInTotalNet else 0 end) +Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')  and ((a.ProductsType='M130704050932527' and  typeName='部门领用')  ) then -DirectInTotalNet else 0 end)  as DbrMoney ";

        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')   and a.ProductsType='M130704050932527' and typeName<>'销售出库' and typeName<>'部门领用' then -DirectInAmount else 0 end)  as DbrDCLlAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')  and a.ProductsType='M130704050932527' and typeName<>'销售出库' and typeName<>'部门领用' then -DirectInTotalNet else 0 end)  as DbrDCLlMoney ";

        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')   and a.ProductsType='M130704050932527' and typeName='销售出库' then -DirectInAmount else 0 end)  as DbrDCXsAmount ";
        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')  and a.ProductsType='M130704050932527' and typeName='销售出库' then -DirectInTotalNet else 0 end)  as DbrDCXsMoney ";

        s_Sql += ",Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInAmount else 0 end)  as QMAmount ";
        s_Sql += ",Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInTotalNet else 0 end)  as QMMoney ";

        s_Sql += ",Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108') and TypeName='材料调整'  then -DirectInTotalNet else 0 end)  as TZMoney ";
        s_Sql += " from V_Store a join KNet_Sys_Products b on a.ProductsBarCode=b.ProductsBarCode ";
        s_Sql += " join KNet_Sys_WareHouse c on a.HouseNo=c.HouseNo ";

        s_Sql += " where 1=1 ";

        if (s_HouseNo != "")
        {
            s_Sql += " and  a.HouseNo='" + s_HouseNo + "'";
        }
        else
        {
            s_Sql += " and  a.HouseNo in (select HouseNo FROM KNet_Sys_WareHouse where HouseYN=1 and KSW_Type='0' )";
        }

        if (s_ProductsType != "")
        {
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and b.ProductsType in ('" + s_SonID + "') ";
        }
        if (s_ProductsEdition != "")
        {
            s_Sql += " and a.ProductsBarCode in(Select ProductsBarCode from KNet_sys_Products where ProductsEdition like '%" + s_ProductsEdition + "%') ";
        }
        s_Sql += " Group by b.KSP_CwReamrks,b.ksp_Code,a.ProductsBarCode,b.ProductsName,b.ProductsEdition,b.ProductsUnits,b.ProductsType,b.KSP_ProdutsType ";

        if (Button3.Text == "隐藏仓库")
        {
            s_Sql += ",c.HouseName";
        }
        s_Sql += " HAVING Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInTotalNet else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime<'" + s_StartDate + "' then DirectInAmount else 0 end)<>0  ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('102')  then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('105')  then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('106')  then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('108')  then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime>='" + s_StartDate + "' and  DirectinDateTime<='" + s_EndDate + "' and Type in ('104')  then DirectInAmount else 0 end)<>0 ";
        s_Sql += " or Sum(case when DirectinDateTime<='" + s_EndDate + "' then DirectInAmount else 0 end)<>0  ";
        s_Sql += " or Sum(case when  DirectinDateTime<='" + s_EndDate + "'   then DirectInTotalNet else 0 end)<>0 ";

        s_Sql += " order by b.ProductsName,b.ProductsEdition,b.ProductsType ";
        string s_Style = "";
        string s_Head = "";
        decimal d_QCTotalNumber = 0, d_QCTotalMoney = 0;
        decimal d_CgTotalNumber = 0, d_CgTotalMoney = 0;
        decimal d_WwTotalNumber = 0, d_WwTotalMoney = 0;
        decimal d_DbrTotalNumber = 0, d_DbrTotalMoney = 0;
        decimal d_QMTotalNumber = 0, d_QMTotalMoney = 0;
        decimal d_XhTotalNumber = 0, d_XhTotalMoney = 0;
        decimal d_outTotalNumber = 0, d_outTotalMoney = 0;

        decimal d_DbrDCLlTotalNumber = 0, d_DbrDCLlTotalMoney = 0;
        decimal d_DbrDCXsTotalNumber = 0, d_DbrDCXsTotalMoney = 0;

        decimal d_TotalTZMoney = 0;

        this.BeginQuery(s_Sql);
        this.QueryForDataTable();
        DataTable Dtb_Table = this.Dtb_Result;
        for (int i = 0; i < Dtb_Table.Columns.Count; i++)
        {   
            ICell cell = headerrow.CreateCell(i);
            cell.CellStyle = style;
            cell.SetCellValue(Dtb_Table.Columns[i].ColumnName);
        } 
        MemoryStream ms = new MemoryStream();
        book.Write(ms);
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", HttpUtility.UrlEncode("材料收发存报表" + "_" + DateTime.Now.ToString("yyyy-MM-dd"), System.Text.Encoding.UTF8)));
        Response.BinaryWrite(ms.ToArray()); 
        Response.End(); 
        book = null; 
        ms.Close(); 
        ms.Dispose();
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            AdminloginMess AM = new AdminloginMess();
            //先执行库存
            this.Button2.Text = "计算中....";
            // string s_DoSql = " exec Pro_UpdateStore ";
            int i_Row1;
            SqlParameter[] parameters1 = { };
            DbHelperSQL.RunProcedure("Pro_UpdateStore", parameters1, out i_Row1);


            //  s_DoSql = "exec CalculationAllWwPrice '" + this.Tbx_Month.Text + "','" + this.Tbx_Year.Text + "'";

            SqlParameter[] parameters = {
					new SqlParameter("@Month", SqlDbType.NVarChar,20),
					new SqlParameter("@Year", SqlDbType.NVarChar,20)};
            parameters[0].Value = this.Tbx_Month.Text;
            parameters[1].Value = this.Tbx_Year.Text;
            int i_Row;
            DbHelperSQL.RunProcedure("CalculationAllWwPrice1", parameters, out i_Row);

            if (i_Row > 0)
            {
                DbHelperSQL.RunProcedure("Pro_UpdateStore", parameters1, out i_Row1);
                this.Button2.Text = "计算完成";
                AM.Add_Logs("计算委外价格：年：" + this.Tbx_Year.Text + " 月" + this.Tbx_Month.Text);
                Alert("计算成功！");
            }
            //this.Button2.Text = "计算";

        }
        catch (Exception ex)
        {
            this.Button2.Text = "计算";
        }
    }
}
