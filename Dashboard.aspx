<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Dashboard</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="crumbs">
        <ul id="breadcrumbs" class="breadcrumb">
            <li><i class="icon-home"></i><a href="index.aspx"><b>工作台</b></a> </li>
            <li class="current"><a href="Dashboard.aspx" target="main" title="">工作台</a> </li>
        </ul>
        <ul class="crumb-buttons">
            <li class="first"><a href="charts.html" title=""><i class="icon-signal"></i><span>Statistics</span></a></li>
            <li class="dropdown"><a href="#" title="" data-toggle="dropdown"><i class="icon-tasks"></i><span>Users <strong>(+3)</strong></span><i class="icon-angle-down left-padding"></i></a>
                <ul class="dropdown-menu pull-right">
                    <li><a href="form_components.html" title=""><i class="icon-plus"></i>Add new User</a></li>
                    <li><a href="tables_dynamic.html" title=""><i class="icon-reorder"></i>Overview</a></li>
                </ul>
            </li>
            <li class="range"><a href="#"><i class="icon-calendar"></i><span>July 5, 2016 - August 3, 2016</span> <i class="icon-angle-down"></i></a></li>
        </ul>
    </div>
    <div class="page-header">
        <div class="page-title">
            <h3>Dashboard</h3>
            <span>欢迎, xuejx！</span>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="widget box">
                <div class="widget-header">
                    <h4><i class="icon-reorder"></i>本月销售统计</h4>
                    <div class="toolbar no-padding">
                        <div class="btn-group"><span class="btn btn-xs widget-collapse"><i class="icon-angle-down"></i></span></div>
                    </div>
                </div>
                <div class="widget-content">
                    <ul class="stats">
                        <li><span class="title">本月新增联系记录</span><strong>4,853</strong> <small>上月：15
                        </small><small>本年：93</small> </li>
                        <li class="light"><span class="title">本月订单成交量</span><strong>271</strong> <small>Last 24 Hours</small> </li>
                        <li><span class="title">本月订单成交金额</span><strong>1,025</strong> <small>Unique Users</small> </li>
                        <li class="light"><span class="title">本月收款金额</span><strong>105</strong> <small>Last 24 Hours</small> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="widget box">
                <div class="widget-header">
                    <h4><i class="icon-reorder"></i>本月采购统计</h4>
                    <div class="toolbar no-padding">
                        <div class="btn-group"><span class="btn btn-xs widget-collapse"><i class="icon-angle-down"></i></span></div>
                    </div>
                </div>
                <div class="widget-content">
                    <ul class="stats">
                        <li><span class="title">本月新增联系记录</span><strong>4,853</strong> <small>上月：15
                        </small><small>本年：93</small> </li>
                        <li class="light"><span class="title">本月订单成交量</span><strong>271</strong> <small>Last 24 Hours</small> </li>
                        <li><span class="title">本月订单成交金额</span><strong>1,025</strong> <small>Unique Users</small> </li>
                        <li class="light"><span class="title">本月收款金额</span><strong>105</strong> <small>Last 24 Hours</small> </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="widget box">
                <div class="widget-header">
                    <h4><i class="icon-reorder"></i>公司资金状况 </h4>
                    <div class="toolbar no-padding">
                        <div class="btn-group"><span class="btn btn-xs widget-collapse"><i class="icon-angle-down"></i></span></div>
                    </div>
                </div>
                <div class="widget-content">
                    <span id="Lbl_Account">
                        <table width="100%">
                            <tr>
                                <td align="center" class="settingsTabHeader">账号</td>
                                <td align="center" class="settingsTabHeader">余额</td>
                            </tr>
                            <tr>
                                <td align="left" class="settingsTabHeader">交行东新支行</td>
                                <td align="right" class="settingsTabList"><a href="http://115.238.88.226:88/web/Report_Cw/Bank/List_Bank.aspx?StartDate=2016/8/1&amp;EndDate=2016/8/4&amp;CustomerName=&amp;Account=129780760640657451&amp;Type=&amp;Type1=" target="_blank">187,737.03</a></td>
                            </tr>
                            <tr>
                                <td align="left" class="settingsTabHeader">应收票据</td>
                                <td align="right" class="settingsTabList"><a href="http://115.238.88.226:88/web/Report_Cw/Bill/List_Bank.aspx?StartDate=2016/8/1&amp;EndDate=2016/8/4&amp;CustomerName=&amp;Account=129780760640657453&amp;Type=&amp;Type1=" target="_blank">2,066,000.00</a></td>
                            </tr>
                            <tr>
                                <td align="left" class="settingsTabHeader">民生银行西湖支行</td>
                                <td align="right" class="settingsTabList"><a href="http://115.238.88.226:88/web/Report_Cw/Bank/List_Bank.aspx?StartDate=2016/8/1&amp;EndDate=2016/8/4&amp;CustomerName=&amp;Account=129780760640657452&amp;Type=&amp;Type1=" target="_blank">-720,222.89</a></td>
                            </tr>
                            <tr>
                                <td align="left" class="settingsTabHeader">现金</td>
                                <td align="right" class="settingsTabList"><a href="http://115.238.88.226:88/web/Report_Cw/Money/List_Bank.aspx?StartDate=2016/8/1&amp;EndDate=2016/8/4&amp;CustomerName=&amp;Account=129780760640657412&amp;Type=&amp;Type1=" target="_blank">0</a></td>
                            </tr>
                            <tr>
                                <td align="left" class="settingsTabHeader">合计</td>
                                <td align="right" class="settingsTabHeader">1,533,514.14</td>
                            </tr>
                        </table>
                    </span>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="widget box">
                <div class="widget-header">
                    <h4><i class="icon-reorder"></i>公司应收款信息 </h4>
                    <div class="toolbar no-padding">
                        <div class="btn-group"><span class="btn btn-xs widget-collapse"><i class="icon-angle-down"></i></span></div>
                    </div>
                </div>
                <div class="widget-content">
                    <span id="Lbl_Receive">
                        <table width="100%">
                            <tr>
                                <td align="center" class="settingsTabHeader">业务员</td>
                                <td align="center" class="settingsTabHeader">应收款金额</td>
                                <td align="center" class="settingsTabHeader">超期金额</td>
                            </tr>
                            <tr>
                                <td align="center" class="settingsTabHeader">黄景江</td>
                                <td align="center" class="settingsTabList">394857.00</td>
                                <td align="center" class="settingsTabList"><a href="http://115.238.88.226:88/web/Xs/Customer/KNet_Sales_ClientList_Manger_Receive.aspx?DutyPerson=129750601593032855" target="_blank">39176.00</a></td>
                            </tr>
                            <tr>
                                <td align="center" class="settingsTabHeader">曹柱立</td>
                                <td align="center" class="settingsTabList">233153.40</td>
                                <td align="center" class="settingsTabList"><a href="http://115.238.88.226:88/web/Xs/Customer/KNet_Sales_ClientList_Manger_Receive.aspx?DutyPerson=129785817669906814" target="_blank">-1675599.60</a></td>
                            </tr>
                            <tr>
                                <td align="center" class="settingsTabHeader">刘必飞</td>
                                <td align="center" class="settingsTabList">19347437.78</td>
                                <td align="center" class="settingsTabList"><a href="http://115.238.88.226:88/web/Xs/Customer/KNet_Sales_ClientList_Manger_Receive.aspx?DutyPerson=129785819880633261" target="_blank">-39476029.90</a></td>
                            </tr>
                            <tr>
                                <td align="center" class="settingsTabHeader">李萍</td>
                                <td align="center" class="settingsTabList">6235926.80</td>
                                <td align="center" class="settingsTabList"><a href="http://115.238.88.226:88/web/Xs/Customer/KNet_Sales_ClientList_Manger_Receive.aspx?DutyPerson=130273944327386905" target="_blank">-13362681.85</a></td>
                            </tr>
                            <tr>
                                <td align="center" class="settingsTabHeader">李思婕</td>
                                <td align="center" class="settingsTabList">179000.00</td>
                                <td align="center" class="settingsTabList"><a href="http://115.238.88.226:88/web/Xs/Customer/KNet_Sales_ClientList_Manger_Receive.aspx?DutyPerson=130559285841610564" target="_blank">-525.00</a></td>
                            </tr>
                            <tr>
                                <td align="left" class="settingsTabHeader">合计</td>
                                <td align="center" class="settingsTabHeader">26,390,374.98</td>
                                <td align="center" class="settingsTabHeader">-54,475,660.35</td>
                            </tr>
                        </table>
                    </span>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="widget box">
                <div class="widget-header">
                    <h4><i class="icon-reorder"></i>日/周/月/年报 </h4>
                    <div class="toolbar no-padding">
                        <div class="btn-group"><span class="btn btn-xs widget-collapse"><i class="icon-angle-down"></i></span></div>
                    </div>
                </div>
                <div class="widget-content">
                    <span id="Lbl_ReportDetails">
                        <table width="100%">
                            <tr>
                                <td class="settingsTabHeader">日/周/月</td>
                                <td class="settingsTabHeader">日报</td>
                                <td class="settingsTabHeader">周报</td>
                                <td class="settingsTabHeader">月报</td>
                            </tr>
                            <tr>
                                <td class="settingsTabHeader">写</td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/OA_Person_Report_Today_Add.aspx">写</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/OA_Person_Report_Week_Add.aspx">写</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/OA_Person_Report_Month_Add.aspx">写</a></td>
                            </tr>
                            <tr>
                                <td class="settingsTabHeader">看下级</td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/OA_Person_Report_Today_View.aspx">查看</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/OA_Person_Report_Week_View.aspx">查看</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/OA_Person_Report_Month_View.aspx">查看</a></td>
                            </tr>
                            <tr>
                                <td class="settingsTabHeader">提交情况</td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/Report_Today_View.aspx" target="_blank">查看</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/Report_Week_View.aspx" target="_blank">查看</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/Report_Month_View.aspx" target="_blank">查看</a></td>
                            </tr>
                            <tr>
                                <td class="settingsTabHeader">汇总</td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/TotalReport_Today_View.aspx">查看</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/TotalReport_Week_View.aspx">查看</a></td>
                                <td class="settingsTabList"><a href="http://115.238.88.226:88/Web/OA/Report/TotalReport_Month_View.aspx">查看</a></td>
                            </tr>
                        </table>
                    </span>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
