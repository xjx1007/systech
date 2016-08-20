using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Zl_Produce_Problem:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Zl_Produce_Problem 
{
public Zl_Produce_Problem()
{}
#region 
private string _ZPP_ID;
private string _ZPP_Code;
private string _ZPP_ProdutsBarCode;
private string _ZPP_ScStage;
private string _ZPP_Title;
private string _ZPP_Type;
private string _ZPP_Text;
private DateTime _ZPP_STime;
private string _ZPP_DutyPerson;
private string _ZPP_DutyDepart;
private DateTime _ZPP_HopeDate;
private int _ZPP_State =0 ;
private string _ZPP_Cause;
private string _ZPP_Temporary;
private DateTime _ZPP_DoneTime;
private int _ZPP_ClosedState =0 ;
private string _ZPP_Result;
private string _ZPP_ClosedType;
private int _ZPP_Del =0 ;
private string _ZPP_Creator;
private DateTime _ZPP_CTime;
private string _ZPP_Mender;
private DateTime _ZPP_MTime;
private string _ZPP_Flow;
private string _ZPP_FlowStep;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_ID	 
{
set{ _ZPP_ID = value;}
get{ return _ZPP_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Code	 
{
set{ _ZPP_Code = value;}
get{ return _ZPP_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_ProdutsBarCode	 
{
set{ _ZPP_ProdutsBarCode = value;}
get{ return _ZPP_ProdutsBarCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_ScStage	 
{
set{ _ZPP_ScStage = value;}
get{ return _ZPP_ScStage;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Title	 
{
set{ _ZPP_Title = value;}
get{ return _ZPP_Title;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Type	 
{
set{ _ZPP_Type = value;}
get{ return _ZPP_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Text	 
{
set{ _ZPP_Text = value;}
get{ return _ZPP_Text;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPP_STime	 
{
set{ _ZPP_STime = value;}
get{ return _ZPP_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_DutyPerson	 
{
set{ _ZPP_DutyPerson = value;}
get{ return _ZPP_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_DutyDepart	 
{
set{ _ZPP_DutyDepart = value;}
get{ return _ZPP_DutyDepart;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPP_HopeDate	 
{
set{ _ZPP_HopeDate = value;}
get{ return _ZPP_HopeDate;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPP_State	 
{
set{ _ZPP_State = value;}
get{ return _ZPP_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Cause	 
{
set{ _ZPP_Cause = value;}
get{ return _ZPP_Cause;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Temporary	 
{
set{ _ZPP_Temporary = value;}
get{ return _ZPP_Temporary;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPP_DoneTime	 
{
set{ _ZPP_DoneTime = value;}
get{ return _ZPP_DoneTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPP_ClosedState	 
{
set{ _ZPP_ClosedState = value;}
get{ return _ZPP_ClosedState;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Result	 
{
set{ _ZPP_Result = value;}
get{ return _ZPP_Result;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_ClosedType	 
{
set{ _ZPP_ClosedType = value;}
get{ return _ZPP_ClosedType;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPP_Del	 
{
set{ _ZPP_Del = value;}
get{ return _ZPP_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Creator	 
{
set{ _ZPP_Creator = value;}
get{ return _ZPP_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPP_CTime	 
{
set{ _ZPP_CTime = value;}
get{ return _ZPP_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Mender	 
{
set{ _ZPP_Mender = value;}
get{ return _ZPP_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPP_MTime	 
{
set{ _ZPP_MTime = value;}
get{ return _ZPP_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Flow	 
{
set{ _ZPP_Flow = value;}
get{ return _ZPP_Flow;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_FlowStep	 
{
set{ _ZPP_FlowStep = value;}
get{ return _ZPP_FlowStep;}
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
