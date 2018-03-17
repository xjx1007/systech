<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zl_Produce_ProblemYN.aspx.cs" Inherits="Knet_Web_Sales_pop_ContractListCheckYN" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<title>产品试制审核</title>
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
                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 >产品试制审核
                </td>
                <td width="100%" nowrap></td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>

<asp:Label ID="UsersNotxt" runat="server" Text="" Visible="false"></asp:Label>
<table width="100%" height="102" border="0" cellpadding="0" cellspacing="0"  class="small">
<tr>
    <td width="36%" height="30" align="right" class="dvtCellLabel">审核意见：</td>
    <td width="64%" class="dvtCellInfo">
    <asp:TextBox  runat="server"  ID="Tbx_Remark" Text="" TextMode="MultiLine" Width="170px" Height="100px"></asp:TextBox>
    </td>
  </tr>
  <tr>
    <td width="36%" class="dvtCellLabel">合同审核选择：</td>
    <td width="64%" class="dvtCellInfo">&nbsp;
    <asp:DropDownList ID="Ddl_State" runat="server">
       <asp:ListItem Value="-1">请选择审核</asp:ListItem>
       <asp:ListItem Value="1">通过审核</asp:ListItem>
       <asp:ListItem Value="0">不通过审核</asp:ListItem>
    </asp:DropDownList>
    </td>
  </tr>
  <tr>
    <td width="36%" height="30" align="right" class="dvtCellLabel">是否发送提醒邮件：</td>
    <td width="64%" class="dvtCellInfo">
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
    <asp:Button ID="Button1" runat="server" Text="确定审核"   class="crmbutton small save" OnClick="Button1_Click" style="width: 70px;height: 33px;"  />&nbsp;<input   name="button2"   type="button"   value="关闭本窗口"   class="crmbutton small cancel"  onclick="closeWindow();" style="width: 70px;height: 33px;"> </td>
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
        </Columns>
                                <HeaderStyle CssClass='colHeader'/>
                                <RowStyle CssClass='listTableRow'/>
                                <AlternatingRowStyle BackColor="#E3EAF2"/>
                                <PagerStyle CssClass='Custom_DgPage' />
        </asp:GridView>
           </td>
      </tr>
</table>



    </div>
    </form>
</body>
</html>
