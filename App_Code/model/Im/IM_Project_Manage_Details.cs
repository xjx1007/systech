using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// IM_Project_Manage_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class IM_Project_Manage_Details 
{
public IM_Project_Manage_Details()
{}
#region 
private string _IPMD_ID;
private string _IPMD_IPMID;
private string _IPMD_FID;
private int _IPMD_Type =0 ;
private string _IPMD_Name;
private int _IPMD_Days =0 ;
private int _IPMD_FloatingDays =0 ;
private string _IPMD_PreTask;
private DateTime _IPMD_EarlyBeginTime;
private DateTime _IPMD_EarlyEndTime;
private DateTime _IPMD_AtLatestBeginTime;
private DateTime _IPMD_AtLatestEndTime;
private string _IPMD_DutyPerson;
private string _IPMD_Executor;
private string _IPMD_Remarks;
private string _IPMD_Creator;
private DateTime _IPMD_CTime;
private int _IPMD_Del =0 ;
private string _IPMD_Mender;
private DateTime _IPMD_MTime;
private string _IPMD_FTaskID;
private int _IPMD_Level =0 ;
private int _IPMD_WorkType =0 ;
private int _IPMD_State =0 ;
private int _IPMD_ProjectType =0 ;
private int _IPMD_Import =0 ;
private decimal _IPMD_Precent;
private string _IPMD_Persons;
private int _IPMD_DaysType =0 ;
private int _IPMD_HolidayType =0 ;
private int _IPMD_UseDays =0 ;
private int _IPMD_LeftDays =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_ID	 
{
set{ _IPMD_ID = value;}
get{ return _IPMD_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_IPMID	 
{
set{ _IPMD_IPMID = value;}
get{ return _IPMD_IPMID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_FID	 
{
set{ _IPMD_FID = value;}
get{ return _IPMD_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_Type	 
{
set{ _IPMD_Type = value;}
get{ return _IPMD_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_Name	 
{
set{ _IPMD_Name = value;}
get{ return _IPMD_Name;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_Days	 
{
set{ _IPMD_Days = value;}
get{ return _IPMD_Days;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_FloatingDays	 
{
set{ _IPMD_FloatingDays = value;}
get{ return _IPMD_FloatingDays;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_PreTask	 
{
set{ _IPMD_PreTask = value;}
get{ return _IPMD_PreTask;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPMD_EarlyBeginTime	 
{
set{ _IPMD_EarlyBeginTime = value;}
get{ return _IPMD_EarlyBeginTime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPMD_EarlyEndTime	 
{
set{ _IPMD_EarlyEndTime = value;}
get{ return _IPMD_EarlyEndTime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPMD_AtLatestBeginTime	 
{
set{ _IPMD_AtLatestBeginTime = value;}
get{ return _IPMD_AtLatestBeginTime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPMD_AtLatestEndTime	 
{
set{ _IPMD_AtLatestEndTime = value;}
get{ return _IPMD_AtLatestEndTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_DutyPerson	 
{
set{ _IPMD_DutyPerson = value;}
get{ return _IPMD_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_Executor	 
{
set{ _IPMD_Executor = value;}
get{ return _IPMD_Executor;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_Remarks	 
{
set{ _IPMD_Remarks = value;}
get{ return _IPMD_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_Creator	 
{
set{ _IPMD_Creator = value;}
get{ return _IPMD_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPMD_CTime	 
{
set{ _IPMD_CTime = value;}
get{ return _IPMD_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_Del	 
{
set{ _IPMD_Del = value;}
get{ return _IPMD_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_Mender	 
{
set{ _IPMD_Mender = value;}
get{ return _IPMD_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPMD_MTime	 
{
set{ _IPMD_MTime = value;}
get{ return _IPMD_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_FTaskID	 
{
set{ _IPMD_FTaskID = value;}
get{ return _IPMD_FTaskID;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_Level	 
{
set{ _IPMD_Level = value;}
get{ return _IPMD_Level;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_WorkType	 
{
set{ _IPMD_WorkType = value;}
get{ return _IPMD_WorkType;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_State	 
{
set{ _IPMD_State = value;}
get{ return _IPMD_State;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_ProjectType	 
{
set{ _IPMD_ProjectType = value;}
get{ return _IPMD_ProjectType;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_Import	 
{
set{ _IPMD_Import = value;}
get{ return _IPMD_Import;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal IPMD_Precent	 
{
set{ _IPMD_Precent = value;}
get{ return _IPMD_Precent;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPMD_Persons	 
{
set{ _IPMD_Persons = value;}
get{ return _IPMD_Persons;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_DaysType	 
{
set{ _IPMD_DaysType = value;}
get{ return _IPMD_DaysType;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_HolidayType	 
{
set{ _IPMD_HolidayType = value;}
get{ return _IPMD_HolidayType;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_UseDays	 
{
set{ _IPMD_UseDays = value;}
get{ return _IPMD_UseDays;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPMD_LeftDays	 
{
set{ _IPMD_LeftDays = value;}
get{ return _IPMD_LeftDays;}
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
