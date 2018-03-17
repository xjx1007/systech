<%@ Page Language="C#" EnableEventValidation="false"  ValidateRequest="false" AutoEventWireup="true" CodeFile="KNet_Sales_ContractList_Manage_AddDetails.aspx.cs" Inherits="Knet_Web_Sales_KNet_Sales_ContractList_Manage_AddDetails" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
<script language="javascript"> 
function refresh() 
{ 
this.location = this.location; 
} 
</script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
  <SCRIPT LANGUAGE=JAVASCRIPT>
    function btnGetReturnValue_onclick()  
    {   
       /*选择客户*/
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("../Common/SelectSalesClientListProtect.aspx?sID="+intSeconds+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(temp!=undefined)   
       {   
          	 var ss;
	         ss=temp.split("|");
             document.all('CustomerValue').value = ss[0];
             document.all('CustomerValueName').value =ss[1];
        }   
       else
        {
             document.all('CustomerValue').value = ""; 
             document.all('CustomerValueName').value = ""; 
        }
    }
</SCRIPT>


<SCRIPT LANGUAGE=JAVASCRIPT>
    function btnGetBaoPriceValue_onclick()  
    {   
       var todayw,intSecondsw;
       todayw = new Date();
       intSecondsw = todayw.getSeconds();
       var temp= window.showModalDialog("../Common/SelectBaoPriceList.aspx?sID="+intSecondsw+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(temp!=undefined)   
       {   
          	 var ss;
	         ss=temp.split("|");
             document.all('BaoPriceNo').value = ss[0];
             document.all('BaoPriceNoName').value =ss[1];
        }   
       else
        {
             document.all('BaoPriceNo').value = ""; 
             document.all('BaoPriceNoName').value = ""; 
        }
    }
</SCRIPT>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">


<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="3"></td>
  </tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">销售合同明细</div></td>
    <td  background="../../images/ktxt2.gif" >&nbsp;<font color="blue">提示:</font><font color="#999999">点击左边<img src="../../images/up.jpg" width="20" height="20" /> 可把合同往上收缩方便编辑合同明细，点 <img src="../../images/down.jpg" width="20" height="20" />可把合同向下展开...</font>&nbsp;</td>
    <td background="../../images/ktxt2.gif" >&nbsp;</td>
  </tr>
</table>
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="3"></td>
  </tr>
</table>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_add">
  <tr>
    <td valign="top">
    
<%--发添加的报价单--%>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" >
    
 <tr>
        <td width="17%" height="25" align="right"  class="tableBotcss"><asp:ImageButton ID="ImageButton_down" runat="server" ImageUrl="../../images/down.jpg"  Visible="false"  CausesValidation="false" OnClick="ImageButton_down_Click"  /><asp:ImageButton ID="ImageButton_up" runat="server" ImageUrl="../../images/up.jpg"  OnClick="ImageButton_up_Click"  CausesValidation="false" />&nbsp;合同编号:</td>
        <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="ContractNo" MaxLength="40" runat="server" CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox>(<font color="red">*</font>)</td>
         <td align="right" class="tableBotcss">签订日期:</td>
    <td align="left" class="tableBotcss"><asp:TextBox ID="ContractDateTime" runat="server"  MaxLength="20"  CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>(<font color="red">*</font>)<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="签订日期非空" ControlToValidate="ContractDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
  </tr>
      
      
 <tr runat="server" >
    <td width="17%" height="25" align="right" class="tableBotcss">关联客户:</td>
    <td align="left" class="tableBotcss">
    <input type="hidden" name="CustomerValue" id="CustomerValue" runat="server" />
    <asp:TextBox ID="CustomerValueName" runat="server" CssClass="Boxx2" Width="350px" ReadOnly="true" ></asp:TextBox>(<font color="red">*</font>)<Input  Type="Button" id=" btnGetReturnValue" class="Btt" onclick="return btnGetReturnValue_onclick()" value="选择客户"><br />
    <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户" ControlToValidate="CustomerValueName" Display="Dynamic"></asp:RequiredFieldValidator></td>
    
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">责任人:</td>
    <td align="left" class="tableBotcss" style="height: 33px">
    <asp:DropDownList runat="Server" ID="Ddl_DutyPerson"></asp:DropDownList>
   </td>
   
   </tr>


  <tr>
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">
        地址:</td>
    <td width="36%" align="left" class="tableBotcss" style="height: 33px"><asp:TextBox ID="ContractToAddress" runat="server" CssClass="Boxx"  MaxLength="48" Width="300px"></asp:TextBox></td>
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">交货方式:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:DropDownList ID="ContractDeliveMethods" runat="server" Width="150px"></asp:DropDownList></td>
 </tr>
 
  <tr>
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">
        联系人:</td>
    <td width="36%" align="left" class="tableBotcss" style="height: 33px"><asp:TextBox ID="Tbx_ContentPerson" runat="server" CssClass="Boxx"  MaxLength="48"></asp:TextBox></td>
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">电话:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:TextBox ID="Tbx_Telephone" runat="server" CssClass="Boxx"  MaxLength="48"></asp:TextBox></td>
 </tr>
 <asp:Panel ID="Panel1" runat="server">
<tr  >
  <td width="17%" height="25" align="right" class="tableBotcss">开始日期:</td>
  <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="ContractStarDateTime" runat="server" MaxLength="20"   CssClass="Wdate"   onFocus="var ContractEndtDateTime=$dp.$('ContractEndtDateTime');WdatePicker({onpicked:function(){ContractEndtDateTime.focus();},maxDate:'#F{$dp.$D(\'ContractEndtDateTime\')}'})" ></asp:TextBox>(<font color="red">*</font>)<br />
  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="开始日期非空" ControlToValidate="ContractStarDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">交货日期:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:TextBox ID="ContractToDeliDate" runat="server" MaxLength="20" CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox></td>
  <asp:TextBox ID="ContractEndtDateTime" runat="server" MaxLength="20"    CssClass="Custom_Hidden"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'ContractStarDateTime\')}'})"  ></asp:TextBox>
