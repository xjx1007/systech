using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Zl_Quality_Cost:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Zl_Quality_Cost 
{
public Zl_Quality_Cost()
{}
#region 
private string _ZQC_ID;
private string _ZQC_Code;
private string _ZQC_ProjectType;
private string _ZQC_ContentType;
private DateTime _ZQC_STime;
private decimal _ZQC_Money;
private string _ZQC_Remarks;
private int _ZQC_Del =0 ;
private string _ZQC_Creator;
private DateTime _ZQC_CTime;
private string _ZQC_Mender;
private DateTime _ZQC_MTime;
private string _ZQC_Flow;
private string _ZQC_FlowStep;
private int _ZQC_State =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_ID	 
{
set{ _ZQC_ID = value;}
get{ return _ZQC_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_Code	 
{
set{ _ZQC_Code = value;}
get{ return _ZQC_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_ProjectType	 
{
set{ _ZQC_ProjectType = value;}
get{ return _ZQC_ProjectType;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_ContentType	 
{
set{ _ZQC_ContentType = value;}
get{ return _ZQC_ContentType;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZQC_STime	 
{
set{ _ZQC_STime = value;}
get{ return _ZQC_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal ZQC_Money	 
{
set{ _ZQC_Money = value;}
get{ return _ZQC_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_Remarks	 
{
set{ _ZQC_Remarks = value;}
get{ return _ZQC_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZQC_Del	 
{
set{ _ZQC_Del = value;}
get{ return _ZQC_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_Creator	 
{
set{ _ZQC_Creator = value;}
get{ return _ZQC_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZQC_CTime	 
{
set{ _ZQC_CTime = value;}
get{ return _ZQC_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_Mender	 
{
set{ _ZQC_Mender = value;}
get{ return _ZQC_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime ZQC_MTime	 
{
set{ _ZQC_MTime = value;}
get{ return _ZQC_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_Flow	 
{
set{ _ZQC_Flow = value;}
get{ return _ZQC_Flow;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZQC_FlowStep	 
{
set{ _ZQC_FlowStep = value;}
get{ return _ZQC_FlowStep;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZQC_State	 
{
set{ _ZQC_State = value;}
get{ return _ZQC_State;}
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
