<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_DlkDetails.aspx.cs"
    Inherits="Web_Report_Xs_Report_CkDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="JAVASCRIPT">

        function btnGetProductsTypeValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsTypeNo').value = ss[0];
                document.all('Tbx_ProductsTypeName').value = ss[1];
            }
            else {
                document.all('Tbx_ProductsTypeNo').value = "";
                document.all('Tbx_ProductsTypeName').value = "";
            }
        }
        function OnClick() {
            var StartDate = document.all('StartDate').value;
            var EndDate = document.all('EndDate').value;
            var State = document.all('Ddl_State').value;
            var CustomerName = document.all('Tbx_CustomerName').value;
            var ProductsType = document.all('Tbx_ProductsTypeNo').value;
            var CustomerTypes = document.all('Tbx_CustomerTypes').value;
            var ProductsEidition = document.all('Tbx_ProductsEdition').value;
            var CustomerValue = document.all('Tbx_CustomerValue').value;
            var Price = document.all('Ddl_Price').value;
            
            var Ck = document.all('Tbx_CK').value;
            var s_URL = 'List_DlCkList.aspx?StartDate=' + StartDate + '&EndDate=' + EndDate + '';
            s_URL += '&State=' + State + '';
            s_URL += '&CustomerName=' + CustomerName + '';
            s_URL += '&CustomerValue=' + CustomerValue + '';
            s_URL += '&ProductsType=' + ProductsType + '';
            s_URL += '&CustomerTypes=' + CustomerTypes + '';
            s_URL += '&ProductsEidition=' + ProductsEidition + '';
            s_URL += '&Price=' + Price + '';
            
            s_URL += '&Ck=' + Ck + '';
            window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');
        }


        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var CustomerTypes = document.all('Tbx_CustomerTypes').value;
            var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?CustomerValueType=" + CustomerTypes + "&sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss, fh;
                ss = tempd.split("#");
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];

            }
            else {
                document.all('CustomerValue').value = "";
                document.all('CustomerValueName').value = "";
            }
        }
    </script>
    <title>代理费明细</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    单据报表 > <a class="hdrLink" href="Report_Kc.aspx">代理费明细</a>
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
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                日期：
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>&nbsp;到<asp:TextBox
                                                    ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="dvtCellLabel">
                                                产品分类：
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_ProductsTypeName" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    MaxLength="48" Width="200px"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_ProductsTypeNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProductsTypeValue_onclick()" />
                                            </td>
                                            <td align="right" class="dvtCellLabel">
                                                客户名称：
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                
                                                <asp:TextBox ID="Tbx_CustomerValue" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    MaxLength="48" Width="200px"></asp:TextBox><img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetReturnValue_onclick()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                仓库:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:TextBox ID="Tbx_CK" CssClass="detailedViewTextBox" Width="200px" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" runat="server"></asp:TextBox>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                产品版本:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:TextBox ID="Tbx_ProductsEdition" CssClass="detailedViewTextBox" Width="200px"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                客户类别:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList ID="Tbx_CustomerTypes" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                状态:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList ID="Ddl_State" runat="server">
                                                    <asp:ListItem Text="所有" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="未审核" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="部门已审批" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="财务已审核" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                状态:
                                            </td>
                                            <td class="dvtCellInfo" align="left" colspan="3">
                                                <asp:DropDownList ID="Ddl_Price" runat="server">
                                                    <asp:ListItem Text="所有" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="新" Value="17.5"></asp:ListItem>
                                                    <asp:ListItem Text="老" Value="18.49"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <input type="button" runat="server" value="确定" class="crmbutton small save" onclick="OnClick()"
                                                    style="width: 55px; height: 30px" />&nbsp;&nbsp;
                                                <input type="button" class="crmbutton small cancel" value="返回" style="width: 55px;
                                                    height: 30px" onclick="PageGo('../Report/Xs_Report_Base.aspx')">
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
        </table>
    </div>
    </form>
</body>
</html>