</tr>
 
 <tr >
    <td width="14%" align="right" class="tableBotcss">合同分类:</td>
    <td width="33%" align="left" class="tableBotcss"><asp:DropDownList ID="ContractClass" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="合同分类不能为空" ControlToValidate="ContractClass" Display="Dynamic"></asp:RequiredFieldValidator></td>
    <td width="14%" align="right" class="tableBotcss" style="color: #000000; height: 33px;">付款方式:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px"><asp:DropDownList ID="Drop_Payment" runat="server" Width="150px"></asp:DropDownList></td>
    
 </tr>
 
 
 <tr>
   
    <td width="14%" align="right" class="tableBotcss" style="height: 33px">运输方式:</td>
    <td width="33%" align="left" class="tableBotcss" style="height: 33px" colspan="3">常规：<asp:DropDownList ID="Drop_RoutineTransport" runat="server" Width="150px"></asp:DropDownList>
    应急：<asp:DropDownList ID="Drop_WorryTransport" runat="server" Width="150px"></asp:DropDownList></td>
 </tr>
 
 
<tr >
    <td width="17%" height="25" align="right" class="tableBotcss">关联报价:</td>
    <td width="36%" align="left" class="tableBotcss">
    <input type="hidden" name="BaoPriceNo" id="BaoPriceNo" runat="server" />
    <asp:TextBox ID="BaoPriceNoName" runat="server" CssClass="Boxx2" Width="150px" ReadOnly="true" ></asp:TextBox>(<font color="red">*</font>)<Input  Type="Button" id="Button1" class="Btt" onclick="return btnGetBaoPriceValue_onclick()" value="选择报价单"><br />
    <asp:RequiredFieldValidator  ID="RequiredFieldValidator14" runat="server" ErrorMessage="选择关联报价单" ControlToValidate="BaoPriceNoName" Display="Dynamic"></asp:RequiredFieldValidator></td>
    <td width="14%" align="right" class="tableBotcss">结算方式:</td>
    <td width="33%" align="left" class="tableBotcss"><asp:DropDownList ID="ContractToPayment" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)
    <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="结算方式不能为空" ControlToValidate="ContractToPayment" Display="Dynamic"></asp:RequiredFieldValidator></td>
 </tr>
      
            
