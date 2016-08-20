using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// ZL_Task_Instruction:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class ZL_Task_Instruction 
{
public ZL_Task_Instruction()
{}
#region 
private string _ZTI_ID;
private string _ZTI_Code;
private string _ZTI_ProductsBarCode;
private string _ZTI_Name;
private DateTime _ZTI_Stime;
private string _ZTI_DutyPerson;
private string _ZTI_Flow;
private string _ZTI_FlowStep;
private string _ZTI_Remarks;
private int _ZTI_State =0 ;
private int _ZTI_Del =0 ;
private DateTime _ZTI_CTime;
private string _ZTI_Creator;
private DateTime _ZTI_MTime;
private string _ZTI_Mender;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_ID	 
{
set{ _ZTI_ID = value;}
get{ return _ZTI_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_Code	 
{
set{ _ZTI_Code = value;}
get{ return _ZTI_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_ProductsBarCode	 
{
set{ _ZTI_ProductsBarCode = value;}
get{ return _ZTI_ProductsBarCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_Name	 
{
set{ _ZTI_Name = value;}
get{ return _ZTI_Name;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZTI_Stime	 
{
set{ _ZTI_Stime = value;}
get{ return _ZTI_Stime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_DutyPerson	 
{
set{ _ZTI_DutyPerson = value;}
get{ return _ZTI_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_Flow	 
{
set{ _ZTI_Flow = value;}
get{ return _ZTI_Flow;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_FlowStep	 
{
set{ _ZTI_FlowStep = value;}
get{ return _ZTI_FlowStep;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_Remarks	 
{
set{ _ZTI_Remarks = value;}
get{ return _ZTI_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZTI_State	 
{
set{ _ZTI_State = value;}
get{ return _ZTI_State;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZTI_Del	 
{
set{ _ZTI_Del = value;}
get{ return _ZTI_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZTI_CTime	 
{
set{ _ZTI_CTime = value;}
get{ return _ZTI_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_Creator	 
{
set{ _ZTI_Creator = value;}
get{ return _ZTI_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZTI_MTime	 
{
set{ _ZTI_MTime = value;}
get{ return _ZTI_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZTI_Mender	 
{
set{ _ZTI_Mender = value;}
get{ return _ZTI_Mender;}
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
