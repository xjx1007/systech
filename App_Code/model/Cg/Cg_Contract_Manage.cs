using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Cg_Contract_Manage:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Cg_Contract_Manage 
{
public Cg_Contract_Manage()
{}
#region 
private string _CCM_ID;
private string _CCM_Code;
private string _CCM_Type;
private string _CCM_Title;
private string _CCM_CustomerValue;
private string _CCM_DutyPerson;
private DateTime _CCM_STime;
private string _CCM_Flow;
private string _CCM_Remarks;
private int _CCM_Del =0 ;
private string _CCM_Creator;
private DateTime _CCM_CTime;
private string _CCM_Mender;
private DateTime _CCM_MTime;
private int _CCM_OrderNo =0 ;
private int _CCM_CheckYN =0 ;
private string _CCM_PayMent;
private string _CCM_BillType;
private string _CCM_TechnicalRequire;
private string _CCM_ProductPackaging;
private string _CCM_QualityRequire;
private string _CCM_WarrantyPeriod;
private string _CCM_DeliveryReqyire;
private string _CCM_FhDetails;
private ArrayList _Arr_Details;
public ArrayList Arr_Details
{
    set { _Arr_Details = value; }

    get { return _Arr_Details; }
}
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CCM_ID	 
{
set{ _CCM_ID = value;}
get{ return _CCM_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_Code	 
{
set{ _CCM_Code = value;}
get{ return _CCM_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_Type	 
{
set{ _CCM_Type = value;}
get{ return _CCM_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_Title	 
{
set{ _CCM_Title = value;}
get{ return _CCM_Title;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_CustomerValue	 
{
set{ _CCM_CustomerValue = value;}
get{ return _CCM_CustomerValue;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_DutyPerson	 
{
set{ _CCM_DutyPerson = value;}
get{ return _CCM_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CCM_STime	 
{
set{ _CCM_STime = value;}
get{ return _CCM_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_Flow	 
{
set{ _CCM_Flow = value;}
get{ return _CCM_Flow;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_Remarks	 
{
set{ _CCM_Remarks = value;}
get{ return _CCM_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int CCM_Del	 
{
set{ _CCM_Del = value;}
get{ return _CCM_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_Creator	 
{
set{ _CCM_Creator = value;}
get{ return _CCM_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CCM_CTime	 
{
set{ _CCM_CTime = value;}
get{ return _CCM_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_Mender	 
{
set{ _CCM_Mender = value;}
get{ return _CCM_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CCM_MTime	 
{
set{ _CCM_MTime = value;}
get{ return _CCM_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int CCM_OrderNo	 
{
set{ _CCM_OrderNo = value;}
get{ return _CCM_OrderNo;}
}
 /// <summary>
 /// 
 /// </summary>
public int CCM_CheckYN	 
{
set{ _CCM_CheckYN = value;}
get{ return _CCM_CheckYN;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_PayMent	 
{
set{ _CCM_PayMent = value;}
get{ return _CCM_PayMent;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_BillType	 
{
set{ _CCM_BillType = value;}
get{ return _CCM_BillType;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_TechnicalRequire	 
{
set{ _CCM_TechnicalRequire = value;}
get{ return _CCM_TechnicalRequire;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_ProductPackaging	 
{
set{ _CCM_ProductPackaging = value;}
get{ return _CCM_ProductPackaging;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_QualityRequire	 
{
set{ _CCM_QualityRequire = value;}
get{ return _CCM_QualityRequire;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_WarrantyPeriod	 
{
set{ _CCM_WarrantyPeriod = value;}
get{ return _CCM_WarrantyPeriod;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_DeliveryReqyire	 
{
set{ _CCM_DeliveryReqyire = value;}
get{ return _CCM_DeliveryReqyire;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CCM_FhDetails	 
{
set{ _CCM_FhDetails = value;}
get{ return _CCM_FhDetails;}
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