<tr >
    <td width="17%" align="right" class="tableBotcss" style="height: 33px">发货要求:</td>
    <td align="left" class="tableBotcss" style="height: 33px" colspan="3"><asp:TextBox runat="server" ID="Tbx_ContractShip" Width="300px" ></asp:TextBox>   <asp:CheckBox ID="ProductsPic" runat="server" OnCheckedChanged="ProductsPic_CheckedChanged" AutoPostBack="true" /><font color="gray">（上传图片的请打勾）</font></td>

    </tr>
     <tr id="AddPic" runat="server" visible="false">
        <td height="25" align="right" class="tdcss">请选择图片:</td>
        <td colspan="3" align="left" class="tdcss"><asp:Label ID="Image1Big" runat="server" Text="" Visible="false"></asp:Label>
	 <asp:Image ID="Image1" runat="server" Width="95px" Height="75px" />&nbsp;<input id="uploadFile" type="file" runat="server" class="Boxx" size="30" />&nbsp;<input id="button" type="button" value="上传图片"  runat="server" class="Btt" onserverclick="button_ServerClick"  causesvalidation="false" /></td>
    </tr><asp:DropDownList ID="ContractStaffDepart" runat="server" Width="150px"  Visible="false"></asp:DropDownList><asp:DropDownList ID="ContractStaffBranch" runat="server" Width="150px" OnSelectedIndexChanged="OrderStaffBranch_SelectedIndexChanged" AutoPostBack="true" Visible="false"></asp:DropDownList>
<tr>
        <td align="right" class="tableBotcss" style="height: 30px">技术要求:</td>
        <td align="left" valign="top" class="tableBotcss" style="height: 30px"><asp:TextBox ID="Tbx_TechnicalRequire"  runat="server" CssClass="Boxx" Width="300px" ></asp:TextBox></td>

        <td align="right" class="tableBotcss" style="height: 30px">产品包装:</td>
        <td  align="left" valign="top" class="tableBotcss" style="height: 30px"><asp:TextBox ID="Tbx_ProductPackaging"  runat="server" CssClass="Boxx" Width="300px" ></asp:TextBox></td>
</tr>
 
<tr>
        <td height="37" align="right" class="tableBotcss">质量要求:</td>
        <td align="left" valign="top" class="tableBotcss"><asp:TextBox ID="Tbx_QualityRequire"  runat="server" CssClass="Boxx" Width="300px" ></asp:TextBox></td>

        <td align="right" class="tableBotcss" style="height: 30px">质保期:</td>
        <td  align="left" valign="top" class="tableBotcss" style="height: 30px"><asp:TextBox ID="Tbx_WarrantyPeriod"  runat="server" CssClass="Boxx" Width="300px" ></asp:TextBox></td>
</tr>
<tr >
        <td height="37" align="right" class="tableBotcss">备货要求:</td>
        <td align="left" valign="top" class="tableBotcss" colspan="3"><asp:TextBox ID="Tbx_DeliveryRequire"  runat="server" CssClass="Boxx" Width="300px" ></asp:TextBox></td>
</tr>
<tr >
        <td height="37" align="right" class="tableBotcss">备注说明:</td>
        <td  align="left" valign="top" class="tableBotcss" colspan="3"><asp:TextBox ID="ContractRemarks" TextMode="MultiLine" runat="server" CssClass="Boxx" Width="300px" Height="50px"></asp:TextBox></td>
        
</tr>
<tr>
<td><asp:Button ID="Button3" runat="server" Text="编辑并保存合同单" OnClick="Button3_Click" CssClass="Btt"  /></td></tr>

 </asp:Panel>
 <tr>
 <td height="25" colspan="4" align="left">
 
<table width="100%" border="0" height="20px" cellspacing="0" cellpadding="0" id="AddProuPar" runat="server">
          <tr>
          <td width="16%" align="right"><B>选择产品:</B></td>
            <td width="34%" align="left"><asp:ImageButton ID="Button2" ImageUrl="../../images/selecpruduts.gif" runat="server" /></td>
             <td width="20%" align="right"></td>
            <td width="30%" align="left"><asp:TextBox ID="ProductsBarCode" runat="server" Width="200px"  Visible="false" CssClass="Boxx"></asp:TextBox></td>
      
          </tr>
