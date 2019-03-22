<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectSampling.aspx.cs" Inherits="Web_CG_Order_SelectSampling" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script>
        function closeWindow() {
            window.close();
        }
    </script>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script>
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "../../Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
                send_request("GET", url, null, "text", populateClass3);
            }
        }
        function populateClass3() {
            var f = document.getElementById("SmallClass");
            if (http_request.readyState == 4) {
                if (http_request.status == 200) {
                    var list = http_request.responseText;
                    var classList = list.split("|");
                    f.options.length = 1;
                    for (var i = 0; i < classList.length; i++) {
                        var tmp = classList[i].split(",");
                        f.add(new Option(tmp[1], tmp[0]));
                    }
                } else {
                    alert("您所请求的页面有异常.");
                }
            }
        }
    </script>
    <style type="text/css">
        .Div11 {
            background-image: url(../images/midbottonA2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }

        .Div22 {
            background-image: url(../images/midbottonB2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }
    </style>
    <base target="_self" />
    <title>选择供应商采购报价</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div>
            <!--头部-->
            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="150" background="../../../images/ktxt1.gif" style="background-color: #F5F5F5; height: 28px; width: 130px; padding-left: 20px;">
                        <div class="TP2">采购产品选择</div>
                    </td>
                    <td align="left" background="../../../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;">&nbsp;&nbsp;<font color="blue"></td>
                    <td width="10" background="../../../images/ktxt2.gif" style="background-color: #F5F5F5; height: 28px;" align="left"></td>
                </tr>
            </table>
            <div id="ssdd" style="padding: 3px"></div>
            <!--头部-->


            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="small">
                <tr>

                   <%-- <td width="10%" valign="top">
                        <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                            <tr>
                                <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                </td>
                                <td id="catalog_tab" class="dvtSelectedCell" align="center" nowrap>
                                    <a href="javascript:showProductCatalog()">产品分类</a>
                                </td>
                                <td class="dvtTabCache" style="width: 100%">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="XPFileExplorer"
                                        NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                        <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black"
                                            HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                        <ParentNodeStyle Font-Bold="False" />
                                        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False"
                                            HorizontalPadding="0px" VerticalPadding="0px" />
                                    </asp:TreeView>
                                </td>
                            </tr>
                        </table>
                    </td>--%>
                    <td width="88%" align="left" valign="top" style="border-left: 2px dashed #cccccc;">
                        <cc1:MyGridView ID="GridView1" AllowPaging="true" runat="server" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                            <Columns>
                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chbk" runat="server" Checked />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="请购单号" SortExpression="ID" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <asp:TextBox ID="ID" runat="server"  value=' <%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>'></asp:TextBox>
                                        <%--<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="物品编号" SortExpression="ReID" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <asp:TextBox ID="ReID" runat="server"  value=' <%# DataBinder.Eval(Container.DataItem, "ReID").ToString()%>'></asp:TextBox>
                                        <%--<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="样品名称" SortExpression="SampleName" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <asp:TextBox ID="SampleName" runat="server"  value=' <%# DataBinder.Eval(Container.DataItem, "SampleName").ToString()%>'></asp:TextBox>
                                        <%--<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="类别" SortExpression="HouseClass" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                    <%# base.Base_GetBasicCodeName("1140",DataBinder.Eval(Container.DataItem, "HouseClass").ToString())%>
                                   </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="申请数量" SortExpression="Number" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Number" runat="server"  value=' <%# DataBinder.Eval(Container.DataItem, "Number").ToString()%>'></asp:TextBox>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="封装" SortExpression="Packaging" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Packaging").ToString()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="项目组" SortExpression="ProjectGroup" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                    <%# base.Base_GetBasicCodeName("1137",DataBinder.Eval(Container.DataItem, "ProjectGroup").ToString())%>
                                   </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="购买级别" SortExpression="BuyRank" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                    <%# base.Base_GetBasicCodeName("1138",DataBinder.Eval(Container.DataItem, "BuyRank").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="请购人" SortExpression="Proposer" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                    <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "Proposer").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="备注" SortExpression="Remark" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Remark" runat="server"  value=' <%# DataBinder.Eval(Container.DataItem, "Remark").ToString()%>'></asp:TextBox>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle CssClass='colHeader' />
                            <RowStyle CssClass='listTableRow' />
                            <AlternatingRowStyle BackColor="#E3EAF2" />
                            <PagerStyle CssClass='Custom_DgPage' />
                        </cc1:MyGridView>
                        <!--GridView-->

                        <!--底部功能栏-->
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                            <tr>
                                <td height="25" width="25%">
                                    <asp:Button ID="Button2" runat="server" CssClass="crmButton small create" Text="确定选择" OnClick="Button1_Click" Style="width: 70px; height: 30px;" /></td>

<%--                                <td width="75%" align="right">料号:<asp:TextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" Width="200px"></asp:TextBox>&nbsp;
      关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" Width="200px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="产品筛选" CssClass="crmButton small save" OnClick="Button1_Click1" /></td>--%>
                            </tr>
                        </table>
                        <!--底部功能栏-->

                    </td>
                </tr>
            </table>
            <!--内部结束-->


        </div>
    </form>
</body>
</html>
