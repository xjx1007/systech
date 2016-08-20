using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Zl_Produce_Problem_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Zl_Produce_Problem_Details 
{
public Zl_Produce_Problem_Details()
{}
#region 
private string _ZPPD_ID;
private string _ZPPD_FID;
private string _ZPPD_OrderNo;
private string _ZPPD_Remarks;
private int _ZPP_Type =0 ;
private string _ZPP_Details;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  ZPPD_ID	 
{
set{ _ZPPD_ID = value;}
get{ return _ZPPD_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPPD_FID	 
{
set{ _ZPPD_FID = value;}
get{ return _ZPPD_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPPD_OrderNo	 
{
set{ _ZPPD_OrderNo = value;}
get{ return _ZPPD_OrderNo;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPPD_Remarks	 
{
set{ _ZPPD_Remarks = value;}
get{ return _ZPPD_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int ZPP_Type	 
{
set{ _ZPP_Type = value;}
get{ return _ZPP_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  ZPP_Details	 
{
set{ _ZPP_Details = value;}
get{ return _ZPP_Details;}
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
