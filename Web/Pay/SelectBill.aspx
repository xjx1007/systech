<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectBill.aspx.cs" Inherits="SelectBill" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <base target="_self" />
    <script>
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "../Web/Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
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

    <title>选择票据</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                <tr>
                    <td style="height: 2px"></td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>财务 > <a class="hdrLink" href="SelectProduct.aspx">选择票据</a>
                        <asp:TextBox runat="server" ID="Tbx_KSP_SampleId" CssClass="Custom_Hidden"></asp:TextBox>
                    </td>
                    <td width="100%" nowrap>
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="sep1" style="width: 1px;"></td>
                                <td class="small"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td style="height: 2px"></td>
                </tr>
            </table>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">

                <tr>
                    <td>
                        <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                            <tr>
                                <!-- Buttons -->
                                <td style="padding-right: 20px" align="left" nowrap></td>
                            </tr>
                            <tr>
                                <td width="100%">
                                    
                                                <cc1:MyGridView ID="GridView_Bill" runat="server" AllowSorting="True" AllowPaging="true" PageSize="10"
                                                                    IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                                     Width="100%">
                                                                    <Columns>
                                                                        <asp:TemplateField>
                                                                            <HeaderTemplate>
                                                                                <input type="CheckBox" onclick="selectAll(this)">
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="Chbk" runat="server"  />
                                                                            </ItemTemplate>
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle Height="25px" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField HeaderText="票据单号" DataField="CAA_BillCode"
                                                                            ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="票据日期" DataField="CAA_StartDateTime" DataFormatString="{0:yyyy-MM-dd}"
                                                                            ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="到期日期" DataField="CAA_EndDateTime"  DataFormatString="{0:yyyy-MM-dd}"
                                                                            ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="票据金额" DataField="CAA_PayMoney" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Right" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField HeaderText="摘要" DataField="CAA_Details"
                                                                           ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                            <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="来源" 
                                                                           ItemStyle-HorizontalAlign="left" HeaderStyle-HorizontalAlign="center">
                                                                                                                    <ItemTemplate>
                                            <%#base.Base_GetSupplierOrCustomerName(DataBinder.Eval(Container.DataItem, "CAA_CustomerValue").ToString())%>
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
                        </table>
                        <!--分页-->
                    </td>
                </tr>
            </table>

            <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" style="border-top: 1px solid #A3B2CC;">
                <tr>
                    <td height="25" width="40%">
                        <asp:Button ID="Button2" runat="server" CssClass="crmbutton small save" Text="确定选择" OnClick="Button2_Click" />
                        <td width="60%" align="right">关健词:<asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="100px"></asp:TextBox>&nbsp;<asp:Button ID="Button1" runat="server" Text="筛选"  CssClass="crmbutton small save"  OnClick="Button1_Click1" /></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
