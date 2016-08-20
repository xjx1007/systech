using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Xs_Contract_FhDetails:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Xs_Contract_FhDetails 
{
public Xs_Contract_FhDetails()
{}
#region 
private string _XCF_ID;
private string _XCF_FID;
private string _XCF_Name;
private string _XCF_Details;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  XCF_ID	 
{
set{ _XCF_ID = value;}
get{ return _XCF_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCF_FID	 
{
set{ _XCF_FID = value;}
get{ return _XCF_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCF_Name	 
{
set{ _XCF_Name = value;}
get{ return _XCF_Name;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  XCF_Details	 
{
set{ _XCF_Details = value;}
get{ return _XCF_Details;}
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
