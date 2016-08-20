<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Newhome.aspx.cs" Inherits="Admin_hame" Title="" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<script language="JavaScript" src="../Web/Js/Global.js" type="text/javascript"></script>	
<script type="text/javascript">
     //if(window != window.parent) 
     //{ var P = window.parent, D = P.loadinndlg(); }
</script>

<title></title>
<style type="text/css">
.Div11
{
  background-image:url(../images/btna.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
.Div22
{
  background-image:url(../images/btna2.gif); 
  background-repeat:no-repeat;
  z-index:0px;
  padding-top:3px;
}
</style>

</head>
<script type="text/javascript" src="../Web/KDialog/lhgdialog.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0">
  <tr>
    <td height="5"></td>
  </tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td background="../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">欢迎登陆系统</div></td>
    <td background="../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;</td>
    <td width="173" background="../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;"></td>
  </tr>
</table>
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0">
<tr>
    <td height="1" ></td>
</tr>
<tr>
    <td height="24" bgcolor="#E6F0F9" style="border-bottom:#3399CC 1px solid;"> 欢迎 <font color="#FF6600"><b><asp:Label ID="StaffName" runat="server" Text="Label"></asp:Label></b></font> 登陆系统，您目前拥有管理的仓库列表:<font color="#FF6600"><b><asp:Label ID="Warehouse_Name" runat="server" Text=""></asp:Label></b></font></td>
</tr>
<tr>
    <td height="3"></td>
</tr>
</table>


<table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" >
  <tr>
    <td height="22" colspan="2" align="left" bgcolor="#E6F0F9"><table  height="22" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td width="101" align="center"><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"  CssClass="Div11" Width="101px" Height="22px"  CausesValidation="false" Font-Size="14px">系统公告</asp:LinkButton></td>
        <td width="4" align="center">&nbsp;</td>
        <td width="101" align="center"><asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"  CssClass="Div11" Width="101px" Height="22px" CausesValidation="false" Font-Size="14px">最新动态</asp:LinkButton></td>
        <td width="4" align="center">&nbsp;</td>
        <td width="101" align="center"><asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"  CssClass="Div11" Width="101px" Height="22px"  CausesValidation="false" Font-Size="14px">修改密码</asp:LinkButton></td>
        <td width="4" align="center">&nbsp;</td>
      <td width="101" align="center"><asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click"  CssClass="Div11" Width="101px" Height="22px"  CausesValidation="false" Font-Size="14px">短消息</asp:LinkButton></td>
        <td align="center">&nbsp;&nbsp;</td>
      </tr>
    </table></td>
  </tr>
  <tr>  
    <td  align="left" valign="top"  style="border-bottom:#3399CC 1px solid;border-right:#3399CC 1px solid;border-left:#3399CC 1px solid;border-top:#3399CC 1px solid;">
<%--工作区A2A --%>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="A2A" runat="server">
  <tr id="NoticeYNs" runat="server">
    <td height="20" align="left">
    
    <table width="100%"  border="0" cellpadding="0" cellspacing="0" style="border-bottom:#3399CC 0px solid;">
      <tr>
        <td width="4%" align="center" height="25" style="border-bottom:#0099CC 1px solid"><img src="../images/109.gif" width="22" height="22"/></td>
        <td  width="96%"  align="left" style="font-size:14px; color:#000099;border-bottom:#0099CC 1px solid">&nbsp;<strong>系统公告</strong></td>
      </tr>
    </table>
    
    
    </td>
  </tr>
  <tr>
    <td height="20" valign="top">

        <asp:Label ID="NoticeContenttxt"  runat="server" Text=""></asp:Label>
    </td>
  </tr>
</table>
<%--工作区A2A --%>

<%--工作区B2B --%>
<table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" id="B2B" runat="server">
  <tr>
    <td height="20" align="left">
    
                    <table>
                        <tr>
                            <td width="20">
                                <img src="../Images/icon_2.gif" width="16" height="16"></td>
                            <td width="450">
                                <div>
                                    待办事宜</div>
                            </td>
                        </tr>
                    </table>
<!--系统公告-->
                    <hr>
    <table width="100%"  border="0" cellpadding="3" cellspacing="0" style="border-bottom:#3399CC 0px solid;">

    <tr>
    <td>
    <a href="javascript:;"  onclick="PageGo('../Web/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=26')"><asp:Label runat ="server" ID="Ltn_Contract" Text="未完成审核的合同评审信息"  Font-Size="13px"></asp:Label></a>
    </td>
    <td > 
    <a href="javascript:;"  onclick="PageGo('../Web/SalesContract/KNet_Sales_ContractList_List.aspx?WhereID=63')"><asp:Label runat ="server" ID="Lbl_Cotracted" Text="已审核未查看合同评审"  Font-Size="13px"></asp:Label></a>
   
    </td>
  </tr>
  <tr>
    <td >
    <a href="javascript:;"  onclick="PageGo('../Web/SalesShip/Knet_Sales_Ship_Manage_Manage.aspx?WhereID=64')"><asp:Label runat ="server" ID="Ltn_Ship" Text="未完成出库的发货通知单"  Font-Size="13px"></asp:Label></a>
   
    </td>
  <td ><a href="javascript:;"  onclick="PageGo('../Web/Order/Knet_Procure_OpenBilling_Manage.aspx?WhereID=55')"><asp:Label runat ="server" ID="Ltn_Order" Text="未完成审核的采购订单"  Font-Size="13px"></asp:Label></a>
   
  </td>
  </tr>
  <tr>
    <td >
    <a href="javascript:;"  onclick="PageGo('../web/ProductsSample/Pb_Products_Sample_List.aspx')"><asp:Label runat ="server" ID="Lbl_Demo" Text="样品审核"  Font-Size="13px"></asp:Label></a>
   
    </td>
  <td ><a href="../Web/Sc/SC_Plan_Print.aspx"  target="_blank" ><asp:Label runat ="server" ID="Lbl_ScPlan" Text="最新生产计划 [<Font color=red>1</Font>]"  Font-Size="13px"></asp:Label></a>
   
  </td>
  </tr>
  <tr>
  
  <td >
   <asp:LinkButton runat ="server" ID="Ltn_SalesReturn" Text="退货审批"  Font-Size="13px" ></asp:LinkButton>
  </td>
    <td >
       <asp:LinkButton runat ="server" ID="Ltn_Return" Text="退货入库审批"  Font-Size="13px" ></asp:LinkButton>
  
    <asp:Panel runat="server" ID="Pan_Return" Visible="false">
  </td>
    
  </asp:Panel>

    </td>
  </tr>
  
  <tr>
  
  <td >
   <asp:LinkButton runat ="server" ID="Ltn_RkNotShip" Text="已入库未发货信息"  Font-Size="13px"></asp:LinkButton>

  </td>
  <td >
   <a href="javascript:;"  onclick="PageGo('../web/HR/KNet_AttenDance_OutManger.aspx')"><asp:Label runat ="server" ID="Label1" Text="考勤信息"  Font-Size="13px"></asp:Label></a>
  </td>
  </tr>
    </table>
<!--系统公告--->   </td>
  </tr>
  <tr><td>
  
                    <table>
                        <tr>
                            <td width="20">
                                <img src="../Images/icon_5.gif" width="16" height="16"></td>
                            <td width="450">
                                <div>
                                    其他数据</div>
                            </td>
                        </tr>
                    </table>
<!--系统公告--><hr>
                                    <asp:Label ID="Lbl_ShTime" runat="server"></asp:Label>
                    
  </td></tr>
</table>
<%--工作区B2B --%>

<%--工作区C2C --%>
<table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" id="C2C" runat="server">
  <tr>
    <td height="20" align="left">
    <table width="100%"  border="0" cellpadding="0" cellspacing="0" >
              <tr>
        <td width="4%" align="center" height="25" style="border-bottom:#0099CC 1px solid"><img src="../images/109.gif" width="22" height="22"></td>
        <td  width="96%"  align="left" style="font-size:14px; color:#000099;border-bottom:#0099CC 1px solid">&nbsp;<strong>修改密码</strong></td>
      </tr>
    <tr>
    <td height="30" valign="top" colspan="4">
    
<!--修改密码-->
<table width="98%" id="PanlC"  runat="server" border="0" align="center" cellpadding="3" cellspacing="3">
  <tr>
    <td height="29" align="right">重置新密码:</td>
    <td height="29" align="left"><asp:TextBox ID="NewWsp1" runat="server" TextMode="Password"  Width="200px" CssClass="Boxx"></asp:TextBox>
        <asp:RequiredFieldValidator  ID="Req2" runat="server" ErrorMessage="请输入新密码！" ControlToValidate="NewWsp1" ></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <td height="29" align="right">确认新密码: </td>
    <td height="29" align="left"><asp:TextBox ID="NewWsp2" runat="server" TextMode="Password"  Width="200px" CssClass="Boxx"></asp:TextBox>
     <asp:CompareValidator ID="Com1" runat="server" ErrorMessage="两次输入密码不一样!" ControlToValidate="NewWsp2" ControlToCompare="NewWsp1"></asp:CompareValidator></td>
      
  </tr>
  <tr>
    <td height="30" align="right">&nbsp;</td>
    <td height="30" align="left">&nbsp;<asp:Button ID="Button4" runat="server" Text="确定修改" CssClass="Btt" OnClick="Button4_Click" /></td>
  </tr>
</table>
<!--修改密码--->    
    
    
    </td>
  </tr>
    </table></td>
  </tr>
</table>
<%--工作区C2C --%>

<table width="100%" border="0" align="center" cellpadding="1" cellspacing="1" id="E2E" runat="server">
  <tr>
    <td height="100%" align="left">
<!--内容-->
<table width="100%" border="0">
<tr><td></td></tr>
    </table></td>
  </tr>
</table>
<%--工作区D2D --%>
</div>
</form>
</body>
</html>
