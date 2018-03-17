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

public partial class List_CkList3 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            AdminloginMess Am = new AdminloginMess();
            string s_Sql = "Select AllocateNo,AllocateDateTime,OutHouseNo,inHoueNO,inHoueName,ProductsName,ProductsBarCode,KSP_COde,AllocateAmount,Allocate_WwPrice,";
            s_Sql += " Allocate_WwMoney ,AllocateStaffNo,AllocateCheckStaffNo,OutHouseName,ProductsEdition ,KWAD_BadNumber,KWAD_AddBadNumber";
            s_Sql += " from  v_AllocateList  ";
            s_Sql += " Where 1=1 and AllocateNo not like 'FX%'  ";
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_CustomerName = Request.QueryString["CustomerName"] == null ? "" : Request.QueryString["CustomerName"].ToString();
            string s_ProductsType = Request.QueryString["ProductsType"] == null ? "" : Request.QueryString["ProductsType"].ToString();
            string s_CustomerTypes = Request.QueryString["CustomerTypes"] == null ? "" : Request.QueryString["CustomerTypes"].ToString();
            string s_ProductsEdition = Request.QueryString["ProductsEidition"] == null ? "" : Request.QueryString["ProductsEidition"].ToString();
            string s_State = Request.QueryString["State"] == null ? "" : Request.QueryString["State"].ToString();
            
            string s_Ck = Request.QueryString["Ck"] == null ? "" : Request.QueryString["Ck"].ToString();
            string s_InCk = Request.QueryString["InCk"] == null ? "" : Request.QueryString["InCk"].ToString();
            
            string s_Code = Request.QueryString["Code"] == null ? "" : Request.QueryString["Code"].ToString();


            string s_OutHouseNo = Request.QueryString["OutHouseNo"] == null ? "" : Request.QueryString["OutHouseNo"].ToString();
            string s_InHouseNo = Request.QueryString["InHouseNo"] == null ? "" : Request.QueryString["InHouseNo"].ToString();
            string s_ProductsBarCode = Request.QueryString["ProductsBarCode"] == null ? "" : Request.QueryString["ProductsBarCode"].ToString();
     
            string s_Details="",s_Style="";
            string s_Head = "";
            Decimal DTotalNum = 0, DTotalNum1 = 0, DTotalNum2 = 0;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n";
            s_Head += "<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=\"13\" class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>成品调拨明细</th></tr>\n";
            s_Head += "<tr>\n<th colspan=\"7\" class=\"thstyleleft\"  >" + "制表人:" + Am.KNet_StaffName + "</th><th colspan=\"6\" class=\"thstyleRight\" >" + "日期:" + s_StartDate + " 到 " + s_EndDate + "</th></tr>\n";
            s_Head += "<tr class=\"thstyle\">\n<th>序号</th>\n";
            s_Head += "<th class=\"thstyle\">调拨单号</th>\n";
            s_Head += "<th class=\"thstyle\">调拨日期</th>\n";
            s_Head += "<th class=\"thstyle\">调出仓库</th>\n";
            s_Head += "<th class=\"thstyle\">调入仓库</th>\n";
            s_Head += "<th class=\"thstyle\">产品名称</th>\n";
            s_Head += "<th class=\"thstyle\">料号</th>\n";
            s_Head += "<th class=\"thstyle\">产品版本</th>\n";
            s_Head += "<th class=\"thstyle\">数量</th>\n";
            s_Head += "<th class=\"thstyle\">士腾不良品</th>\n";
            s_Head += "<th class=\"thstyle\">加工厂不良品</th>\n";
            s_Head += "<th class=\"thstyle\">制单人</th>\n";
            s_Head += "<th class=\"thstyle\">审核</th>\n";
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            if(s_StartDate!="")
            {
                s_Sql += " and AllocateDateTime>='" + s_StartDate + "'";
            }
            if (s_EndDate != "")
            {
                s_Sql += " and AllocateDateTime<='" + s_EndDate + "'";
            }
            if (s_State != "")
            {
                s_Sql += " and  AllocateCheckYN='" + s_State + "' ";
            }
            if (s_ProductsEdition != "")
            {
                s_Sql += " and ProductsEdition like '%" + s_ProductsEdition + "%' ";
            }
            if (s_Code != "")
            {
                s_Sql += " and KSP_Code = '" + s_Code + "' ";
            }
            //显示原材料的调拨
            KNet.BLL.PB_Basic_ProductsClass Bll_ProductsDetails = new KNet.BLL.PB_Basic_ProductsClass();
            string s_SonID = Bll_ProductsDetails.GetSonIDs("M160818111359632");
            s_SonID = s_SonID.Replace(",", "','");
            s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            if(s_ProductsType!="")
            {
                    s_SonID = Bll_ProductsDetails.GetSonIDs(s_ProductsType);
                    s_SonID = s_SonID.Replace(",", "','");
                    s_Sql += " and ProductsType in ('" + s_SonID + "') ";
            }
            if (s_Ck != "")
            {
                s_Sql += " and (inHoueName like '%" + s_Ck + "%' )";
            }
            if (s_InCk != "")
            {
                s_Sql += " and (OutHouseName like '%" + s_Ck + "%' )";
            }


            if (s_OutHouseNo != "")
            {
                s_Sql += " and (OutHouseNo='" + s_OutHouseNo + "' )";
            }
            if (s_InHouseNo != "")
            {
                s_Sql += " and (inHoueno='" + s_InHouseNo + "' )";
            }
            if (s_ProductsBarCode != "")
            {
                s_Sql += " and (ProductsBarCode='" + s_ProductsBarCode + "' )";
            }
            s_Sql += " and AllocateNo not in(select AllocateNo from v_AllocateList where  OutHouseNo='131235104473261008' and inHoueNO='131187187069993664')  Order by AllocateDateTime,AllocateNo ";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table=this.Dtb_Result;

            string s_ID = "";
            if(Dtb_Table.Rows.Count>0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    s_ID += Dtb_Table.Rows[i][0].ToString()+",";

                    if(i%2==0)
                    {
                       s_Style="class='gg'";
                    }
                    else
                    {
                        s_Style="class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails' noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["AllocateNo"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + DateTime.Parse(Dtb_Table.Rows[i]["AllocateDateTime"].ToString()).ToShortDateString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i]["OutHouseName"].ToString() + "</td>\n";
                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i]["inHoueName"].ToString() + "</td>\n";

                    s_Details += "<td align=left class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i]["ProductsName"].ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["KSP_Code"].ToString() + "</td>\n";
                    s_Details += "<td align=left  class='thstyleLeftDetails' noWrap>" + Dtb_Table.Rows[i]["ProductsEdition"].ToString() + "&nbsp;</td>\n";

                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i]["AllocateAmount"].ToString() + "</td>\n";//数量

                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i]["KWAD_BadNumber"].ToString() + "</td>\n";//数量

                    s_Details += "<td align=right class='thstyleLeftDetails'  noWrap>" + Dtb_Table.Rows[i]["KWAD_AddBadNumber"].ToString() + "</td>\n";//数量

                    s_Details += "<td align=center class='thstyleLeftDetails'  noWrap>&nbsp;" + base.Base_GetUserName(Dtb_Table.Rows[i]["AllocateStaffNo"].ToString()) + "</td>\n";//制单人
                    s_Details += "<td align=center  class='thstyleLeftDetails' noWrap>&nbsp;" + base.Base_GetUserName(Dtb_Table.Rows[i]["AllocateCheckStaffNo"].ToString()) + "</td>\n";//制单人
                    s_Details +=" </tr>";
                    DTotalNum += Decimal.Parse(Dtb_Table.Rows[i]["AllocateAmount"].ToString());
                    DTotalNum1 += Decimal.Parse(Dtb_Table.Rows[i]["KWAD_BadNumber"].ToString());
                    DTotalNum2 += Decimal.Parse(Dtb_Table.Rows[i]["KWAD_AddBadNumber"].ToString());
                }
            }
            if (s_ID != "")
            {
                this.Tbx_ID.Text = s_ID.Substring(0,s_ID.Length-1);
            }
            s_Details += " <tr >\n";
            s_Details += "<td  class='thstyleLeftDetails' align=left noWrap colspan=8>合计:" + (Dtb_Table.Rows.Count).ToString() + "</td>\n";
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DTotalNum.ToString() + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DTotalNum1.ToString() + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' noWrap>" + DTotalNum2.ToString() + "</td>\n";//数量
            s_Details += "<td align=right class='thstyleLeftDetails' colspan=2 noWrap>&nbsp;</td>\n";//单价


            s_Details += " </tr>";
            s_Details += "</tbody></table></div>";

            this.Lbl_Details.Text = s_Head+s_Details;

        }

    }

    protected void Btn_Excel_Click(object sender, EventArgs e)
    {
        /*

        KNet.BLL.Xs_Products_Prodocts BLL_Products_Products = new KNet.BLL.Xs_Products_Prodocts();
        KNet.BLL.PB_Basic_ProductsClass BLL_Basic_ProductsClass = new KNet.BLL.PB_Basic_ProductsClass();
        KNet.BLL.Xs_Products_Prodocts_Demo BLL_DemoProducts_Products = new KNet.BLL.Xs_Products_Prodocts_Demo();
        string s_Where1 = " and XPD_FaterBarCode='" + this.Tbx_ID.Text + "' ";
        s_Where1 += " and  b.KSP_Del=0 ";
        string s_Sql = "Select * from Xs_Products_Prodocts_Demo a join KNET_Sys_Products b on a.XPD_ProductsBarCode=b.ProductsBarCode";
        s_Sql += " join PB_Basic_ProductsClass c on b.ProductsType=c.PBP_ID where 1=1 ";
        this.BeginQuery(s_Sql + s_Where1 + "  order by c.PBP_Name,ProductsEdition");
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        
        Excel export = new Excel();
        export.ExcelExport(GetStringWriter(Dtb_DemoProducts), this.Lbl_BomTitle.Text);
        */

        Response.Buffer = true;
        Response.Clear();
        Response.ClearContent();
        Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.UrlEncode("成品调回明细.xls", System.Text.Encoding.UTF8).ToString());
        //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("UTF-8");

        Response.ContentType = "application/ms-excel";
        Response.Write(this.Lbl_Details.Text);
        Response.Flush();
        Response.End();
    }
}
