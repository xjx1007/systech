<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Sc_Plan_Material2.aspx.cs"
    Inherits="Sc_Plan_Material2" %>

<%@ Register Assembly="Container" Namespace="HT.Control.WebControl" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
    <title>物料计划</title>
    <script type="text/javascript" src="../js/ajax_func.js"></script>
    <script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
    <script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="../../include/js/ListView.js"></script>
    <script type="text/javascript" src="../KDialog/lhgdialog.js"></script>
    
<SCRIPT LANGUAGE=JAVASCRIPT >
    function btnGetReturnValue_onclick()  
    {   
        /*选择客户*/
        var today,seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd= window.showModalDialog("../Common/SelectSuppliers.aspx?Type=128860698200781250","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
       
        if(tempd!=undefined)   
        {   
            var ss;
            ss=tempd.split("|");
            document.all('Tbx_HouseNo').value =ss[0];
            document.all('Tbx_HouseName').value =ss[1];
        }   
        else
        {
            document.all('Tbx_HouseNo').value = ""; 
            document.all('Tbx_HouseName').value = ""; 
        }
    }
    
    function btnGetReturnValue_onclick1()  
    {   
        /*选择客户*/
        var today,seconds;
        today = new Date();
        intSeconds = today.getSeconds();
        var tempd= window.showModalDialog("../Products/SelectProduct.aspx?sID="+intSeconds+"","","dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=700px");
       
        if(tempd!=undefined)   
        {   
            var ss;
            ss=tempd.split(",");
            document.all('Tbx_ProductsBarCode').value =ss[2];
            document.all('Tbx_ProductsName').value =ss[0];
             
        }   
        else
        {
            document.all('Tbx_ProductsBarCode').value = ""; 
            document.all('Tbx_ProductsName').value = ""; 
        }
    }
    
    </SCRIPT>
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
        }

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
        .auto-style1 {
            background: #F7F7F7 url('../../themes/softed/images/testsidebar.jpg') repeat-y right center;
            border-bottom: 1px solid #DEDEDE;
            border-left: 1px solid #DEDEDE;
            border-right: 1px solid #DEDEDE;
            color: #545454;
            padding-left: 10px;
            padding-right: 10px;
            white-space: nowrap;
            text-align: right;
            height: 25px;
            width: 10%;
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
        
                                <asp:Panel runat="server" ID="Pan" Visible="false">
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
                                    <tr>
                                        <td align="right" class="dvtCellLabel" valign="middle" style="height: 30px" width="15%">
                                            <b>供应商名称：</b>
                                        </td>

                                        <td align="left" class="dvtCellInfo" valign="middle">
                                            <asp:Label runat="server" ID="Lbl_House"></asp:Label>&nbsp;
                                            <input type="hidden" name="Tbx_HouseNo" id="Tbx_HouseNo" runat="server" />
                                            <asp:TextBox ID="Tbx_HouseName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>
        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick()" />(<font color="red">*</font>)<br />
                                            <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator2" runat="server" ErrorMessage="供应商名称非空" ControlToValidate="Tbx_HouseName"
                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" class="auto-style1" valign="middle">
                                            <b>产品：</b>
                                        </td>
                                        <td align="left" class="dvtCellInfo" valign="middle">
                                            <asp:Label runat="server" ID="Lbl_ProductsBarCode"></asp:Label>&nbsp;
                                            <input type="hidden" name="Tbx_ProductsBarCode" id="Tbx_ProductsBarCode" runat="server" />
                                            <asp:TextBox ID="Tbx_ProductsName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                            OnBlur="this.className='detailedViewTextBox'" Width="150px"></asp:TextBox>
        <img tabindex="8" src="../../themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetReturnValue_onclick1()" />
                                                                                        <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator1" runat="server" ErrorMessage="产品名称非空" ControlToValidate="Tbx_ProductsName"
                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                        &nbsp;<asp:Button ID="Button4" runat="server" Text="筛选" class="crmbutton small save"
                                                            CausesValidation="false"  />
                                        </td>
                                    </tr>
                                </table>
                                    </asp:Panel>
                                <hr />
                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
    </form>
</body>
</html>
