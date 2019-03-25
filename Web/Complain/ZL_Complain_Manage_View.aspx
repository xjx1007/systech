<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZL_Complain_Manage_View.aspx.cs"
    Inherits="Web_ZL_Complain_Manage_View" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<%@ Register Src="../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
<%@ Register Src="../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
     <link rel="alternate icon" type="image/png" href="../../images/士腾.png"/>
    <title></title>
    <script type="text/javascript" src="../Js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                客户抱怨 > <a class="hdrLink" href="ZL_Complain_Manage_List.aspx">客户抱怨</a>
            </td>
            <td width="100%" nowrap>
                <asp:Label ID="Tbx_ID" runat="server" Style="display: none"></asp:Label>&nbsp;
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
                </div>
                <span class="lvtHeaderText">
                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
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
                                        客户抱怨信息
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
                                                        onclick="PageGo('ZL_Complain_Manage_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')"
                                                        name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share"
                                                        value="&nbsp;共享&nbsp;">&nbsp;
                                                    <input title="" class="crmbutton small edit" onclick="PageGo('ZL_Complain_Manage_List.aspx')"
                                                        type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;
                                                </td>
                                                <td align="right">
                                                    <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create"
                                                        onclick="PageGo('ZL_Complain_Manage_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"
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
                                            <tr>
                                                <td align="left" style="padding-left: 10px;">
                                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle" />
                                                    <a href="../CustomerContent/Xs_Sales_Content_Add.aspx?CustomerValue=<%=s_CustomerValue %>&LinkMan=<%=s_LinkMan %>&OppID=<%=s_OppID %>"
                                                        class="webMnu">创建联系记录</a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
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
                                                        单号:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_Code" AllowEmpty="true" ValidError="客户抱怨不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'"></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        投诉日期
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_Stime" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        投诉分类:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_Type"  runat="server" Width="100px">
                                                        </asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        紧急程度:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_HurryState"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="dvtCellLabel">
                                                        选择订单:
                                                    </td>
                                                    <td align="left" class="dvtCellInfo">
                                                        <input type="hidden" name="SalesOrderNoSelectValue" id="SalesOrderNoSelectValue"
                                                            runat="server" />
                                                        <asp:Label ID="SalesOrderNo" runat="server"  OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" MaxLength="48" Width="150px" AutoPostBack="True"></asp:Label>&nbsp;
                                                                                                        </td>
                                                    <td class="dvtCellLabel">
                                                        花费时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_TimeState"  runat="server"
                                                            Width="150px">
                                                        </asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" class="dvtCellLabel">
                                                        客户:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="Tbx_CustomerValue" id="Tbx_CustomerValue" runat="server"
                                                            style="width: 150px" />
                                                        <asp:Label ID="Tbx_CustomerName" runat="server"  ValidError="客户不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        联系人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_LinkMan"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="17%" class="dvtCellLabel">
                                                        产品:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <input type="hidden" name="Tbx_ProductsID" id="Tbx_ProductsID" runat="server" style="width: 150px" />
                                                        <asp:Label ID="Tbx_ProductsName" runat="server"  ValidError="客户不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></asp:Label>&nbsp;
                                                    </td>
                                                    <td width="17%" class="dvtCellLabel">
                                                        责任人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_DutyPerson"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D1 解决方式</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        领队：
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_D1LederID" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                        <asp:Label ID="Tbx_D1LederName" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="256px" Height="50px"></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        组员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label runat="server" ID="Tbx_D1Member" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                                        <asp:Label ID="Tbx_D1MemberName" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="271px" Height="50px"></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D2 问题描述</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        发现人:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D2Finder" runat="server"  ValidError="发现人不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        发现时间:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D2Time" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        涉及数量:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D2Number" runat="server"  ValidError="涉及数量不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        具体问题:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D2FRemarks" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="500px" Height="50px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D3 临时处置对策</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        问题产品状态:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D3QState" runat="server"   Width="178px"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        客户库存:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D3CustomerNumber" runat="server" 
                                                            
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        运输数量:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D3TravelNumber" runat="server"  ValidError="涉及数量不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        本公司成品:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D3CompyNumber" runat="server"  ValidError="涉及数量不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        相关材料:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D3MaterialDetails" runat="server"  ValidError="涉及数量不能为空"
                                                             OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="178px"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        完成时间:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D3Time" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        处置方式:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D3Cause" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="500px" Height="50px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D4 不良原因分析</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_D4Person"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D4Time" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D4Cause" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="500px" Height="50px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D5 改善对策</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_D5Person"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D5Time" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D5Cause" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="500px" Height="50px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D6 改善对策验证</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_D6Person"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D6Time" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D6Cause" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="500px" Height="50px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D7 预防再发生</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_D7Person"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D7Time" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D7Cause" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="500px" Height="50px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" class="detailedViewHeader">
                                                        <b>D8 结案</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        人员:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Ddl_D8Person"  runat="server"
                                                            Width="100px">
                                                        </asp:Label>&nbsp;
                                                        
                                                    </td>
                                                    <td class="dvtCellLabel">
                                                        日期:
                                                    </td>
                                                    <td class="dvtCellInfo">
                                                        <asp:Label ID="Tbx_D8Time" runat="server"
                                                            ></asp:Label>&nbsp;
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="dvtCellLabel">
                                                        原因分析:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:Label ID="Tbx_D8Cause" TextMode="MultiLine" runat="server" 
                                                            
                                                            Width="500px" Height="50px"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                            
                                                <tr>
                                                    <td colspan="4">
                                                        <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />
                                                    </td>
                                                </tr>
                                        </table>
            </td>
        </tr>
        </table> </td> </tr>
    </table>
    </td>
    <td valign="top">
        <img src="../../themes/softed/images/showPanelTopRight.gif">
    </td>
    </tr> </table>
    </form>
</body>
</html>
<%--收货单信息  结束--%>
