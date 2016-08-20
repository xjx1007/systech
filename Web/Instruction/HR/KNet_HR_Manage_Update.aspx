<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false"  EnableEventValidation="false"  CodeFile="KNet_HR_Manage_Update.aspx.cs" Inherits="Knet_Web_HR_KNet_HR_Manage_Update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../css/knetwork.css" type="text/css">
<title></title>

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
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>

</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
<div id="ssdd" style="padding:1px"></div>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td width="150" background="../../images/ktxt1.gif" style="background-color:#F5F5F5; height:28px; width:130px;padding-left:20px;"><div class="TP2">人事管理</div></td>
    <td  background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;">&nbsp;&nbsp;</td>
    <td width="216" background="../../images/ktxt2.gif" style="background-color:#F5F5F5; height:28px;" align="center">&nbsp;</td>
  </tr>
</table>
<div id="Div1" style="padding:1px"></div>


<table  height="22" border="0" cellpadding="0" cellspacing="0" width="99%" align="center" >
      <tr>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl="KNet_HR_Manage.aspx"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px" >人员列表</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl="KNet_HR_Manage_Add.aspx"  CssClass="Div11" Width="78px" Height="21px" Font-Size="14px" >人员添加</asp:HyperLink></td>
        <td width="78" align="center"><asp:HyperLink ID="HyperLink3" runat="server"  CssClass="Div22" Width="78px" Height="21px" Font-Size="14px" Font-Bold="true" ForeColor="MintCream">人员修改</asp:HyperLink></td>
        <td width="4" align="center"></td>
        <td align="center">&nbsp;</td>
      </tr>
</table>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" class="tablecss">
  <tr>
    <td>
<%--内容块--%>


<asp:Label ID="lblID" runat="server"  Visible="false" ></asp:Label>
<asp:Label ID="OldPasword" runat="server"  Visible="false" ></asp:Label>
        
<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0" >
  <tr>
    <td height="10" ></td>
  </tr>
  <tr>
    <td height="176" align="right" valign="top">
