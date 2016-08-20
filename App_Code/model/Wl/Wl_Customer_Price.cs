using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Wl_Customer_Price:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Wl_Customer_Price 
{
public Wl_Customer_Price()
{}
#region 
private string _WCP_ID;
private string _WCP_Code;
private string _WCP_SuppNo;
private string _WCP_WuliuSuppNo;
private DateTime _WCP_STime;
private string _WCP_CustomerValue;
private string _WCP_LinkMan;
private string _WCP_Address;
private string _WCP_DutyPerson;
private string _WCP_Remarks;
private int _WCP_CheckYN =0 ;
private int _WCP_Del =0 ;
private DateTime _WCP_CTime;
private string _WCP_Creator;
private DateTime _WCP_MTime;
private string _WCP_Mender;
private decimal _WCP_Days;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  WCP_ID	 
{
set{ _WCP_ID = value;}
get{ return _WCP_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_Code	 
{
set{ _WCP_Code = value;}
get{ return _WCP_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_SuppNo	 
{
set{ _WCP_SuppNo = value;}
get{ return _WCP_SuppNo;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_WuliuSuppNo	 
{
set{ _WCP_WuliuSuppNo = value;}
get{ return _WCP_WuliuSuppNo;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime WCP_STime	 
{
set{ _WCP_STime = value;}
get{ return _WCP_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_CustomerValue	 
{
set{ _WCP_CustomerValue = value;}
get{ return _WCP_CustomerValue;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_LinkMan	 
{
set{ _WCP_LinkMan = value;}
get{ return _WCP_LinkMan;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_Address	 
{
set{ _WCP_Address = value;}
get{ return _WCP_Address;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_DutyPerson	 
{
set{ _WCP_DutyPerson = value;}
get{ return _WCP_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_Remarks	 
{
set{ _WCP_Remarks = value;}
get{ return _WCP_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public int WCP_CheckYN	 
{
set{ _WCP_CheckYN = value;}
get{ return _WCP_CheckYN;}
}
 /// <summary>
 /// 
 /// </summary>
public int WCP_Del	 
{
set{ _WCP_Del = value;}
get{ return _WCP_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime WCP_CTime	 
{
set{ _WCP_CTime = value;}
get{ return _WCP_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_Creator	 
{
set{ _WCP_Creator = value;}
get{ return _WCP_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime WCP_MTime	 
{
set{ _WCP_MTime = value;}
get{ return _WCP_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  WCP_Mender	 
{
set{ _WCP_Mender = value;}
get{ return _WCP_Mender;}
}
public decimal WCP_Days
{
    set { _WCP_Days = value; }
    get { return _WCP_Days; }
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
