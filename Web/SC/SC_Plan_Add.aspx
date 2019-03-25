<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SC_Plan_Add.aspx.cs"
    Inherits="SC_Plan_Add" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>生产排成表</title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="JavaScript" src="/Web/Js/Global.js" type="text/javascript"></script>
</head>
<script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
<script type="text/javascript" src="/Web/KDialog/lhgdialog.js"></script>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        //var temp = window.showModalDialog("/Web/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
        var temp = window.open("/Web/Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "选择供应商", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
    }
    function SetReturnValueInOpenner_Suppliers(temp) {
        if (temp != undefined) {
            var ss;
            ss = temp.split("|");
            document.all('SuppNoSelectValue').value = ss[0];
            document.all('SuppNo').value = ss[1];
        }
        else {
            document.all('SuppNoSelectValue').value = "";
            document.all('SuppNo').value = "";
        }
    }
    //改变日期
    function Keap1(ipt) {
        var trs = document.getElementById("GridView1");
        var pipt = ipt.parentNode.parentNode;
        var i_row = pipt.rowIndex;
        var i_rows = parseInt(i_row) + 1;
        var v_row = i_rows;
        if (v_row.toString().length == 1) {
            v_row = "0" + i_rows;
        }
        var i_rows = trs.rows.length;
        var BegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_BeginTime").value;
        var EndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value;
        var FBegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_FBeginTime").value;
        var FEndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value;
        var Days = document.getElementById("GridView1_ctl" + v_row + "_Tbx_Days").value;
        if ((BegindateTime != "") && (Days != "")) {
            var i_Days = parseInt(Days);
            var i_Days1 = parseInt(Days) + 2;

            document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value = addTime(i_Days, v_row);
            document.getElementById("GridView1_ctl" + v_row + "_Tbx_FBeginTime").value = addTime(2, v_row);
            document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value = addTime(i_Days1, v_row);
        }

    }

    //改变日期
    function Keap2(ipt) {
        var trs = document.getElementById("GridView1");
        var pipt = ipt.parentNode.parentNode;
        var i_row = pipt.rowIndex;
        var i_rows = parseInt(i_row) + 1;
        var v_row = i_rows;
        if (v_row.toString().length == 1) {
            v_row = "0" + i_rows;
        }
        var i_rows = trs.rows.length;
        var EndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value;
        var FEndateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value;
        var Days = document.getElementById("GridView1_ctl" + v_row + "_Tbx_Days").value;
        if ((EndateTime != "") && (Days != "")) {
            var i_Days = parseInt(Days);
            var i_Days1 = parseInt(Days);

            document.getElementById("GridView1_ctl" + v_row + "_Tbx_FEndTime").value = addTime1(i_Days1, v_row);
        }

    }

    function addTime1(Days, v_row) {
        var i_Day = parseInt(Days);
        var BegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_EndTime").value;
        var v_Time = BegindateTime.replace(/-/g, "/");
        var d_Date = new Date(v_Time);
        d_Date = d_Date.valueOf();
        d_Date = d_Date + i_Day * 24 * 60 * 60 * 1000;
        d_Date = new Date(d_Date);

        var y = d_Date.getFullYear();
        var m = d_Date.getMonth() + 1;
        var d = d_Date.getDate();
        if (m <= 9) m = "0" + m;
        if (d <= 9) d = "0" + d;
        var cdate = y + "-" + m + "-" + d;
        return cdate;
    }
    function addTime(Days, v_row) {
        var i_Day = parseInt(Days);
        var BegindateTime = document.getElementById("GridView1_ctl" + v_row + "_Tbx_BeginTime").value;
        var v_Time = BegindateTime.replace(/-/g, "/");
        var d_Date = new Date(v_Time);
        d_Date = d_Date.valueOf();
        d_Date = d_Date + i_Day * 24 * 60 * 60 * 1000;
        d_Date = new Date(d_Date);

        var y = d_Date.getFullYear();
        var m = d_Date.getMonth() + 1;
        var d = d_Date.getDate();
        if (m <= 9) m = "0" + m;
        if (d <= 9) d = "0" + d;
        var cdate = y + "-" + m + "-" + d;
        return cdate;
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>生产排成表 > <a class="hdrLink" href="Sc_Plan_Manage.aspx">生产排成表</a>
                </td>
            </tr>
            <tr>
                <td style="height: 10px"></td>
            </tr>
        </table>
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

                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
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
                                                        <td width="17%" height="25" align="right" class="dvtCellLabel">供应商:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <input type="hidden" name="SuppNoSelectValue" id="SuppNoSelectValue" runat="server" />
                                                            <asp:TextBox ID="SuppNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="48"></asp:TextBox>
                                                            <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetReturnValue_onclick()" />
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">客户:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_Customer" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%" height="25" align="right" class="dvtCellLabel">负责人:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_Batch">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" class="dvtCellLabel">产品型号:
                                                        </td>
                                                        <td width="33%" align="left" class="dvtCellInfo">
                                                            <asp:TextBox ID="SeachKey" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>
                                                            <asp:Button ID="Button4" runat="server" Text="产品筛选" class="crmbutton small save"
                                                                CausesValidation="false" OnClick="Button4_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="10%" height="25" align="right" class="dvtCellLabel">计划日期:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="Tbx_Stime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>
                                                            <font color="gray">（注意：生产排程为最新日期的全部OEM计划）</font>
                                                            <asp:Button ID="Btn_Sc" runat="server" Text="自动排序" class="crmbutton small save"
                                                                CausesValidation="false" OnClick="Btn_Sc_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="dvtCellInfo" colspan="4">明细:
                                                        <asp:Label runat="server" ID="Lbl_Details" ></asp:Label>
                                                        <cc1:MyGridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                            AutoGenerateColumns="False" CssClass="Custom_DgMain" Width="100%" PageSize="100" 
                                                            BorderColor="#4974C2" EmptyDataText="<div align=center><font color=red><br/><br/><B>没有找到相关生产排成表记录</B><br/><br/></font></div>">
                                                            <Columns>
                                                                <asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="left">
                                                                    <HeaderTemplate>
                                                                        <input type="CheckBox" onclick="selectAll(this)" checked />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="Chbk" runat="server" Checked></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="序号"  ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#Container.DataItemIndex+1%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="生产序号"  ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="Tbx_OrderNum" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                            OnBlur="this.className='detailedViewTextBox';" Width="40px" Text=' <%#OrderNo(DataBinder.Eval(Container.DataItem, "SCP_Order").ToString(),Convert.ToString(Container.DataItemIndex+1))%>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="客户" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    
                                                                    <ItemTemplate>
                                                                        <%#GetCustomer(DataBinder.Eval(Container.DataItem, "ContractNos").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="OEM订单号" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        
                                                        <a href="/Web/CG/Order/Knet_Procure_OpenBilling_View.aspx?ID=<%# DataBinder.Eval(Container.DataItem, "OrderNo") %>" target="_blank">
                                                            <%# DataBinder.Eval(Container.DataItem, "OrderNo") %></a>
                                                    
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="产品名称" SortExpression="OrderNo" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#base.Base_GetProductsEdition_Link(DataBinder.Eval(Container.DataItem, "ProductsBarCode").ToString())%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="计划下达日期" SortExpression="OrderDateTime" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# DateTime.Parse(DataBinder.Eval(Container.DataItem, "OrderDateTime").ToString()).ToShortDateString()%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="客户要求日期" SortExpression="OrderDateTime" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#DateTime.Parse(DataBinder.Eval(Container.DataItem, "OrderPreToDate").ToString()).ToShortDateString()%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="物料交货日期" SortExpression="OrderDateTime" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%#  DateTime.Parse(DataBinder.Eval(Container.DataItem, "MaxOrderPreToDate").ToString()).ToShortDateString()%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="预计开始日期" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_BeginTime" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                                            onFocus="WdatePicker()"  Text='<%# GetDate(DataBinder.Eval(Container.DataItem, "DID").ToString(),0)%>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_EndTime" runat="server" CssClass="Wdate" Width="100px" onFocus="WdatePicker();" onblur="Keap2(this);"
                                                                            Text='<%# GetDate(DataBinder.Eval(Container.DataItem, "DID").ToString(),1)%>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_DID" runat="server" CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "DID").ToString()%>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_SPDID" runat="server"  CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "SPD_ID").ToString()%>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_MaxOrderPreToDate" runat="server"  CssClass="Custom_Hidden" Text='<%# DataBinder.Eval(Container.DataItem, "MaxOrderPreToDate").ToString()%>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="预计结束日期" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="Tbx_FBeginTime" runat="server" CssClass="Custom_Hidden" Width="100px"
                                                                            onFocus="WdatePicker()" onblur='Keap1(this)' Text='<%# GetDate(DataBinder.Eval(Container.DataItem, "DID").ToString(),2)%>'></asp:TextBox>
                                                                        <asp:TextBox ID="Tbx_FEndTime" runat="server" CssClass="Wdate" Width="100px" onFocus="WdatePicker();Keap2(this)"
                                                                            Text='<%# GetDate(DataBinder.Eval(Container.DataItem, "DID").ToString(),3)%>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="订单数量" SortExpression="OrderAmount" HeaderStyle-Font-Size="12px"
                                                                    ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Left">
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "OrderAmount").ToString() %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="排产数量" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center">
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" ID="Tbx_Number" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                            OnBlur="this.className='detailedViewTextBox'" Width="80px" Text='<%# DataBinder.Eval(Container.DataItem, "wrkNumber").ToString()%>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="说明" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center"> 
                                                                    <ItemTemplate>
                                                                        <asp:TextBox runat="server" TextMode="MultiLine" ID="Tbx_Remarks" CssClass="detailedViewTextBox"
                                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                            Width="150px" Height="30px" Text='<%# GetDate(DataBinder.Eval(Container.DataItem, "DID").ToString(),4)%>'></asp:TextBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="状态" HeaderStyle-Font-Size="12px" ItemStyle-HorizontalAlign="Left"
                                                                    HeaderStyle-HorizontalAlign="center"> 
                                                                    <ItemTemplate>
                                                                        <%# GetState(DataBinder.Eval(Container.DataItem, "OrderNo").ToString()) %>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass='colHeader' />
                                                            <RowStyle CssClass='listTableRow' />
                                                            <AlternatingRowStyle BackColor="#E3EAF2" />
                                                            <PagerStyle CssClass='Custom_DgPage' />
                                                        </cc1:MyGridView>
                                                <asp:Button ID="Btn_SaveOrderNo" runat="server" Text="更新生产序号" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_SaveOrderNoClick" Style="width: 120px; height: 33px;" />
                                                        </td>
                                                    </tr>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">备注:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:TextBox ID="Tbx_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="600px" Height="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        
                        <asp:TextBox ID="Tbx_Tyoe" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
