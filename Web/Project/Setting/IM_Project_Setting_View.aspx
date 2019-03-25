<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IM_Project_Setting_View.aspx.cs"
    Inherits="IM_Project_Setting_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<%@ register assembly="Container" namespace="HT.Control.WebControl" tagprefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <title>项目设置</title>
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
                工作台 > <a class="hdrLink" href="Pb_Basic_Notice_List.aspx">查看项目设置</a>
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
                <img src="../../../themes/softed/images/showPanelTopLeft.gif">
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
                                            项目设置信息
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
                                        <td>
                                             <table id="_ctl0_WorkForm_dlList" cellspacing="0" border="0" style="width:100%;border-collapse:collapse;">
	<tr>
		<td style="width:45%;">
            <div onclick="location.href='SettingItem.aspx?id=1'" style="cursor: pointer">
                <h5>
                    1.项目类型</h5>
                <p class="gray">
                    对您公司所从事的项目进行设置，如设计项目、开发项目、建筑项目等。</p>
            </div>
        </td><td style="width:45%;">
            <div onclick="location.href='SettingItem.aspx?id=2'" style="cursor: pointer">
                <h5>
                    2.项目类别</h5>
                <p class="gray">
                    对项目类别属性设置，系统默认有“一般项目、重要项目、重大项目、关键项目”。</p>
            </div>
        </td>
	</tr><tr>
		<td style="width:45%;">
            <div onclick="location.href='SettingItem.aspx?id=3'" style="cursor: pointer">
                <h5>
                    3.重要程度</h5>
                <p class="gray">
                    对项目重要程度设置，系统默认有“一般、重要、非常重要”。</p>
            </div>
        </td><td style="width:45%;">
            <div onclick="location.href='SettingItem.aspx?id=4'" style="cursor: pointer">
                <h5>
                    4.项目状态</h5>
                <p class="gray">
                    项目的执行状态，系统默认有“待启动（草稿）、待执行、执行中、已完成、已搁置、已取消”。</p>
            </div>
        </td>
	</tr><tr>
		<td style="width:45%;">
            <div onclick="location.href='SettingItem.aspx?id=5'" style="cursor: pointer">
                <h5>
                    5.假期类型</h5>
                <p class="gray">
                    项目执行工期的休息日设定值，支持单休、双休和日历日期。（日历日期支持自定义假期）。</p>
            </div>
        </td><td style="width:45%;">
            <div onclick="location.href='SettingItem.aspx?id=8'" style="cursor: pointer">
                <h5>
                    6.项目评分</h5>
                <p class="gray">
                    项目评分,对状态已完成项目进行评分。</p>
            </div>
        </td>
	</tr><tr>
		<td style="width:45%;">
            <div onclick="location.href='/OM/Common/BaseData/ClientSelfField.aspx?Kind=7'" style="cursor: pointer">
                <h5>
                    7.项目自定义字段</h5>
                <p class="gray">
                    项目管理可以增加的6个自定义字段，支持自定义“字符、数字、日期、下拉框、多选格式”的字段。</p>
            </div>
        </td><td style="width:45%;">
            <div onclick="location.href='/OM/PM/ProjectTemplateList.aspx'" style="cursor: pointer">
                <h5>
                    8.项目模板</h5>
                <p class="gray">
                    对经常使用的项目，可以将该项目的活动（项目执行步骤及任务）设置成模板，下次建立同样项目时，可以直接选用。也可以在建立新的项目时，将项目的活动（项目执行步骤及任务）保存成模板，即用即建，方便下次使用；</p>
            </div>
        </td>
	</tr><tr>
		<td style="width:45%;">
            <div onclick="location.href='/OM/common/basedata/holiday.aspx?from=pm'" style="cursor: pointer">
                <h5>
                    9.日历日期</h5>
                <p class="gray">
                    设置假日或工作日，项目工期计算时会按工作日和假日计算。</p>
            </div>
        </td><td style="width:45%;">
            <div onclick="location.href='/OM/Common/BaseData/ClientSelfField.aspx?Kind=27'" style="cursor: pointer">
                <h5>
                    10.项目子项自定义字段</h5>
                <p class="gray">
                    项目子项可以增加的6个自定义字段，支持自定义“字符、数字、日期、下拉框、多选格式”的字段。</p>
            </div>
        </td>
	</tr><tr>
		<td style="width:45%;">
            <div onclick="location.href='/OM/PM/SetupNotifyTypes.aspx'" style="cursor: pointer">
                <h5>
                    11.提醒方式设置</h5>
                <p class="gray">
                    设置项目提醒方式：即时消息、邮件、短信</p>
            </div>
        </td><td></td>
	</tr>
</table>

                    </div>
                    <div class="grid">
                        

                    </div>
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
                <img src="../../../themes/softed/images/showPanelTopRight.gif">
            </td>
        </tr>
    </table>
    </td>
    <td align="right" valign="top">
        <img src="../../../themes/softed/images/showPanelTopRight.gif" />
    </td>
    </tr> </table>
    </form>
</body>
</html>
