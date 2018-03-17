<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZL_Complain_Manage_Add.aspx.cs"
    Inherits="Web_Sales_ZL_Complain_Manage_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="stylesheet" href="../../css/common.css" />
    <title>客户抱怨</title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script src="../js/jQuery.js" type="text/javascript"></script>
    <script src="../js/Global.js" type="text/javascript"></script>
    <script type="text/javascript">
    
     function btnGetReturnOrderValue_onclick()  
    { 
       var today,seconds;
       today = new Date();
       intSeconds = today.getSeconds();
       var temp= window.showModalDialog("../Common/SelectSalesContractList.aspx","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=550px");
           if(temp!=undefined)   
           {   
              	 var ss;
		         ss=temp.split("|");
		         
                 document.all('SalesOrderNoSelectValue').value = ss[0];
                 document.all('SalesOrderNo').value =ss[1];
                 
            }   
           else
            {
                 document.all('SalesOrderNoSelectValue').value = ""; 
                 document.all('SalesOrderNo').value = ""; 
            }
    }
    function btnGetPerson_onclick() {
        var today, seconds;
        today = new Date();
        var v_Receive = document.all('Tbx_D1LederID').value;
        var v_ReceiveName = document.all('Tbx_D1LederName').value;
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("../Common/SelectDeptPerson.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        if (temp == undefined) {
            temp = window.returnValue;
        }
        if (temp != undefined) {
            var ss, s_Receive;
            ss = temp.split("|");
            s_Receive = ss[0].split(",");
            s_ReceiveName = ss[1].split(",");
            for (var i = 0; i < s_Receive.length; i++) {
                if (v_Receive.indexOf(s_Receive[i]) < 0) {
                    v_Receive = v_Receive + "," + s_Receive[i];
                    v_ReceiveName = v_ReceiveName + "," + s_ReceiveName[i];
                }
            }
            if (v_Receive.substring(0, 1) == ",") {
                document.all('Tbx_D1LederID').value = v_Receive.substring(1, v_Receive.length);
                document.all('Tbx_D1LederName').value = v_ReceiveName.substring(1, v_ReceiveName.length);
            }
            else {
                document.all('Tbx_D1LederID').value = v_Receive;
                document.all('Tbx_D1LederName').value = v_ReceiveName;
            }

        }
        else {
            document.all('Tbx_D1LederID').value = "";
            document.all('Tbx_D1LederName').value = "";
        }
    }

    function btnGetPerson1_onclick() {
        var today, seconds;
        today = new Date();
        var v_Receive = document.all('Tbx_D1Member').value;
        var v_ReceiveName = document.all('Tbx_D1MemberName').value;
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("../Common/SelectDeptPerson.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        if (temp == undefined) {
            temp = window.returnValue;
        }
        if (temp != undefined) {
            var ss, s_Receive;
            ss = temp.split("|");
            s_Receive = ss[0].split(",");
            s_ReceiveName = ss[1].split(",");
            for (var i = 0; i < s_Receive.length; i++) {
                if (v_Receive.indexOf(s_Receive[i]) < 0) {
                    v_Receive = v_Receive + "," + s_Receive[i];
                    v_ReceiveName = v_ReceiveName + "," + s_ReceiveName[i];
                }
            }
            if (v_Receive.substring(0, 1) == ",") {
                document.all('Tbx_D1Member').value = v_Receive.substring(1, v_Receive.length);
                document.all('Tbx_D1MemberName').value = v_ReceiveName.substring(1, v_ReceiveName.length);
            }
            else {
                document.all('Tbx_D1Member').value = v_Receive;
                document.all('Tbx_D1MemberName').value = v_ReceiveName;
            }

        }
        else {
            document.all('Tbx_D1Member').value = "";
            document.all('Tbx_D1MemberName').value = "";
        }
    }

        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

            if (tempd == undefined) {
                tempd = window.returnValue;
            }
            var sel = document.getElementById("Ddl_LinkMan");
            var length = sel.length;
            for (var i = length - 1; i >= 0; i--) {
                sel.remove(i);
            }
            var opt = new Option("", "");
            sel.options.add(opt);
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_CustomerValue').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
                var st, sw;
                st = ss[3].split("|");
                if (st.length > 0) {
                    for (var i = 0; i < st.length - 1; i++) {
                        sw = st[i].split(",");
                        var opt = new Option(sw[1], sw[0]);
                        sel.options.add(opt);
                    }

                }

            }
            else {
                document.all('Tbx_CustomerValue').value = "";
                document.all('Tbx_CustomerName').value = "";
                var length = sel.length;
                for (var i = length - 1; i >= 0; i--) {
                    sel.remove(i);
                }
            }
        }
         function btnGetProducts_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Products/SelectProductsDemo.aspx?CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                    var ss, s_Value, s_Name, i_row, s_ID;
                    ss = tempd.split(",");
                    document.all('Tbx_ProductsID').value = ss[0];
                    document.all('Tbx_ProductsName').value = ss[3].substring(0, ss[3].length-1);
                }
                else
                {
                    document.all('Tbx_ProductsID').value = "";
                    document.all('Tbx_ProductsName').value = "";
                }
        }
    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                客户抱怨 > <a class="hdrLink" href="ZL_Complain_Manage_List.aspx">客户抱怨</a>
            </td>
            <td width="100%" nowrap>
                <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
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
                                        客户抱怨信息
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
                                            <asp:Panel runat="server" ID="D0" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        单号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="true" ValidError="客户抱怨不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        投诉日期
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_Stime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        投诉分类:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_Type" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        紧急程度:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_HurryState" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="dvtCellLabel">
                                                        选择订单:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <input type="hidden" name="SalesOrderNoSelectValue" id="SalesOrderNoSelectValue"
                                                            runat="server" />
                                                        <asp:TextBox ID="SalesOrderNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" MaxLength="48" Width="150px" AutoPostBack="True"></asp:TextBox>
                                                        <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnOrderValue_onclick()" />
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        花费时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_TimeState" CssClass="detailedViewTextBox" runat="server"
                                                            Width="150px">
                                                        </asp:DropDownList>
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
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                                        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        联系人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_LinkMan" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                        <a href="../Customer/KNet_Sales_LinkMan_Add.aspx" target="_blank">新增联系人</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" class="dvtCellLabel">
                                                        产品:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="Tbx_ProductsID" id="Tbx_ProductsID" runat="server" style="width: 150px" />
                                                        <pc:PTextBox ID="Tbx_ProductsName" runat="server"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                                        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetProducts_onclick()" />
                                                    </td>
                                                    <td width="17%" class="dvtCellLabel">
                                                        责任人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择负责人"
                                                            ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D1" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D1 解决方式</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        领队：
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox runat="server" ID="Tbx_D1LederID" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:TextBox ID="Tbx_D1LederName" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="256px" Height="50px"></asp:TextBox>
                                                        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetPerson_onclick()" />
                                                        (<font color="red">*</font>)
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        组员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox runat="server" ID="Tbx_D1Member" CssClass="Custom_Hidden"></asp:TextBox>
                                                        <asp:TextBox ID="Tbx_D1MemberName" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="271px" Height="50px"></asp:TextBox>
                                                        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                            onclick="return btnGetPerson1_onclick()" />
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D2" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D2 问题描述</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发现人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D2Finder" runat="server" AllowEmpty="false" ValidError="发现人不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        发现时间:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <pc:PTextBox ID="Tbx_D2Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        涉及数量:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D2Number" runat="server" AllowEmpty="false" ValidError="涉及数量不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        具体问题:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="Tbx_D2FRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D3" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D3 临时处置对策</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        问题产品状态:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D3QState" runat="server" AllowEmpty="false" ValidError="发现人不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        客户库存:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <pc:PTextBox ID="Tbx_D3CustomerNumber" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        运输数量:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D3TravelNumber" runat="server" AllowEmpty="false" ValidError="涉及数量不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        本公司成品:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D3CompyNumber" runat="server" AllowEmpty="false" ValidError="涉及数量不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        相关材料:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D3MaterialDetails" runat="server" AllowEmpty="false" ValidError="涉及数量不能为空"
                                                            CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        完成时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D3Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        处置方式:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="Tbx_D3Cause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D4" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D4 不良原因分析</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_D4Person" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="请选择负责人"
                                                            ControlToValidate="Ddl_D4Person" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D4Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="Tbx_D4Cause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D5" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D5 改善对策</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_D5Person" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请选择负责人"
                                                            ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D5Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="Tbx_D5Cause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D6" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D6 改善对策验证</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_D6Person" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="请选择负责人"
                                                            ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D6Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="Tbx_D6Cause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D7" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D7 预防再发生</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_D7Person" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="请选择负责人"
                                                            ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D7Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="Tbx_D7Cause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="D8" Visible="false">
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D8 结案</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_D8Person" CssClass="detailedViewTextBox" runat="server"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="请选择负责人"
                                                            ControlToValidate="Ddl_DutyPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <pc:PTextBox ID="Tbx_D8Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                            AllowEmpty="false"></pc:PTextBox>
                                                        (<font color="red">*</font>)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:TextBox ID="Tbx_D8Cause" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="500px" Height="50px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </asp:Panel>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        &nbsp;
                                        <br />
                                        <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                            class="crmbutton small save" OnClick="Btn_SaveOnClick"  style="width: 55px;height: 33px;" />
                                        <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
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
