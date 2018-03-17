using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// OA_Person_Report_Details:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class OA_Person_Report_Details 
{
public OA_Person_Report_Details()
{}
#region 
private string _OPRD_ID;
private string _OPRD_FID;
private int _OPRD_ProjectNum = 0;
private int _OPRD_DetailsNum = 0;
private string _OPRD_Project;
private string _OPRD_ProjectDetails;
private string _OPRD_Person;
private string _OPRD_Time;
private DateTime _OPRD_CTime;
private string _OPRD_Creator;
private string _OPRD_FFID;
private int _OPRD_Type = 0;
    
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  OPRD_ID	 
{
set{ _OPRD_ID = value;}
get{ return _OPRD_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRD_FID	 
{
set{ _OPRD_FID = value;}
get{ return _OPRD_FID;}
}

public int OPRD_ProjectNum
{
    set { _OPRD_ProjectNum = value; }
    get { return _OPRD_ProjectNum; }
}
/// <summary>
/// 
/// </summary>
public int OPRD_DetailsNum
{
    set { _OPRD_DetailsNum = value; }
    get { return _OPRD_DetailsNum; }
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRD_Project	 
{
set{ _OPRD_Project = value;}
get{ return _OPRD_Project;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRD_ProjectDetails	 
{
set{ _OPRD_ProjectDetails = value;}
get{ return _OPRD_ProjectDetails;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRD_Person	 
{
set{ _OPRD_Person = value;}
get{ return _OPRD_Person;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRD_Time	 
{
set{ _OPRD_Time = value;}
get{ return _OPRD_Time;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime OPRD_CTime	 
{
set{ _OPRD_CTime = value;}
get{ return _OPRD_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPRD_Creator	 
{
set{ _OPRD_Creator = value;}
get{ return _OPRD_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public string OPRD_FFID	 
{
    set { _OPRD_FFID = value; }
    get { return _OPRD_FFID; }
}
public int OPRD_Type 
{
    set { _OPRD_Type = value; }
    get { return _OPRD_Type; }
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
        set { _Arr_Detail = value; }
        get { return _Arr_Detail; }
    }
#endregion
}
}
