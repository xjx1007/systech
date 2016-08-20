<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pb_Products_Sample_Approval.aspx.cs" Inherits="Web_ProductsSample_Pb_Products_Sample_Approval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <title>样品申请审核</title>
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<script type="text/javascript">
    function btnGetReturnValue_onclick() {
        /*选择客户*/
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd = window.showModalDialog("../Common/SelectClientProductsList.aspx", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
        if (tempd != undefined) {
            var ss, s_Value, s_Name, i_row, sd;
            sd = tempd.split(",");
            document.all("Tbx_ProductsBarCode").value = sd[0];
            document.all("Tbx_ProductsName").value = sd[1];
            document.all("Tbx_ProductsEdition").value = sd[2];
        }
    }

    function btnGetSupp_onclick(i) {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var temp = window.showModalDialog("../Common/SelectSuppliers.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");

        if (temp != undefined) {
            var ss;
            ss = temp.split("|");
            document.all('SuppNo_' + i + '').value = ss[0];
            document.all('SuppName_' + i + '').value = ss[1];
        }
        else {
            document.all('SuppNo_' + i + '').value = "";
            document.all('SuppName_' + i + '').value = "";
        }
    }

    function btnGetBomProducts_onclick1() {
        var today, seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        v_newNum = $("Products_BomNum").value;
            var ss, s_Value, s_Name, i_row, s_ID;
            i_row = ProductsBomTable.rows.length;
            s_ID = document.all("Products_BomID").value + ",";
            ss = tempd.split("|");
            for (var i = 0; i < ss.length - 1; i++) {
                s_Value = ss[i].split(",");
                var objRow = ProductsBomTable.insertRow(i_row);
                v_newNum = parseInt(v_newNum) + i + 1;
                var objCel = objRow.insertCell();
                objCel.innerHTML = "<font color=green>&nbsp;</font>";
                objCel.className = "ListHeadDetails";
                var objCel = objRow.insertCell();
                objCel.innerHTML = '&nbsp;';
                objCel.className = "ListHeadDetails";
                var objCel = objRow.insertCell();
                objCel.className = "ListHeadDetails";
                objCel.innerHTML = '<input type=input Name=\"DemoProdoctsBarCode_' + v_newNum + '\" style=\"display:none;\" value=' + s_Value[0] + ' >' + s_Value[1];
                var objCel = objRow.insertCell();
                objCel.className = "ListHeadDetails";
                objCel.innerHTML = s_Value[3];

                var objCel = objRow.insertCell();
                objCel.className = "ListHeadDetails";
                objCel.innerHTML = '<input type=input Name=\"DemoNumber_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;\" value=' + s_Value[2] + '  >'

                var objCel = objRow.insertCell();
                objCel.className = "ListHeadDetails";
                objCel.innerHTML = '<input type=input Name=\"DemoOrder_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;\" value=0 >'

                i_row = i_row + 1;
                s_ID = s_ID + s_Value[0] + ",";
            $("Products_BomID").value = s_ID;
            $("Products_BomNum").value = v_newNum;
        }
    }
</script>
<body>
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>样品申请确认 > <a class="hdrLink" href="Pb_Products_Sample_List.aspx">样品申请确认</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
                    <asp:TextBox runat="server" ID="Tbx_DutyPerson" CssClass="Custom_Hidden"></asp:TextBox>
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
                                        <td class="dvtSelectedCell" align="center" nowrap>样品申请确认信息
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
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>基本信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">样品单:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <a href="Pb_Products_Sample_View.aspx?ID=<%=s_ID %>" target="_blank">
                                                            <asp:Label runat="server" ID="Lbl_Code"></asp:Label></a>
                                                    </td>
                                                    <td class="dvtCellLabel">产品:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Lbl_Products"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">主题:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label runat="server" ID="Lbl_Tiltle"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                
                                <asp:Panel runat="server" ID="Pan_Details" Visible="false">
                                    <tr>
                                        <td colspan="4" class="detailedViewHeader">
                                            <b>产品信息</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="dvtCellInfo" colspan="4">
                                        <table id="Table2" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                            class="ListDetails" style="height: 28px">
                                            <!-- Header for the Product Details -->
                                            <tr valign="top">
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>产品</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>样品要求</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>产品参数</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>库存数量</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>未入库采购单</b>
                                                </td>
                                                <td class="ListHead" align="left" nowrap>
                                                    <b>处理方式</b>
                                                </td>
                                            </tr>
                                            <asp:Label runat="server" ID="Lbl_ProductsDetails"></asp:Label>
                                        </table>
                                    </td>
                                    </tr>
                                </asp:Panel>

                                                <tr>
                                                    <td class="detailedViewHeader" colspan="4">
                                                        <b>确认信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellInfo" colspan="4" width="100%">

                                                        <asp:Panel ID="Pan_Detail" runat="server" Width="100%">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                <tr>
                                                                    <td class="dvtCellInfo">
                                                                        <table id="Table1" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                            class="ListDetails" style="height: 28px">
                                                                            <tr valign="top">
                                                                                <td class="ListHead" align="left" nowrap>
                                                                                    <b>序号</b>
                                                                                </td>
                                                                                <td class="ListHead" align="left" nowrap>
                                                                                    <b>确认人</b>
                                                                                </td>
                                                                                <td class="ListHead" align="left" nowrap>
                                                                                    <b>确认日期</b>
                                                                                </td>
                                                                                <td class="ListHead" align="left" nowrap>
                                                                                    <b>备注</b>
                                                                                </td>
                                                                                <td class="ListHead" align="left" nowrap>
                                                                                    <b>名称</b>
                                                                                </td>
                                                                                <td class="ListHead" align="left" nowrap>
                                                                                    <b>状态</b>
                                                                                </td>
                                                                                <td class="ListHead" align="left" nowrap>
                                                                                    <b>图片</b>
                                                                                </td>
                                                                            </tr>
                                                                            <asp:Label runat="server" ID="Lbl_QrDetails"></asp:Label>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td class="dvtCellLabel">样品确认:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:DropDownList ID="Ddl_Type" runat="server">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请选择样品确认"
                                                        ControlToValidate="Ddl_Type" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="dvtCellLabel">确认日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:TextBox ID="Tbx_STime" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">确认人:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:DropDownList ID="Ddl_DutyPerson" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>

                                                <asp:Panel runat="server" ID="Pan_Produts">
                                                    <asp:TextBox ID="Tbx_num" Text="0" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                    <tr id="AddPic" runat="server">
                                                        <td class="dvtCellInfo" colspan="4">
                                                            <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                                class="ListDetails" style="height: 28px">

                                                                <!-- Header for the Product Details -->
                                                                <tr valign="top">
                                                                    <td valign="top" class="ListHead" align="left" nowrap>
                                                                        <b>工具</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>名称</b>
                                                                    </td>
                                                                    <td class="ListHead" align="left" nowrap>
                                                                        <b>资料</b>
                                                                    </td>
                                                                </tr>
                                                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">名称:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:DropDownList runat="server" ID="Tbx_PicName"></asp:DropDownList>
                                                        </td>
                                                        <td class="dvtCellLabel">上传:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <input id="uploadFile" type="file" runat="server" class="Boxx" size="30" />&nbsp;
                                        <input id="button" type="button" value="上传资料" runat="server" class="crmbutton small save" onserverclick="button_ServerClick"
                                            causesvalidation="false" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>产品信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">产品名称:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_ProductsBarCode" CssClass="Custom_Hidden" runat="server"></asp:TextBox>
                                                            <asp:TextBox ID="Tbx_ProductsName" runat="server"></asp:TextBox>
                                                            <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择"
                                                                onclick="return btnGetReturnValue_onclick()" />
                                                            <a href="../Products/KnetProductsSetting_Add.aspx?KSP_SampleId=<%=s_ID %>">创建产品</a>
                                                        </td>
                                                        <td class="dvtCellLabel">产品型号:
                                                        </td>
                                                        <td class="dvtCellInfo">
                                                            <asp:TextBox ID="Tbx_ProductsEdition" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>

                                                </asp:Panel>
                                                <asp:Panel runat="server" ID="Pan_Products">

                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader">
                                                            <b>产品BOM信息</b>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="left" class="dvtCellInfo" style="text-align: left" colspan="4">
                                                            <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                            <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="0" class="ListDetails"
                                                                cellspacing="0">
                                                                <tr id="tr3">
                                                                    <td align="center" class="ListHead">序号
                                                                    </td>
                                                                    <td align="center" class="ListHead">类别
                                                                    </td>
                                                                    <td align="center" class="ListHead">供应商
                                                                    </td>
                                                                    <td align="center" class="ListHead">规格
                                                                    </td>
                                                                    <td align="center" class="ListHead">数量
                                                                    </td>
                                                                    <td align="center" class="ListHead">参考价格
                                                                    </td>
                                                                    <td align="center" class="ListHead">备注
                                                                    </td>
                                                                </tr>
                                                                <%=s_ProductsTable_BomDetail %>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>描述信息</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">备注:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="4">
                                                        <asp:TextBox ID="Tbx_Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                            OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                            Width="300px" Height="40px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">&nbsp;
                            <br />
                                            <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 30px" />
                                            <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.close()"
                                                type="button" name="button" value="关 闭" style="width: 55px; height: 30px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" height="31px">&nbsp;
                            <br />
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
