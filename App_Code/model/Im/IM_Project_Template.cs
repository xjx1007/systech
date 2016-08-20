using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// IM_Project_Template:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class IM_Project_Template 
{
public IM_Project_Template()
{}
#region 
private string _IPT_ID;
private string _IPT_Code;
private string _IPT_Name;
private string _IPT_Details;
private string _IPT_Creator;
private DateTime _IPT_CTime;
private string _IPT_Mender;
private DateTime _IPT_MTime;
private int _IPT_Del =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  IPT_ID	 
{
set{ _IPT_ID = value;}
get{ return _IPT_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPT_Code	 
{
set{ _IPT_Code = value;}
get{ return _IPT_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPT_Name	 
{
set{ _IPT_Name = value;}
get{ return _IPT_Name;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPT_Details	 
{
set{ _IPT_Details = value;}
get{ return _IPT_Details;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPT_Creator	 
{
set{ _IPT_Creator = value;}
get{ return _IPT_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPT_CTime	 
{
set{ _IPT_CTime = value;}
get{ return _IPT_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  IPT_Mender	 
{
set{ _IPT_Mender = value;}
get{ return _IPT_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime IPT_MTime	 
{
set{ _IPT_MTime = value;}
get{ return _IPT_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int IPT_Del	 
{
set{ _IPT_Del = value;}
get{ return _IPT_Del;}
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
