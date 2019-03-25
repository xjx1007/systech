<%@ Page Language="C#" AutoEventWireup="true" CodeFile="1.aspx.cs" Inherits="Web_Report_Bill_Details_1" %>

<!DOCTYPE html>
<html>
<head>
    <title>固定表格表头 </title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="alternate icon" type="image/png" href="../../images/士腾.png" />
    <meta name="Generator" content="EditPlus">
    <meta name="Author" content="">
    <meta name="Keywords" content="">
    <meta name="Description" content="">
    <style type="text/css">
        div {
            overflow-y: scroll;
            overflow-x: scroll;
            margin-top: 5px;
            margin-left: 12px;
            padding-top: -2px;
            padding-bottom: 5px;
            background: none repeat scroll 0 0 #8F8F9A;
            border-spacing: 1px;
            margin: 0;
            clear: both;
            border: 1px solid #963;
            height: 551px;
            overflow: auto;
            width: 100%;
        }

        table {
            width: 100%;
            border-color: #d2f1ac;
            border-collapse: collapse;
            border-top: 0px solid #ffffff;
        }

        .fixedtd {
            position: relative;
            z-index: 1;
            background: #009933;
            text-align: center;
        }
    </style>
</head>
<body>
    <div>
        
<table border="0" cellspacing="0" cellpadding="0" width="100%" class="scrollTable" >
<tr class="tr_Head"><td class="fixedtd"  align=center  rowspan="2" colspan="1">序号</td>
<td class="fixedtd"  align=center rowspan="2" colspan="1">品名</td>
<td class="fixedtd"  align=center rowspan="2" colspan="1">规格</td>
<td class="fixedtd" align=center rowspan="2" colspan="1">单位</td>
<td class="fixedtd" align=center colspan="3">期初</td>
<td class="fixedtd" align=center colspan="3">采购入库</td>
<td class="fixedtd" align=center colspan="3">调拨入库</td>
<td class="fixedtd" align=center colspan="3">生产出库</td>
<td class="fixedtd" align=center colspan="3">部门领用</td>
<td class="fixedtd" align=center colspan="3">调拨出库</td>
<td class="fixedtd" align=center rowspan="2" colspan="1">没数量<br>有金额调整</td>
<td class="fixedtd" align=center colspan="3">期末</td>
<td class="fixedtd" align=center colspan="3">产品状态</td>
</tr>
<tr class="tr_Head">
<td class="fixedtd" align=center >数量</td>
<td class="fixedtd" align=center >单价</td>
<td class="fixedtd" align=center >金额</td>
<td class="fixedtd" align=center >数量</td>
<td class="fixedtd" align=center >单价</td>
<td class="fixedtd" align=center >金额</td>
<td class="fixedtd" align=center >数量</td>
<td class="fixedtd" align=center >单价</td>
<td class="fixedtd" align=center >金额</td>
<td class="fixedtd" align=center >数量</td>
<td class="fixedtd" align=center >单价</td>
<td class="fixedtd" align=center >金额</td>
<td class="fixedtd" align=center >数量</td>
<td class="fixedtd" align=center >单价</td>
<td class="fixedtd" align=center >金额</td>
<td class="fixedtd" align=center >数量</td>
<td class="fixedtd" align=center >单价</td>
<td class="fixedtd" align=center >金额</td>
<td class="fixedtd" align=center >数量</td>
<td class="fixedtd" align=center >单价</td>
<td class="fixedtd" align=center >金额</td>
<td class="fixedtd" align=center >正常</td>
<td class="fixedtd" align=center >滞销</td>
<td class="fixedtd" align=center >呆滞</td>
</tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>1</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061026213924&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1005（KX16214-7542（KB））&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.61538</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4338.46</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.61538</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4338.43</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.03</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup0" value="0"  id="radiogroup1_0_0" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_0"  value="D1604061026213924"><input type="radio" name="radiogroup0" value="1" id="radiogroup1_1_0" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup0" value="2" id="radiogroup1_2_0" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>2</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606280941586130&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1008（WL16214-5849（KB））&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.57240</td>
<td  class='thstyleLeftDetails' align=right  noWrap>57.24</td>
<td  class='thstyleLeftDetails' align=right  noWrap>80030</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.57265</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45829.14</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>78730</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.57265</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45084.74</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.57260</td>
<td  class='thstyleLeftDetails' align=right  noWrap>801.64</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup1" value="0"  id="radiogroup1_0_1" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_1"  value="D1606280941586130"><input type="radio" name="radiogroup1" value="1" id="radiogroup1_1_1" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup1" value="2" id="radiogroup1_2_1" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>3</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061027347443&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1009（WL16214-5805（KB））&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;10003</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.67519</td>
<td  class='thstyleLeftDetails' align=right  noWrap>6753.91</td>
<td  class='thstyleLeftDetails' align=right  noWrap>49921</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.67521</td>
<td  class='thstyleLeftDetails' align=right  noWrap>33707.32</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>41208</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.67521</td>
<td  class='thstyleLeftDetails' align=right  noWrap>27824.06</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18716</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.67521</td>
<td  class='thstyleLeftDetails' align=right  noWrap>12637.17</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup2" value="0"  id="radiogroup1_0_2" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_2"  value="D1604061027347443"><input type="radio" name="radiogroup2" value="1" id="radiogroup1_1_2" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup2" value="2" id="radiogroup1_2_2" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>4</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1607071455436153&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM1012（WL16214-5853（V））&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.46154</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1146.93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.46154</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1146.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup3" value="0"  id="radiogroup1_0_3" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_3"  value="D1607071455436153"><input type="radio" name="radiogroup3" value="1" id="radiogroup1_1_3" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup3" value="2" id="radiogroup1_2_3" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>5</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608171537261684&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-2003（WL16214-5883（KB））&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.66666</td>
<td  class='thstyleLeftDetails' align=right  noWrap>333.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.66666</td>
<td  class='thstyleLeftDetails' align=right  noWrap>333.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup4" value="0"  id="radiogroup1_0_4" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_4"  value="D1608171537261684"><input type="radio" name="radiogroup4" value="1" id="radiogroup1_1_4" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup4" value="2" id="radiogroup1_2_4" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>6</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1509141639432760&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41福建省网（WL16214-5705B（KB））&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.68376</td>
<td  class='thstyleLeftDetails' align=right  noWrap>63.59</td>
<td  class='thstyleLeftDetails' align=right  noWrap>407</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.66666</td>
<td  class='thstyleLeftDetails' align=right  noWrap>271.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.66984</td>
<td  class='thstyleLeftDetails' align=right  noWrap>334.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup5" value="0"  id="radiogroup1_0_5" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_5"  value="D1509141639432760"><input type="radio" name="radiogroup5" value="1" id="radiogroup1_1_5" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup5" value="2" id="radiogroup1_2_5" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>7</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1511121541203882&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>HB1531版（KX16214-7454）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.70941</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14489.63</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.70940</td>
<td  class='thstyleLeftDetails' align=right  noWrap>42599.57</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.70940</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24775.80</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45550</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.70941</td>
<td  class='thstyleLeftDetails' align=right  noWrap>32313.40</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup6" value="0"  id="radiogroup1_0_6" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_6"  value="D1511121541203882"><input type="radio" name="radiogroup6" value="1" id="radiogroup1_1_6" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup6" value="2" id="radiogroup1_2_6" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>8</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1510121632389994&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>JC25键模具（WL16214-5749）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>30520</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.52137</td>
<td  class='thstyleLeftDetails' align=right  noWrap>15912.14</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.52137</td>
<td  class='thstyleLeftDetails' align=right  noWrap>13294.94</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5020</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.52135</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2617.20</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup7" value="0"  id="radiogroup1_0_7" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_7"  value="D1510121632389994"><input type="radio" name="radiogroup7" value="1" id="radiogroup1_1_7" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup7" value="2" id="radiogroup1_2_7" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>9</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604070906375944&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-5402-01（A94075）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;150</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3.07693</td>
<td  class='thstyleLeftDetails' align=right  noWrap>461.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>150</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3.07693</td>
<td  class='thstyleLeftDetails' align=right  noWrap>461.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup8" value="0"  id="radiogroup1_0_8" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_8"  value="D1604070906375944"><input type="radio" name="radiogroup8" value="1" id="radiogroup1_1_8" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup8" value="2" id="radiogroup1_2_8" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>10</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608160909538965&HouseNo=130595639097577148' target="_blank">PCB</td>
<td  class='thstyleLeftDetails' align=left  noWrap>WH-51（KX16214-7862A（KB））&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.97949</td>
<td  class='thstyleLeftDetails' align=right  noWrap>979.49</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.97949</td>
<td  class='thstyleLeftDetails' align=right  noWrap>979.49</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup9" value="0"  id="radiogroup1_0_9" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_9"  value="D1608160909538965"><input type="radio" name="radiogroup9" value="1" id="radiogroup1_1_9" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup9" value="2" id="radiogroup1_2_9" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>11</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504211628564576&HouseNo=130595639097577148' target="_blank">包装袋</td>
<td  class='thstyleLeftDetails' align=left  noWrap>EPE珍珠棉袋&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;11000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.04420</td>
<td  class='thstyleLeftDetails' align=right  noWrap>486.23</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>11000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.04420</td>
<td  class='thstyleLeftDetails' align=right  noWrap>486.23</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup10" value="0"  id="radiogroup1_0_10" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_10"  value="D1504211628564576"><input type="radio" name="radiogroup10" value="1" id="radiogroup1_1_10" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup10" value="2" id="radiogroup1_2_10" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>12</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1401101126281974&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-1601-01(河北)&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.16240</td>
<td  class='thstyleLeftDetails' align=right  noWrap>23741.99</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60080</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.16239</td>
<td  class='thstyleLeftDetails' align=right  noWrap>69836.59</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.16239</td>
<td  class='thstyleLeftDetails' align=right  noWrap>40596.48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45580</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.16240</td>
<td  class='thstyleLeftDetails' align=right  noWrap>52982.10</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup11" value="0"  id="radiogroup1_0_11" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_11"  value="D1401101126281974"><input type="radio" name="radiogroup11" value="1" id="radiogroup1_1_11" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup11" value="2" id="radiogroup1_2_11" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>13</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1607071453301598&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-2302-00（黑龙江农垦导电胶）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.72649</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1805.34</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.72649</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1805.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup12" value="0"  id="radiogroup1_0_12" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_12"  value="D1607071453301598"><input type="radio" name="radiogroup12" value="1" id="radiogroup1_1_12" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup12" value="2" id="radiogroup1_2_12" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>14</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606280940559434&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-2400-00（河北导电胶）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.68390</td>
<td  class='thstyleLeftDetails' align=right  noWrap>68.39</td>
<td  class='thstyleLeftDetails' align=right  noWrap>80030</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.68376</td>
<td  class='thstyleLeftDetails' align=right  noWrap>54721.35</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>78730</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.68376</td>
<td  class='thstyleLeftDetails' align=right  noWrap>53832.43</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.68379</td>
<td  class='thstyleLeftDetails' align=right  noWrap>957.31</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup13" value="0"  id="radiogroup1_0_13" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_13"  value="D1606280940559434"><input type="radio" name="radiogroup13" value="1" id="radiogroup1_1_13" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup13" value="2" id="radiogroup1_2_13" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>15</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061034302977&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-4200-00（江苏农网导电胶）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.02564</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7230.77</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.02564</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7230.76</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup14" value="0"  id="radiogroup1_0_14" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_14"  value="D1604061034302977"><input type="radio" name="radiogroup14" value="1" id="radiogroup1_1_14" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup14" value="2" id="radiogroup1_2_14" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>16</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061036295267&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-4500-00（福建省网导电胶）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;10003</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.47867</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14791.18</td>
<td  class='thstyleLeftDetails' align=right  noWrap>50921</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.47863</td>
<td  class='thstyleLeftDetails' align=right  noWrap>75293.44</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>41208</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.47864</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60931.80</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>19716</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.47864</td>
<td  class='thstyleLeftDetails' align=right  noWrap>29152.82</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup15" value="0"  id="radiogroup1_0_15" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_15"  value="D1604061036295267"><input type="radio" name="radiogroup15" value="1" id="radiogroup1_1_15" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup15" value="2" id="radiogroup1_2_15" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>17</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608101513299153&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-4700-00（导电胶）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.42736</td>
<td  class='thstyleLeftDetails' align=right  noWrap>713.68</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.42736</td>
<td  class='thstyleLeftDetails' align=right  noWrap>713.68</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup16" value="0"  id="radiogroup1_0_16" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_16"  value="D1608101513299153"><input type="radio" name="radiogroup16" value="1" id="radiogroup1_1_16" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup16" value="2" id="radiogroup1_2_16" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>18</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504070936102072&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-5600（福建省导电胶白色）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.36753</td>
<td  class='thstyleLeftDetails' align=right  noWrap>127.18</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.36753</td>
<td  class='thstyleLeftDetails' align=right  noWrap>127.18</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup17" value="0"  id="radiogroup1_0_17" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_17"  value="D1504070936102072"><input type="radio" name="radiogroup17" value="1" id="radiogroup1_1_17" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup17" value="2" id="radiogroup1_2_17" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>19</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1412301039095502&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-8818-01（福建简易版）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.17948</td>
<td  class='thstyleLeftDetails' align=right  noWrap>589.74</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.17948</td>
<td  class='thstyleLeftDetails' align=right  noWrap>589.74</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup18" value="0"  id="radiogroup1_0_18" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_18"  value="D1412301039095502"><input type="radio" name="radiogroup18" value="1" id="radiogroup1_1_18" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup18" value="2" id="radiogroup1_2_18" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>20</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1507090932437204&HouseNo=130595639097577148' target="_blank">导电胶</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-8834-02（厦门简易版）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>30020</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.30769</td>
<td  class='thstyleLeftDetails' align=right  noWrap>39256.91</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.30769</td>
<td  class='thstyleLeftDetails' align=right  noWrap>32692.25</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5020</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.30770</td>
<td  class='thstyleLeftDetails' align=right  noWrap>6564.66</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup19" value="0"  id="radiogroup1_0_19" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_19"  value="D1507090932437204"><input type="radio" name="radiogroup19" value="1" id="radiogroup1_1_19" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup19" value="2" id="radiogroup1_2_19" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>21</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1206131626094137&HouseNo=130595639097577148' target="_blank">电池</td>
<td  class='thstyleLeftDetails' align=left  noWrap>双鹿碳性7#&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;125310</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.19658</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24634.03</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>67110</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.19658</td>
<td  class='thstyleLeftDetails' align=right  noWrap>13192.49</td>
<td  class='thstyleLeftDetails' align=right  noWrap>20000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.19658</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3931.60</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>38200</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.19660</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7509.94</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup20" value="0"  id="radiogroup1_0_20" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_20"  value="D1206131626094137"><input type="radio" name="radiogroup20" value="1" id="radiogroup1_1_20" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup20" value="2" id="radiogroup1_2_20" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>22</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606280939407066&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1008灰电池盖（24系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>16.40</td>
<td  class='thstyleLeftDetails' align=right  noWrap>80030</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16239</td>
<td  class='thstyleLeftDetails' align=right  noWrap>12996.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>78730</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16240</td>
<td  class='thstyleLeftDetails' align=right  noWrap>12785.75</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16213</td>
<td  class='thstyleLeftDetails' align=right  noWrap>226.98</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup21" value="0"  id="radiogroup1_0_21" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_21"  value="D1606280939407066"><input type="radio" name="radiogroup21" value="1" id="radiogroup1_1_21" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup21" value="2" id="radiogroup1_2_21" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>23</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061018522795&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1009白电池盖（45系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;10003</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09405</td>
<td  class='thstyleLeftDetails' align=right  noWrap>940.77</td>
<td  class='thstyleLeftDetails' align=right  noWrap>50421</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09402</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4740.45</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>41208</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09402</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3874.37</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>19216</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09403</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1806.85</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup22" value="0"  id="radiogroup1_0_22" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_22"  value="D1604061018522795"><input type="radio" name="radiogroup22" value="1" id="radiogroup1_1_22" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup22" value="2" id="radiogroup1_2_22" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>24</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606301527061453&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1012黑电池盖（23系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09402</td>
<td  class='thstyleLeftDetails' align=right  noWrap>233.63</td>
<td  class='thstyleLeftDetails' align=right  noWrap>100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9.40</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09402</td>
<td  class='thstyleLeftDetails' align=right  noWrap>233.64</td>
<td  class='thstyleLeftDetails' align=right  noWrap>100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9.40</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>-0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup23" value="0"  id="radiogroup1_0_23" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_23"  value="D1606301527061453"><input type="radio" name="radiogroup23" value="1" id="radiogroup1_1_23" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup23" value="2" id="radiogroup1_2_23" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>25</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606201431318976&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1015黑电池盖（25系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.14530</td>
<td  class='thstyleLeftDetails' align=right  noWrap>726.50</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.14530</td>
<td  class='thstyleLeftDetails' align=right  noWrap>726.50</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup24" value="0"  id="radiogroup1_0_24" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_24"  value="D1606201431318976"><input type="radio" name="radiogroup24" value="1" id="radiogroup1_1_24" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup24" value="2" id="radiogroup1_2_24" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>26</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1505251629264119&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM15A电池盖黑色&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.15375</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7.38</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.15375</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7.38</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup25" value="0"  id="radiogroup1_0_25" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_25"  value="D1505251629264119"><input type="radio" name="radiogroup25" value="1" id="radiogroup1_1_25" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup25" value="2" id="radiogroup1_2_25" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>27</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608101510494739&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-2003灰电池盖（47系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11966</td>
<td  class='thstyleLeftDetails' align=right  noWrap>59.83</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11966</td>
<td  class='thstyleLeftDetails' align=right  noWrap>59.83</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup26" value="0"  id="radiogroup1_0_26" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_26"  value="D1608101510494739"><input type="radio" name="radiogroup26" value="1" id="radiogroup1_1_26" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup26" value="2" id="radiogroup1_2_26" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>28</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1503161019524088&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM32模具电池盖（德州江苏）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.05983</td>
<td  class='thstyleLeftDetails' align=right  noWrap>421.79</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.05983</td>
<td  class='thstyleLeftDetails' align=right  noWrap>421.80</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>-0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup27" value="0"  id="radiogroup1_0_27" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_27"  value="D1503161019524088"><input type="radio" name="radiogroup27" value="1" id="radiogroup1_1_27" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup27" value="2" id="radiogroup1_2_27" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>29</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504131354043534&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41白电池盖（56系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.13677</td>
<td  class='thstyleLeftDetails' align=right  noWrap>81.24</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.13677</td>
<td  class='thstyleLeftDetails' align=right  noWrap>81.24</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup28" value="0"  id="radiogroup1_0_28" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_28"  value="D1504131354043534"><input type="radio" name="radiogroup28" value="1" id="radiogroup1_1_28" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup28" value="2" id="radiogroup1_2_28" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>30</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504070941191027&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41电池盖（56系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2340</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.12821</td>
<td  class='thstyleLeftDetails' align=right  noWrap>300.00</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2340</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.12821</td>
<td  class='thstyleLeftDetails' align=right  noWrap>300.00</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup29" value="0"  id="radiogroup1_0_29" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_29"  value="D1504070941191027"><input type="radio" name="radiogroup29" value="1" id="radiogroup1_1_29" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup29" value="2" id="radiogroup1_2_29" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>31</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504141316555352&HouseNo=130595639097577148' target="_blank">电池盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>WH-051电池盖（54系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>85.47</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>85.47</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup30" value="0"  id="radiogroup1_0_30" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_30"  value="D1504141316555352"><input type="radio" name="radiogroup30" value="1" id="radiogroup1_1_30" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup30" value="2" id="radiogroup1_2_30" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>32</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1509081533038085&HouseNo=130595639097577148' target="_blank">发射管</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SWIR-3408-L（迅光）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;5085</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11884</td>
<td  class='thstyleLeftDetails' align=right  noWrap>604.30</td>
<td  class='thstyleLeftDetails' align=right  noWrap>78030</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11880</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9270.23</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>81715</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11881</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9708.56</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11855</td>
<td  class='thstyleLeftDetails' align=right  noWrap>165.97</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup31" value="0"  id="radiogroup1_0_31" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_31"  value="D1509081533038085"><input type="radio" name="radiogroup31" value="1" id="radiogroup1_1_31" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup31" value="2" id="radiogroup1_2_31" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>33</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1212261421213991&HouseNo=130595639097577148' target="_blank">发射管</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SWIR3410（迅光长头6mm）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;22425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11881</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2664.34</td>
<td  class='thstyleLeftDetails' align=right  noWrap>88600</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11880</td>
<td  class='thstyleLeftDetails' align=right  noWrap>10525.98</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11880</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7178.49</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>50600</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11881</td>
<td  class='thstyleLeftDetails' align=right  noWrap>6011.83</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup32" value="0"  id="radiogroup1_0_32" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_32"  value="D1212261421213991"><input type="radio" name="radiogroup32" value="1" id="radiogroup1_1_32" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup32" value="2" id="radiogroup1_2_32" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>34</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1212140832293183&HouseNo=130595639097577148' target="_blank">发射管</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SWIR34102（迅光短头）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;1777</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11880</td>
<td  class='thstyleLeftDetails' align=right  noWrap>211.11</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1777</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11880</td>
<td  class='thstyleLeftDetails' align=right  noWrap>211.11</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup33" value="0"  id="radiogroup1_0_33" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_33"  value="D1212140832293183"><input type="radio" name="radiogroup33" value="1" id="radiogroup1_1_33" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup33" value="2" id="radiogroup1_2_33" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>35</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1505111404325763&HouseNo=130595639097577148' target="_blank">发射管</td>
<td  class='thstyleLeftDetails' align=left  noWrap>YIR305AW（天佳无帽檐8.7mm）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;3761</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.08125</td>
<td  class='thstyleLeftDetails' align=right  noWrap>305.57</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3761</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.08125</td>
<td  class='thstyleLeftDetails' align=right  noWrap>305.57</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup34" value="0"  id="radiogroup1_0_34" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_34"  value="D1505111404325763"><input type="radio" name="radiogroup34" value="1" id="radiogroup1_1_34" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup34" value="2" id="radiogroup1_2_34" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>36</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061116301089&HouseNo=130595639097577148' target="_blank">发射管</td>
<td  class='thstyleLeftDetails' align=left  noWrap>YIR305BSS（长头8.7mm60°角）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;46060</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11965</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5510.99</td>
<td  class='thstyleLeftDetails' align=right  noWrap>27050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11966</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3236.75</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>48258</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11965</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5774.09</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24852</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.11965</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2973.65</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup35" value="0"  id="radiogroup1_0_35" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_35"  value="D1604061116301089"><input type="radio" name="radiogroup35" value="1" id="radiogroup1_1_35" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup35" value="2" id="radiogroup1_2_35" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>37</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1412031329046784&HouseNo=130595639097577148' target="_blank">发射管</td>
<td  class='thstyleLeftDetails' align=left  noWrap>YIR305C（天佳长头8.7mm）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.08119</td>
<td  class='thstyleLeftDetails' align=right  noWrap>405.97</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.08119</td>
<td  class='thstyleLeftDetails' align=right  noWrap>405.97</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup36" value="0"  id="radiogroup1_0_36" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_36"  value="D1412031329046784"><input type="radio" name="radiogroup36" value="1" id="radiogroup1_1_36" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup36" value="2" id="radiogroup1_2_36" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>38</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061038215101&HouseNo=130595639097577148' target="_blank">锅仔键</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1005-00（30个按键）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.61538</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4338.46</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.61538</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4338.43</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.03</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup37" value="0"  id="radiogroup1_0_37" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_37"  value="D1604061038215101"><input type="radio" name="radiogroup37" value="1" id="radiogroup1_1_37" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup37" value="2" id="radiogroup1_2_37" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>39</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1607051715422095&HouseNo=130595639097577148' target="_blank">锅仔键</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-2302-00（30个按键）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.29914</td>
<td  class='thstyleLeftDetails' align=right  noWrap>743.37</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.29914</td>
<td  class='thstyleLeftDetails' align=right  noWrap>743.36</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup38" value="0"  id="radiogroup1_0_38" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_38"  value="D1607051715422095"><input type="radio" name="radiogroup38" value="1" id="radiogroup1_1_38" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup38" value="2" id="radiogroup1_2_38" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>40</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1507210834524967&HouseNo=130595639097577148' target="_blank">锅仔键</td>
<td  class='thstyleLeftDetails' align=left  noWrap>MRC-593-01锅仔5键&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>30520</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.13675</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4173.68</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.13675</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3487.13</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5020</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.13676</td>
<td  class='thstyleLeftDetails' align=right  noWrap>686.55</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup39" value="0"  id="radiogroup1_0_39" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_39"  value="D1507210834524967"><input type="radio" name="radiogroup39" value="1" id="radiogroup1_1_39" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup39" value="2" id="radiogroup1_2_39" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>41</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504070934102256&HouseNo=130595639097577148' target="_blank">锅仔键</td>
<td  class='thstyleLeftDetails' align=left  noWrap>福建省锅仔41键（MRC-5600）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>71.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>71.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup40" value="0"  id="radiogroup1_0_40" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_40"  value="D1504070934102256"><input type="radio" name="radiogroup40" value="1" id="radiogroup1_1_40" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup40" value="2" id="radiogroup1_2_40" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>42</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1401101128416186&HouseNo=130595639097577148' target="_blank">锅仔键</td>
<td  class='thstyleLeftDetails' align=left  noWrap>河北新模具（200g）MRC-1601&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.82906</td>
<td  class='thstyleLeftDetails' align=right  noWrap>16933.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60080</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.82906</td>
<td  class='thstyleLeftDetails' align=right  noWrap>49809.91</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.82906</td>
<td  class='thstyleLeftDetails' align=right  noWrap>28954.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45580</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.82906</td>
<td  class='thstyleLeftDetails' align=right  noWrap>37788.53</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup41" value="0"  id="radiogroup1_0_41" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_41"  value="D1401101128416186"><input type="radio" name="radiogroup41" value="1" id="radiogroup1_1_41" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup41" value="2" id="radiogroup1_2_41" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>43</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604060928174554&HouseNo=130595639097577148' target="_blank">键帽</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1005键帽（江苏）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7200</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.08547</td>
<td  class='thstyleLeftDetails' align=right  noWrap>615.38</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.08547</td>
<td  class='thstyleLeftDetails' align=right  noWrap>602.56</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>150</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.08547</td>
<td  class='thstyleLeftDetails' align=right  noWrap>12.82</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup42" value="0"  id="radiogroup1_0_42" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_42"  value="D1604060928174554"><input type="radio" name="radiogroup42" value="1" id="radiogroup1_1_42" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup42" value="2" id="radiogroup1_2_42" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>44</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604060947274129&HouseNo=130595639097577148' target="_blank">键帽</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1005键帽烫金（江苏）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7200</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1230.77</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1205.13</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>150</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17093</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25.64</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup43" value="0"  id="radiogroup1_0_43" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_43"  value="D1604060947274129"><input type="radio" name="radiogroup43" value="1" id="radiogroup1_1_43" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup43" value="2" id="radiogroup1_2_43" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>45</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606301527373212&HouseNo=130595639097577148' target="_blank">键帽</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1012黑键帽（23系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.05983</td>
<td  class='thstyleLeftDetails' align=right  noWrap>148.67</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.05983</td>
<td  class='thstyleLeftDetails' align=right  noWrap>148.67</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup44" value="0"  id="radiogroup1_0_44" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_44"  value="D1606301527373212"><input type="radio" name="radiogroup44" value="1" id="radiogroup1_1_44" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup44" value="2" id="radiogroup1_2_44" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>46</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608101511572492&HouseNo=130595639097577148' target="_blank">键帽</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-2003键帽（47系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.05982</td>
<td  class='thstyleLeftDetails' align=right  noWrap>29.91</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.05982</td>
<td  class='thstyleLeftDetails' align=right  noWrap>29.91</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup45" value="0"  id="radiogroup1_0_45" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_45"  value="D1608101511572492"><input type="radio" name="radiogroup45" value="1" id="radiogroup1_1_45" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup45" value="2" id="radiogroup1_2_45" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>47</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1607071454232818&HouseNo=130595639097577148' target="_blank">面贴</td>
<td  class='thstyleLeftDetails' align=left  noWrap>面贴（MRC-2302）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17949</td>
<td  class='thstyleLeftDetails' align=right  noWrap>446.03</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17949</td>
<td  class='thstyleLeftDetails' align=right  noWrap>446.03</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup46" value="0"  id="radiogroup1_0_46" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_46"  value="D1607071454232818"><input type="radio" name="radiogroup46" value="1" id="radiogroup1_1_46" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup46" value="2" id="radiogroup1_2_46" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>48</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604051800401265&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1005上盖（江苏）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35897</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2530.77</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35897</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2530.74</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.03</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup47" value="0"  id="radiogroup1_0_47" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_47"  value="D1604051800401265"><input type="radio" name="radiogroup47" value="1" id="radiogroup1_1_47" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup47" value="2" id="radiogroup1_2_47" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>49</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606280938229263&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1008灰上盖（24系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32280</td>
<td  class='thstyleLeftDetails' align=right  noWrap>32.28</td>
<td  class='thstyleLeftDetails' align=right  noWrap>80030</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32479</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25992.64</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>78730</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32478</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25569.94</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32499</td>
<td  class='thstyleLeftDetails' align=right  noWrap>454.98</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup48" value="0"  id="radiogroup1_0_48" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_48"  value="D1606280938229263"><input type="radio" name="radiogroup48" value="1" id="radiogroup1_1_48" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup48" value="2" id="radiogroup1_2_48" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>50</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604060949351916&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1009白上盖（45系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;10003</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35898</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3590.91</td>
<td  class='thstyleLeftDetails' align=right  noWrap>50421</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35897</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18099.83</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>41208</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35898</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14792.85</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>19216</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35897</td>
<td  class='thstyleLeftDetails' align=right  noWrap>6897.89</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup49" value="0"  id="radiogroup1_0_49" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_49"  value="D1604060949351916"><input type="radio" name="radiogroup49" value="1" id="radiogroup1_1_49" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup49" value="2" id="radiogroup1_2_49" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>51</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606301517416451&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1012黑上盖（23系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.27351</td>
<td  class='thstyleLeftDetails' align=right  noWrap>679.66</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.27350</td>
<td  class='thstyleLeftDetails' align=right  noWrap>273.50</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.27350</td>
<td  class='thstyleLeftDetails' align=right  noWrap>679.65</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.27350</td>
<td  class='thstyleLeftDetails' align=right  noWrap>273.50</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup50" value="0"  id="radiogroup1_0_50" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_50"  value="D1606301517416451"><input type="radio" name="radiogroup50" value="1" id="radiogroup1_1_50" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup50" value="2" id="radiogroup1_2_50" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>52</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606201430381197&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1015黑上盖（25系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.31624</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1581.20</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.31624</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1581.20</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup51" value="0"  id="radiogroup1_0_51" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_51"  value="D1606201430381197"><input type="radio" name="radiogroup51" value="1" id="radiogroup1_1_51" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup51" value="2" id="radiogroup1_2_51" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>53</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1505251624434395&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM15A上盖黑色&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.44438</td>
<td  class='thstyleLeftDetails' align=right  noWrap>21.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.44438</td>
<td  class='thstyleLeftDetails' align=right  noWrap>21.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup52" value="0"  id="radiogroup1_0_52" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_52"  value="D1505251624434395"><input type="radio" name="radiogroup52" value="1" id="radiogroup1_1_52" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup52" value="2" id="radiogroup1_2_52" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>54</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608101508542975&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-2003白上盖（47系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.47864</td>
<td  class='thstyleLeftDetails' align=right  noWrap>239.32</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.47864</td>
<td  class='thstyleLeftDetails' align=right  noWrap>239.32</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup53" value="0"  id="radiogroup1_0_53" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_53"  value="D1608101508542975"><input type="radio" name="radiogroup53" value="1" id="radiogroup1_1_53" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup53" value="2" id="radiogroup1_2_53" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>55</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504131352427589&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41白上盖（56系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35042</td>
<td  class='thstyleLeftDetails' align=right  noWrap>208.15</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35042</td>
<td  class='thstyleLeftDetails' align=right  noWrap>208.15</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup54" value="0"  id="radiogroup1_0_54" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_54"  value="D1504131352427589"><input type="radio" name="radiogroup54" value="1" id="radiogroup1_1_54" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup54" value="2" id="radiogroup1_2_54" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>56</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504070939569215&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41上盖（56系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2340</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.34188</td>
<td  class='thstyleLeftDetails' align=right  noWrap>800.00</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2340</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.34188</td>
<td  class='thstyleLeftDetails' align=right  noWrap>800.00</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup55" value="0"  id="radiogroup1_0_55" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_55"  value="D1504070939569215"><input type="radio" name="radiogroup55" value="1" id="radiogroup1_1_55" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup55" value="2" id="radiogroup1_2_55" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>57</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504141313516896&HouseNo=130595639097577148' target="_blank">上盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>WH-051上盖（54系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.38460</td>
<td  class='thstyleLeftDetails' align=right  noWrap>192.30</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.38460</td>
<td  class='thstyleLeftDetails' align=right  noWrap>192.30</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup56" value="0"  id="radiogroup1_0_56" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_56"  value="D1504141313516896"><input type="radio" name="radiogroup56" value="1" id="radiogroup1_1_56" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup56" value="2" id="radiogroup1_2_56" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>58</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1505251630562243&HouseNo=130595639097577148' target="_blank">上盖加工</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM15A键上盖热转印加工&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.28208</td>
<td  class='thstyleLeftDetails' align=right  noWrap>13.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.28208</td>
<td  class='thstyleLeftDetails' align=right  noWrap>13.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup57" value="0"  id="radiogroup1_0_57" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_57"  value="D1505251630562243"><input type="radio" name="radiogroup57" value="1" id="radiogroup1_1_57" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup57" value="2" id="radiogroup1_2_57" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>59</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1304101646572440&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-35新疆简易型（泽熙）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;98</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.15388</td>
<td  class='thstyleLeftDetails' align=right  noWrap>113.08</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>98</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.15388</td>
<td  class='thstyleLeftDetails' align=right  noWrap>113.08</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup58" value="0"  id="radiogroup1_0_58" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_58"  value="D1304101646572440"><input type="radio" name="radiogroup58" value="1" id="radiogroup1_1_58" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup58" value="2" id="radiogroup1_2_58" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>60</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1402251045218364&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-43L电池盖（河北省网）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16240</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3317.05</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60080</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16239</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9756.58</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16240</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5671.82</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45580</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.16239</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7401.81</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup59" value="0"  id="radiogroup1_0_59" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_59"  value="D1402251045218364"><input type="radio" name="radiogroup59" value="1" id="radiogroup1_1_59" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup59" value="2" id="radiogroup1_2_59" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>61</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1402251043057649&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-43L键帽（河北省网）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.25641</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5237.19</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60080</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.25641</td>
<td  class='thstyleLeftDetails' align=right  noWrap>15405.12</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.25641</td>
<td  class='thstyleLeftDetails' align=right  noWrap>8955.12</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45580</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.25641</td>
<td  class='thstyleLeftDetails' align=right  noWrap>11687.19</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup60" value="0"  id="radiogroup1_0_60" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_60"  value="D1402251043057649"><input type="radio" name="radiogroup60" value="1" id="radiogroup1_1_60" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup60" value="2" id="radiogroup1_2_60" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>62</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1402251045051725&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-43L上盖（河北省网）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.41025</td>
<td  class='thstyleLeftDetails' align=right  noWrap>8379.38</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60080</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.41026</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24648.20</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.41026</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14328.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45580</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.41025</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18699.25</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup61" value="0"  id="radiogroup1_0_61" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_61"  value="D1402251045051725"><input type="radio" name="radiogroup61" value="1" id="radiogroup1_1_61" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup61" value="2" id="radiogroup1_2_61" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>63</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1402251044167145&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-43L下盖（河北省网）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.40171</td>
<td  class='thstyleLeftDetails' align=right  noWrap>8204.88</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60080</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.40171</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24134.69</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.40171</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14029.72</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45580</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.40171</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18309.85</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup62" value="0"  id="radiogroup1_0_62" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_62"  value="D1402251044167145"><input type="radio" name="radiogroup62" value="1" id="radiogroup1_1_62" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup62" value="2" id="radiogroup1_2_62" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>64</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1304121522103324&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>JC-21户户通 电池盖（君超）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>套</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>30520</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5217.09</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4358.97</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5020</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>858.12</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup63" value="0"  id="radiogroup1_0_63" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_63"  value="D1304121522103324"><input type="radio" name="radiogroup63" value="1" id="radiogroup1_1_63" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup63" value="2" id="radiogroup1_2_63" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>65</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1503041637176835&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>JC-21户户通 电池盖黑色（君超）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>套</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;1000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>170.94</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>170.94</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup64" value="0"  id="radiogroup1_0_64" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_64"  value="D1503041637176835"><input type="radio" name="radiogroup64" value="1" id="radiogroup1_1_64" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup64" value="2" id="radiogroup1_2_64" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>66</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1304121521521094&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>JC-21户户通 下盖（君超）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>套</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>30520</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.42735</td>
<td  class='thstyleLeftDetails' align=right  noWrap>13042.73</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.42735</td>
<td  class='thstyleLeftDetails' align=right  noWrap>10897.43</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5020</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.42735</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2145.30</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup65" value="0"  id="radiogroup1_0_65" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_65"  value="D1304121521521094"><input type="radio" name="radiogroup65" value="1" id="radiogroup1_1_65" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup65" value="2" id="radiogroup1_2_65" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>67</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1308011319547095&HouseNo=130595639097577148' target="_blank">塑壳</td>
<td  class='thstyleLeftDetails' align=left  noWrap>JC-25简易上盖（君超）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>套</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>30520</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.29915</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9129.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.29915</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7628.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5020</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.29912</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1501.59</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup66" value="0"  id="radiogroup1_0_66" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_66"  value="D1308011319547095"><input type="radio" name="radiogroup66" value="1" id="radiogroup1_1_66" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup66" value="2" id="radiogroup1_2_66" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>68</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1607071501299039&HouseNo=130595639097577148' target="_blank">透镜</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1012黑透镜无孔（23系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.10256</td>
<td  class='thstyleLeftDetails' align=right  noWrap>254.87</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.10256</td>
<td  class='thstyleLeftDetails' align=right  noWrap>254.86</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup67" value="0"  id="radiogroup1_0_67" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_67"  value="D1607071501299039"><input type="radio" name="radiogroup67" value="1" id="radiogroup1_1_67" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup67" value="2" id="radiogroup1_2_67" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>69</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608101511211424&HouseNo=130595639097577148' target="_blank">透镜</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-2003透镜（47系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09402</td>
<td  class='thstyleLeftDetails' align=right  noWrap>47.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.09402</td>
<td  class='thstyleLeftDetails' align=right  noWrap>47.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup68" value="0"  id="radiogroup1_0_68" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_68"  value="D1608101511211424"><input type="radio" name="radiogroup68" value="1" id="radiogroup1_1_68" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup68" value="2" id="radiogroup1_2_68" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>70</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504070941392914&HouseNo=130595639097577148' target="_blank">透镜</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41透镜（56系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>101.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.17094</td>
<td  class='thstyleLeftDetails' align=right  noWrap>101.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup69" value="0"  id="radiogroup1_0_69" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_69"  value="D1504070941392914"><input type="radio" name="radiogroup69" value="1" id="radiogroup1_1_69" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup69" value="2" id="radiogroup1_2_69" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>71</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606280939193040&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1008灰下盖（24系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32300</td>
<td  class='thstyleLeftDetails' align=right  noWrap>32.30</td>
<td  class='thstyleLeftDetails' align=right  noWrap>80030</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32479</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25992.66</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>78730</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32478</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25569.94</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.32501</td>
<td  class='thstyleLeftDetails' align=right  noWrap>455.02</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup70" value="0"  id="radiogroup1_0_70" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_70"  value="D1606280939193040"><input type="radio" name="radiogroup70" value="1" id="radiogroup1_1_70" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup70" value="2" id="radiogroup1_2_70" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>72</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061017374216&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1009白下盖（45系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;10003</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.44445</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4445.85</td>
<td  class='thstyleLeftDetails' align=right  noWrap>50421</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.44444</td>
<td  class='thstyleLeftDetails' align=right  noWrap>22409.29</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>41208</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.44444</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18314.48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>19216</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.44446</td>
<td  class='thstyleLeftDetails' align=right  noWrap>8540.66</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup71" value="0"  id="radiogroup1_0_71" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_71"  value="D1604061017374216"><input type="radio" name="radiogroup71" value="1" id="radiogroup1_1_71" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup71" value="2" id="radiogroup1_2_71" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>73</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606301521009879&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1012黑下盖（23系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35043</td>
<td  class='thstyleLeftDetails' align=right  noWrap>870.81</td>
<td  class='thstyleLeftDetails' align=right  noWrap>300</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35043</td>
<td  class='thstyleLeftDetails' align=right  noWrap>105.13</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35043</td>
<td  class='thstyleLeftDetails' align=right  noWrap>870.82</td>
<td  class='thstyleLeftDetails' align=right  noWrap>300</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35043</td>
<td  class='thstyleLeftDetails' align=right  noWrap>105.13</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>-0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup72" value="0"  id="radiogroup1_0_72" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_72"  value="D1606301521009879"><input type="radio" name="radiogroup72" value="1" id="radiogroup1_1_72" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup72" value="2" id="radiogroup1_2_72" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>74</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606201431113031&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-1015黑下盖（25系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35043</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1752.13</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.35043</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1752.15</td>
<td  class='thstyleLeftDetails' align=right  noWrap>-0.02</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup73" value="0"  id="radiogroup1_0_73" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_73"  value="D1606201431113031"><input type="radio" name="radiogroup73" value="1" id="radiogroup1_1_73" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup73" value="2" id="radiogroup1_2_73" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>75</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1505251628503306&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM15A下盖黑色&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.29917</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14.36</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.29917</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14.36</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup74" value="0"  id="radiogroup1_0_74" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_74"  value="D1505251628503306"><input type="radio" name="radiogroup74" value="1" id="radiogroup1_1_74" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup74" value="2" id="radiogroup1_2_74" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>76</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608101510167859&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-2003灰下盖（47系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.55556</td>
<td  class='thstyleLeftDetails' align=right  noWrap>277.78</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.55556</td>
<td  class='thstyleLeftDetails' align=right  noWrap>277.78</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup75" value="0"  id="radiogroup1_0_75" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_75"  value="D1608101510167859"><input type="radio" name="radiogroup75" value="1" id="radiogroup1_1_75" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup75" value="2" id="radiogroup1_2_75" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>77</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1503161019331244&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM32模具下盖（德州江苏）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.45299</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3193.59</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.45299</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3193.58</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup76" value="0"  id="radiogroup1_0_76" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_76"  value="D1503161019331244"><input type="radio" name="radiogroup76" value="1" id="radiogroup1_1_76" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup76" value="2" id="radiogroup1_2_76" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>78</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504131353366149&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41白下盖（56系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.43589</td>
<td  class='thstyleLeftDetails' align=right  noWrap>258.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>594</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.43589</td>
<td  class='thstyleLeftDetails' align=right  noWrap>258.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup77" value="0"  id="radiogroup1_0_77" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_77"  value="D1504131353366149"><input type="radio" name="radiogroup77" value="1" id="radiogroup1_1_77" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup77" value="2" id="radiogroup1_2_77" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>79</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504070940495696&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>BM-41下盖（56系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2340</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.42735</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000.00</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2340</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.42735</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000.00</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup78" value="0"  id="radiogroup1_0_78" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_78"  value="D1504070940495696"><input type="radio" name="radiogroup78" value="1" id="radiogroup1_1_78" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup78" value="2" id="radiogroup1_2_78" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>80</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504141315471328&HouseNo=130595639097577148' target="_blank">下盖</td>
<td  class='thstyleLeftDetails' align=left  noWrap>WH-051下盖（54系列）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.47008</td>
<td  class='thstyleLeftDetails' align=right  noWrap>235.04</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.47008</td>
<td  class='thstyleLeftDetails' align=right  noWrap>235.04</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup79" value="0"  id="radiogroup1_0_79" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_79"  value="D1504141315471328"><input type="radio" name="radiogroup79" value="1" id="radiogroup1_1_79" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup79" value="2" id="radiogroup1_2_79" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>81</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1510080858501194&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>HB1531A-MT_BM1605_BM1605-00（河北）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>片</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;20425</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>12220.12</td>
<td  class='thstyleLeftDetails' align=right  noWrap>60095</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>35954.27</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>34925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>20895.29</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>45595</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>27279.10</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup80" value="0"  id="radiogroup1_0_80" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_80"  value="D1510080858501194"><input type="radio" name="radiogroup80" value="1" id="radiogroup1_1_80" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup80" value="2" id="radiogroup1_2_80" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>82</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1607071503307757&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>HB1531A-MT_BM2302_BM2302-00（黑龙江农垦）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>片</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1486.76</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2485</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1486.75</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.01</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup81" value="0"  id="radiogroup1_0_81" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_81"  value="D1607071503307757"><input type="radio" name="radiogroup81" value="1" id="radiogroup1_1_81" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup81" value="2" id="radiogroup1_2_81" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>83</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1606280946043374&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>HB1531A-MT_BM2401_BM2401-00（河北）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>片</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59860</td>
<td  class='thstyleLeftDetails' align=right  noWrap>59.86</td>
<td  class='thstyleLeftDetails' align=right  noWrap>80030</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>47881.20</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>78730</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59829</td>
<td  class='thstyleLeftDetails' align=right  noWrap>47103.38</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1400</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.59834</td>
<td  class='thstyleLeftDetails' align=right  noWrap>837.68</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup82" value="0"  id="radiogroup1_0_82" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_82"  value="D1606280946043374"><input type="radio" name="radiogroup82" value="1" id="radiogroup1_1_82" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup82" value="2" id="radiogroup1_2_82" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>84</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1303081006082448&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL10_SL10（衢江农网29键）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>片</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;18</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.04389</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18.79</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.04389</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18.79</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup83" value="0"  id="radiogroup1_0_83" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_83"  value="D1303081006082448"><input type="radio" name="radiogroup83" value="1" id="radiogroup1_1_83" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup83" value="2" id="radiogroup1_2_83" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>85</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1412261711001625&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL100_SL100（福州高清）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>片</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;6018</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4629.30</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>769.23</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>6000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4615.44</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1018</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>783.09</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup84" value="0"  id="radiogroup1_0_84" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_84"  value="D1412261711001625"><input type="radio" name="radiogroup84" value="1" id="radiogroup1_1_84" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup84" value="2" id="radiogroup1_2_84" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>86</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1409110944527945&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL105_SL105（福建泉州）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;1514</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1164.65</td>
<td  class='thstyleLeftDetails' align=right  noWrap>11130</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>8561.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9200</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7076.93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76857</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5.38</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3437</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2643.88</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup85" value="0"  id="radiogroup1_0_85" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_85"  value="D1409110944527945"><input type="radio" name="radiogroup85" value="1" id="radiogroup1_1_85" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup85" value="2" id="radiogroup1_2_85" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>87</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504141320029722&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL113_SL113（启东2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;10</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81300</td>
<td  class='thstyleLeftDetails' align=right  noWrap>8.13</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>10</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81300</td>
<td  class='thstyleLeftDetails' align=right  noWrap>8.13</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup86" value="0"  id="radiogroup1_0_86" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_86"  value="D1504141320029722"><input type="radio" name="radiogroup86" value="1" id="radiogroup1_1_86" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup86" value="2" id="radiogroup1_2_86" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>88</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504090839001003&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL115_SL115（南平超标清2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;430</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81198</td>
<td  class='thstyleLeftDetails' align=right  noWrap>349.15</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>430</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81198</td>
<td  class='thstyleLeftDetails' align=right  noWrap>349.15</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup87" value="0"  id="radiogroup1_0_87" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_87"  value="D1504090839001003"><input type="radio" name="radiogroup87" value="1" id="radiogroup1_1_87" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup87" value="2" id="radiogroup1_2_87" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>89</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504090929097255&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL118_SL118（宁德简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;308</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81198</td>
<td  class='thstyleLeftDetails' align=right  noWrap>250.09</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>308</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81198</td>
<td  class='thstyleLeftDetails' align=right  noWrap>250.09</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup88" value="0"  id="radiogroup1_0_88" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_88"  value="D1504090929097255"><input type="radio" name="radiogroup88" value="1" id="radiogroup1_1_88" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup88" value="2" id="radiogroup1_2_88" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>90</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1507131544513569&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL133_SL133（福安）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>片</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;24</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.78333</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18.80</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.78333</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18.80</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup89" value="0"  id="radiogroup1_0_89" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_89"  value="D1507131544513569"><input type="radio" name="radiogroup89" value="1" id="radiogroup1_1_89" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup89" value="2" id="radiogroup1_2_89" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>91</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1507090931413057&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL134_SL134（厦门简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;9</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81444</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7.33</td>
<td  class='thstyleLeftDetails' align=right  noWrap>30074</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>23133.85</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>25000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>19231.00</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5083</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76927</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3910.18</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup90" value="0"  id="radiogroup1_0_90" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_90"  value="D1507090931413057"><input type="radio" name="radiogroup90" value="1" id="radiogroup1_1_90" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup90" value="2" id="radiogroup1_2_90" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>92</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1508210835291279&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL141_SL141（漳浦简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;18</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81222</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14.62</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81222</td>
<td  class='thstyleLeftDetails' align=right  noWrap>14.62</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup91" value="0"  id="radiogroup1_0_91" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_91"  value="D1508210835291279"><input type="radio" name="radiogroup91" value="1" id="radiogroup1_1_91" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup91" value="2" id="radiogroup1_2_91" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>93</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1509091513252946&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL144_SL144（漳州超标清2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2554</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76925</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1964.67</td>
<td  class='thstyleLeftDetails' align=right  noWrap>12508</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9621.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>10005</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7696.15</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.77000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.54</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5055</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3888.52</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup92" value="0"  id="radiogroup1_0_92" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_92"  value="D1509091513252946"><input type="radio" name="radiogroup92" value="1" id="radiogroup1_1_92" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup92" value="2" id="radiogroup1_2_92" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>94</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1509021553065619&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL146_SL146（宁波鄞州）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;2</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.62</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1.62</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup93" value="0"  id="radiogroup1_0_93" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_93"  value="D1509021553065619"><input type="radio" name="radiogroup93" value="1" id="radiogroup1_1_93" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup93" value="2" id="radiogroup1_2_93" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>95</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1509301543221038&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL151_SL151（宁德超标清2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;10</td>
<td  class='thstyleLeftDetails' align=right  noWrap>39.23100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>392.31</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>10</td>
<td  class='thstyleLeftDetails' align=right  noWrap>39.23100</td>
<td  class='thstyleLeftDetails' align=right  noWrap>392.31</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup94" value="0"  id="radiogroup1_0_94" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_94"  value="D1509301543221038"><input type="radio" name="radiogroup94" value="1" id="radiogroup1_1_94" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup94" value="2" id="radiogroup1_2_94" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>96</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1510190939177091&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL154_SL154（珠江1807）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;4</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81250</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3.25</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>4</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81250</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3.25</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup95" value="0"  id="radiogroup1_0_95" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_95"  value="D1510190939177091"><input type="radio" name="radiogroup95" value="1" id="radiogroup1_1_95" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup95" value="2" id="radiogroup1_2_95" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>97</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504090926391576&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL158_SL158（福州简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;24</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76958</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18.47</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76958</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18.47</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup96" value="0"  id="radiogroup1_0_96" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_96"  value="D1504090926391576"><input type="radio" name="radiogroup96" value="1" id="radiogroup1_1_96" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup96" value="2" id="radiogroup1_2_96" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>98</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1601061319361744&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL165_SL165（南京学习型2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;7</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81143</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5.68</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81143</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5.68</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup97" value="0"  id="radiogroup1_0_97" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_97"  value="D1601061319361744"><input type="radio" name="radiogroup97" value="1" id="radiogroup1_1_97" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup97" value="2" id="radiogroup1_2_97" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>99</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504090928378843&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL167_SL167（漳州简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;225</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81196</td>
<td  class='thstyleLeftDetails' align=right  noWrap>182.69</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>225</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81196</td>
<td  class='thstyleLeftDetails' align=right  noWrap>182.69</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup98" value="0"  id="radiogroup1_0_98" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_98"  value="D1504090928378843"><input type="radio" name="radiogroup98" value="1" id="radiogroup1_1_98" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup98" value="2" id="radiogroup1_2_98" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>100</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504090929311102&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL168_SL168（南平简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;9</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81222</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7.31</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81222</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7.31</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup99" value="0"  id="radiogroup1_0_99" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_99"  value="D1504090929311102"><input type="radio" name="radiogroup99" value="1" id="radiogroup1_1_99" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup99" value="2" id="radiogroup1_2_99" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>101</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504090932039831&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL169_SL169（泉州简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;510</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81196</td>
<td  class='thstyleLeftDetails' align=right  noWrap>414.10</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>510</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.81196</td>
<td  class='thstyleLeftDetails' align=right  noWrap>414.10</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup100" value="0"  id="radiogroup1_0_100" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_100"  value="D1504090932039831"><input type="radio" name="radiogroup100" value="1" id="radiogroup1_1_100" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup100" value="2" id="radiogroup1_2_100" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>102</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1504090930552137&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL174_SL174（三明简易2317）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;14</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.77000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>10.78</td>
<td  class='thstyleLeftDetails' align=right  noWrap>510</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>392.31</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76926</td>
<td  class='thstyleLeftDetails' align=right  noWrap>384.63</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>24</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76917</td>
<td  class='thstyleLeftDetails' align=right  noWrap>18.46</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup101" value="0"  id="radiogroup1_0_101" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_101"  value="D1504090930552137"><input type="radio" name="radiogroup101" value="1" id="radiogroup1_1_101" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup101" value="2" id="radiogroup1_2_101" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>103</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1604061029519040&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL178_SL178（江苏农网）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7093</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5456.15</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7050</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>5423.07</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>43</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76930</td>
<td  class='thstyleLeftDetails' align=right  noWrap>33.08</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup102" value="0"  id="radiogroup1_0_102" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_102"  value="D1604061029519040"><input type="radio" name="radiogroup102" value="1" id="radiogroup1_1_102" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup102" value="2" id="radiogroup1_2_102" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>104</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1608101627538147&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL190_SL190（歌华基本）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>510</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>392.31</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>500</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>384.62</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>10</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76900</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7.69</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup103" value="0"  id="radiogroup1_0_103" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_103"  value="D1608101627538147"><input type="radio" name="radiogroup103" value="1" id="radiogroup1_1_103" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup103" value="2" id="radiogroup1_2_103" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>105</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1308091344454250&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL38_SL38（慈溪简易）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;9</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76889</td>
<td  class='thstyleLeftDetails' align=right  noWrap>6.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76889</td>
<td  class='thstyleLeftDetails' align=right  noWrap>6.92</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup104" value="0"  id="radiogroup1_0_104" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_104"  value="D1308091344454250"><input type="radio" name="radiogroup104" value="1" id="radiogroup1_1_104" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup104" value="2" id="radiogroup1_2_104" ></td>
 </tr>
 <tr class='rr' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>106</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1407181114229706&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL86_SL86（福建省网）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;519</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.78796</td>