<table width="100%" height="20" border="0" align="center" cellpadding="0" cellspacing="0">
     
      <tr>
        <td width="16%" height="25" align="right" class="tdcss">选择分部:</td>
        <td class="tdcss" align="left">&nbsp;<asp:DropDownList ID="StaffBranch1" runat="server" Width="152px" OnSelectedIndexChanged="StaffBranch1_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList>(<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator4"
            runat="server" ErrorMessage="请选择分部" ControlToValidate="StaffBranch1" Display="Dynamic"></asp:RequiredFieldValidator></td>
        <td align="right" class="tdcss">选择部门:</td>
        <td align="left" class="tdcss"><asp:DropDownList ID="StaffDepart1" runat="server" Width="152px" >
        </asp:DropDownList></td>
      </tr>
      
      <tr>
        <td width="16%" height="25" align="right" class="tdcss">员工卡号:</td>
        <td width="35%" align="left" class="tdcss">&nbsp;
          <asp:TextBox ID="StaffCard1" runat="server" CssClass="Boxx2" Width="150px"  MaxLength="20" ReadOnly="true"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
            ID="RequiredFieldValidator1" runat="server" ErrorMessage="不能为空！" ControlToValidate="StaffCard1" Display="Dynamic" ></asp:RequiredFieldValidator>         </td>
        <td width="17%" align="right" class="tdcss">员工姓名:</td>
        <td width="32%" align="left" class="tdcss"><asp:TextBox ID="StaffName1" runat="server" MaxLength="30" CssClass="Boxx2" Width="150px" ReadOnly="true"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="员工姓名必填" ControlToValidate="StaffName1" Display="Dynamic" ></asp:RequiredFieldValidator></td>
      </tr>

        
      <tr>
        <td height="25" align="right" class="tdcss">登陆密码:</td>
        <td align="left" class="tdcss">&nbsp;
          <asp:TextBox ID="StaffPassword1" TextMode="Password" runat="server" MaxLength="30" CssClass="Boxx" Width="150px"></asp:TextBox><font color="gray">(如不修改,请留空)</font><asp:RegularExpressionValidator
                ID="RegularExpressionValidator2" runat="server" ErrorMessage="密码长度在5-18之间的数字与字母组合！" ControlToValidate="StaffPassword1" ValidationExpression="^\w{5,17}$" Display="Dynamic" ></asp:RegularExpressionValidator> </td>
        <td align="right" class="tdcss">确认密码:</td>
        <td align="left" class="tdcss"><asp:TextBox ID="StaffPassword2" TextMode="Password" MaxLength="30" runat="server" CssClass="Boxx" Width="150px"></asp:TextBox><asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="确认不正确" ControlToCompare="StaffPassword1" ControlToValidate="StaffPassword2" Display="Dynamic"></asp:CompareValidator></td>
      </tr>

      <tr>
        <td height="25" align="right" class="tdcss">基本工资:</td>
        <td align="left" class="tdcss">&nbsp;
          <asp:TextBox ID="Staffwages1" runat="server" MaxLength="30" Text="1000.00" CssClass="Boxx" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
                ID="RegularExpressionValidator1" runat="server" ErrorMessage="货币形式！" ControlToValidate="Staffwages1" ValidationExpression="^(-)?(\d+|,\d{3})+(\.\d{0,3})?$" Display="Dynamic" ></asp:RegularExpressionValidator> </td>
        <td align="right" class="tdcss">性别:</td>
        <td align="left" class="tdcss"><asp:RadioButtonList ID="StaffSex1" runat="server" Width="105px" Height="25px" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected="True">男</asp:ListItem>
                                <asp:ListItem Value="0">女</asp:ListItem> 
         </asp:RadioButtonList></td>
      </tr>


      <tr>
        <td height="25" align="right" class="tdcss">联系电话:</td>
        <td align="left" class="tdcss">&nbsp;
          <asp:TextBox ID="StaffTel1" runat="server" MaxLength="20" CssClass="Boxx" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
                ID="RegularExpressionValidator4" runat="server" ErrorMessage="电话号码不正确!" ControlToValidate="StaffTel1" ValidationExpression="^(\(\d{3,4}\)|\d{3,4}-)?\d{7,11}$" Display="Dynamic" ></asp:RegularExpressionValidator></td>
        <td align="right" class="tdcss">电子邮件:</td>
        <td align="left" class="tdcss"><asp:TextBox ID="StaffEmail1" runat="server" MaxLength="60" CssClass="Boxx" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
            ID="StaffEmail1aa" runat="server" ErrorMessage="邮件输入错误！" ControlToValidate="StaffEmail1" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
      </tr>
	  
	        <tr>
        <td height="25" align="right" class="tdcss">身份证号:</td>
        <td align="left" class="tdcss">&nbsp;
          <asp:TextBox ID="StaffIDCard1" MaxLength="30" runat="server" CssClass="Boxx" Width="150px"></asp:TextBox><asp:RegularExpressionValidator
            ID="RegularExpressionValidator5" runat="server" ErrorMessage="身份证号码不正确" ControlToValidate="StaffIDCard1" ValidationExpression="\d{17}[\d|X]|\d{15}" Display="Dynamic" ></asp:RegularExpressionValidator></td>
        <td align="right" class="tdcss">入职时间:</td>
        <td align="left" class="tdcss"><asp:TextBox ID="StaffAddTime1"   MaxLength="30" runat="server" CssClass="Wdate"  onClick="WdatePicker()"  ></asp:TextBox></td>
      </tr>
	  
      <tr>
        <td height="25" align="right" class="tdcss">通信地址:</td>
        <td class="tdcss" align="left">&nbsp;<asp:TextBox ID="StaffAddress1" runat="server" MaxLength="100" CssClass="Boxx" Width="300px"></asp:TextBox></td>
        <td height="25" align="right" class="tdcss">职位:</td>
        <td class="tdcss" align="left" >&nbsp;<asp:DropDownList ID="Drop_Position" runat="server" CssClass="Boxx"></asp:DropDownList></td>
      </tr>

      <tr>
        <td height="50" align="right" class="tdcss">备注:</td>
        <td colspan="3" align="left" class="tdcss" ><asp:TextBox ID="Remarks1" runat="server" style="display:none;"></asp:TextBox>
        <IFRAME src='../eWebEditor/ewebeditor.htm?id=Remarks1&style=coolblue' frameborder='0' scrolling='no' width='620' height='350'></IFRAME></td>
      </tr>
      <tr>
        <td height="30" align="right">&nbsp;</td>
        <td colspan="3" align="left">&nbsp;<asp:Button ID="Button1" runat="server" Text="修改员工" CssClass="Btt" OnClick="Button1_Click"  /></td>
      </tr>
    </table>
   </td>
  </tr>
</table>
    </td>
  </tr>
</table>


    </form>
</body>
</html>
