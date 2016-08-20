using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// CG_Account_Bill_Outimes:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class CG_Account_Bill_Outimes 
{
public CG_Account_Bill_Outimes()
{}
#region 
private string _CABO_ID;
private string _CABO_FID;
private DateTime _CABO_OutTime;
private int _CABO_Days =0 ;
private decimal _CABO_Money;
private string _CABO_Remarks;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CABO_ID	 
{
set{ _CABO_ID = value;}
get{ return _CABO_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CABO_FID	 
{
set{ _CABO_FID = value;}
get{ return _CABO_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CABO_OutTime	 
{
set{ _CABO_OutTime = value;}
get{ return _CABO_OutTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int CABO_Days	 
{
set{ _CABO_Days = value;}
get{ return _CABO_Days;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CABO_Money	 
{
set{ _CABO_Money = value;}
get{ return _CABO_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CABO_Remarks	 
{
set{ _CABO_Remarks = value;}
get{ return _CABO_Remarks;}
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
