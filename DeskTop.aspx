<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeskTop.aspx.cs" Inherits="Web_DeskTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>个人桌面</title>
    <link href="Images/Custom.css" type="text/css" rel="stylesheet">
    <link href="Images/main.css" type="text/css" rel="stylesheet">

    <script language="JScript" src="Images/Calendar.js"></script>
    <script language="JavaScript" src="Images/Comm_JScript.js"></script>
    <style type="text/css"> 
        TD.grzmRow { PADDING-RIGHT: 4px; PADDING-LEFT: 4px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px } TD.grzmList { PADDING-RIGHT: 4px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px } BODY { BACKGROUND-COLOR: #ebf1fa } 
    </style>
</head>
<body>
    <form id="DeskTop" runat="server">
        <table width="100%" background="images/style/tab-strip-bg.gif" bgcolor="#D4E4F3" cellpadding="0" cellspacing="0">
            <tr>
                <td width="80" height="28" align="left">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="10"><img src="images/style/tab_left.gif" width="10" height="26" /></td>
                            <td width="180" background="images/style/tab_bg.gif" class="top_menu">个人桌面</td>
                            <td width="3500"><img src="images/style/tab_right.gif" width="10" height="26" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table><br />
        <table cellspacing="0" cellpadding="0" width="800" align="center" border="0">
            <tr>
                <td width="550">
                    <!---- 最外层td  ----->
                    <table>
                        <tr>
                            <td width="20">
                                <img src="Images/icon_1.gif" width="16" height="16"></td>
                            <td width="350">
                                <div>
                                    最新消息</div>
                            </td>
                            <td width="80" align="right">
                                <a href="">更多...</a></td>
                        </tr>
                    </table>
                    <hr>
                    <table>
                        <tr>
                            <td colspan="3" width="500">
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td width="20">
                                <img src="Images/icon_2.gif" width="16" height="16"></td>
                            <td width="450">
                                <div>
                                    待办事宜</div>
                            </td>
                        </tr>
                    </table>
                    <hr>
                    <table width="500">
                        <tr>
                            <td>
                                <a href="javascript:PageOpen('Web/Sales/KNet_Sales_ContractList_Manage.aspx?Type=1');">合同评审审批</a></td>
                            <td>
                                <a href="javascript:PageOpen('Web/Procure/Knet_Procure_OpenBilling.aspx?Type=1');">采购订单审批</a> </td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:PageOpen('Web/Sales/Knet_Sales_Ship_Manage_Manage.aspx');">发货通知</a>
                                </td>
                            <td>
                                <a href="javascript:PageOpen('Web/Sales/Sales_ShipWareOut_Manage.aspx');">销售出库单</a></td>
                        </tr>
                        <tr>
                            <td>
                                <a href="javascript:PageOpen('Web/Sales/Knet_Sales_Retrun_Manage_Manage.aspx');">销售退货单审批</a></td>
                            <td></td>
                        </tr>
                    </table>
                    <br>
                    <table>
                        <tr>
                            <td width="20">
                                <img src="Images/icon_5.gif"></td>
                            <td width="350">
                                <div>
                                    我的工作</div>
                            </td>
                            <td width="80" align="right">
                                <a href="">进入&gt;&gt;</a></td>
                        </tr>
                    </table>
                    <hr>
                    <table width="500">
                        <asp:Label ID="Lab_MyPlan" runat="server"></asp:Label></table>
                    <br>
                    <table>
                        <tr>
                            <td width="20">
                                <img src="Images/icon_4.gif"></td>
                            <td width="350">
                                <div>
                                    工作日志</div>
                            </td>
                            <td width="80" align="right">
                                <a href="">进入&gt;&gt;</a></td>
                        </tr>
                    </table>
                    <hr>
                    <table width="500">
                        <asp:Label ID="Lab_MyLog" runat="server"></asp:Label></table>
                    <br>
                    <table>
                        <tr>
                            <td width="20">
                                <img src="Images/icon_5.gif"></td>
                            <td width="350">
                                <div>
                                    今日日程</div>
                            </td>
                            <td width="80" align="right">
                                <a href="">进入&gt;&gt;</a></td>
                        </tr>
                    </table>
                     <hr>
                    <table width="500">
                        <asp:Label ID="Lab_MyCalendar" runat="server"></asp:Label></table>
                    <!-- br>
                    < table>
                        <tr>
                            <td width="20">
                                <img src="Images/icon_5.gif"></td>
                            <td width="350">
                                <div>
                                    案卷信息</div>
                            </td>
                            <td width="80" align="right">
                                <a href="OA/OA_File/OA_File_RollList.aspx">进入&gt;&gt;</a></td>
                        </tr>
                    </table>
                    <hr>
                     <table width="500">
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                      </table -->
                    <br>
                    <table>
                        <tr>
                            <td width="20">
                                <img src="Images/icon_5.gif"></td>
                            <td width="350">
                                <div>
                                    档案登记</div>
                            </td>
                            <td width="80" align="right">
                                <a href="">进入&gt;&gt;</a></td>
                        </tr>
                    </table>
                    <table width="500">
                        <asp:Label ID="Lab_Document" runat="server"></asp:Label></table>
                </td>
                <!---- 最外层td  ----->
                <td width="50" rowspan="4">
                    <font face="宋体"></font>
                </td>
                <!---- 最外层td  ----->
                <td width="200" valign="top">
                    <!---- 最外层td  ----->
                    <table width="200" cellspacing="0" cellpadding="0" border="0" style="margin: 0px"
                        class="tableFrame">
                        <tr>
                            <td align="center">

                                <script language="javascript">
							        var tY = <%=System.DateTime.Today.Year%>;
							        var tM = <%=System.DateTime.Today.Month%>;
							        var tD = <%=System.DateTime.Today.Day%>;
							        var cld = new calendar(tY,tM-1);
							        document.write(cld[tD-1].sYear+"年"+cld[tD-1].sMonth+"月"+cld[tD-1].sDay+"日" + "<br>");
							        document.write("星期"+cld[tD-1].week + "<br>");
							        document.write("农历"+nStr1[cld[tD-1].lMonth]+"月"+cDay(cld[tD-1].lDay) + "<br>");
							        var s=cld[tD-1].lunarFestival;
							        if(s.length>0) {
								        s = s.fontcolor('red');
								        document.write (s + "<br>")
							        }
							        var s=cld[tD-1].solarFestival;
							        if(s.length>0) {
								        s = s.fontcolor('blue');
								        document.write (s + "<br>")
							        }
							        var s=cld[tD-1].solarTerms;
							        if(s.length>0){
								        s = s.fontcolor('limegreen');
								        document.write (s + "<br>")
							        }
                                </script>

                            </td>
                        </tr>
                    </table>                  
						
                    <br>
                    <table width="200">
                        <tr>
                            <td width="20">
                                <img src="Images/icon_5.gif" width="16" height="16"></td>
                            <td width="150">
                                个人工具</td>
                        </tr>
                    </table>
                    <table width="200" cellspacing="0" cellpadding="0" border="0" style="margin: 0px"
                        class="tableFrame">
                        <tr>
                            <td height="20">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 20px">
                                <input class="Custom_Button" id="Bun1" onclick="PageGo('')"
                                    type="button" value="办公申请">
                            </td>
                            <td align="center" style="height: 20px">
                                <input class="Custom_Button" id="Bun2" onclick="PageGo('')"
                                    type="button" value="个人名片">
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <input class="Custom_Button" id="Bun3" onclick="PageGo('')"
                                    type="button" value="今日日程">
                            </td>
                            <td align="center">
                                <input class="Custom_Button" id="Butn4" onclick="PageGo('')"
                                    type="button" value="离线设置">
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="height: 21px">
                                <input class="Custom_Button" id="Bun5" onclick="PageGo('')"
                                    type="button" value="修改口令"></td>
                            <td align="center" style="height: 21px">
                                <input class="Custom_Button" id="Bun6" onclick="PageGo('')"
                                    type="button" value="提交错误"></td>
                        </tr>
                        <tr>
                            <td height="20">
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <input class="Custom_Button" id="Bunt7" onclick="PageGo('')"
                                    type="button" value="我的上传">
                            </td>
                            <td align="center">
                                <input class="Custom_Button" id="Butn8" onclick="PageGo('')"
                                    type="button" value="共享下载">
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" height="40">
                                <font color="red" size="4"><b></b></font>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
