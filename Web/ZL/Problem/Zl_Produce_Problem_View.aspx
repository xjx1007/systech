<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zl_Produce_Problem_View.aspx.cs"
    Inherits="Zl_Project_ProductsTry_View" %>

<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <title></title>
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="Zl_Project_ProductsTry_List.aspx">查看产品试制</a>
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
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
                        <br>
                        <hr noshade size="1">

                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>产品试制信息
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
                                                                onclick="PageGo('Zl_Project_ProductsTry_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')"
                                                                name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                            value="&nbsp;共享&nbsp;">&nbsp;
                                                        <input title="" class="crmbutton small edit" onclick="PageGo('Zl_Project_ProductsTry_List.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                                onclick="PageGo('Zl_Project_ProductsTry_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')"
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

                                                <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                                                    <tr>
                                                        <td valign="top">
                                                            <img src="../../../themes/softed/images/showPanelTopLeft.gif">
                                                        </td>
                                                        <td class="showPanelBg" valign="top" width="100%">
                                                            <div class="small" style="padding: 20px">
                                                                <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">

                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                                                                <asp:Panel runat="server" ID="Pan_Basic">
                                                                                    <tr>
                                                                                        <td colspan="4" class="detailedViewHeader">
                                                                                            <b>基本信息</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">编号：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Tbx_Code" runat="server">
                                                                                            </asp:Label>&nbsp;

                                                                                        </td>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">生产标题：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Tbx_Title" runat="server">
                                                                                            </asp:Label>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">产品型号：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Tbx_ProdutsBarCode" runat="server">
                                                                                            </asp:Label>&nbsp;
                                                                                        </td>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">生产阶段：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Ddl_ScStage" runat="server">
                                                                                            </asp:Label>&nbsp;

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">日期：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Tbx_STime" runat="server">
                                                                                            </asp:Label>&nbsp;

                                                                                        </td>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">问题性质：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Ddl_Type" runat="server">
                                                                                            </asp:Label>&nbsp;

                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">审批流程：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Ddl_Flow" runat="server">
                                                                                            </asp:Label>&nbsp;
                                                                                        </td>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">状态：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Ddl_FlowStep" runat="server">
                                                                                            </asp:Label>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">责任人：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Ddl_DutyPerson" runat="server">
                                                                                            </asp:Label>&nbsp;

                                                                                        </td>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">责任部门：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">

                                                                                            <asp:Label ID="Ddl_DutyDepart" runat="server">
                                                                                            </asp:Label>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">希望完成时间：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                                                            <asp:Label ID="Tbx_HopeDate" runat="server">
                                                                                            </asp:Label>&nbsp;

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">问题内容：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                                                            <asp:Label ID="Tbx_Text"  runat="server" ></asp:Label>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4">
                                                                                            <uc2:CommentList ID="CommentList2" runat="server" CommentFID="" CommentType="-1" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel runat="server" ID="Pan_Cl">
                                                                                    <tr>
                                                                                        <td colspan="4" class="detailedViewHeader">
                                                                                            <b>处置</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">原因：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Tbx_Cause"  runat="server" ></asp:Label>&nbsp;

                                                                                        </td>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">临时处置：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Tbx_Temporary"  runat="server" ></asp:Label>&nbsp;

                                                                                        </td>

                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">完成时间：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                                                            <asp:Label ID="Tbx_DoneTime" runat="server">
                                                                                            </asp:Label>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="4">
                                                                                            <uc2:CommentList ID="CommentList1" runat="server" CommentFID="" CommentType="-1" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel runat="server" ID="Pan_Done">
                                                                                    <tr>
                                                                                        <td colspan="4" class="detailedViewHeader">
                                                                                            <b>结案</b>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">结果确认：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Tbx_Result"  runat="server" ></asp:Label>&nbsp;
                                                                                        </td>
                                                                                        <td width="15%" height="25" align="right" class="dvtCellLabel">结案：
                                                                                        </td>
                                                                                        <td width="35%" class="dvtCellInfo" align="left">
                                                                                            <asp:Label ID="Ddl_ClosedType" runat="server">
                                                                                            </asp:Label>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                            <asp:Label ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                            <asp:Label ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                            <asp:Label ID="Tbx_State" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                            <asp:Label ID="Tbx_ClosedState" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                        </td>
                                                        <td align="right" valign="top">
                                                            <img src="../../../themes/softed/images/showPanelTopRight.gif" />
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
            </tr>
        </table>
        </div>
            </td>
            <td valign="top">
                <img src="../../../themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
