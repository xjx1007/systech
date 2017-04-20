<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Task_Add.aspx.cs" Inherits="Web_Sales_Xs_Sales_Task_Add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<title></title>
<script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>	
</head>

<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetReturnValue_onclick()  
    {   
       /*选择客户*/
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       //var tempd= window.showModalDialog("/Web/Common/SelectDeptPerson.aspx?sID="+intSeconds+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       var tempd = window.open("/Web/Common/SelectDeptPerson.aspx?sID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
   }
    function SetReturnValueInOpenner_DeptPerson(tempd) {
       if (tempd != undefined)
       {   
          	 var ss;
	         ss=tempd.split("|");
             document.all('Tbx_ExecutorValue').value = ss[0];
             document.all('Tbx_ExecutorName').value =ss[1];
        }   
       else
        {
             document.all('Tbx_ExecutorValue').value = ""; 
             document.all('Tbx_ExecutorName').value = "";
        }
    }
</SCRIPT>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    

<table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>客户任务计划  > 
	<a class="hdrLink" href="Xs_Sales_Task_List.aspx">客户任务计划 </a>
        </td>
	<td width=100% nowrap>
 <asp:TextBox ID="Tbx_ID" runat="server" style="display:none"></asp:TextBox>
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>

<table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
   <tr>
   	<td valign="top"><img src="/themes/softed/images/showPanelTopLeft.gif"></td>
	<td class="showPanelBg" valign="top" width="100%">
	     	     <div class="small" style="padding:10px"></div>
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label></span> <br>
                <hr noshade size=1>
                                
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>客户任务计划 信息</td>
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
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >主题:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Topic"  AllowEmpty="false" ValidError="关怀主题不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            <td  class="dvtCellLabel" >状态:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_State" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                        
                                        </tr>
                                        
                                            <td  class="dvtCellLabel" >认领:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Claim" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                            <td  class="dvtCellLabel" >是否修改客户负责人为执行人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_IsModiy" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                        <tr>
                                        </tr>
                                        
                                        <tr>
                                            <td  class="dvtCellLabel" >开始日期:</td>
                                            <td  class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_BeginTime" runat="server" CssClass="Wdate"  onFocus="WdatePicker({maxDate:'#F{$dp.$D(\'Tbx_EndTime\')}'})" ></asp:TextBox> 

                                        
                                            <td  class="dvtCellLabel" >开始日期:</td>
                                            <td  class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_EndTime" runat="server" CssClass="Wdate"  onFocus="WdatePicker({minDate:'#F{$dp.$D(\'Tbx_BeginTime\')}'})" ></asp:TextBox> 

                                        </tr>
                                        
                                        
                                        <tr>
    
                                            <td width="17%"  class="dvtCellLabel" >执行人:</td>
                                            <td  class="dvtCellInfo"  >
                                            <asp:TextBox ID="Tbx_ExecutorValue" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <pc:PTextBox ID="Tbx_ExecutorName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true" ></pc:PTextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" /><br />
                                                
                                             </td>
                                            <td  class="dvtCellLabel" >负责人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>(<font color="red">*</font>)
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            
                                        </tr>
                                        
                                        <tr>
                                        <td   class="dvtCellLabel" >备注:</td>
                                        <td  class="dvtCellInfo"  colspan="4" >
                                        <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"  Height="100px"></asp:TextBox>
                                        </td>
                                        </tr>
                                        
                                                      
                                        <tr>
                                        <td colspan="4" align="center" >&nbsp;
                                        <br />
                                        <asp:Button ID="Btn_Save" runat="server" Text="保 存" accessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick"  />
                                        <input title="取消 [Alt+X]" accessKey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="width:70px">
                                        </td>

                                        </tr>
                                        </table>
                                  </td>
                             </tr>
                             </table>
                             </td>
                             </tr>
               
                </table>
    </td>
    <td valign="top"><img src="/themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>

    </form>
</body>
</html>
