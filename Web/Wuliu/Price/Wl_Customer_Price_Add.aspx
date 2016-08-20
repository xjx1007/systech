<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Wl_Customer_Price_Add.aspx.cs"
    Inherits="Wl_Customer_Price_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <title>物流报价添加</title>
    <script type="text/javascript">
        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");

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
        function btnGetSupp_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Common/SelectSuppliers.aspx?Type=128860698200781250", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('Tbx_SuppNo').value = ss[0];
                document.all('Tbx_SuppName').value = ss[1];
            }
            else {
                document.all('Tbx_SuppNo').value = "";
                document.all('Tbx_SuppName').value = "";
            }
        }

        function btnGetWuliuSupp_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Web/Common/SelectSuppliers.aspx?Type=128860697896406251", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                document.all('Tbx_WuliuSuppNo').value = ss[0];
                document.all('Tbx_WuliuSuppName').value = ss[1];
            }
            else {
                document.all('Tbx_WuliuSuppNo').value = "";
                document.all('Tbx_WuliuSuppName').value = "";
            }
        }
        function Change()
        {
            var LinkValue = document.all('Ddl_LinkMan').value;
            var response = Wl_Customer_Price_Add.GetAddress(LinkValue);
            document.all('Tbx_Address').value = response.value;
        }



        function Add() {
            var today, seconds, tempd;
            today = new Date();
            intSeconds = today.getSeconds();
                var i_num1 = parseInt(document.all('Tbx_Num').value);
                document.all('Tbx_Num').value = i_num1;
                var ss, s_Value, i_row;
                    i_row = myTable.rows.length;
                    var objRow = myTable.insertRow(i_row);

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"input\"  Name=\"Tbx_MinWeight_' + i_num1 + '\" >';
                    objCel.className = "ListHeadDetails";
            
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '&lt;Mx≤ ';
                    objCel.className = "ListHeadDetails";
                    
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"input\"  Name=\"Tbx_MaxWeight_' + i_num1 + '\">';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"input\"  Name=\"Tbx_Price_' + i_num1 + '\" >';
                    objCel.className = "ListHeadDetails";

                    i_row = i_row + 1;
                    document.all('Tbx_Num').value = parseInt(document.all('Tbx_Num').value) + 1;
        }
        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        }

    </script>
    <style type="text/css">
        .auto-style1 {
            text-align: left;
            border: 1px solid #DDDDDD;
            padding: 5px;
            background: #dddcdd url('../../../../themes/softed/images/inner.gif') repeat-x 50% bottom;
            color: #000000;
            height: 27px;
        }
    </style>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>物流管理 > <a class="hdrLink" href="PB_Basic_Express_List.aspx">物流单价添加</a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <asp:TextBox runat="server" ID="Tbx_URL" CssClass="Custom_Hidden"></asp:TextBox>
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
                                        <tr>
                                            <td colspan="4" class="auto-style1">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">编号：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Code" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">日期：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Stime" runat="server"
                                                    CssClass="Wdate" onClick="WdatePicker()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">供应商名称：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                <pc:PTextBox ID="Tbx_SuppName" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetSupp_onclick()" />
                                                            (<font color="red">*</font>)
                                                <pc:PTextBox ID="Tbx_SuppNo" runat="server"
                                                    CssClass="Custom_Hidden" >
                                                </pc:PTextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">物流供应商：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" >
                                                <pc:PTextBox ID="Tbx_WuliuSuppName" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetWuliuSupp_onclick()" />
                                                            (<font color="red">*</font>)
                                                <pc:PTextBox ID="Tbx_WuliuSuppNo" runat="server"
                                                    CssClass="Custom_Hidden" >
                                                </pc:PTextBox>
                                            </td>
                                            <td  class="dvtCellLabel" >责任人:</td>
                                            <td  class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_DutyPerson" CssClass="detailedViewTextBox" runat="server" Width="100px" OnChange="Change()" ></asp:DropDownList>
                                                            (<font color="red">*</font>)
                                            </td>
                                            
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">备注：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" colspan="3">
                                                <pc:PTextBox ID="Tbx_Remarks" runat="server"
                                                    TextMode="MultiLine" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="600px" Height="50px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        
                                                    <tr>
                                                        <td class="dvtCellLabel" align="right">文件：
                                                        </td>
                                                        <td align="left" class="dvtCellInfo" colspan="3">
                                                            <asp:Label runat="server" ID="Lbl_Upload"></asp:Label>
                                                            <input id="uploadFile" type="file" runat="server" />

                                                            <asp:Button
                                                                ID="save" runat="server" Text="上传" CssClass="crmbutton small save"
                                                                OnClick="save_Click" style="height: 26px; width: 70px" />
                                                        </td>
                                                    </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>明细信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" >
                                  <asp:TextBox ID="Tbx_Num" runat="Server" Text="2" CssClass="Custom_Hidden"></asp:TextBox>
                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                        class="crmTable" style="height: 28px">
                                        <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                    </table>
                                            </td>
                                        </tr>
                                                                       
                                            <tr>
                                                <td colspan="4" align="center" style="height: 30px">
                                                    <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                                        class="crmbutton small save" OnClick="Btn_Save_Click" Style="height: 30px; width: 70px" />
                                                    <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                        type="button" name="button" value="取 消" style="height: 30px; width: 70px">
                                                </td>
                                            </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>


    </form>
</body>
</html>
