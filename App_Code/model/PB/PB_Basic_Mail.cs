using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// PB_Basic_Mail:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class PB_Basic_Mail 
{
public PB_Basic_Mail()
{}
#region 
private string _PBM_ID;
private string _PBM_Code;
private string _PBM_SendEmail;
private string _PBM_ReceiveEmail;
private string _PBM_Text;
private string _PBM_File;
private string _PBM_Title;
private int _PBM_State =0 ;
private int _PBM_Del =0 ;
private string _PBM_Creator;
private DateTime _PBM_CTime;
private string _PBM_Mender;
private DateTime _PBM_MTime;
private string _PBM_FID;
private int _PBM_Type =0 ;
private string _PBM_Cc;
private string _PBM_Ms;
private decimal _PBM_Minute = 0 ;
private int _PBM_SendType = 0;
private string _PBM_SendSettingID;
    
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  PBM_ID	 
{
set{ _PBM_ID = value;}
get{ return _PBM_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_Code	 
{
set{ _PBM_Code = value;}
get{ return _PBM_Code;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_SendEmail	 
{
set{ _PBM_SendEmail = value;}
get{ return _PBM_SendEmail;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_ReceiveEmail	 
{
set{ _PBM_ReceiveEmail = value;}
get{ return _PBM_ReceiveEmail;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_Text	 
{
set{ _PBM_Text = value;}
get{ return _PBM_Text;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_File	 
{
set{ _PBM_File = value;}
get{ return _PBM_File;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_Title	 
{
set{ _PBM_Title = value;}
get{ return _PBM_Title;}
}
 /// <summary>
 /// 
 /// </summary>
public int PBM_State	 
{
set{ _PBM_State = value;}
get{ return _PBM_State;}
}
 /// <summary>
 /// 
 /// </summary>
public int PBM_Del	 
{
set{ _PBM_Del = value;}
get{ return _PBM_Del;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_Creator	 
{
set{ _PBM_Creator = value;}
get{ return _PBM_Creator;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime PBM_CTime	 
{
set{ _PBM_CTime = value;}
get{ return _PBM_CTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_Mender	 
{
set{ _PBM_Mender = value;}
get{ return _PBM_Mender;}
}
 /// <summary>
 /// 
 /// </summary>
public DateTime PBM_MTime	 
{
set{ _PBM_MTime = value;}
get{ return _PBM_MTime;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PBM_FID	 
{
set{ _PBM_FID = value;}
get{ return _PBM_FID;}
}
 /// <summary>
 /// 
 /// </summary>
public int PBM_Type	 
{
set{ _PBM_Type = value;}
get{ return _PBM_Type;}
}

public string PBM_Cc
{
    set { _PBM_Cc = value; }
    get { return _PBM_Cc; }
}
public string PBM_Ms
{
    set { _PBM_Ms = value; }
    get { return _PBM_Ms; }
}


public decimal PBM_Minute
{
    set { _PBM_Minute = value; }
    get { return _PBM_Minute; }
}

public int PBM_SendType
{
    set { _PBM_SendType = value; }
    get { return _PBM_SendType; }
}

public string PBM_SendSettingID
{
    set { _PBM_SendSettingID = value; }
    get { return _PBM_SendSettingID; }
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
