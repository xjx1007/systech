using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// CW_Bank_Bill:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class CW_Bank_Bill 
{
public CW_Bank_Bill()
{}
#region 
private string _CBB_ID;
private string _CBB_Code;
private string _CBB_OutBankNo;
private string _CBB_InBankNo;
private DateTime _CBB_STime;
private decimal _CBB_Money;
private string _CBB_Detail;
private int _CBB_Del =0 ;
private string _CBB_Creator;
private DateTime _CBB_CTime;
private string _CBB_Mender;
private DateTime _CBB_MTime;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CBB_ID	 
{
set{ _CBB_ID = value;}
get{ return _CBB_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBB_Code	 
{
set{ _CBB_Code = value;}
get{ return _CBB_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBB_OutBankNo	 
{
set{ _CBB_OutBankNo = value;}
get{ return _CBB_OutBankNo;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBB_InBankNo	 
{
set{ _CBB_InBankNo = value;}
get{ return _CBB_InBankNo;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBB_STime	 
{
set{ _CBB_STime = value;}
get{ return _CBB_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CBB_Money	 
{
set{ _CBB_Money = value;}
get{ return _CBB_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBB_Detail	 
{
set{ _CBB_Detail = value;}
get{ return _CBB_Detail;}
}
 /// <summary>
 /// 
 /// </summary>
public int CBB_Del	 
{
set{ _CBB_Del = value;}
get{ return _CBB_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBB_Creator	 
{
set{ _CBB_Creator = value;}
get{ return _CBB_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBB_CTime	 
{
set{ _CBB_CTime = value;}
get{ return _CBB_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBB_Mender	 
{
set{ _CBB_Mender = value;}
get{ return _CBB_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBB_MTime	 
{
set{ _CBB_MTime = value;}
get{ return _CBB_MTime;}
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
