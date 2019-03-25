<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="Knet_Sales_Ship_Manage_Talks_Detail.aspx.cs" Inherits="Knet_Sales_Ship_Manage_Talks_Detail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Global.js"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script type="text/javascript">
        if(window != window.parent) 
        { var P = window.parent, D = P.loadinndlg(); }
`</script>
    <style>
        .ickd_return {
            font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            font-size: 1em;
            border: 1px solid #98bf21;
            padding: 3px 7px 2px 7px;
            text-align: left;
        }

        th {
            text-align: center;
            font-size: 1.1em;
            padding-top: 5px;
            padding-bottom: 4px;
            background-color: #A7C942;
            color: #ffffff;
        }

        tr.td {
            color: #000000;
            background-color: #EAF2D3;
        }
    </style>


    <title>发货跟踪明细</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div id="ListGo333">


            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="50%">
                        <asp:Label ID="Tbx_Return" runat="server"></asp:Label>
                        <asp:CheckBox runat="server" ID="Chk_Check" />签收
                    <asp:TextBox ID="Tbx_DirectOutNo" runat="server" Style="display: none"></asp:TextBox>

                    </td>
                    <td width="50%">
                                <asp:Button ID="Btn_Save" runat="server" Text="更新" AccessKey="S" title="更新 [Alt+S]"
                                    class="crmbutton small save" />
                    </td>
                </tr>
            </table>
            <!--内部结束-->


        </div>
    </form>
</body>
</html>
