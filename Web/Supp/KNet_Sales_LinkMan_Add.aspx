<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_LinkMan_Add.aspx.cs" Inherits="Web_Sales_KNet_Sales_LinkMan_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<title></title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
<script type="text/javascript" src="../Js/ajax_func.js"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>	
</head>

<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetReturnValue_onclick()  
    {   
       /*选择客户*/
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var tempd= window.showModalDialog("../Common/SelectSuppliers.aspx?sID="+intSeconds+"","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       
       if(tempd ==undefined)
       {
            tempd = window.returnValue;  
       }
            var sel=document.getElementById("Ddl_DutyPerson");
            var length = sel.length; 
            for(var i=length-1;i>=0;i--)
            { 
                sel.remove(i); 
            } 
            var opt =new Option("","");
            sel.options.add(opt);
            if(tempd!=undefined)   
       {   
          	 var ss;
	         ss=tempd.split("#");
             document.all('Tbx_CustomerValue').value =ss[0];
             document.all('Tbx_CustomerName').value =ss[1];
             document.all('Tbx_Code').value =ss[2];
             var st,sw;
            st=ss[3].split("|");
            if(st.length >0)
            {
                for(var i=0;i<st.length-1;i++)
                {
                    sw=st[i].split(",");
                    var opt =new Option(sw[1],sw[0]);
                    sel.options.add(opt);
                }
             }
             
        }   
       else
        {
            document.all('Tbx_CustomerValue').value = ""; 
            document.all('Tbx_CustomerName').value = ""; 
            document.all('Tbx_Code').value = ""; 
            var length = sel.length; 
            for(var i=length-1;i>=0;i--){ 
            sel.remove(i); 
            } 
        }
    }
    </SCRIPT>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="EditView" runat="server"  ENCTYPE="multipart/form-data">
<div id="ssdd" style="padding:1px"></div>




<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>联系人 > 
	<a class="hdrLink" href="KNet_Sales_LinkMan_List.aspx">联系人</a>
        </td>
	<td width=100% nowrap>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>



<table border=0 cellspacing=0 cellpadding=0 width=98% align=center>
   <tr>
	<td valign=top>
		<img src="../../themes/softed/images/showPanelTopLeft.gif">
	</td>

	<td class="showPanelBg" valign=top width=100%>
	     	     <div class="small" style="padding:20px">
		
		 		 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
		 <hr noshade size=1>

<table width="99%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
  <tr>
			<td>
				<table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
				   <tr>
					<td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
					<td class="dvtSelectedCell" align="center" nowrap>联系人信息</td>
					<td class="dvtTabCache" style="width:10px">&nbsp;</td>
					<td class="dvtTabCache" style="width:100%">&nbsp;</td>
				   <tr>
				</table>
			</td>
		   </tr>
		  <tr>
			<td>   
<table width="100%" border="0" cellpadding="0" cellspacing="0"  align="center" class="dvtContentSpace" >
 <tr>
      <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
        <asp:TextBox ID="txt_Code" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_Code" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
      </td>
 </tr>
     
 <tr>
    <td  class="dvtCellLabel" >姓名:</td>
    <td class="dvtCellInfo">
        <asp:TextBox ID="txtXOL_Name"  runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>(<font color="red">*</font>)
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="名称非空" ControlToValidate="txtXOL_Name" Display="Dynamic"></asp:RequiredFieldValidator>
    </td>
    <td  class="dvtCellLabel" >称呼:</td>
    <td  class="dvtCellInfo">
        <asp:DropDownList ID="Ddl_CallName" runat="server" Width="100px" ></asp:DropDownList>
    </td>
</tr>

<tr>
    <td  class="dvtCellLabel" > 英文名:</td>
    <td  class="dvtCellInfo">
        <asp:TextBox ID="tbxXOL_EnglishName"  runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox></td>
    <td  class="dvtCellLabel" >负责业务:</td>
    <td  class="dvtCellInfo"  >
        <asp:TextBox ID="txtXOL_Responsible"  runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>
    </td>
</tr>
<tr>
    <td width="17%"  class="dvtCellLabel" >供应商:</td>
    <td  class="dvtCellInfo"  >
        <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server" style="width: 150px" />
        <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true" ></asp:TextBox>
        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator6" runat="server" ErrorMessage="选择关联客户" ControlToValidate="Tbx_CustomerName" Display="Dynamic"></asp:RequiredFieldValidator>
     </td>
   
    <td  class="dvtCellLabel" >负责人:</td>
    <td  class="dvtCellInfo">
        <asp:DropDownList ID="Ddl_DutyPerson" runat="server" Width="100px" ></asp:DropDownList>(<font color="red">*</font>)
        <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
     <td   class="dvtCellLabel">
         手机:</td>
     <td  class="dvtCellInfo">
         <asp:TextBox ID="txtXOL_Phone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox>
     </td>
     <td  class="dvtCellLabel" >
         传真:</td>
     <td  class="dvtCellInfo">
         <asp:TextBox ID="txtXOL_Fax" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox>
     </td>
</tr>

<tr>
     <td   class="dvtCellLabel">
         Email:</td>
     <td  class="dvtCellInfo">
         <asp:TextBox ID="txtXOL_Mail" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox>
     </td>
          <td   class="dvtCellLabel">
         住宅电话:</td>
     <td  class="dvtCellInfo">
         <asp:TextBox ID="txtXOL_Homephone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox></td>
</tr>

<tr>
    <td  class="dvtCellLabel" >办公电话:</td>
    <td  class="dvtCellInfo">
        <asp:TextBox ID="txtXOL_Officephone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox>
   </td>
    <td  class="dvtCellLabel" >QQ:</td>
    <td  class="dvtCellInfo">
        <img border="0" src="../../themes/softed/images/qq.gif"  align="middle"><asp:TextBox ID="Tbx_QQ" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox>
   </td>
</tr>

<tr>
     
     <td   class="dvtCellLabel" >经理:</td>
     <td  class="dvtCellInfo" colspan="3"  >
        <asp:DropDownList ID="Ddl_Manager" runat="server" Width="100px" ></asp:DropDownList>
        
     </td> 
</tr>
 <tr>
      <td colspan=4 class="detailedViewHeader"><b>其他信息</b>
      </td>
 </tr>
 <tr>
     <td  class="dvtCellLabel" >学历:</td>
     <td  class="dvtCellInfo">
     <asp:DropDownList runat="server" ID="DdlXOL_Education">
     </asp:DropDownList></td>
     <td   class="dvtCellLabel" >部门:</td>
     <td  class="dvtCellInfo"  >
        <asp:TextBox ID="DdlXOL_Duty"  CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  runat="server" Width="150px"></asp:TextBox>
     </td> 
 </tr>
<tr>
     <td   class="dvtCellLabel">年龄:</td>
     <td  class="dvtCellInfo">
         <asp:TextBox ID="txtXOL_Age" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox></td>
     <td  class="dvtCellLabel">性别:</td>
     <td  class="dvtCellInfo">
         <asp:DropDownList runat="server" ID="DdlXOL_Sex">
         <asp:ListItem Value="男">男</asp:ListItem>
         <asp:ListItem Value="女">女</asp:ListItem>
         </asp:DropDownList>
     </td>
</tr>
<tr>
     <td  class="dvtCellLabel">生日:</td>
     <td  class="dvtCellInfo">
         <asp:TextBox ID="txtXOL_Birthday" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox>
     </td>
     <td  class="dvtCellLabel" >
         籍贯:</td>
     <td width="33%"  class="dvtCellInfo">
     <asp:DropDownList runat="server" ID="DdlXOL_Place">
     </asp:DropDownList></td>
</tr>
<tr>
     <td   class="dvtCellLabel">
         民族:</td>
     <td  class="dvtCellInfo">
     <asp:DropDownList runat="server" ID="DdlXOL_Nation">
     </asp:DropDownList>
     </td>
     <td  class="dvtCellLabel" >
         婚姻:</td>
     <td width="33%"  class="dvtCellInfo">     
     <asp:DropDownList runat="server" ID="DdlXOL_Marriage">
     <asp:ListItem Value="未婚">未婚</asp:ListItem>
     <asp:ListItem Value="已婚">已婚</asp:ListItem>
     </asp:DropDownList></td>
</tr>
    
 <tr>
      <td colspan=4 class="detailedViewHeader"><b>登录信息</b>
      </td>
 </tr>
 <tr>
        <td  class="dvtCellLabel">登录名:</td>
        <td  valign="top" class="dvtCellInfo"><asp:TextBox ID="Tbx_Card" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox></td>
     
        <td  class="dvtCellLabel">密码:</td>
        <td  valign="top" class="dvtCellInfo"><asp:TextBox ID="Tbx_PassWord" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Width="150px"></asp:TextBox></td>

 </tr>
 <tr>
      <td colspan=4 class="detailedViewHeader"><b>描述信息</b>
      </td>
 </tr>
 <tr>
        <td   class="dvtCellLabel" >爱好/特长:</td>
        <td   valign="top" class="dvtCellInfo"  ><asp:TextBox ID="txtXOL_Hobby" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox></td>

        <td   class="dvtCellLabel" >地址:</td>
        <td   valign="top" class="dvtCellInfo"  ><asp:TextBox ID="txtXOL_Address" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox></td>
 </tr>
<tr>
        <td   class="dvtCellLabel" >物流地址:</td>
        <td   valign="top" class="dvtCellInfo"  ><asp:TextBox ID="txtXOL_LogisticsAddress" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox></td>
         <td   class="dvtCellLabel" >评价:</td>
        <td   valign="top" class="dvtCellInfo"  ><asp:TextBox ID="txtXOL_Evaluation" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox></td>
        
 </tr>
<tr>
        <td   class="dvtCellLabel" >工作履历:</td>
        <td  valign="top" class="dvtCellInfo"  ><asp:TextBox ID="txtXOL_Experience" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox></td>

        <td   class="dvtCellLabel" >备注说明:</td>
        <td  valign="top" class="dvtCellInfo"  ><asp:TextBox ID="txtXOL_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox></td>
 </tr>
<tr>
  <td colspan="4" align="center" >&nbsp;
  <br />
   <asp:Button ID="Btn_Save" runat="server" Text="保 存" accessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick" style="width: 55px;height: 33px;"  />
   <input title="取消 [Alt+X]" accessKey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
   </td>

</tr>
</table>
</td>
</tr>
</table>
 <asp:TextBox ID="Tbx_ID" runat="server" style="display:none"></asp:TextBox>
<%--收货单信息  结束--%>

</div>

</td>

<td align=right valign=top>
<img src="../../themes/softed/images/showPanelTopRight.gif">
</td>
</tr></table>
    </form>
</body>
</html>
