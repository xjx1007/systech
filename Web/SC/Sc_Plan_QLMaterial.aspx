<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Sc_Plan_QLMaterial.aspx.cs"
    Inherits="Sc_Plan_QLMaterial" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>缺料计划</title>
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
    <style type="text/css">
        a.x {
            color: black;
            text-align: center;
            text-decoration: none;
            padding: 5px;
            font-weight: bold;
        }

            a.x:hover {
                color: #333333;
                text-decoration: underline;
                font-weight: bold;
            }

        ul {
            color: black;
        }

        .drag_Element {
            position: relative;
            left: 0px;
            top: 0px;
            padding-left: 5px;
            padding-right: 5px;
            border: 0px dashed #CCCCCC;
            visibility: hidden;
        }`

        #Drag_content {
            position: absolute;
            left: 0px;
            top: 0px;
            padding-left: 5px;
            padding-right: 5px;
            background-color: #000066;
            color: #FFFFFF;
            border: 1px solid #CCCCCC;
            font-weight: bold;
            display: none;
        }
    </style>
    <script>
        var hideAll = false;
        var parentId = "";
        var parentName = "";
        var childId = "NULL";
        var childName = "NULL";
        function displayCoords(event) {
            var move_Element = document.getElementById('Drag_content').style;
            if (!event) {
                move_Element.left = e.pageX + 'px';
                move_Element.top = e.pageY + 10 + 'px';
            }
            else {
                move_Element.left = event.clientX + 'px';
                move_Element.top = event.clientY + 10 + 'px';
            }
        }

        function fnRevert(e) {
            if (e.button == 2) {
                document.getElementById('Drag_content').style.display = 'none';
                hideAll = false;
                parentId = "Head";
                parentName = "DEPARTMENTS";
                childId = "NULL";
                childName = "NULL";
            }
        }
        function fnVisible(Obj) {
            document.getElementById(Obj).style.visibility = 'visible';
        }

        function fnInVisible(Obj) {
            document.getElementById(Obj).style.visibility = 'hidden';
        }
        function showhide(argg, imgId) {
            var harray = argg.split(",");
            var harrlen = harray.length;
            var i;
            var img_dir = imgId + "_dir";
            for (i = 0; i < harrlen; i++) {
                var x = document.getElementById(harray[i]).style;
                if (x.display == "none") {
                    x.display = "block";
                    document.getElementById(imgId).src = "../../themes/softed/images/minus.gif";
                    document.getElementById(img_dir).src = "../../themes/softed/images/folderopen.gif";
                }
                else {
                    x.display = "none";
                    document.getElementById(imgId).src = "../../themes/softed/images/plus.gif";
                    document.getElementById(img_dir).src = "../../themes/softed/images/folder.gif";
                }
            }
        }


    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
        <div id="ssdd" style="padding: 1px">
        </div>

        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">

            <tr>
                <td>
                    <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                        <tr>
                            <td align="center" colspan="2">
                                <h3>杭州士腾科技有限公司<br />
                                    物料缺料明细</h3>
                            </td>
                        </tr>
                        <tr>
                            <td align="left"><asp:Label runat="server" ID="Lbl_House"></asp:Label>
                            </td>
                            <td align="right"><asp:Label runat="server" ID="Lbl_ProductsBarCode" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" valign="top">
                                <%=s_DivStyle %>
                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                <asp:TextBox runat="server" ID="Tbx_ProductsBarCode" CssClass="Custom_Hidden"></asp:TextBox>
                                <asp:TextBox runat="server" ID="Tbx_HouseNo" CssClass="Custom_Hidden"></asp:TextBox>
                            </td> 
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
