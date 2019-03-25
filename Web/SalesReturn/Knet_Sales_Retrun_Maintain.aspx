<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Sales_Retrun_Maintain.aspx.cs" Inherits="Web_SalesReturn_Knet_Sales_Retrun_Maintain" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <link rel="stylesheet" href="../../css/common.css" />
    <title>客户抱怨</title>
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script src="../js/jQuery.js" type="text/javascript"></script>
    <script src="../js/Global.js" type="text/javascript"></script>
    <script type="text/javascript">

        function btnGetReturnOrderValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("../Common/SelectSalesContractList.aspx", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=550px");
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");

                document.all('SalesOrderNoSelectValue').value = ss[0];
                document.all('SalesOrderNo').value = ss[1];

            }
            else {
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
        //function btnGetProducts_onclick() {
        //    debugger;
        //    var today, seconds;
        //    today = new Date();
        //    intSeconds = today.getSeconds();
        //    var tempd = window.open("../Products/SelectProductsDemo.aspx?CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        //    if (tempd != undefined) {
        //        var ss, s_Value, s_Name, i_row, s_ID;
        //        ss = tempd.split(",");
        //        document.all('Tbx_ProductsID').value = ss[0];
        //        document.all('Tbx_ProductsName').value = ss[3].substring(0, ss[3].length - 1);
        //    }
        //    else {
        //        document.all('Tbx_ProductsID').value = "";
        //        document.all('Tbx_ProductsName').value = "";
        //    }
        //}
        function btnGetProducts_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            v_newNum = $("Products_BomNum").value;
            //var tempd = window.showModalDialog("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("../Products/SelectProductsDemo.aspx?CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsDemo(tempd) {
            if (tempd != undefined) {
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsBomTable.rows.length;
                //s_ID = document.all("Products_BomID").value + ",";
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split("!");
                    var objRow = ProductsBomTable.insertRow(i_row);
                    //v_newNum = parseInt(v_newNum) + i + 1;
                    v_newNum1 = i;
                    //var objCel = objRow.insertCell();
                    //objCel.innerHTML = '&nbsp;<A onclick=\"deleteRow2(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    //objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ProdoctsBarCode_' + i + '\" style=\"display:none;\" value=' + s_Value[0] + ' >' + s_Value[0];


                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ProdoctName_' +
                        i.toString() +
                        '\"  ID=\"ProdoctName_' +
                        i.toString() +
                        '\"  style=\"detailedViewTextBox;width:100px\"  onblur=\"onPlaceblur()\"  value=' +
                        s_Value[1] +
                        ' >';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ProdctsEdition_' + i.toString() + '\"  ID=\"ProdctsEdition_' + i.toString() + '\"  style=\"detailedViewTextBox;width:100px\"    value=' + s_Value[3] + ' >';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"Remark_' +
                        i.toString() +
                        '\" style=\"detailedViewTextBox;width:300px\" value="" >';


                    i_row = i_row + 1;
                    //s_ID = s_ID + s_Value[0] + ",";
                }
                //$("Products_BomID").value = s_ID;
                //alert(v_newNum1);
                document.all('Tbx_Num').value = v_newNum1+1;
            }
        }
        //function deleteRow2(obj) {
        //    ProductsBomTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        //    var Values = document.getElementsByName("DemoProdoctsBarCode");
        //    var bm_num = "";
        //    for (i = 0; i < Values.length; i++) {
        //        bm_num += Values[i].value + ",";
        //    }
        //    document.all("Products_BomID").value = bm_num;
        //}

    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>客户抱怨 > <a class="hdrLink" href="ZL_Complain_Manage_List.aspx">客户抱怨</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
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
                                        <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                        </td>
                                        <td class="dvtSelectedCell" align="center" nowrap>客退维修信息
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
                            <td valign="top" align="left">
                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <tr>
                                        <td align="left">
                                            <%-- <input title="审核 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" runat="server" onserverclick="Edit_OnServerClick" name="Edit" value="&nbsp;审核&nbsp;" />&nbsp;--%>
                                            <asp:Button ID="Button2" runat="server" class="crmbutton small edit" Text="审核" OnClick="Button2_OnClick" />&nbsp; 
                                                <asp:Button ID="Button1" runat="server" class="crmbutton small edit" Text="报废处理" />&nbsp;   
                                               <%-- <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Submitted_Product_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" />&nbsp;
                                                   <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small cancel" Text="特采审核" OnClick="btn_Chcek_OnClick" />&nbsp;--%>
                                            <asp:Button ID="Button4" runat="server" class="crmbutton small edit" Text="对策验收" />

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
                                                        <td class="dvtCellLabel">单号:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="Tbx_Code" AllowEmpty="true" ValidError="客户抱怨不能为空"
                                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                        <td class="dvtCellLabel">投诉日期
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox ID="Tbx_Stime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                AllowEmpty="false"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">分类:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_Type" CssClass="detailedViewTextBox" runat="server" Width="100px">
                                                            </asp:DropDownList>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                        <td class="dvtCellLabel">紧急程度:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_HurryState" CssClass="detailedViewTextBox" runat="server"
                                                                Width="100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td width="17%" class="dvtCellLabel">客户:
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
                                                        <td class="dvtCellLabel">联系人:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="Ddl_LinkMan" CssClass="detailedViewTextBox" runat="server"
                                                                Width="100px">
                                                            </asp:DropDownList>
                                                            <a href="../Customer/KNet_Sales_LinkMan_Add.aspx" target="_blank">新增联系人</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                       <td align="right" class="dvtCellLabel">选择订单:
                                                        </td>
                                                        <td align="left" class="dvtCellInfo">
                                                            <input type="hidden" name="SalesOrderNoSelectValue" id="SalesOrderNoSelectValue"
                                                                runat="server" />
                                                            <asp:TextBox ID="SalesOrderNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" MaxLength="48" Width="150px" AutoPostBack="True"></asp:TextBox>
                                                            <img src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnOrderValue_onclick()" />
                                                        </td>
                                                        <td width="17%" class="dvtCellLabel">责任人:
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

                                                <asp:Panel runat="server" ID="D2" Visible="false">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>问题描述</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <%--  <td class="dvtCellLabel">发现人:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox ID="Tbx_D2Finder" runat="server" AllowEmpty="false" ValidError="发现人不能为空"
                                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                        </td>--%>
                                                        <td class="dvtCellLabel">发现时间:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox ID="Tbx_D2Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                AllowEmpty="false"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                        <td class="dvtCellLabel">涉及数量:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox ID="Tbx_D2Number" runat="server" AllowEmpty="false" ValidError="涉及数量不能为空"
                                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="178px"></pc:PTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>

                                                        <td class="dvtCellLabel">具体问题:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_D2FRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="500px" Height="50px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="D3" Visible="false">
                                               
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>维修对策</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel" align="right">上传文件：
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Details1"></asp:Label><input id="uploadFile2"
                                                                type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button3" type="button"
                                                                    value="上传" runat="server" class="crmbutton small save" onserverclick="button3_OnServerClick" causesvalidation="false" />

                                                        </td>
                                                        <td class="dvtCellLabel">完成时间:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox ID="Tbx_D3Time" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                AllowEmpty="false"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                    </tr>
                                            
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                        <tr>
                                                            <td colspan="8" class="detailedViewHeader">
                                                                <b>产品详细信息</b>
                                                            </td>
                                                        </tr>
                                                        <tr valign="top">
                                                            <td class="ListHead" width="20%" nowrap>
                                                                <b>产品名称</b>
                                                            </td>
                                                            <td class="ListHead" width="20%" nowrap>
                                                                <b>产品编码</b>
                                                            </td>
                                                            <td class="ListHead" width="20%" nowrap>
                                                                <b>版本号</b>
                                                            </td>
                                                            <td class="ListHead" width="10%" nowrap>
                                                                <b>退货数量</b>
                                                            </td>
                                                            <td class="ListHead" width="10%" nowrap>
                                                                <b>修好数量</b>
                                                            </td>
                                                            <td class="ListHead" width="10%" nowrap>
                                                                <b>报废数量</b>
                                                            </td>
                                                            <td class="ListHead" width="10%" nowrap>
                                                                <b>花费时间</b>
                                                            </td>
                                                            <td class="ListHead" width="30%" nowrap>
                                                                <b>备注</b>
                                                            </td>
                                                        </tr>
                                                       <%-- <%=s_MyTable_Detail %>--%>
                                                        <asp:Label runat="server" ID="Lbl_SDetail"></asp:Label>
                                                    </table>
                                                </asp:Panel>
                                                    
                                                <asp:Panel runat="server" ID="D4" Visible="false">
                                                
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>客诉对策</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel" align="right">上传文件：
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Label2"></asp:Label><input id="File2"
                                                                type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button5" type="button"
                                                                    value="上传" runat="server" class="crmbutton small save" onserverclick="button5_OnServerClick" causesvalidation="false" />

                                                        </td>
                                                        <td class="dvtCellLabel">完成时间:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox ID="PTextBox1" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                AllowEmpty="false"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">处置记录:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="TextBox1" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                Width="500px" Height="50px"></asp:TextBox>
                                                        </td>
                                                        <td class="dvtCellLabel" align="right">上传8D附件：
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Label3"></asp:Label><input id="File3"
                                                                type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button6" type="button"
                                                                    value="上传" runat="server" class="crmbutton small save" onserverclick="button6_OnServerClick" causesvalidation="false" />

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" align="left">
                                                             <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                            <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_Num" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                            <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="ListDetails" style="height: 28px">
                                                                <!-- Header for the Product Details -->
                                                                <tr valign="top">
                                                                   <%-- <td valign="top" class="ListHead" align="right" nowrap>
                                                                        <b>工具</b>
                                                                    </td>--%>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品编号</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品名称</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>产品型号</b>
                                                                    </td>
                                                                    <td class="ListHead" nowrap>
                                                                        <b>备注</b>
                                                                    </td>
                                                                </tr>
                                                                  <asp:Label runat="server" ID="Label_KReturn"></asp:Label>
                                                            </table>
                                                            <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                                                <!-- Add Product Button -->
                                                                <tr>
                                                                    <td colspan="3">①选择产品:
                                                        <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                     </asp:Panel>
                                                

                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">&nbsp;
                                        <br />
                                            <asp:TextBox ID="Suppno" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="ContractNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="ReturnNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="ProductCount" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="KSM_WUploadUrl" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="KSM_WUploadName" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="KSM_KUploadUrl" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="KSM_KUploadName" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="KSM_K8DUploadUrl" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <asp:TextBox ID="KSM_K8DUploadName" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
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
                </td>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
