using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Cw_Bill_Expense_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Cw_Bill_Expense_Details 
{
public Cw_Bill_Expense_Details()
{}
#region 
private string _CBED_ID;
private string _CBED_FID;
private string _CBED_Used;
private string _CBED_Place;
private DateTime _CBED_StartTime;
private DateTime _CBED_EndTime;
private decimal _CBED_Money;
private string _CBED_Type;
private string _CBED_Remarks;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CBED_ID	 
{
set{ _CBED_ID = value;}
get{ return _CBED_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBED_FID	 
{
set{ _CBED_FID = value;}
get{ return _CBED_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBED_Used	 
{
set{ _CBED_Used = value;}
get{ return _CBED_Used;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBED_Place	 
{
set{ _CBED_Place = value;}
get{ return _CBED_Place;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBED_StartTime	 
{
set{ _CBED_StartTime = value;}
get{ return _CBED_StartTime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBED_EndTime	 
{
set{ _CBED_EndTime = value;}
get{ return _CBED_EndTime;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CBED_Money	 
{
set{ _CBED_Money = value;}
get{ return _CBED_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBED_Type	 
{
set{ _CBED_Type = value;}
get{ return _CBED_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBED_Remarks	 
{
set{ _CBED_Remarks = value;}
get{ return _CBED_Remarks;}
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
