<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PB_Basic_ProductsClass_List.aspx.cs"
    Inherits="PB_Basic_ProductsClass_List" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-/W3C/DTD XHTML 1.0 Transitional/EN" "http:/www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http:/www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title></title>
    <style type="text/css">
    a.x
    {
        color: black;
        text-align: center;
        text-decoration: none;
        padding: 5px;
        font-weight: bold;
    }
    
    a.x:hover
    {
        color: #333333;
        text-decoration: underline;
        font-weight: bold;
    }
    
    ul
    {
        color: black;
    }
    
    .drag_Element
    {
        position: relative;
        left: 0px;
        top: 0px;
        padding-left: 5px;
        padding-right: 5px;
        border: 0px dashed #CCCCCC;
        visibility: hidden;
    }
    
    #Drag_content
    {
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
        if (!hideAll)
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
<script type="text/javascript" src="../js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">
    <div id="Drag_content">
        &nbsp;</div>
    <div id="status" style="position: absolute; display: none; left: 930px; top: 95px;
        height: 27px; white-space: nowrap;">
        <img src="../../themes/softed/images/status.gif">
    </div>
    <!-- ActivityReminder Customization for callback -->
    <div class="ListHead" id="ActivityRemindercallback" align="left">
    </div>
    <div id="SelCustomer_popview" class="layerPopup" style="position: absolute; z-index: 60;
        display: none;">
    </div>
    
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
        <tr>
            <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>
                <table border="0" cellspacing="0" cellpadding="5" width="100%" class="settingsSelUITopLine">
                    <tr>
                        <td width="50" rowspan="2" valign="top">
                            <img src="../../themes/softed/images/ico-roles.gif" alt="Catalogs" width="48" height="48"
                                border="0" title="Catalogs">
                        </td>
                        <td class="heading2" valign="bottom">
                            <b>产品</a> > 产品分类</b>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="small">
                            使用帮助：把鼠标放在某个产品分类上，旁边会出现添加分类,编辑分类和删除分类的图标，点击相应图标可以维护产品分类。
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 2px">
            </td>
        </tr>
    </table>
    
    <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0" class="tablecss">
        <tr>
            <td>
                <table border="0" cellspacing="0" cellpadding="2" width="100%" class="small">
                    <tr>
                        <!-- Buttons -->
                        <td style="padding-right: 20px" align="left" nowrap>
                            <div id='CatalogTreeFull' onmousemove="displayCoords(event)">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="small">
                                    <tr>
                                        <td style="padding: 10px;" valign="top">
                                            
                                            <%=s_AdvShow %>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
                </div>
            </td>
        </tr>
    </table>
    <!--分页-->
    <!--底部功能栏-->
    </td> </tr> </table>
    </form>
</body>
</html>
