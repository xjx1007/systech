<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="OA_Person_Report_Week_Add.aspx.cs"
    Inherits="OA_Person_Report_Add" %>
<%@ Register Src="../../Control/UploadList.ascx" TagName="CommentList" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="x-ua-compatible" content="ie=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="/../themes/softed/style.css" type="text/css">
    <script type="text/javascript" src="/Js/ajax_func.js"></script>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="/../include/js/general.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/prototype.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/scriptaculous.js"></script>
    <script language="javascript" type="text/javascript" src="/../include/scriptaculous/dom-drag.js"></script>
    <script language="javascript" type="text/javascript" src="/DatePicker/WdatePicker.js"></script>
    <script language="javascript">

        function AddProject(aa, i_Num) {
            var v_Person = document.all("Tbx_Person").value;
            var v_Project = aa.parentElement.parentElement.parentElement.parentElement;
            if (v_Project.id == "")
            {
                 v_Project = aa.parentElement.parentElement.parentElement.parentElement.parentElement;
            }
            var i_row = v_Project.rows.length;

            var objRow = v_Project.insertRow(i_row);
            var objCel = objRow.insertCell();
            var v_Num = parseInt(document.all("Tbx_TNum").value);
            var v_DNum = parseInt(document.all("Tbx_DNum").value);
            var v_Htm = "<a href=\"#\" onclick=\"AddProject(this," + v_Num + ")\">添加</a>&nbsp;&nbsp;";
            v_Htm += "<input type=\"hidden\" name=\"Tbx_ID_" + v_Num + "\"  Id=\"Tbx_ID_" + v_Num + "\"  value=" + (parseInt(v_Num) + 1) + " style=\"width: 20px\" >&nbsp;<input type=\"text\" name=\"Tbx_Project_" + v_Num + "\" id=\"Tbx_Project_" + v_Num + "\"  style=\"width: 70%\" value=\"" + (v_Num + 1) + ".\" />";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            v_Htm ="<table width=\"100%\" class=\"ListDetails\">";
            v_Htm += "<tr>";
            v_Htm += "<td class=\"ListHeadDetails\" width=\"24%\">";
            v_Htm += "<a href=\"#\" onclick=\"AddDetails(this," + (parseInt(v_Num) + 1) + ")\">添加</a>&nbsp;&nbsp;";
            v_Htm += "<input type=\"hidden\" name=\"Tbx_FID_" + v_DNum + "\"  Id=\"Tbx_FID_" + v_DNum + "\"  value=" + (parseInt(v_Num) + 1) + " style=\"width: 20px\" >&nbsp;<input type=\"text\" name=\"Tbx_ProjectDetails_" + v_DNum + "\" id=\"Tbx_ProjectDetails_" + v_DNum + "\"  style=\"width: 70%\" value=\"" + (v_Num + 1) + ".1\"  />";
            v_Htm += "</td>";
            v_Htm += "<td class=\"ListHeadDetails\" width=\"24%\">";
            v_Htm += "<input type=\"text\" name=\"Tbx_Person_" + v_DNum + "\" id=\"Tbx_Person_" + v_DNum + "\"  style=\"width: 80%\" value=\"" + v_Person + "\" />";
            v_Htm += "&nbsp;<img  src=\"/../themes/softed/images/select.gif\" onclick=\"return btnGetPerson_onclick('Tbx_Person_" + v_DNum + "')\" />";
            v_Htm += "</td>";
            v_Htm += "<td class=\"ListHeadDetails\" width=\"24%\">";
            v_Htm += "<input type=\"text\" name=\"Tbx_Time_" + v_DNum + "\" id=\"Tbx_Time_" + v_DNum + "\"  style=\"width: 80%\" value=\"\" />";
            v_Htm += "<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/../themes/softed/images/delete.gif\"  border=0></A>";
            v_Htm += "</td>";
            v_Htm += "</tr>";
            v_Htm += "</table>";
            objCel.colSpan = 3;
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";

            var objCel = objRow.insertCell();
            v_Htm = "<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/../themes/softed/images/delete.gif\"  border=0></A>";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            document.all("Tbx_TNum").value = v_Num+1;
            document.all("Tbx_DNum").value = v_DNum+1;
        }

        function AddDetails(aa, cc) {
            var v_Person = document.all("Tbx_Person").value;
            var v_Project = aa.parentElement.parentElement.parentElement.parentElement;
            var i_row = v_Project.rows.length;
            var objRow = v_Project.insertRow(i_row);
            var v_DNum = parseInt(document.all("Tbx_DNum").value);
            var objCel = objRow.insertCell();
            v_Htm = "<a href=\"#\" onclick=\"AddDetails(this,"+cc+")\">添加</a>&nbsp;&nbsp;";
            v_Htm += "<input type=\"hidden\" name=\"Tbx_FID_" + v_DNum + "\"  Id=\"Tbx_FID_" + v_DNum + "\"  value=" + cc + "  style=\"width: 20px\">&nbsp;<input type=\"text\" name=\"Tbx_ProjectDetails_" + v_DNum + "\" id=\"Tbx_ProjectDetails_" + v_DNum + "\"  style=\"width: 70%\" value=\"" + cc + "." + parseInt(i_row + 1) + "\" />";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            objCel.style.width = "33%";

            var objCel = objRow.insertCell();
            v_Htm = "<input type=\"text\" name=\"Tbx_Person_" + v_DNum + "\" id=\"Tbx_Person_" + v_DNum + "\"  style=\"width: 80%\" value=\"" + v_Person + "\" />";
            v_Htm += "&nbsp;<img  src=\"/../themes/softed/images/select.gif\" onclick=\"return btnGetPerson_onclick('Tbx_Person_" + v_DNum + "')\" />";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            objCel.style.width = "33%";

            var objCel = objRow.insertCell();
            v_Htm = "<input type=\"text\" name=\"Tbx_Time_" + v_DNum + "\" id=\"Tbx_Time_" + v_DNum + "\"  style=\"width: 80%\" value=\"\" />";
            v_Htm += "<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/../themes/softed/images/delete.gif\"  border=0></A>";
           
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            objCel.style.width = "33%";
            document.all("Tbx_DNum").value = v_DNum + 1;
        }

        function AddProject1(aa, i_Num) {
            var v_Person = document.all("Tbx_Person").value;
            var v_Project = aa.parentElement.parentElement.parentElement.parentElement;
            if (v_Project.id == "") {
                v_Project = aa.parentElement.parentElement.parentElement.parentElement.parentElement;
            }
            var i_row = v_Project.rows.length;
            var objRow = v_Project.insertRow(i_row);
            var objCel = objRow.insertCell();
            var v_Num = parseInt(document.all("Tbx_TNum1").value);
            var v_DNum = parseInt(document.all("Tbx_DNum1").value);

            var v_Htm = "<a href=\"#\" onclick=\"AddProject1(this," + v_Num + ")\">添加</a>&nbsp;&nbsp;";
            v_Htm += "<input type=\"hidden\" name=\"Tbx_ID1_" + v_Num + "\"  Id=\"Tbx_ID1_" + v_Num + "\"  value=" + (parseInt(v_Num) + 1) + " style=\"width: 20px\" >&nbsp;<input type=\"text\" name=\"Tbx_Project1_" + v_Num + "\" id=\"Tbx_Project1_" + v_Num + "\"  style=\"width: 70%\" value=\"" + (v_Num + 1) + ".\" />";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            var objCel = objRow.insertCell();
            v_Htm = "<table width=\"100%\" class=\"ListDetails\">";
            v_Htm += "<tr>";
            v_Htm += "<td class=\"ListHeadDetails\" width=\"24%\">";
            v_Htm += "<a href=\"#\" onclick=\"AddDetails1(this," + (parseInt(v_Num) + 1) + ")\">添加</a>&nbsp;&nbsp;";
            v_Htm += "<input type=\"hidden\" name=\"Tbx_FID1_" + v_DNum + "\"  Id=\"Tbx_FID1_" + v_DNum + "\"  value=" + (parseInt(v_Num) + 1) + " style=\"width: 20px\" >&nbsp;<input type=\"text\" name=\"Tbx_ProjectDetails1_" + v_DNum + "\" id=\"Tbx_ProjectDetails1_" + v_DNum + "\"  style=\"width: 70%\" value=\"" + (v_Num + 1) + ".1\"  />";
            v_Htm += "</td>";
            v_Htm += "<td class=\"ListHeadDetails\" width=\"24%\">";
            v_Htm += "<input type=\"text\" name=\"Tbx_Person1_" + v_DNum + "\" id=\"Tbx_Person1_" + v_DNum + "\"  style=\"width: 80%\" value=\"" + v_Person + "\" />";
            v_Htm += "&nbsp;<img  src=\"/../themes/softed/images/select.gif\" onclick=\"return btnGetPerson_onclick('Tbx_Person1_" + v_DNum + "')\" />";
            v_Htm += "</td>";
            v_Htm += "<td class=\"ListHeadDetails\" width=\"24%\">";
            v_Htm += "<input type=\"text\" name=\"Tbx_Time1_" + v_DNum + "\" id=\"Tbx_Time1_" + v_DNum + "\"  style=\"width: 80%\" value=\"\" />";
            v_Htm += "<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/../themes/softed/images/delete.gif\"  border=0></A>";
            v_Htm += "</td>";
            v_Htm += "</tr>";
            v_Htm += "</table>";
            objCel.colSpan = 3;
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";

            var objCel = objRow.insertCell();
            v_Htm = "<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/../themes/softed/images/delete.gif\"  border=0></A>";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            document.all("Tbx_TNum1").value = v_Num + 1;
            document.all("Tbx_DNum1").value = v_DNum + 1;
        }
        function AddDetails1(aa, cc) {
            var v_Person = document.all("Tbx_Person").value;
            var v_Project = aa.parentElement.parentElement.parentElement.parentElement;
            var i_row = v_Project.rows.length;
            var objRow = v_Project.insertRow(i_row);
            var v_DNum = parseInt(document.all("Tbx_DNum1").value);
            var objCel = objRow.insertCell();
            v_Htm = "<a href=\"#\" onclick=\"AddDetails1(this," + cc + ")\">添加</a>&nbsp;&nbsp;";
            v_Htm += "<input type=\"hidden\" name=\"Tbx_FID1_" + v_DNum + "\"  Id=\"Tbx_FID1_" + v_DNum + "\"  value=" + cc + "  style=\"width: 20px\">&nbsp;<input type=\"text\" name=\"Tbx_ProjectDetails1_" + v_DNum + "\" id=\"Tbx_ProjectDetails1_" + v_DNum + "\"  style=\"width: 70%\" value=\"" + cc + "." + parseInt(i_row + 1) + "\" />";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            objCel.style.width = "33%";

            var objCel = objRow.insertCell();
            v_Htm = "<input type=\"text\" name=\"Tbx_Person1_" + v_DNum + "\" id=\"Tbx_Person1_" + v_DNum + "\"  style=\"width: 80%\" value=\"" + v_Person + "\" />";
            v_Htm += "&nbsp;<img  src=\"/../themes/softed/images/select.gif\" onclick=\"return btnGetPerson_onclick('Tbx_Person1_" + v_DNum + "')\" />";
            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            objCel.style.width = "33%";

            var objCel = objRow.insertCell();
            v_Htm = "<input type=\"text\" name=\"Tbx_Time1_" + v_DNum + "\" id=\"Tbx_Time1_" + v_DNum + "\"  style=\"width: 80%\" value=\"\" />";
            v_Htm += "<A onclick=\"deleteRow(this)\" href=\"#\"><img src=\"/../themes/softed/images/delete.gif\"  border=0></A>";

            objCel.innerHTML = v_Htm;
            objCel.className = "ListHeadDetails";
            objCel.style.width = "33%";
            document.all("Tbx_DNum1").value = v_DNum + 1;
        }
        function btnGetPerson_onclick(aa) {
            var today, seconds;
            today = new Date();
            var v_ReceiveName = document.all('' + aa + '').value;
            intSeconds = today.getSeconds();
            var temp = window.showModalDialog("/Common/SelectDeptPerson.aspx?ID=" + intSeconds + "", "", "dialogtop=150px;dialogleft=160px;help=no;toolbar=no; menubar=no;scrollbars=yes; resizable=yes; location=no; status=no; dialogwidth=850px;dialogHeight=500px");
            if (temp == undefined) {
                temp = window.returnValue;
            }
            if (temp != undefined) {
                var ss, s_Receive;
                ss = temp.split("|");
                s_Receive = ss[0].split(",");
                s_ReceiveName = ss[1].split(",");
                for (var i = 0; i < s_ReceiveName.length; i++) {
                    if (v_ReceiveName.indexOf(s_ReceiveName[i]) < 0) {
                        v_ReceiveName = v_ReceiveName + "," + s_ReceiveName[i];
                    }
                }

                if (v_ReceiveName.substring(0, 1) == ",") {
                    document.all('' + aa + '').value = v_ReceiveName.substring(1, v_ReceiveName.length);
                }
                else {
                    document.all('' + aa + '').value = v_ReceiveName;
                }

            }
            else {
                document.all(''+aa+'').value = "";
            }
        }

        function deleteRow(aa) {
            var v_Project = aa.parentElement.parentElement.parentElement.parentElement;
            if (v_Project.rows == undefined) {
                v_Project = aa.parentElement.parentElement.parentElement.parentElement.parentElement;
            }
            v_Project.deleteRow(aa.parentElement.parentElement.rowIndex);
        }
    </script>
    <title>周报添加</title>
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form2" runat="server">
        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="small">
            <tr>
                <td style="height: 2px"></td>
            </tr>
            <tr>
                <td style="padding-left: 10px; padding-right: 50px" class="moduleName" nowrap>工作台 > <a class="hdrLink" href="OA_Person_Report_List.aspx">周报</a>
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
                    <img src="/../themes/softed/images/showPanelTopLeft.gif">
                </td>
                <td class="showPanelBg" valign="top" width="100%">
                    <div class="small" style="padding: 20px">
                        <span class="lvtHeaderText">
                            <asp:Label runat="server" ID="Lbl_Title"></asp:Label></span>
                        <br>
                        <hr noshade size="1">
                        <table width="99%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellspacing="0" cellpadding="3" width="100%" class="small">
                                        <tr>
                                            <td class="dvtTabCache" style="width: 10px" nowrap>&nbsp;
                                            </td>
                                            <td class="dvtSelectedCell" align="center" nowrap>周报
                                            </td>
                                            <td class="dvtTabCache" style="width: 10px">&nbsp;
                                            </td>
                                            <td class="dvtTabCache" style="width: 100%" align="center">&nbsp;
                                            <asp:LinkButton runat="server" ID="Lbl_Pre" Text="<" OnClick="Lbl_Pre_Click"></asp:LinkButton>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label runat="server" ID="Lbl_Days"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:LinkButton runat="server" ID="Lbl_Next" Text=">" OnClick="Lbl_Next_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="dvtContentSpace">
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>1.本周计划（由上周拟定）</b>
                                                <pc:PTextBox ID="Tbx_STime" runat="server" CssClass="Custom_Hidden" onFocus="WdatePicker()"
                                                    AllowEmpty="false"></pc:PTextBox>
                                                <asp:DropDownList runat="server" ID="Ddl_DutyPerson" CssClass="Custom_Hidden"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellInfo" width="24%" align="left" colspan="4">
                                                
                                                <table class="ListDetails" id="Table2" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">分项</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                    </tr>
                                                <asp:Label runat="server" ID="Lbl_ThisReport"></asp:Label>
                                                    </table>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>2.本周总结</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="dvtCellInfo" width="34%" align="left" colspan="4">
                                                
                                                <table class="ListDetails" id="This_Project" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">分项</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                        <td class="ListHead" width="3%">删除</td>
                                                    </tr>
                                                    <tr runat="server" id="Tr_ThisReport">

                                                        <td class="ListHeadDetails" width="25%" nowrap>
                                                            <a href="#" onclick="AddProject(this,1)">添加</a>
                                                                        <input type="hidden" name="Tbx_ID_0"  Id="Tbx_ID_0"  value="1" >
                                                            <input type="text" name="Tbx_Project_0" id="Tbx_Project_0" runat="server" style="width: 70%" value="1." />
                                                        </td>
                                                        <td class="ListHeadDetails" colspan="3" width="72%" nowrap>
                                                            <table width="100%" class="ListDetails">
                                                                <tr>
                                                                    <td class="ListHeadDetails" width="24%">
                                                                        <a href="#" onclick="AddDetails(this,1)">添加</a>
                                                                        <input type="hidden" name="Tbx_FID_0"  Id="Tbx_FID_0"  value="1" >

                                                            <input type="text" name="Tbx_ProjectDetails_0" id="Tbx_ProjectDetails_0" runat="server" style="width: 70%" value="1.1" />
                                                                    </td>
                                                                    <td class="ListHeadDetails" width="24%">
                                                                        <input type="text" name="Tbx_Person_0" id="Tbx_Person_0" runat="server" style="width: 80%"  />
                                                                         <img  src="/../themes/softed/images/select.gif" 
                                                                onclick="return btnGetPerson_onclick('Tbx_Person_0')" />
                                                                    </td>
                                                                    <td class="ListHeadDetails" width="24%">
                                                                        <input type="text" name="Tbx_Time_0" id="Tbx_Time_0" runat="server" style="width: 80%" value="" />
                                                                        <a onclick="deleteRow(this)" href="#">
                                                                            <img src="/../themes/softed/images/delete.gif" border="0"></a>
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="ListHeadDetails" width="3%">
                                                            <a onclick="deleteRow(this)" href="#">
                                                                <img src="/../themes/softed/images/delete.gif" border="0"></a>
                                                        </td>

                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_ThisProject"></asp:Label>
                                                </table>
                                                <pc:PTextBox ID="Tbx_ThisReport" runat="server" Width="95%" Height="100px" CssClass="Custom_Hidden"></pc:PTextBox>
                                         
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>3.下周计划</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="dvtCellInfo" width="34%" align="left" colspan="4">
                                                
                                                <table class="ListDetails" id="Table1" width="100%">
                                                    <tr>
                                                        <td class="ListHead" width="25%">项目</td>
                                                        <td class="ListHead" width="24%">分项</td>
                                                        <td class="ListHead" width="24%">负责人</td>
                                                        <td class="ListHead" width="24%">时间</td>
                                                        <td class="ListHead" width="3%">删除</td>
                                                    </tr>
                                                    <tr runat="server" id="Tr_NextReport">

                                                        <td class="ListHeadDetails" width="25%" nowrap>
                                                            <a href="#" onclick="AddProject1(this,1)">添加</a>
                                                                        <input type="hidden" name="Tbx_ID1_0"  Id="Tbx_ID1_0"  value="1" >
                                                            <input type="text" name="Tbx_Project1_0" id="Tbx_Project1_0" runat="server" style="width: 70%" value="1." />
                                                        </td>
                                                        <td class="ListHeadDetails" colspan="3" width="72%" nowrap>
                                                            <table width="100%" class="ListDetails">
                                                                <tr>
                                                                    <td class="ListHeadDetails" width="24%">
                                                                        <a href="#" onclick="AddDetails1(this,1)">添加</a>
                                                                        <input type="hidden" name="Tbx_FID1_0"  Id="Tbx_FID1_0"  value="1" >

                                                            <input type="text" name="Tbx_ProjectDetails1_0" id="Tbx_ProjectDetails1_0" runat="server" style="width: 70%" value="1.1" />
                                                                    </td>
                                                                    <td class="ListHeadDetails" width="24%">
                                                                        <input type="text" name="Tbx_Person1_0" id="Tbx_Person1_0" runat="server" style="width: 80%"  />
                                                                         <img  src="/../themes/softed/images/select.gif" 
                                                                onclick="return btnGetPerson_onclick('Tbx_Person_0')" />
                                                                    </td>
                                                                    <td class="ListHeadDetails" width="24%">
                                                                        <input type="text" name="Tbx_Time1_0" id="Tbx_Time1_0" runat="server" style="width: 80%" value="" />
                                                                        <a onclick="deleteRow(this)" href="#">
                                                                            <img src="/../themes/softed/images/delete.gif" border="0"></a>
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td class="ListHeadDetails" width="3%">
                                                            <a onclick="deleteRow(this)" href="#">
                                                                <img src="/../themes/softed/images/delete.gif" border="0"></a>
                                                        </td>

                                                    </tr>
                                                    <asp:Label runat="server" ID="Lbl_NextProject"></asp:Label>
                                                </table>
                                                <pc:PTextBox ID="Tbx_NextReport" runat="server" Width="95%" Height="100px" CssClass="Custom_Hidden"></pc:PTextBox>
                                          
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>4.附件</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4">
                                                <uc2:CommentList ID="CommentList2" runat="server" CommentFID="0" CommentType="-1" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="detailedViewHeader">
                                                <b>4.当周报告参考</b>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" valign="top">
                                                <asp:Label runat="server" ID="Lbl_Details"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" align="center" style="height: 30px">
                                                <br />
                                                <asp:Button ID="Btn_Save" runat="server" Text="暂 存" AccessKey="S" title="保存 [Alt+S]"
                                                    class="crmbutton small save" OnClick="Btn_Send_Click" Style="height: 30px; width: 70px" />
                                                <asp:Button ID="Button1" runat="server" Text="提 交" AccessKey="T" title="保存 [Alt+T]"
                                                    class="crmbutton small save" Style="height: 30px; width: 70px" OnClick="Button1_Click" />

                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <asp:TextBox ID="Tbx_ID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_NID" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Type" runat="server" CssClass="Custom_Hidden"></asp:TextBox>
                        <asp:TextBox ID="Tbx_TNum" runat="server" CssClass="Custom_Hidden" Text="1"></asp:TextBox>
                        <asp:TextBox ID="Tbx_DNum" runat="server" CssClass="Custom_Hidden" Text="1"></asp:TextBox>
                        <asp:TextBox ID="Tbx_TNum1" runat="server" CssClass="Custom_Hidden" Text="1"></asp:TextBox>
                        <asp:TextBox ID="Tbx_DNum1" runat="server" CssClass="Custom_Hidden" Text="1"></asp:TextBox>
                        <asp:TextBox ID="Tbx_Person" runat="server" CssClass="Custom_Hidden" Text="1"></asp:TextBox>
                </td>

                <td align="right" valign="top">
                    <img src="/../themes/softed/images/showPanelTopRight.gif" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
