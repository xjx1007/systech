<%@ Page Language="C#" EnableEventValidation="false"  ValidateRequest="false" AutoEventWireup="true" CodeFile="Knet_Sales_Ship_Manage_AddDetails.aspx.cs" Inherits="Knet_Web_Sales_Knet_Sales_Ship_Manage_AddDetails" %>
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
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">销售发货管理</div></td>
    <td  background="../../images/ktxt2.gif" >&nbsp;<font color="blue">提示：</font><font color="#999999">点击左边<img src="../../images/up.jpg" width="20" height="20" /> 可把发货单往上收缩方便编辑发货明细，点 <img src="../../images/down.jpg" width="20" height="20" />可把发货单向下展开...</font>&nbsp;</td>
    <td background="../../images/ktxt2.gif" >&nbsp;</td>
  </tr>
</table>
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="3"></td>
  </tr>
</table>


<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td valign="top">
    
<%--发添加的发货单--%>
<table width="99%" border="0" align="center">
    
 <tr>
    <td width="17%" height="25" align="right" class="tableBotcss"><asp:ImageButton ID="ImageButton_down" runat="server" ImageUrl="../../images/down.jpg"  Visible="false"  CausesValidation="false" OnClick="ImageButton_down_Click"  /><asp:ImageButton ID="ImageButton_up" runat="server" ImageUrl="../../images/up.jpg"  OnClick="ImageButton_up_Click"  CausesValidation="false" />&nbsp;发货单号:</td>
    <td width="36%" align="left" class="tableBotcss" ><asp:TextBox ID="OutWareNo" MaxLength="40" runat="server" CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox>(<font color="red">*</font>)</td>
    
            <td width="17%" align="right" class="tableBotcss" style="height: 33px">责任人:</td>
            <td align="left" class="tableBotcss1" style="height: 33px">
            <asp:DropDownList runat="Server" ID="Ddl_DutyPerson"></asp:DropDownList>邮件提醒:<asp:CheckBox ID="Is_Mail" runat="server" Checked="true"  Text="是"/><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Ddl_DutyPerson"
            Display="Dynamic" ErrorMessage="责任人非空"></asp:RequiredFieldValidator></td>
   </tr>

   
<tr>
 <td  height="25" align="right" class="tableBotcss">发货日期:</td>
 <td  align="left" class="tableBotcss"><asp:TextBox ID="OutWareDateTime" runat="server"    CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>(<font color="red">*</font>)<br />
 <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="发货日期非空" ControlToValidate="OutWareDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
      <td width="17%" height="25" align="right" class="tableBotcss">预计到货日期:</td>
     <td width="36%" align="left" class="tableBotcss1"><asp:TextBox ID="PlanOutWareDateTime" runat="server"    CssClass="Wdate" onClick="WdatePicker()" ></asp:TextBox>(<font color="red">*</font>)<br />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="预计到货日期非空" ControlToValidate="PlanOutWareDateTime" Display="Dynamic"></asp:RequiredFieldValidator></td>
   
</tr>


<tr >
  <td  height="25" align="right" class="tableBotcss">关联客户:</td>
  <td  align="left" class="tableBotcss"><input type="hidden" name="CustomerValue" id="CustomerValue" runat="server" />
  <asp:TextBox ID="CustomerValueName" runat="server" CssClass="Boxx2" Width="250px" ReadOnly="true" ></asp:TextBox>(<font color="red">*</font>)</td>
   <td  align="right" class="tableBotcss">原合同编号:</td>
 <td  align="left" class="tableBotcss1"><asp:TextBox ID="ContractNo" runat="server"  CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox></td>
