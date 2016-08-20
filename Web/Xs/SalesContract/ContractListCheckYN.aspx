<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContractListCheckYN.aspx.cs" Inherits="Knet_Web_Sales_pop_ContractListCheckYN" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../css/knetwork.css" type="text/css">
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<title>合同进展操作--审核</title>
<script>   
  function closeWindow()   
  {   
  window.opener=null;   
  window.close();   
  }   
  </script>   
  
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>

<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">合同审核</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;</td>
    <td width="216" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="center">&nbsp;</td>
  </tr>
</table>
<table width="98%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="2"></td>
  </tr>
</table>



<%--内容开始--%>

<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
    
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss_add">
 <tr>
        <td width="17%" height="25" align="right"  class="tableBotcss">合同编号：</td>
        <td width="36%" align="left" class="tableBotcss"><asp:Label ID="ContractNo" runat="server"></asp:Label></td>
         <td align="right" class="tableBotcss">签订日期：</td>
        <td align="left" class="tableBotcss"><asp:Label ID="ContractDateTime" runat="server"></asp:Label></td>
  </tr>
      
      
 <tr >
    <td width="17%" height="25" align="right" class="tableBotcss">客户:</td>
    <td align="left" class="tableBotcss" >
    <asp:Label ID="CustomerName" runat="server"></asp:Label></td>
    <td width="17%" height="25" align="right" class="tableBotcss">责任人:</td>
    <td align="left" class="tableBotcss" >
    <asp:Label ID="Lbl_DutyPerson" runat="server"></asp:Label></td>
   </tr>
</table>
           </td>
      </tr>
  <tr>
    <td>

<asp:Label ID="UsersNotxt" runat="server" Text="" Visible="false"></asp:Label>


<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0">
<tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">审核意见：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">
    <asp:TextBox  runat="server"  ID="Tbx_Remark" Text="" TextMode="MultiLine" Width="170px" Height="100px"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">回复交货期：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">
    <asp:TextBox ID="Tbx_ReDate" runat="server"  MaxLength="20"  CssClass="Wdate"  onFocus="WdatePicker()"></asp:TextBox>
    <asp:TextBox ID="Tbx_OldReDate" runat="server"  MaxLength="20"  CssClass="Custom_Hidden" onClick="WdatePicker()" ></asp:TextBox>
    <asp:Label runat="server" ID="Lbl_Date"></asp:Label>
    </td>
  </tr>
  <tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">合同审核选择：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
       <asp:ListItem Value="-1">请选择审核</asp:ListItem>
       <asp:ListItem Value="1">通过审核</asp:ListItem>
       <asp:ListItem Value="0">不通过审核</asp:ListItem>
       <asp:ListItem Value="3">异常通过</asp:ListItem>
       <asp:ListItem Value="2">合同作废</asp:ListItem>
    </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td width="36%" height="30" align="right" style="border-bottom:#A3B2CC 1px solid;">是否发送提醒邮件：</td>
    <td width="64%" style="border-bottom:#A3B2CC 1px solid;">
    <asp:CheckBox runat="server" ID="Chk_IsShow" Text="是" Checked="true" />
    </td>
  </tr>
        <tr>
           <td height="30" colspan="2" align="center" >&nbsp;<font color="gray"></font>
            <asp:Label ID="MyStatStr" runat="server" Text="" Visible="false" ForeColor="red" ></asp:Label>
           </td>
      </tr>
  <tr>
    <td height="30" colspan="2" align="center" >&nbsp;
    <asp:Button ID="Button1" runat="server" Text="确定审核" CssClass="Btt" OnClick="Button1_Click" style="width: 70px;height: 33px;"  />&nbsp;<input   name="button2"   type="button"   value="关闭本窗口"  class="Btt"  onclick="closeWindow();" style="width: 70px;height: 33px;"> </td>
  </tr>
       <tr>
           <td height="30" colspan="2" align="left" >
                  <asp:GridView ID="GridView1" runat="server" Width="99%"  AllowSorting="True"  EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"  GridLines="None" HorizontalAlign="center" AutoGenerateColumns="false"  ShowHeader="true"  HeaderStyle-Height="25px" >
        <Columns>
        
        
      <asp:TemplateField HeaderText="审核人"  SortExpression="KSF_ShPerson" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KSF_ShPerson").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="所在部门"  SortExpression="StaffDepart" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "StaffDepart").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
      <asp:TemplateField HeaderText="职位"  SortExpression="Position" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# base.Base_GetBasicCodeName("105",DataBinder.Eval(Container.DataItem, "Position").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
         <asp:BoundField  HeaderText="审核时间"  DataField="KSF_Date"  ItemStyle-Width="70px"  SortExpression="KSF_Date" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        
      <asp:TemplateField HeaderText="审核状态"  SortExpression="KSF_State" HeaderStyle-Font-Size="12px"  ItemStyle-Width="60px"   ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
          <ItemTemplate>
               <%# GetFlowName(DataBinder.Eval(Container.DataItem, "KSF_State").ToString())%>
          </ItemTemplate>
        </asp:TemplateField>
        
         <asp:BoundField  HeaderText="审核意见"  DataField="KSF_Detail"  ItemStyle-Width="115px"  SortExpression="KSF_Detail" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        
         <asp:BoundField  HeaderText="交货期"  DataField="KFS_ReDate"  ItemStyle-Width="115px"  DataFormatString="{0:yyyy-MM-dd}"  SortExpression="KFS_ReDate" >
            <ItemStyle HorizontalAlign="center"   Font-Size="12px"  />
            <HeaderStyle HorizontalAlign="center" Font-Size="12px"  />
        </asp:BoundField>
        </Columns>
        <HeaderStyle CssClass='Custom_DgHead' />
        <RowStyle CssClass='Custom_DgItem' />
        <AlternatingRowStyle BackColor="#E3EAF2" />
        <PagerStyle CssClass='Custom_DgPage' />
        </asp:GridView>
           </td>
      </tr>
</table>


<!--底部功能栏-->
<table width="100%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="30" >&nbsp;</td>
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
