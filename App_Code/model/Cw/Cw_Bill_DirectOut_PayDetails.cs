using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Cw_Bill_DirectOut_PayDetails:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Cw_Bill_DirectOut_PayDetails 
{
public Cw_Bill_DirectOut_PayDetails()
{}
#region 
private string _CBDP_ID;
private string _CBDP_FPOutID;
private string _CBDP_Code;
private string _CBDP_PayMentID;
private string _CBDP_DetailsID;
private decimal _CBDP_Money;
private int _CBDP_Del =0 ;
private DateTime _CBDP_CTime;
private string _CBDP_Creator;
private DateTime _CBDP_MTime;
private string _CBDP_Mender;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  CBDP_ID	 
{
set{ _CBDP_ID = value;}
get{ return _CBDP_ID;}
}
public string CBDP_FPOutID	 
{
    set { _CBDP_FPOutID = value; }
    get { return _CBDP_FPOutID; }
}

    
 /// <summary>
 /// 
 /// </summary>
public  string  CBDP_Code	 
{
set{ _CBDP_Code = value;}
get{ return _CBDP_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBDP_PayMentID	 
{
set{ _CBDP_PayMentID = value;}
get{ return _CBDP_PayMentID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBDP_DetailsID	 
{
set{ _CBDP_DetailsID = value;}
get{ return _CBDP_DetailsID;}
}
 /// <summary>
 /// 
 /// </summary>
public decimal CBDP_Money	 
{
set{ _CBDP_Money = value;}
get{ return _CBDP_Money;}
}
 /// <summary>
 /// 
 /// </summary>
public int CBDP_Del	 
{
set{ _CBDP_Del = value;}
get{ return _CBDP_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBDP_CTime	 
{
set{ _CBDP_CTime = value;}
get{ return _CBDP_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBDP_Creator	 
{
set{ _CBDP_Creator = value;}
get{ return _CBDP_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime CBDP_MTime	 
{
set{ _CBDP_MTime = value;}
get{ return _CBDP_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  CBDP_Mender	 
{
set{ _CBDP_Mender = value;}
get{ return _CBDP_Mender;}
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
