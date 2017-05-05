<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cw_Account_Bill_Add.aspx.cs"
    Inherits="Cw_Account_Bill_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>发票管理</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        if (tempd != undefined) {
            var ss;
            ss = tempd.split("#");
            document.all('Tbx_CustomerValue').value = ss[0];
            document.all('Tbx_CustomerName').value = ss[1];
        }
        else {
            document.all('Tbx_CustomerValue').value = "";
            document.all('Tbx_CustomerName').value = "";
        }
    }

    function ChgDays() {
        var i_num1 = parseInt(document.all('i_Num').value);
        var v_Time1 = document.all('Tbx_Stime').value.replace(/-/g, "/");
        for (i = 0; i < i_num1; i++) {
            var i_Day = parseInt(document.all('D_OutDays_'+i+'').value);
            var d_Date = new Date(v_Time1);
            d_Date = d_Date.valueOf();
            d_Date = d_Date + i_Day * 24 * 60 * 60 * 1000;
            d_Date = new Date(d_Date);
            var y = d_Date.getFullYear();
            var m = d_Date.getMonth() + 1;
            var d = d_Date.getDate();
            if (m <= 9) m = "0" + m;
            if (d <= 9) d = "0" + d;
            var cdate = y + "-" + m + "-" + d;

            if (v_Time1 != cdate) {
                cdate = getFirstAndLastMonthDay(y, m);
            }
            document.all('D_OutTime_' + i + '').value = cdate;
        }
    }
    function getFirstAndLastMonthDay( year, month){    
                      var   firstdate = year + '-' + month + '-01';  
                       var  day = new Date(year,month,0);   
                       var lastdate = year + '-' + month + '-' + day.getDate();//获取当月最后一天日期    
          //给文本控件赋值。同下  
                       return firstdate;
                    }  

    function btnGetSuppValue_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        if (document.all('Tbx_CustomerValue').value == "") {
            alert("请选择客户！");
            return;
        }
        var temp = window.showModalDialog("../Common/SelectContractList.aspx?ID=" + intSeconds + "&CustomerValue=" + document.all('Tbx_CustomerValue').value + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1150px;dialogHeight=500px");

        if (temp != undefined) {
            var ss;
            ss = temp.split("|");
            document.all('Tbx_ContractNo').value = ss[0];
        }
        else {
            document.all('Tbx_ContractNo').value = "";
        }
    }

    function deleteRow(obj) {
        myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        ChangePrice()
    }

    function deleteRow1(obj) {
        myTable1.deleteRow(obj.parentElement.parentElement.rowIndex);
    }
    function ChangePrice() {
        var i_num1 = parseInt(document.all('Tbx_Num').value);
        var v_TotatNet = parseFloat(document.all('Tbx_Money').value);
        var v_Total = 0;
        for (i = 0; i < i_num1; i++) {
            var Total = 0;
            var Number = document.all("Number_" + i + "");
            var Price = document.all("Price_" + i + "");
            if ((Number != null) && (Price != null)) {
                Total = parseFloat(Number.value) * parseFloat(Price.value);
                if (i = i_num1 - 1) {
                    Total = parseFloat(v_TotatNet) - parseFloat(v_Total)
                }
                v_Total += Total;
                document.all("Money_" + i + "").value = Total.toFixed(2);
            }
        }
        document.all("Tbx_Money").value = v_Total;
    }

    function ChangePayMent() {
        var ReveiveID = document.all('Tbx_FID').value;
        var PayMent = document.all('Ddl_PayMent').value;
        var Money = document.all('Tbx_Money').value;
        var STime = document.all('Tbx_STime').value;
        var response = Cw_Account_Bill_Add.GetDetails(ReveiveID, PayMent, Money, STime);
        var ss;
        ss = response.value.split("$");
        document.all('i_Num').value = ss[0];
        document.getElementById("Lbl_Details").innerHTML=ss[1];
        document.all('Lbl_Details1').value = ss[1];
        ChangePrice();
        $("Tbx_BillNumber").focus();
    }
