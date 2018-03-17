using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Xs_Contract_Manage_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Xs_Contract_Manage_Details 
{
public Xs_Contract_Manage_Details()
{}
#region 
private string _XCMD_ID;
private string _XCMD_ContractNo;
private string _XCMD_ProductsName;
private string _XCMD_ProductsBarCode;
private string _XCMD_ProductsPattern;
private string _XCMD_ProductsUnits;
private int _XCMD_ContractAmount =0 ;
private decimal _XCMD_ContractUnitPrice;
private decimal _XCMD_ContractDiscount;
private decimal _XCMD_ContractTotalNet;
private decimal _XCMD_Contract_SalesUnitPrice;
private decimal _XCMD_Contract_SalesDiscount;
private decimal _XCMD_Contract_SalesTotalNet;
private string _XCMD_ContractRemarks;
private int _XCMD_ContractReceiving =0 ;
private DateTime _XCMD_DateTime;
private string _XCMD_OwnallPID;
private string _XCMD_Battery;
private string _XCMD_Manual;
private int _XCMD_BNumber =0 ;
private int _XCMD_OrderBNumber = 0;
    
private string _XCMD_OrderNumber;
private string _XCMD_MaterNumber;
private string _XCMD_IsFollow;
private string _XCMD_PlanNumber;
private string _XCMD_MaterPattern;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_ID	 
{
set{ _XCMD_ID = value;}
get{ return _XCMD_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_ContractNo	 
{
set{ _XCMD_ContractNo = value;}
get{ return _XCMD_ContractNo;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_ProductsName	 
{
set{ _XCMD_ProductsName = value;}
get{ return _XCMD_ProductsName;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_ProductsBarCode	 
{
set{ _XCMD_ProductsBarCode = value;}
get{ return _XCMD_ProductsBarCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_ProductsPattern	 
{
set{ _XCMD_ProductsPattern = value;}
get{ return _XCMD_ProductsPattern;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_ProductsUnits	 
{
set{ _XCMD_ProductsUnits = value;}
get{ return _XCMD_ProductsUnits;}
}
 /// <summary>
 /// 
 /// </summary>
public int XCMD_ContractAmount	 
{
set{ _XCMD_ContractAmount = value;}
get{ return _XCMD_ContractAmount;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XCMD_ContractUnitPrice	 
{
set{ _XCMD_ContractUnitPrice = value;}
get{ return _XCMD_ContractUnitPrice;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XCMD_ContractDiscount	 
{
set{ _XCMD_ContractDiscount = value;}
get{ return _XCMD_ContractDiscount;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XCMD_ContractTotalNet	 
{
set{ _XCMD_ContractTotalNet = value;}
get{ return _XCMD_ContractTotalNet;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XCMD_Contract_SalesUnitPrice	 
{
set{ _XCMD_Contract_SalesUnitPrice = value;}
get{ return _XCMD_Contract_SalesUnitPrice;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XCMD_Contract_SalesDiscount	 
{
set{ _XCMD_Contract_SalesDiscount = value;}
get{ return _XCMD_Contract_SalesDiscount;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal XCMD_Contract_SalesTotalNet	 
{
set{ _XCMD_Contract_SalesTotalNet = value;}
get{ return _XCMD_Contract_SalesTotalNet;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_ContractRemarks	 
{
set{ _XCMD_ContractRemarks = value;}
get{ return _XCMD_ContractRemarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int XCMD_ContractReceiving	 
{
set{ _XCMD_ContractReceiving = value;}
get{ return _XCMD_ContractReceiving;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime XCMD_DateTime	 
{
set{ _XCMD_DateTime = value;}
get{ return _XCMD_DateTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_OwnallPID	 
{
set{ _XCMD_OwnallPID = value;}
get{ return _XCMD_OwnallPID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_Battery	 
{
set{ _XCMD_Battery = value;}
get{ return _XCMD_Battery;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_Manual	 
{
set{ _XCMD_Manual = value;}
get{ return _XCMD_Manual;}
}
 /// <summary>
 /// 
 /// </summary>
public int XCMD_BNumber	 
{
set{ _XCMD_BNumber = value;}
get{ return _XCMD_BNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public int XCMD_OrderBNumber	 
{
set{ _XCMD_OrderBNumber = value;}
get{ return _XCMD_OrderBNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public string XCMD_OrderNumber	 
{
    set { _XCMD_OrderNumber = value; }
    get { return _XCMD_OrderNumber; }
}
    
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_MaterNumber	 
{
set{ _XCMD_MaterNumber = value;}
get{ return _XCMD_MaterNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_IsFollow	 
{
set{ _XCMD_IsFollow = value;}
get{ return _XCMD_IsFollow;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_PlanNumber	 
{
set{ _XCMD_PlanNumber = value;}
get{ return _XCMD_PlanNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCMD_MaterPattern	 
{
set{ _XCMD_MaterPattern = value;}
get{ return _XCMD_MaterPattern;}
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
