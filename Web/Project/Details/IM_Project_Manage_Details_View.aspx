<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IM_Project_Manage_Details_View.aspx.cs"
    Inherits="Pb_Project_Manage_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ register assembly="Container" namespace="HT.Control.WebControl" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <title></title>
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>

</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                工作台 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">查看公告</a>
            </td>
            <td width="100%" nowrap>
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
                    <span class="lvtHeaderText">
                        <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                    <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
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
                                            公告信息
                                        </td>
                                        <td class="dvtTabCache" style="width: 10px">
                                            &nbsp;
                                        </td>
                                        <td class="dvtUnSelectedCell" align="center" nowrap>
                                            <a href="#">相关信息</a>
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
                                        <td valign="top" align="left">
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                <tr>
                                                    <td>
                                                        <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit"
                                                            onclick="PageGo('Pb_Project_Manage_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                            name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                        <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                            value="&nbsp;共享&nbsp;">&nbsp;
                                                        <input title="" class="crmbutton small edit" onclick="PageGo('Pb_Project_Manage_List.aspx')"
                                                            type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                            onclick="PageGo('Pb_Project_Manage_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
                                                            name="Duplicate" value="复制">&nbsp;
                                                        <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete"
                                                            onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px"
                                            rowspan="2">
                                            <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="genHeaderSmall">
                                                        操作
                                                    </td>
                                                </tr>
                                                <!-- Module based actions starts -->
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
                                                    <td height="304" align="right" valign="top">
                                                      
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
                                                <asp:Label ID="Tbx_Code" runat="server" 
                                                      ></asp:Label>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">产品类型：
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label ID="Tbx_Products" runat="server" 
                                                      ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">客户:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label ID="Tbx_CustomerName" runat="server" 
                                                      ></asp:Label>
                                                <asp:Label ID="Tbx_CustomerID" runat="server" CssClass="Custom_Hidden"></asp:Label>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">日期:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label ID="Tbx_Stime"  runat="server" ></asp:Label></td>
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
                                                <asp:Label runat="server" ID="Ddl_ProductsType"  >
                                                </asp:Label>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">操作模式:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label runat="server"  ID="Ddl_Model" >
                                                </asp:Label>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">软件需求:
                                            </td>
                                            <td class="dvtCellInfo" align="left">

                                                <asp:Label runat="server"  ID="Ddl_SoftNeed" >
                                                </asp:Label>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">按键自定义:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label runat="server"  ID="Ddl_KeyCustom" >
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">执行标准:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label runat="server"  ID="Ddl_Standards" >
                                                </asp:Label>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">其他说明:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label ID="Tbx_OtherRemarks" runat="server" 
                                                      ></asp:Label>
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
                                                <asp:Label runat="server"  ID="Ddl_Shape" >
                                                </asp:Label>
                                            </td>
                                            <td width="16%" align="right" class="dvtCellLabel">指示灯:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label runat="server"  ID="Ddl_Lamp" >
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" align="right" class="dvtCellLabel">液晶显示:
                                            </td>
                                            <td class="dvtCellInfo" align="left">
                                                <asp:Label runat="server"  ID="Ddl_Led" >
                                                </asp:Label>
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
                                                            <asp:Label ID="Tbx_Upper" runat="server" 
                                                                  ></asp:Label>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">下盖:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:Label ID="Tbx_Lower" runat="server" 
                                                                  ></asp:Label>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">电池盖:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:Label ID="Tbx_Battery" runat="server" 
                                                                 ></asp:Label>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">导电胶:

                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:Label ID="Tbx_Conductive" runat="server" 
                                                                  ></asp:Label>
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
                                                            <asp:Label ID="Tbx_KeyNumber" runat="server" 
                                                                  ></asp:Label>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">锅仔:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:Label ID="Tbx_Pot" runat="server" 
                                                                  ></asp:Label>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">背光:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:Label ID="Tbx_Backlight" runat="server" 
                                                                  ></asp:Label>
                                                        </td>
                                                        <td width="16%" align="right" class="dvtCellLabel">外观说明:
                                                        </td>
                                                        <td class="dvtCellInfo" align="left">
                                                            <asp:Label ID="Tbx_Description" runat="server" 
                                                                  ></asp:Label></td>
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
                                        <asp:Label runat="server"  ID="Ddl_HaveBattery" >
                                        </asp:Label>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">包装方式:
                                    </td>
                                    <td class="dvtCellInfo" align="left">

                                        <asp:Label runat="server"  ID="Ddl_Packing" >
                                        </asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">产品说明书:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <asp:Label runat="server"  ID="Ddl_ProductsDescription" >
                                        </asp:Label>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">保修卡:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <asp:Label runat="server"  ID="Ddl_Warranty" >
                                        </asp:Label>
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
                                        <asp:Label ID="Tbx_Price" runat="server" 
                                              ></asp:Label>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">预定交期:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <asp:Label ID="Tbx_NeedTime" runat="server" 
                                              ></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">生产数量:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        
                                        <asp:Label ID="Tbx_Neednumber" runat="server" 
                                              ></asp:Label>
                                    </td>
                                    <td width="16%" align="right" class="dvtCellLabel">专利申请:
                                    </td>
                                    <td class="dvtCellInfo" align="left">
                                        <asp:Label ID="Tbx_Application" runat="server" 
                                              ></asp:Label></td>
                                </tr>

                                <tr>
                                    <td width="16%" align="right" class="dvtCellLabel">其他要求:
                                    </td>
                                    <td class="dvtCellInfo" align="left" colspan="3">
                                        <asp:Label ID="Tbx_Remaks" TextMode="MultiLine" runat="server" 
                                              Height="30px" ></asp:Label>
                                    </td>
                                </tr>

                        </table>
                </td>
                </tr>
                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
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
    </td>
    <td align="right" valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif" />
    </td>
    </tr> </table>
    </form>
</body>
</html>
