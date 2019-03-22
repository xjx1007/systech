<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Submitted_Update_Product.aspx.cs" Inherits="Web_ProductSubmitted_Knet_Submitted_Update_Product" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript">
        function ChangPrice() {
            debugger;
            var num = document.all('count').value;
            for (var i = 0; i < num; i++) {
                var str = "";
                if (document
                    .all("KPD_BadNumber_" + i)
                    .value ==
                    "0" &&
                    document.all("KPD_CheckNumber_" + i).value == "0") {
                    str = "0%";
                    document.all("KPD_RejectRatio_" + i).value = str;
                } else {
                    str = ((document.all("KPD_BadNumber_" + i).value / document.all("KPD_CheckNumber_" + i).value).toFixed(4)) * 100;
                    document.all("KPD_RejectRatio_" + i).value = str + "%";
                }


            }
        }
    </script>

    <title runat="server" id="titl">IQC检测信息</title>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>IQC检测 > <a class="hdrLink" runat="server" id="tit" href="Knet_Submitted_Product_List.aspx">IQC检测信息</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="TextBox2" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="TextBox1" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="UploadUrl" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_ProductsBarCode" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="count" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_FaterBarCode" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Anomaly_Url" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Back_Url" runat="server" Style="display: none"></asp:TextBox>
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
                                            <td class="dvtSelectedCell" align="center" nowrap>IQC检测信息
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
                                                <asp:Button ID="Button1" runat="server" class="crmbutton small edit" Text="审核" OnClick="Button1_OnClick" />&nbsp;   
                                                <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Submitted_Product_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" />&nbsp;
                                                   <asp:Button ID="btn_Chcek" runat="server" class="crmbutton small cancel" Text="特采审核" OnClick="btn_Chcek_OnClick" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="Button4" runat="server" class="crmbutton small edit" Text="创建入库" OnClick="Button4_OnClick" />
                                            </td>


                                        </tr>
                                    </table>
                                </td>



                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="10" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="dvtCellLabel">送检单号:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_SID" ReadOnly="True" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="dvtCellLabel">采购单号:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_Order" ReadOnly="True" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="dvtCellLabel">送检日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="KSP_Time" runat="server" ReadOnly="True" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="送检日期非空"
                                                    ControlToValidate="KSP_Time" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">检验日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="KSP_Stime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="送检日期非空"
                                                    ControlToValidate="KSP_Stime" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;送检仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_HouseNo" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_HouseName" ReadOnly="True" runat="server"></asp:TextBox>
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;供应商:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_SuppNo" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_Persser" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_SuppName" ReadOnly="True" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;送检级别:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="BuyRank" ReadOnly="True" runat="server"></asp:DropDownList>
                                            </td>
                                            <td class="dvtCellLabel">&nbsp;评分:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="KSP_Prant" runat="server"></asp:DropDownList>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td class="dvtCellLabel" align="right">上传文件：
                                            </td>

                                            <td class="dvtCellInfo">
                                                <asp:Label runat="server" ID="Lbl_Details1"></asp:Label><input id="uploadFile2"
                                                    type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="button3" type="button"
                                                        value="上传" runat="server" onserverclick="button3_OnServerClick" class="crmbutton small save" causesvalidation="false" />

                                            </td>
                                            <td class="dvtCellLabel">异常通知文件:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:Label runat="server" ID="Anomaly"></asp:Label><input id="File_Anomaly"
                                                    type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="Btn_Anomaly" type="button"
                                                        value="上传" runat="server" onserverclick="Btn_Anomaly_OnServerClick" class="crmbutton small save" causesvalidation="false" />

                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="dvtCellLabel" align="right">供应商回传文件：
                                            </td>

                                            <td class="dvtCellInfo">
                                                <asp:Label runat="server" ID="Back"></asp:Label><input id="File_Back"
                                                    type="file" runat="server" class="detailedViewTextBox" style="width: 250px" />&nbsp;<input id="Btn_Back" type="button"
                                                        value="上传" runat="server" onserverclick="Btn_Back_OnServerClick" class="crmbutton small save" causesvalidation="false" />

                                            </td>
                                            <td class="dvtCellLabel">备注说明:
                                            </td>
                                            <td class="dvtCellInfo" colspan="3">
                                                <asp:TextBox ID="Remark" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    Width="400px" Height="40px"></asp:TextBox><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                        runat="server" ControlToValidate="Remark" ValidationExpression="^(\s|\S){0,500}$"
                                                        ErrorMessage="备注说明太多，限少于500个字." Display="dynamic"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                    </table>


                                    <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                    <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>


                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                    <tr>
                                        <td colspan="12" class="detailedViewHeader">
                                            <b>基本信息</b>
                                        </td>
                                    </tr>
                                    <tr valign="top">
                                        <td class="ListHead" nowrap>
                                            <b>序号</b><input type="CheckBox" onclick="selectAllPage(this)" checked></td>
                                        <%--<td class="ListHead" nowrap>
                                                <input type="CheckBox" onclick="selectAllPage(this)" checked>
                                                <b>类别</b></td>--%>
                                        <td class="ListHead" nowrap>
                                            <b>料号</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>物料名称</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>品牌</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>规格型号</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>送检数量</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>抽检数量</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>不良数量</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>不良率</b></td>
                                        <td class="ListHead" nowrap>
                                            <b>检验结果</b></td>

                                        <td class="ListHead" nowrap>
                                            <b>备注</b></td>


                                    </tr>
                                    <asp:Label runat="server" ID="Lbl_SDetail"></asp:Label>
                                </table>

                            </tr>

                            <tr>
                                <td align="center" style="height: 30px" colspan="2">
                                    <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                        class="crmbutton small save" OnClick="Btn_Save_OnClick" Style="width: 55px; height: 30px;" />
                                    <asp:Button ID="Button2" runat="server" Text="取消" AccessKey="S" title="取消 [Alt+S]"
                                        class="crmbutton small save" OnClick="Button2_OnClick" Style="width: 55px; height: 30px;" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>

        </table>


    </form>
</body>
</html>
