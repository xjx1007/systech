using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// IM_Project_Manage:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class IM_Project_Manage 
{
public IM_Project_Manage()
{}
#region 
private string _IPM_ID;
private string _IPM_Code;
private string _IPM_Name;
private string _IPM_DutyPerson;
private string _IPM_Import;
private string _IPM_Persons;
private string _IPM_Type;
private string _IPM_Class;
private DateTime _IPM_STime;
private DateTime _IPM_EndTime;
private int _IPM_Days =0 ;
private string _IPM_DaysType;
private string _IPM_State;
private string _IPM_CustomerValue;
private decimal _IPM_Money;
private int _IPM_IsDetailsMoney =0 ;
private string _IPM_Remarks;
private string _IPM_Creator;
private DateTime _IPM_CTime;
private int _IPM_Del =0 ;
private string _IPM_Mender;
private DateTime _IPM_MTime;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  IPM_ID	 
{
set{ _IPM_ID = value;}
get{ return _IPM_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Code	 
{
set{ _IPM_Code = value;}
get{ return _IPM_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Name	 
{
set{ _IPM_Name = value;}
get{ return _IPM_Name;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_DutyPerson	 
{
set{ _IPM_DutyPerson = value;}
get{ return _IPM_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Import	 
{
set{ _IPM_Import = value;}
get{ return _IPM_Import;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Persons	 
{
set{ _IPM_Persons = value;}
get{ return _IPM_Persons;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Type	 
{
set{ _IPM_Type = value;}
get{ return _IPM_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Class	 
{
set{ _IPM_Class = value;}
get{ return _IPM_Class;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPM_STime	 
{
set{ _IPM_STime = value;}
get{ return _IPM_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPM_EndTime	 
{
set{ _IPM_EndTime = value;}
get{ return _IPM_EndTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPM_Days	 
{
set{ _IPM_Days = value;}
get{ return _IPM_Days;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_DaysType	 
{
set{ _IPM_DaysType = value;}
get{ return _IPM_DaysType;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_State	 
{
set{ _IPM_State = value;}
get{ return _IPM_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_CustomerValue	 
{
set{ _IPM_CustomerValue = value;}
get{ return _IPM_CustomerValue;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal IPM_Money	 
{
set{ _IPM_Money = value;}
get{ return _IPM_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPM_IsDetailsMoney	 
{
set{ _IPM_IsDetailsMoney = value;}
get{ return _IPM_IsDetailsMoney;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Remarks	 
{
set{ _IPM_Remarks = value;}
get{ return _IPM_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Creator	 
{
set{ _IPM_Creator = value;}
get{ return _IPM_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPM_CTime	 
{
set{ _IPM_CTime = value;}
get{ return _IPM_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPM_Del	 
{
set{ _IPM_Del = value;}
get{ return _IPM_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPM_Mender	 
{
set{ _IPM_Mender = value;}
get{ return _IPM_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPM_MTime	 
{
set{ _IPM_MTime = value;}
get{ return _IPM_MTime;}
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
