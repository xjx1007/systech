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
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            ICell cell = headerrow.CreateCell(i);
            cell.CellStyle = style; 
            cell.SetCellValue(dt.Columns[i].ColumnName);
        } 
        MemoryStream ms = new MemoryStream();
        book.Write(ms);
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", HttpUtility.UrlEncode(title + "_" + DateTime.Now.ToString("yyyy-MM-dd"), System.Text.Encoding.UTF8)));
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
