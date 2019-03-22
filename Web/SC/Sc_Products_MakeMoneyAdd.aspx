<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false"  CodeFile="Sc_Products_MakeMoneyAdd.aspx.cs" Inherits="Web_SC_Sc_Products_MakeMoneyAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <title runat="server" ID="titl" >制造费用添加</title>
    
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
                生产 > <a class="hdrLink" runat="server" ID="tit"  href="Sc_Products_MakeMoney.aspx">制造费用添加</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" Style="display: none"></asp:TextBox>
                
                <asp:TextBox ID="Tbx_FaterBarCode" runat="server" Style="display: none"></asp:TextBox>
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
                <div class="small" style="padding: 10px">
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <br>
                    <hr noshade size="1">
                    
                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr valign="bottom">
                            <td style="height: 44px">
                                <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                    <tr>
                                        <td class="dvtTabCache" style="width: 10px" nowrap>
                                            &nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>
                                            制造费用信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtTabCache" style="width: 100%">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td class="dvtCellLabel">
                                            &nbsp;出库单号:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="DirectInNo" MaxLength="40" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="150px"></asp:TextBox>(<font color="red">*</font>)唯一性<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="出库单号不能为空"
                                                ControlToValidate="DirectInNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>--%>
                                        <td class="dvtCellLabel">
                                            日期:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_Time" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="出库日期非空"
                                                ControlToValidate="Tbx_Time" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            &nbsp;制造费用:
                                        </td>
                                        <td class="dvtCellInfo"><asp:TextBox ID="Tbx_MakeMoney" runat="server"></asp:TextBox>(<font color="red">*</font>)
      
                                        </td>
                                        <td class="dvtCellLabel">
                                            &nbsp;人工费用:
                                        </td>
                                        <td class="dvtCellInfo"><asp:TextBox ID="Tbx_PeopleMoney" runat="server"></asp:TextBox>(<font color="red">*</font>)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            &nbsp;其他材料费用:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_ElseMaterialsMoney" runat="server"></asp:TextBox>(<font color="red">*</font>)
                                        </td>
                                        <td class="dvtCellLabel">
                                            &nbsp;制造费用单价:
                                        </td>
                                        <td class="dvtCellInfo">
                                             <asp:TextBox ID="Tbx_UnitsMakeMoney" runat="server"></asp:TextBox>(<font color="red">*</font>)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellLabel">
                                            &nbsp;人工费用单价:
                                        </td>
                                        <td class="dvtCellInfo">
                                           <asp:TextBox ID="Tbx_UnitsPeopleMoney" runat="server"></asp:TextBox>(<font color="red">*</font>)
                                        </td>
                                        <td class="dvtCellLabel">
                                           &nbsp; 其他材料费用单价:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:TextBox ID="Tbx_UnitsElseMaterialsMoney" runat="server"></asp:TextBox>(<font color="red">*</font>)
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="dvtCellLabel">
                                            &nbsp;总工时:
                                        </td>
                                        <td class="dvtCellInfo">
                                         <asp:TextBox ID="Tbx_CountTime" runat="server"></asp:TextBox>(<font color="red">*</font>)
                                        </td>
                                       <%-- <td class="dvtCellLabel">
                                            &nbsp;OEM:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList runat="server" ID="Ddl_SuppNo">
                                            </asp:DropDownList>
                                        </td>--%>
                                    </tr>
                                    
                                  <%--  <tr>
                                        <td class="dvtCellLabel">
                                            &nbsp;领用用途:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList runat="server" ID="Ddl_LyType">
                                            </asp:DropDownList>
                                        </td>
                                       
                                    </tr>--%>
                                   <%-- <tr>
                                        <td class="dvtCellLabel">
                                            备注说明:
                                        </td>
                                        <td class="dvtCellInfo" colspan="3">
                                            <asp:TextBox ID="Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                    runat="server" ControlToValidate="Remarks" ValidationExpression="^(\s|\S){0,500}$"
                                                    ErrorMessage="备注说明太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>--%>
                                </table>
                                <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                              <%--  <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                    class="crmTable" style="height: 28px">
                                    <tr>
                                        <td colspan="10" class="dvInnerHeader">
                                            <b>产品详细信息</b>
                                             <a style="color:brown">总数量：</a>
                                            <a style="color: brown" id="count"></a>&nbsp; &nbsp;   
                                            <a style="color: red">总金额：</a>
                                            <a style="color: red" id="moneycount"></a>
                                        </td>
                                    </tr>
                                    <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                </table>
                                <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                    <!-- Add Product Button -->
                                    <tr>
                                        <td colspan="3">
                                            ①选择产品:
                                            <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();"/>
                                        </td>
                                    </tr>
                                </table>--%>
                            </td>
                        </tr>
                        <input type="text" id="Total_Price" style="display: none" runat="server" />
                        <tr>
                            <td colspan="4" align="center">
                                &nbsp;
                                <br />
                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                    class="crmbutton small save" OnClick="Btn_Save_OnClick" style="width: 55px;height: 33px;" />
                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                            </td>
                        </tr>
                    </table>
            </td>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
        
    </form>
</body>
</html>
