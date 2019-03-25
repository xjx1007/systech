<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Wl_Customer_Price_View.aspx.cs"
    Inherits="Xs_Sales_Freight_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <title></title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>销售管理 > <a class="hdrLink" href="Xs_Sales_Freight_List.aspx">查看运费承担</a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtSelectedCell" align="center" nowrap>运费承担信息
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
                                                                onclick="PageGo('Wl_Customer_Price_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')"
                                                                name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                            value="&nbsp;共享&nbsp;">&nbsp;
                                                        <input title="" class="crmbutton small edit" onclick="PageGo('Xs_Sales_Freight_List.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                        </td>
                                                        <td align="right">
                                                            <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                                onclick="PageGo('Wl_Customer_Price_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')"
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Label1"></asp:Label></span>
                        <asp:TextBox runat="server" ID="Tbx_URL" CssClass="Custom_Hidden"></asp:TextBox>
                        <br>
                        <hr noshade size="1">
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>添加
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                        </tr>
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
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">编号：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <asp:Label ID="Tbx_Code" runat="server"
                                                    >
                                                </asp:Label>
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">日期：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <asp:Label ID="Tbx_Stime" runat="server"
                                                    >
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">供应商名称：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                <asp:Label ID="Tbx_SuppName" runat="server"
                                                    >
                                                </asp:Label>
                                                
                                                            
                                                <asp:Label ID="Tbx_SuppNo" runat="server"
                                                    CssClass="Custom_Hidden" >
                                                </asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">物流供应商：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" >
                                                <asp:Label ID="Tbx_WuliuSuppName" runat="server"
                                                    >
                                                </asp:Label>
                                                            
                                                <asp:Label ID="Tbx_WuliuSuppNo" runat="server"
                                                    CssClass="Custom_Hidden" >
                                                </asp:Label>
                                            </td>
                                            <td  class="dvtCellLabel" >责任人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:Label ID="Ddl_DutyPerson"  runat="server" OnChange="Change()" ></asp:Label>
                                                            
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">备注：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                <asp:Label ID="Tbx_Remarks" runat="server"
                                                    TextMode="MultiLine" Width="600px" Height="50px">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        
                                                    <tr>
                                                        <td class="dvtCellLabel" align="right">文件：
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:Label runat="server" ID="Lbl_Upload"></asp:Label>
                                                            &nbsp;</td>
                                                    </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>明细信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >
                                  <asp:TextBox ID="Tbx_Num" runat="Server" Text="2" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                        class="crmTable" style="height: 28px">
                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                    </table>
                                            </td>
                                        </tr>
                                                                 
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif" />
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
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
        </td>
    <td align="right" valign="top">
        <img src="/themes/softed/images/showPanelTopRight.gif" />
    </td>
        </tr> </table>
    </form>
</body>
</html>
