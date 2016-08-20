using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// CG_Account_Bill_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class CG_Account_Bill_Details 
{
public CG_Account_Bill_Details()
{}
#region 
private string _CABD_ID;
private string _CABD_FID;
private string _CABD_CheckDetailsID;
private string _CABD_WareHouseDetailsID;
private string _CABD_ProductsBarCode;
private decimal _CABD_KpNumber;
private decimal _CABD_KPPrice;
private decimal _CABD_KpMoney;
private string _CABD_FPCode;
private string _CABD_FPCode1;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CABD_ID	 
{
set{ _CABD_ID = value;}
get{ return _CABD_ID;}
}
public string CABD_FPCode	 
{
    set { _CABD_FPCode = value; }
    get { return _CABD_FPCode; }
}
public string CABD_FPCode1
{
    set { _CABD_FPCode1 = value; }
    get { return _CABD_FPCode1; }
}
    
 /// <summary>
 /// 
 /// </summary>
public  string  CABD_FID	 
{
set{ _CABD_FID = value;}
get{ return _CABD_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CABD_CheckDetailsID	 
{
set{ _CABD_CheckDetailsID = value;}
get{ return _CABD_CheckDetailsID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CABD_WareHouseDetailsID	 
{
set{ _CABD_WareHouseDetailsID = value;}
get{ return _CABD_WareHouseDetailsID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CABD_ProductsBarCode	 
{
set{ _CABD_ProductsBarCode = value;}
get{ return _CABD_ProductsBarCode;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CABD_KpNumber	 
{
set{ _CABD_KpNumber = value;}
get{ return _CABD_KpNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CABD_KPPrice	 
{
set{ _CABD_KPPrice = value;}
get{ return _CABD_KPPrice;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CABD_KpMoney	 
{
set{ _CABD_KpMoney = value;}
get{ return _CABD_KpMoney;}
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
