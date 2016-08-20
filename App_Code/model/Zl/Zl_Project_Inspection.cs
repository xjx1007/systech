using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Zl_Project_Inspection:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Zl_Project_Inspection 
{
public Zl_Project_Inspection()
{}
#region 
private string _ZPI_ID;
private string _ZPI_Code;
private string _ZPI_Title;
private DateTime _ZPI_STime;
private string _ZPI_Flow;
private int _ZPI_State =0 ;
private string _ZPI_Remarks;
private int _ZPI_Del =0 ;
private DateTime _ZPI_CTime;
private string _ZPI_Creator;
private DateTime _ZPI_MTime;
private string _ZPI_Mender;
private string _ZPI_SampleID;
private string _ZPI_SampleName;
private int _ZPI_Type =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_ID	 
{
set{ _ZPI_ID = value;}
get{ return _ZPI_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_Code	 
{
set{ _ZPI_Code = value;}
get{ return _ZPI_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_Title	 
{
set{ _ZPI_Title = value;}
get{ return _ZPI_Title;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPI_STime	 
{
set{ _ZPI_STime = value;}
get{ return _ZPI_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_Flow	 
{
set{ _ZPI_Flow = value;}
get{ return _ZPI_Flow;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPI_State	 
{
set{ _ZPI_State = value;}
get{ return _ZPI_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_Remarks	 
{
set{ _ZPI_Remarks = value;}
get{ return _ZPI_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPI_Del	 
{
set{ _ZPI_Del = value;}
get{ return _ZPI_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPI_CTime	 
{
set{ _ZPI_CTime = value;}
get{ return _ZPI_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_Creator	 
{
set{ _ZPI_Creator = value;}
get{ return _ZPI_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZPI_MTime	 
{
set{ _ZPI_MTime = value;}
get{ return _ZPI_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_Mender	 
{
set{ _ZPI_Mender = value;}
get{ return _ZPI_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_SampleID	 
{
set{ _ZPI_SampleID = value;}
get{ return _ZPI_SampleID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPI_SampleName	 
{
set{ _ZPI_SampleName = value;}
get{ return _ZPI_SampleName;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPI_Type	 
{
set{ _ZPI_Type = value;}
get{ return _ZPI_Type;}
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
