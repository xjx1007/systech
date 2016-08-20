using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Xs_Sales_Freight:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Xs_Sales_Freight 
{
public Xs_Sales_Freight()
{}
#region 
private string _XSF_ID;
private string _XSF_Code;
private string _XSF_FID;
private DateTime _XSF_Stime;
private string _XSF_Description;
private string _XSF_Type;
private string _XSF_CustomerValue;
private string _XSF_CustomerName;
private decimal _XSF_FPercent;
private decimal _XSF_FMoney;
private decimal _XSF_Percent;
private decimal _XSF_Money;
private decimal _XSF_TotalMoney;
private int _XSF_TotalNumber =0 ;
private decimal _XSF_Price;
private string _XSF_Remarks;
private int _XSF_CheckYN =0 ;
private string _XSF_Flow;
private int _XSF_Del =0 ;
private DateTime _XSF_CTime;
private string _XSF_Creator;
private DateTime _XSF_MTime;
private string _XSF_Mender;
private string _XSF_KDNameCode;
private string _XSF_KDName;
private string _XSF_KDCode;
private string _XSF_State;
private string _XSF_FSuppNo;
private string _XSF_Address;
private string _XSF_DutyPerson;
private string _XSF_WuliuType;
private decimal _XSF_WuliuPrice;
private decimal _XSF_WuliuMoney;
private int _XSF_TimeDays =0 ;
private decimal _XSF_MinMoney;
private decimal _XSF_PickUpCost;
private decimal _XSF_DeliveryFee;
private decimal _XSF_UpstairsCost;
private decimal _XSF_UpstairsCostMoney;
private decimal _XSF_WareHouseEntry150Low;
private decimal _XSF_Insured;
private decimal _XSF_InsuredMoney;
private decimal _XSF_SignBill;
private string _XSF_BigLateTime;
private decimal _XSF_Weight;
private string _XSF_WeightDetails;
private decimal _XSF_Volume;
private string _XSF_VolumeDetails;
private string _XSF_TotalMoneyDetails;
private string _XSF_WuliuID;
private string _XSF_Province;
private string _XSF_City;

    
#endregion
#region 属性设计器

 /// <summary>
 /// 主键
 /// </summary>
public  string  XSF_ID	 
{
set{ _XSF_ID = value;}
get{ return _XSF_ID;}
}
 /// <summary>
 /// 编号
 /// </summary>
public  string  XSF_Code	 
{
set{ _XSF_Code = value;}
get{ return _XSF_Code;}
}
 /// <summary>
 /// 来源
 /// </summary>
public  string  XSF_FID	 
{
set{ _XSF_FID = value;}
get{ return _XSF_FID;}
}
 /// <summary>
 /// 日期
 /// </summary>
public DateTime XSF_Stime	 
{
set{ _XSF_Stime = value;}
get{ return _XSF_Stime;}
}
 /// <summary>
 /// 原因
 /// </summary>
public  string  XSF_Description	 
{
set{ _XSF_Description = value;}
get{ return _XSF_Description;}
}
 /// <summary>
 /// 类型
 /// </summary>
public  string  XSF_Type	 
{
set{ _XSF_Type = value;}
get{ return _XSF_Type;}
}
 /// <summary>
 /// 客户值
 /// </summary>
public  string  XSF_CustomerValue	 
{
set{ _XSF_CustomerValue = value;}
get{ return _XSF_CustomerValue;}
}
 /// <summary>
 /// 客户名称
 /// </summary>
public  string  XSF_CustomerName	 
{
set{ _XSF_CustomerName = value;}
get{ return _XSF_CustomerName;}
}
 /// <summary>
 /// 客户承担
 /// </summary>
public decimal XSF_FPercent	 
{
set{ _XSF_FPercent = value;}
get{ return _XSF_FPercent;}
}
 /// <summary>
 /// 承担金额
 /// </summary>
public decimal XSF_FMoney	 
{
set{ _XSF_FMoney = value;}
get{ return _XSF_FMoney;}
}
 /// <summary>
 /// 士腾承担
 /// </summary>
public decimal XSF_Percent	 
{
set{ _XSF_Percent = value;}
get{ return _XSF_Percent;}
}
 /// <summary>
 /// 承担金额
 /// </summary>
public decimal XSF_Money	 
{
set{ _XSF_Money = value;}
get{ return _XSF_Money;}
}
 /// <summary>
 /// 总金额
 /// </summary>
public decimal XSF_TotalMoney	 
{
set{ _XSF_TotalMoney = value;}
get{ return _XSF_TotalMoney;}
}
 /// <summary>
 /// 总数量
 /// </summary>
public int XSF_TotalNumber	 
{
set{ _XSF_TotalNumber = value;}
get{ return _XSF_TotalNumber;}
}
 /// <summary>
 /// 单价
 /// </summary>
public decimal XSF_Price	 
{
set{ _XSF_Price = value;}
get{ return _XSF_Price;}
}
 /// <summary>
 /// 备注
 /// </summary>
public  string  XSF_Remarks	 
{
set{ _XSF_Remarks = value;}
get{ return _XSF_Remarks;}
}
 /// <summary>
 /// 是否审核
 /// </summary>
public int XSF_CheckYN	 
{
set{ _XSF_CheckYN = value;}
get{ return _XSF_CheckYN;}
}
 /// <summary>
 /// 审批流程
 /// </summary>
public  string  XSF_Flow	 
{
set{ _XSF_Flow = value;}
get{ return _XSF_Flow;}
}
 /// <summary>
 /// 删除
 /// </summary>
public int XSF_Del	 
{
set{ _XSF_Del = value;}
get{ return _XSF_Del;}
}
 /// <summary>
 /// 创建时间
 /// </summary>
public DateTime XSF_CTime	 
{
set{ _XSF_CTime = value;}
get{ return _XSF_CTime;}
}
 /// <summary>
 /// 创建人
 /// </summary>
public  string  XSF_Creator	 
{
set{ _XSF_Creator = value;}
get{ return _XSF_Creator;}
}
 /// <summary>
 /// 修改时间
 /// </summary>
public DateTime XSF_MTime	 
{
set{ _XSF_MTime = value;}
get{ return _XSF_MTime;}
}
 /// <summary>
 /// 修改人
 /// </summary>
public  string  XSF_Mender	 
{
set{ _XSF_Mender = value;}
get{ return _XSF_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_KDNameCode	 
{
set{ _XSF_KDNameCode = value;}
get{ return _XSF_KDNameCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_KDName	 
{
set{ _XSF_KDName = value;}
get{ return _XSF_KDName;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_KDCode	 
{
set{ _XSF_KDCode = value;}
get{ return _XSF_KDCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_State	 
{
set{ _XSF_State = value;}
get{ return _XSF_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_FSuppNo	 
{
set{ _XSF_FSuppNo = value;}
get{ return _XSF_FSuppNo;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_Address	 
{
set{ _XSF_Address = value;}
get{ return _XSF_Address;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_DutyPerson	 
{
set{ _XSF_DutyPerson = value;}
get{ return _XSF_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_WuliuType	 
{
set{ _XSF_WuliuType = value;}
get{ return _XSF_WuliuType;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_WuliuPrice	 
{
set{ _XSF_WuliuPrice = value;}
get{ return _XSF_WuliuPrice;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_WuliuMoney	 
{
set{ _XSF_WuliuMoney = value;}
get{ return _XSF_WuliuMoney;}
}
 /// <summary>
 /// 
 /// </summary>
public int XSF_TimeDays	 
{
set{ _XSF_TimeDays = value;}
get{ return _XSF_TimeDays;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_MinMoney	 
{
set{ _XSF_MinMoney = value;}
get{ return _XSF_MinMoney;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_PickUpCost	 
{
set{ _XSF_PickUpCost = value;}
get{ return _XSF_PickUpCost;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_DeliveryFee	 
{
set{ _XSF_DeliveryFee = value;}
get{ return _XSF_DeliveryFee;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_UpstairsCost	 
{
set{ _XSF_UpstairsCost = value;}
get{ return _XSF_UpstairsCost;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_UpstairsCostMoney	 
{
set{ _XSF_UpstairsCostMoney = value;}
get{ return _XSF_UpstairsCostMoney;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_WareHouseEntry150Low	 
{
set{ _XSF_WareHouseEntry150Low = value;}
get{ return _XSF_WareHouseEntry150Low;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_Insured	 
{
set{ _XSF_Insured = value;}
get{ return _XSF_Insured;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_InsuredMoney	 
{
set{ _XSF_InsuredMoney = value;}
get{ return _XSF_InsuredMoney;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_SignBill	 
{
set{ _XSF_SignBill = value;}
get{ return _XSF_SignBill;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_BigLateTime	 
{
set{ _XSF_BigLateTime = value;}
get{ return _XSF_BigLateTime;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_Weight	 
{
set{ _XSF_Weight = value;}
get{ return _XSF_Weight;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_WeightDetails	 
{
set{ _XSF_WeightDetails = value;}
get{ return _XSF_WeightDetails;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XSF_Volume	 
{
set{ _XSF_Volume = value;}
get{ return _XSF_Volume;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_VolumeDetails	 
{
set{ _XSF_VolumeDetails = value;}
get{ return _XSF_VolumeDetails;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XSF_TotalMoneyDetails	 
{
set{ _XSF_TotalMoneyDetails = value;}
get{ return _XSF_TotalMoneyDetails;}
}

public string XSF_WuliuID	 
{
    set { _XSF_WuliuID = value; }
    get { return _XSF_WuliuID; }
}

public string XSF_Province
{
    set { _XSF_Province = value; }
    get { return _XSF_Province; }
}

public string XSF_City
{
    set { _XSF_City = value; }
    get { return _XSF_City; }
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
