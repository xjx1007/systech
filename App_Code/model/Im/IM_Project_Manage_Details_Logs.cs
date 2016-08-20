using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// IM_Project_Manage_Details_Logs:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class IM_Project_Manage_Details_Logs 
{
public IM_Project_Manage_Details_Logs()
{}
#region 
private string _IPML_ID;
private string _IPML_FID;
private int _IPML_ThisUseDays =0 ;
private int _IPML_Precent =0 ;
private string _IPML_Details;
private string _IPML_OldDetails;
private int _IPML_Del =0 ;
private string _IPML_Creator;
private DateTime _IPML_CTime;
private string _IPML_Mender;
private DateTime _IPML_MTime;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  IPML_ID	 
{
set{ _IPML_ID = value;}
get{ return _IPML_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPML_FID	 
{
set{ _IPML_FID = value;}
get{ return _IPML_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPML_ThisUseDays	 
{
set{ _IPML_ThisUseDays = value;}
get{ return _IPML_ThisUseDays;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPML_Precent	 
{
set{ _IPML_Precent = value;}
get{ return _IPML_Precent;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPML_Details	 
{
set{ _IPML_Details = value;}
get{ return _IPML_Details;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPML_OldDetails	 
{
set{ _IPML_OldDetails = value;}
get{ return _IPML_OldDetails;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPML_Del	 
{
set{ _IPML_Del = value;}
get{ return _IPML_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPML_Creator	 
{
set{ _IPML_Creator = value;}
get{ return _IPML_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPML_CTime	 
{
set{ _IPML_CTime = value;}
get{ return _IPML_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPML_Mender	 
{
set{ _IPML_Mender = value;}
get{ return _IPML_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPML_MTime	 
{
set{ _IPML_MTime = value;}
get{ return _IPML_MTime;}
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
