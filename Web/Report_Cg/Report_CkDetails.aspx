<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report_CkDetails.aspx.cs" Inherits="Web_Report_Xs_Report_CkDetails" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
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
            //var temp = window.showModalDialog("../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsClass(temp) {
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
            var ProductsEidition = document.all('Tbx_ProductsEdition').value;
            var HqState = document.all('Ddl_HqState').value;
            var isFirst = document.all('DDL_isFirst').value;
            
            var Ck = document.all('Tbx_CK').value;
            var s_URL = 'List_CkList.aspx?StartDate=' + StartDate + '&EndDate=' + EndDate + '';
            s_URL += '&State=' + State + '';
            s_URL += '&CustomerName=' + CustomerName + '';
            s_URL += '&ProductsType=' + ProductsType + '';
            s_URL += '&ProductsEidition=' + ProductsEidition + '';
            s_URL += '&HqState=' + HqState + '';
            s_URL += '&Ck=' + Ck + '';
            s_URL += '&isFirst=' + isFirst + '';
            
            window.open(s_URL, '查看详细', 'top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=yes, location=no, status=no, width=850,height=450');

        }
        </script>
    <title>发货明细</title>
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
                    单据报表 > <a class="hdrLink" href="Report_Kc.aspx">销售出库明细</a>
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
                                          <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate"  onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})" ></asp:TextBox>&nbsp;到<asp:TextBox ID="EndDate" runat="server"  CssClass="Wdate"   onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})" ></asp:TextBox>
                                                (<font
                                                color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="开始日期非空"
                                                ControlToValidate="StartDate" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                                <asp:TextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    MaxLength="48" Width="200px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                仓库:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList ID="Tbx_CK" runat="server">
                                                </asp:DropDownList>
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
                                                状态:
                                            </td>
                                            <td class="dvtCellInfo" align="left" >
                                                <asp:DropDownList ID="Ddl_State" runat="server">
                                               <asp:ListItem Text="所有" Value=""></asp:ListItem>
                                               <asp:ListItem Text="未审核" Value="0"></asp:ListItem>
                                               <asp:ListItem Text="仓库已审核" Value="2"></asp:ListItem>
                                               <asp:ListItem Text="财务已审核" Value="3"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                回签状态:
                                            </td>
                                            <td class="dvtCellInfo" align="left" >
                                                <asp:DropDownList ID="Ddl_HqState" runat="server">
                                               <asp:ListItem Text="所有" Value=""></asp:ListItem>
                                               <asp:ListItem Text="是" Value="0"></asp:ListItem>
                                               <asp:ListItem Text="否" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">
                                                第一次采购:
                                            </td>
                                            <td class="dvtCellInfo" align="left" >
                                                <asp:DropDownList ID="DDL_isFirst" runat="server">
                                               <asp:ListItem Text="无" Value=""></asp:ListItem>
                                               <asp:ListItem Text="是" Value="0"></asp:ListItem>
                                               <asp:ListItem Text="否" Value="1"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <input id="Button1" type="button" runat="server" value="确定" class="crmbutton small save" onclick="OnClick()"
                                                    style="width: 55px; height: 30px" />&nbsp;&nbsp;
                                                <input type="button" class="crmbutton small cancel" value="返回" style="width:55px;Height:30px" onclick="PageGo('../Report/Xs_Report_Base.aspx')">
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

