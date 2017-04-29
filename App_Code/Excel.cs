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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
/// <summary>
/// Excel 的摘要说明
/// </summary>
public class Excel : BasePage
{
    public Excel()
    {

    }
    public System.Data.DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
    {
        try
        {
            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + Server.MapPath("ExcelFiles/MyExcelFile.xls") + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件
            string strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + Server.MapPath(strExcelFileName) + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"; //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)
            //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。//      "IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。 
            //Sql语句
            string strExcel = string.Format("select * from [{0}$]", strSheetName); //这是一种方法
            //string strExcel = "select * from   [sheet1$]";
            //定义存放的数据表
            DataSet ds = new DataSet();
            //连接数据源
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            //适配到数据源
            OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
            adapter.Fill(ds, strSheetName);
            conn.Close();

            return ds.Tables[strSheetName];
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public System.Data.DataTable ExcelFirestToDataTable(string strExcelFileName, string s_Where)
    {
        try
        {
            //string strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + Server.MapPath("ExcelFiles/MyExcelFile.xls") + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'"; //此连接只能操作Excel2007之前(.xls)文件
            //备注： "HDR=yes;"是说Excel文件的第一行是列名而不是数据，"HDR=No;"正好与前面的相反。//      "IMEX=1 "如果列中的数据类型不一致，使用"IMEX=1"可必免数据类型冲突。 
            //Sql语句
            string strConn = "";
            string strSheetName = "";
            try
            {
                strConn = "Provider=Microsoft.Ace.OleDb.12.0;" + "data source=" + Server.MapPath(strExcelFileName) + ";Extended Properties='Excel 12.0; HDR=NO; IMEX=1'"; //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)
                strSheetName = GetExcelFirstTableName(strExcelFileName, strConn);
            }
            catch(Exception ex)
            {
                strConn = "Provider=Microsoft.Jet.OleDb.4.0;" + "data source=" + Server.MapPath(strExcelFileName) + ";Extended Properties='Excel 8.0; HDR=Yes; IMEX=1'"; //此连接可以操作.xls与.xlsx文件 (支持Excel2003 和 Excel2007 的连接字符串)
                strSheetName = GetExcelFirstTableName(strExcelFileName, strConn);
            }
            string strExcel = string.Format("select * from [{0}] where " + s_Where + "", strSheetName); //这是一种方法
            //string strExcel = "select * from   [sheet1$]";
            //定义存放的数据表
            DataSet ds = new DataSet();
            //连接数据源
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            //适配到数据源
            OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
            adapter.Fill(ds, strSheetName);
            conn.Close();

            return ds.Tables[strSheetName];
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public void HtmlToExcel(string s_Html, string strExcelFileName)
    {
        try
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.AppendHeader("Content-Disposition",
                 "attachment;filename=" + HttpUtility.UrlEncode(strExcelFileName, System.Text.Encoding.UTF8).ToString() + ".xls");

            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.Write(s_Html);
            HttpContext.Current.Response.End();
        }
        catch (Exception ex)
        {
        }
    }
    public string GetExcelFirstTableName(string excelFileName, string strConn)
    {
        string tableName = null;
        if (File.Exists(Server.MapPath(excelFileName)))
        {
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                System.Data.DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                tableName = dt.Rows[0][2].ToString().Trim();
            }
        }
        return tableName;
    }
    public void DGToExcel(System.Web.UI.Control ctl, string FileName)
    {
        string s_style = @"<style>.Custom_Hidden { display: none; }</style> ";
        HttpContext.Current.Response.Charset = "GB2312";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;//注意编码
        HttpContext.Current.Response.AppendHeader("Content-Disposition",
             "attachment;filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        ctl.Page.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        ctl.RenderControl(hw);
        HttpContext.Current.Response.Write(tw.ToString());
        HttpContext.Current.Response.End();
    }
    public void ExcelExport(StringWriter sw, string exportFileName)
    {
        try
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode(exportFileName, System.Text.Encoding.UTF8).ToString());
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.Write(sw.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
        catch(Exception ex)
        { }


    }


    public void CreateExcel(DataSet ds, string FileName)
    {
        HttpResponse resp;
        resp = Page.Response;
        resp.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
        string colHeaders = "", ls_item = "";

        //定义表对象与行对象，同时用DataSet对其值进行初始化 
        System.Data.DataTable dt = ds.Tables[0];
        DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
        int i = 0;
        int cl = dt.Columns.Count;


        //取得数据表各列标题，各标题之间以/t分割，最后一个列标题后加回车符 
        for (i = 0; i < cl; i++)
        {
            if (i == (cl - 1))//最后一列，加/n
            {
                colHeaders += dt.Columns[i].Caption.ToString() + "/n";
            }
            else
            {
                colHeaders += dt.Columns[i].Caption.ToString() + "/t";
            }

        }
        resp.Write(colHeaders);
        //向HTTP输出流中写入取得的数据信息 

        //逐行处理数据   
        foreach (DataRow row in myRow)
        {
            //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据     
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加/n
                {
                    ls_item += row[i].ToString() + "/n";
                }
                else
                {
                    ls_item += row[i].ToString() + "/t";
                }

            }
            resp.Write(ls_item);
            ls_item = "";

        }
        resp.End();
    }


    /// <summary>
    /// xml格式生成excel文件并存盘;
    /// </summary>
    /// <param name="page">生成报表的页面，没有传null</param>
    /// <param name="dt">数据表</param>
    /// <param name="TableTitle">报表标题，sheet1名</param>
    /// <param name="fileName">存盘文件名，全路径</param>
    /// <param name="IsDown">生成文件后是否提示下载,只有web下才有效</param>
    public void CreateExcelByXml(System.Web.UI.Page page, System.Data.DataTable dt, String TableTitle, string fileName, bool IsDown)
    {
        StringBuilder strb = new StringBuilder();
        strb.Append(" <html xmlns:o=\"urn:schemas-microsoft-com:office:office\"");
        strb.Append("xmlns:x=\"urn:schemas-microsoft-com:office:excel\"");
        strb.Append("xmlns=\"");
        strb.Append(" <head> <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>");
        strb.Append(" <style>");
        strb.Append("body");
        strb.Append(" {mso-style-parent:style0;");
        strb.Append(" font-family:\"Times New Roman\", serif;");
        strb.Append(" mso-font-charset:0;");
        strb.Append(" mso-number-format:\"@\";}");
        strb.Append("table");
        //strb.Append(" {border-collapse:collapse;margin:1em 0;line-height:20px;font-size:12px;color:#222; margin:0px;}");
        strb.Append(" {border-collapse:collapse;margin:1em 0;line-height:20px;color:#222; margin:0px;}");
        strb.Append("thead tr td");
        strb.Append(" {background-color:#e3e6ea;color:#6e6e6e;text-align:center;font-size:14px;}");
        strb.Append("tbody tr td");
        strb.Append(" {font-size:12px;color:#666;}");
        strb.Append(" </style>");
        strb.Append(" <xml>");
        strb.Append(" <x:ExcelWorkbook>");
        strb.Append(" <x:ExcelWorksheets>");
        strb.Append(" <x:ExcelWorksheet>");
        //设置工作表 sheet1的名称
        strb.Append(" <x:Name>" + TableTitle + " </x:Name>");
        strb.Append(" <x:WorksheetOptions>");
        strb.Append(" <x:DefaultRowHeight>285 </x:DefaultRowHeight>");
        strb.Append(" <x:Selected/>");
        strb.Append(" <x:Panes>");
        strb.Append(" <x:Pane>");
        strb.Append(" <x:Number>3 </x:Number>");
        strb.Append(" <x:ActiveCol>1 </x:ActiveCol>");
        strb.Append(" </x:Pane>");
        strb.Append(" </x:Panes>");
        strb.Append(" <x:ProtectContents>False </x:ProtectContents>");
        strb.Append(" <x:ProtectObjects>False </x:ProtectObjects>");
        strb.Append(" <x:ProtectScenarios>False </x:ProtectScenarios>");
        strb.Append(" </x:WorksheetOptions>");
        strb.Append(" </x:ExcelWorksheet>");
        strb.Append(" <x:WindowHeight>6750 </x:WindowHeight>");
        strb.Append(" <x:WindowWidth>10620 </x:WindowWidth>");
        strb.Append(" <x:WindowTopX>480 </x:WindowTopX>");
        strb.Append(" <x:WindowTopY>75 </x:WindowTopY>");
        strb.Append(" <x:ProtectStructure>False </x:ProtectStructure>");
        strb.Append(" <x:ProtectWindows>False </x:ProtectWindows>");
        strb.Append(" </x:ExcelWorkbook>");
        strb.Append(" </xml>");
        strb.Append("");
        strb.Append(" </head> <body> ");
        strb.Append(" <table style=\"border-right: 1px solid #CCC;border-bottom: 1px solid #CCC;text-align:center;\"> <thead><tr>");
        //合格所有列并显示标题
        strb.Append(" <td style=\"text-align:center;background:#d3eeee;font-size:18px;\" colspan=\"" + dt.Columns.Count + "\" ><b>");
        strb.Append(TableTitle);
        strb.Append(" </b></td> ");
        strb.Append(" </tr>");
        strb.Append(" </thead><tbody><tr style=\"height:20px;\">");
        if (dt != null)
        {
            //写列标题 
            int columncount = dt.Columns.Count;
            for (int columi = 0; columi < columncount; columi++)
            {
                strb.Append(" <td style=\"width:110px;;text-align:center;background:#CCC;\"> <b>" + dt.Columns[columi] + " </b> </td>");
            }
            strb.Append(" </tr>");
            //写数据 
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strb.Append(" <tr style=\"height:20px;\">");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    strb.Append(" <td style=\"width:110px;;text-align:center;\">" + dt.Rows[i][j].ToString() + " </td>");
                }
                strb.Append(" </tr>");
            }
        }
        strb.Append(" </tbody> </table>");
        strb.Append(" </body> </html>");

        string ExcelFileName = fileName;
        //string ExcelFileName = Path.Combine(page.Request.PhysicalApplicationPath, path+"/guestData.xls");
        //报表文件存在则先删除
        if (File.Exists(ExcelFileName))
        {
            File.Delete(ExcelFileName);
        }
        StreamWriter writer = new StreamWriter(ExcelFileName, false);
        writer.WriteLine(strb.ToString());
        writer.Close();
        //如果需下载则提示下载对话框
        if (IsDown)
        {
            DownloadExcelFile(page, ExcelFileName);
        }
    }

