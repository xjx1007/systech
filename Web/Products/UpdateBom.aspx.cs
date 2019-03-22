using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Products_UpdateBom : BasePage
{
    public string s_ProductsTable_BomDetail = "";

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_Create_OnServerClick(object sender, EventArgs e)
    {
        string fileName = FileUpload1.FileName;
        //string sheetName = "day";
        string filePath = Server.MapPath("/UploadBOMExcel/");
        //string tmpRootDir = Server.MapPath(HttpContext.Current.Request.ApplicationPath.ToString());//获取程序根目录
        string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
        string fileserverurl = (filePath + s_Date + fileName).Replace(filePath, ""); //转换成相对路径
        fileserverurl = fileserverurl.Replace(@"\", @"/");
        if (File.Exists(fileserverurl))
        {
            Alert("你已经上传过一次了，不可再次上传");
            return;
        }
        else
        {
            FileUpload1.SaveAs(filePath + s_Date + fileName);
        }

        //DataTable dt = ReadExcelToDataTable(filePath + fileName);
        string sheetName = null;
        bool isFirstRowColumn = true;
        string fileurl = filePath + s_Date + fileName;
        //定义要返回的datatable对象
        DataTable data = new DataTable();
        //excel工作表
        ISheet sheet = null;
        //数据开始行(排除标题行)
        int startRow = 0;
        try
        {
            if (!File.Exists(fileurl))
            {

            }
            //根据指定路径读取文件
            FileStream fs = new FileStream(fileurl, FileMode.Open, FileAccess.Read);
            //根据文件流创建excel数据结构
            IWorkbook workbook = WorkbookFactory.Create(fs);
            //IWorkbook workbook = new HSSFWorkbook(fs);
            //如果有指定工作表名称
            if (!string.IsNullOrEmpty(sheetName))
            {
                sheet = workbook.GetSheet(sheetName);
                //如果没有找到指定的sheetName对应的sheet，则尝试获取第一个sheet
                if (sheet == null)
                {
                    sheet = workbook.GetSheetAt(0);
                }
            }
            else
            {
                //如果没有指定的sheetName，则尝试获取第一个sheet
                sheet = workbook.GetSheetAt(0);
            }
            if (sheet != null)
            {
                IRow firstRow = sheet.GetRow(0);
                //一行最后一个cell的编号 即总的列数
                int cellCount = firstRow.LastCellNum;
                //如果第一行是标题列名
                if (isFirstRowColumn)
                {
                    for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                    {
                        ICell cell = firstRow.GetCell(i);
                        if (cell != null)
                        {
                            string cellValue = cell.StringCellValue;
                            if (cellValue != null)
                            {
                                DataColumn column = new DataColumn(cellValue);
                                data.Columns.Add(column);
                            }
                        }
                    }
                    startRow = sheet.FirstRowNum + 1;
                }
                else
                {
                    startRow = sheet.FirstRowNum;
                }
                //最后一列的标号
                int rowCount = sheet.LastRowNum;
                for (int i = startRow; i <= rowCount; ++i)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue; //没有数据的行默认是null　　　　　　　

                    DataRow dataRow = data.NewRow();
                    for (int j = row.FirstCellNum; j < cellCount; ++j)
                    {
                        if (row.GetCell(j) != null) //同理，没有数据的单元格都默认是null
                            dataRow[j] = row.GetCell(j).ToString();
                    }
                    data.Rows.Add(dataRow);
                }
            }
            string s_DemoProductsID = ""; //产品编号
            string s_DemoProductCode = ""; //产品料号
            if (data.Rows.Count > 0)
            {
                //s_ProductsTable_BomDetail = "";
                string[] bomlist = new string[data.Rows.Count];

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    int a = i + 1;
                    bomlist[i] = data.Rows[i][0].ToString();
                    string productbarcode = GetProductByCode(data.Rows[i][0].ToString());
                    if (productbarcode == "")
                    {
                        s_DemoProductCode += data.Rows[i][0].ToString() + ",";
                    }
                    else
                    {


                        s_DemoProductsID += productbarcode + ",";
                        s_ProductsTable_BomDetail += "<tr>\n";
                        s_ProductsTable_BomDetail +=
                            "<td class=\"ListHeadDetails\"><input type=input Name=\"DemoOrder_" + a +
                            " \"  value='" + a.ToString() + "'  readonly=\"readonly\" ></td>\n";
                        s_ProductsTable_BomDetail +=
                            "<td class='ListHeadDetails' width=\"100px\"><input type=input Name=\"DemoProdoctsBarCode_" +
                            a + "\"  value='" + data.Rows[i][0].ToString() + "' readonly=\"readonly\"  ></td>\n"; //料号
                        s_ProductsTable_BomDetail +=
                            "<td class='ListHeadDetails'><input type=\"input\" Name=\"ProdoctsName_" + a + "\"  value='" +
                            data.Rows[i][1].ToString() + "'></td>\n"; //修改名称

                        s_ProductsTable_BomDetail +=
                            "<td class='ListHeadDetails'><input type=\"input\" Name=\"ProductsPattern_" + a +
                            "\"  ID=\"ProductsPattern_" + a + "\" value='" + data.Rows[i][2].ToString() + "' ></td>\n"; //修改型号

                        s_ProductsTable_BomDetail +=
                            "<td class='ListHeadDetails'><input type=\"input\" Name=\"ProductsEdition_" + a +
                            "\"  ID=\"ProductsEdition_" + a + "\"  value='" + data.Rows[i][3].ToString() + "' ></td>\n"; //修改版本

                        s_ProductsTable_BomDetail +=
                            "<td class='ListHeadDetails'><input type=\"input\" Name=\"Remark_" + a +
                            "\" style=\"detailedViewTextBox;width:200px\"  value='" + data.Rows[i][4].ToString() +
                            "'  ></td>\n"; //修改备注
                        s_ProductsTable_BomDetail +=
                            "<td class='ListHeadDetails'><input type=\"input\" Name=\"BZNumber_" + a + "\"  value='" +
                            data.Rows[i][5].ToString() + "' ></td>\n";

                        s_ProductsTable_BomDetail += "</tr>\n";

                    }

                }
                if (s_DemoProductCode.Length > 0)
                {
                    File.Delete(fileserverurl);
                    s_ProductsTable_BomDetail = "";
                    Alert("料号：" + s_DemoProductCode + "匹配失败，有可能料号非法!请检查你上传的EXCEL表！");
                }
                else
                {
                    bool flag = true; //假设不重复 
                    string cfcode = ""; //重复的物料
                    for (int i = 0; i < bomlist.Length - 1; i++)
                    {
                        //循环开始元素 
                        for (int j = i + 1; j < bomlist.Length; j++)
                        {
                            //循环后续所有元素 
                            //如果相等，则重复 
                            if (bomlist[i] == bomlist[j])
                            {
                                flag = false; //设置标志变量为重复 
                                cfcode += bomlist[i];

                            }
                        }
                    }
                    //判断标志变量 
                    if (flag)
                    {
                        this.Products_BomID.Text = s_DemoProductsID;
                        this.Products_BomNum.Text = data.Rows.Count.ToString();
                        //this.truenum.Text = data.Rows.Count.ToString();
                    }
                    else
                    {
                        s_ProductsTable_BomDetail = "";
                        Alert("你上传的EXCEL表中有重复的物料，料号为：" + cfcode);
                    }
                }


            }
            else
            {
                File.Delete(fileserverurl);
                s_ProductsTable_BomDetail = "";
                Alert("EXCEL表格内容不能为空");
            }


        }
        catch (Exception ex)
        {
            //File.Delete(fileserverurl);
            //Alert("匹配失败！！请检查你上传的EXCEL表，重新上传");
            throw ex;
        }
    }

    /// <summary>
    /// 根据料号查询产品
    /// </summary>
    /// <returns></returns>
    public string GetProductByCode(string code)
    {
        string sql = "select * from KNet_Sys_Products where KSP_COde='" + code + "'";
        DataTable rownum = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        if (rownum.Rows.Count > 0)
        {
            return code;
        }
        else
        {
            return "";
        }

    }

    protected void Button2_OnClick(object sender, EventArgs e)
    {
        if (this.Products_BomNum.Text != "0")
        {
            KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Prodocts = new KNet.BLL.Xs_Products_Prodocts_Demo();
            string code = "";
            int num = 0;
            for (int i = 0; i < int.Parse(this.Products_BomNum.Text) + 1; i++)
            {
                string ProductCode = Request.Form["DemoProdoctsBarCode_" + i.ToString() + ""] == null
                    ? ""
                    : Request.Form["DemoProdoctsBarCode_" + i.ToString() + ""].ToString();
                string ProdoctsName = Request.Form["ProdoctsName_" + i.ToString() + ""] == null
                    ? "0"
                    : Request.Form["ProdoctsName_" + i.ToString() + ""].ToString(); //名称
                string ProductsPattern = Request.Form["ProductsPattern_" + i.ToString() + ""] == null
                    ? "0"
                    : Request.Form["ProductsPattern_" + i.ToString() + ""].ToString(); //型号
                string ProductsEdition = Request.Form["ProductsEdition_" + i.ToString() + ""] == null
                    ? "0"
                    : Request.Form["ProductsEdition_" + i.ToString() + ""].ToString(); //版本号
                string Remark = Request.Form["Remark_" + i.ToString() + ""] == null
                    ? ""
                    : Request.Form["Remark_" + i.ToString() + ""].ToString(); //备注
                string BZNumber = Request.Form["BZNumber_" + i.ToString() + ""] == null
                    ? ""
                    : Request.Form["BZNumber_" + i.ToString() + ""].ToString(); //包装数

                try
                {
                    string sql = "update KNet_Sys_Products set ProductsName='" + ProdoctsName + "',ProductsPattern='" + ProductsPattern + "',ProductsEdition='" + ProductsEdition + "',KSP_Remark='" + Remark + "',KSP_BZNumber=" + int.Parse(BZNumber) + " where KSP_COde='" + ProductCode + "'";
                    int a = DbHelperSQL.ExecuteSql(sql);
                    if (a>0)
                    {
                        num += 1;
                    }
                   
                }
                catch
                {
                    code += ProductCode;
                }
               

            }
            this.Label1.Text = "修改失败的物料：" + code;
            this.Label2.Text = "修改成功：" + num+"个物料";
            if (num==int.Parse(this.Products_BomNum.Text))
            {
                Alert("修改成功，修改了"+num+"个物料");
            }
           
        }
    }
}