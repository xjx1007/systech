<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Reports_Submit_Add.aspx.cs" Inherits="Web_Sales_KNet_Reports_Submit_Add" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
<title></title>
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
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
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var tempd = window.showModalDialog("/Web/System/Notice/Select_Pb_Basic_Notice_List.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(tempd!=undefined)   
       {   
          	 var ss;
	         ss=tempd.split(",");
	         document.all('Tbx_NoticeID').value = ss[0];
             document.all('Tbx_NoticeTitle').value = ss[1];
        }   
       else
        {
           document.all('Tbx_NoticeID').value = "";
           document.all('Tbx_NoticeTitle').value = "";
        }
    }
    </SCRIPT>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    

<table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>报表上传 > 
	<a class="hdrLink" href="KNet_Reports_Submit_List.aspx">报表上传</a>
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
                                    <td class="dvtSelectedCell" align="center" nowrap>报表上传信息</td>
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
                                 <td >
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >报表编号:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Code" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            
                                            </td>
                                            <td  class="dvtCellLabel" >主题:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Topic" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>(<font color="red">*</font>)
                                            <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入主题" ControlToValidate="Tbx_Topic" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >上传日期:</td>
                                            <td  class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate"  onFocus="WdatePicker()" ></asp:TextBox> 

                                            </td>
                                            <td  class="dvtCellLabel" >上传人:</td>
                                            <td  class="dvtCellInfo" >
                                                <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>(<font color="red">*</font>)
                                                <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人" ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                        
                                            <td  class="dvtCellLabel" >状态:</td>
                                            <td  class="dvtCellInfo"  >
                                                <asp:DropDownList ID="Ddl_State" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                            </td>
                                            <td  class="dvtCellLabel" >公告:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_NoticeTitle" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>(<font color="red">*</font>)
                                            <pc:PTextBox runat="server" ID="Tbx_NoticeID" CssClass="Custom_Hidden"></pc:PTextBox>
                                                        <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetReturnValue_onclick()" />
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>描述信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" style="height: 54px" >备注:</td>
                                        <td  class="dvtCellInfo"  colspan="4" style="height: 54px" >
                                            <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="300px" Height="71px"></asp:TextBox>
                                        </td>
                                        </tr>

                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>附件信息</b>
                                        </td>
                                        </tr>
                                        <tr> 
                                        <td  align="center" colspan="4">文件名</td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellInfo"  colspan="4"> <asp:LinkButton id="Lbl_Spce" runat="server" OnClick="Lbl_Spce_Click"></asp:LinkButton> <asp:TextBox runat="server"  CssClass="Custom_Hidden" ID="Tbx_Type"></asp:TextBox></td>

                                        </tr>
                                        <tr>
                                        <td  class="dvtCellInfo"  colspan="4"> <asp:LinkButton id="Lbl_Spce1" runat="server" OnClick="Lbl_Spce1_Click"></asp:LinkButton><asp:TextBox runat="server"  CssClass="Custom_Hidden" ID="Tbx_Type1"></asp:TextBox></td>
                                  
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellInfo"   colspan="4"> <asp:LinkButton id="Lbl_Spce2" runat="server" OnClick="Lbl_Spce2_Click"></asp:LinkButton> <asp:TextBox runat="server"  CssClass="Custom_Hidden" ID="Tbx_Type2"></asp:TextBox>
                                        <asp:TextBox runat="server"  CssClass="Custom_Hidden" ID="Tbx_Num"></asp:TextBox></td>
                          
                                        </tr>
                                        <tr>
                                        
                                            <td  class="dvtCellLabel" >类型:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_Types" CssClass="detailedViewTextBox" runat="server" Width="100px" ></asp:DropDownList>
                                            </td>
                                        <td   class="dvtCellLabel"  >附件:</td>
                                        <td  class="dvtCellInfo"  >
                                            <input id="uploadFile" type="file" runat="server" CssClass="detailedViewTextBox"  size="30" />&nbsp;
        <input id="button" type="button" value="上传文档"  runat="server" class="crmbutton small create" onserverclick="button_ServerClick"  causesvalidation="false" style="width: 85px; height: 26px" />
                                        </td>
                                        </tr>
                                        
                                        </table>
                                  </td>
                             </tr>
                             
<tr>
  <td colspan="4" align="center" >&nbsp;
  <br />
   <asp:Button ID="Btn_Save" runat="server" Text="保 存" accessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick"  style="width: 55px;height: 33px;"  />
   <input title="取消 [Alt+X]" accessKey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
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
