using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// OA_Person_Report_Project:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class OA_Person_Report_Project 
{
public OA_Person_Report_Project()
{}
#region 
private string _OPRP_ID;
private string _OPRP_FID;
private int _OPRP_ProjectNum =0 ;
private string _OPRP_Project;
private DateTime _OPRP_CTime;
private string _OPRP_Creator;
private int _OPRP_Type = 0;
    
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  OPRP_ID	 
{
set{ _OPRP_ID = value;}
get{ return _OPRP_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRP_FID	 
{
set{ _OPRP_FID = value;}
get{ return _OPRP_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public int OPRP_ProjectNum	 
{
set{ _OPRP_ProjectNum = value;}
get{ return _OPRP_ProjectNum;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRP_Project	 
{
set{ _OPRP_Project = value;}
get{ return _OPRP_Project;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime OPRP_CTime	 
{
set{ _OPRP_CTime = value;}
get{ return _OPRP_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRP_Creator	 
{
set{ _OPRP_Creator = value;}
get{ return _OPRP_Creator;}
}
public int OPRP_Type
{
    set { _OPRP_Type = value; }
    get { return _OPRP_Type; }
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
	private ArrayList Arr_Detail;
	public ArrayList getArr_Detail()
	{
		return Arr_Detail;
	}
	public void setArr_Detail(ArrayList Arr_Detail)
	{
		this.Arr_Detail=Arr_Detail;
	}
#endregion
}
}
