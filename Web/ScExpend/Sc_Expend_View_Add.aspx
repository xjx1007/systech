<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sc_Expend_View_Add.aspx.cs" Inherits="Web_ScExpend_Sc_Expend_View_Add" %>


<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>添加物料</title>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../Js/bodyedit.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" AllowSorting="True" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>" GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false" ShowHeader="true" HeaderStyle-Height="25px">
                <Columns>

                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="Chbk" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="KSP_Code" HeaderText="料号" SortExpression="KSP_Code">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ProductsPattern" HeaderText="料号" SortExpression="ProductsPattern">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="ProductsEdition" HeaderText="型号" SortExpression="ProductsEdition">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="Number" HeaderText="仓库" SortExpression="Number">
                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="数量" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                           <asp:TextBox ID="Tbx_Remark" runat="server" Width="70px" Text=""></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="类型" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                           
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="Tbx_Remark" runat="server" Width="70px" Text=""></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle CssClass='colHeader' />
                <RowStyle CssClass='listTableRow' />
                <AlternatingRowStyle BackColor="#E3EAF2" />
                <PagerStyle CssClass='Custom_DgPage' />
            </cc1:MyGridView>
        </div>
    </form>
</body>
</html>
