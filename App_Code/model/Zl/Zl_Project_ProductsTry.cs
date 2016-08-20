using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Zl_Project_ProductsTry:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Zl_Project_ProductsTry 
{
public Zl_Project_ProductsTry()
{}
#region 
private string _ZPP_ID;
private string _ZPP_Code;
private string _ZPP_Title;
private DateTime _ZPP_STime;
private string _ZPP_Flow;
private int _ZPP_State =0 ;
private string _ZPP_Remarks;
private int _ZPP_Del =0 ;
private DateTime _ZPP_CTime;
private string _ZPP_Creator;
private DateTime _ZPP_MTime;
private string _ZPP_Mender;
private string _ZPP_SampleID;
private string _ZPP_SampleName;
private int _ZPP_Type =0 ;
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
public  string  ZPP_Title	 
{
set{ _ZPP_Title = value;}
get{ return _ZPP_Title;}
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
public  string  ZPP_Flow	 
{
set{ _ZPP_Flow = value;}
get{ return _ZPP_Flow;}
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
public  string  ZPP_Remarks	 
{
set{ _ZPP_Remarks = value;}
get{ return _ZPP_Remarks;}
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
public DateTime ZPP_CTime	 
{
set{ _ZPP_CTime = value;}
get{ return _ZPP_CTime;}
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
public DateTime ZPP_MTime	 
{
set{ _ZPP_MTime = value;}
get{ return _ZPP_MTime;}
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
public  string  ZPP_SampleID	 
{
set{ _ZPP_SampleID = value;}
get{ return _ZPP_SampleID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_SampleName	 
{
set{ _ZPP_SampleName = value;}
get{ return _ZPP_SampleName;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPP_Type	 
{
set{ _ZPP_Type = value;}
get{ return _ZPP_Type;}
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
