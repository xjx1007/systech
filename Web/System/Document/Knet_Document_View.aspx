<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false" CodeFile="Knet_Document_View.aspx.cs"
    Inherits="Knet_Web_System_Knet_Document_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../../themes/softed/style.css" type="text/css">
    <link rel="alternate icon" type="image/png" href="../../../images/士腾.png" />
    <script type="text/javascript" src="../../Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="../../DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../../include/scriptaculous/dom-drag.js"></script>

    <title>查看文档</title>

    <style type="text/css">
        .Div11 {
            background-image: url(/Web/images/KbottonB.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }

        .Div22 {
            background-image: url(/Web/images/KbottonA.gif);
            background-repeat: no-repeat;
            z-index: 0px;
            padding-top: 3px;
        }
    </style>


    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick()  
        {   
            /*选择产品*/
            var today,seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            var temp= window.showModalDialog("SelectDocument.aspx","","dialogtop=150px;dialogleft=160px; dialogwidth=750px;dialogHeight=500px");
    
            if(temp!=undefined)   
            {   
                var ss;
                ss=temp.split("#");
                document.all('tbx_FaterId').value = ss[0];
                document.all('Tbx_FaterName').value =ss[1];
            }   
            else
            {
                document.all('tbx_FaterId').value = ""; 
                document.all('Tbx_FaterName').value = ""; 
            }
        }
        function Chang()
        {
            var s_Name= document.all('Tbx_Name').value;
            var response=Knet_Web_System_Knet_Document_Add.GetCode(s_Name);
            document.all('Tbx_Visio').value=response.value;
        
        }
    </script>
</head>

<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>文档中心 > <a class="hdrLink" href="Knet_Document_List.aspx">文档中心</a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif"></td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span>
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
                                            <td class="dvtUnSelectedCell" align="center" nowrap>
                                                <a href="#">相关信息</a></td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;</td>
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
                                                            <input title="编辑 [Alt+E]" type="button" accesskey="E" class="crmbutton small edit" onclick="PageGo('Knet_Procure_Suppliers_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    ')" name="Edit" value="&nbsp;编辑&nbsp;">&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;">&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('Knet_Procure_Suppliers_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;">&nbsp;</td>
                                                        <td align="right">
                                                            <input title="复制 [Alt+U]" type="button" accesskey="U" class="crmbutton small create" onclick="PageGo('Knet_Procure_Suppliers_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>    &Type=1')" name="Duplicate" value="复制">&nbsp;
                                    <input title="刪除 [Alt+D]" type="button" accesskey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="22%" valign="top" style="border-left: 2px dashed #cccccc; padding: 13px" rowspan="2">
                                                <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                                    <tr>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" class="genHeaderSmall">操作</td>
                                                    </tr>
                                                    <!-- Module based actions starts -->

                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                                    <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>基本信息</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">文档编号:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Code"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">文档名称:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Name"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">文档类型:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Type"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">负责人:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_DutyPerson"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">版本号:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Visio"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">上级文档:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_FaterName"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="dvtCellLabel">文档路径:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Spce"></asp:Label>&nbsp;
                                                        </td>
                                                        <td class="dvtCellLabel">文档内容:</td>
                                                        <td class="dvtCellInfo">
                                                            <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                                                                        <tr>
                                                        <td colspan="4" class="detailedViewHeader"><b>下级文档</b>
                                                        </td>
                                                    </tr>

                                                    <%=s_NextDocumentHtml %>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif"></td>

            </tr>
        </table>
    </form>
</body>
</html>
