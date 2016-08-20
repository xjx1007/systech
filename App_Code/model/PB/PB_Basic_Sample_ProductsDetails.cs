using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// PB_Basic_Sample_ProductsDetails:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class PB_Basic_Sample_ProductsDetails 
{
public PB_Basic_Sample_ProductsDetails()
{}
#region 
private string _PBSP_ID;
private string _PBSP_FID;
private string _PBSP_ProductsType;
private string _PBSP_ProductsTypeName;
private string _PBSP_SuppNo;
private string _PBSP_SuppName;
private string _PBSP_ProductsEdition;
private int _PBSP_Number =0 ;
private decimal _PBSP_Price;
private string _PBSP_Remarks;
private string _PBSP_ProductsBarCode;
private string _PBSP_FProductsBarCode;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_ID	 
{
set{ _PBSP_ID = value;}
get{ return _PBSP_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_FID	 
{
set{ _PBSP_FID = value;}
get{ return _PBSP_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_ProductsType	 
{
set{ _PBSP_ProductsType = value;}
get{ return _PBSP_ProductsType;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_ProductsTypeName	 
{
set{ _PBSP_ProductsTypeName = value;}
get{ return _PBSP_ProductsTypeName;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_SuppNo	 
{
set{ _PBSP_SuppNo = value;}
get{ return _PBSP_SuppNo;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_SuppName	 
{
set{ _PBSP_SuppName = value;}
get{ return _PBSP_SuppName;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_ProductsEdition	 
{
set{ _PBSP_ProductsEdition = value;}
get{ return _PBSP_ProductsEdition;}
}
 /// <summary>
 /// 
 /// </summary>
public int PBSP_Number	 
{
set{ _PBSP_Number = value;}
get{ return _PBSP_Number;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal PBSP_Price	 
{
set{ _PBSP_Price = value;}
get{ return _PBSP_Price;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_Remarks	 
{
set{ _PBSP_Remarks = value;}
get{ return _PBSP_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_ProductsBarCode	 
{
set{ _PBSP_ProductsBarCode = value;}
get{ return _PBSP_ProductsBarCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBSP_FProductsBarCode	 
{
set{ _PBSP_FProductsBarCode = value;}
get{ return _PBSP_FProductsBarCode;}
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
