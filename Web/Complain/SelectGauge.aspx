<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectGauge.aspx.cs" Inherits="Web_Complain_SelectGauge" %>
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
                                 <asp:TemplateField HeaderText="治具编号" SortExpression="KPG_KID" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <asp:TextBox ID="KPG_KID" runat="server"  value=' <%# DataBinder.Eval(Container.DataItem, "KPG_KID").ToString()%>'></asp:TextBox>
                                        <%--<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="治具名称" SortExpression="KPG_Name" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <asp:TextBox ID="KPG_Name" runat="server"  value=' <%# DataBinder.Eval(Container.DataItem, "KPG_Name").ToString()%>'></asp:TextBox>
                                        <%--<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>

                               <asp:TemplateField HeaderText="库存数量" SortExpression="KCount" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <asp:TextBox ID="KCount" runat="server"  value=' <%# Base_GetStoreCount(DataBinder.Eval(Container.DataItem, "KPG_SuppNo").ToString(),DataBinder.Eval(Container.DataItem, "KPG_KID").ToString())%>'></asp:TextBox>
                                        <%--<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                 <asp:TemplateField HeaderText="责任人" SortExpression="KPG_Person" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                    <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "KPG_Person").ToString())%>
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

