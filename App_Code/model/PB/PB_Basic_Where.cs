using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// PB_Basic_Where:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class PB_Basic_Where 
{
public PB_Basic_Where()
{}
#region 
private string _PBW_ID;
private string _PBW_Name;
private string _PBW_Table;
private string _PBW_Sql;
private string _PBW_Type;
private int _PBW_Del =0 ;
private int _PBW_Order =0 ;
private string _PBW_Cloumn;
private string _PBW_FromTable;
private string _PBW_FromValue;
private string _PBW_FromName;
private string _PBW_InputType;
private string _PBW_FromWhere;
private DateTime _PBW_CTime;
private string _PBW_Creator;
private DateTime _PBW_MTime;
private string _PBW_Mender;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  PBW_ID	 
{
set{ _PBW_ID = value;}
get{ return _PBW_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_Name	 
{
set{ _PBW_Name = value;}
get{ return _PBW_Name;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_Table	 
{
set{ _PBW_Table = value;}
get{ return _PBW_Table;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_Sql	 
{
set{ _PBW_Sql = value;}
get{ return _PBW_Sql;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_Type	 
{
set{ _PBW_Type = value;}
get{ return _PBW_Type;}
}
 /// <summary>
 /// 
 /// </summary>
public int PBW_Del	 
{
set{ _PBW_Del = value;}
get{ return _PBW_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public int PBW_Order	 
{
set{ _PBW_Order = value;}
get{ return _PBW_Order;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_Cloumn	 
{
set{ _PBW_Cloumn = value;}
get{ return _PBW_Cloumn;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_FromTable	 
{
set{ _PBW_FromTable = value;}
get{ return _PBW_FromTable;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_FromValue	 
{
set{ _PBW_FromValue = value;}
get{ return _PBW_FromValue;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_FromName	 
{
set{ _PBW_FromName = value;}
get{ return _PBW_FromName;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_InputType	 
{
set{ _PBW_InputType = value;}
get{ return _PBW_InputType;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_FromWhere	 
{
set{ _PBW_FromWhere = value;}
get{ return _PBW_FromWhere;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime PBW_CTime	 
{
set{ _PBW_CTime = value;}
get{ return _PBW_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_Creator	 
{
set{ _PBW_Creator = value;}
get{ return _PBW_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime PBW_MTime	 
{
set{ _PBW_MTime = value;}
get{ return _PBW_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBW_Mender	 
{
set{ _PBW_Mender = value;}
get{ return _PBW_Mender;}
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
