<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="Knet_Sales_Ship_Manage_Add.aspx.cs" Inherits="Knet_Web_Sales_Knet_Sales_Ship_Manage_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
  <SCRIPT LANGUAGE=JAVASCRIPT>
   function btnGetReturnValue_onclick1()  
    {   
       /*选择客户*/
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var tempd= window.showModalDialog("../Common/SelectSalesClientList.aspx?sID="+intSeconds+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(tempd!=undefined)   
       {   
          	 var ss;
	         ss=tempd.split("|");
             document.all('CustomerValue').value = ss[0];
             document.all('CustomerValueName').value =ss[1];
             document.all('ContractToAddress').value =ss[2];
        }   
       else
        {
             document.all('CustomerValue').value = ""; 
             document.all('CustomerValueName').value = ""; 
             document.all('ContractToAddress').value = ""; 
        }
    }
    function btnGetReturnValue_onclick()  
    { 
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("../Common/SelectSalesContractList.aspx?ID="+intSeconds+"&Type=1","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(temp!=undefined)   
       {   
          	 var ss;
	         ss=temp.split("|");
             document.all('ContractNoSelectValue').value = ss[0];
             document.all('ContractNoName').value =ss[1];
        }   
       else
        {
             document.all('ContractNoSelectValue').value = ""; 
             document.all('ContractNoName').value = ""; 
        }
    }
    
    function btnGetContentPerson_onclick()  
    {
       var s_Customer="";
       s_Customer=document.all('CustomerValue').value;
       var temaap= window.showModalDialog("../Common/SelectContentPerson.aspx?ID="+s_Customer,"","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
      
       if(temaap!=undefined)   
       {   
          	 var sws;
	         sws=temaap.split(",");
             document.all('Tbx_ContentPerson').value = sws[0];
             document.all('Phone').value =sws[1];
             document.all('Tbx_ContentPersonID').value = sws[2];
             document.all('ContractToAddress').value =sws[3];
        }   
       else
        {
             document.all('Tbx_ContentPerson').value = ""; 
             document.all('Phone').value = ""; 
             document.all('Tbx_ContentPersonID').value = ""; 
             document.all('ContractToAddress').value = "";
             
        }
    }
</SCRIPT>
  <SCRIPT LANGUAGE=JAVASCRIPT>
    function btnGetBackValue_onclick()  
    { 
     document.all('ContractNoSelectValue').value = ""; 
     document.all('ContractNoName').value = ""; 
    }
</SCRIPT>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

 <div class="TitleBar">销售发货管理</div>

<div id="Div1" style="padding:1px"></div>



<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
     
<%--选择采购单进行收货--%>
<table width="820" height="162" border="0" cellpadding="0" cellspacing="0"  id="selectPathen" runat="server" >
  <tr>
    <td height="60" colspan="3" align="left">&nbsp;</td>
  </tr>
  <tr>
    <td width="224" height="30" align="right">发货流程:</td>
    <td width="386" background="../../images/awa2.gif"><table width="386" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="91" height="26" align="center">选择合同单</td>
        <td width="85" align="center">确定发货</td>
        <td width="92" align="center">填写发货单</td>
        <td width="123" align="center">添加发货明细</td>
      </tr>
    </table></td>
    <td width="364" align="left"> 审核并完成发货</td>
  </tr>
  <tr>
    <td height="45" align="right" valign="bottom">请选择合同单:</td>
    <td colspan="2" valign="bottom"><input type="hidden" name="ContractNoSelectValue" id="ContractNoSelectValue" runat="server" />
    <asp:TextBox ID="ContractNoName" runat="server" Width="300px" CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<Input  Type="Button" id=" btnGetReturnValue" class="Btt" onclick="return btnGetReturnValue_onclick()" value="选择合同单" ><br />
        &nbsp;</td>
  </tr>
  <tr>
    <td height="46" align="right">&nbsp;</td>
    <td colspan="2">&nbsp;<asp:Button ID="Button1" runat="server" Text="确定发货，并填发货单"  CssClass="Btt" OnClick="Button1_Click"/>&nbsp;&nbsp;<Input  Type="Button" id="Button2" class="Btt" onclick="return btnGetBackValue_onclick()" value="取消选择" >
        <asp:Button ID="Button4" runat="server" Text="直接填写发货单"  CssClass="Btt" OnClick="Button4_Click"/></td>
  </tr>
  <tr>
    <td height="25" align="right">操作说明:</td>
    <td colspan="2"><font color="gray">对已确定审核的销售合同进行发货，未审核的合同单或是作废的合同单不能发货.</font> </td>
  </tr>
</table>
<%--选择采购单结束--%>


<table width="99%" border="0" cellspacing="0" cellpadding="0" align="center">
  <tr>
    <td height="10"><asp:TextBox runat="server" ID="Tbx_WareHouseNo" CssClass="Custom_Hidden"></asp:TextBox></td>
  </tr>
</table>

<table width="99%" border="0" align="center" id="AddPaten" runat="server" visible="false">
 <tr>
    <td width="17%" height="25" align="right" class="tableBotcss">&nbsp;发货单号:</td>
        <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="OutWareNo" MaxLength="40" runat="server" CssClass="Boxx" Width="150px" ></asp:TextBox>(<font color="red">*</font>)唯一性<br />
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="发货单号不能为空" ControlToValidate="OutWareNo" Display="Dynamic"></asp:RequiredFieldValidator></td>
        
            <td width="17%" align="right" class="tableBotcss" style="height: 33px">责任人:</td>
            <td align="left" class="tableBotcss1" style="height: 33px">
            <asp:DropDownList runat="Server" ID="Ddl_DutyPerson"></asp:DropDownList>邮件提醒:<asp:CheckBox ID="Is_Mail" runat="server" Checked="true"  Text="是"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Ddl_DutyPerson"
            Display="Dynamic" ErrorMessage="责任人非空"></asp:RequiredFieldValidator></td>
         </tr>
   
<tr>
     <td width="17%" height="25" align="right" class="tableBotcss">发货日期:</td>
     <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="OutWareDateTime" runat="server"    CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>(<font color="red">*</font>)<br />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="发货日期非空" ControlToValidate="OutWareDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
   
     <td width="17%" height="25" align="right" class="tableBotcss">预计到货日期:</td>
     <td width="36%" align="left" class="tableBotcss1"><asp:TextBox ID="PlanOutWareDateTime" runat="server"    CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>(<font color="red">*</font>)<br />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="预计到货日期非空" ControlToValidate="PlanOutWareDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
   
   </tr>


<tr>
     <td width="17%" height="25" align="right" class="tableBotcss">关联客户:</td>
     <td width="36%" align="left" class="tableBotcss"><input type="hidden" name="CustomerValue" id="CustomerValue" runat="server" />
    <asp:TextBox ID="CustomerValueName" runat="server" CssClass="Boxx2" Width="200px" ReadOnly="true" ></asp:TextBox>
    (<font color="red">*</font>)<div id="Div_Customer" runat="server"><input  type="Button" id="Btn_Customer" name="Btn_Customer" class="Btt" onclick="return btnGetReturnValue_onclick1()" value="选择客户">  
    </div>
      <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户" ControlToValidate="CustomerValueName" Display="Dynamic"></asp:RequiredFieldValidator></td>
      <td width="14%" align="right" class="tableBotcss">原合同编号:</td>
     <td width="33%" align="left" class="tableBotcss1"><asp:TextBox ID="ContractNo" runat="server"  CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox></td>
    
    </tr>

	  
 <tr>
    <td width="17%" height="25" align="right" class="tableBotcss">发货联系人:</td>
    <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="OutWareOursContact" runat="server" MaxLength="40"  CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<br /></td>
    <td width="14%" align="right" class="tableBotcss">收货联系人:</td>
    <td width="33%" align="left" class="tableBotcss1">
    <div id="Div_Content" runat="server">
    <asp:TextBox ID="Tbx_ContentPerson" runat="server" CssClass="Boxx"  MaxLength="48"></asp:TextBox>
    <asp:TextBox ID="Tbx_ContentPersonID" runat="server" CssClass="Custom_Hidden"  MaxLength="48"></asp:TextBox>
    <Input Type="Button" id="Btn_Contenct" class="Btt" onclick="return btnGetContentPerson_onclick()" value="选择联系人">
    </div>
    <asp:DropDownList ID="OutWareSideContact" runat="server" OnTextChanged="OutWareSideContact_TextChanged" AutoPostBack="true" ></asp:DropDownList>(<font color="red">*</font>)<br />
  </td>
 </tr>
     	  
 <tr>
 
    <td width="17%" height="25" align="right" class="tableBotcss">联系电话:</td>
    <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="Phone" runat="server" MaxLength="40"  CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<br /></td>
  <td width="14%" align="right" class="tableBotcss">运输分担:</td>
     <td width="33%" align="left" class="tableBotcss1"><asp:TextBox ID="ContractTranShare" runat="server" MaxLength="9" Text="0.00" CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="运输分担非空" ControlToValidate="ContractTranShare" Display="Dynamic"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" runat="server" ErrorMessage="货币形式.如 85.00" ControlToValidate="ContractTranShare" ValidationExpression="^(-)?(\d+|,\d{3})+(\.\d{0,3})?$" Display="Dynamic" ></asp:RegularExpressionValidator></td>
    </tr> 
<tr>
    <td width="17%" height="25" align="right" class="tableBotcss">交货地点:</td>
    <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="ContractToAddress" runat="server" CssClass="Boxx"  MaxLength="48"></asp:TextBox></td>
    <td width="14%" align="right" class="tableBotcss">交货方式:</td>
    <td width="33%" align="left" class="tableBotcss1"><asp:DropDownList ID="ContractDeliveMethods" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="交货方式不能为空" ControlToValidate="ContractDeliveMethods" Display="Dynamic"></asp:RequiredFieldValidator></td>
 </tr>
      
<tr >
        <td width="17%" height="25" align="right" class="tableBotcss">所属分部:</td>
        <td align="left" class="tableBotcss"><asp:DropDownList ID="OutWareStaffBranch" runat="server" Width="150px" OnSelectedIndexChanged="OrderStaffBranch_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>(<font color="red">*</font>)<br />
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" runat="server" ErrorMessage="所属分部名称不能为空" ControlToValidate="OutWareStaffBranch" Display="Dynamic"></asp:RequiredFieldValidator></td>
        <td align="right" class="tableBotcss">部门:</td>
        <td align="left" class="tableBotcss1"><asp:DropDownList ID="OutWareStaffDepart" runat="server" Width="150px"></asp:DropDownList></td>
</tr>

<tr>
   <td height="25" align="right" class="tableBotcss">经办(发货)人:</td>
   <td align="left" class="tableBotcss"><asp:TextBox ID="OutWareStaffNo" runat="server" CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox>
   <asp:Label ID="OutWareStaffNotxt" runat="server" Text="" Visible="false"></asp:Label></td>
   <td align="right" class="tableBotcss">审核人:</td>
   <td align="left" class="tableBotcss1"><asp:TextBox ID="OutWareCheckStaffNo" runat="server" CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox>
   <asp:Label ID="OutWareCheckStaffNotxt" runat="server"  Visible="false" ></asp:Label></td>
</tr>
<tr>
        <td height="12" align="right" class="tableBotcss" >备注说明:</td>
        <td colspan="3" align="left" valign="top" class="tableBotcss1"  ><asp:TextBox ID="OutWareRemarks" TextMode="MultiLine" runat="server" CssClass="Boxx" Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4"  runat=server   ControlToValidate="OutWareRemarks"  ValidationExpression="^(\s|\S){0,300}$" ErrorMessage="备注太多，限少于300个字." display="dynamic"></asp:RegularExpressionValidator></td>
 </tr>
 
<tr>
  <td height="12" align="right" class="tableBotcss" >&nbsp;</td>
  <td colspan="3" align="left" valign="top"  class="tableBotcss1" >&nbsp;<asp:Button ID="Button3" runat="server" Text="确定添加发货单" CssClass="Btt" OnClick="Button3_Click" /></td>
</tr>
</table>

<%--收货单信息  结束--%>


<!--底部功能栏 -->
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="30" >&nbsp;&nbsp;</td>
  </tr>
</table>
<!--底部功能栏-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>
