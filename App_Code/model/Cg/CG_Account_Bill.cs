using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// CG_Account_Bill:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class CG_Account_Bill 
{
public CG_Account_Bill()
{}
#region 
private string _CAB_ID;
private string _CAB_Code;
private string _CAB_SuppNo;
private DateTime _CAB_Stime;
private string _CAB_FpCode;
private string _CAB_BillType;
private string _CAB_PayMent;
private decimal _CAB_Money;
private string _CAB_Remarks;
private string _CAB_DutyPerson;
private string _CAB_Brokerage;
private int _CAB_State =0 ;
private int _CAB_Del =0 ;
private DateTime _CAB_CTime;
private string _CAB_Creator;
private DateTime _CAB_MTime;
private string _CAB_Mender;
private string _CAB_CheckNo;
    
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CAB_ID	 
{
set{ _CAB_ID = value;}
get{ return _CAB_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_Code	 
{
set{ _CAB_Code = value;}
get{ return _CAB_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_SuppNo	 
{
set{ _CAB_SuppNo = value;}
get{ return _CAB_SuppNo;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CAB_Stime	 
{
set{ _CAB_Stime = value;}
get{ return _CAB_Stime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_FpCode	 
{
set{ _CAB_FpCode = value;}
get{ return _CAB_FpCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_BillType	 
{
set{ _CAB_BillType = value;}
get{ return _CAB_BillType;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_PayMent	 
{
set{ _CAB_PayMent = value;}
get{ return _CAB_PayMent;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CAB_Money	 
{
set{ _CAB_Money = value;}
get{ return _CAB_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_Remarks	 
{
set{ _CAB_Remarks = value;}
get{ return _CAB_Remarks;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_DutyPerson	 
{
set{ _CAB_DutyPerson = value;}
get{ return _CAB_DutyPerson;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_Brokerage	 
{
set{ _CAB_Brokerage = value;}
get{ return _CAB_Brokerage;}
}
 /// <summary>
 /// 
 /// </summary>
public int CAB_State	 
{
set{ _CAB_State = value;}
get{ return _CAB_State;}
}
 /// <summary>
 /// 
 /// </summary>
public int CAB_Del	 
{
set{ _CAB_Del = value;}
get{ return _CAB_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CAB_CTime	 
{
set{ _CAB_CTime = value;}
get{ return _CAB_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_Creator	 
{
set{ _CAB_Creator = value;}
get{ return _CAB_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CAB_MTime	 
{
set{ _CAB_MTime = value;}
get{ return _CAB_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CAB_Mender	 
{
set{ _CAB_Mender = value;}
get{ return _CAB_Mender;}
}
public string CAB_CheckNo	 
{
    set { _CAB_CheckNo = value; }
    get { return _CAB_CheckNo; }
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

    private ArrayList _arr_OutTimes;
    public ArrayList arr_OutTimes
	{
        set { _arr_OutTimes = value; }

        get { return _arr_OutTimes; }
	}
    
#endregion
}
}
