<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_ShipCheck_Excel.aspx.cs"
    Inherits="Procure_ShipCheck_Excel" %>

<html xmlns="http://www.w3.org/1999/xhtml">
 
<head id="Head1" runat="server">
    <base target="_self" />
    <title>对账单导入设置</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
</head>
   
<body>
    <form id="form1" runat="server">
        <div>

            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px">
                        <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox runat="server" ID="Tbx_Table" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox runat="server" ID="Tbx_Num" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购对账单 > 导入设置
                    </td>
                    <td width="100%" nowrap></td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>

            <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center" class="small">
                <tr>
                    <td valign="top">
                        <img src="../../../themes/softed/images/showPanelTopLeft.gif">
                    </td>
                    <td class="showPanelBg" valign="top" width="100%">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%" class="small">
                            <tr>
                                <td class="detailedViewHeader" colspan="4"><b>基本信息</b> </td>
                            </tr>
                            <tr>

                                
                            <td width="16%" height="25" align="right" class="dvtCellLabel">供应商:
                        </td>
                    <td class="dvtCellInfo" align="left">
                        <asp:TextBox runat="server" ID="Tbx_SuppName" CssClass="detailedViewTextBox"></asp:TextBox>
                        </td>
                                
                            <td width="16%" height="25" align="right" class="dvtCellLabel">对账类型:
                        </td>
                    <td class="dvtCellInfo" align="left">
                        <asp:TextBox runat="server" ID="Tbx_CheckType" CssClass="detailedViewTextBox" ></asp:TextBox>
                        </td>

                            </tr>
                            <tr>

                            <td width="16%" height="25" align="right" class="dvtCellLabel">模板:
                        </td>
                    <td class="dvtCellInfo" align="left">
                        <asp:DropDownList runat="server" ID="Ddl_Model" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Model_SelectedIndexChanged"></asp:DropDownList><asp:LinkButton runat="server" ID="Lbl_Del" Text="删除" OnClick="Lbl_Del_Click"></asp:LinkButton>&nbsp;
                        <asp:TextBox runat="server" ID="Tbx_Model" Width="105px"></asp:TextBox>&nbsp;
                    <asp:LinkButton runat="server" ID="Lbl_Save" Text="保存" OnClick="Lbl_Save_Click"></asp:LinkButton>&nbsp;
                    </td>
                    <td width="35%" align="left" class="dvtCellInfo" colspan="2">
                        <asp:Button ID="Button2" runat="server" Text="确定选择"
                            CssClass="crmbutton small create" Style="width: 80px; height: 28px;" OnClick="Button2_Click" />&nbsp;&nbsp;
                                    <input name="button2" type="button" value="关闭窗口" class="crmbutton small cancel" style="width: 80px; height: 28px;" onclick="closeWindow();">
                    </td>
                    <tr>
                        <td align="right" height="304" valign="top" colspan="4">

                            <table id="myTable" width="98%" border="0" align="center" cellpadding="2" cellspacing="0"
                                class="ListDetails" style="height: 28px">
                                <tr>

                                    <td class="ListHead" nowrap>
                                        <b>系统字段</b></td>
                                    <td class="ListHead" nowrap>
                                        <b>列1</b></td>
                                    <td class="ListHead" nowrap>
                                        <b>列2</b></td>
                                    <td class="ListHead" nowrap>
                                        <b>列3</b></td>
                                    <td class="ListHead" nowrap>
                                        <b>列4</b></td>
                                    <td class="ListHead" nowrap>
                                        <b>列5</b></td>
                                    <td class="ListHead" nowrap>
                                        <b>列6</b></td>
                                </tr>
                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                            </table>

                        </td>
                    </tr>
            </table>
        </div>
        </td>
                <td align="right" valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif" />
                </td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
