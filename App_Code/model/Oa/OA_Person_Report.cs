using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// OA_Person_Report:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class OA_Person_Report 
{
public OA_Person_Report()
{}
#region 
private string _OPR_ID;
private string _OPR_Code;
private DateTime _OPR_STime;
private string _OPR_DutyPerson;
private string _OPR_ThisReport;
private string _OPR_NextReport;
private DateTime _OPR_SubmitTime;
private int _OPR_Type =0 ;
private int _OPR_State =0 ;
private DateTime _OPR_CTime;
private string _OPR_Creator;
private DateTime _OPR_MTime;
private string _OPR_Mender;
private int _OPR_Del =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  OPR_ID	 
{
set{ _OPR_ID = value;}
get{ return _OPR_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPR_Code	 
{
set{ _OPR_Code = value;}
get{ return _OPR_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime OPR_STime	 
{
set{ _OPR_STime = value;}
get{ return _OPR_STime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPR_DutyPerson	 
{
set{ _OPR_DutyPerson = value;}
get{ return _OPR_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPR_ThisReport	 
{
set{ _OPR_ThisReport = value;}
get{ return _OPR_ThisReport;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPR_NextReport	 
{
set{ _OPR_NextReport = value;}
get{ return _OPR_NextReport;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime OPR_SubmitTime	 
{
set{ _OPR_SubmitTime = value;}
get{ return _OPR_SubmitTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int OPR_Type	 
{
set{ _OPR_Type = value;}
get{ return _OPR_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public int OPR_State	 
{
set{ _OPR_State = value;}
get{ return _OPR_State;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime OPR_CTime	 
{
set{ _OPR_CTime = value;}
get{ return _OPR_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPR_Creator	 
{
set{ _OPR_Creator = value;}
get{ return _OPR_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime OPR_MTime	 
{
set{ _OPR_MTime = value;}
get{ return _OPR_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  OPR_Mender	 
{
set{ _OPR_Mender = value;}
get{ return _OPR_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public int OPR_Del	 
{
set{ _OPR_Del = value;}
get{ return _OPR_Del;}
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
    private ArrayList _Arr_Detail1;
    public ArrayList Arr_Detail1
    {
        set { _Arr_Detail1 = value; }
        get { return _Arr_Detail1; }
    }
#endregion
}
}
