<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Zl_Produce_Problem_Add.aspx.cs"
    Inherits="Zl_Produce_Problem_Add" %>
<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>生产问题添加</title>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">

        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Products/SelectProduct.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=700px");
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsName').value = ss[0];
                document.all('Tbx_ProdutsBarCode').value = ss[2];
            }
            else {
                document.all('Tbx_ProductsName').value = "";
                document.all('Tbx_ProdutsBarCode').value = "";
            }
        }

    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtSelectedCell" align="center" nowrap>添加
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
                                        <asp:Panel runat="server" ID="Pan_Basic">
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>基本信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">编号：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <pc:PTextBox ID="Tbx_Code" runat="server"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" ValidError="编号不能为空！" ValidType="String" Width="200px">
                                                    </pc:PTextBox>
                                                    <font color="red">*</font>
                                                </td>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">生产标题：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <pc:PTextBox ID="Tbx_Title" runat="server"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px" ValidError="生产标题不能为空！" ValidType="String">
                                                    </pc:PTextBox>
                                                    <font color="red">*</font>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">产品型号：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <pc:PTextBox ID="Tbx_ProductsName" runat="server"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                    </pc:PTextBox>
                                                    <pc:PTextBox ID="Tbx_ProdutsBarCode" runat="server"
                                                        CssClass="Custom_Hidden">
                                                    </pc:PTextBox>
                                                    <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                    
                                                <asp:Button ID="Button1" runat="server" Text="筛选" AccessKey="T" title="筛选 [Alt+T]"
                                                    class="crmbutton small save"  OnClick="Btn_Serch_Click" /> 
                                                </td>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">生产阶段：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:DropDownList ID="Ddl_ScStage" runat="server"
                                                        CssClass="detailedViewTextBox" Width="200px">
                                                    </asp:DropDownList>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择生产阶段！"
                                                        ControlToValidate="Ddl_ScStage" Display="Dynamic"></asp:RequiredFieldValidator>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">日期：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <pc:PTextBox ID="Tbx_STime" runat="server"
                                                        CssClass="Wdate" onFocus="WdatePicker()" Width="200px">
                                                    </pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请选择日期！"
                                                        ControlToValidate="Tbx_STime" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">问题性质：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:DropDownList ID="Ddl_Type" runat="server"
                                                        CssClass="detailedViewTextBox" Width="200px">
                                                    </asp:DropDownList>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请选择问题性质！"
                                                        ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>

                                                </td>
                                            </tr>
                                        </asp:Panel>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">审批流程：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:DropDownList ID="Ddl_Flow" runat="server"
                                                        CssClass="detailedViewTextBox" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">状态：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:DropDownList ID="Ddl_FlowStep" runat="server"
                                                        CssClass="detailedViewTextBox" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        <asp:Panel runat="server" ID="Pan_Basic1">

                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">责任人：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:DropDownList ID="Ddl_DutyPerson" runat="server"
                                                        CssClass="detailedViewTextBox" Width="200px">
                                                    </asp:DropDownList>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="请选择责任人！"
                                                        ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">责任部门：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">

                                                    <asp:DropDownList ID="Ddl_DutyDepart" runat="server"
                                                        CssClass="detailedViewTextBox" Width="200px">
                                                    </asp:DropDownList>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="请选择责任部门！"
                                                        ControlToValidate="Ddl_DutyDepart" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">希望完成时间：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <pc:PTextBox ID="Tbx_HopeDate" runat="server"
                                                        CssClass="Wdate" onFocus="WdatePicker()" Width="200px">
                                                    </pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择完成时间！"
                                                        ControlToValidate="Tbx_HopeDate" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">问题内容：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                    <asp:TextBox ID="Tbx_Text" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" cols="90" Rows="8"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <uc2:CommentList ID="CommentList2" runat="server" CommentFID="" CommentType="-1" />
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        
                                        <tr>
                                            <td colspan="4">
                                                <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="10"
                                            BorderColor="#4974C2"
                                            EmptyDataText="<div style='border: 3px solid rgb(153, 153, 153); background-color: rgb(255, 255, 255); width: 45%; position: relative; z-index: 10000000;'> <table border='0' cellpadding='5' cellspacing='0' width='98%'><tr> <td rowspan='2' width='25%'><img src='../../../themes/softed/images/empty.jpg' height='60' width='61'></td> <td style='border-bottom: 1px solid rgb(204, 204, 204);' nowrap='nowrap' width='75%'><span class='genHeaderSmall'>记录为空</span></td></tr></table> </div>"
                                           OnRowDataBound="GridView1_DataRowBinding"  >
                                            <Columns>
                                                <asp:TemplateField ItemStyle-Width="40px" ItemStyle-Height="25px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="left">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="CheckBox1" onclick="selectAll(this)" runat="server" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Chbk" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="采购单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <a href="/WEB/CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>" target="_blank">
                                                            <%# DataBinder.Eval(Container.DataItem, "OrderNo") %></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField HeaderText="采购日期" DataField="OrderDateTime" SortExpression="OrderDateTime"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="要求日期" DataField="ArrivalDate" SortExpression="ArrivalDate"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="交期确认" DataField="OrderPreToDate" SortExpression="OrderPreToDate"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="采购类型" DataField="ProcureTypeName" SortExpression="ProcureTypeName"
                                                    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="供应商" SortExpression="SuppNo" HeaderStyle-Font-Size="12px"
                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetSupplierName_Link(DataBinder.Eval(Container.DataItem, "SuppNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="产品类型" HeaderStyle-Font-Size="12px" ItemStyle-Width="150px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# base.Base_GetOrderDetailProductsPatten(DataBinder.Eval(Container.DataItem, "OrderNo").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="数量" DataField="OrderAmount" SortExpression="OrderAmount"
                                                    HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="入库" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%#GetRk(DataBinder.Eval(Container.DataItem, "RkState").ToString(),DataBinder.Eval(Container.DataItem, "OrderNo").ToString(),DataBinder.Eval(Container.DataItem, "ProcureTypeName").ToString())%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="未入库" DataField="wrkNumber" SortExpression="wrkNumber"
                                                    HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="已入库" DataField="RkNumber" SortExpression="RkNumber"
                                                    HtmlEncode="false">
                                                    <ItemStyle HorizontalAlign="Left" Font-Size="12px" />
                                                    <HeaderStyle HorizontalAlign="Left" Font-Size="12px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="实际交货" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                    HeaderStyle-HorizontalAlign="Left">
                                                    <ItemTemplate>
                                                        <%# GetOutWareListfollowup(DataBinder.Eval(Container.DataItem, "OrderNo"),"订单号",DataBinder.Eval(Container.DataItem, "ProcureTypeName").ToString())%>
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
                                        <asp:Panel runat="server" ID="Pan_Cl">
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>处置</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">原因：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:TextBox ID="Tbx_Cause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" cols="90" Rows="8"></asp:TextBox>

                                                </td>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">临时处置：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:TextBox ID="Tbx_Temporary" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" cols="90" Rows="8"></asp:TextBox>

                                                </td>

                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">完成时间：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <pc:PTextBox ID="Tbx_DoneTime" runat="server"
                                                        CssClass="Wdate" onFocus="WdatePicker()" Width="200px">
                                                    </pc:PTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <uc2:CommentList ID="CommentList1" runat="server" CommentFID="" CommentType="-1" />
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <asp:Panel runat="server" ID="Pan_Done">
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>结案</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">结果确认：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:TextBox ID="Tbx_Result" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" cols="90" Rows="8"></asp:TextBox>

                                                </td>
                                                <td width="15%" height="25" align="right" class="dvtCellLabel">结案：
                                                </td>
                                                <td width="35%" class="dvtCellInfo" align="left">
                                                    <asp:DropDownList ID="Ddl_ClosedType" runat="server"
                                                        CssClass="detailedViewTextBox" Width="200px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Save_Click" Style="height: 30px; width: 70px" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="  取消  " style="height: 30px; width: 70px">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_State" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_ClosedState" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
