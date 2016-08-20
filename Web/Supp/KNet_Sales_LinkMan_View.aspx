<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KNet_Sales_LinkMan_View.aspx.cs" Inherits="Web_Sales_KNet_Sales_LinkMan_View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link rel="stylesheet" href="../../themes/softed/style.css" type="text/css">
<title>联系人查看</title>
<script type="text/javascript" src="../Js/ajax_func.js"></script>
<script language="JavaScript" src="../Js/Global.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript" src="../DatePicker/WdatePicker.js"></script>
<script language="JavaScript" type="text/javascript" src="../../include/js/general.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/prototype.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/scriptaculous.js"></script>
<script language="javascript" type="text/javascript" src="../../include/scriptaculous/dom-drag.js"></script>	
</head>
<body topmargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" runat="server">

<table border="0" cellspacing=0 cellpadding=0 width=100% class=small>
<tr><td style="height:2px"></td></tr>
<tr>
	<td style="padding-left:10px;padding-right:50px" class="moduleName" nowrap>联系人 > 
	<a class="hdrLink" href="KNet_Sales_LinkMan_List.aspx">联系人</a>
        </td>
	<td width=100% nowrap>
 <asp:Label ID="Tbx_ID" runat="server" style="display:none"></asp:Label>&nbsp;
	</td>
</tr>
<tr><td style="height:2px"></td></tr>
</table>



