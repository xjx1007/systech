using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Cw_Material_MoneyChange:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Cw_Material_MoneyChange 
{
public Cw_Material_MoneyChange()
{}
#region 
private string _CMM_ID;
private string _CMM_Code;
private string _CMM_FID;
private DateTime _CMM_STime;
private int _CMM_Type =0 ;
private decimal _CMM_Money;
private string _CMM_Remarks;
private int _CMM_Del =0 ;
private DateTime _CMM_CTime;
private string _CMM_Creator;
private DateTime _CMM_MTime;
private string _CMM_Mender;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CMM_ID	 
{
set{ _CMM_ID = value;}
get{ return _CMM_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CMM_Code	 
{
set{ _CMM_Code = value;}
get{ return _CMM_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CMM_FID	 
{
set{ _CMM_FID = value;}
get{ return _CMM_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CMM_STime	 
{
set{ _CMM_STime = value;}
get{ return _CMM_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public int CMM_Type	 
{
set{ _CMM_Type = value;}
get{ return _CMM_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CMM_Money	 
{
set{ _CMM_Money = value;}
get{ return _CMM_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CMM_Remarks	 
{
set{ _CMM_Remarks = value;}
get{ return _CMM_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int CMM_Del	 
{
set{ _CMM_Del = value;}
get{ return _CMM_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CMM_CTime	 
{
set{ _CMM_CTime = value;}
get{ return _CMM_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CMM_Creator	 
{
set{ _CMM_Creator = value;}
get{ return _CMM_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CMM_MTime	 
{
set{ _CMM_MTime = value;}
get{ return _CMM_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CMM_Mender	 
{
set{ _CMM_Mender = value;}
get{ return _CMM_Mender;}
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
