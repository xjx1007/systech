<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_Suppliers_Add.aspx.cs" Inherits="Web_Sales_Knet_Procure_Suppliers_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>物流供应商</title>
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>
</head>

<script language="JAVASCRIPT">
    function btnGetReturnValue_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("../../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

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

    function searchFromSelect(str) {
        var o = document.getElementById("Drop_KD");
        if (o.tagName == "SELECT") {
            var opts = o.options;
            str = str ? str : event.srcElement.innerText;

            var tmp = '';
            var kCode = event.keyCode;

            if (str != "") {
                if (kCode == 33 || kCode == 38 || kCode == 35)//向上翻页，方向键，end
                {
                    o.selectedIndex = o.selectedIndex > 0 ? o.selectedIndex - 1 : 0;
                    if (kCode == 35) o.selectedIndex = opts.length - 1;
                    for (var i = o.selectedIndex; i >= 0; i--) {
                        tmp = opts(i % opts.length).text;
                        if (tmp.indexOf(str) >= 0) {
                            o.selectedIndex = i % opts.length;
                            return;
                        }
                    }
                }
                if (kCode == 34 || kCode == 40 || kCode == 36)//
                {
                    o.selectedIndex++;
                    if (kCode == 36) o.selectedIndex = opts.length - 1;
                }
                for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex) ; i++) {
                    tmp = opts(i % opts.length).text;
                    if (tmp.indexOf(str) >= 0) {
                        o.selectedIndex = i % opts.length;
                        return;
                    }
                }
                o.selectedIndex = 0;
            }
        }
    }
    function btnGetReturnValue_onclick1() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("../../CustomerContent/SelectSalesOpp.aspx?sID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        if (tempd == undefined) {
            tempd = window.returnValue;
        }

        if (tempd != undefined) {
            var ss;
            ss = tempd.split("#");
            document.all('Tbx_SalesChanceValue').value = ss[0];
            document.all('Tbx_SalesChanceName').value = ss[1];


        }
        else {
            document.all('Tbx_SalesChanceValue').value = "";
            document.all('Tbx_SalesChanceName').value = "";
        }
    }

    function btnGetProducts_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();

        var tempd = window.showModalDialog("SelectProducts.aspx?sID=" + document.all("Xs_ProductsCode").value + "&CustomerValue=" + document.all("Tbx_CustomerValue").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");

        if (tempd != undefined) {

            var ss, s_Value, i_row;

            ss = tempd.split("|");
            i_row = myTable.rows.length;
            s_ID = document.all("Xs_ProductsCode").value;

            for (var i = 0; i < ss.length - 1; i++) {
                s_Value = ss[i].split(",");

                var objRow = myTable.insertRow(i_row);

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsName\" value=' + s_Value[0] + '>' + s_Value[0];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode\" value=' + s_Value[1] + '>' + s_Value[1];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern\" value=' + s_Value[2] + '>' + s_Value[2];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;" Name=\"Number\" value=' + s_Value[3] + '>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Price\" value=' + s_Value[4] + '>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:70px;" Name=\"Precent\" value=100 >';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:70px;" Name=\"PrecentMoney\" value=' + s_Value[6] + '>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Remarks\" value=' + s_Value[5] + ' >';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Money\" value=' + s_Value[6] + ' >';
                objCel.className = "dvtCellInfo";
                i_row = i_row + 1;
                s_ID = s_ID + s_Value[1] + ",";
            }

            document.all("Xs_ProductsCode").value = s_ID;
        }
    }

    function deleteRow(obj) {
        myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
        var Values = document.getElementsByName("ProductsBarCode");
        var bm_num = "";
        for (i = 0; i < Values.length; i++) {
            bm_num += Values[i].value + ",";
        }
        document.all("Xs_ProductsCode").value = bm_num;
    }

</script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>供应商 > 
	<a class="hdrLink" href="Knet_Procure_Suppliers_List.aspx">供应商</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="SuppNo" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_LinkManID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>


        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif"></td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;</td>
                                            <td class="dvtSelectedCell" align="center" nowrap>供应商信息</td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;</td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;</td>
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
                                                        <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">供应商名称:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppName" AllowEmpty="false" ValidType="String" ValidError="供应商名称不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                            
                                                        </td>
                                                        <td class="dvtCellLabel">供应商简称:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="Tbx_SName" AllowEmpty="false" ValidType="String" ValidError="供应商简称不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">负责人:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_DutyPerson"></asp:DropDownList>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                        <td class="dvtCellLabel">供应商编号:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="Tbx_Code" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>

                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="dvtCellLabel">供应商字母:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppCode" AllowEmpty="true" ValidType="String" ValidError="供应商不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                        <td class="dvtCellLabel">公司网址:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppWeb" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="dvtCellLabel">供应商级别:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_Level"></asp:DropDownList>
                                                        </td>
                                                        <td class="dvtCellLabel">供应商类型:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Ddl_Type"></asp:DropDownList>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="dvtCellLabel">快递查询关联:</td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:DropDownList runat="server" ID="Drop_KD"></asp:DropDownList>
                                                            <input type="text" id="span" onkeyup='searchFromSelect(this.value)'
                                                                onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}' class="detailedViewTextBox"
                                                                style="width: 103px; height: 20; border: 1 solid #0000FF; overflow-y: auto"></input>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>账户信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">付款周期:</td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:DropDownList runat="server" ID="Tbx_Days" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">开户行账号:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppBankAccount" AllowEmpty="true" ValidError="开户行账号不能为空" Csslass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)

                                                        </td>
                                                        <td class="dvtCellLabel">开户行名称:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppBankName" AllowEmpty="true" ValidError="开户行名称不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>联系人信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">联系人:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppPeople" AllowEmpty="true" ValidError="联系人不能为空" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                        <td class="dvtCellLabel">联系手机:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppMobiTel" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">联系电话:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppPhone" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">传真号码:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppFax" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>地址信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">电子邮箱:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppEmail" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">所在地区:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList ID="sheng" runat="server" AutoPostBack="true" OnSelectedIndexChanged="sheng_SelectedIndexChanged"></asp:DropDownList>
                                                            <asp:DropDownList ID="city" runat="server"></asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">通信地址:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppAddress" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        </td>
                                                        <td class="dvtCellLabel">邮政编码:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="SuppZipCode" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>产能信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">日产能 :</td>
                                                        <td valign="top" class="dvtCellInfo" colspan="4">
                                                            <pc:PTextBox runat="server" ID="Tbx_ScNumber" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>描述信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">主营产品:</td>
                                                        <td class="dvtCellInfo" colspan="3">&nbsp;
                                          <asp:TextBox ID="SuppProducts" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" TextMode="MultiLine" Width="400px" Height="50px"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td class="dvtCellLabel">供应商简介:</td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:TextBox ID="Remarks" runat="server" Style="display: none;"></asp:TextBox>
                                                            <iframe src='../../eWebEditor/ewebeditor.htm?id=Remarks&style=coolblue' frameborder='0' scrolling='no' width='620' height='350'></iframe>
                                                        </td>
                                                    </tr>

                                                </table>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" align="center">&nbsp;
  <br />
                                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]" class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()" type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif"></td>

            </tr>
        </table>

    </form>
</body>
</html>
