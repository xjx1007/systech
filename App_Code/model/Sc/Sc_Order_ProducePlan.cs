using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Sc_Order_ProducePlan:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Sc_Order_ProducePlan 
{
public Sc_Order_ProducePlan()
{}
#region 
private string _SOP_ID;
private string _SOP_FID;
private string _SOP_PlanID;
private string _SOP_SuppNo;
private DateTime _SOP_STime;
private DateTime _SOP_BeginTime;
private DateTime _SOP_EndTime;
private int _SOP_ScNumber =0 ;
private int _SOP_LeftNumber =0 ;
private int _SOP_DayScNumber =0 ;
private string _SOP_Creator;
private DateTime _SOP_CTime;
private int _SOP_Del =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  SOP_ID	 
{
set{ _SOP_ID = value;}
get{ return _SOP_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  SOP_FID	 
{
set{ _SOP_FID = value;}
get{ return _SOP_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  SOP_PlanID	 
{
set{ _SOP_PlanID = value;}
get{ return _SOP_PlanID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  SOP_SuppNo	 
{
set{ _SOP_SuppNo = value;}
get{ return _SOP_SuppNo;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime SOP_STime	 
{
set{ _SOP_STime = value;}
get{ return _SOP_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime SOP_BeginTime	 
{
set{ _SOP_BeginTime = value;}
get{ return _SOP_BeginTime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime SOP_EndTime	 
{
set{ _SOP_EndTime = value;}
get{ return _SOP_EndTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int SOP_ScNumber	 
{
set{ _SOP_ScNumber = value;}
get{ return _SOP_ScNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public int SOP_LeftNumber	 
{
set{ _SOP_LeftNumber = value;}
get{ return _SOP_LeftNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public int SOP_DayScNumber	 
{
set{ _SOP_DayScNumber = value;}
get{ return _SOP_DayScNumber;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  SOP_Creator	 
{
set{ _SOP_Creator = value;}
get{ return _SOP_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime SOP_CTime	 
{
set{ _SOP_CTime = value;}
get{ return _SOP_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int SOP_Del	 
{
set{ _SOP_Del = value;}
get{ return _SOP_Del;}
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