</table>
</td>
  </tr>
</table>
</table>

<%--发添加结束--%>
    
    
    
    </td>
  </tr>

<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="3"></td>
  </tr>
</table>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td valign="top">

  <asp:GridView ID="GridView1" runat="server"  AllowSorting="True"  EmptyDataText="<div align=center><font color=Blue><br/><br/><B>暂时没有添加明细记录，请按上面的两种方式之一录入</B><br/><br/></font></div>"  GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px"
        OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_Editing"  OnSorting="GridView1_Sorting"  OnRowDataBound="GridView1_DataRowBinding"  OnRowDeleting="GridView1_del">
        <Columns>
        

        <asp:BoundField   HeaderText="序"  ItemStyle-Height="25px" ItemStyle-Width="25px"  HeaderStyle-Font-Size="12px"  HeaderStyle-HorizontalAlign="Left" ReadOnly="true"  >
            <ItemStyle HorizontalAlign="Left"  />
        </asp:BoundField>
        
        
        <asp:BoundField  DataField="ProductsName"  HeaderText="产品名称"  SortExpression="ProductsName" ReadOnly="true">
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        
        <asp:BoundField  DataField="ProductsPattern"   HeaderText="产品型号"  SortExpression="ProductsPattern" ReadOnly="true">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"   />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
       </asp:BoundField>
        
         <asp:TemplateField HeaderText="版本"  SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%> 
           </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="单位"  SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits").ToString()) %> 
           </ItemTemplate>
        </asp:TemplateField>
        

      <asp:TemplateField HeaderText="数量" SortExpression="ContractAmount" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          
          <EditItemTemplate> 
                <asp:TextBox ID="Orsdnttxtsgsdg" MaxLength="10" runat="server" CssClass="Boxx" Width="100"  Text='<%# DataBinder.Eval(Container.DataItem,"ContractAmount")%>'></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="Ordersdcountra"  runat="server" ErrorMessage="非空值!" ControlToValidate="Orsdnttxtsgsdg" Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="Ordsdountrbb" runat="server" ErrorMessage="正整数!" ControlToValidate="Orsdnttxtsgsdg" ValidationExpression="^\+?[0-9][0-9]*$" Display="Dynamic" ValidationGroup="88"></asp:RegularExpressionValidator>
          </EditItemTemplate>
          <ItemTemplate>
              <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"ContractAmount")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
      
      <asp:TemplateField HeaderText="备品数量" SortExpression="KSC_BNumber" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          
          <EditItemTemplate> 
                <asp:TextBox ID="BNumber" MaxLength="10" runat="server" CssClass="Boxx" Text='<%# DataBinder.Eval(Container.DataItem,"KSC_BNumber")%>' Width="100" ></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="BNumberaa"  runat="server" ErrorMessage="非空值!" ControlToValidate="BNumber" Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="BNumberbb" runat="server" ErrorMessage="正整数!" ControlToValidate="BNumber" ValidationExpression="^\+?[0-9][0-9]*$" Display="Dynamic" ValidationGroup="88"></asp:RegularExpressionValidator>
          </EditItemTemplate>
          <ItemTemplate>
              <asp:Label ID="LabelBNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"KSC_BNumber")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
      
      <asp:TemplateField HeaderText="销售单价" SortExpression="Contract_SalesUnitPrice"   HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <EditItemTemplate> 
                <asp:TextBox ID="OrderUnitPricetxt" MaxLength="10"  runat="server" CssClass="Boxx" Text='<%#  base.FormatNumber(DataBinder.Eval(Container.DataItem,"Contract_SalesUnitPrice").ToString(),3)%>'></asp:TextBox><br />
                <asp:RequiredFieldValidator ID="OrderUnitPricera"  runat="server" ErrorMessage="非空值!" ControlToValidate="OrderUnitPricetxt" Display="Dynamic" ValidationGroup="88"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="OrderUnitPricerbb" runat="server" ErrorMessage="货币形式(正)!" ControlToValidate="OrderUnitPricetxt" ValidationExpression="^(\d+|,\d{3})+(\.\d{0,3})?$"  Display="Dynamic" ValidationGroup="88"></asp:RegularExpressionValidator>
          </EditItemTemplate>
          <ItemTemplate>
              <asp:Label ID="Label1B" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"Contract_SalesUnitPrice")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
         <asp:TemplateField HeaderText="电池"  HeaderStyle-Font-Size="12px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <%#base.Base_GetProductsPattern( DataBinder.Eval(Container.DataItem, "KSD_OrderNumber").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="说明书"  HeaderStyle-Font-Size="12px"    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <%#base.Base_GetBasicCodeName("134", DataBinder.Eval(Container.DataItem, "KSD_MaterNumber").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      
       <asp:BoundField  DataField="Contract_SalesTotalNet" ReadOnly="true" ItemStyle-Font-Size="12px"  SortExpression="Contract_SalesTotalNet"  HeaderText="金额小计" DataFormatString="{0:N}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
      
       <asp:BoundField  DataField="ContractRemarks"  SortExpression="ContractRemarks"   HeaderText="备注说明" ControlStyle-CssClass="Boxx" ControlStyle-Width="70px" >
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="90px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
      
      
      
      
      <asp:CommandField  ButtonType="Image" HeaderImageUrl="../../images/register.gif" HeaderText="编辑与管理明细记录"   ShowEditButton="true"  EditImageUrl="../../images/Eedit.gif"  EditText="编辑此记录"  ShowDeleteButton="true"  DeleteImageUrl="../../images/icon_delete.gif" DeleteText="删除此记录"  CancelImageUrl="../../images/connet.gif" CancelText="取消编辑" ValidationGroup="88"  UpdateImageUrl="../../images/Esave.gif" UpdateText="保存编辑">
            <ItemStyle HorizontalAlign="Left" Width="1%" Font-Size="12px"/>
            <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
        </asp:CommandField>

      </Columns>
         
            <FooterStyle BackColor="LightSteelBlue" />
            <HeaderStyle BackColor="LightSteelBlue" />
            <AlternatingRowStyle BackColor="WhiteSmoke" />
             <PagerStyle HorizontalAlign="Left" />
  </asp:GridView>
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0"  bgcolor="WhiteSmoke" style="border-top:1px solid #A3B2CC;">
<tr>
 <td width="20%" height="25" align="left">&nbsp;<asp:Label ID="DoDinfion" runat="server" Text=""></asp:Label></td>
 <td width="80%" align="right" ><asp:Label ID="HeXinQ" runat="server"  Font-Size="13px"></asp:Label>&nbsp;&nbsp;</td>
