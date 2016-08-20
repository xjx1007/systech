<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Pb_Products_Project_Add.aspx.cs"
    Inherits="Pb_Project_Manage_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <title>项目</title>
    <script language="JAVASCRIPT">

        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var tempd = window.showModalDialog("../Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                document.all('Tbx_CustomerID').value = ss[0];
                document.all('Tbx_CustomerName').value = ss[1];
                }
                else {
                   
                    }
            }
    </script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>研发 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">项目</a>
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
                    <img src="../../themes/softed/images/showPanelTopLeft.gif">
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
                                            <td class="dvtSelectedCell" align="center" nowrap>项目
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                            <tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">编号：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                
                                                <pc:PTextBox ID="Tbx_Code" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox><font
                                                        color="red">*</font>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">产品类型：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Products" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox></td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">客户:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_CustomerName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />
                                                
                                                <pc:PTextBox ID="Tbx_CustomerID" runat="server" CssClass="Custom_Hidden"></pc:PTextBox>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">日期:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Stime" Width="180px" runat="server" CssClass="Wdate" onFocus="WdatePicker()"></pc:PTextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>技术要求</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">产品类型:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" ID="Ddl_ProductsType" Width="180px" class="detailedViewTextBox">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">操作模式:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" Width="180px" ID="Ddl_Model" class="detailedViewTextBox">
                                                </asp:DropDownList>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">软件需求:
                                            </td>
                                            <td class="dvtCellInfo" align="left">

                                                <asp:DropDownList runat="server" Width="180px" ID="Ddl_SoftNeed" class="detailedViewTextBox">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">按键自定义:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" Width="180px" ID="Ddl_KeyCustom" class="detailedViewTextBox">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">执行标准:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" Width="180px" ID="Ddl_Standards" class="detailedViewTextBox">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">其他说明:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_OtherRemarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>外观要求</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">外形:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" Width="180px" ID="Ddl_Shape" class="detailedViewTextBox">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">指示灯:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" Width="180px" ID="Ddl_Lamp" class="detailedViewTextBox">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">液晶显示:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:DropDownList runat="server" Width="180px" ID="Ddl_Led" class="detailedViewTextBox">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">颜色
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="16%" align="right" class="dvtCellLabel">上盖:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Upper" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">下盖:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Lower" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">电池盖:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Battery" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px"></pc:PTextBox>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">导电胶:

                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Conductive" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">按键
                                            </td>
                                        </tr>
                                        <tr>

                                            <td colspan="4">
                                                <table width="100%">
                                                    <tr>
                                                        <td width="16%" align="right" class="dvtCellLabel">数量:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_KeyNumber" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">锅仔:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Pot" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">背光:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Backlight" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">外观说明:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <pc:PTextBox ID="Tbx_Description" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox></td>
                                                    </tr>

                                    </table>
                                </td>
                                            
                                </tr>
                                <tr>
                                    <td colspan="4" class="detailedViewHeader">
                                        <b>包装说明</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">电池:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <asp:DropDownList runat="server" Width="180px" ID="Ddl_HaveBattery" class="detailedViewTextBox">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">包装方式:
                                    </td>
                                    <td class="dvtCellInfo" align="left">

                                        <asp:DropDownList runat="server" Width="180px" ID="Ddl_Packing" class="detailedViewTextBox">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">产品说明书:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <asp:DropDownList runat="server" Width="180px" ID="Ddl_ProductsDescription" class="detailedViewTextBox">
                                        </asp:DropDownList>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">保修卡:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <asp:DropDownList runat="server" Width="180px" ID="Ddl_Warranty" class="detailedViewTextBox">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="4" class="detailedViewHeader">
                                        <b>其他事项</b>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">目标价格:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <pc:PTextBox ID="Tbx_Price" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">预定交期:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <pc:PTextBox ID="Tbx_NeedTime" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">生产数量:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <pc:PTextBox ID="Tbx_Neednumber" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">专利申请:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <pc:PTextBox ID="Tbx_Application" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="180px" ValidType="String"></pc:PTextBox></td>
                                </tr>

                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">其他要求:
                                    </td>
                                    <td class="dvtCellInfo" align="left" colspan="3">
                                        <pc:PTextBox ID="Tbx_Remaks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                            OnBlur="this.className='detailedViewTextBox'" Width="180px" Height="30px" ValidType="String"></pc:PTextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="4" align="center" style="height: 30px">
                                        <asp:Button ID="Btn_Save" runat="server" Text="保存" AccessKey="S" title="保存 [Alt+S]"
                                            class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                        &nbsp;<input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                            type="button" name="button" value="取 消" style="width: 55px;height: 33px;" style="height: 30px; width: 70px">
                                    </td>
                                </tr>
                        </table>
                </td>
                </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                </td>
                <td align="right" valign="top">
                    <img src="../../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