</script>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="ChangePayMent()">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                发票管理 > <a class="hdrLink" href="Cw_Account_Bill_List.aspx">发票管理</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                <asp:TextBox ID="Tbx_FID" runat="server" Style="display: none"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
        <tr>
            <td valign="top">
                <img src="../../themes/softed/images/showPanelTopLeft.gif">
            </td>
            <td class="showPanelBg" valign="top" width="100%">
                <div class="small" style="padding: 10px">
                </div>
                <span class="lvtHeaderText">
                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                <br>
                <hr noshade size="1">
                
                <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr valign="bottom">
                        <td style="height: 44px">
                            <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                <tr>
                                    <td class="dvtTabCache" style="width: 10px" nowrap>
                                        &nbsp;
                                    </td>
                                    <td class="dvtSelectedCell" align="center" nowrap>
                                        发票管理信息
                                    </td>
                                    <td class="dvtTabCache" style="width: 10px">
                                        &nbsp;
                                    </td>
                                    <td class="dvtTabCache" style="width: 100%">
                                        &nbsp;
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
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>基本信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    编号:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="false" ValidError="编号不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    开票内容:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Content" Text='' CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Width="150px"></pc:PTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="17%" class="dvtCellLabel">
                                                    客户:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                        style="width: 150px" />
                                                    <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" ReadOnly="true"></pc:PTextBox>
                                                    <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                </td>
                                                <td width="17%" height="25" align="right" class="dvtCellLabel">
                                                    合同编号:
                                                </td>
                                                <td align="left" class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_ContractNo" ReadOnly runat="server" CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Width="150px" MaxLength="48"></asp:TextBox>
                                                    <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetSuppValue_onclick()" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    付款方式:
                                                </td>
                                                <td class="dvtCellInfo" colspan="3">
                                                    <asp:DropDownList ID="Ddl_PayMent" CssClass="detailedViewTextBox" runat="server" onchange="ChangePayMent()"
                                                       >
                                                    </asp:DropDownList>
                                                    <asp:Label runat="server" ID="Lbl_PayMent"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    票据类型:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList ID="Ddl_BillType" CssClass="detailedViewTextBox" runat="server"
                                                        Width="100px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    开票日期:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker({onpicked: function(){ChgDays();} });" ></asp:TextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    责任人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <asp:DropDownList runat="server" ID="Ddl_DutyPerson">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人"
                                                        ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                </td>
                                                <td class="dvtCellLabel">
                                                    票据金额:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Money" AllowEmpty="false" ValidError="票据金额不能为空"
                                                        CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    发票号码:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_BillNumber" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="300px"  AllowEmpty="false" ValidError="发票号码"></pc:PTextBox>
                                                    (<font color="red">*</font>)
                                                </td>
                                                <td class="dvtCellLabel">
                                                    经手人:
                                                </td>
                                                <td class="dvtCellInfo">
                                                    <pc:PTextBox runat="server" ID="Tbx_Brokerage" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                        OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>帐期</b>
                                                </td>
                                            </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="i_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                        <div id="Lbl_Details"></div>
                                        <asp:TextBox runat="server" ID="Lbl_Details1" CssClass="Custom_Hidden"></asp:TextBox>
                                        <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                        </table>
                                    </td>
                                </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>描述信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="dvtCellLabel">
                                                    备注:
                                                </td>
                                                <td class="dvtCellInfo" colspan="4">
                                                    <asp:TextBox ID="Tbx_Remarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                        Width="300px" Height="40px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" class="detailedViewHeader">
                                                    <b>产品详细信息</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:TextBox runat="server" CssClass="Custom_Hidden" ID="Tbx_Num"></asp:TextBox>
                                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0"
                                                        class="ListDetails">
                                                        <tr valign="top">
                                                            <td align="left" class="ListHead" width="3%">
                                                                删除
                                                            </td>
                                                            <td align="left" class="ListHead">
                                                                合同编号
                                                            </td>
                                                            <td align="left" class="ListHead">
                                                                发货单号
                                                            </td>
                                                            <td align="left" class="ListHead">
                                                                产品
                                                            </td>
                                                            <td align="left" class="ListHead">
                                                                数量
                                                            </td>
                                                            <td align="left" class="ListHead">
                                                                单价
                                                            </td>
                                                            <td align="left" class="ListHead">
                                                                金额
                                                            </td>
                                                            <td align="left" class="ListHead">
                                                                备注
                                                            </td>
                                                        </tr>
                                                        <%=s_MyTable_Detail %>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input id="Button4" class="crmbutton small create" onclick="return btnGetShip_onclick()"
                                                        type="button" value="选择产品" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        &nbsp;
                                        <br />
                                        <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                            class="crmbutton small save" OnClick="Btn_SaveOnClick" style="width: 55px;height: 33px;"   />
                                        &nbsp;<input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                            type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
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
