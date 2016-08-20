<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sc_Plan_Print.aspx.cs" Inherits="Sc_Plan_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <%@ Register Src="../Control/CommentList.ascx" TagName="CommentList" TagPrefix="uc1" %>
    <style type="text/css">
        TABLE.print {
            vertical-align: middle;
            BORDER-RIGHT: #000000 1px solid;
            BORDER-TOP: #000000 1px solid;
            BORDER-LEFT: #000000 1px solid;
            BORDER-BOTTOM: #000000 1px solid;
            BORDER-COLLAPSE: collapse;
        }

            TABLE.print TD {
                BORDER-RIGHT: #000000 1px solid;
                PADDING-RIGHT: 5px;
                BORDER-TOP: #000000 1px solid;
                PADDING-LEFT: 5px;
                FONT-SIZE: 15px;
                BORDER-LEFT: #000000 1px solid;
                LINE-HEIGHT: 20px;
                BORDER-BOTTOM: #000000 1px solid;
            }

            TABLE.print .right {
                TEXT-ALIGN: right;
            }

        TABLE.print1 {
            vertical-align: middle;
            BORDER-RIGHT: #000000 1px solid;
            BORDER-TOP: #000000 0px solid;
            BORDER-LEFT: #000000 1px solid;
            BORDER-BOTTOM: #000000 1px solid;
            BORDER-COLLAPSE: collapse;
        }

            TABLE.print1 TD {
                BORDER-RIGHT: #000000 1px solid;
                PADDING-RIGHT: 3px;
                BORDER-TOP: #000000 0px solid;
                PADDING-LEFT: 3px;
                FONT-SIZE: 12px;
                BORDER-LEFT: #000000 1px solid;
                LINE-HEIGHT: 20px;
                BORDER-BOTTOM: #000000 1px solid;
            }

            TABLE.print1 .right {
                TEXT-ALIGN: right;
            }

        .init_font {
            FONT-SIZE: 12px;
        }

        .table_1 {
            BORDER-RIGHT: #000000 0px solid;
            PADDING-RIGHT: 0px;
            BORDER-TOP: #000000 0px solid;
            PADDING-LEFT: 0px;
            FONT-SIZE: 13px;
            BORDER-LEFT: #000000 0px solid;
            LINE-HEIGHT: 20px;
            BORDER-BOTTOM: #000000 0px solid;
            padding-bottom: 0px;
        }

        .STYLE1 {
            font-family: "黑体";
            line-height: 30px;
            font-size: 20px;
        }
    </style>
    <title>查看生产计划</title>
    <script language="javascript" type="text/javascript">
        var LODOP; //声明为全局变量 
        function prn1_preview() {
            CreateOneFormPage();
            LODOP.PREVIEW();
        };
        function prn1_print() {
            CreateOneFormPage();
            LODOP.PRINT();
        };
        function prn1_printA() {
            CreateOneFormPage();
            LODOP.PRINTA();
        };
        function CreateOneFormPage() {
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("生产计划");
            LODOP.SET_PRINT_STYLE("FontSize", 18);
            LODOP.SET_PRINT_STYLE("Bold", 1);
            LODOP.ADD_PRINT_HTM(130, 0, "100%", "100%", document.getElementById("tMater").innerHTML);
        };
        function OutToFileMoreSheet() {
            LODOP = getLodop(document.getElementById('LODOP_OB'), document.getElementById('LODOP_EM'));
            LODOP.PRINT_INIT("");
            LODOP.ADD_PRINT_HTM(0, 0, "100%", "100%", document.documentElement.innerHTML);
            LODOP.SET_SAVE_MODE("PAGE_TYPE", 1);
            LODOP.SET_SAVE_MODE("centerHeader", "页眉");
            LODOP.SET_SAVE_MODE("centerFooter", "第&P页");
            LODOP.SET_SAVE_MODE("Caption", "生产计划");
            LODOP.SET_SAVE_MODE("RETURN_FILE_NAME", 1);
            LODOP.SAVE_TO_FILE("生产计划.xls");
        };
    </script>
    <script language="javascript" src="../Js/LodopFuncs.js"></script>
    <object id="LODOP_OB" classid="clsid:2105C259-1E0C-4534-8141-A753534CB4CA" width="0" height="0">
        <embed id="LODOP_EM" type="application/x-print-lodop" width="0" height="0" pluginspage="install_lodop.exe"></embed>
    </object>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                <div style="text-align: center">
                    <asp:Image runat="server" ID="Imag_Load" ImageUrl="../images/loading.gif" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div id="tMater">
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="ke-zeroborder"
                        width="100%">
                        <tr>
                            <td width="100%">
                                <div align="center">
                                    <font style="FONT-SIZE: 30px"><strong>杭州士腾科技有限公司<br>
                                        生产计划</strong></font></div>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div id="zoom" class="init_font">
                        <table id="table_1" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                            style="font-size: 15pt; font-family: 黑体" width="90%">
                             <tr>
                                <td align="left"> <asp:Button ID="Btn_Save" runat="server" Text="发送消息" AccessKey="S" title="发送消息 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_SaveOnClick" Style="width: 100px; height: 33px;" />
                                             </td>
                                <td align="right"></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    <asp:Label runat="server" ID="Lbl_SuppNo"></asp:Label></td>
                                <td align="right">发布人:<asp:Label runat="server" ID="Lbl_Person"></asp:Label>&nbsp;
                        发布时间：
                    <asp:Label runat="server" ID="Lbl_CTimes"></asp:Label></td>
                            </tr>
                        </table>

                        <%=s_MyTable_Detail %>
                        <table id="table_1" align="center" border="0" cellpadding="0" cellspacing="0" class="table_1 ke-zeroborder"
                            style="font-size: 15pt; font-family: 黑体" width="90%">
                            <tr>
                                <td>
                                    <uc1:CommentList ID="CommentList1" runat="server" CommentFID="0" CommentType="-1" />
                                </td>
                            </tr>
                        </table>
                        <table align="center" border="0" cellpadding="0" cellspacing="0" class="ke-zeroborder"
                            width="100%">
                            <tr>
                                <td width="100%">
                                    <div align="center" style="height: 50px">
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox runat="server" ID="Tbx_Title" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox runat="server" ID="Tbx_HouseNo" CssClass="Custom_Hidden"></asp:TextBox>
                    </div>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>

</body>
</html>
