using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Cw_Bill_Expense:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Cw_Bill_Expense 
{
public Cw_Bill_Expense()
{}
#region 
private string _CBE_ID;
private string _CBE_Code;
private string _CBE_CustomerValue;
private string _CBE_LinkMan;
private string _CBE_OPPID;
private int _CBE_State =0 ;
private string _CBE_Content;
private DateTime _CBE_Stime;
private string _CBE_DutyPerson;
private string _CBE_Remarks;
private DateTime _CBE_CTime;
private string _CBE_Creator;
private DateTime _CBE_MTime;
private string _CBE_Mender;
private int _CBE_Del =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CBE_ID	 
{
set{ _CBE_ID = value;}
get{ return _CBE_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_Code	 
{
set{ _CBE_Code = value;}
get{ return _CBE_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_CustomerValue	 
{
set{ _CBE_CustomerValue = value;}
get{ return _CBE_CustomerValue;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_LinkMan	 
{
set{ _CBE_LinkMan = value;}
get{ return _CBE_LinkMan;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_OPPID	 
{
set{ _CBE_OPPID = value;}
get{ return _CBE_OPPID;}
}
 /// <summary>
 /// 
 /// </summary>
public int CBE_State	 
{
set{ _CBE_State = value;}
get{ return _CBE_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_Content	 
{
set{ _CBE_Content = value;}
get{ return _CBE_Content;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBE_Stime	 
{
set{ _CBE_Stime = value;}
get{ return _CBE_Stime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_DutyPerson	 
{
set{ _CBE_DutyPerson = value;}
get{ return _CBE_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_Remarks	 
{
set{ _CBE_Remarks = value;}
get{ return _CBE_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBE_CTime	 
{
set{ _CBE_CTime = value;}
get{ return _CBE_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_Creator	 
{
set{ _CBE_Creator = value;}
get{ return _CBE_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBE_MTime	 
{
set{ _CBE_MTime = value;}
get{ return _CBE_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBE_Mender	 
{
set{ _CBE_Mender = value;}
get{ return _CBE_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public int CBE_Del	 
{
set{ _CBE_Del = value;}
get{ return _CBE_Del;}
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
