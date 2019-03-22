using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_CG_Procure_Check_Procure_Delivery_List : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            string OrderNo = Request.QueryString["OrderNo"] == null ? "" : Request.QueryString["OrderNo"].ToString();
            string House_Int = Request.QueryString["HouseNo"] == null ? "" : Request.QueryString["HouseNo"].ToString();
            string ProductsBarCode = Request.QueryString["ProductBarCode"] == null
                ? ""
                : Request.QueryString["ProductBarCode"].ToString();
            string SuppNo = Request.QueryString["SuppNo"] == null ? "" : Request.QueryString["SuppNo"].ToString();
            this.SuppNo.Text = SuppNo;
          
            Lbl_ProductsBarCode.Text = "订单号：" + OrderNo + "";
            this.Lbl_House.Text = "供应商：" + base.Base_GetHouseName(House_Int);
            this.BeginQuery(
                "select * from KNet_WareHouse_AllocateList a join KNet_WareHouse_AllocateList_Details b on a.AllocateNo=b.AllocateNo where KWA_OrderNo='" +
                OrderNo + "' and HouseNo='" + House_Int + "' and HouseNo_int='131235104473261008'");
            this.QueryForDataSet();

            DataSet ds_Details1 = this.Dts_Result;
            this.MyGridView2.DataSource = ds_Details1;
            MyGridView2.DataBind();


        }
    }


    public string RK_Number(string OrderNo, string productbarcode) //入库数量
    {
        decimal d_totalPrice = 0;

        string P = "";
        string sql =
            "  select AllocateAmount from KNet_WareHouse_AllocateList a join  KNet_WareHouse_AllocateList_Details b on a.AllocateNo=b.AllocateNo where KWA_OrderNo='" +
            OrderNo + "' and HouseNo='131235104473261008' and HouseNo_int='131187187069993664' and ProductsBarCode='" +
            productbarcode + "'";
        try
        {
            this.BeginQuery(sql);
            DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
            DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
            P = Dtb_DemoProducts.Rows[0][0].ToString();

            if (P == "")
            {
                P = "0";
            }
        }
        catch
        {

            P = "0";
        }
      
        d_totalPrice = decimal.Parse(P);



        return d_totalPrice.ToString();
    }

    public string BFPrice(string productbarcode) //报废单价
    {
        decimal d_totalPrice = 0;

        try
        {
            string sql = "select top 1 KPP_PCPrice from Knet_Procure_SuppliersPrice where ProductsBarCode='" + productbarcode + "' and KPP_State!=0 and  KPP_Del!=1 order by KPP_ShTime desc";

            this.BeginQuery(sql);
            DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
            DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
            string P = Dtb_DemoProducts.Rows[0][0].ToString();

            if (P == "")
            {
                P = "0";
            }
            d_totalPrice = decimal.Parse(P);

        }
        catch (Exception)
        {


            Response.Write(
                 "<script language=javascript>alert('有部分产品没有报价，或者报价已停用!');parent.location.href = 'Procure_ShipCheck_List.aspx';</script>");
            Response.End();
        }
        return d_totalPrice.ToString();
    }
    public string KK_Money(string number, string productbarcode) //应扣款金额
    {
        decimal d_totalPrice = 0;

        try
        {
            string sql = "select top 1 KPP_PCPrice from Knet_Procure_SuppliersPrice where ProductsBarCode='" + productbarcode + "' and KPP_State!=0 and  KPP_Del!=1 order by KPP_ShTime desc";

            this.BeginQuery(sql);
            DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
            DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
            string P = Dtb_DemoProducts.Rows[0][0].ToString();
            if (number == "")
            {
                number = "0";
            }
            if (P == "")
            {
                P = "0";
            }
            d_totalPrice = decimal.Parse(P) * decimal.Parse(number);

        }
        catch (Exception)
        {

            //Response.Write("<script language=javascript>alert('本信息不存在返回');history.go(-2);</ script > ");
            //Alert("有部分产品没有报价，或者报价已停用");
            //Response.Write("<scripttype='text/javascript'>alert('你所查询的数据不存在！');</script>");
            //Response.Redirect("Procure_ShipCheck_List.aspx");
            Response.Write(
                 "<script language=javascript>alert('有部分产品没有报价，或者报价已停用!');parent.location.href = 'Procure_ShipCheck_List.aspx';</script>");
            Response.End();
        }
        return d_totalPrice.ToString();
    }

    public string GetHandPrice(string productbarcode)//获取加工费
    {
        string s_Return = "";
        this.BeginQuery("select top 1 HandPrice from Knet_Procure_SuppliersPrice where SuppNo='" + this.SuppNo.Text +
                        "' and ProductsBarCode='" + productbarcode + "'  order by ProcureUpdateDateTime desc");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                s_Return = Dtb_Result.Rows[i]["HandPrice"].ToString();
            }
        }
        return s_Return;
    }

    public decimal GetHandMoney(string productbarcode,  string Num, string BFNumber)
    {
        decimal s_Return = 0;
        decimal KPP_PCPrice = 0;
        decimal HandPrice = 0;
        this.BeginQuery("select top 1 HandPrice,KPP_PCPrice from Knet_Procure_SuppliersPrice where SuppNo='" + this.SuppNo.Text +
                        "' and ProductsBarCode='" + productbarcode + "'  order by ProcureUpdateDateTime desc");
        this.QueryForDataTable();
        if (this.Dtb_Result.Rows.Count > 0)
        {
            for (int i = 0; i < Dtb_Result.Rows.Count; i++)
            {
                if (BFNumber.ToString() == "")
                {
                    BFNumber = "0";
                }
                if (Dtb_Result.Rows[i]["KPP_PCPrice"].ToString() == "")
                {
                    KPP_PCPrice = 0;
                }
                if (Dtb_Result.Rows[i]["KPP_PCPrice"].ToString() != "")
                {
                    KPP_PCPrice = decimal.Parse(Dtb_Result.Rows[i]["KPP_PCPrice"].ToString());
                }
                if (Dtb_Result.Rows[i]["HandPrice"].ToString() != "")
                {
                    HandPrice = decimal.Parse(Dtb_Result.Rows[i]["HandPrice"].ToString());
                }
                else
                {
                    HandPrice = 0;

                }
                if (Num == "")
                {
                    Num = "0";
                }
                s_Return = HandPrice *
                           (Convert.ToDecimal(Num) - decimal.Parse(BFNumber)) -
                           Convert.ToDecimal(KPP_PCPrice) * decimal.Parse(BFNumber);
            }
        }
        return s_Return;
    }

    public string OrderNoCount(string OrderNo, string productbarcode) //订单总数量
    {



        string sql = " select sum(OrderAmount)as OrderAmount from Knet_Procure_OrdersList_Details where ProductsBarCode='" + productbarcode + "' and OrderNo='" + OrderNo + "'";

        this.BeginQuery(sql);
        DataSet Dts_DemoProducts = (DataSet)this.QueryForDataSet();
        DataTable Dtb_DemoProducts = Dts_DemoProducts.Tables[0];
        string P = Dtb_DemoProducts.Rows[0][0].ToString();




        return P.ToString();
    }
}