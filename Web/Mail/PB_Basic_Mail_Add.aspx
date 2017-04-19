<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="PB_Basic_Mail_Add.aspx.cs"
    Inherits="PB_Basic_Mail_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>邮件添加</title>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="PB_Basic_Menu_List.aspx">邮件</a>
                </td>
                <td width="100%" nowrap></td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>
        <script type="text/javascript">
            function btnGetContentPerson_onclick() {
                var s_Customer = "";
                s_Customer = document.all('Tbx_SuppNo').value;
                var temaap = window.showModalDialog("SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
                if (temaap != undefined) {
                    var sws;
                    sws = temaap.split(",");
                    document.all('Tbx_ReceiveEmail').value = sws[3];
                }
                else {
                    document.all('Tbx_ReceiveEmail').value = "";
                }
            }
            function btnGetContentPerson_onclick1() {
                var s_Customer = "";
                s_Customer = document.all('Tbx_SuppNo').value;
                var temaap = window.showModalDialog("SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
                if (temaap != undefined) {
                    var sws;
                    sws = temaap.split(",");
                    document.all('Tbx_Cc').value = sws[3];
                }
                else {
                    document.all('Tbx_Cc').value = "";
                }
            }
            function btnGetContentPerson_onclick2() {
                var s_Customer = "";
                s_Customer = document.all('Tbx_SuppNo').value;
                var temaap = window.showModalDialog("SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
                if (temaap != undefined) {
                    var sws;
                    sws = temaap.split(",");
                    document.all('Tbx_Ms').value = sws[3];
                }
                else {
                    document.all('Tbx_Ms').value = "";
                }
            }

            function deleteRow(obj) {
                myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
                var Values = document.getElementsByName("DetailsFile");

                var bm_num = "";
                for (i = 0; i < Values.length; i++) {
                    bm_num += Values[i].value + ",";
                }
                document.all("Tbx_FileUrl").value = bm_num;
            }
        </script>

        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtSelectedCell" align="center" nowrap>邮件
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
                                            <td align="right" valign="top">
                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">发件人：
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:DropDownList runat="server" ID="Ddl_SendEmail" CssClass="detailedViewTextBox" Width="400px"></asp:DropDownList>
                                                            <pc:PTextBox ID="Tbx_SendEmail" runat="server" CssClass="Custom_Hidden"></pc:PTextBox><font
                                                                color="red">*</font>
                                                            <asp:Label runat="server" ID="Lbl_Send"></asp:Label>
                                                            (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="发件人不能为空"
                                                            ControlToValidate="Ddl_SendEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">收件人：</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox runat="server" ID="Tbx_ReceiveEmail" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" Height="50px"></asp:TextBox>
                                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetContentPerson_onclick()" />
                                                            (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="收件人不能为空"
                                                            ControlToValidate="Tbx_ReceiveEmail" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">抄送人：</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox runat="server" ID="Tbx_Cc" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" Height="50px"></asp:TextBox>
                                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetContentPerson_onclick1()" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">密送人：</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:TextBox runat="server" ID="Tbx_Ms" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" Height="50px"></asp:TextBox>
                                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetContentPerson_onclick2()" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" align="right" class="dvtCellLabel">附件： </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <table id="myTable" width="50%" border="0" align="left" cellpadding="5" cellspacing="0"
                                                                class="ListDetails" style="height: 28px">
                                                                <tr>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>类型</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>附件</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>操作</b>
                                                                    </td>
                                                                </tr>
                                                                <asp:Label ID="Tbx_File" runat="server"></asp:Label>
                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="Tr_Order">
                                                        <td width="16%" align="right" class="dvtCellLabel">产品附件：</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <cc1:MyGridView ID="GridView_Comment" runat="server" AllowPaging="True" AllowSorting="True" PageSize="100"
                                                                IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="选择" HeaderStyle-Font-Size="12px" ItemStyle-Width="10px">

                                                                        <HeaderTemplate>
                                                                            <input type="CheckBox" onclick="selectAll(this)" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="名称" DataField="PBA_Name" SortExpression="PBA_Name"
                                                                        HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="类别" SortExpression="PBA_ProductsType" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetBasicCodeName("778", DataBinder.Eval(Container.DataItem, "PBA_ProductsType").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="附件" SortExpression="PBA_URL" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <a target="_blank" href="<%#DataBinder.Eval(Container.DataItem, "PBA_URL").ToString()%>"><%# DataBinder.Eval(Container.DataItem, "PBA_Name").ToString()%></a>
                                                                            <asp:TextBox ID="Tbx_UrlDetails" CssClass="Custom_Hidden" runat="server" Text=<%#DataBinder.Eval(Container.DataItem, "PBA_URL").ToString()%>></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField HeaderText="描述" DataField="PBA_Remarks" SortExpression="PBA_Remarks"
                                                                        HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" Width="100px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="创建人" SortExpression="PBA_Creator" HeaderStyle-Font-Size="12px"
                                                                        ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetUserName(DataBinder.Eval(Container.DataItem, "PBA_Creator").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField HeaderText="上传时间" DataField="PBA_Ctime" SortExpression="PBA_Ctime"
                                                                        HtmlEncode="false">
                                                                        <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                        <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                    </asp:BoundField>
                                                                </Columns>
                                                                <HeaderStyle CssClass='colHeader' />
                                                                <RowStyle CssClass='listTableRow' />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass='Custom_DgPage' />
                                                            </cc1:MyGridView>

                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">上传：</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <input id="uploadFile" type="file" runat="server" class="Boxx" size="30" />
                                                            <asp:Button
                                                                ID="save" runat="server" Text="上传" CssClass="crmbutton small save"
                                                                OnClick="save_Click" Height="26px" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">标题：</td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Title" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="400px" ValidType="String"></pc:PTextBox><font color="red">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="16%" height="25" align="right" class="dvtCellLabel">内容：</td>
                                                        <td class="dvtCellInfo" align="left">

                                                            <asp:TextBox ID="Tbx_Text" runat="server" Style="display: none;"></asp:TextBox>
                                                            <iframe src='../eWebEditor/ewebeditor.htm?id=Tbx_Text&style=gray'
                                                                frameborder='0' scrolling='no' width='620' height='350'></iframe>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="height: 30px; width: 70px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Code" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_FileUrl" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_User" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="Tbx_UserPassWord" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="Tbx_SuppNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_OrderNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_DirectOutNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_CheckNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_ScNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_MailType" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
