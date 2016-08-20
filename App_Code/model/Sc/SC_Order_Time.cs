using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// SC_Order_Time:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class SC_Order_Time 
{
public SC_Order_Time()
{}
#region 
private string _SOT_ID;
private string _SOT_FID;
private int _SOT_Number =0 ;
private DateTime _SOT_OldTime;
private DateTime _SOT_NewTime;
private int _SOT_State =0 ;
private string _SOT_Details;
private DateTime _SOT_CTime;
private string _SOT_Creator;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  SOT_ID	 
{
set{ _SOT_ID = value;}
get{ return _SOT_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  SOT_FID	 
{
set{ _SOT_FID = value;}
get{ return _SOT_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public int SOT_Number	 
{
set{ _SOT_Number = value;}
get{ return _SOT_Number;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime SOT_OldTime	 
{
set{ _SOT_OldTime = value;}
get{ return _SOT_OldTime;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime SOT_NewTime	 
{
set{ _SOT_NewTime = value;}
get{ return _SOT_NewTime;}
}
 /// <summary>
 /// 
 /// </summary>
public int SOT_State	 
{
set{ _SOT_State = value;}
get{ return _SOT_State;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  SOT_Details	 
{
set{ _SOT_Details = value;}
get{ return _SOT_Details;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime SOT_CTime	 
{
set{ _SOT_CTime = value;}
get{ return _SOT_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  SOT_Creator	 
{
set{ _SOT_Creator = value;}
get{ return _SOT_Creator;}
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
