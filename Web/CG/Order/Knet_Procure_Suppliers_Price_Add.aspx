<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false"
    CodeFile="Knet_Procure_Suppliers_Price_Add.aspx.cs" Inherits="Knet_Web_Procure_Knet_Procure_Suppliers_Price_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <title>供应商报价</title>
    <script language="javascript" type="text/javascript" src="../../../Web/DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/js/ListView.js"></script>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick(i_Num) {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Suppliers(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('GridView1$ctl02$Tbx_SuppNo').value = ss[0];
                document.all('GridView1$ctl02$Tbx_SuppName').value = ss[1];
            }
            else {
                document.all('GridView1$ctl02$Tbx_SuppNo').value = "";
                document.all('GridView1$ctl02$Tbx_SuppName').value = "";
            }
        }
    </script>
    <script>
        function changsheng(va) {
            if (va != '0') {
                var SmallClass = document.getElementById("SmallClass");
                SmallClass.disabled = false;
                var url = "../../Web/Js/ProductClassHandler.ashx?type=BigClass&BigNo=" + va;
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

        function btnGetProductsTypeValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("../../ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsClass(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsTypeNo').value = ss[0];
                document.all('Tbx_ProductsTypeName').value = ss[1];
            }
            else {
                document.all('Tbx_ProductsTypeNo').value = "";
                document.all('Tbx_ProductsTypeName').value = "";
            }
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>供应商报价 > <a class="hdrLink" href="Knet_Procure_Suppliers_Price.aspx">供应商报价</a>
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
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>供应商报价添加
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                            <tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%--内容块--%>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="304" align="right" valign="top">
                                                <table width="100%" height="261" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">版本号:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_ProductsEdition" runat="server" CssClass="detailedViewTextBox" Width="140px"></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">料号:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" Width="140px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td align="right" class="dvtCellLabel">产品分类：
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_ProductsTypeName" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                MaxLength="48" Width="200px"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_ProductsTypeNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <img src="../../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProductsTypeValue_onclick()" />
                                                        </td>

                                                        <td align="left" class="dvtCellInfo" colspan="2">停用:<asp:CheckBox runat="server" ID="Chk_IsStop" Checked="true" />
                                                            <asp:Button
                                                                ID="Button4" runat="server" Text="产品筛选" class="crmbutton small save" OnClick="Button4_Click"
                                                                CausesValidation="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="dvtCellInfo" colspan="4">
                                                            <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="true" PageSize="5" AllowSorting="True"
                                                                EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关记录</B><br/><br/></font></div>"
                                                                GridLines="None" Width="100%" HorizontalAlign="center" AutoGenerateColumns="false"
                                                                ShowHeader="true" HeaderStyle-Height="25px" OnRowDataBound="GridView1_DataRowBinding">
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="left">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" Checked />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="ProductsName" HeaderText="产品名称" SortExpression="ProductsName">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="产品名称" SortExpression="ProductsName" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetProdutsName_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="KSP_Code" HeaderText="料号" SortExpression="KSP_Code">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ProductsEdition" HeaderText="版本号" SortExpression="ProductsPattern">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="类名" SortExpression="ProductsType" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetProductsType(DataBinder.Eval(Container.DataItem, "ProductsType"))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="单位" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetUnitsName(DataBinder.Eval(Container.DataItem, "ProductsUnits"))%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="采购单价" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="70px">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="ProcureUnitPrice" runat="server" CssClass="detailedViewTextBox" Width="80px" Text='<%#GetProductsPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(),0)%>'
                                                                                MaxLength="9"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="JoinNumberb33b" runat="server" ErrorMessage="正货币形式!"
                                                                                ControlToValidate="ProcureUnitPrice" ValidationExpression="^(\d+|,\d{6})+(\.\d{0,6})?$"
                                                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                                                            
                                                                            <asp:TextBox ID="Salesprice" runat="server" CssClass="Custom_Hidden" Text='<%#GetProductsPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(),2)%>'
                                                                                MaxLength="9"></asp:TextBox><br />
                                                                            <asp:RegularExpressionValidator ID="JoinNumberb33sdgsdb" runat="server" ErrorMessage="正货币形式!"
                                                                                ControlToValidate="Salesprice" ValidationExpression="^(\d+|,\d{4})+(\.\d{0,6})?$"
                                                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="加工费" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="HandPrice" runat="server" CssClass="detailedViewTextBox" Width="80px" Text='<%#GetProductsPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(),1)%>'
                                                                                MaxLength="9"></asp:TextBox><br />
                                                                            <asp:RegularExpressionValidator ID="HandPrice33db" runat="server" ErrorMessage="正货币形式!"
                                                                                ControlToValidate="Salesprice" ValidationExpression="^(\d+|,\d{4})+(\.\d{0,6})?$"
                                                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="HandPrice33" runat="server" ErrorMessage="非空值" ControlToValidate="HandPrice"
                                                                                Display="Dynamic"></asp:RequiredFieldValidator>

                                                                            <asp:TextBox ID="ProductsBarCode" runat="server" CssClass="Custom_Hidden" Text=<%#DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="赔偿单价" HeaderStyle-ForeColor="red" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" ItemStyle-Width="80px">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="PCPrice" runat="server" CssClass="detailedViewTextBox" Width="80px" Text='<%#GetProductsPrice(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString(),2)%>'
                                                                                MaxLength="9"></asp:TextBox><br />
                                                                            <asp:RegularExpressionValidator ID="HandPrice33dc" runat="server" ErrorMessage="正货币形式!"
                                                                                ControlToValidate="Salesprice" ValidationExpression="^(\d+|,\d{4})+(\.\d{0,6})?$"
                                                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="HandPrice333" runat="server" ErrorMessage="非空值" ControlToValidate="PCPrice"
                                                                                Display="Dynamic"></asp:RequiredFieldValidator>

                                                                            <asp:TextBox ID="ProductsBarCode1" runat="server" CssClass="Custom_Hidden" Text=<%#DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString() %>></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="品牌"  HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList runat="server" ID="Ddl_Brand"></asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="供应商" SortExpression="ProductsUnits" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_SuppNo" runat="server" CssClass="Custom_Hidden" Text=''></asp:TextBox>

                                                                            <asp:TextBox ID="Tbx_SuppName" runat="server"  CssClass="Boxx" Width="150px" Text=''></asp:TextBox>
                                                                            <font color=red>*</font>
                                                                            <img src="../../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="备注" HeaderStyle-ForeColor="blue" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left" >
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Remarks" runat="server" CssClass="detailedViewTextBox" Width="100px" Text=''></asp:TextBox>
                                                                            
                                                                            <asp:RequiredFieldValidator ID="ProcureUnitPricedddssss33" runat="server" ErrorMessage="非空值"
                                                                                ControlToValidate="Salesprice" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            <asp:TextBox ID="ProcureMinShu" runat="server" CssClass="Custom_Hidden" Text="0"
                                                                                MaxLength="6"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="JoinNumberbb" runat="server" ErrorMessage="非负整数!"
                                                                                ControlToValidate="ProcureMinShu" ValidationExpression="^\d+$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                            <asp:RequiredFieldValidator ID="ProcureMinShuDDsss4444" runat="server" ErrorMessage="非空值"
                                                                                ControlToValidate="ProcureMinShu" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                            <asp:RequiredFieldValidator ID="ProcureUnitPricessss33" runat="server" ErrorMessage="非空值"
                                                                                ControlToValidate="ProcureUnitPrice" Display="Dynamic"></asp:RequiredFieldValidator>
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
                                            </td>
                                        </tr>
                                        <tr>
                                                        <td align="right" class="dvtCellLabel">价格明细：
                                                        </td>
                                            <td colspan="3" align="center" style="height: 30px">
                                                
                                                                <asp:TextBox ID="Tbx_DetailsRemarks" runat="server" Style="display: none;"></asp:TextBox>
                                                                <iframe src='/Web/eWebEditor/ewebeditor.htm?id=Tbx_DetailsRemarks&style=gray'
                                                                    frameborder='0' scrolling='no' width='750' height='350'></iframe>  
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
            </tr>
        </table>
        </td>
    <td align="right" valign="top">
        <img src="../../../themes/softed/images/showPanelTopRight.gif" />
    </td>
        </tr> </table>
    </form>
</body>
</html>
