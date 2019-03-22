<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sales_ShipWareOut_Add.aspx.cs"
    Inherits="Web_Sales_Sales_ShipWareOut_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script type="text/javascript" src="/Web/Js/ajax_func.js"></script>
    <link rel="stylesheet" href="/themes/softed/style.css" type="text/css">
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/include/scriptaculous/dom-drag.js"></script>
    <title>发货出库管理</title>
    <script language="JAVASCRIPT">
        function btnGetReturnValue_onclick() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var temp = window.showModalDialog("SelectSalesShipList.aspx?ID=" + intSeconds + "&State=1", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var temp = window.open("SelectSalesShipList.aspx?ID=" + intSeconds + "&State=1", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_SalesShip(temp) {
            if (temp != undefined) {
                var ss;
                ss = temp.split("|");
                $('ShipNoSelectValue').value = ss[0];
                $('Tbx_ShipNoName').value = ss[1];
            }
            else {
                $('ShipNoSelectValue').value = "";
                $('Tbx_ShipNoName').value = "";
            }
        }
        function btnGetReturnValue_onclick1() {
            /*选择客户*/
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "&callBack=SetReturnValueInOpenner_Customer2", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Customer2(tempd) {
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                $('Tbx_CustomerValue').value = ss[0];
                $('Tbx_CustomerName').value = ss[1];
            }
            else {
                $('Tbx_CustomerValue').value = "";
                $('Tbx_CustomerName').value = "";
            }
        }
        function ChangeShen() {
            var sel = document.getElementById("city");
            var v_Shen = $('sheng').value;
            var response = Knet_Web_Sales_KNet_Sales_ClientList_Add.GetShen(v_Shen);
            var length = sel.length;
            for (var i = length - 1; i >= 0; i--) {
                sel.remove(i);
            }
            var opt = new Option("", "");
            sel.options.add(opt);
            var st, sw;
            st = response.value.split("|");
            if (st.length > 0) {
                for (var i = 0; i < st.length - 1; i++) {
                    sw = st[i].split(",");
                    var opt = new Option(sw[1], sw[0]);
                    sel.options.add(opt);
                }
            }
        }
        function btnGetReturnValue_onclick2() {
            var today, seconds;
            today = new Date();
            intSeconds = today.getSeconds();
            //var tempd = window.showModalDialog("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            var tempd = window.open("/Web/Common/SelectCustomer.aspx?sID=" + intSeconds + "&callBack=SetReturnValueInOpenner_Customer1", "选择客户", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
        }
        function SetReturnValueInOpenner_Customer1(tempd) {
            if (tempd != undefined) {
                var ss;
                ss = tempd.split("#");
                $('Tbx_SCustomerValue').value = ss[0];
                $('Tbx_SCustomerName').value = ss[1];
                var response = Web_Sales_Sales_ShipWareOut_Add.GetLastOutWare($('Tbx_SCustomerValue').value);
                if (response.value != "") {
                    var TS = response.value.split(",");
                    $('Tbx_ContentPersonID').value = TS[0];
                    $('Tbx_ContentPerson').value = TS[1];
                    $('Tbx_Phone').value = TS[2];
                    $('ContractToAddress').value = TS[3];
                    $('Tbx_ShipType').value = TS[6];
                    $('Tbx_MaterNumber').value = TS[7];
                    $('Tbx_OrderNo').value = TS[8];
                    $('Tbx_PlanNo').value = TS[9];

                    objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                    for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                        if (objSelect_DutyPerson.options[i].value == TS[4]) {
                            objSelect_DutyPerson.options[i].selected = true;
                        }
                    }
                    objSelect = document.getElementById("ContractDeliveMethods")
                    for (var i = 0; i < objSelect.options.length; i++) {
                        if (objSelect.options[i].value == TS[5]) {
                            objSelect.options[i].selected = true;
                        }
                    }
                }
                else {
                    var Gs = ss[3].split(",");
                    var response = Web_Sales_Sales_ShipWareOut_Add.GetLinkMan(Gs[0]);
                    if (response.value != "") {
                        var TS = response.value.split(",");
                        $('Tbx_ContentPersonID').value = TS[0];
                        $('Tbx_ContentPerson').value = TS[1];
                        $('Tbx_Phone').value = TS[2];
                        $('ContractToAddress').value = TS[3];
                        objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                        for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                            if (objSelect_DutyPerson.options[i].value == TS[4]) {
                                objSelect_DutyPerson.options[i].selected = true;
                            }
                        }
                    }
                }
            }
            else {
                $('Tbx_SCustomerValue').value = "";
                $('Tbx_SCustomerName').value = "";
                $('Tbx_Phone').value = "";
                $('ContractToAddress').value = "";
                objSelect_DutyPerson = document.getElementById("Ddl_DutyPerson")
                for (var i = 0; i < objSelect_DutyPerson.options.length; i++) {
                    if (objSelect_DutyPerson.options[i].value == "") {
                        objSelect_DutyPerson.options[i].selected = true;
                    }
                }
                objSelect = document.getElementById("ContractDeliveMethods")
                for (var i = 0; i < objSelect.options.length; i++) {
                    if (objSelect.options[i].value == "") {
                        objSelect.options[i].selected = true;
                    }
                }
            }
        }
            function btnGetBackValue_onclick() {
                $('ContractNoSelectValue').value = "";
                $('ContractNoName').value = "";
            }
            function btnGetProducts_onclick() {
                var today, seconds;
                today = new Date();
                intSeconds = today.getSeconds();
                //var tempd = window.showModalDialog("SelectKNet_WareHouse_Ownall.aspx?sID=" + $("Xs_ProductsCode").value + "&isModiy=" + $("Tbx_ID").value + "&OutWareNo=" + $("OutWareNo").value + "&HouseNo=" + $("Ddl_HouseNo").value + " ", "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=yes; menubar=yes;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=1000px;dialogHeight=500px");
 
                    var tempd = window.open("SelectKNet_WareHouse_Ownall.aspx?sID=" + $("Xs_ProductsCode").value + "&isModiy=" + $("Tbx_ID").value + "&OutWareNo=" + $("OutWareNo").value + "&HouseNo=" + $("Ddl_HouseNo").value + " ", "选择产品", "width=1000px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
              
            }

            function Submitcheck() {
                var v_Num = "";
                v_Num = document.all("Tbx_Num").value;
                debugger;
                if (v_Num != "") {
                    var v_Right = "";
                    for (var i = 0; i < parseInt(v_Num) ; i++) {
                        if ($("KCNumber_" + i.toString() + "") != null)
                        {
                            var KcNumber = $("KCNumber_" + i.toString() + "").value;
                            var Number = $("Number_" + i.toString() + "").value
                            var BNumber = $("BNumber_" + i.toString() + "").value;
                            if (parseInt(KcNumber) < parseInt(Number) + parseInt(BNumber)) {
                                //v_Right = "1"
                                alert("不能小于库存数，请先补足库存！");
                                return false;
                            }
                        }
                    }
                    if (v_Right == "1") {
                        alert("不能小于库存数，请先补足库存！");
                        return false;
                    }
                }
            }
            function SetReturnValueInOpenner_WareHouse_Ownall(tempd) {
                if (tempd != undefined) {
                    var ss, s_Value, i_row;
                    ss = tempd.split("|");
                    i_row = myTable.rows.length;
                    s_ID = $("Xs_ProductsCode").value;
                    var v_Num = $("Tbx_Num").value;
                    for (var i = 0; i < ss.length - 1; i++) {
                        s_Value = ss[i].split(",");
                        var objRow = myTable.insertRow(i_row);
                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<A onclick=\"deleteRow(this)\" href=\"#\"><img src="/themes/softed/images/delete.gif" alt="CRMone" title="CRMone" border=0></a>';
                        objCel.className = "ListHeadDetails";
                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"hidden\"  Name=\"ID_' + parseInt(v_Num + i) + '\" value=' + s_Value[7] + '><input type=\"hidden\"  Name=\"ProductsName_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[0] + '\">' + s_Value[0];
                        objCel.className = "ListHeadDetails";
                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsBarCode_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[1] + '\">' + s_Value[13];

                        objCel.className = "ListHeadDetails";
                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"hidden\"  Name=\"ProductsName_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[0] + '\">' + s_Value[3];
                        objCel.className = "ListHeadDetails";
                    
                        var v_HouseNo=$('Ddl_HouseNo').value;
                        var response = Web_Sales_Sales_ShipWareOut_Add.GetKCNumber(s_Value[1] ,v_HouseNo);
                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"KCNumber_' + parseInt(v_Num + i) + '\" readonly=\"true\"  value=\"' + response.value + '\">';

                        objCel.className = "ListHeadDetails";
                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Number_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[4] + '\" >';
                        objCel.className = "ListHeadDetails";
                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"BNumber_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[6] + '\" >';
                        objCel.className = "ListHeadDetails";

                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"PlanNo_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[11] + '\" >';
                        objCel.className = "ListHeadDetails";

                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"OrderNo_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[8] + '\" >';
                        objCel.className = "ListHeadDetails";

                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"MaterNo_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[9] + '\" >';
                        objCel.className = "ListHeadDetails";

                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"CustomerProductsName_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[10] + '\" >';
                        objCel.className = "ListHeadDetails";

                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"IsFollow_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[12] + '\" >';
                        objCel.className = "ListHeadDetails";

                        var objCel = objRow.insertCell();
                        objCel.innerHTML = '<input type=\"text\" Class=\"detailedViewTextBox\" OnFocus=\"this.className=\'detailedViewTextBoxOn\'\" OnBlur=\"this.className=\'detailedViewTextBox\'\" style="width:70px;"  Name=\"Remarks_' + parseInt(v_Num + i) + '\" value=\"' + s_Value[5] + '\" >';
                        objCel.className = "ListHeadDetails";
                        i_row = i_row + 1;
                        s_ID = s_ID + s_Value[1] + ",";
                    }

                    $("Tbx_Num").value = v_Num + ss.length - 1;
                    $("Xs_ProductsCode").value = s_ID;
                    var v_HouseNO=s_Value[14];
                    if (v_HouseNO != "")
                    {
                        $("Ddl_HouseNo").value = v_HouseNO;
                    }
                }
            }

            function deleteRow(obj) {
                myTable.deleteRow(obj.parentElement.parentElement.rowIndex);
                var bm_num = "";
                var v_Num = $("Tbx_Num").value;

                for (i = 0; i < parseInt(v_Num) ; i++) {
                    bm_num += $("ProductsBarCode_" + i.toString() + "").value + ",";
                }
                $("Xs_ProductsCode").value = bm_num;
            }
            function btnGetContentPerson_onclick() {
                var s_Customer = "";
                s_Customer = $('Tbx_CustomerValue').value;
                //var temaap = window.showModalDialog("/Web/Common/SelectContentPerson.aspx?ID=" + s_Customer, "", "dialogtop=100px;dialogleft=120px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
                var temaap = window.open("/Web/Common/SelectContentPerson.aspx?ID=" + s_Customer, "选择联系人", "width=850px, height=500,top=150px,left=160px,toolbar=no, menubar=no, scrollbars=yes, resizable=yes, location=no, status=no,alwaysRaised=yes,depended=yes");
            }
            function SetReturnValueInOpenner_ContentPerson(temaap) {
                if (temaap != undefined) {
                    var sws;
                    sws = temaap.split(",");
                    $('Tbx_ContentPerson').value = sws[0];
                    $('Tbx_TelPhone').value = sws[1];
                    $('Tbx_Address').value = sws[3];
                }
                else {
                    $('Tbx_ContentPerson').value = "";
                    $('Tbx_TelPhone').value = "";
                    $('Tbx_Address').value = "";

                }
            }
            $("#Tbx_KDCode").keyup(function () {
                var value = $("#Tbx_KDCode").val();
                $("#search_list").html("");
                $.ajax({
                    type: "GET",
                    url: "/KuaiDi/GetData",
                    data: { no: value },
                    dataType: 'json',
                    timeout: 5000,
                    cache: false,
                    success: function (result) {
                        var html = "";
                        $.each(result, function (k, v) {
                            html += "<li>" + v + "</li>";
                        });
                        $("#search_list").html(html);
                        $("#search_list li").click(function (e) {
                            e.stopPropagation();
                            var _text = $(this).text();
                            $("#search_input").val(_text);
                            $("#search_list").hide();
                        });
                    },
                    error: function () {

                    }
                });
            });
            function searchFromSelect(o, str) {
                if (o.tagName == "SELECT") {
                    var opts = o.options;
                    str = str ? str : event.srcElement.innerText;

                    var tmp = '';
                    var kCode = event.keyCode;

                    if (str != "") {
                        if (kCode == 33 || kCode == 38 || kCode == 35)//向上翻页，方向键，end
                        {
                            o.selectedIndex = o.selectedIndex > 0 ? o.selectedIndex - 1 : 0;
                            if (kCode == 35) o.selectedIndex = opts.length - 1;
                            for (var i = o.selectedIndex; i >= 0; i--) {
                                tmp = opts(i % opts.length).text;
                                if (tmp.indexOf(str) >= 0) {
                                    o.selectedIndex = i % opts.length;
                                    return;
                                }
                            }
                        }
                        if (kCode == 34 || kCode == 40 || kCode == 36)//
                        {
                            o.selectedIndex++;
                            if (kCode == 36) o.selectedIndex = opts.length - 1;
                        }
                        for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex) ; i++) {
                            tmp = opts(i % opts.length).text;
                            if (tmp.indexOf(str) >= 0) {
                                o.selectedIndex = i % opts.length;
                                return;
                            }
                        }
                        o.selectedIndex = 0;
                    }
                }
            }

            function GetMoney() {
                var v_TotalMoney = $('Tbx_TotalMoney').value == "" ? "0" : $('Tbx_TotalMoney').value;

                var v_TotalNumber = $('Tbx_TotalNumber').value == "" ? "0" : $('Tbx_TotalNumber').value;
                var v_FMoney = $('Tbx_FMoney').value == "" ? "0" : $('Tbx_FMoney').value;
                var v_Money = $('Tbx_Money').value == "" ? "0" : $('Tbx_Money').value;
                if (v_FMoney != "0") {
                    var v_Money = parseFloat(v_TotalMoney) - parseFloat(v_FMoney)
                    $('Tbx_Money').value = v_Money;
                    var v_FPercent = parseFloat(v_FMoney) / parseFloat(v_TotalMoney);
                    var v_Percent = parseFloat(v_Money) / parseFloat(v_TotalMoney);
                    $('Tbx_FPercent').value = v_FPercent.toFixed(2);
                    $('Tbx_Percent').value = v_Percent.toFixed(2);
                }
                if (v_TotalNumber != "0") {
                    var v_Price = parseFloat(v_TotalMoney) / parseFloat(v_TotalNumber);
                    $('Tbx_Price').value = v_Percent.toFixed(2);
                }
            }
            function onSelect(o) {
                var v_SingleNum = 0, v_SingleBNum = 0, v_SingleTotalNum = 0, v_SingleWeight = 0, v_SingleVolume = 0;
                var v_TotalNum = 0, v_TotalWeight = 0, v_TotalVolume = 0, v_RCTotalNumber = 0, v_TotalMoney = 0;
                var WeightDetails = "", VolumeDetails = "", v_TotalMoneyDetails = "";
                var v_Num = $("Tbx_Num").value;
                for (var i = 0; i < parseInt(v_Num) ; i++) {
                    var s_ProductsBarCodes = $("ProductsBarCode_" + i.toString() + "").value;
                    var s_ProductsName = $("ProductsName_" + i.toString() + "").value;
                    var response = Web_Sales_Sales_ShipWareOut_Add.GetWeightVolume(s_ProductsBarCodes);
                    var v_WeightVolume = response.value.split(",");
                    v_SingleWeight = v_WeightVolume[0];
                    v_SingleVolume = v_WeightVolume[1];
                    v_SingleNum = $("Number_" + i.toString() + "").value;
                    v_SingleBNum = $("BNumber_" + i.toString() + "").value;
                    v_SingleTotalNum = parseInt(v_SingleNum) + parseInt(v_SingleBNum);

                    v_TotalWeight += parseFloat(v_SingleWeight) * v_SingleTotalNum;
                    v_TotalVolume += parseFloat(v_SingleVolume) * v_SingleTotalNum;
                    v_TotalNum += v_SingleTotalNum;
                    if (s_ProductsName != "电池") {
                        v_RCTotalNumber += v_SingleTotalNum;
                    }
                    WeightDetails += s_ProductsName + ":" + v_SingleWeight.toString() + " * " + v_SingleNum.toString() + "=" + parseFloat(v_SingleWeight) * v_SingleTotalNum + "\n";
                    VolumeDetails += s_ProductsName + ":" + v_SingleVolume.toString() + " * " + v_SingleNum.toString() + "=" + parseFloat(v_SingleVolume) * v_SingleTotalNum + "\n";
                }
                $("Tbx_TotalNumber").value = v_RCTotalNumber.toFixed(0).toString();
                $("Tbx_Weight").value = v_TotalWeight.toFixed(3).toString();
                $("Tbx_WeightDetails").value = WeightDetails;
                $("Tbx_Volume").value = v_TotalVolume.toString();
                $("Tbx_VolumeDetails").value = VolumeDetails;

                var v_FeightNum = $("Tbx_FeightNum").value;
                //选中物流事件
                var v_WuliuID = $("Wuliu_PriceID_" + o.value.toString() + "").value;
                var response1 = Web_Sales_Sales_ShipWareOut_Add.GetWuliuPriceDetails(v_WuliuID);
                var v_WuliuDetails = response1.value.split(",");
                $("Ddl_FSupp").value = v_WuliuDetails[0];
                Change();
                var v_WuiliuPrice = $("Wuliu_Price_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_PriceID").value = v_WuliuID;

                var v_WuiliuType = $("Wuliu_Type_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_Type").value = v_WuiliuType;
                var v_WuiliuTime = $("Wuliu_Time_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_Time").value = v_WuiliuTime;
                //单价
                var v_MinMoney = $("Wuliu_MinMoney_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_MinMoney").value = parseFloat(v_MinMoney).toFixed(2).toString();
                var v_PickUpCost = $("Wuliu_PickUpCost_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_PickUpCost").value = v_PickUpCost;
                var v_DeliveryFee = $("Wuliu_DeliveryFee_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_DeliveryFee").value = v_DeliveryFee;
                var v_UpstairsCost = $("Wuliu_UpstairsCost_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_UpstairsCost").value = v_UpstairsCost;
                var v_WareHouseEntry150Low = $("Wuliu_WareHouseEntry150Low_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_WareHouseEntry150Low").value = parseFloat(v_WareHouseEntry150Low).toFixed(2).toString();
                var v_Insured = $("Wuliu_Insured_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_Insured").value = v_Insured;

                var v_SignBill = $("Wuliu_SignBill_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_SignBill").value = v_SignBill;
                var v_BigLateTime = $("Wuliu_BigLateTime_" + o.value.toString() + "").value;
                $("Tbx_Wuliu_BigLateTime").value = v_BigLateTime;

                var v_Num = 0;
                if (parseFloat(v_TotalWeight) >= parseFloat(v_TotalVolume)) {
                    v_Num = v_TotalWeight;
                }
                else {
                    v_Num = v_TotalVolume;
                }

                $("Tbx_Wuliu_Price").value = parseFloat(v_WuiliuPrice);
                var v_WuiliuMoney = 0;
                v_WuiliuMoney= parseFloat(v_WuiliuPrice) * parseFloat(v_Num);
                $("Tbx_Wuliu_Money").value = v_WuiliuMoney.toFixed(2);
                var v_DeliveryFeeWeight = parseFloat(v_DeliveryFee) / 0.2;
                $("Tbx_FMoney").value = v_RCTotalNumber * 0.15;
                //送货费
                v_TotalMoneyDetails = " 单价" + parseFloat(v_Num) + "*" + (v_WuiliuPrice) + "+ 提货费：" + v_PickUpCost;

                //送货费重量
                v_TotalMoney = parseFloat(v_Num) * (v_WuiliuPrice) + parseFloat(v_PickUpCost);

                if (parseFloat(v_DeliveryFeeWeight) > 0) {
                    if (parseFloat(v_Num) <= parseFloat(v_DeliveryFeeWeight)) {
                        v_TotalMoney += parseFloat(v_DeliveryFee)
                        v_TotalMoneyDetails += "+ (重量不超过 " + v_DeliveryFeeWeight + " : " + v_DeliveryFee + ")";
                        $("Tbx_Wuliu_DeliveryFee").value = parseFloat(v_DeliveryFee);
                    }
                    else {
                        v_TotalMoney += parseFloat(v_Num) * 0.2
                        v_TotalMoneyDetails += "+ (重量超过" + v_DeliveryFeeWeight + ":" + parseFloat(v_DeliveryFee) + "*" + 0.2 + ")";
                        $("Tbx_Wuliu_DeliveryFee").value = parseFloat(v_Num) * 0.2;
                    }
                }
                else {
                    $("Tbx_Wuliu_DeliveryFee").value = 0;
                }
                v_TotalMoney += parseFloat(v_Num) * parseFloat(v_UpstairsCost);
                v_TotalMoneyDetails += "+上楼费：" + parseFloat(v_TotalWeight) + "*" + v_UpstairsCost;
                $("Tbx_Wuliu_UpstairsCost").value =  parseFloat(v_UpstairsCost);

                $("Tbx_Wuliu_UpstairsCostMoney").value = parseFloat(v_Num) * parseFloat(v_UpstairsCost);
            
            
                v_TotalMoney += parseFloat(v_WareHouseEntry150Low);  
                v_TotalMoneyDetails += "+进仓费：" + v_WareHouseEntry150Low;
                $("Tbx_Wuliu_WareHouseEntry150Low").value = parseFloat(v_WareHouseEntry150Low);
                //保价
                $("Tbx_Wuliu_Insured").value =parseFloat(v_Insured);
                $("Tbx_Wuliu_InsuredMoney").value = v_RCTotalNumber * 6 * parseFloat(v_Insured);
                v_TotalMoney += v_RCTotalNumber * 6 * parseFloat(v_Insured);
                v_TotalMoneyDetails += "+保价费：" + v_RCTotalNumber * 6 * parseFloat(v_Insured);

                //回签单
                $("Tbx_Wuliu_SignBill").value = parseFloat(v_SignBill).toFixed(2).toString();;
                v_TotalMoneyDetails += "+回签单费：" + v_SignBill;

                $("Tbx_TotalMoney").value = parseFloat(v_TotalMoney).toFixed(2).toString();
                $("Tbx_TotalMoneyDetails").value = v_TotalMoneyDetails;
                if (parseFloat(v_MinMoney) >= parseFloat(v_TotalMoney)) {
                    $("Tbx_TotalMoney").value = parseFloat(v_MinMoney).toFixed(2).toString();
                }
                else {
                    $("Tbx_TotalMoney").value = parseFloat(v_TotalMoney).toFixed(2).toString(); 
                }
                GetMoney();

            }
            function Calculation(type) {
                var v_TotalMoney = 0;
                var v_TotalWeight = $("Tbx_Weight").value;
                var v_TotalVolume = $("Tbx_Volume").value;
                var v_RCTotalNumber = $("Tbx_TotalNumber").value;

                var v_DeliveryFee = $("Tbx_Wuliu_DeliveryFee").value;
                var v_WuiliuPrice = $("Tbx_Wuliu_Price").value;
                var v_WuiliuMoney = $("Tbx_Wuliu_Money").value;
                var v_PickUpCost = $("Tbx_Wuliu_PickUpCost").value;
                var v_UpstairsCost = $("Tbx_Wuliu_UpstairsCost").value;
                var v_UpstairsCostMoney = $("Tbx_Wuliu_UpstairsCostMoney").value;
                var v_WareHouseEntry150Low = $("Tbx_Wuliu_WareHouseEntry150Low").value;
                var v_Insured = $("Tbx_Wuliu_Insured").value;
                var v_InsuredMoney = $("Tbx_Wuliu_InsuredMoney").value;
                var v_SignBill = $("Tbx_Wuliu_SignBill").value;
                var v_MinMoney = $("Tbx_Wuliu_MinMoney").value;
            
                var v_DeliveryFeeWeight = parseFloat(v_DeliveryFee) / 0.2;

                var v_Num = 0;
                if (parseFloat(v_TotalWeight) >= parseFloat(v_TotalVolume)) {
                    v_Num = v_TotalWeight;
                }
                else {
                    v_Num = v_TotalVolume;
                }
                if (type == 0) {
                    var v_Price = parseFloat(v_WuiliuMoney) / parseFloat(v_Num);
                    $("Tbx_Wuliu_Price").value = v_Price.toFixed(3);

                    var v_UpstairsPrice1 = parseFloat(v_UpstairsCostMoney) / parseFloat(v_Num);
                    $("Tbx_Wuliu_UpstairsCost").value = v_UpstairsPrice1.toFixed(3);
                    var v_InsuredPrice1 = parseFloat(v_InsuredMoney) / (parseFloat(v_RCTotalNumber)*6);
                    $("Tbx_Wuliu_Insured").value = v_InsuredPrice1.toFixed(3);
                }
                else {
                    $("Tbx_Wuliu_Money").value = parseFloat(v_WuiliuPrice) * parseFloat(v_Num);
                    $("Tbx_Wuliu_UpstairsCostMoney").value = parseFloat(v_UpstairsCost) * parseFloat(v_Num);
                    $("Tbx_Wuliu_InsuredMoney").value = parseFloat(v_Insured) * parseFloat(v_RCTotalNumber)*6;
                }
                $("Tbx_FMoney").value = v_RCTotalNumber * 0.15;
                //送货费
                //送货费重量
                v_TotalMoney = parseFloat(v_WuiliuPrice) * parseFloat(v_Num);
                v_TotalMoney += parseFloat(v_PickUpCost)
                v_TotalMoney += parseFloat(v_DeliveryFee)
                v_TotalMoney += parseFloat(v_UpstairsCostMoney);
                v_TotalMoney += parseFloat(v_WareHouseEntry150Low);
                v_TotalMoney += parseFloat(v_InsuredMoney);

                v_TotalMoney += parseFloat(v_SignBill);

                if (parseFloat(v_MinMoney) >= parseFloat(v_TotalMoney)) {
                    $("Tbx_TotalMoney").value =  v_MinMoney.toFixed(3).toString();
                }
                else {
                    $("Tbx_TotalMoney").value = v_TotalMoney.toFixed(3).toString();
                }
                GetMoney();
            }

            function Change() {
                var FSupp = $('Ddl_FSupp').value;
                var response = Web_Sales_Sales_ShipWareOut_Add.GetKDCode(FSupp);
                $('Drop_KD').value = response.value;
            }


            function ChangeHouseNo() {

                var v_HouseNo = $('Ddl_HouseNo').value;
                var v_Num = $("Tbx_Num").value;
                for (var i = 0; i < parseInt(v_Num) ; i++)
                {
                    if($("ProductsBarCode_"+i.toString()+""))
                    {
                        var v_HouseNo=$('Ddl_HouseNo').value;
                        var v_ProductsBarCode=$('ProductsBarCode_'+i.toString()+'').value;
                        var response = Web_Sales_Sales_ShipWareOut_Add.GetKCNumber(v_ProductsBarCode, v_HouseNo);
                        $('KCNumber_' + i.toString() + '').value = response.value;
                    }
                }
                $('Drop_KD').value = response.value;
            
            }

            function searchFromSelect(str) {
                var o = document.getElementById("Drop_KD");
                if (o.tagName == "SELECT") {
                    var opts = o.options;
                    str = str ? str : event.srcElement.innerText;

                    var tmp = '';
                    var kCode = event.keyCode;

                    if (str != "") {
                        if (kCode == 33 || kCode == 38 || kCode == 35)//向上翻页，方向键，end
                        {
                            o.selectedIndex = o.selectedIndex > 0 ? o.selectedIndex - 1 : 0;
                            if (kCode == 35) o.selectedIndex = opts.length - 1;
                            for (var i = o.selectedIndex; i >= 0; i--) {
                                tmp = opts(i % opts.length).text;
                                if (tmp.indexOf(str) >= 0) {
                                    o.selectedIndex = i % opts.length;
                                    return;
                                }
                            }
                        }
                        if (kCode == 34 || kCode == 40 || kCode == 36)//
                        {
                            o.selectedIndex++;
                            if (kCode == 36) o.selectedIndex = opts.length - 1;
                        }
                        for (var i = o.selectedIndex; i < (opts.length + o.selectedIndex) ; i++) {
                            tmp = opts(i % opts.length).text;
                            if (tmp.indexOf(str) >= 0) {
                                o.selectedIndex = i % opts.length;
                                return;
                            }
                        }
                        o.selectedIndex = 0;
                    }
                }
            }
            function Onload()
            {
                var v_ID = $('Tbx_ID').value;
                if (v_ID=="")
                {
                    btnGetProducts_onclick();
                }
            }
    </script>
    <script language="javascript" type="text/javascript" src="/Web/DatePicker/WdatePicker.js"></script>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0" onload="Onload();" ><%--onload="Onload();"--%>
    <form id="form1" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>发货出库 > <a class="hdrLink" href="Sales_ShipWareOut_Manage.aspx">发货出库</a>
                </td>
                <td width="100%" nowrap>
                    <asp:TextBox ID="Tbx_ID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_WuliuID" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Freight" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="Tbx_Type" runat="server" Style="display: none"></asp:TextBox>
                </td>
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
                    <div class="small" style="padding: 10px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">

                        <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>出库单信息
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
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>基本信息</b>
                                            </td>
                                        </tr>
                                        
                                        <asp:Panel runat="server" ID="Pan_DirectOut">
                                        <asp:Panel runat="server" ID="Panel2">
                                        <tr>
                                            <td class="dvtCellLabel">&nbsp;出库单号:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_DirectInNo" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px" MaxLength="40" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_CwCode" runat="server" Width="150px" Style="display: none"></asp:TextBox>(<font
                                                    color="red">*</font>)唯一性<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="发货单号不能为空"
                                                    ControlToValidate="Tbx_DirectInNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">发货单号:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="OutWareNo" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px" ReadOnly="true"></asp:TextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetReturnValue_onclick()" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">出库日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_DirectInDateTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="出库日期非空"
                                                    ControlToValidate="Tbx_DirectInDateTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">要求日期:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_ReceTime" runat="server" CssClass="Wdate" onClick="WdatePicker()"></asp:TextBox>(<font
                                                    color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="要求日期非空"
                                                    ControlToValidate="Tbx_ReceTime" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                            
                                        <tr>
                                            
                                        <td class="dvtCellLabel">
                                            &nbsp;发货类型:
                                        </td>
                                        <td class="dvtCellInfo">
                                            <asp:DropDownList ID="Ddl_ShipType" CssClass="detailedViewTextBox" runat="server"
                                                Width="100px">
                                            </asp:DropDownList>
                                            (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="发货类型不能为空"
                                                ControlToValidate="Ddl_ShipType" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </td>
                                            <td class="dvtCellLabel">付款方式:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Drop_Payment" runat="server" Width="300px">
                                                </asp:DropDownList>
                                                (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="付款方式非空"
                                                ControlToValidate="Drop_Payment" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                    </tr>
                                            </asp:Panel>
                                            <tr>
                                                    <td class="dvtCellLabel">开票方式:
                                                    </td>
                                                    <td class="dvtCellInfo" colspan="3">
                                                        <asp:DropDownList ID="Ddl_KpType" runat="server">
                                                        </asp:DropDownList>
                                                        (<font color="red">*</font>)
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server"
                                                            ErrorMessage="开票方式非空" ControlToValidate="Ddl_KpType" Display="Dynamic"></asp:RequiredFieldValidator>
                                                    </td>
                                            </tr>
                                        <asp:Panel runat="server" ID="Panel1">
                                        <tr>
                                            <td width="17%" class="dvtCellLabel">结算客户:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <pc:PTextBox ID="Tbx_CustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetReturnValue_onclick1()" />(<font color="red">*</font>)
                                            <pc:PTextBox ID="Tbx_CustomerValue" runat="server" CssClass="Custom_Hidden" />
                                            </td>
                                            <td width="17%" class="dvtCellLabel">收货客户:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <pc:PTextBox ID="Tbx_SCustomerName" runat="server" AllowEmpty="false" ValidError="客户不能为空"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="178px" ReadOnly="true"></pc:PTextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetReturnValue_onclick2()" />(<font color="red">*</font>)
                                            <pc:PTextBox ID="Tbx_SCustomerValue" runat="server" CssClass="Custom_Hidden" />
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="dvtCellLabel">责任人:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList runat="Server" ID="Ddl_DutyPerson">
                                                </asp:DropDownList>
                                                邮件提醒:
                                            <asp:CheckBox ID="Is_Mail" runat="server" Checked="true" Text="是" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Ddl_DutyPerson"
                                                    Display="Dynamic" ErrorMessage="责任人非空"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="17%" class="dvtCellLabel">仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_HouseNo" runat="server" Width="180px" onchange="ChangeHouseNo()">
                                                </asp:DropDownList>
                                                (<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="预出仓库不能为空"
                                                    ControlToValidate="Ddl_HouseNo" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">发货联系人:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="OutWareOursContact" runat="server" MaxLength="40" Width="180px"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'"></asp:TextBox>(<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="收货联系人不能为空"
                                                    ControlToValidate="OutWareOursContact" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">收货联系人:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_ContentPerson" runat="server" CssClass="detailedViewTextBox"
                                                    Width="180px" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    MaxLength="48"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_ContentPersonID" runat="server" CssClass="Custom_Hidden" MaxLength="48"></asp:TextBox>
                                                <img tabindex="8" src="/themes/softed/images/select.gif" alt="选择" title="选择"
                                                    onclick="return btnGetContentPerson_onclick()" />(<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="收货联系人不能为空"
                                                ControlToValidate="Tbx_ContentPerson" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellLabel">交货地点:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_Address" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="300px"></asp:TextBox>
                                                (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="交货地点不能为空"
                                                ControlToValidate="Tbx_Address" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="dvtCellLabel">交货方式:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="ContractDeliveMethods" runat="server" Width="150px">
                                                </asp:DropDownList>
                                                (<font color="red">*</font>)<br />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="交货方式不能为空"
                                                    ControlToValidate="ContractDeliveMethods" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">联系电话:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:TextBox ID="Tbx_TelPhone" runat="server" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="300px"></asp:TextBox>

                                                (<font color="red">*</font>)
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="联系电话不能为空"
                                                ControlToValidate="Tbx_TelPhone" Display="Dynamic"></asp:RequiredFieldValidator>
                                            </td>
                                            <td width="17%" class="dvtCellLabel">入库仓库:
                                            </td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Ddl_RkHouseNo" runat="server" Width="180px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">备注:
                                            </td>
                                            <td class="dvtCellInfo" colspan="4">
                                                <asp:TextBox ID="Tbx_DirectInRemarks" TextMode="MultiLine" runat="server" CssClass="detailedViewTextBox"
                                                    OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'"
                                                    cols="90" Rows="8"></asp:TextBox>
                                            </td>
                                        </tr>


                                        <tr runat="server" visible="false">
                                            <td align="right" class="dvtCellLabel">请选择图片:
                                            </td>
                                            <td colspan="3" align="left" class="dvtCellInfo">
                                                <asp:Label ID="Image1Big" runat="server" Text="" Visible="false"></asp:Label>
                                                <asp:Image ID="Image1" runat="server" Width="95px" Height="75px" />&nbsp;<input id="uploadFile"
                                                    type="file" runat="server" class="Boxx" size="30" />&nbsp;<input id="button" type="button"
                                                        value="上传图片" runat="server" class="crmbutton small create" onserverclick="button_ServerClick" causesvalidation="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>产品详细信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">


                                                <asp:TextBox ID="Xs_ProductsCode" runat="Server" CssClass="Custom_Hidden"></asp:TextBox>
                                                <asp:TextBox ID="Tbx_Num" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                <table id="myTable" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                    class="crmTable" style="height: 28px">
                                                    <!-- Header for the Product Details -->
                                                    <tr valign="top">
                                                        <td valign="top" class="ListHead" align="right" nowrap>
                                                            <b>工具</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>产品名称</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>料号</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>版本号</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>库存</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>数量</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>备品数量</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>件数</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>订单号</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>客户料号</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>客户型号</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>随货</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>备注</b>
                                                        </td>
                                                    </tr>
                                                    <%=s_MyTable_Detail %>
                                                </table>
                                                <table width="100%" border="0" align="center" cellpadding="5" cellspacing="0" class="crmTable">
                                                    <!-- Add Product Button -->
                                                    <tr>
                                                        <td colspan="3">①选择产品:
                                            <input type="button" id="Button_Select" name="Button_Select" runat="server" class="crmbutton small create" value="添加产品" onclick="btnGetProducts_onclick();" />

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                            </asp:Panel>
                                            </asp:Panel>
                                            <asp:Panel runat="server" ID="Pan_Wuliu" Visible="false">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>运费物流信息</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">编号：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_WuliuCode" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">日期：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_WuliuStime" runat="server"
                                                    CssClass="Wdate" onClick="WdatePicker()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellLabel">快递:</td>
                                            <td class="dvtCellInfo">
                                                <asp:DropDownList ID="Drop_KD" runat="server" CssClass="detailedViewTextBox" Width="150px"></asp:DropDownList>
                                                <input type="text" id="span" runat="server" onkeyup='searchFromSelect(this.value)'
                                                    onkeydown='window.event.cancelBubble = true;if(event.keyCode==13){return false;}' class="detailedViewTextBox"
                                                    style="width: 103px; height: 20; border: 1 solid #0000FF; overflow-y: auto"></input>
                                            </td>
                                            <td class="dvtCellLabel">单号:</td>
                                            <td class="dvtCellInfo">
                                                <pc:PTextBox runat="server" ID="Tbx_KDCode" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                    OnBlur="this.className='detailedViewTextBox'" Width="150px"></pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="16%" height="25" align="right" class="dvtCellLabel">所在省份:
                                            </td>
                                            <td width="35%" align="left" class="dvtCellInfo">
                                                <asp:DropDownList ID="sheng" Style="width: 150px" runat="server" OnChange="ChangeShen();">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="17%" align="right" class="dvtCellLabel">所在城区:
                                            </td>
                                            <td width="32%" align="left" class="dvtCellInfo">
                                                <asp:DropDownList ID="city" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">

                                                <asp:TextBox ID="Tbx_FeightNum" runat="Server" Text="0" CssClass="Custom_Hidden"></asp:TextBox>
                                                <table id="Table_Feight" width="100%" border="0" align="center" cellpadding="5" cellspacing="0"
                                                    class="crmTable" style="height: 28px">
                                                    <!-- Header for the Product Details -->
                                                    <tr valign="top">
                                                        <td valign="top" class="ListHead" align="right" rowspan="2" style="width: 3%;" nowrap>
                                                            <b>选择</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 90px" rowspan="2" nowrap>
                                                            <b>物流</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 10%;" rowspan="2" nowrap>
                                                            <b>类型</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 4%;" colspan="2" nowrap>
                                                            <b>费用</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 4%;" rowspan="2" nowrap>
                                                            <b>时间</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 4%;" rowspan="2" nowrap>
                                                            <b>最低收费</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 4%;" rowspan="2" nowrap>
                                                            <b>提货费</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 4%;" rowspan="2" nowrap>
                                                            <b>送货费</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 4%;" colspan="2" nowrap>
                                                            <b>上楼费</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 4%;" rowspan="2" nowrap>
                                                            <b>进仓费</b>
                                                        </td>
                                                        <td class="ListHead" style="width: 6%;" colspan="2" nowrap>
                                                            <b>保价</b>
                                                        </td>
                                                        <td class="ListHead" rowspan="2" nowrap>
                                                            <b>回签单</b>
                                                        </td>
                                                        <td class="ListHead" rowspan="2" nowrap>
                                                            <b>最晚发车</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="ListHead" nowrap>
                                                            <b>单价</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>金额</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>单价</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>金额</b>
                                                        </td>

                                                        <td class="ListHead" nowrap>
                                                            <b>单价</b>
                                                        </td>
                                                        <td class="ListHead" nowrap>
                                                            <b>金额</b>
                                                        </td>
                                                    </tr>

                                                    <asp:Label runat="server" ID="Lbl_Details"></asp:Label>

                                                    <tr valign="top">
                                                        <td valign="top" class="ListHeadDetails" align="right" style="width: 3%;" nowrap>&nbsp;
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 10%;" nowrap>
                                                            <asp:DropDownList runat="server" ID="Ddl_FSupp" CssClass="detailedViewTextBox" OnChange="Change()"></asp:DropDownList>

                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 10%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_PriceID" CssClass="Custom_Hidden"></pc:PTextBox>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_Type" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_Price" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_Money" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_Time" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_MinMoney" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_PickUpCost" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>

                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_DeliveryFee" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_UpstairsCost" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_UpstairsCostMoney" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_WareHouseEntry150Low" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_Insured" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" style="width: 6%;" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_InsuredMoney" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_SignBill" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox';Calculation(0)" Width="60px"></pc:PTextBox>
                                                        </td>
                                                        <td class="ListHeadDetails" nowrap>
                                                            <pc:PTextBox runat="server" ID="Tbx_Wuliu_BigLateTime" CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'"
                                                                OnBlur="this.className='detailedViewTextBox'" Width="60px"></pc:PTextBox>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>

                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">重量（KG）：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Weight" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';Calculation(1)" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" colspan="2">
                                                <pc:PTextBox ID="Tbx_WeightDetails" runat="server" TextMode="MultiLine"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="500px" Height="35px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">体积(M<sup>3</sup>)：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Volume" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';Calculation(1)" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left" colspan="2">
                                                <pc:PTextBox ID="Tbx_VolumeDetails" runat="server" TextMode="MultiLine"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="500px" Height="35px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">数量：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_TotalNumber" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';Calculation(1)" Width="200px">
                                                </pc:PTextBox>
                                            </td>

                                            <td width="15%" height="25" align="right" class="dvtCellLabel">单价：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Price" runat="server" ReadOnly="true"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">金额：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_TotalMoney" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>

                                            <td width="35%" class="dvtCellInfo" align="left" colspan="2">
                                                <pc:PTextBox ID="Tbx_TotalMoneyDetails" runat="server" TextMode="MultiLine"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="500px" Height="35px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">原因：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" colspan="3" align="left">
                                                <pc:PTextBox ID="Tbx_Description" runat="server" TextMode="MultiLine"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox'" Width="500px" Height="40px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">供应商承担：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_FPercent" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';" ReadOnly="true" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">承担金额：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_FMoney" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">士腾承担：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Percent" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                            <td width="15%" height="25" align="right" class="dvtCellLabel">承担金额：
                                            </td>
                                            <td width="35%" class="dvtCellInfo" align="left">
                                                <pc:PTextBox ID="Tbx_Money" runat="server"
                                                    CssClass="detailedViewTextBox" OnFocus="this.className='detailedViewTextBoxOn'" OnBlur="this.className='detailedViewTextBox';GetMoney()" Width="200px">
                                                </pc:PTextBox>
                                            </td>
                                        </tr>
                                            </asp:Panel>
                                        <tr>
                                            <td colspan="4" align="center">&nbsp;
                                <br />
                                                <asp:Button ID="Btn_Save" runat="server" Text="保 存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClientClick="return Submitcheck();" OnClick="Btn_SaveOnClick" Style="width: 55px; height: 33px;"  />
                                                <input title="取消 [Alt+X]" accesskey="X" class="crmbutton small cancel" onclick="window.history.back()"
                                                    type="button" name="button" value="取 消" style="width: 55px; height: 33px;">
                                            </td>
                                        </tr>

                                    </table>
                                </td>
                            </tr>
                        </table>
                </td>
                <td valign="top">
                    <img src="/themes/softed/images/showPanelTopRight.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
