using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Zl_Project_Record:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Zl_Project_Record 
{
public Zl_Project_Record()
{}
#region 
private string _ZPR_ID;
private string _ZPR_Code;
private string _ZPR_Title;
private DateTime _ZPR_STime;
private string _ZPR_Flow;
private int _ZPR_State =0 ;
private string _ZPR_Remarks;
private int _ZPR_Del =0 ;
private DateTime _ZPR_CTime;
private string _ZPR_Creator;
private DateTime _ZPR_MTime;
private string _ZPR_Mender;
private string _ZPR_SampleID;
private string _ZPR_SampleName;
private int _ZPR_Type =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_ID	 
{
set{ _ZPR_ID = value;}
get{ return _ZPR_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_Code	 
{
set{ _ZPR_Code = value;}
get{ return _ZPR_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_Title	 
{
set{ _ZPR_Title = value;}
get{ return _ZPR_Title;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPR_STime	 
{
set{ _ZPR_STime = value;}
get{ return _ZPR_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_Flow	 
{
set{ _ZPR_Flow = value;}
get{ return _ZPR_Flow;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPR_State	 
{
set{ _ZPR_State = value;}
get{ return _ZPR_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_Remarks	 
{
set{ _ZPR_Remarks = value;}
get{ return _ZPR_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPR_Del	 
{
set{ _ZPR_Del = value;}
get{ return _ZPR_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPR_CTime	 
{
set{ _ZPR_CTime = value;}
get{ return _ZPR_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_Creator	 
{
set{ _ZPR_Creator = value;}
get{ return _ZPR_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPR_MTime	 
{
set{ _ZPR_MTime = value;}
get{ return _ZPR_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_Mender	 
{
set{ _ZPR_Mender = value;}
get{ return _ZPR_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_SampleID	 
{
set{ _ZPR_SampleID = value;}
get{ return _ZPR_SampleID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPR_SampleName	 
{
set{ _ZPR_SampleName = value;}
get{ return _ZPR_SampleName;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPR_Type	 
{
set{ _ZPR_Type = value;}
get{ return _ZPR_Type;}
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
