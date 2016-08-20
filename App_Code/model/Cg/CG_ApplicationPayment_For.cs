using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// CG_ApplicationPayment_For:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class CG_ApplicationPayment_For 
{
public CG_ApplicationPayment_For()
{}
#region 
private string _CAF_ID;
private string _CAF_Code;
private string _CAF_Title;
private DateTime _CAF_STime;
private string _CAF_DutyPerson;
private decimal _CAF_TotalMoney;
private int _CAF_State =0 ;
private string _CAF_Remarks;
private int _CAF_Del =0 ;
private string _CAF_Creator;
private DateTime _CAF_CTime;
private string _CAF_Mender;
private DateTime _CAF_MTime;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CAF_ID	 
{
set{ _CAF_ID = value;}
get{ return _CAF_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAF_Code	 
{
set{ _CAF_Code = value;}
get{ return _CAF_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAF_Title	 
{
set{ _CAF_Title = value;}
get{ return _CAF_Title;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CAF_STime	 
{
set{ _CAF_STime = value;}
get{ return _CAF_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAF_DutyPerson	 
{
set{ _CAF_DutyPerson = value;}
get{ return _CAF_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CAF_TotalMoney	 
{
set{ _CAF_TotalMoney = value;}
get{ return _CAF_TotalMoney;}
}
 /// <summary>
 /// 
 /// </summary>
public int CAF_State	 
{
set{ _CAF_State = value;}
get{ return _CAF_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAF_Remarks	 
{
set{ _CAF_Remarks = value;}
get{ return _CAF_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int CAF_Del	 
{
set{ _CAF_Del = value;}
get{ return _CAF_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAF_Creator	 
{
set{ _CAF_Creator = value;}
get{ return _CAF_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CAF_CTime	 
{
set{ _CAF_CTime = value;}
get{ return _CAF_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAF_Mender	 
{
set{ _CAF_Mender = value;}
get{ return _CAF_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CAF_MTime	 
{
set{ _CAF_MTime = value;}
get{ return _CAF_MTime;}
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
