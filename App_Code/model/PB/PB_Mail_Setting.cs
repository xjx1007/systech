using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// PB_Mail_Setting:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class PB_Mail_Setting 
{
public PB_Mail_Setting()
{}
#region 
private string _PMS_ID;
private string _PMS_Sever;
private string _PMS_Port;
private string _PMS_Email;
private string _PMS_Password;
private int _PMS_Verification =0 ;
private string _PMS_SendEmail;
private string _PMS_SendPerson;
private int _PMS_Seconds =0 ;
private int _PMS_Del =0 ;
private string _PMS_Creator;
private DateTime _PMS_CTime;
private string _PMS_Mender;
private DateTime _PMS_MTime;
private int _PBS_SSL = 0;
#endregion
#region 属性设计器

/// <summary>
/// 
/// </summary>
public int PBS_SSL
{
    set { _PBS_SSL = value; }
    get { return _PBS_SSL; }
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_ID	 
{
set{ _PMS_ID = value;}
get{ return _PMS_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_Sever	 
{
set{ _PMS_Sever = value;}
get{ return _PMS_Sever;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_Port	 
{
set{ _PMS_Port = value;}
get{ return _PMS_Port;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_Email	 
{
set{ _PMS_Email = value;}
get{ return _PMS_Email;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_Password	 
{
set{ _PMS_Password = value;}
get{ return _PMS_Password;}
}
 /// <summary>
 /// 
 /// </summary>
public int PMS_Verification	 
{
set{ _PMS_Verification = value;}
get{ return _PMS_Verification;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_SendEmail	 
{
set{ _PMS_SendEmail = value;}
get{ return _PMS_SendEmail;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_SendPerson	 
{
set{ _PMS_SendPerson = value;}
get{ return _PMS_SendPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public int PMS_Seconds	 
{
set{ _PMS_Seconds = value;}
get{ return _PMS_Seconds;}
}
 /// <summary>
 /// 
 /// </summary>
public int PMS_Del	 
{
set{ _PMS_Del = value;}
get{ return _PMS_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_Creator	 
{
set{ _PMS_Creator = value;}
get{ return _PMS_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime PMS_CTime	 
{
set{ _PMS_CTime = value;}
get{ return _PMS_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PMS_Mender	 
{
set{ _PMS_Mender = value;}
get{ return _PMS_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime PMS_MTime	 
{
set{ _PMS_MTime = value;}
get{ return _PMS_MTime;}
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