</tr>

	  
 <tr id="Cshow" runat="server">
    <td  height="25" align="right" class="tableBotcss">发货联系人:</td>
    <td  align="left" class="tableBotcss"><asp:TextBox ID="OutWareOursContact" runat="server" MaxLength="40"  CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<br />
     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="发货联系人非空" ControlToValidate="OutWareOursContact" Display="Dynamic"></asp:RequiredFieldValidator></td>
    <td  align="right" class="tableBotcss">收货联系人:</td>
    <td  align="left" class="tableBotcss1"><asp:DropDownList ID="OutWareSideContact" runat="server" OnTextChanged="OutWareSideContact_TextChanged" AutoPostBack="true" ></asp:DropDownList>(<font color="red">*</font>)<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="收货联系人非空" ControlToValidate="OutWareSideContact" Display="Dynamic"></asp:RequiredFieldValidator></td>
 </tr>
 
 <tr id="Cshow_1" runat="server">
 
    <td width="17%" height="25" align="right" class="tableBotcss">联系电话:</td>
    <td width="36%" align="left" class="tableBotcss"><asp:TextBox ID="Phone" runat="server" MaxLength="40"  CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<br /></td>
  <td  align="right" class="tableBotcss">运输分担:</td>
  <td  align="left" class="tableBotcss1"><asp:TextBox ID="ContractTranShare" runat="server" MaxLength="9" Text="0.00" CssClass="Boxx"></asp:TextBox>(<font color="red">*</font>)<br />
  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="运输分担非空" ControlToValidate="ContractTranShare" Display="Dynamic"></asp:RequiredFieldValidator>
  <asp:RegularExpressionValidator  ID="RegularExpressionValidator1" runat="server" ErrorMessage="货币形式.如 85.00" ControlToValidate="ContractTranShare" ValidationExpression="^(-)?(\d+|,\d{3})+(\.\d{0,3})?$" Display="Dynamic" ></asp:RegularExpressionValidator></td>
</tr> 
      
<tr id="Dshow" runat="server">
    <td  height="25" align="right" class="tableBotcss">交货地点:</td>
    <td  align="left" class="tableBotcss"><asp:TextBox ID="ContractToAddress" runat="server" CssClass="Boxx"  MaxLength="48"></asp:TextBox></td>
    <td  align="right" class="tableBotcss">交货方式:</td>
    <td  align="left" class="tableBotcss1"><asp:DropDownList ID="ContractDeliveMethods" runat="server" Width="150px"></asp:DropDownList>(<font color="red">*</font>)<br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="交货方式不能为空" ControlToValidate="ContractDeliveMethods" Display="Dynamic"></asp:RequiredFieldValidator></td>
 </tr>
      
<tr  id="Eshow" runat="server">
        <td height="25" align="right" class="tableBotcss">所属分部:</td>
        <td align="left" class="tableBotcss"><asp:DropDownList ID="OutWareStaffBranch" runat="server" Width="150px" OnSelectedIndexChanged="OrderStaffBranch_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>(<font color="red">*</font>)<br />
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator3" runat="server" ErrorMessage="所属分部名称不能为空" ControlToValidate="OutWareStaffBranch" Display="Dynamic"></asp:RequiredFieldValidator></td>
        <td align="right" class="tableBotcss">部门:</td>
        <td align="left" class="tableBotcss1"><asp:DropDownList ID="OutWareStaffDepart" runat="server" Width="150px"></asp:DropDownList></td>
</tr>

<tr id="Fshow" runat="server">
   <td height="25" align="right" class="tableBotcss">经办(发货)人:</td>
   <td align="left" class="tableBotcss"><asp:TextBox ID="OutWareStaffNo" runat="server" CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox>
   <asp:Label ID="OutWareStaffNotxt" runat="server" Text="" Visible="false"></asp:Label></td>
   <td align="right" class="tableBotcss">审核人:</td>
   <td align="left" class="tableBotcss1"><asp:TextBox ID="OutWareCheckStaffNo" runat="server" CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox>
   <asp:Label ID="OutWareCheckStaffNotxt" runat="server"  Visible="false" ></asp:Label></td>
</tr>