<table border="0" cellspacing="0" cellpadding="0" width="98%" align="center">
   <tr>
   	<td valign="top"><img src="../../themes/softed/images/showPanelTopLeft.gif"></td>
	<td class="showPanelBg" valign="top" width="100%">
	     	     <div class="small" style="padding:10px"></div>
	 			<span class="lvtHeaderText"><asp:Label runat="server" ID="Lbl_Title"></asp:Label>&nbsp;</span> <br>
                <hr noshade size=1>
                                
                <table width="95%" border="0" align="center"  cellpadding="0" cellspacing="0"   >
                            <tr valign="bottom">
                                <td style="height: 44px">
                                    <table border=0 cellspacing=0 cellpadding=3 width=100% class="small">
                                    <tr>
                                    <td class="dvtTabCache" style="width:10px" nowrap>&nbsp;</td>
                                    <td class="dvtSelectedCell" align="center" nowrap>联系人信息</td>
                                    <td class="dvtTabCache" style="width:10px">&nbsp;</td>										
                                    <td class="dvtUnSelectedCell" align="center" nowrap>
                                    <a href="#">相关信息</a></td>
                                    <td class="dvtTabCache" style="width:100%">&nbsp;</td>
                                    </tr>
                                    </table>
                                </td>
                            </tr>		
                            <tr>
                            <td>
                            <table border=0 cellspacing=3 cellpadding=3  width=100% class="dvtContentSpace">
							
                            <tr>
                                <td valign=top align=left >
                                    <table border=0 cellspacing=0 cellpadding=0 width=100%><tr><td>
                                    <input title="编辑 [Alt+E]" type="button" accessKey="E" class="crmbutton small edit" onclick="PageGo('KNet_Sales_LinkMan_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>')" name="Edit" value="&nbsp;编辑&nbsp;" >&nbsp;
                                    <input title="共享" class="crmbutton small edit" onclick="" type="button" name="Share" value="&nbsp;共享&nbsp;" >&nbsp;
                                    <input title="" class="crmbutton small edit" onclick="PageGo('KNet_Sales_LinkMan_List.aspx')" type="button" name="ListView" value="&nbsp;返回列表&nbsp;" >&nbsp;</td>
                                    <td align=right>
                                    <input title="复制 [Alt+U]" type="button" accessKey="U" class="crmbutton small create" onclick="PageGo('KNet_Sales_LinkMan_Add.aspx?ID=<%= Request.QueryString["ID"].ToString() %>&Type=1')"name="Duplicate" value="复制"  >&nbsp;
                                    <input title="刪除 [Alt+D]" type="button" accessKey="D" class="crmbutton small delete" onclick=" return confirm('确定要删除这个记录吗?')" name="Delete" value="删除" >&nbsp;
                                    </td></tr>
                                    </table>
                                </td>
                                <td width=22% valign=top style="border-left:2px dashed #cccccc;padding:13px" rowspan="3">
                                    <table width="100%" border="0" cellpadding="5" cellspacing="0">
                                    <tr>
                                    <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                    <td align="left" class="genHeaderSmall">操作</td>
                                    </tr>
                                    <!-- Module based actions starts -->

                                    <tr>
                                    <td align="left" style="padding-left:10px;">
                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <a href="../Cg/CgContent/Xs_Sales_Content_Add.aspx?CustomerValue=<%=s_CustomerValue %>" class="webMnu">创建联系记录</a> 

                                    </td>
                                    </tr>
                                    <tr>
                                    <td align="left" style="padding-left:10px;">
                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <a href="#" onclick="window.open('upload.php?return_action=DetailView&return_module=Contacts&return_id=869','Attachments','width=500,height=300');" class="webMnu">创建附件</a> 
                                    </td>
                                    </tr>
                                    <tr>
                                    <td align="left" style="padding-left:10px;">
                                    <img src="../../themes/softed/images/pointer.gif" hspace="5" align="middle"/>
                                    <a href="#" class="webMnu">创建日程安排</a> 
                                    </td>
                                    </tr>

                                    </table>
                                </td>
                             </tr>
                             <tr>
                                 <td>
                                        <table border=0 cellspacing=0 cellpadding=0 width=100% class="small">
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>基本信息</b>
                                        <asp:Label ID="Lbl_Code" runat="server" CssClass="Custom_Hidden"></asp:Label>&nbsp;
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >姓名:</td>
                                        <td class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Name"  runat="server"  Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        <td  class="dvtCellLabel" >称呼:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_CallName" runat="server" ></asp:Label>&nbsp;
                                        </td>
                                        </tr>

                                        <tr>
                                        <td  class="dvtCellLabel" > 英文名:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_EnglishName"  runat="server"  Width="150px"></asp:Label>&nbsp;</td>
                                        <td  class="dvtCellLabel" >负责业务:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Responsible"  runat="server"  Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        </tr>
                                        <tr>
                                        <td width="17%"  class="dvtCellLabel" >客户:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_CompyName" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>&nbsp;
                                        </td>

                                        <td  class="dvtCellLabel" >负责人:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_DutyPerson" runat="server"  Width="178px" ReadOnly="true" ></asp:Label>&nbsp;
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel">
                                        手机:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Phone" runat="server"   Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        <td  class="dvtCellLabel" >
                                        传真:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Fax" runat="server"   Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        </tr>

                                        <tr>
                                        <td   class="dvtCellLabel">
                                        Email:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Mail" runat="server"   Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        <td   class="dvtCellLabel">
                                        住宅电话:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Homephone" runat="server"   Width="150px"></asp:Label>&nbsp;</td>
                                        </tr>

                                        <tr>
                                        <td  class="dvtCellLabel" >办公电话:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Officephone" runat="server"   Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        <td  class="dvtCellLabel" >QQ:</td>
                                        <td  class="dvtCellInfo">
                                        <img border="0" src="../../themes/softed/images/qq.gif"  align="middle"><asp:Label ID="Lbl_QQ" runat="server"   Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        </tr>

                                        <tr>
                                        <td   class="dvtCellLabel" >经理:</td>
                                        <td  class="dvtCellInfo" colspan="3"  >
                                        <asp:Label ID="Lbl_Manager" runat="server"   Width="150px"></asp:Label>&nbsp;

                                        </td> 
                                        </tr>

                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>其他信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel" >学历:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Education"    runat="server" Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        <td   class="dvtCellLabel" >部门:</td>
                                        <td  class="dvtCellInfo"  >
                                        <asp:Label ID="Lbl_Duty"    runat="server" Width="150px"></asp:Label>&nbsp;
                                        </td> 
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel">年龄:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Age" runat="server"   Width="150px"></asp:Label>&nbsp;</td>
                                        <td  class="dvtCellLabel">性别:</td>
                                        <td  class="dvtCellInfo">

                                        <asp:Label ID="Lbl_Sex"    runat="server" Width="150px"></asp:Label>&nbsp;

                                        </td>
                                        </tr>
                                        <tr>
                                        <td  class="dvtCellLabel">生日:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Birthday" runat="server"   Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        <td  class="dvtCellLabel" >
                                        籍贯:</td>
                                        <td width="33%"  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Place"    runat="server" Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel">民族:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Nation" runat="server" Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        <td  class="dvtCellLabel" >婚姻:</td>
                                        <td width="33%"  class="dvtCellInfo">     
                                        <asp:Label ID="Lbl_Marriage"    runat="server" Width="150px"></asp:Label>&nbsp;</td>
                                        </tr>
                                        <tr>
                                        <td colspan=4 class="detailedViewHeader"><b>描述信息</b>
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel">用户名:</td>
                                        <td  class="dvtCellInfo">
                                        <asp:Label ID="Lbl_Card" runat="server" Width="150px"></asp:Label>&nbsp;
                                        </td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >爱好/特长:</td>
                                        <td   valign="top" class="dvtCellInfo"  ><asp:Label ID="Lbl_Hobby"  runat="server"></asp:Label>&nbsp;</td>

                                        <td   class="dvtCellLabel" >地址:</td>
                                        <td   valign="top" class="dvtCellInfo"  ><asp:Label ID="Lbl_Address"  runat="server"></asp:Label>&nbsp;</td>
                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >物流地址:</td>
                                        <td   valign="top" class="dvtCellInfo"  ><asp:Label ID="Lbl_LogisticsAddress"  runat="server"></asp:Label>&nbsp;</td>
                                        <td   class="dvtCellLabel" >评价:</td>
                                        <td   valign="top" class="dvtCellInfo"  ><asp:Label ID="Lbl_Evaluation"  runat="server"></asp:Label>&nbsp;</td>

                                        </tr>
                                        <tr>
                                        <td   class="dvtCellLabel" >工作履历:</td>
                                        <td  valign="top" class="dvtCellInfo"  ><asp:Label ID="Lbl_Experience"  runat="server"></asp:Label>&nbsp;</td>

                                        <td   class="dvtCellLabel" >备注说明:</td>
                                        <td  valign="top" class="dvtCellInfo"  ><asp:Label ID="Lbl_Remark" runat="server"></asp:Label>&nbsp;</td>
                                        </tr>
                                        </table>
                                        
                                  </td>
                             </tr>
                             <tr> 
                                <td align="right" valign="middle" >						
                                <input class="crmbutton small edit" type="button" onclick="window.open('index.php?module=Accounts&return_module=Noteplans&return_action=DetailView&parenttab=Customer&action=Popup&popuptype=detailview&select=enable&form=EditView&form_submit=false&recordid=1599','test','width=700,height=602,resizable=1,scrollbars=1');" value=" 选择客户 ">&nbsp;
                                <input class="crmbutton small edit" type="button" onclick="fnvshobj(this,'assignaccountdiv');callAssignaccountDiv(1599)" value=" 分配客户 ">
                                </td>
                             </tr>
							</table>
                            </td>
                            </tr>
                </table>
    </td>
    <td valign="top"><img src="../../themes/softed/images/showPanelTopRight.gif"></td>
                                        
   </tr>
</table>


    </form>
</body>
</html>
<%--收货单信息  结束--%>

