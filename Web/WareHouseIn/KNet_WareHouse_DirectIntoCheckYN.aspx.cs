using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

/// <summary>
/// 对入库单进行审核,并处到到  （仓库总账），产生  （仓库流水账）
/// </summary>
public partial class Knet_Web_Procure_pop_Knet_Procure_WareHouseCheckYN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                //入库单审核
                if (Request.QueryString["WareHouseNo"] != null && Request.QueryString["WareHouseNo"] != "")
                {
                    this.UsersNotxt.Text = Request.QueryString["WareHouseNo"].ToString().Trim();

                    if (Knet_Procure_OrdersList_Details_Shu(Request.QueryString["WareHouseNo"].ToString().Trim()) <= 0)
                    {
                        this.MyStatStr.Visible = true;
                        this.MyStatStr.Text = "此入库单未添加有产品明细，不能进行审核操作！";
                        this.Button1.Enabled = false;

                    }
                }
                else
                {
                    Response.Write("<script>alert('非法参数！');window.close();</script>");
                    Response.End();
                }
            }
        }
    }


    /// <summary>
    /// 是否是自己的订单？
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected string GetProcureOrders_onselftYN(string ProcureBM)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select * from Knet_Procure_WareHouseList where WareHouseNo='" + ProcureBM + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return dr["WareHouseStaffNo"].ToString();
            }
            else
            {
                return "";
            }
        }
    }

    /// <summary>
    /// 审核操作
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            int AA = int.Parse(this.DropDownList1.SelectedValue);
            string WareHouseNo = this.UsersNotxt.Text.Trim();
            string WareHouseCheckStaffNo = AM.KNet_StaffNo;

            //if (GetProcureOrders_onselftYN(WareHouseNo).ToLower() == AM.KNet_StaffNo.ToLower())
            //{
            //    Response.Write("<script>alert('自己开的单不能自己审核！');window.opener.location.reload();window.close();</script>");
            //    Response.End();
            //}
      
            if (AA != -1)
            {
                if (AA == 1) //通过审核
                {    
                    //读取入库单信息
                    KNet.BLL.Knet_Procure_WareHouseList BLL2 = new KNet.BLL.Knet_Procure_WareHouseList();
                    KNet.Model.Knet_Procure_WareHouseList model2 = BLL2.GetModelB(WareHouseNo);


                    string HouseNo = model2.HouseNo;
                    string WaterUnionOrderNo = model2.WareHouseNo;
                    string WaterSupperUnitsName =model2.SuppNo;
                    string WaterDoStaffNo = AM.KNet_StaffNo;



                    //后加入库信息表

                    string OrderNumber = model2.OrderNo;//采购单号
                    string SingleStorage = model2.WareHouseNo;//入库单号
                    DateTime StorageTime = DateTime.Now; //入库时间
 






                    //读取入库单 明细
                    KNet.BLL.Knet_Procure_WareHouseList_Details bll = new KNet.BLL.Knet_Procure_WareHouseList_Details();
                    DataSet ds = bll.GetList(" WareHouseNo='" + WareHouseNo + "' ");
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        DataRowView mydrv = ds.Tables[0].DefaultView[i];

                        string WareHouseNox = mydrv["WareHouseNo"].ToString(); //入库单号
                        string ProductsName = mydrv["ProductsName"].ToString();
                        string ProductsBarCode = mydrv["ProductsBarCode"].ToString();
                        string ProductsPattern = mydrv["ProductsPattern"].ToString();
                        string ProductsUnits = mydrv["ProductsUnits"].ToString();
                        string WareHousePack = mydrv["WareHousePack"].ToString();
                        int WareHouseAmount = int.Parse(mydrv["WareHouseAmount"].ToString());  //仓库总账---现存数量
                        decimal WareHouseUnitPrice =decimal.Parse( mydrv["WareHouseUnitPrice"].ToString());
                        decimal WareHouseDiscount = decimal.Parse(mydrv["WareHouseDiscount"].ToString());
                        decimal WareHouseTotalNet = decimal.Parse(mydrv["WareHouseTotalNet"].ToString());


                        int StorageVolume = int.Parse(mydrv["WareHouseAmount"].ToString()); //入库数量
                        int ShippedQuantity = 0; //已出货数量


                        //生成入库总台
                        this.BluidWareHouseOwnall(HouseNo, ProductsName, ProductsBarCode, ProductsPattern, ProductsUnits, WareHouseAmount, WareHouseTotalNet, WareHouseDiscount, OrderNumber, SingleStorage, StorageTime, StorageVolume, ShippedQuantity);



                        //生成入库明细流水账 
                        this.BluidWareHouse_Ownall_Water(HouseNo, 1, ProductsName, ProductsBarCode, ProductsPattern, ProductsUnits, WareHousePack, WareHouseAmount, WareHouseUnitPrice, WareHouseDiscount, WareHouseTotalNet, WaterSupperUnitsName, WaterUnionOrderNo, WaterDoStaffNo);

                    }



                    string DoSql = "update Knet_Procure_WareHouseList  set  WareHouseCheckYN=" + AA + ",WareHouseCheckStaffNo ='" + WareHouseCheckStaffNo + "' where  WareHouseNo='" + WareHouseNo + "' ";
                    DbHelperSQL.ExecuteSql(DoSql);

                    AM.Add_Logs(" 入库单审核成功.入库单：" + WareHouseNo + "");
                    Response.Write("<script>alert('入库审核成功，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('入库单没通过审核，点 确定 返回！');window.opener.location.reload();window.close();</script>");
                    Response.End();
                }
            }
        }
    }



    /// <summary>
    /// 获取采购单明细数目
    /// </summary>
    /// <param name="aa"></param>
    /// <returns></returns>
    protected int Knet_Procure_OrdersList_Details_Shu(string WareHouseNo)
    {
        using (SqlConnection conn = DBClass.GetConnection("KNetERP"))
        {
            conn.Open();
            string Dostr = "select count(*) as IDS  from Knet_Procure_WareHouseList_Details where WareHouseNo='" + WareHouseNo + "'";
            SqlCommand cmd = new SqlCommand(Dostr, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                return int.Parse(dr["IDS"].ToString().Trim().ToString());
            }
            else
            {
                return -1;
            }
        }
    }

    /// <summary>
    /// 生成入库总台账
    /// </summary>
    /// <param name="HouseNo">仓库</param>
    /// <param name="ProductsName">产品名称</param>
    /// <param name="ProductsBarCode">形码</param>
    /// <param name="ProductsPattern">型号</param>
    /// <param name="ProductsUnits">单位</param>
    /// <param name="WareHouseAmount">数量</param>
    /// <param name="WareHouseTotalNet">净值</param>
    /// <param name="WareHouseDiscount">计调价</param>
    /// 
    /// <param name="OrderNumber">采购单号</param>
    /// <param name="SingleStorage">入库单号</param>
    /// <param name="StorageTime">入库时间</param>
    /// <param name="StorageVolume">入库数量</param>
    /// <param name="ShippedQuantity">已出货数量</param>
    protected void BluidWareHouseOwnall(string HouseNo, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, int WareHouseAmount, decimal WareHouseTotalNet, decimal WareHouseDiscount, string OrderNumber, string SingleStorage, DateTime StorageTime, int StorageVolume, int ShippedQuantity)
    {
        KNet.BLL.KNet_WareHouse_Ownall BLL = new KNet.BLL.KNet_WareHouse_Ownall();
        KNet.Model.KNet_WareHouse_Ownall model = new KNet.Model.KNet_WareHouse_Ownall();

        model.HouseNo = HouseNo;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;
        model.WareHouseAmount = WareHouseAmount;
        model.WareHouseTotalNet = WareHouseTotalNet;
        model.WareHouseDiscount = WareHouseDiscount;

        model.OrderNumber = OrderNumber;
        model.SingleStorage = SingleStorage;
        model.StorageTime = StorageTime;
        model.StorageVolume = StorageVolume;
        model.ShippedQuantity = ShippedQuantity;

        try
        {
            //if (BLL.Exists(HouseNo, ProductsBarCode))
            //{
            //    BLL.Update(model);
            //}
            //else
            //{
            BLL.Add(model);
            //}
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// 仓库明细  流出账
    /// </summary>
    /// <param name="HouseNo">仓库流水——进出仓库唯一值</param>
    /// <param name="WaterType">类型（1 采购入库，2 销售出库，3 直接入库，4 直接出库）</param>
    /// <param name="ProductsName">仓库流水——产品名称</param>
    /// <param name="ProductsBarCode">仓库流水——编码（条形码）</param>
    /// <param name="ProductsPattern">仓库流水——产品型号</param>
    /// <param name="ProductsUnits">仓库流水——单位</param>
    /// <param name="WaterHousePack">仓库流水——产品包装</param>
    /// <param name="WaterHouseAmount">仓库流水——数量</param>
    /// <param name="WaterHouseUnitPrice">仓库流水——单价(原采购单价)</param>
    /// <param name="WaterHouseDiscount">仓库流水——计价调节(原调价平均)</param>
    /// <param name="WaterHouseTotalNet">仓库流水——净值合计(原净值平均)</param>
    /// <param name="WaterSupperUnitsName">仓库流水——往来单位名称</param>
    /// <param name="WaterUnionOrderNo">仓库流水——关联单号</param>
    /// <param name="WaterDoStaffNo">操作者唯一值</param>
    protected void BluidWareHouse_Ownall_Water(string HouseNo, int WaterType, string ProductsName, string ProductsBarCode, string ProductsPattern, string ProductsUnits, string WaterHousePack, int WaterHouseAmount, decimal WaterHouseUnitPrice, decimal WaterHouseDiscount, decimal WaterHouseTotalNet, string WaterSupperUnitsName, string WaterUnionOrderNo, string WaterDoStaffNo)
    {
        KNet.BLL.KNet_WareHouse_Ownall_Water BLL = new KNet.BLL.KNet_WareHouse_Ownall_Water();
        KNet.Model.KNet_WareHouse_Ownall_Water model = new KNet.Model.KNet_WareHouse_Ownall_Water();

        model.HouseNo = HouseNo;
        model.WaterType =WaterType;
        model.WaterDateTime = DateTime.Now;
        model.ProductsName = ProductsName;
        model.ProductsBarCode = ProductsBarCode;
        model.ProductsPattern = ProductsPattern;
        model.ProductsUnits = ProductsUnits;
        model.WaterHousePack = WaterHousePack;
        model.WaterHouseAmount = WaterHouseAmount;
        model.WaterHouseUnitPrice = WaterHouseUnitPrice;
        model.WaterHouseDiscount = WaterHouseDiscount;
        model.WaterHouseTotalNet = WaterHouseTotalNet;
        model.WaterSupperUnitsName = WaterSupperUnitsName;
        model.WaterUnionOrderNo = WaterUnionOrderNo;
        model.WaterDoStaffNo = WaterDoStaffNo;


        try
        {
            BLL.Add(model);
        }
        catch { }
    }

}