    public void HTMLToExcel(string s_Details, string s_ID)
    {

        try
        {
            string s_Path = Server.MapPath("Excel/" + s_ID + ".xls");
            if (File.Exists(s_Path))
            {
                File.Delete(s_Path);
            }
            FileStream fs = new FileStream(s_Path, FileMode.Create, FileAccess.Write);
            StreamWriter rw = new StreamWriter(fs, Encoding.Default);//建立StreamWriter为写作准备;
            rw.WriteLine(s_Details);
            rw.Close();
            fs.Close();
        }
        catch (Exception ex)
        { }
    }
    /// <summary>
    /// web下提示下载
    /// </summary>
    /// <param name="page"></param>
    /// <param name="filename">文件名，全路径</param>
    public static void DownloadExcelFile(System.Web.UI.Page page, string FileName)
    {
        page.Response.Write("path:" + FileName);
        if (!System.IO.File.Exists(FileName))
        {
            //MessageBox.ShowAndRedirect(page, "文件不存在！", FileName);
        }
        else
        {
            FileInfo f = new FileInfo(FileName);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + f.Name);
            HttpContext.Current.Response.AddHeader("Content-Length", f.Length.ToString());
            HttpContext.Current.Response.AddHeader("Content-Transfer-Encoding", "binary");
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.WriteFile(f.FullName);
            HttpContext.Current.Response.End();
        }
    }



    public  void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName)
    {

        if (tmpDataTable == null)

            return;

        int rowNum = tmpDataTable.Rows.Count;

        int columnNum = tmpDataTable.Columns.Count;

        int rowIndex = 1;

        int columnIndex = 0;



        Application xlApp = new ApplicationClass();

        xlApp.DefaultFilePath = "";

        xlApp.DisplayAlerts = true;

        xlApp.SheetsInNewWorkbook = 1;

        Workbook xlBook = xlApp.Workbooks.Add(true);



        //将DataTable的列名导入Excel表第一行

        foreach (DataColumn dc in tmpDataTable.Columns)
        {

            columnIndex++;

            xlApp.Cells[rowIndex, columnIndex] = dc.ColumnName;

        }



        //将DataTable中的数据导入Excel中

        for (int i = 0; i < rowNum; i++)
        {

            rowIndex++;

            columnIndex = 0;

            for (int j = 0; j < columnNum; j++)
            {

                columnIndex++;

                xlApp.Cells[rowIndex, columnIndex] = tmpDataTable.Rows[i][j].ToString();

            }

        }

        //xlBook.SaveCopyAs(HttpUtility.UrlDecode(strFileName, System.Text.Encoding.UTF8));

        xlBook.SaveCopyAs(strFileName);

    }
}