<td  class='thstyleLeftDetails' align=right  noWrap>408.95</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>3</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.78667</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2.36</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>516</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.78797</td>
<td  class='thstyleLeftDetails' align=right  noWrap>406.59</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup105" value="0"  id="radiogroup1_0_105" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_105"  value="D1407181114229706"><input type="radio" name="radiogroup105" value="1" id="radiogroup1_1_105" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup105" value="2" id="radiogroup1_2_105" ></td>
 </tr>
 <tr class='gg' onmouseover=''>
<td class='thstyleLeftDetails'align=center noWrap>107</td>
<td  class='thstyleLeftDetails' align=left  noWrap><a href='/web/WareHouseStore/KNet_WareHouse_Ownall_Water_New.aspx?ProductsBarCode=D1409110946167695&HouseNo=130595639097577148' target="_blank">芯片</td>
<td  class='thstyleLeftDetails' align=left  noWrap>SC51P2317SC1G_SL90_SL90（福建省网三明）&nbsp;</td>
<td  class='thstyleLeftDetails' align=left  noWrap>只</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;3573</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76926</td>
<td  class='thstyleLeftDetails' align=right  noWrap>2748.57</td>
<td  class='thstyleLeftDetails' align=right  noWrap>22187</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>17066.93</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>16000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76924</td>
<td  class='thstyleLeftDetails' align=right  noWrap>12307.84</td>
<td  class='thstyleLeftDetails' align=right  noWrap>1</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.77000</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.77</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0</td>
<td  class='thstyleLeftDetails' align=right  noWrap>9759</td>
<td  class='thstyleLeftDetails' align=right  noWrap>0.76923</td>
<td  class='thstyleLeftDetails' align=right  noWrap>7506.89</td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup106" value="0"  id="radiogroup1_0_106" checked> </td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="hidden" name="Tbx_ProductsBarCode_106"  value="D1409110946167695"><input type="radio" name="radiogroup106" value="1" id="radiogroup1_1_106" ></td>
<td  class='thstyleLeftDetails' align=right  noWrap><input type="radio" name="radiogroup106" value="2" id="radiogroup1_2_106" ></td>
 </tr>
 <tr >
<td class='thstyleLeftDetails'align=center noWrap colspan='4'>合计:</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;487707</td>
<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;182904.80</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;1745136</td>
<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;841067.66</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;7593</td>
<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;5789.48</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;1460226</td>
<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;680001.51</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;68520</td>
<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;13588.21</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;35000</td>
<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;7991.45</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;0.12</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;676690</td>
<td  class='thstyleLeftDetails' align=right noWrap >&nbsp;</td>
<td  class='thstyleLeftDetails' align=right  noWrap>&nbsp;328180.65</td>
<td  class='thstyleLeftDetails' align=right noWrap colspan=2 >&nbsp;</td>
 </tr>
</table>
</div>
</body>
</html>
