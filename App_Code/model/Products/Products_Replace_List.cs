using System;
using System.Collections;
namespace KNet.Model
{
 /// <summary>
 /// Products_Replace_List:实体类(属性说明自动提取数据库字段的描述信息)
 /// </summary>
[Serializable]
public partial class Products_Replace_List 
{
public Products_Replace_List()
{}
#region 
private string _PRL_ID;
private string _PRL_ProductsCode;
private string _PRL_ReplaceProductsBarCode;
private int _PRL_AlternativePriority =0 ;
private int _PRL_AlternativeOlny =0 ;
#endregion
#region 属性设计器

 /// <summary>
 /// 
 /// </summary>
public  string  PRL_ID	 
{
set{ _PRL_ID = value;}
get{ return _PRL_ID;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PRL_ProductsCode	 
{
set{ _PRL_ProductsCode = value;}
get{ return _PRL_ProductsCode;}
}
 /// <summary>
 /// 
 /// </summary>
public  string  PRL_ReplaceProductsBarCode	 
{
set{ _PRL_ReplaceProductsBarCode = value;}
get{ return _PRL_ReplaceProductsBarCode;}
}
 /// <summary>
 /// 
 /// </summary>
public int PRL_AlternativePriority	 
{
set{ _PRL_AlternativePriority = value;}
get{ return _PRL_AlternativePriority;}
}
 /// <summary>
 /// 
 /// </summary>
public int PRL_AlternativeOlny	 
{
set{ _PRL_AlternativeOlny = value;}
get{ return _PRL_AlternativeOlny;}
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
