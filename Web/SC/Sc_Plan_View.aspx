<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sc_Plan_View.aspx.cs" Inherits="Web_Sc_Produce_Plan" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
 
<title>查看生产计划</title>	 
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title></title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                生产计划 > <a class="hdrLink" href="Sc_Expend_Manage.aspx">生产计划</a>
            </td>
            <td width="100%" nowrap>
                <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>
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
                </div>
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
                                        生产计划信息
                                    </td>
                                    <td class="dvtTabCache" style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td class="dvtUnSelectedCell" align="center" nowrap>
                                        <a href="#">相关信息</a>
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
                            <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                <tr>
                                    <td valign="top" align="left">
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                            <tr>
                                                <td>
                                                    <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                        onclick="PageGo('Sc_Expend_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('Sc_Expend_Manage.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                    <asp:Button ID="Button4" runat="server" class="crmbutton small edit" Text="重新生成PDF" OnClick="Button4_Click" Style="height: 26px; width: 100px" />&nbsp;

                                                       <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small edit" Text="审批"  OnClick="btn_Chcek_Click"/>
                                                    
                                                       <asp:Button ID="Btn_Auto" runat="server" class="crmbutton small edit" Text="自动排产"  OnClick="Btn_Auto_Click"/>

                                                </td>
                                                <td align="right">
                                                    <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                        onclick="PageGo('Sc_Expend_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
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
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="genHeaderSmall">
                                                    操作
                                                </td>
                                            </tr>
                                            <!-- Module based actions starts -->
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>基本信息</b>
                                                    <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    供应商:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_SuppName" runat="server"></asp:Label>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    计划日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_Stime" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    备注:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:Label ID="Lbl_Remarks" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>计划信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="ListDetails">
                                                        <tr valign="top">
                                                            <td class="ListHead" nowrap>
                                                                <b>采购单号</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>日期</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>供应商</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>产品</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>数量</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>本次计划</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>生产日期</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>发货</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>备注</b>
                                                            </td>
                                                            <td class="ListHead" nowrap>
                                                                <b>物料</b>
                                                            </td>
                                                        </tr>
                                                <%=s_MyTable_Detail %>
                                                    </table>
                                                </td>
                                            </tr>
                                            
                            </table>
                        </td>
                    </tr>
                </table>
                            <cc1:MyGridView ID="MyGridView3" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                BorderColor="#4974C2"
                                EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="ID" SortExpression="PBM_Code" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <a href="../mail/PB_Basic_Mail_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "PBM_ID") %>">
                                                <%# DataBinder.Eval(Container.DataItem, "PBM_Code")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="发送邮件" DataField="PBM_SendEmail" SortExpression="PBM_SendEmail" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="接收邮件" DataField="PBM_ReceiveEmail" SortExpression="PBM_ReceiveEmail" HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="内容" DataField="PBM_Text" SortExpression="PBM_Text"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    
                                    <asp:TemplateField HeaderText="附件" SortExpression="PBM_File" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <a href="<%# DataBinder.Eval(Container.DataItem, "PBM_File") %>"><%# DataBinder.Eval(Container.DataItem, "PBM_FID")+".PDF" %></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="主题" DataField="PBM_Title" SortExpression="PBM_Title"
                                        HtmlEncode="false">
                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                    </asp:BoundField>
                                    
                                    <asp:TemplateField HeaderText="状态" SortExpression="PBM_State" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <%# GetState(DataBinder.Eval(Container.DataItem, "PBM_State").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass='colHeader' />
                                <RowStyle CssClass='listTableRow' />
                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                <PagerStyle CssClass='Custom_DgPage' />
                            </cc1:MyGridView>
            </td>
        </tr>
        </table> </td>
        <td valign="top">
            <img src="../../themes/softed/images/showPanelTopRight.gif">
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
