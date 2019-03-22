<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateBom.aspx.cs" Inherits="Web_Products_UpdateBom" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>修改BOM</title>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="detail_info_click('Div1');">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                           
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">

                                        <tr>
                                            <td colspan="2">
                                                <div id="Div3">

                                                    <table width="100%" cellspacing="0" cellpadding="0">
                                                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                                        <br />
                                                         <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                                                        <tr>
                                                            <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                            <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <td align="left" class="dvtCellInfo" style="text-align: left">
                                                                <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="0"
                                                                    cellspacing="0" class="ListDetails">
                                                                    <tr id="tr3">
                                                                        <td align="center" class="ListHead">序号
                                                                        </td>
                                                                        <td align="center" class="ListHead">料号
                                                                        </td>
                                                                        
                                                                        <td align="center" class="ListHead">修改名称
                                                                        </td>
                                                                       
                                                                        <td align="center" class="ListHead">修改型号
                                                                        </td>
                                                                        
                                                                        <td align="center" class="ListHead">修改版本
                                                                        </td>
                                                                        
                                                                        <td align="center" class="ListHead">修改备注
                                                                        </td>
                                                                       
                                                                        <td align="center" class="ListHead">修改包装数
                                                                        </td>
                                                                    </tr>
                                                                    <%=s_ProductsTable_BomDetail %>
                                                                    <asp:Label runat="server" ID="Lbl_Bom" Visible="false"></asp:Label>
                                                                </table>
                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <td colspan="4">
                                                                <div style="float: left">
                                                                   
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                    <input type="button" runat="server" id="Btn_Create" value="确   定"  onserverclick="Btn_Create_OnServerClick" class="crmbutton small create" />
                                                                </div>
                                                                <div class="clearfloat" style="clear: both"></div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>                                                          
                   
                                        <tr>
                                            <td colspan="2" align="center">
                                               
                                                <asp:Button ID="Button2" runat="server" Text="保 存"  AccessKey="S" title="保存 [Alt+S]" OnClientClick="return check1();"
                                                    class="crmbutton small save" OnClick="Button2_OnClick" Style="width: 55px; height: 33px;" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                       type="button" name="button" value="取 消" style="width: 55px; height: 33px;"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                     </div>
                </td>
            
            </tr>
        </table>
    </form>
</body>
</html>
