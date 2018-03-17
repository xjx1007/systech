<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Structermenu.ascx.cs" Inherits="Web_HR_inc_Structermenu" %>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<style type="text/css">
.Div11
{
  background-image:url(../images/KbottonB.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/KbottonA.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>


<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="../KNet_OrganizationalStructure.aspx?KNetStrA=AA"  CssClass="Div22" Width="78px" Height="21px" Font-Size="14px" Font-Bold="true" ForeColor="MintCream">分部管理</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="../KNet_OrganizationalStructureDarp.aspx?KNetStrA=BB"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px">部门管理</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="center">&nbsp;</td>
      </tr>
</table>