﻿<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" EnableEventValidation="false"
    CodeFile="KnetProductsSetting_Add.aspx.cs" Inherits="Knet_Web_System_KnetProductsSetting_Add" %>

<%@ Register Src="../Control/UploadListForProducts.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>产品添加</title>
    <script language="JAVASCRIPT">
        function btnGetProducts_onclick1() {
            /*选择产品*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectProduct.aspx", "", "dialogtop=150px;dialogleft=160px; dialogwidth=900px;dialogHeight=500px");
            var temp = window.open("SelectProduct.aspx", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Product(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_GProductsBarCode').value = ss[2];
                document.all('Tbx_GProductsEdition').value = ss[0];
            }
            else {
                document.all('Tbx_GProductsBarCode').value = "";
                document.all('Tbx_GProductsEdition').value = "";
            }
        }
        function btnGetReturnValue_onclick() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();

            //var tempd = window.showModalDialog("/Web/Common/SelectClientList.aspx?sID=" + document.all("Xs_ClientID").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("/Web/Common/SelectClientList.aspx?sID=" + document.all("Xs_ClientID").value + "", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Client(tempd) {
            if (tempd != undefined) {

                var ss, s_Value, s_Name, i_row;
                ss = tempd.split("|");
                s_Value = ss[0].split(",");
                s_Name = ss[1].split(",");
                i_row = myTable.rows.length;
                s_ID = document.all("Xs_ClientID").value;
                for (var i = 0; i < s_Value.length; i++) {
                    var objRow = myTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=\"hidden\" input Name=\"CustomerValue\" value=' + s_Value[i] + '>' + s_Value[i];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input  type=\"hidden\"  Name=\"CustomerName\" value=' + s_Name[i] + ' >' + s_Name[i];
                    objCel.className = "ListHeadDetails";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[i] + ",";
                }
                document.all("Xs_ClientID").value = s_ID;
            }
        }
        function btnGetCgDay_onclick() {
            i_row = CgDay.rows.length;

            var i_Num = parseInt(document.all("Tbx_NumCgDay").value);
            var v_Max = 999999;
            var v_Min = 0;
            if (i_Num != 0) {
                var v_NewNum = parseInt(i_Num) - 1
                var v_FMax = document.all("Max_" + v_NewNum + "");
                if (v_FMax) {
                    v_Min = parseFloat(v_FMax.value);
                }
                else {
                    v_Min = 0
                }
                v_Max = 999999
            }
            var objRow = CgDay.insertRow(i_row);
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<A onclick=\"deleteRowCgDay(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:70px;"  Name=\"Min_' + i_Num + '\" value=' + v_Min + '>';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:70px;"  Name=\"Max_' + i_Num + '\" value=' + v_Max + '>';
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            objCel.innerHTML = '<input  type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\"  style="width:70px;"  Name=\"day_' + i_Num + '\" value=>';
            objCel.className = "ListHeadDetails";
            document.all("Tbx_NumCgDay").value = i_Num + 1;
        }
        function btnGetProducts_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("/Web/Common/SelectSuppliersPriceForProducts.aspx", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1100px;dialogHeight=500px");
            var tempd = window.open("/Web/Common/SelectSuppliersPriceForProducts.aspx", "选择供应商采购报价", "width=1100px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_SuppliersPriceForProducts(tempd) {
            if (tempd != undefined) {
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsTable.rows.length;
                s_ID = document.all("Products_ID").value + ",";
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split(",");
                    var objRow = ProductsTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteRow1(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ProdoctsBarCode\" style=\"display:none;\" value=' + s_Value[0] + ' >' + s_Value[1];
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[6];
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=input Name=\"SuppNo\"  style=\"display:none;\" value=' + s_Value[2] + '>' + s_Value[3];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=input Name=\"Price\" style=\"display:none;\" value=' + s_Value[4] + ' >' + s_Value[4];
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=input Name=\"Number\" style=\"display:none;\" value=' + s_Value[5] + ' >' + s_Value[5];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=input Name=\"IsOrder\" style=\"display:none;\" value=' + s_Value[7] + ' >' + s_Value[7];
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<input type=input Name=\"Address\" style=\"display:none;\" value=' + s_Value[8] + ' >' + s_Value[9];
                    objCel.className = "ListHeadDetails";
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                document.all("Products_ID").value = s_ID;
            }
        }

        function deleteRow(obj) {
            myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("CustomerValue");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Xs_ClientID").value = bm_num;
        }

        function deleteRow1(obj) {
            ProductsTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("ProdoctsBarCode");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Products_ID").value = bm_num;
        }

        function btnGetBomProducts_onclick1() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            v_newNum = $("Products_BomNum").value;
            //var tempd = window.showModalDialog("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "&callBack=SetReturnValueInOpenner_ProductsDemo3", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function btnGetBomProducts_onclick2(temp, code, nume) {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            v_newNum = $("Products_BomNum").value;
            //var tempd = window.showModalDialog("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            //ID=" + document.all("Products_BomID").value + "&&
            var tempd = window.open("SelectProductsDemo.aspx?place=" + temp + "&&code=" + code + "&&num=" + nume + "&&callBack=SetReturnValueInOpenner_ProductsDemo1", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsDemo1(tempd) {
            debugger;
            if (tempd != undefined) {
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsBomTable.rows.length;
                s_ID = document.all("Products_BomID").value + ",";
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    //alert(ss);

                    s_Value = ss[i].split("!");
                    //var place = s_Value[4];
                    var objRow = ProductsBomTable.insertRow(i_row);
                    v_newNum = parseInt(v_newNum) + i + 1;

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoOrder_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;width:50px\" value=' + v_newNum.toString() + ' >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '&nbsp;'

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '&nbsp;<A onclick=\"deleteRow2(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoProdoctsBarCode_' + v_newNum + '\" style=\"display:none;\" value=' + s_Value[0] + ' >' + s_Value[1];
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[3];

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"Place_' +
                        v_newNum.toString() +
                        '\"  ID=\"Place_' +
                        v_newNum.toString() +
                        '\"  style=\"detailedViewTextBox;width:300px\"  onblur=\"onPlaceblur()\"  value=' +
                         s_Value[4] +
                        ' >';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ReplaceNum_' + v_newNum.toString() + '\"  ID=\"ReplaceNum_' + v_newNum.toString() + '\"  style=\"detailedViewTextBox;width:300px\" value=1 >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoNumber_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;width:50px\" onblur=\"onPlaceblur()\" value=' + s_Value[5] + '  >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=\"checkbox\" Name=\"DemoDel_' + v_newNum.toString() + '\" > '

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=\"checkbox\" Name=\"DemoOnly_' + v_newNum.toString() + '\" checked> '

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '&nbsp;'
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                $("Products_BomID").value = s_ID;
                $("Products_BomNum").value = v_newNum;
            }
        }

        function SetReturnValueInOpenner_ProductsDemo3(tempd) {
            if (tempd != undefined) {
                var df = "";
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsBomTable.rows.length;
                s_ID = document.all("Products_BomID").value + ",";
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split("!");
                    var objRow = ProductsBomTable.insertRow(i_row);
                    v_newNum = parseInt(v_newNum) + i;
                    //alert(v_newNum);
                    df = v_newNum + 1;
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoOrder_' + v_newNum + '\" style=\"detailedViewTextBox;width:50px\" value=' + df + ' >';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '&nbsp;';

                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '&nbsp;<A onclick=\"deleteRow2(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoProdoctsBarCode_' + v_newNum + '\" style=\"display:none;\" value=' + s_Value[0] + ' ><input type=\"input\"  readonly=\"true\"  Name=\"ProductsName_' + v_newNum + '\" value=' + s_Value[1] + '>';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=\"input\"  readonly=\"true\" style=\"width:300px\"  Name=\"ProductsEdition_' + v_newNum + '\" value=' + s_Value[3] + '>';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"Place_' + v_newNum.toString() + '\"  ID=\"Place_' + v_newNum.toString() + '\"  style=\"detailedViewTextBox;width:300px\"  onblur=\"onPlaceblur()\"  value="" >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"ReplaceNum_' + v_newNum.toString() + '\"  ID=\"ReplaceNum_' + v_newNum.toString() + '\"  style=\"detailedViewTextBox;width:300px\"    value="0" >';

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoNumber_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;width:50px\" style=\"detailedViewTextBox;width:300px\"  onblur=\"onPlaceblur()\" value=' + s_Value[2] + '  >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=\"checkbox\" Name=\"DemoDel_' + v_newNum.toString() + '\" > '

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=\"checkbox\" Name=\"DemoOnly_' + v_newNum.toString() + '\" checked> '

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '&nbsp;'
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                $("Products_BomID").value = s_ID;
                $("Products_BomNum").value = df;
            }
        }
        function btnGetBomProducts_onclick(ProductsTypeID, Rowi) {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "&ProductsTypeID=" + ProductsTypeID + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("SelectProductsDemo.aspx?ID=" + document.all("Products_BomID").value + "&ProductsTypeID=" + ProductsTypeID + "", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsDemo(tempd) {
            if (tempd != undefined) {

                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsBomTable.rows.length;
                s_ID = $("Products_BomID").value + ",";
                ss = tempd.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split(",");
                    var v_ProductsBarCode = s_Value[0];
                    var v_ProductsName = s_Value[1];
                    var v_ProductsEdition = s_Value[3];
                    var v_Number = s_Value[2];
                    $("DemoProdoctsBarCode_" + Rowi + "").value = s_Value[0];
                    $("ProductsName_" + Rowi + "").value = s_Value[1];
                    $("ProductsEdition_" + Rowi + "").value = s_Value[3];
                    $("DemoNumber_" + Rowi + "").value = s_Value[2];
                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                $("Products_BomID").value = s_ID;
            }
        }

        function ChangeOnly(chk_only) {
            var Chk_DemoOnly = $("DemoOnly_" + chk_only + "");
            var ProductsBarCode = $("DemoProdoctsBarCode_" + chk_only + "").value;
            if (Chk_DemoOnly.checked == true) {
                v_newNum = $("Products_BomNum").value;
                var Response = Knet_Web_System_KnetProductsSetting_Add.GetRepalceProducts(ProductsBarCode);
                ss = Response.value.split("|");
                for (var i = 0; i < ss.length - 1; i++) {
                    s_Value = ss[i].split(",");
                    v_newNum = parseInt(v_newNum) + i + 1;
                    var objRow = ProductsBomTable.insertRow(parseInt(chk_only) + 2);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = "<font color=green>" + s_Value[1] + "</font>";
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<a href=\"#\" onclick=\"return btnGetBomProducts_onclick(\"' + s_Value[0] + '\",\"' + v_newNum + '\")\" >添加</a><A onclick=\"deleteRow2(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoRepacleProdoctsBarCode_' + v_newNum.toString() + '\" style=\"display:none;\" value=' + s_Value[2] + ' ><input type=input Name=\"DemoProdoctsBarCode_' + v_newNum.toString() + '\" style=\"display:none;\" value=' + s_Value[3] + ' >' + s_Value[4];
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[5];
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoNumber_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;\" value=1 >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"DemoOrder_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;\" value=0 >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=\"checkbox\" Name=\"DemoOnly_' + v_newNum.toString() + '\" checked>是 '
                }
                $("Products_BomNum").value = v_newNum;
            }
            else {
                v_Num = $("Products_BomNum").value;
                for (var i = 0; i < parseInt(v_Num) + 1 ; i++) {
                    var v_DemoRepacleProdoctsBarCode = $("DemoRepacleProdoctsBarCode_" + i.toString() + "");
                    if (typeof (v_DemoRepacleProdoctsBarCode) != "undefined") {
                        if (v_DemoRepacleProdoctsBarCode.value == ProductsBarCode) {
                            ProductsBomTable.deleteRow(v_DemoRepacleProdoctsBarCode.parentElement.parentElement.rowIndex);
                        }
                    }
                }

            }
        }
        function check1() {
            if ($("TextBox4").value != "3") {
                debugger;
                var ProductsName = $("ProductsName").value;
                var ProductsPattern = $("ProductsPattern").value;
                var Edition = $("Tbx_Edition").value;
                var Type = $("Tbx_Type").value;
                var Response = Knet_Web_System_KnetProductsSetting_Add.CheckProductsEdition(ProductsName, Edition, Type);
                if (Response.value == "1") {
                    alert("产品版本号已存在！");
                    return false;
                }
                var Tbx_Num = $("TextBox2").value;
                if (Tbx_Num != "") {
                    //var vr = msgbox("", 3);
                    if (confirm("有订单在进行中，此次升级是否用于此生产？点击取消则不用于此次生产，直接升级！！点击确认或取消数据都无法恢复！！慎重！！！！")) {
                        if (confirm("有订单在进行中,你真的要用于此次升级么")) {
                            $("TextBox3").value = "true";
                        }
                        else {
                            $("TextBox3").value = "false";
                        }

                    }
                    else {
                        if (confirm("有订单在进行中,你真的不用于此次生产，直接升级么")) {
                            $("TextBox3").value = "false";
                        } else {
                            $("TextBox3").value = "true";
                        }

                    }

                }
                
            }
            if ($("TextBox4").value != "") {
                if ($("ProductRemark").value=="") {
                    alert("备注不能为空！请在备注处输入你修改的内容！");
                    return false;
                }
               
            }

        }
        function onPlaceblur() {

            var v_Num = "";
            v_Num = document.all("Products_BomNum").value;
            debugger;
            if (v_Num != "") {
                var v_Have = "";
                var v_ErrorText = "";

                for (var i = 0; i < parseInt(v_Num) + 1 ; i++) {
                    var place = "";
                    if (document.all("Place_" + i + "") != null) {
                        place = document.all("Place_" + i + "").value;
                        var ProductsEdition = "";
                        ProductsEdition = document.all("ProductsEdition_" + i + "").value;
                        var DemoNumber = "";
                        DemoNumber = document.all("DemoNumber_" + i + "").value;
                        var DemoOrder = "";
                        DemoOrder = document.all("DemoOrder_" + i + "").value;
                        var ProductsName = document.all("ProductsName_" + i + "").value;
                        if (place != "") {
                            var ss = place.split(",");
                            var v_length = ss.length;

                            if (ProductsName != "辅料") {
                                if (parseInt(v_length) != parseInt(DemoNumber))
                                    v_ErrorText += "<font color=red>行号：" + DemoOrder + "的" + ProductsEdition + " 的位号个数和BOM个数不一致！</font><br/>";
                            }
                        }
                        var v_havebool = "0";
                        if (v_Have != "") {
                            var v_Haves = v_Have.split(",");
                            for (var jj = 0; jj < v_Haves.length - 1; jj++) {
                                if (i == v_Haves[jj]) {
                                    v_havebool = 1;
                                }
                            }
                        }
                        for (var j = 0; j < parseInt(v_Num) + 1; j++) {
                            if (j != i) {
                                var place1 = "";
                                if (v_havebool == 0) {
                                    if (document.all("Place_" + j + "") != null) {
                                        place1 = document.all("Place_" + j + "").value;
                                        var ProductsEdition1 = document.all("ProductsEdition_" + j + "").value;
                                        var DemoOrder1 = "";
                                        DemoOrder1 = document.all("DemoOrder_" + j + "").value;
                                        if (place1 != "" && place != "") {
                                            var pp = place1 + "," + place;
                                            //var arr = pp.split(",");
                                            var strs = new Array(); //定义一数组 
                                            strs = pp.split(","); //字符分割 
                                            var nary = strs.sort();
                                            for (var f = 0; f < nary.length; f++) {
                                                if (nary[f] == nary[f + 1]) {
                                                    //alert("数组重复内容：" + nary[i]);
                                                    v_ErrorText += "<font color=red>位号已经存在！序号：" + DemoOrder + " 的 " + ProductsEdition + "和 序号：" + DemoOrder1 + " 的 " + ProductsEdition1 + " 位号相同！</font><br/>";
                                                    v_Have += j + ",";
                                                }

                                            }


                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                document.all("Lbl_Error").innerHTML = v_ErrorText;
            }
        }
        function btnGetAlternativeProductsNum_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("SelectAlternativeProducts.aspx?ProductsType=" + document.all("Tbx_ProductsTypeNo").value + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("SelectAlternativeProducts.aspx?ProductsType=" + document.all("Tbx_ProductsTypeNo").value + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_AlternativeProducts(tempd) {
            if (tempd != undefined) {
                var ss, s_Value, s_Name, i_row, s_ID;
                i_row = ProductsAlternativeTable.rows.length;
                s_ID = $("Products_AlternativeID").value + ",";
                ss = tempd.split("|");
                var v_newNum = parseInt($("Products_AlternativeNum").value);
                for (var i = 0; i < ss.length - 1; i++) {
                    v_newNum = parseInt(v_newNum) + i + 2;
                    s_Value = ss[i].split(",");
                    var objRow = ProductsAlternativeTable.insertRow(i_row);
                    var objCel = objRow.insertCell();
                    objCel.innerHTML = '<A onclick=\"deleteAlternativeRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                    objCel.className = "ListHeadDetails";
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"AlternativeProdoctsBarCode_' + v_newNum.toString() + '\" style=\"display:none;\" value=' + s_Value[0] + ' >' + s_Value[1];
                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = s_Value[2];

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=input Name=\"AlternativePriority_' + v_newNum.toString() + '\" style=\"detailedViewTextBox;\" value=0 >'

                    var objCel = objRow.insertCell();
                    objCel.className = "ListHeadDetails";
                    objCel.innerHTML = '<input type=\"checkbox\" Name=\"AlternativeOlny_' + v_newNum.toString() + '\" checked>是 '

                    i_row = i_row + 1;
                    s_ID = s_ID + s_Value[0] + ",";
                }
                $("Products_AlternativeID").value = s_ID;
                $("Products_AlternativeNum").value = parseInt(v_newNum) + 1;
            }
        }

        function deleteAlternativeRow(obj) {
            ProductsAlternativeTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("AlternativeProdoctsBarCode");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Products_AlternativeID").value = bm_num;
        }

        function deleteRow2(obj) {
            ProductsBomTable.deleteRow(obj.parentElement.parentElement.rowIndex);
            var Values = document.getElementsByName("DemoProdoctsBarCode");
            var bm_num = "";
            for (i = 0; i < Values.length; i++) {
                bm_num += Values[i].value + ",";
            }
            document.all("Products_BomID").value = bm_num;
        }



        function btnGetProductsTypeValue_onclick() {
            if (document.all('TextBox4').value == "3") {
                return false;
            }//02210268判断是否为编辑，如果为编辑，不能选择产品分类和更改料号
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("/Web/ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("/Web/ProductsClass/Pb_Basic_ProductsClass_Show.aspx?ID=" + intSeconds + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_ProductsClass(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_ProductsTypeNo').value = ss[0];
                document.all('Tbx_ProductsTypeName').value = ss[1];
                document.all('Tbx_Code').value = ss[2];
                GetProductsPattern();
            }
            else {
                document.all('Tbx_ProductsTypeNo').value = "";
                document.all('Tbx_ProductsTypeName').value = "";
                document.all('Tbx_Code').value = "";
            }
        }
        function btnGetMJValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectMouldProduct.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=750px;dialogHeight=500px");
            var temp = window.open("SelectMouldProduct.aspx?ID=" + intSeconds + "", "选择产品", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_MouldProduct(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split(",");
                document.all('Tbx_MouldNo').value = ss[0];
                document.all('Tbx_MouldName').value = ss[1];
                document.all('Tbx_MouldCode').value = ss[2];
                GetProductsPattern();
            }
            else {
                document.all('Tbx_MouldNo').value = "";
                document.all('Tbx_MouldName').value = "";
                document.all('Tbx_MouldCode').value = "";
            }
        }
        function GetProductsPattern() {
            var v_Code = "", v_ProductsType = "", v_ID;
            v_ID = document.all('Tbx_ID').value;
            if (v_ID == "") {
                v_ProductsType = document.all('Tbx_ProductsTypeNo').value;
                v_Code += document.all('Tbx_ProductsTypeName').value;
                v_Code += "-";
                v_Code += document.all('Tbx_MouldCode').value;

                var response = Knet_Web_System_KnetProductsSetting_Add.GetProductsPattern(v_Code, v_ProductsType);
                document.all('ProductsPattern').value = response.value;
            }
        }

        function deleteRow3(obj) {
            myTableDetails.deleteRow(obj.parentElement.parentElement.rowIndex);
        }
        function deleteRowCgDay(obj) {
            CgDay.deleteRow(obj.parentElement.parentElement.rowIndex);
        }

    </script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="detail_info_click('Div1');">
    <form id="form1" runat="server">

        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>产品字典 > <a class="hdrLink" href="KnetProductsSetting_Add.aspx">
                    <asp:Label runat="server" ID="Lbl_Title"></asp:Label></a>
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
                    <img src="/themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <br>
                        <hr noshade size="1">
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>产品字典信息
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">

                                        <tr style="height: 16px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Div2');">
                                            <!-- windLayerHeadingTr -->
                                            <td colspan="2" class="" valign="middle">&nbsp;&nbsp;基本信息&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 16px; width: 30px;" onclick="detail_info_click('Div2');">
                                                <img align="absmiddle" id="Div2_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                            </span>
                                                <asp:Label ID="lblID" runat="server" Visible="false"></asp:Label>

                                            </td>
                                        </tr>
                                        <asp:Panel ID="Pan_De" runat="server">
                                            <tr>
                                                <td colspan="4">
                                                    <div id="Div2">
                                                        <table width="100%" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="15%" height="25" align="right" class="dvtCellLabel">产品名称:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" MaxLength="40"></asp:TextBox>(<font
                                                                            color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                                ErrorMessage="产品名称非空！" ControlToValidate="ProductsName" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td height="25" align="right" class="dvtCellLabel">料号:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_Code" runat="server" MaxLength="40" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        Width="200px"></asp:TextBox>
                                                                    <asp:TextBox ID="ProductsBarCode" runat="server" MaxLength="40" CssClass="Custom_Hidden"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator4" runat="server" ErrorMessage="非空！且要唯一" ControlToValidate="Tbx_Code"
                                                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="dvtCellLabel">产品分类：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_ProductsTypeName" runat="server" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        MaxLength="48" Width="200px"></asp:TextBox>
                                                                    <asp:TextBox ID="Tbx_ProductsTypeNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                    <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProductsTypeValue_onclick()" />
                                                                    (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                                                                        runat="server" ErrorMessage="产品分类非空" ControlToValidate="Tbx_ProductsTypeNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">模具：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_MouldName" runat="server" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        MaxLength="48" Width="200px"></asp:TextBox>
                                                                    <asp:TextBox ID="Tbx_MouldNo" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                    <asp:TextBox ID="Tbx_MouldCode" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                    <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetMJValue_onclick()" />
                                                                    (<font color="red">*</font>)
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td width="13%" align="right" class="dvtCellLabel">产品型号：
                                                                </td>
                                                                <td width="30%" align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsPattern" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">产品版本:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_Edition" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>

                                                                <td width="13%" align="right" class="dvtCellLabel">客户物料名称：
                                                                </td>
                                                                <td width="30%" align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_CustomerProductsName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">客户物料代码:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_CustomerProductsCode" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>

                                                                <td width="13%" align="right" class="dvtCellLabel">客户规格型号：
                                                                </td>
                                                                <td width="30%" align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_CustomerProductsEdition" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                                <td width="13%" align="right" class="dvtCellLabel">包装数：
                                                                </td>
                                                                <td width="30%" align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="Tbx_BZNumber" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" MaxLength="40"></asp:TextBox>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td align="right" class="dvtCellLabel">单 位：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:DropDownList ID="ProductsUnits" runat="server" Width="100px" CssClass="detailedViewTextBox">
                                                                    </asp:DropDownList>
                                                                    (<font color="red">*</font>)<asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                                                                        runat="server" ErrorMessage="单位非空" ControlToValidate="ProductsUnits" Display="Dynamic"></asp:RequiredFieldValidator>
                                                                    <asp:TextBox ID="BigUnits" Width="40px" runat="server" Text=""></asp:TextBox><%--<asp:Label ID="WLweight" runat="server" Text="物料重量"></asp:Label>--%>
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" CssClass="detailedViewTextBox">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">库存预警：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsStockAlert" Text="0" MaxLength="6" runat="server" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        Width="200px"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="非空，0表示不预警"
                                                                        ControlToValidate="ProductsStockAlert" Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                            ID="RegularExpressionValidator5" runat="server" ErrorMessage="只能零或正整数" ControlToValidate="ProductsStockAlert"
                                                                            ValidationExpression="^\+?[0-9][0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="dvtCellLabel">重量（KG）：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <pc:PTextBox ID="Tbx_Weight" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" runat="server" Text="0.00" ValidType="Float"></pc:PTextBox>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">体积（M<sup>3</sup>）：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <pc:PTextBox ID="Tbx_Volume" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" runat="server" Text="0.00" ValidType="Float"></pc:PTextBox>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td height="25" align="right" class="dvtCellLabel">更新产品:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">

                                                                    <input type="hidden" name="Tbx_GProductsBarCode" id="Tbx_GProductsBarCode" runat="server" style="width: 150px" />
                                                                    <asp:TextBox ID="Tbx_GProductsEdition" runat="server" CssClass="detailedViewTextBox" Width="200px"></asp:TextBox>(<font color="red">*</font>)
                                                <img src="/themes/softed/images/select.gif" alt="选择" title="选择" onclick="return btnGetProducts_onclick1()" />
                                                                </td>
                                                                <td height="25" align="right" class="dvtCellLabel">新产品生产:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:CheckBox ID="Chk_isModiy" runat="server" Checked />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="25" align="right" class="dvtCellLabel">使用方式:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:DropDownList runat="server" ID="Ddl_UseType"></asp:DropDownList>
                                                                </td>
                                                                <td height="25" align="right" class="dvtCellLabel">损耗分类:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:DropDownList runat="server" ID="Ddl_Loss"></asp:DropDownList>
                                                                </td>
                                                            </tr>

                                                            <tr>
                                                                <td height="25" align="right" class="dvtCellLabel">研发工程师:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:DropDownList runat="server" ID="Ddl_RDPerson"></asp:DropDownList>
                                                                </td>
                                                                <td height="25" align="right" class="dvtCellLabel">采购方式:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:RadioButtonList runat="server" ID="Chk_CgType"></asp:RadioButtonList>
                                                                </td>
                                                            </tr>

                                                            <tr runat="server" visible="false">
                                                                <td
                                                                    height="25" align="right" class="dvtCellLabel">品牌/厂家:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3">
                                                                    <table id="Table1" width="100%" border="0" align="center" cellpadding="2" cellspacing="1" class="ListDetails">
                                                                        <tr id="tr2">
                                                                            <td align="center" class="ListHead">品牌/厂家
                                                                            </td>
                                                                            <td align="center" class="ListHead">参数
                                                                            </td>
                                                                            <td align="center" class="ListHead">工具
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" class="ListHeadDetails">
                                                                                <asp:TextBox ID="Tbx_BrandID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                                                                                <asp:TextBox ID="Tbx_BrandName" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                    OnBlur="this.className='detailedViewTextBox'" Width="200px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" class="ListHeadDetails">
                                                                                <asp:TextBox ID="Tbx_BrandRemarks" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                                    OnBlur="this.className='detailedViewTextBox'"
                                                                                    TextMode="MultiLine" Width="340px" Height="30px"></asp:TextBox>
                                                                            </td>
                                                                            <td align="left" class="ListHeadDetails"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="dvtCellLabel">参数描述:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsDescription" runat="server" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        TextMode="MultiLine" Width="370px" Height="50px"></asp:TextBox>
                                                                    <font color="gray">1000字内.如体积大小,品牌,产地等.</font><br />
                                                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                                        ControlToValidate="ProductsDescription" ValidationExpression="^(\s|\S){0,1000}$"
                                                                        ErrorMessage="简单描述字太多" Display="dynamic"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">备注:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductRemark" runat="server" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        TextMode="MultiLine" Width="380px" Height="50px"></asp:TextBox>
                                                                </td>


                                                            </tr>

                                                            <tr>
                                                                <div runat="server" id="Attachment">
                                                                    <td colspan="4">
                                                                        <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />
                                                                    </td>
                                                                </div>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>


                                            <tr style="height: 16px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Div1');">
                                                <!-- windLayerHeadingTr -->
                                                <td colspan="4" class="" valign="middle">&nbsp;&nbsp;其他信息&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 16px; width: 30px;" onclick="detail_info_click('Div1');">
                                                    <img align="absmiddle" id="Div1_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                                </span>

                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <div id="Div1">
                                                        <table width="100%" cellspacing="0" cellpadding="0">

                                                            <tr>
                                                                <td align="right" class="dvtCellLabel">销售价:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsSellingPrice" runat="server" Text="0.00" MaxLength="9" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        Width="200px"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator6" runat="server" ErrorMessage="建议售价非空" ControlToValidate="ProductsSellingPrice"
                                                                            Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                                                                                runat="server" ErrorMessage="货币形式！" ControlToValidate="ProductsSellingPrice"
                                                                                ValidationExpression="^(-)?(\d+|,\d{6})+(\.\d{0,6})?$" Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">采购参考成本：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsCostPrice" runat="server" Text="0.00" MaxLength="9" CssClass="detailedViewTextBox"
                                                                        OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                                        Width="200px"></asp:TextBox>(<font color="red">*</font>)<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="建议售价非空" ControlToValidate="ProductsCostPrice"
                                                                            Display="Dynamic"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                                                                runat="server" ErrorMessage="货币形式！" ControlToValidate="ProductsCostPrice" ValidationExpression="^(-)?(\d+|,\d{6})+(\.\d{0,6})?$"
                                                                                Display="Dynamic"></asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="25" align="right" class="dvtCellLabel">是否有图片:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:CheckBox ID="ProductsPic" runat="server" OnCheckedChanged="ProductsPic_CheckedChanged"
                                                                        AutoPostBack="true" /><font color="gray">（上传图片的请打勾）</font>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">加工费：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <pc:PTextBox ID="Tbx_HandPrice" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" Width="200px" runat="server" Text="0.00" ValidType="Float"></pc:PTextBox>
                                                                </td>
                                                            </tr>
                                                            <tr id="AddPic" runat="server" visible="false">
                                                                <td height="25" align="right" class="dvtCellLabel">请选择图片:
                                                                </td>
                                                                <td colspan="3" align="left" class="dvtCellInfo">
                                                                    <asp:Label ID="Image1Big" runat="server" Text="" Visible="false"></asp:Label>
                                                                    <asp:Image ID="Image1" runat="server" Width="95px" Height="75px" />&nbsp;<input id="uploadFile"
                                                                        type="file" runat="server" class="Boxx" size="30" />&nbsp;<input id="button" type="button"
                                                                            value="上传图片" runat="server" class="Btt" onserverclick="button_ServerClick" causesvalidation="false" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="25" align="right" class="dvtCellLabel">添加员：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsAddMan" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" ReadOnly="true" Width="200px"></asp:TextBox>
                                                                    <asp:Label ID="ProductsAddMantxt" runat="server" Visible="false"></asp:Label>
                                                                </td>
                                                                <td align="right" class="dvtCellLabel">添加时间：
                                                                </td>
                                                                <td align="left" class="dvtCellInfo">
                                                                    <asp:TextBox ID="ProductsAddTime" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                        OnBlur="this.className='detailedViewTextBox'" ReadOnly="true" Width="200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <asp:TextBox ID="Xs_ClientID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox><td
                                                                    height="25" align="right" class="dvtCellLabel">选择销售客户:
                                                                </td>
                                                                <td align="left" class="dvtCellInfo" style="text-align: left" colspan="3">
                                                                    <table id="myTable" width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr id="tr1">
                                                                            <td align="center" class="dvtCellLabel">工具
                                                                            </td>
                                                                            <td align="center" class="dvtCellLabel">客户编号
                                                                            </td>
                                                                            <td align="center" class="dvtCellLabel">客户名称
                                                                            </td>
                                                                        </tr>
                                                                        <%=s_MyTable_Detail %>
                                                                    </table>
                                                                    <input id=" btnGetReturnValue" class="crmbutton small create" onclick="return btnGetReturnValue_onclick()"
                                                                        type="button" value="选择客户" />
                                                                </td>
                                                            </tr>


                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </asp:Panel>


                                        <tr style="height: 16px; cursor: pointer;" class="detail-content-heading" onmouseover="this.className='detail-content-heading-over';" onmouseout="this.className='detail-content-heading'" onclick="detail_info_click('Div3');">
                                            <!-- windLayerHeadingTr -->
                                            <td colspan="2" class="" valign="middle">&nbsp;&nbsp;BOM(位号请用<font color="red"> , </font>间隔)&nbsp;&nbsp;&nbsp;&nbsp;<span style="cursor: pointer; height: 16px; width: 30px;" onclick="detail_info_click('Div3');">
                                                <img align="absmiddle" id="Div3_IMG" src="/themes/softed/images/arrow-list-down.gif" border="0">
                                            </span>

                                                &nbsp;</td>
                                        </tr>


                                        <tr>
                                            <td colspan="2">
                                                <div id="Div3" runat="server">

                                                    <table width="100%" cellspacing="0" cellpadding="0">

                                                        <tr>
                                                            <asp:TextBox ID="Products_BomNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                            <asp:TextBox ID="Products_BomID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                            <td align="left" class="dvtCellInfo" style="text-align: left">
                                                                <table id="ProductsBomTable" width="100%" border="0" align="center" cellpadding="0"
                                                                    cellspacing="0" class="ListDetails">
                                                                    <tr id="tr3">
                                                                        <td align="center" class="ListHead">序号
                                                                        </td>
                                                                        <td align="center" class="ListHead">类别
                                                                        </td>
                                                                        <td align="center" class="ListHead">工具
                                                                        </td>
                                                                        <td align="center" class="ListHead">产品名称
                                                                        </td>
                                                                        <td align="center" class="ListHead">版本号
                                                                        </td>
                                                                        <td align="center" class="ListHead">位号
                                                                        </td>
                                                                        <td align="center" class="ListHead">替换编号
                                                                        </td>
                                                                        <td align="center" class="ListHead">数量
                                                                        </td>
                                                                        <td align="center" class="ListHead">停用
                                                                        </td>
                                                                        <td align="center" class="ListHead">可替代
                                                                        </td>
                                                                        <td align="center" class="ListHead">添加
                                                                        </td>
                                                                    </tr>
                                                                    <%=s_ProductsTable_BomDetail %>
                                                                    <asp:Label runat="server" ID="Lbl_Bom" Visible="false"></asp:Label>


                                                                </table>
                                                            </td>

                                                        </tr>

                                                        <tr>
                                                            <td colspan="4">
                                                                <div style="float: left">
                                                                    <asp:Label runat="server" ID="Lbl_Error"></asp:Label>
                                                                    <input id="Button4" runat="server" class="crmbutton small create" onclick="return btnGetBomProducts_onclick1()" type="button" value="选择材料" />
                                                                </div>
                                                                <div style="float: right">
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                    <input type="button" runat="server" id="Btn_Create" value="确   定" onserverclick="Btn_Create_OnServerClick" class="crmbutton small create" />
                                                                </div>
                                                                <div class="clearfloat" style="clear: both"></div>
                                                            </td>

                                                        </tr>

                                                    </table>
                                                </div>
                                            </td>
                                        </tr>

                                        <asp:Panel runat="server" ID="Pan_Update" Visible="false">
                                            <tr>
                                                <td width="16%" height="25" align="right" class="dvtCellLabel">明细：
                                                </td>
                                                <td class="dvtCellInfo" align="left" colspan="3">

                                                    <asp:TextBox ID="ProductsDetailDescription" runat="server" Style="display: none;"></asp:TextBox>
                                                    <iframe src='../eWebEditor/ewebeditor.htm?id=ProductsDetailDescription&style=gray'
                                                        frameborder='0' scrolling='no' width='620' height='350'></iframe>
                                                </td>
                                            </tr>
                                        </asp:Panel>

                                        <tr>
                                            <td colspan="2" class="detailedViewHeader">
                                                <b>适用成品:</b>
                                                <asp:TextBox ID="TextBox1" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td align="left" class="dvtCellInfo" style="text-align: left" colspan="2">
                                                <table id="Table2" width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="ListDetails">
                                                    <tr id="tr8">
                                                        <td align="center" class="ListHead">选择
                                                        </td>
                                                        <td align="center" class="ListHead">产品名称
                                                        </td>
                                                        <td align="center" class="ListHead">版本号
                                                        </td>
                                                        <td align="center" class="ListHead">单位
                                                        </td>
                                                        <td align="center" class="ListHead">相关单价
                                                        </td>
                                                        <td align="center" class="ListHead">数量
                                                        </td>
                                                        <td align="center" class="ListHead">是否采购
                                                        </td>
                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_ProductsRC"></asp:Label>
                                                    <asp:TextBox ID="Tbx_RCNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td height="25" align="right" class="dvtCellLabel">原产品:
                                            </td>
                                            <td align="left" class="dvtCellInfo">
                                                <asp:Label ID="Lbl_Detail" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <asp:Panel runat="server" ID="Pan_D" Visible="false">
                                            <tr>
                                                <td height="25" align="right" class="dvtCellLabel">操作:
                                                </td>
                                                <td align="left" class="dvtCellInfo">
                                                    <asp:CheckBox ID="Chk_add" runat="server" />共存<br />
                                                    <asp:CheckBox ID="Chk_IsReplace" runat="server" />替换<br />
                                                    <asp:CheckBox ID="Chk_Delete" runat="server" />删除
                                                </td>
                                            </tr>
                                        </asp:Panel>
                                        <tr>
                                            <asp:TextBox ID="Products_AlternativeNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

                                            <asp:TextBox ID="Products_AlternativeID" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                            <td height="25" align="right" class="dvtCellLabel">可替代物料:
                                            </td>
                                            <td align="left" class="dvtCellInfo" style="text-align: left">
                                                <asp:TextBox ID="Tbx_AlternativeProductsNum" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>

                                                <table id="ProductsAlternativeTable" width="100%" border="0" align="center" cellpadding="0"
                                                    cellspacing="0" class="ListDetails">
                                                    <tr id="tr7">
                                                        <td align="center" class="ListHead">工具
                                                        </td>
                                                        <td align="center" class="ListHead">产品名称
                                                        </td>
                                                        <td align="center" class="ListHead">版本号
                                                        </td>
                                                        <td align="center" class="ListHead">优先等级
                                                        </td>
                                                        <td align="center" class="ListHead">是否可替代
                                                        </td>
                                                    </tr>
                                                    <%=s_AlternativeDetail %>
                                                </table>
                                                <input id="Button6" class="crmbutton small create" runat="server" onclick="return btnGetAlternativeProductsNum_onclick()" type="button"
                                                    value="选择物料" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td height="25" align="right" class="dvtCellLabel">采购周期:
                                            </td>
                                            <td align="left" class="dvtCellInfo" style="text-align: left">
                                                <asp:TextBox ID="Tbx_NumCgDay" runat="Server" CssClass="Custom_Hidden" Text="0"></asp:TextBox>
                                                <table id="CgDay" width="100%" border="0" align="center" cellpadding="0"
                                                    cellspacing="0" class="ListDetails">
                                                    <tr id="tr6">
                                                        <td align="center" class="ListHead">工具
                                                        </td>
                                                        <td align="center" class="ListHead">最小值
                                                        </td>
                                                        <td align="center" class="ListHead">最大值
                                                        </td>
                                                        <td align="center" class="ListHead">天数
                                                        </td>
                                                    </tr>
                                                    <%=s_Cgdays %>
                                                </table>
                                                <input id="Button5" class="crmbutton small create" runat="server" onclick="return btnGetCgDay_onclick()" type="button"
                                                    value="添加" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="25" align="right" class="dvtCellLabel">操作:
                                            </td>
                                            <td align="left" class="dvtCellInfo" style="text-align: left">
                                                <a href="#" onclick="PageGo('KnetProductsSetting_Add.aspx')" target="_blank">创建配件</a>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <input id="hidden1" runat="server" type="hidden" name="hidden1" />
                                                <asp:TextBox runat="server" ID="Tbx_SampleID" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="TextBox2" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="TextBox3" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="truenum" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="Tbx_ID" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox runat="server" ID="Tbx_Type" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:Button ID="Button1" runat="server" Visible="False" Text="保 存" AccessKey="S" title="保存 [Alt+S]" OnClientClick="return check1();"
                                                    class="crmbutton small save" OnClick="Button1_Click" Style="width: 55px; height: 33px;" />
                                                <asp:Button ID="Button2" runat="server" Text="保 存" Visible="False" AccessKey="S" title="保存 [Alt+S]" OnClientClick="return check1();"
                                                    class="crmbutton small save" OnClick="Button2_OnClick" Style="width: 55px; height: 33px;" />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                       type="button" name="button" value="取 消" style="width: 55px; height: 33px;"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td align="right" valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
