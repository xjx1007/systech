<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PB_Basic_Express_View.aspx.cs"
    Inherits="Pb_Basic_Express_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <title></title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="Pb_Basic_Express_List.aspx">查看快递</a>
                </td>
                <td width="100%" nowrap></td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>快递信息
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtUnSelectedCell" align="center" nowrap>
                                                <a href="#">相关信息</a>
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td valign="top" align="left">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                    <tr>
                                                        <td>
                                                            <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                                onclick="PageGo('Pb_Basic_Express_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')"
                                                                name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                            value="&nbsp;共享&nbsp;">&nbsp;
                                                        <input title="" class="crmbutton small edit" onclick="PageGo('Pb_Basic_Express_List.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                                onclick="PageGo('Pb_Basic_Express_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')"
                                                                name="Duplicate" value="复制">&nbsp;
                                                        <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                            onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                                rowspan="2">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                    <tr>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="genHeaderSmall">操作
                                                        </td>
                                                    </tr>
                                                    <!-- Module based actions starts -->
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                                                <tr>
                                                                    <td colspan="4" class="detailedViewHeader">
                                                                        <b>基本信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">单号：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_Code" runat="server" 
                                                                              ></asp:Label>
                                                                                
                                                                    </td>
                                                                    <td width="16%" align="right" class="dvtCellLabel">日期:
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_Stime" runat="server" ></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">责任人：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                                        <asp:Label runat="server" ID="lblPBE_DutyPerson"  ></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="detailedViewHeader">
                                                                        <b>发件人信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">发件人公司：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <input type="hidden" name="lblPBE_CustomerValue" id="lblPBE_CustomerValue" runat="server" />
                                                                        <asp:Label ID="lblPBE_CustomerName" runat="server" AllowEmpty="false" ValidError="发件人公司不能为空"  ></asp:Label>
                                                                       </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">发件人：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <input type="hidden" name="lblPBE_LinkMan" id="lblPBE_LinkMan" runat="server" />
                                                                        <asp:Label ID="lblPBE_LinkManName" runat="server" AllowEmpty="false" ValidError="发件人不能为空"  ></asp:Label>
                                                                      </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">地址：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left" colspan="3">
                                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                        </asp:ScriptManager>
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Label   runat="server" ID="lblPBE_Shen"></asp:Label>
                                                                                <asp:Label   runat="server" ID="lblPBE_Shi"></asp:Label>
                                                                                <asp:Label   runat="server" ID="lblPBE_Qu"></asp:Label>
                                                                                <asp:Label   runat="server" ID="lblPBE_Jie"></asp:Label>
                                                                                <br />
                                                                                <asp:Label ID="lblPBE_Address" runat="server" ></asp:Label>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">手机：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_Phone" runat="server"  ></asp:Label>
                                                                    </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">电话：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_TelPhone" runat="server"  ></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="detailedViewHeader">
                                                                        <b>收件人信息</b>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">收件人公司：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_ReCustomerName" runat="server"  ></asp:Label>
                                                                    </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">收件人：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                       <asp:Label ID="lblPBE_ReLinkManName" runat="server"  ></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">地址：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left" colspan="3">

                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Label   runat="server" ID="lblPBE_ReShen" ></asp:Label>
                                                                                <asp:Label   runat="server" ID="lblPBE_ReShi" ></asp:Label>
                                                                                <asp:Label   runat="server" ID="lblPBE_ReQu" ></asp:Label>
                                                                                <asp:Label   runat="server" ID="lblPBE_ReJie"></asp:Label>
                                                                                <br />
                                                                                <asp:Label ID="lblPBE_ReAddress" runat="server" AllowEmpty="false"  ValidError="地址不能为空"></asp:Label>

                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">手机：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_RePhone" runat="server"  ></asp:Label>
                                                                    </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">电话：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_ReTelPhone" runat="server"  ></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4" class="detailedViewHeader">
                                                                        <b>快递信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">快递名称：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label runat="server" ID="lblPBE_KDName"  ></asp:Label>
                                                                    </td>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">快递单号：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_KdCode" runat="server"  ></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="16%" height="25" align="right" class="dvtCellLabel">备注：
                                                                    </td>
                                                                    <td class="dvtCellInfo" align="left">
                                                                        <asp:Label ID="lblPBE_Use" runat="server" ></asp:Label>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
        </td>
    <td align="right" valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif" />
    </td>
        </tr> </table>
    </form>
</body>
</html>
