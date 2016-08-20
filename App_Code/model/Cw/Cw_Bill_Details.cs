using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Cw_Bill_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Cw_Bill_Details 
{
public Cw_Bill_Details()
{}
#region 
private string _CBD_ID;
private string _CBD_FID;
private string _CBD_ReCeID;
private DateTime _CBD_BeginTime;
private DateTime _CBD_EndTime;
private decimal _CBD_Money;
private string _CBD_BillCode;
private string _CBD_Details;
private string _CBD_From;
private DateTime _CBD_CTime;
private string _CBD_Creator;
private int _CBD_Type =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CBD_ID	 
{
set{ _CBD_ID = value;}
get{ return _CBD_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBD_FID	 
{
set{ _CBD_FID = value;}
get{ return _CBD_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBD_ReCeID	 
{
set{ _CBD_ReCeID = value;}
get{ return _CBD_ReCeID;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBD_BeginTime	 
{
set{ _CBD_BeginTime = value;}
get{ return _CBD_BeginTime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBD_EndTime	 
{
set{ _CBD_EndTime = value;}
get{ return _CBD_EndTime;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CBD_Money	 
{
set{ _CBD_Money = value;}
get{ return _CBD_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBD_BillCode	 
{
set{ _CBD_BillCode = value;}
get{ return _CBD_BillCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBD_Details	 
{
set{ _CBD_Details = value;}
get{ return _CBD_Details;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBD_From	 
{
set{ _CBD_From = value;}
get{ return _CBD_From;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBD_CTime	 
{
set{ _CBD_CTime = value;}
get{ return _CBD_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBD_Creator	 
{
set{ _CBD_Creator = value;}
get{ return _CBD_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public int CBD_Type	 
{
set{ _CBD_Type = value;}
get{ return _CBD_Type;}
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
