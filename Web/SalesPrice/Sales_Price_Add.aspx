<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_Price_Add.aspx.cs" Inherits="Web_SalesPrice_Sales_Price_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
    <title>销售价格设置</title>
</head>
<body>

<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetProducts_onclick()  
    {   
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var tempd= window.showModalDialog("../Common/SelectSuppliersPriceForProducts.aspx?ID="+document.all("Products_ID").value+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(tempd!=undefined)   
       {   
      
          	 var ss,s_Value,s_Name,i_row,s_ID;
	         i_row = ProductsTable.rows.length;
	         s_ID=document.all("Products_ID").value+",";
	         ss = tempd.split("|");  
	         for(var i=0;i<ss.length-1;i++)
	         {
	            s_Value=ss[i].split(",");
	            var objRow = ProductsTable.insertRow(i_row);
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=input Name=\"ProdoctsBarCode\" value='+s_Value[0]+' style=\"display:none;\">'+s_Value[1]; 
                objCel.className="tdcss";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=input Name=\"SuppNo\" value='+s_Value[2]+' style=\"display:none;\">'+s_Value[3]; 
                objCel.className="tdcss";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=input Name=\"Price\" value='+s_Value[4]+' style=\"display:none;\">'+s_Value[4]; 
                objCel.className="tdcss";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=input Name=\"Number\" value='+s_Value[5]+' style=\"display:none;\">'+s_Value[5]; 
                objCel.className="tdcss";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=button Name=\"Del\" onclick=\"deleteRow(this)\" value=删除 >';
                objCel.className="tdcss";
                i_row=i_row+1;
                s_ID =s_ID + s_Value[0]+",";
	         }
	         document.all("Products_ID").value = s_ID;
        }   
    }
    
    
function deleteRow(obj){
   ProductsTable.deleteRow(obj.parentElement.parentElement.rowIndex);
    var Values =document.getElementsByName("ProdoctsBarCode"); 
    var bm_num="";
    for(i=0;i<Values.length;i++){  
        bm_num += Values[i].value+",";   
    }
    document.all("Products_ID").value=bm_num;
    }
</SCRIPT>
    
    
    <form id="form1" runat="server">
    <div>
    
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td>

<%--合同开单  开始--%>

<table width="100%" border="0"   cellpadding="0" cellspacing="0" align="center" class="tablecss_add" id="TABLE1" >
 <tr>
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">&nbsp; 编号:</td>
    <td width="36%" align="left" class="tableBotcss" style="height: 33px"><asp:TextBox ID="ContractNo" MaxLength="40" runat="server" CssClass="Boxx" Width="150px" ></asp:TextBox>(<font color="red">*</font>)唯一性</td>
    <td align="right" class="tableBotcss" style="color: #000000; height: 33px;">
      执行日期:</td>
    <td align="left" class="tableBotcss" style="height: 33px"><asp:TextBox ID="ContractDateTime" runat="server"  MaxLength="20"  CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>(<font color="red"><span
            style="color: #ff0066">*</span></font>)</td>
  </tr>

 <tr >
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">客户:</td>
    <td align="left" class="tableBotcss" style="height: 33px" colspan="3">
    <input type="hidden" name="CustomerValue" id="CustomerValue" runat="server" style="width: 150px" />
    <asp:TextBox ID="CustomerValueName" runat="server" CssClass="Boxx2" Width="350px" ></asp:TextBox>(<font color="red">*</font>)<Input  Type="Button" id=" btnGetReturnValue" class="Btt" onclick="return btnGetReturnValue_onclick()" value="选择客户"><br />
    <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户" ControlToValidate="CustomerValueName" Display="Dynamic"></asp:RequiredFieldValidator></td>
   
 </tr> 
 <tr>
      <asp:TextBox ID="Products_ID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox><td height="25" align="right" class="tdcss">选择产品:</td>
        <td align="left" class="tdcss" style="text-align: left">
         <table id="ProductsTable" width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
            <tr id="tr2">
                <td align="center" class="tdcss" >产品名称</td>
                <td align="center" class="tdcss" >型号</td>
                <td align="center" class="tdcss" >单价</td>
                <td align="center" class="tdcss" >含税</td>
                <td align="center" class="tdcss" >电池</td>
                <td align="center" class="tdcss" >删除</td>
            </tr>
        </table>        
            <INPUT id="Button2" class="Btt" onclick="return btnGetProducts_onclick()" type="button" value="选择配件" />
        </td>
         </tr>
</table>

<%--合同开单  结束--%>


<!--底部功能栏 -->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td style="text-align: center; height: 8px;" >&nbsp;&nbsp;<br /><asp:Button ID="Button3" runat="server" Text="" CssClass="Btt" OnClick="Button3_Click" /></td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>
    </div>
    </form>
</body>
</html>
