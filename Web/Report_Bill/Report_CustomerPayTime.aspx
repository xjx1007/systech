<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_CustomerPayTime.aspx.cs" Inherits="Web_Report_CustomerPayTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>客户帐期统计</title>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JAVASCRIPT">
    function btnGetReturnValue_onclick()  
    { 
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("../Common/SelectSuppliers.aspx?ID="+intSeconds+"","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

           if(temp!=undefined)   
           {   
              	 var ss;
		         ss=temp.split("|");
                 document.all('SuppNoSelectValue').value = ss[0];
                 document.all('SuppNo').value =ss[1];
            }   
           else
            {
                 document.all('SuppNoSelectValue').value = ""; 
                 document.all('SuppNo').value = ""; 
            }
    }

    function OnClick() {
        var CustomerName = document.all('Tbx_Customer').value;


        var s_URL = 'List_CustomerPayTime.aspx?';
        s_URL += '&CustomerName=' + CustomerName + '';
        window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
    }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                客户帐期统计 > <a class="hdrLink" href="Procure_ShipCheck_List.aspx">客户帐期统计</a>
            </td>
            <td width="100%" nowrap>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
    
    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
        <tr>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td class="showPanelBg" valign="top" width="100%">
                <div class="small" style="padding: 20px">
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">

                                    <tr>
                                        <td align="right" valign="top">
                                            <table width="100%"  border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="16%" align="right" class="dvtCellLabel">
                                                        客户名称:
                                                    </td>
                                                        <td align="left" class="dvtCellInfo">
                                                  <asp:TextBox ID="Tbx_Customer"  CssClass="detailedViewTextBox" Width="200px"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>
                                                   
                                                </tr> 
                                                
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <input id="Button1" type="button" runat="server" value="确定" class="crmbutton small save"
                                                    onclick="OnClick()" style="width: 55px; height: 30px" />&nbsp;&nbsp;
            <input type="button" class="crmbutton small cancel" value="返回" onclick="PageGo('../../Report/Bill_Report_Base.aspx')" style="width: 55px; height: 30px">
                                            </td>
                                        </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
            </td>
            <td align="right" valign="top">
                <img src="../../themes/softed/images/showPanelTopRight.gif" />
            </td>
        </tr>
    </table></td>
    </form>
</body>
</html>