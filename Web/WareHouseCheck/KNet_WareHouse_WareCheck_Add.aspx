<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_WareHouse_WareCheck_Add.aspx.cs" Inherits="Web_WareHouseCheck_KNet_WareHouse_WareCheck_Add" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title></title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>

<script language="JAVASCRIPT">
    function btnGetProducts_onclick() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("SelectKNet_WareCheck_Ownall.aspx?sID=&HouseNo=" + document.all("HouseNo").value + "&sTime=" + document.all("ReceivDateTime").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=600px");
    
        if (tempd != undefined) {

            var ss, s_Value, i_row;

            ss = tempd.split("|");
            i_row = myTable.rows.length;
            s_ID = document.all("Xs_ProductsCode").value;
            var Num = document.all("Tbx_Num").value;
            for (var i = 0; i < ss.length - 1; i++) {
                s_Value = ss[i].split(",");
                var objRow = myTable.insertRow(i_row);
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="../../themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsName_' + parseInt(Num+i) + '\" value=' + s_Value[0] + '>' + s_Value[0];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode_' + parseInt(parseInt(Num) + parseInt(i)) + '\" value=' + s_Value[1] + '>' + s_Value[1];
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsPattern_' + parseInt(parseInt(Num) + parseInt(i)) + '\" value=' + s_Value[2] + '>' + s_Value[2];
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;" Name=\"Number_' + parseInt(parseInt(Num) + parseInt(i)) + '\" value=' + s_Value[3] + '>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;" Name=\"ZNumber_' + parseInt(parseInt(Num) + parseInt(i)) + '\" readonly value=' + s_Value[4] + '>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;" Name=\"DNumber_' + parseInt(parseInt(Num) + parseInt(i)) + '\" readonly value=' + parseInt(s_Value[4]) - parseInt(s_Value[3]) + '>';
                objCel.className = "dvtCellInfo";

                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Price_' + parseInt(parseInt(Num) + parseInt(i)) + '\" value=' + s_Value[5] + '>';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\"  Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Money_' + parseInt(parseInt(Num) + parseInt(i)) + '\" value=' + s_Value[7] + '>';
                objCel.className = "dvtCellInfo";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Remarks_' + parseInt(parseInt(Num) + parseInt(i)) + '\" value=' + s_Value[6] + ' >';
                objCel.className = "dvtCellInfo";
                i_row = i_row + 1;
                s_ID = s_ID + s_Value[1] + ",";
            }
            document.all("Tbx_Num").value = parseInt(Num) + ss.length - 1;
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
                <td style="height: 2px">
                </td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                    库存盘点 > <a class="hdrLink" href="KNet_WareHouse_WareCheck_Manage.aspx">库存盘点添加</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_SuppNo" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px">
                </td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top" style="width: 9px">
                    <img src="../../themes/softed/images/showPanelTopLeft.gif"></td>
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
                                            <td class="dvtTabCache" style="width: 10px" nowrap>
                                                &nbsp;</td>
                                            <td class="dvtSelectedCell" align="center" nowrap>
                                                库存盘点添加信息</td>
                                            <td class="dvtTabCache" style="width: 10px">
                                                &nbsp;</td>
                                            <td class="dvtTabCache" style="width: 100%">
                                                &nbsp;</td>
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
                                                            盘点单号:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox runat="server" ID="ReceivNo" Enabled="false" AllowEmpty="true" ValidError="库存盘点添加不能为空"
                                                                CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                        <td class="dvtCellLabel">
                                                            盘点日期:</td>
                                                        <td class="dvtCellInfo">
                                                            <pc:PTextBox ID="ReceivDateTime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"
                                                                AllowEmpty="false"></pc:PTextBox>
                                                            (<font color="red">*</font>)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">
                                                            仓库:</td>
                                                        <td class="dvtCellInfo" colspan="3">
                                                            <asp:DropDownList ID="HouseNo" runat="server" Width="150px">
                                                            </asp:DropDownList>(<font color="red">*</font>)<br />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="预入仓库不能为空"
                                                                ControlToValidate="HouseNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>描述信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">
                                                            备注:</td>
                                                        <td class="dvtCellInfo" colspan="4">
                                                            <asp:TextBox ID="ReceivRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                                OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                cols="90" Rows="8"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                
                                                <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                    class="crmTable" style="height: 28px">
                                                    <tr>
                                                        <td colspan="10" class="dvInnerHeader">
                                                            <b>产品详细信息</b>
                                                        </td>
                                                    </tr>
                                                    <!-- Header for the Product Details -->
                                                    <tr valign="top">
                                                        <td valign="top" class="ListHead" align="right" nowrap>
                                                            <b>工具</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>产品名称</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>产品编码</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>型号</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>当时库存</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>账面库存</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>调整数量</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>单价</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>调整金额</b></td>
                                                        <td class="ListHead" nowrap>
                                                            <b>备注</b></td>
                                                    </tr>
                                                    <%=s_MyTable_Detail %>
                                                </table>
                                                <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                                    <!-- Add Product Button -->
                                                    <tr>
                                                        <td colspan="3">
                                                            ①选择产品:
                                                            <input type="button" name="Button" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />
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
                                                    class="crmbutton small save" OnClick="Btn_SaveOnClick"  style="width: 55px;height: 33px;"/>
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px;height: 33px;" >
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                </tr>
                                </table>
                                </td>
                <td valign="top" style="width: 9px">
                    <img src="../../themes/softed/images/showPanelTopRight.gif"></td>
            </tr>
        </table>
    </form>
</body>
</html>
