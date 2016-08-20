using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Wl_Customer_Price_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Wl_Customer_Price_Details 
{
public Wl_Customer_Price_Details()
{}
#region 
private string _WCPD_ID;
private string _WCPD_FID;
private string _WCPD_Provice;
private string _WCPD_City;
private string _WCPD_MinTime;
private string _WCPD_MaxTime;
private decimal _WCPD_MinMoney;
private decimal _WCPD_Price;
private decimal _WCPD_DeliveryFee;
private decimal _WCPD_UpstairsCost;
private decimal _WCPD_WarehouseEntry150Low;
private decimal _WCPD_WarehouseEntry150Up;
private decimal _WCPD_Insured;
private decimal _WCPD_SignBill;
private string _WCPD_BigLateTime;
private int _WCPD_Del =0 ;
private string _WCPD_Type;
private decimal _WCPD_PickUpCost;
private decimal _WCPD_DeliveryFeePrice;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_ID	 
{
set{ _WCPD_ID = value;}
get{ return _WCPD_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_FID	 
{
set{ _WCPD_FID = value;}
get{ return _WCPD_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_Provice	 
{
set{ _WCPD_Provice = value;}
get{ return _WCPD_Provice;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_City	 
{
set{ _WCPD_City = value;}
get{ return _WCPD_City;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_MinTime	 
{
set{ _WCPD_MinTime = value;}
get{ return _WCPD_MinTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_MaxTime	 
{
set{ _WCPD_MaxTime = value;}
get{ return _WCPD_MaxTime;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_MinMoney	 
{
set{ _WCPD_MinMoney = value;}
get{ return _WCPD_MinMoney;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_Price	 
{
set{ _WCPD_Price = value;}
get{ return _WCPD_Price;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_DeliveryFee	 
{
set{ _WCPD_DeliveryFee = value;}
get{ return _WCPD_DeliveryFee;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_UpstairsCost	 
{
set{ _WCPD_UpstairsCost = value;}
get{ return _WCPD_UpstairsCost;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_WarehouseEntry150Low	 
{
set{ _WCPD_WarehouseEntry150Low = value;}
get{ return _WCPD_WarehouseEntry150Low;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_WarehouseEntry150Up	 
{
set{ _WCPD_WarehouseEntry150Up = value;}
get{ return _WCPD_WarehouseEntry150Up;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_Insured	 
{
set{ _WCPD_Insured = value;}
get{ return _WCPD_Insured;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_SignBill	 
{
set{ _WCPD_SignBill = value;}
get{ return _WCPD_SignBill;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_BigLateTime	 
{
set{ _WCPD_BigLateTime = value;}
get{ return _WCPD_BigLateTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int WCPD_Del	 
{
set{ _WCPD_Del = value;}
get{ return _WCPD_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCPD_Type	 
{
set{ _WCPD_Type = value;}
get{ return _WCPD_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_PickUpCost	 
{
set{ _WCPD_PickUpCost = value;}
get{ return _WCPD_PickUpCost;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal WCPD_DeliveryFeePrice	 
{
set{ _WCPD_DeliveryFeePrice = value;}
get{ return _WCPD_DeliveryFeePrice;}
}
#endregion
#region 附加信息

	private string Temp;
	public string getTemp()
	{
		return Temp;
	}
	public void setTemp(string Temp)
	{
		this.Temp=Temp;
	}
	private ArrayList _Arr_Detail;
	public ArrayList Arr_Detail
	{
		 set{_Arr_Detail = value;}
	
		 get{return _Arr_Detail;}
	}
#endregion
}
}