</tr>
</table>    
<!--分页-->
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top:1px solid #A3B2CC;">
  <tr>
    <td height="24" bgcolor="#F2F4F9">
    <webdiyer:aspnetpager id="AspNetPager1" runat="server" horizontalalign="left" onpagechanged="AspNetPager1_PageChanged"
    showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:13px" PageIndexBoxStyle="width:18px;border-top:1px solid #A3B2CC;border-left:1px solid #A3B2CC;border-right:1px solid #A3B2CC;border-bottom:1px solid #A3B2CC;height:17px;"
    CustomInfoHTML="　当前页<font color='red'><b>%CurrentPageIndex%</b></font>共%PageCount%页，记录%StartRecordIndex%-%EndRecordIndex%" 
    ShowNavigationToolTip="True" CustomInfoStyle="font-size:13px;padding-top:5px;width:280px;" TextAfterPageIndexBox=" " SubmitButtonText="  转" SubmitButtonStyle="width:41px;height:21px;border: none;cursor:hand;background-image: url(../../images/go.gif)"  CustomInfoTextAlign="left"  ShowPageIndexBox="Always" AlwaysShow="True" 
    FirstPageText="【首页】" LastPageText="【尾页】" NextPageText="【下页】" PageSize="10" PrevPageText="【前页】">    </webdiyer:aspnetpager>    </td>
</tr>
</table>
<!--分页-->

    </td>
  </tr>
</table>


    </form>
</body>
</html>
