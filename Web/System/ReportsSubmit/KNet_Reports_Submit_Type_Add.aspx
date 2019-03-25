<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Reports_Submit_Type_Add.aspx.cs" Inherits="Web_Sales_KNet_Reports_Submit_Type_Add" %>
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
       var tempd= window.showModalDialog("/Web/Common/SelectSalesClientList.aspx?sID="+intSeconds+"","","dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       if(tempd!=undefined)   
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
    function Onchange()
    {
        var Response=Web_Sales_KNet_Reports_Submit_Type_Add.GetCode();
        document.all('Tbx_CustomerName').value = Response.value;
        
    }
    </SCRIPT>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    

<table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>部门报表类型设置 > 
	<a class="hdrLink" href="KNet_Reports_Submit_List.aspx">部门报表类型设置</a>
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
                                    <td class="dvtSelectedCell" align="center" nowrap>部门报表类型设置信息</td>
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
                                            <td  class="dvtCellLabel" >编码:</td>
                                            <td class="dvtCellInfo">
                                            <pc:PTextBox runat="server" ID="Tbx_Code" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>(<font color="red">*</font>)
                                            <asp:RequiredFieldValidator  ID="RequiredFieldValidator2" runat="server" ErrorMessage="请输入编码" ControlToValidate="Tbx_Code" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td  class="dvtCellLabel" >报表名称:</td>
                                            <td  class="dvtCellInfo" >
                                                <pc:PTextBox runat="server" ID="Tbx_TypeName" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                        
                                                  </td>
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" >截止日期:</td>
                                            <td  class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_TypeTime" runat="server" CssClass="Wdate"  onFocus="WdatePicker()" ></asp:TextBox> 

                                            </td>
                                            <td  class="dvtCellLabel" >报表类型:</td>
                                            <td  class="dvtCellInfo" >
                                              <asp:DropDownList runat="server" ID="Ddl_Type" AutoPostBack="True"  OnSelectedIndexChanged="Ddl_Type_SelectedIndexChanged"></asp:DropDownList>
                                              (<font color="red">*</font>)
                                              <asp:RequiredFieldValidator  ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入编码" ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                      
                                                  </td>
                                        </tr>
                                        <tr>
                                            <td  class="dvtCellLabel" style="height: 26px" >部门:</td>
                                            <td  class="dvtCellInfo" style="height: 26px">
                                              <asp:DropDownList runat="server" ID="DDl_Depart" AutoPostBack="True" OnSelectedIndexChanged="DDl_Depart_SelectedIndexChanged"></asp:DropDownList>
                                            </td>
                                            <td  class="dvtCellLabel" style="height: 26px" >个人:</td>
                                            <td  class="dvtCellInfo" colspan="3" style="height: 26px">
                                              <asp:DropDownList runat="server" ID="Ddl_Person" AutoPostBack="True" OnSelectedIndexChanged="Ddl_Person_SelectedIndexChanged"></asp:DropDownList>
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
