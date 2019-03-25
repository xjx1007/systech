﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PB_Basic_Code_Add.aspx.cs" Inherits="PB_Basic_Code_Add" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
<title></title>
<script type="text/javascript" src="../Js/ajax_func.js"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>	
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
<%--莱单列表结束--%>
<table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>系统编码 > 
	<a class="hdrLink" href="PB_Basic_Code_List.aspx">系统编码</a>
        </td>
	<td width=100% nowrap>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>

<table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
   <tr>
   	<td valign="top"><img src="../../themes/softed/images/showPanelTopLeft.gif"></td>
	<td class="showPanelBg" valign="top" width="100%">
	     	     <div class="small" style="padding:10px"></div>
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
                <hr noshade size=1>
                                <%--固定样式 --%>
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>系统编码信息</td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>		
                                    <td class="dvtTabCache" style="width:100%">&nbsp;</td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>		
                            <tr>
                            <td>
                            <table border="0" cellspacing="3" cellpadding="3"  width="100%" class="dvtContentSpace">
							
                             <tr>
                                 <td>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                        <tr>
 <asp:TextBox ID="Tbx_ID1" runat="server" style="display:none"></asp:TextBox>
 <asp:TextBox ID="Tbx_Code1" runat="server" style="display:none"></asp:TextBox>
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >编号:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_ID"  AllowEmpty="false" ValidError="编号不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            
                                            <td  class="dvtCellLabel" >编码:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Code"  AllowEmpty="false" ValidError="编码不能为空"   CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                        </td>
                                        
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >名称:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Name"  AllowEmpty="false" ValidError="名称不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            
                                            <td  class="dvtCellLabel" >排序:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Order"   CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                        </td>
                                        
                                        </tr>
                                      
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >明细:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Details" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            
                                            <td  class="dvtCellLabel" >中文名称:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_CName"   CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                        </td>
                                        
                                        </tr>
                                      
                                        </table>
                                  </td>
                             </tr>
                             
<tr>
  <td colspan="4" align="Center" >&nbsp;
  <br />
   <asp:Button ID="Btn_Save" runat="server" Text="保 存" accessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick"  />
   <input title="取消 [Alt+X]" accessKey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="  取消  " style="width:70px">
   </td>

</tr>
							</table>
                            </td>
                            </tr>
                </table>
    </td>
    <td valign="top"><img src="../../themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>

    </form>
</body>
</html>
