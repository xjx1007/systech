<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_Fp_Add.aspx.cs" Inherits="Web_Sales_Fp_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>
  <SCRIPT LANGUAGE=JAVASCRIPT>
    function btnGetReturnValue_onclick()  
    { 
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("../Common/SelectSalesShipList.aspx?ID="+intSeconds+"&State=1","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(temp!=undefined)   
       {   
          	 var ss;
	         ss=temp.split("|");
             document.all('ShipNoSelectValue').value = ss[0];
             document.all('Tbx_ShipNoName').value =ss[1];
        }   
       else
        {
             document.all('ShipNoSelectValue').value = ""; 
             document.all('Tbx_ShipNoName').value = ""; 
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



<div id="Div2" class="TitleBar">销售开票管理</div>
<div id="Div1" style="padding:1px"></div>




<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
     

<table width="99%" border="0" align="center" id="AddPaten" runat="server">
 <tr>
    <td width="17%" align="right" class="tableBotcss" style="height: 30px">&nbsp;发票编号:</td>
        <td width="36%" align="left" class="tableBotcss" style="height: 30px"><asp:TextBox ID="Tbx_DirectInNo" MaxLength="40" runat="server" CssClass="Boxx" Width="150px" ></asp:TextBox>(<font color="red">*</font>)唯一性<br />
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="对账单号不能为空" ControlToValidate="Tbx_DirectInNo" Display="Dynamic"></asp:RequiredFieldValidator></td>
        <td width="14%" align="right" class="tableBotcss" style="height: 30px">客户名称:</td>
     <td width="33%" align="left" style="height: 30px" class="tableBotcss1">
     <pc:PTextBox ID="Tbx_CustomerValue" runat="server" Width="0" CssClass="TbxID"></pc:PTextBox>
         <pc:PTextBox ID="Tbx_Customer" runat="server"></pc:PTextBox></td>
 </tr>
    <tr>
        <td align="right" class="tableBotcss" style="height: 30px" width="17%">
            开票日期：</td>
        <td align="left" class="tableBotcss" style="height: 30px" width="36%" >
            <pc:PTextBox ID="Tbx_BeginDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></pc:PTextBox>
           </td>
        <td align="right" class="tableBotcss" style="height: 30px" width="17%">
            发票号：</td>
        <td align="left" class="tableBotcss" style="height: 30px" width="36%" >
            <pc:PTextBox ID="Tbx_Code" runat="server"  ></pc:PTextBox>
           </td>
    </tr>


<tr>
        <td height="12" align="right" class="tableBotcss">备注说明:</td>
        <td colspan="3" align="left" valign="top" class="tableBotcss1" ><asp:TextBox ID="Tbx_DirectInRemarks" TextMode="MultiLine" runat="server" CssClass="Boxx" Width="400px" Height="40px"></asp:TextBox></td>
</tr>
    <tr>
        <td align="right" class="tableBotcss" height="12">
            明细：</td>
        <td align="left" class="tableBotcss1" colspan="3" valign="top">
            <cc1:mygridview id="MyGridView1" runat="server" allowsorting="True"
                autogeneratecolumns="False" cssclass="Custom_DgMain" emptydatatext="<div align=center><font color=red><br/><br/><B>没有找到相关采购单记录</B><br/><br/></font></div>"
                isshowemptytemplate="true" pagesize="10" width="100%"><HeaderStyle CssClass='Custom_DgHead'  />
        <RowStyle CssClass='Custom_DgItem'  />
        <AlternatingRowStyle BackColor="#E3EAF2"  />
        <PagerStyle CssClass='Custom_DgPage'  />
        <Columns>
        <asp:TemplateField>
                <HeaderTemplate> 
                 <input type="CheckBox" onclick="selectAll(this)">
                 </HeaderTemplate>
                 <ItemTemplate>
                     <asp:CheckBox ID="Chbk" runat="server" />
                 </ItemTemplate>
            <HeaderStyle HorizontalAlign="Left" ></HeaderStyle>
            <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" ></ItemStyle>
        </asp:TemplateField>
        
          
         <asp:BoundField  HeaderText="发货单号"  DataField="DirectOutNo"  SortExpression="DirectOutNo" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   ></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  ></HeaderStyle>
        </asp:BoundField>
        
        
         <asp:BoundField  HeaderText="出库日期"  DataField="DirectOutDateTime" DataFormatString="{0:yyyy-MM-dd}"   SortExpression="DirectOutDateTime" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   ></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  ></HeaderStyle>
        </asp:BoundField>
        
         <asp:BoundField  HeaderText="产品名称"  DataField="KWD_ContentPerson"  SortExpression="KWD_ContentPerson" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   ></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField  HeaderText="产品型号"  DataField="KWD_Address"  SortExpression="KWD_Address" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   ></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  ></HeaderStyle>
        </asp:BoundField>
         <asp:BoundField  HeaderText="产品版本"  DataField="KWD_Address"  SortExpression="KWD_Address" >
            <ItemStyle HorizontalAlign="Left"   Font-Size="12px"   ></ItemStyle>
            <HeaderStyle HorizontalAlign="Left" Font-Size="12px"  ></HeaderStyle>
        </asp:BoundField>
        <asp:TemplateField HeaderText="未开票数量"  SortExpression="DirectOutStaffDepart">
          <ItemTemplate>
               <%# base.Base_GeDept(DataBinder.Eval(Container.DataItem, "DirectOutStaffDepart").ToString())%>
          </ItemTemplate>
          </asp:TemplateField>
          
        <asp:TemplateField HeaderText="开票数量"  SortExpression="HouseNo">
          <ItemTemplate>
          <pc:PTextBox ID="Tbx_Number" runat="server"></pc:PTextBox>
          </ItemTemplate>
          </asp:TemplateField>
          
        <asp:TemplateField HeaderText="单价"  SortExpression="HouseNo">
          <ItemTemplate>
          <pc:PTextBox ID="Tbx_Price" runat="server"></pc:PTextBox>
          </ItemTemplate>
          </asp:TemplateField>
          
        <asp:TemplateField HeaderText="金额"  SortExpression="HouseNo">
          <ItemTemplate>
          <pc:PTextBox ID="Tbx_Money" runat="server"></pc:PTextBox>
          </ItemTemplate>
          </asp:TemplateField>
</Columns>
</cc1:mygridview>
        </td>
    </tr>
<tr>
  <td colspan="4" valign="top" align="center" >&nbsp;<asp:Button ID="Btn_Save" CssClass="Btt" runat="server" Text="保存"  /></td>
</tr>
</table>
<%--收货单信息  结束--%>
<asp:TextBox id="Tbx_ID" runat="server" CssClass="TbxID" Width="0px"></asp:TextBox><!--底部功能栏 --><!--底部功能栏--></td>
  </tr>
</table>


    </form>
</body>
</html>
