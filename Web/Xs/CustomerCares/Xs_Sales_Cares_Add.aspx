<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xs_Sales_Cares_Add.aspx.cs" Inherits="Web_Sales_Xs_Sales_Cares_Add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<title></title>
<script type="text/javascript" src="Web/Js/ajax_func.js"></script>
<script language="javascript" type="text/javascript" src="Web/DatePicker/WdatePicker.js"></script>
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
       //var tempd= window.showModalDialog("Web/Common/SelectSalesClientList.aspx?sID="+intSeconds+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       var tempd = window.open("/Web/Common/SelectSalesClientList.aspx?sID=" + intSeconds + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
   }
    function SetReturnValueInOpenner_ClientList(tempd) {
       if (tempd != undefined)
       {   
          	 var ss;
	         ss=tempd.split("|");
             document.all('Tbx_CustomerValue').value = ss[0];
             document.all('Tbx_CustomerName').value =ss[1];
        }   
       else
        {
             document.all('Tbx_CustomerValue').value = ""; 
             document.all('Tbx_CustomerName').value = "";
        }
    }
</SCRIPT>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    

<table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>客户关怀 > 
	<a class="hdrLink" href="Xs_Sales_Cares_List.aspx">客户关怀</a>
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
                                    <td class="dvtSelectedCell" align="center" nowrap>客户关怀信息</td>
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
                                            <td  class="dvtCellLabel" >关怀主题:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Topic"  AllowEmpty="false" ValidError="关怀主题不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            (<font color="red">*</font>)
                                            </td>
                                            <td  class="dvtCellLabel" >关怀日期:</td>
                                            <td  class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate"  onFocus="WdatePicker()" ></asp:TextBox> 

                                        </td>
                                        
                                        </tr>
                                        <tr>
                                            <td width="17%"  class="dvtCellLabel" >客户:</td>
                                            <td  class="dvtCellInfo"  >
                                                <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server" style="width: 150px" />
                                                <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"  CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true" ></pc:PTextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                
                                             </td>
                                             
                                            <td  class="dvtCellLabel" >联系人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_LinkMan" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                        
                                            <td  class="dvtCellLabel" >执行人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>(<font color="red">*</font>)
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            
                                            <td  class="dvtCellLabel" >关怀类型:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_CareTypes" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>关怀内容</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >关怀内容:</td>
                                        <td  class="dvtCellInfo"  colspan="4" >
                                        <asp:TextBox ID="Tbx_CareDetails" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox>
                                        </td>
                                        </tr>
                                        
                                        <tr>
                                        <td   class="dvtCellLabel" >反馈内容:</td>
                                        <td  class="dvtCellInfo"  colspan="4" >
                                            <asp:TextBox ID="Tbx_CustomerDetails" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="40px"></asp:TextBox>
                                        </td>
                                        </tr>
                                        
                                        
                                                <asp:TextBox ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <tr><td height="25" align="right" class="dvtCellLabel">
                                                    附件资料:</td>
                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3"> 
                                                    <table  width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr id="tr5">
                                                        
                                                            <td align="center" class="dvtCellLabel">
                                                                工具</td>
                                                            <td align="center" class="dvtCellLabel">
                                                                名称</td>
                                                            <td align="center" class="dvtCellLabel" colspan="2">
                                                                资料</td>
                                                        </tr>
                                                         <tr id="tr4">
                                                            <td colspan="4">
                                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label></td>
                                                        </tr>
                                                     
                                                    </table>
                                                </td>
                                            </tr>   
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">
                                                            附件:</td>
                                                        <td class="dvtCellInfo" align="left">
                                                        <input id="uploadFile" type="file" runat="server"   style="detailedViewTextBox" width="150px"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" size="30" />&nbsp;
                                                        <input id="button_Server" type="button" value="上传" runat="server" class="crmbutton small save" onserverclick="button_ServerClick"
                                                            causesvalidation="false" />
                                                            </td>
                                                       
                                                    </tr>
                                                  
                                                        <tr>
                                                            <td height="25" align="right" class="dvtCellLabel">
                                                                问题反馈简介:</td>
                                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                                <asp:TextBox ID="Tbx_Remarks" runat="server" Style="display: none;"></asp:TextBox>
                                                                <iframe src='/Web/eWebEditor/ewebeditor.htm?id=Tbx_Remarks&style=gray'
                                                                    frameborder='0' scrolling='no' width='620' height='350'></iframe>
                                                            </td>
                                                        </tr>
                                        </table>
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
    <td valign="top"><img src="/themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>

    </form>
</body>
</html>