<tr id="GShow" runat="server">
  <td height="37" align="right" class="tableBotcss">备注说明:</td>
  <td colspan="2" align="left" valign="top" class="tableBotcss" ><asp:TextBox ID="OutWareRemarks" TextMode="MultiLine" runat="server" CssClass="Boxx" Width="450px" Height="50px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator4"  runat=server   ControlToValidate="OutWareRemarks"  ValidationExpression="^(\s|\S){0,300}$" ErrorMessage="备注太多，限少于400个字." display="dynamic"></asp:RegularExpressionValidator></td>
  <td align="center" valign="bottom" class="tableBotcss1"><asp:Button ID="Button3" runat="server" Text="编辑并保存发货单" OnClick="Button3_Click" CssClass="Btt"  /></td>
</tr>

 <tr>
 <td height="25" colspan="4" align="left">
<table width="100%" border="0" height="20px" cellspacing="0" cellpadding="0" id="AddProuPar" runat="server">
  <tr>
    <td width="16%" align="right"><B>手工选择录入:</B></td>
    <td width="34%" align="left"><asp:ImageButton ID="Button2" ImageUrl="../../images/selecpruduts.gif" runat="server" /></td> <td width="20%" align="right">&nbsp;<%--<B>条形码(编码)扫描录入:</B>--%></td>
    <td width="30%" align="left">&nbsp;<%--<asp:TextBox ID="ProductsBarCode" runat="server" Width="200px" CssClass="Boxx" OnTextChanged="txtProduct_SN_TextChanged" AutoPostBack="true"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
    ID="RequiredFieldValidator9" runat="server" ErrorMessage="不能为空" ControlToValidate="ProductsBarCode" Display="Dynamic" ValidationGroup="OlDnwsssssssssss" ></asp:RequiredFieldValidator>--%></td>
   
  </tr>
</table>
</td>
  </tr>
</table>

<%--发添加结束--%>
    
    
    
    </td>
  </tr>
</table>

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
        
        <asp:BoundField  DataField="ProductsBarCode"   HeaderText="编号(条码)"  SortExpression="ProductsBarCode" ReadOnly="true">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="120px"/>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
        </asp:BoundField>
        
        <asp:BoundField  DataField="ProductsPattern"   HeaderText="产品型号"  SortExpression="ProductsPattern" ReadOnly="true">
            <ItemStyle HorizontalAlign="Left"  Font-Size="12px"  Width="100px" />
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  />
       </asp:BoundField>
       
            <asp:TemplateField HeaderText="版本" >    
                <ItemTemplate>
                    <%#base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="单位"  SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"     ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%> 
           </ItemTemplate>
        </asp:TemplateField>
        

      <asp:TemplateField HeaderText="数量" SortExpression="OutWareAmount" HeaderStyle-Font-Size="12px" HeaderStyle-ForeColor="blue" ItemStyle-Width="40px"   ControlStyle-Width="40px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OutWareAmount")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
      
      
      <asp:TemplateField HeaderText="销售单价" SortExpression="OutWare_SalesUnitPrice"   HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ControlStyle-Width="60px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <asp:Label ID="Label1B" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OutWare_SalesUnitPrice")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
      
      
      <asp:TemplateField HeaderText="金额调节"   SortExpression="OutWare_SalesDiscount"   HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ControlStyle-Width="60px"  ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
              <asp:Label ID="Label1C" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"OutWare_SalesDiscount")%>'></asp:Label>
          </ItemTemplate>
      </asp:TemplateField>
        
      
       <asp:BoundField  DataField="OutWare_SalesTotalNet" ReadOnly="true" ItemStyle-Font-Size="12px"  SortExpression="OutWare_SalesTotalNet"  HeaderText="金额小计" ItemStyle-Width="70px"   HeaderStyle-Font-Size="12px"  DataFormatString="{0:N}" HtmlEncode="false">
            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
            <HeaderStyle  HorizontalAlign="Left" Font-Size="12px" />
        </asp:BoundField> 
        
      
       <asp:BoundField  DataField="OutWareRemarks"  SortExpression="OutWareRemarks"   HeaderText="备注说明" ControlStyle-CssClass="Boxx" ControlStyle-Width="70px" >
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
