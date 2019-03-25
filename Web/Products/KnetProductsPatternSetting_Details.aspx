<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KnetProductsPatternSetting_Details.aspx.cs"
    Inherits="Knet_Web_System_KnetProductsSetting_Details" %>
    
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <title>产品详细信息</title>
    <script language="javascript">
        function preview() {
            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
            window.document.body.innerHTML = bdhtml;
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div>
        
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    产品管理 > <a class="hdrLink" href="KnetProductsSetting.aspx">产品明细</a>
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
                        <!--  <tr valign="bottom">
                        <td style="height: 44px">
                                    <table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td <%=s_OrderStyle%> align="center" nowrap><a href="">样品申请信息</a></td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>										
                                    <td <%=s_DetailsStyle%>  align="center" nowrap>
                                    <a href="">相关信息</a></td>
                                    <td class="dvtTabCache" style="width:100%" >&nbsp;</td>
                                    </tr>
                                    </table>
                        </td>
                    </tr>-->
                        <tr>
                            <td>
                                <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                    <tr>
                                        <td valign="top" align="left">
                                            <table border="0" cellspacing="0" cellpadding="0" id="Table_Btn" runat="server" width="100%">
                                                <tr>
                                                    <td>
                                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                            value="&nbsp;共享&nbsp;">&nbsp;
                                                        <input title="" class="crmbutton small edit" onclick="PageGo('KnetProductsSetting.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
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
                                                <tr>
                                                    <td align="left" style="padding-left: 10px;">
                                                        <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                        <a href="../Order/Knet_Procure_SuppliersRC_Price_Add.aspx?ProductsBarCode=<%=s_RC_ProductsBarCode %>"
                                                            class="webMnu"></a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="Pan_Order" runat="server">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>基本信息</b>
                                                            <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel" width="15%">
                                                            模具:
                                                        </td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:Label ID="Lbl_Mould" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">
                                                            产品型号:
                                                        </td>
                                                        <td class="dvtCellInfo"  colspan="3">
                                                            <asp:Label ID="ProductsPattern" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>相关产品</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="dvtCellInfo">                                  
                            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True"
                                PageSize="10" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                ShowHeader="true" HeaderStyle-Height="25px"><Columns><asp:TemplateField ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left"><HeaderTemplate><input type="CheckBox" onclick="selectAll(this)" /></HeaderTemplate><ItemTemplate><asp:CheckBox ID="Chbk" runat="server" /></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="产品名称" SortExpression="ProductsName" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="center"><ItemTemplate><a href="KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode") %>"></a></ItemTemplate></asp:TemplateField><asp:BoundField DataField="ProductsBarCode" HeaderText="编号(条码)" SortExpression="ProductsBarCode"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="center" Font-Size="12px" /></asp:BoundField><asp:BoundField DataField="ProductsPattern" HeaderText="产品型号" SortExpression="ProductsPattern"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="center" Font-Size="12px" /></asp:BoundField><asp:BoundField DataField="ProductsEdition" HeaderText="版本号" SortExpression="ProductsEdition"><ItemStyle HorizontalAlign="Left" Font-Size="12px" /><HeaderStyle HorizontalAlign="center" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="产品类别" SortExpression="ProductsType" HeaderStyle-Font-Size="12px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                        ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="芯片" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="样品确认" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:BoundField HeaderText="添加时间" DataField="ProductsAddTime" SortExpression="ProductsAddTime"
                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false"><ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="70px" /><HeaderStyle HorizontalAlign="Left" Font-Size="12px" /></asp:BoundField><asp:TemplateField HeaderText="状态" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                        HeaderStyle-HorizontalAlign="Left"><ItemTemplate></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="查看" HeaderStyle-Font-Size="12px" ItemStyle-Width="28px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemTemplate><a href="#" onclick="javascript:window.open('KnetProductsSetting_Details.aspx?BarCode=<%# DataBinder.Eval(Container.DataItem, "ProductsBarCode")%>','查看详细','top=120,left=150,toolbar=no, menubar=no,scrollbars=yes, resizable=no, location=no, status=no, width=780,height=500');"><asp:Image ID="Image2" runat="server" ImageUrl="../../images/View.gif" border="0"
                                                    ToolTip="查看发货详细信息" /></a></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="复制" HeaderStyle-Font-Size="12px" ItemStyle-Width="28px"
                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="center"><ItemTemplate><a href="KnetProductsSetting_Add.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "ID") %>&Type=1"><asp:Image ID="Image4" runat="server" ImageUrl="../../images/connet.gif" border="0"
                                                    ToolTip="复制" /></a></ItemTemplate></asp:TemplateField></Columns><HeaderStyle CssClass='colHeader' /><RowStyle CssClass='listTableRow' /><AlternatingRowStyle BackColor="#E3EAF2" /><PagerStyle CssClass='Custom_DgPage' /></cc1:MyGridView>
                                                        </td>
                                                    </tr>

                  
                                                </table>
                                            </asp:Panel>
                                            <asp:Panel ID="Pan_Detail" runat="server">
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td class="detailedViewHeader">
                                                            <b></b>
                                                            <asp:Label ID="Label1" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
