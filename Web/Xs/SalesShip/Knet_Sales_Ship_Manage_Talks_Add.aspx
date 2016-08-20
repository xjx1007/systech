<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Knet_Sales_Ship_Manage_Talks_Add.aspx.cs"
    Inherits="Knet_Sales_Ship_Manage_Talks_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/Web/css/knetwork.css" type="text/css">
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/include/js/ListView.js"></script>
    <script type="text/javascript">
        if (window != window.parent)
        { var P = window.parent, D = P.loadinndlg(); }

        function searchFromSelect(str) {
            var o = document.getElementById("Drop_KD");
            if (o.tagName == "SELECT") {
                var opts = o.options;
                str = str ? str : event.srcElement.innerText;

                var tmp = '';
                var kCode = event.keyCode;

                if (str != "") {
                    if (kCode == 33 || kCode == 38 || kCode == 35)//向上翻页，方向键，end
                    {
                        o.selectedIndex = o.selectedIndex > 0 ? o.selectedIndex - 1 : 0;
                        if (kCode == 35) o.selectedIndex = opts.length - 1;
                        for (var i = o.selectedIndex; i >= 0; i--) {
                            tmp = opts(i % opts.length).text;
                            if (tmp.indexOf(str) >= 0) {
                                o.selectedIndex = i % opts.length;
                                return;
                            }
                        }
                    }
                    if (kCode == 34 || kCode == 40 || kCode == 36)//
                    {
                        o.selectedIndex++;
                        if (kCode == 36) o.selectedIndex = opts.length - 1;
                    }
                    for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex); i++) {
                        tmp = opts(i % opts.length).text;
                        if (tmp.indexOf(str) >= 0) {
                            o.selectedIndex = i % opts.length;
                            return;
                        }
                    }
                    o.selectedIndex = 0;
                }
            }
        }
        function Chang() {
            var v_FollowEnd = document.getElementById("FollowEnd");
            var v_Chk_Check = document.getElementById("Chk_Check");
            if ((v_FollowEnd.checked) || (v_Chk_Check.checked)) {
                var v_Type = document.getElementById("Ddl_Type");
                if (v_Type.options[v_Type.selectedIndex].text != "--请选择--") {
                    document.getElementById("FollowText").value = v_Type.options[v_Type.selectedIndex].text;
                }
            }
            else {
                var myid = document.getElementById("Drop_KD");
                if (myid.options[myid.selectedIndex].text == "--请选择--") {
                    document.getElementById("FollowText").value = document.getElementById("Tbx_Code").value;
                }
                else {
                    if (document.getElementById("Tbx_Code").value != "") {
                        document.getElementById("FollowText").value = myid.options[myid.selectedIndex].text + "(" + document.getElementById("Tbx_Code").value + ")";
                    }
                    else {
                        document.getElementById("FollowText").value = myid.options[myid.selectedIndex].text;
                    }
                }
            }

        }

        function ChangReceive() {
            var v_CustomerName = document.getElementById("Tbx_CustomerName");
            var v_ReceiveName = document.getElementById("Tbx_ReceiveName");
            var v_Message = document.getElementById("Tbx_OldMessage");
            var v_Chk = document.getElementById("Chk_Message");
            if (v_Chk.checked) {
                document.getElementById("Tbx_Message").value = v_Message.value.replace(/CustomerName-ReceiveName/g, v_CustomerName.value + "-" + v_ReceiveName.value);
                document.getElementById("FollowText").value = document.getElementById("Tbx_Message").value;
                if (document.getElementById("FollowText").value != document.getElementById("Tbx_Message").value) {
                    document.getElementById("Tbx_Message").value = document.getElementById("FollowText").value;
                }
            }
        }

    </script>
    <style type="text/css">
        .Div11
        {
            background-image: url(../../images/midbottonA2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }
        .Div22
        {
            background-image: url(../../images/midbottonB2.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }
    </style>
    <title>发货跟踪添加</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div id="ListGo333">
        <div id="ssdd" style="padding: 2px">
        </div>
        <table height="22" border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
            <tr>
                <td width="90" align="center">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="Div11" Width="90px" Height="21px"
                        Font-Size="14px">跟踪列表</asp:HyperLink>
                </td>
                <td width="4" align="center">
                </td>
                <td width="90" align="center">
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="Div22" Width="90px" Height="21px"
                        Font-Size="14px" Font-Bold="true" ForeColor="MintCream">添加跟踪</asp:HyperLink>
                </td>
                <td width="4" align="center">
                </td>
                <td align="right">
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
        
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
            <tr>
                <td>
                    <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <asp:Panel runat="server" ID="Panel1">
                            <tr>
                                <td width="25%" height="25" align="right" class="tableBotcss">
                                    市场评审确认：
                                </td>
                                <td width="75%" class="tableBotcss">
                                    &nbsp;<asp:CheckBox ID="Chk_IsReview" runat="server" />&nbsp;&nbsp;<font color="gray">(评审确认)</font>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%" height="25" align="right" class="tableBotcss">
                                    是否结束：
                                </td>
                                <td width="75%" class="tableBotcss">
                                    &nbsp;<asp:CheckBox ID="FollowEnd" runat="server" AutoPostBack="True" OnCheckedChanged="FollowEnd_CheckedChanged" />&nbsp;&nbsp;<font
                                        color="gray">(如果已完成，结束跟踪请打“√”)</font>
                                </td>
                            </tr>
                            <tr>
                                <td width="25%" height="25" align="right" class="tableBotcss">
                                    部分发货跟踪：
                                </td>
                                <td width="75%" class="tableBotcss">
                                    &nbsp;<asp:CheckBox ID="Chk_Check" runat="server" AutoPostBack="True" OnCheckedChanged="Chk_CheckedChanged" />&nbsp;&nbsp;<font
                                        color="gray">(如果部分发货跟踪，结束跟踪请打“√”)</font>
                                </td>
                            </tr>
                            <tr id="Tr_Qr" runat="server" visible="false">
                                <td height="34" align="right" class="tableBotcss">
                                    确认方式：
                                </td>
                                <td class="tableBotcss">
                                    <asp:DropDownList ID="Ddl_Type" runat="server" Width="150px" onchange='Chang()'>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </asp:Panel>
                        <tr>
                            <td width="25%" height="25" align="right" class="tableBotcss">
                                短信通知：
                            </td>
                            <td width="75%" class="tableBotcss">
                                &nbsp;<asp:CheckBox ID="Chk_Message" AutoPostBack="True" runat="server" OnCheckedChanged="Chk_Message_CheckedChanged" />&nbsp;&nbsp;<font
                                    color="gray">(短信通知请打“√”)</font>
                            </td>
                        </tr>
                        <asp:Panel runat="server" ID="Pan_Message" Visible=false>
                        <tr>
                            <td height="34" align="right" class="tableBotcss">
                                客户：
                            </td>
                            <td class="tableBotcss">
                                <asp:TextBox ID="Tbx_CustomerName" runat="server" TextMode="MultiLine" Height="20px" Width="350px" onblur="ChangReceive()"
                                    CssClass="Boxx"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="tableBotcss">
                                收信人：
                            </td>
                            <td class="tableBotcss">
                                <asp:TextBox ID="Tbx_ReceiveName" runat="server" TextMode="MultiLine" Height="30px" Width="350px" onblur="ChangReceive()"
                                    CssClass="Boxx"></asp:TextBox>&nbsp;&nbsp;
                                <asp:TextBox ID="Tbx_ReceiveID" runat="server" 
                                    CssClass="Custom_Hidden"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="34" align="right" class="tableBotcss">
                                收信电话：
                            </td>
                            <td class="tableBotcss">
                                <asp:TextBox ID="Tbx_Phone" runat="server" TextMode="MultiLine" Height="30px" Width="350px"
                                    CssClass="Boxx"></asp:TextBox><font
                                    color="gray">多个联系人电话以逗号隔开</font>
                            </td>
                        </tr>
                        </asp:Panel>
                        <tr>
                            <td height="34" align="right" class="tableBotcss">
                                <asp:Label runat="server" ID="Lbl_Dtails"></asp:Label>
                            </td>
                            <td class="tableBotcss">
                                <asp:TextBox ID="FollowText" runat="server" TextMode="MultiLine" Height="60px" Width="350px"
                                    CssClass="Boxx" onblur="ChangReceive()"></asp:TextBox>
                                <asp:TextBox ID="Tbx_Message" runat="server" 
                                    CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="Tbx_OldMessage" runat="server" 
                                    CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox ID="Tbx_DirectOutNo" runat="server" 
                                    CssClass="Custom_Hidden"></asp:TextBox>
                            </td>
                        </tr>
                        <asp:Panel ID="Pan_Details" runat="server">
                            <tr>
                                <td height="34" align="right" class="tableBotcss">
                                    快递：
                                </td>
                                <td class="tableBotcss">
                                    <asp:DropDownList ID="Drop_KD" runat="server" Width="150px" onchange='Chang()'>
                                    </asp:DropDownList>
                                    <input type="text" id="span" onchange='Chang()' onkeyup='searchFromSelect(this.value)'
                                        onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}'
                                        style="width: 60; height: 20; border: 1 solid #0000FF; overflow-y: auto"></input>
                                </td>
                            </tr>
                            <tr>
                                <td height="34" align="right" class="tableBotcss">
                                    单号：
                                </td>
                                <td class="tableBotcss">
                                    <asp:TextBox ID="Tbx_Code" runat="server" Height="60px" Width="350px" CssClass="Boxx"
                                        onchange='Chang()'></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server" id="Tr_time" visible="false">
                                <td height="34" align="right" class="tableBotcss">
                                    确定交期：
                                </td>
                                <td class="tableBotcss">
                                    <asp:TextBox ID="Tbx_Time" runat="server" CssClass="Wdate" onFocus="WdatePicker();"></asp:TextBox>
                                </td>
                            </tr>
                        </asp:Panel>
                        <asp:Panel runat="server" ID="Pan_DirectOut">
                            <tr>
                                <td height="34" colspan="2" class="tableBotcss">
                                    <cc1:MyGridView ID="MyGridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                        IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                        PageSize="10" Width="100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <input type="CheckBox" onclick="selectAll(this)">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Height="25px" HorizontalAlign="Left" Width="40px" />
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="出库单号" DataField="DirectOutNo" SortExpression="DirectOutNo">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="物料编码" DataField="ProductsBarCode" SortExpression="ProductsBarCode">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="产品名称" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProdutsName(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                    <%# base.Base_GetProductsEdition(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                    <asp:TextBox ID="Tbx_DID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "ID").ToString()%>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="数量" DataField="DirectOutAmount" SortExpression="DirectOutAmount">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="备货" DataField="KWD_BNumber" SortExpression="KWD_BNumber">
                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="物流" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate> 
                                                <%# GetDirectOutListfollowup(DataBinder.Eval(Container.DataItem, "DirectOutNo"),"0")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="单号" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                HeaderStyle-HorizontalAlign="Left">
                                                <ItemTemplate>
                                                <%# GetDirectOutListfollowup(DataBinder.Eval(Container.DataItem, "DirectOutNo"),"1")%>
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
                        </asp:Panel>
                        <tr>
                            <td align="right" style="height: 28px">
                                &nbsp;
                            </td>
                            <td style="height: 28px">
                                &nbsp;<asp:Button ID="Button1" runat="server" Text="确定添加跟踪" CssClass="Btt" OnClick="Button1_Click" style="width: 55px;height: 33px;"  />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
