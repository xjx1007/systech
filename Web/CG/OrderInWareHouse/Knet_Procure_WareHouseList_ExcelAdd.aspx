<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Knet_Procure_WareHouseList_ExcelAdd.aspx.cs"
    Inherits="Knet_Procure_WareHouseList_ExcelAdd" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.blue.css" type="text/css">
    <link rel="stylesheet" href="../../../themes/softed/buttons-min.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../../images/士腾.png"/>
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>采购入库 > <a class="hdrLink" href="Knet_Procure_WareHouseList_List.aspx">采购入库</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_SuppNo" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 2px"></td>
            </tr>
        </table>
        <table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
            <tr>
                <td valign="top" style="width: 9px">
                    <img src="../../../themes/softed/images/showPanelTopLeft.gif"></td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">
                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="80%" align="center" class="detail-panel-div" border="0" cellspacing="0" cellpadding="5">
                                        <asp:Panel ID="Pan_First" runat="server">
                                            <tr>
                                                <td height="50" align="left" class="detail-content-heading" valign="middle" colspan="2">导入采购入库</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" colspan="2">&nbsp;</td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="left" valign="top" style="padding-left: 40px;" colspan="2">
                                                    <br>
                                                    <span class="genHeaderGray">第一步(共三步):</span>&nbsp; 
					
                                                    <span class="genHeaderSmall">选择来源</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="padding-left: 40px;" colspan="2">ERP导入文件格式支持Excel2003(.xls)、Excel2007(.xlsx)和CSV(.csv)。如果导入的文件有格式(例如颜色、锁定、过滤或多个sheet)，ERP系统将不能识别，导入时会出现空白。如果遇到问题，请先用Excel打开文件，另存为CSV文件(逗号分隔)，关闭Excel，再打开CSV文件，另存为2003或2007的Excel文件即可清除文件格式。
					</td>
                                            </tr>
                                            <tr>
                                                <td width="25%" align="right" class="small" valign="top"><b>请选择要导入的Excel文件 : </b></td>
                                                <td width="75%" align="left" valign="top">
                                                    <input id="uploadFile" name="uploadFile" class="small/" type="file" size="40" runat="server">&nbsp;
                
                                                    <asp:CheckBox runat="server" ID="Chk_Title"  Checked/>有标题
                	<asp:CheckBox runat="server" ID="Chk_IsOVer" />覆盖重复记录
									</td>
                                            </tr>
                                            <tr>
                                                <td height="50" colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right">&nbsp;
                                                <br />
                                                    <asp:Button ID="Btn_Save" runat="server" Text="下一步" AccessKey="S" title="下一步"
                                                        class="pure-button pure-button-edit" OnClick="Btn_Save_Click" />
                                                    <input title="取消 [Alt+X]" accesskey="X" class="pure-button pure-button-cancel" onclick="window.history.back()"
                                                        type="button" name="button" value="取 消">
                                                </td>
                                            </tr>
                                            </asp:Panel>

                                        <asp:Panel ID="Pan_Second" runat="server">
                                            
                                                            <asp:Label runat="server" ID="Lbl_Upload"></asp:Label>
                                            <tr>
                                                <td height="50" align="left" class="detail-content-heading" valign="middle" colspan="2">导入客户</td>
                                            </tr>
                                            
                        <asp:TextBox runat="server" ID="Tbx_Num" Style="display:none" Text="0"></asp:TextBox>
                        <asp:TextBox runat="server" ID="Tbx_Code" Style="display:none"></asp:TextBox>
                                            <tr>
                                                <td align="left" valign="top" style="padding-left: 40px;" colspan="2">
                                                    <br>
                                                    <span class="genHeaderGray">第一步(共三步):</span>&nbsp; 
                                                    <span class="genHeaderSmall">采购入库 字段映射 </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="padding-left: 40px;" colspan="2">以下列表显示 采购入库 和其它信息. 请在下拉框中选择与标题列对应的ERP系统字段。
					</td>
                                            </tr>
                                            
                                            <tr>
                                                <td align="left" valign="top" colspan="2">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td align="left" valign="top" style="padding-left: 40px;" colspan="2">
                                                         <asp:DropDownList runat="server" ID="Ddl_Model" AutoPostBack="true" OnSelectedIndexChanged="Ddl_Model_SelectedIndexChanged"></asp:DropDownList><asp:LinkButton runat="server" ID="Lbl_Del" Text="删除" OnClick="Lbl_Del_Click"></asp:LinkButton>&nbsp;
                        <asp:TextBox runat="server" ID="Tbx_Model" Width="105px"></asp:TextBox>&nbsp;
                    <asp:LinkButton runat="server" ID="Lbl_Save" Text="保存" OnClick="Lbl_Save_Click"></asp:LinkButton>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td  colspan="2">
                                                    <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="right">&nbsp;
                                                <br />
                                                    <asp:Button ID="Button1" runat="server" Text="下一步" AccessKey="S" title="下一步"
                                                        class="pure-button pure-button-edit" OnClick="Btn_Save_Click" />
                                                    <asp:Button ID="Button2" runat="server" Text="导入" AccessKey="S" title="导入"
                                                        class="pure-button pure-button-edit" OnClick="Btn_Save_Click1" />
                                                    <input title="取消 [Alt+X]" accesskey="X" class="pure-button pure-button-cancel" onclick="window.history.back()"
                                                        type="button" name="button" value="取 消">
                                                </td>
                                            </tr>
                                            </asp:Panel>
                                    </table>
                                    <asp:TextBox runat="server" ID="Tbx_ExcelUrl" style='display:none'></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top" style="width: 9px">
                    <img src="../../../themes/softed/images/showPanelTopRight.gif" /></td>
            </tr>
        </table>
    </form>
</body>
</html>
