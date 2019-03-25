<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Procure_ShipCheck_Add.aspx.cs"
    Inherits="Web_Procure_ShipCheck_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script type="text/javascript" src="../../Js/Global.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
    <title>物流对账管理</title>
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script language="JAVASCRIPT">
        function btnGetSupp_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('Ddl_SuppNo').value = ss[0];
                document.all('SuppNo').value = ss[1];
            }
            else {
                document.all('Ddl_SuppNo').value = "";
                document.all('SuppNo').value = "";
            }
        }
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../../Common/SelectSalesShipList.aspx?ID=" + intSeconds + "&State=1", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('ShipNoSelectValue').value = ss[0];
                document.all('Tbx_ShipNoName').value = ss[1];
            }
            else {
                document.all('ShipNoSelectValue').value = "";
                document.all('Tbx_ShipNoName').value = "";
            }
        }
        function btnGetBackValue_onclick() {
            document.all('ContractNoSelectValue').value = "";
            document.all('ContractNoName').value = "";
        }


        //改变价格方法        
        function Keap(ipt) {
            var trs = document.getElementById("MyGridView1");

            var pipt = ipt.parentNode.parentNode;
            var i_row = pipt.rowIndex;
            var i_rows = trs.rows.length;
            var v_Number = trs.rows(i_row).cells(9).childNodes[0].value
            var v_BNumber = trs.rows(i_row).cells(10).childNodes[0].value
            var v_Price = trs.rows(i_row).cells(11).childNodes[0].value

            var v_HandPrice = trs.rows(i_row).cells(12).childNodes[0].value
            if (i_rows > 0) {
                trs.rows(i_row).cells(13).childNodes[0].value = (parseFloat(v_Price) + parseFloat(v_HandPrice)) * (parseFloat(v_Number) + parseFloat(v_BNumber));
            }
            GetTotal1();
        }
        //改变价格方法
        function Keap1(ipt) {
            var trs = document.getElementById("MyGridView2");
            var pipt = ipt.parentNode.parentNode;
            var i_row = pipt.rowIndex;
            var i_rows = trs.rows.length;
            var v_Number = trs.rows(i_row).cells(10).childNodes[0].value
            var v_Price = trs.rows(i_row).cells(11).childNodes[0].value
            if (i_rows > 0) {
                trs.rows(i_row).cells(12).childNodes[0].value = parseFloat(v_Price) * parseFloat(v_Number);
            }
            GetTotal();
        }


        //计算总数量和单价       
        function GetTotal1() {
            var GridView = document.getElementById("MyGridView1");
            var i_Num = 10001 + parseInt(GridView.rows.length);
            var v_TotalNum = 0, v_TotalNet = 0;
            for (var i = 10002; i < i_Num; i++) {
                var v_Index = i % 10000;
                if (v_Index.toString().length == 1) {
                    v_Index = "0" + v_Index.toString();
                }
                var Chbk = document.getElementById("MyGridView1_ctl" + v_Index + "_Chbk1");

                if (Chbk.checked) {
                    var Tbx_Number = document.getElementById("MyGridView1_ctl" + v_Index + "_Tbx_Number");
                    var Tbx_BNumber = document.getElementById("MyGridView1_ctl" + v_Index + "_Tbx_BNumber");
                    var Tbx_Money = document.getElementById("MyGridView1_ctl" + v_Index + "_Tbx_Money");
                    v_TotalNum += parseInt(Tbx_Number.value) + parseInt(Tbx_BNumber.value);
                    v_TotalNet += parseFloat(Tbx_Money.value);
                }
            }

            document.all("Tbx_TotalNet").value = v_TotalNet;
            document.all("Tbx_TotalNum").value = v_TotalNum;
        }
        //计算总数量和单价       
        function GetTotal() {
            var GridView = document.getElementById("MyGridView2");
            var i_Num = 10001 + parseInt(GridView.rows.length);
            var v_TotalNum = 0, v_TotalNet = 0;
            for (var i = 10002; i < i_Num; i++) {
                var v_Index = i % 10000;
                if (v_Index.toString().length == 1) {
                    v_Index = "0" + v_Index.toString();
                }
                var Chbk = document.getElementById("MyGridView2_ctl" + v_Index + "_Chbk");
                if (Chbk.checked) {
                    var Tbx_Number = document.getElementById("MyGridView2_ctl" + v_Index + "_Tbx_Number");
                    var Tbx_Money = document.getElementById("MyGridView2_ctl" + v_Index + "_Tbx_Money");
                    v_TotalNum += parseInt(Tbx_Number.value);
                    v_TotalNet += parseFloat(Tbx_Money.value);
                }
            }

            document.all("Tbx_TotalNet").value = v_TotalNet;
            document.all("Tbx_TotalNum").value = v_TotalNum;
        }

    </script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        #uploadFile {
            width: 379px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">

        <input type="hidden" name="Ddl_SuppNo" id="Ddl_SuppNo" runat="server" />

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>物流 > <a class="hdrLink" href="Procure_ShipCheck_List.aspx">物流对账单</a>
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
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                            <tr>
                                <td>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="dvtContentSpace" width="100%">
                                        <tr>
                                            <td class="detailedViewHeader"><b>基本信息</b> </td>
                                        </tr>
                                        <tr>
                                            <td align="right" height="304" valign="top">
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" height="261" width="100%">
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" height="25" width="16%">对账单号: </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="Tbx_CheckCode" runat="server" CssClass="detailedViewTextBox" MaxLength="45" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="200px"></asp:TextBox>
                                                            (<font color="red">*</font>)
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Tbx_CheckCode" Display="Dynamic" ErrorMessage="对账单号不能为空"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel" align="right">文件：
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Upload"></asp:Label>
                                                            <input id="uploadFile" type="file" runat="server" />

                                                            <asp:Button
                                                                ID="save" runat="server" Text="上传" CssClass="crmbutton small save"
                                                                OnClick="save_Click" Height="26px" />
                                                        </td>
                                                        <td align="right" class="dvtCellLabel" height="25" width="17%">对账日期: </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Stime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                            (<font color="red">*</font>)<br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="Tbx_Stime" Display="Dynamic" ErrorMessage="对账日期非空"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr_HouseNo" runat="server">
                                                        <td align="right" class="dvtCellLabel">出货仓库: </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:DropDownList ID="Ddl_HouseNo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Ddl_HouseNo_SelectedIndexChanged" Width="150px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr1" runat="server">
                                                        <td align="right" class="dvtCellLabel">总数量: </td>
                                                        <td align="left" class="dvtCellInfo">对账单：<asp:TextBox ID="Tbx_TotalNum" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                            <br />
                                                            Excel：
                                                            <asp:TextBox ID="Tbx_TotalNumExcel" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">总金额: </td>
                                                        <td align="left" class="dvtCellInfo">对账单：<asp:TextBox ID="Tbx_TotalNet" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                            <br />
                                                            Excel：
                                                            <asp:TextBox ID="Tbx_TotalNetExcel" runat="server" CssClass="detailedViewTextBox" MaxLength="48" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" Width="150px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel">日期： </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="StartDate" runat="server" CssClass="Wdate" onFocus="var EndDate=$dp.$('EndDate');WdatePicker({onpicked:function(){EndDate.focus();},maxDate:'#F{$dp.$D(\'EndDate\')}'})"></asp:TextBox>
                                                            &nbsp;到<asp:TextBox ID="EndDate" runat="server" CssClass="Wdate" onFocus="WdatePicker({minDate:'#F{$dp.$D(\'StartDate\')}'})"></asp:TextBox>
                                                            <asp:Button ID="Btn_Serch" runat="server" AccessKey="S" class="crmbutton small save" OnClick="Btn_Serch_Click" Text="匹配" title="匹配 [Alt+S]" Height="26px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="detailedViewHeader" colspan="4"><b>明细</b> </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" colspan="4" height="39">


                                                            <cc1:MyGridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="Custom_DgMain" EmptyDataText="&lt;div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'&gt; &lt;table border='0' cellpadding='5' cellspacing='0' width='98%'&gt;&lt;tr&gt; &lt;td rowspan='2' width='25%'&gt;&lt;img src='../../themes/softed/images/empty.jpg' height='60' width='61'&gt;&lt;/td&gt; &lt;td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'&gt;&lt;span class='genHeaderSmall'&gt;记录为空&lt;/span&gt;&lt;/td&gt;&lt;/tr&gt;&lt;/table&gt; &lt;/div&gt;" IsShowEmptyTemplate="true" Width="100%">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="left" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40px">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CheckBox1" runat="server" onclick="selectAll(this)" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="Chbk" runat="server" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left" HeaderText="出库单号" ItemStyle-HorizontalAlign="Left" SortExpression="XSF_Code">
                                                                        <ItemTemplate>
                                                                            <a href='/Web/Xs/SalesOut/Sales_ShipWareOut_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "XSF_FID") %>' target="_blank">
                                                                                <%# DataBinder.Eval(Container.DataItem, "XSF_FID")%></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="供应商" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%#base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "XSF_CustomerValue").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="XSF_Stime" DataFormatString="{0:yyyy-MM-dd}" HeaderText="发货日期" HtmlEncode="false" SortExpression="XSF_Stime">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="产品版本" HeaderStyle-Font-Size="12px" ItemStyle-Width="160px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetShipDetailProductsPatten(DataBinder.Eval(Container.DataItem, "XSF_FID").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="客户" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetCustomerName_Link(DataBinder.Eval(Container.DataItem, "KWD_Custmoer").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="省份" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetCityName(DataBinder.Eval(Container.DataItem, "XSF_Province").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="城市" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                        HeaderStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <%# base.Base_GetShiName(DataBinder.Eval(Container.DataItem, "XSF_City").ToString())%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:BoundField DataField="XSF_KDCode" HeaderText="单号" HtmlEncode="false" SortExpression="XSF_Money">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_TotalNumber" HeaderText="数量" HtmlEncode="false" SortExpression="XSF_TotalNumber">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_Weight" HeaderText="重量" HtmlEncode="false" SortExpression="XSF_TotalNumber">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_WuliuPrice" HeaderText="物流单价" HtmlEncode="false" SortExpression="XSF_TotalNumber">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_UpstairsCostMoney" HeaderText="上楼费" HtmlEncode="false" SortExpression="XSF_TotalNumber">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_DeliveryFee" HeaderText="送货费" HtmlEncode="false" SortExpression="XSF_TotalNumber">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_WareHouseEntry150Low" HeaderText="入仓费" HtmlEncode="false" SortExpression="XSF_TotalNumber">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_SignBill" HeaderText="回签单" HtmlEncode="false" SortExpression="XSF_SignBill">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_Insured" HeaderText="保价费率" HtmlEncode="false" SortExpression="XSF_Insured">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_TotalMoney" HeaderText="总金额" HtmlEncode="false" SortExpression="XSF_TotalMoney">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_FMoney" HeaderText="供应商承担" HtmlEncode="false" SortExpression="XSF_FMoney">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="XSF_Money" HeaderText="士腾承担" HtmlEncode="false" SortExpression="XSF_Money">
                                                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                        <HeaderStyle Font-Size="12px" HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    
                                                                    <asp:TemplateField HeaderText="实际费用">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Money" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="备注">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="Tbx_Details" runat="server" CssClass="detailedViewTextBox" MaxLength="40" Width="65px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <HeaderStyle CssClass="colHeader" />
                                                                <RowStyle CssClass="listTableRow" />
                                                                <AlternatingRowStyle BackColor="#E3EAF2" />
                                                                <PagerStyle CssClass="Custom_DgPage" />
                                                            </cc1:MyGridView>
                                                            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="dvtCellLabel" height="39">备注说明: </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3" valign="top">
                                                            <asp:TextBox ID="Tbx_DirectInRemarks" runat="server" CssClass="detailedViewTextBox" Height="50px" OnBlur="this.className='detailedViewTextBox'" OnFocus="this.className='detailedViewTextBoxOn'" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="4" style="height: 30px">
                                                            <asp:Button ID="Button1" runat="server" AccessKey="S" class="crmbutton small save" OnClick="Btn_Save_Click" Text="保 存" title="保存 [Alt+S]" Style="width: 55px; height: 30px" />
                                                            <input accesskey="X" class="crmbutton small cancel" name="button" onclick="window.history.back()" title="取消 [Alt+X]" type="button" value="取 消" style="width: 55px; height: 30px"> </input>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <hr noshade size="1">
                </td>
                <td align="right" valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
        <asp:TextBox ID="Tbx_URL" runat="server" CssClass="Custom_Hidden" Width="0px"></asp:TextBox>
        <asp:TextBox ID="Tbx_RkCode" runat="server" CssClass="Custom_Hidden" Width="0px"></asp:TextBox>


    </form>
</body>
</html>
