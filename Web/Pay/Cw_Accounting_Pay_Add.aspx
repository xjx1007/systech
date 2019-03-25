<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Cw_Accounting_Pay_Add.aspx.cs"
    Inherits="Cw_Accounting_Pay_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css" />
    <title>付款单信息</title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.open("../Common/SelectSuppliers.aspx?ID=" + intSeconds + "&callback=SetReturnValueInOpenner_Suppliers1", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
        }
        function SetReturnValueInOpenner_Suppliers1(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('Tbx_SuppNo').value = ss[0];
                document.all('Tbx_SuppName').value = ss[1];
            }
            else {
                document.all('Tbx_SuppName').value = "";
                document.all('Tbx_SuppNo').value = "";
            }
        }
        function btnGetBill_onclick1() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            v_newNum = $("BillNum").value;
            var temp = window.open("SelectBill.aspx?ID=" + document.all("BillID").value + "&callback=SetReturnValueInOpenner_Suppliers2", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
           
        }
        function SetReturnValueInOpenner_Suppliers2(temp) {
            if (temp != undefined) {
                var ss1, s_Value, s_Name, i_row, s_ID;
                i_row = BillTable.rows.length;
                s_ID = document.all("BillID").value + ",";
                ss1 = tempd.split("|");
                for (var i = 0; i < ss1.length - 1; i++) {
                    s_Value = ss1[i];
                    var Response = Cw_Accounting_Pay_Add.GetBillDetails(ss1[i]);
                    ss = Response.value.split(",");

                    var objRow = BillTable.insertRow(i_row);
                    v_newNum = parseInt(v_newNum) + i + 1;

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow2(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"text\" Class=\"Custom_Hidden\" Name=\"Tbx_BillID_' + v_newNum + '\" value=\"' + ss1[i] + '\" ><input  type=\"text\" Class=\"Custom_Hidden\" Name=\"Tbx_BillCode_' + v_newNum + '\" value=\"' + ss[0] + '\" >' + ss[0];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"text\"   Class=\"Custom_Hidden\"  Name=\"Tbx_BillStartDateTime_' + v_newNum + '\" value=\"' + ss[1] + '\"  >' + ss[1];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"text\"   Class=\"Custom_Hidden\"  Name=\"Tbx_BillEndDateTime_' + v_newNum + '\" value=\"' + ss[2] + '\">' + ss[2];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"text\"  Class=\"Custom_Hidden\"   Name=\"Tbx_BillMoney_' + v_newNum + '\" value=\"' + ss[3] + '\">' + ss[3];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"text\"  Class=\"Custom_Hidden\"   Name=\"Tbx_BillDetails_' + v_newNum + '\" value=\"' + ss[4] + '\">' + ss[4];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"text\"  Class=\"Custom_Hidden\"   Name=\"Tbx_BillFrom_' + v_newNum + '\" value=\"' + ss[5] + '\">' + ss[5];
                    objCel.className = "ListHeadDetails";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                $("BillID").value = s_ID;
                $("BillNum").value = parseInt(v_newNum) + 1;
            }
        }
        function deleteRow2(obj) {
            BillTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        }
        function DeleteRow(obj) {
            newBill.deleteRow(obj.parentElement.parentElement.rowIndex);
        }

        function btnGetBill_onclick() {
            i_row = newBill.rows.length;
            i_Num = $("Tbx_NewBillNum").value;
            var objRow = newBill.insertRow(i_row);
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<A onclick=\"DeleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:100px;"  Name=\"BillCode_' + i_Num + '\" >';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\"  style="width:100px;"  Name=\"BillStartDateTime_' + i_Num + '\"   CssClass="Wdate" onFocus="WdatePicker()">';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\"  style="width:100px;"  Name=\"BillEndDateTime_' + i_Num + '\" CssClass="Wdate" onFocus="WdatePicker()">';
            objCel.className = "ListHeadDetails";

            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:100px;"  Name=\"BillMoney_' + i_Num + '\" >';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:100px;"  Name=\"BillDetails_' + i_Num + '\" >';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:100px;"  Name=\"BillFrom_' + i_Num + '\" >';
            objCel.className = "ListHeadDetails";
            document.all("Tbx_NewBillNum").value = parseInt(i_Num) + 1;
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopLeft.gif"/>
                </td>
                <td>
                    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
                        <tr>
                            <td class="showPanelBg" valign="top" width="100%">
                                <span class="lvtHeaderText">
                                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                                <br>
                                <hr noshade size="1">

                                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr valign="bottom">
                                        <td style="height: 44px">
                                            <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                                <tr>
                                                    <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                                    </td>
                                                    <td class="dvtSelectedCell" align="center" nowrap>付款单信息
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
                                            <table border="0" cellspacing="3" cellpadding="3" width="100%" class="dvtContentSpace">
                                                <tr>
                                                    <td>
                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                            <tr>
                                                                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                                                                <asp:TextBox ID="Tbx_FID1" runat="server" Style="display: none"></asp:TextBox>
                                                                <asp:TextBox ID="Tbx_Code" runat="server" Style="display: none"></asp:TextBox>
                                                                <td colspan="4" class="detailedViewHeader">
                                                                    <b>基本信息</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="dvtCellLabel">编号:
                                                                </td>
                                                                <td class="dvtCellInfo">
                                                                    <pc:PTextBox runat="server" ID="Tbx_FID" AllowEmpty="false" ValidError="编号不能为空" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        Width="150px"></pc:PTextBox>
                                                                    (<font color="red">*</font>)
                                                                </td>
                                                                <td class="dvtCellLabel">负责人:
                                                                </td>
                                                                <td class="dvtCellInfo">
                                                                    <asp:DropDownList runat="server" ID="Ddl_DutyPerson">
                                                                    </asp:DropDownList>
                                                                    (<font color="red">*</font>)
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="dvtCellLabel">客户/供应商:
                                                                </td>
                                                                <td class="dvtCellInfo">
                                                                    <pc:PTextBox runat="server" ID="Tbx_SuppName" AllowEmpty="false" ValidError="供应商不能为空"
                                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                                    <img src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                        onclick="return btnGetReturnValue_onclick()" />
                                                                    (<font color="red">*</font>)
                                                                <pc:PTextBox runat="server" ID="Tbx_SuppNo" CssClass="Custom_Hidden" Width="0px"></pc:PTextBox>
                                                                </td>
                                                                <td class="dvtCellLabel">帐号:
                                                                </td>
                                                                <td class="dvtCellInfo">
                                                                    <asp:DropDownList runat="server" ID="Ddl_Account" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Account_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    (<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator5" runat="server" ErrorMessage="帐号不能为空" ControlToValidate="Ddl_Account"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td class="dvtCellLabel">付款类型:
                                                                </td>
                                                                <td class="dvtCellInfo" colspan="3">
                                                                    <asp:DropDownList runat="server" ID="Ddl_Type" AutoPostBack="True" OnSelectedIndexChanged="Ddl_Type_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    (<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="付款类型不能为空" ControlToValidate="Ddl_Type"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="dvtCellLabel">付款日期:
                                                                </td>
                                                                <td class="dvtCellInfo">
                                                                    <pc:PTextBox runat="server" ID="Tbx_PayTime" AllowEmpty="false" ValidError="付款日期不能为空"
                                                                        CssClass="Wdate" onFocus="WdatePicker()" Width="180px"></pc:PTextBox>
                                                                    (<font color="red">*</font>)
                                                                </td>
                                                                <td class="dvtCellLabel">付款金额:
                                                                </td>
                                                                <td class="dvtCellInfo">
                                                                    <pc:PTextBox runat="server" ID="Tbx_Money"
                                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                                </td>
                                                            </tr>

                                                            <asp:Panel runat="server" ID="Pan_YFBill" Visible="false">

                                                                <tr>
                                                                    <asp:Panel runat="server" ID="Pan_BillID" Visible="false">
                                                                        <td class="dvtCellLabel">票据单号:
                                                                        </td>
                                                                        <td class="dvtCellInfo">
                                                                            <pc:PTextBox runat="server" ID="Tbx_YFBillCode" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                                            (<font color="red">*</font>)
                                                                        </td>
                                                                    </asp:Panel>
                                                                    <td class="dvtCellLabel">到期日期:
                                                                    </td>
                                                                    <td class="dvtCellInfo">
                                                                        <pc:PTextBox runat="server" ID="Tbx_YFOutDate" AllowEmpty="false" ValidError="到期日期不能为空"
                                                                            CssClass="Wdate" onFocus="WdatePicker()" Width="180px"></pc:PTextBox>
                                                                        (<font color="red">*</font>)
                                                                    </td>
                                                                </tr>
                                                            </asp:Panel>
                                                            <!--   <tr>
                                                            <td class="dvtCellLabel">
                                                                状态:
                                                            </td>
                                                            <td class="dvtCellInfo" colspan="3">
                                                                <asp:DropDownList runat="server" ID="Ddl_State">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>-->
                                                            <tr>
                                                                <td class="dvtCellLabel">摘要:
                                                                </td>
                                                                <td class="dvtCellInfo" colspan="3">
                                                                    <pc:PTextBox runat="server" ID="Tbx_Details" TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="280px" Height="50px"></pc:PTextBox>
                                                                </td>
                                                            </tr>
                                                            <asp:Panel runat="server" ID="Pan_Bill" Visible="false">
                                                                <tr>
                                                                    <td class="detailedViewHeader" colspan="4">
                                                                        <b>现有票据信息</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <asp:TextBox ID="BillNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                                    <asp:TextBox ID="BillID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                    <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                                        <table id="BillTable" width="100%" border="0" align="center" cellpadding="0"
                                                                            cellspacing="0" class="ListDetails">
                                                                            <tr id="tr3">
                                                                                <td align="center" class="ListHead">操作
                                                                                </td>
                                                                                <td align="center" class="ListHead">票据单号
                                                                                </td>
                                                                                <td align="center" class="ListHead">票据日期
                                                                                </td>
                                                                                <td align="center" class="ListHead">到期日期
                                                                                </td>
                                                                                <td align="center" class="ListHead">票据金额
                                                                                </td>
                                                                                <td align="center" class="ListHead">摘要
                                                                                </td>
                                                                                <td align="center" class="ListHead">来源
                                                                                </td>
                                                                            </tr>
                                                                            <asp:Label runat="server" ID="Lbl_Details1"></asp:Label>
                                                                        </table>
                                                                        <input id="Button4" runat="server" class="crmbutton small create" onclick="return btnGetBill_onclick1()" type="button"
                                                                               value="选择票据" />
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="detailedViewHeader" colspan="4">
                                                                        <b>添加票据信息</b>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td align="right" class="dvtCellInfo" colspan="4">

                                                                        <asp:TextBox ID="Tbx_NewBillNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

                                                                        <table cellpadding="2" class="dvtCellInfo" id="newBill" align="center" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td class="ListHead">删除</td>
                                                                                <td class="ListHead">单号</td>
                                                                                <td class="ListHead">票据日期</td>
                                                                                <td class="ListHead">到期日期</td>
                                                                                <td class="ListHead">票据金额</td>
                                                                                <td class="ListHead">摘要</td>
                                                                                <td class="ListHead">来源</td>
                                                                            </tr>
                                                                            <asp:Label runat="server" ID="Lbl_Details2"></asp:Label>

                                                                        </table>

                                                                        <input title="添加 [Alt+E]" type="button" accesskey="E" class="crmbutton small create"
                                                                               onclick="btnGetBill_onclick()" style="width: 80px; height: 25px"
                                                                               name="Btn_AddDetails" id="Btn_AddDetails" value="&nbsp;添加&nbsp;"/>
                                                                    </td>
                                                                </tr>
                                                            </asp:Panel>
                                                            <tr>
                                                                <td class="detailedViewHeader" colspan="4">
                                                                    <b>应付款信息</b>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <cc1:MyGridView ID="MyGridView1" runat="server" AllowSorting="True"
                                                                        IsShowEmptyTemplate="true" AutoGenerateColumns="False" CssClass="Custom_DgMain"
                                                                        PageSize="10" Width="100%">
                                                                        <Columns>
                                                                            <asp:TemplateField>
                                                                                <HeaderTemplate>
                                                                                    <input type="CheckBox" onclick="selectAll(this)"/>
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="Chbk" runat="server" Checked />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" />
                                                                                <ItemStyle Height="25px" HorizontalAlign="Left" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="应付款编号" ItemStyle-HorizontalAlign="center"
                                                                                HeaderStyle-HorizontalAlign="center">
                                                                                <ItemTemplate>
                                                                                    <a href="Cw_Accounting_Pay_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "CAP_ID") %>">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "CAP_Code").ToString()%></a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:BoundField HeaderText="期次" DataField="CAP_State"
                                                                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="应付金额" DataField="CAP_ReceiveMoney"
                                                                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="应付日期" DataField="CAP_Stime"
                                                                                DataFormatString="{0:yyyy-MM-dd}" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            </asp:BoundField>
                                                                            <asp:BoundField HeaderText="已付金额" DataField="CAP_PayMoney"
                                                                                ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                                                <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                                <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="当前付款" HeaderStyle-HorizontalAlign="left">
                                                                                <ItemTemplate>
                                                                                    <pc:PTextBox runat="server" ID="Tbx_PayMoney"
                                                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px" Text='<%# DataBinder.Eval(Container.DataItem, "CAP_LeftMoney") %>'></pc:PTextBox>
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
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">&nbsp;
                                        <br />
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                   type="button" name="button" value="取 消" style="width: 55px; height: 33px;"/>
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
    </form>
</body>
</html>
