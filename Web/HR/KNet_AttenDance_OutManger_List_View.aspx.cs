using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.IO;
using System.Text;

using KNet.DBUtility;
using KNet.Common;

public partial class KNet_AttenDance_OutManger_List_View : BasePage
{
    public string s_Time = "";
    public string s_HouseName = "";
    public string s_Details = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin() == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');parent.location.href = '/Default.aspx';</script>");
                Response.End();
            }
            string s_StartDate = Request.QueryString["StartDate"] == null ? "" : Request.QueryString["StartDate"].ToString();
            string s_EndDate = Request.QueryString["EndDate"] == null ? "" : Request.QueryString["EndDate"].ToString();
            string s_Dept = Request.QueryString["Dept"] == null ? "" : Request.QueryString["Dept"].ToString();
            string s_DutyPerson = Request.QueryString["DutyPerson"] == null ? "" : Request.QueryString["DutyPerson"].ToString();
            
            string s_ProductsEdition = Request.QueryString["ProductsEdition"] == null ? "" : Request.QueryString["ProductsEdition"].ToString();
            TimeSpan ts = DateTime.Parse(s_EndDate) - DateTime.Parse(s_StartDate); 
            int day = ts.Days;
            //人员
            string s_Sql = "Select *";
            s_Sql += " from KNet_Resource_Staff  ";
            s_Sql += "  Where StaffNo<>'admin' and StaffDepart<>'129652783693249229' and staffYN='0'";

            if (s_DutyPerson!="")
            {
                s_Sql += " and StaffNo='" + s_DutyPerson + "' ";
            }
            if (s_Dept != "")
            {
                s_Sql += " and StaffDepart='" + s_Dept + "' ";
            }
            s_Sql += " Order by StaffName,StaffDepart";
            string s_Style = "";
            string s_Head = "";
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                for (int i = 0; i < Dtb_Table.Rows.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        s_Style = "class='gg'";
                    }
                    else
                    {
                        s_Style = "class='rr'";
                    }
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    s_Details += "<td class='thstyleLeftDetails' align=center rowspan=\"2\"  noWrap>" + (i + 1).ToString() + "</td>\n";
                    s_Details += "<td  class='thstyleLeftDetails' align=left rowspan=\"2\"  noWrap>&nbsp;" + Dtb_Table.Rows[i]["StaffName"].ToString() + "</td>\n";

                    for (int j = 0; j <= day; j++)
                    {
                        DateTime d_Time = DateTime.Parse(s_StartDate).AddDays(j);
                        s_Details += "<td  class='thstyleLeftDetails' align=center  rowspan=\"1\" width=\"20px\">&nbsp;" + GetState(Dtb_Table.Rows[i]["StaffNo"].ToString(), d_Time, 0) + "</td>\n";
                    }
                    this.BeginQuery("Select * from PB_Basic_Code where PBC_ID='151' order by PBC_Code ");
                    this.QueryForDataSet();
                    DataTable Dtb_BasicTable1 = this.Dts_Result.Tables[0].Copy();
                    {
                        for (int j = 0; j < Dtb_BasicTable1.Rows.Count; j++)
                        {
                            s_Details += "<td class=\"thstyleLeftDetails\"  rowspan=\"2\" noWrap  align=center>&nbsp;" + GetTimes(Dtb_Table.Rows[i]["StaffNo"].ToString(), s_StartDate, s_EndDate, int.Parse(Dtb_BasicTable1.Rows[j]["PBC_Code"].ToString())) + "</td>\n";
                        }
                    }
                    s_Details += "<td class=\"thstyleLeftDetails\" rowspan=\"2\" align=center>&nbsp;</td>\n";
                    s_Details += " </tr>";
                    s_Details += " <tr " + s_Style + " onmouseover='setActiveBG(this)'>\n";
                    for (int j = 0; j <= day; j++)
                    {
                        DateTime d_Time = DateTime.Parse(s_StartDate).AddDays(j);
                        s_Details += "<td  class='thstyleLeftDetails' align=center  rowspan=\"1\" width=\"20px\">&nbsp;" + GetState(Dtb_Table.Rows[i]["StaffNo"].ToString(), d_Time, 1) + "</td>\n";
                    }
                    s_Details += " </tr>";
                }
            }

            
            s_Details += "</td ></tr>";
            this.BeginQuery("Select * from PB_Basic_Code where PBC_ID='151' order by PBC_Code ");
            this.QueryForDataTable();
            DataTable Dtb_BasicTable = this.Dtb_Result.Copy();

            s_Details += "<tr ><td colspan=" + Convert.ToString(day + Dtb_BasicTable.Rows.Count + 3) + ">";
            s_Details += " <br/>备注：1、每位员工每日分上、下午考勤，每个方格栏内上列为上午，下列为下午，出勤情况统计栏应真实填写每位员工当月实际出勤日,以半天为单位。出勤情况统计栏下各分项栏所填写天数的合计数为当月的日历天总数。<br/>";
            s_Details += "2、考勤代号：⒈出勤（√）、旷工（旷）、事假（事）、病假（病）、工伤（伤）、婚丧（婚或丧）、年假（年）、调休（调）、生育（生）、出差（差）、公休（休）、看护（看）、法定假（法）、上班登记（上）、下班登记（下）、晚打卡申请（晚）、早打开申请（早 ）。<br/>";
            s_Details += "3、以上签字内容真实、有效。";
            s_Details += "</tbody></table></td></tr>";
            s_Time = "日期:" + s_StartDate + " 到" + s_EndDate;
            s_Head += "<div class=\"tableContainer\" id=\"tableContainer\" >\n";
            s_Head += "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\" class=\"scrollTable\">\n<thead class=\"fixedHeader\"> \n";
            s_Head += "<tr>\n<th colspan=" + Convert.ToString(day + Dtb_BasicTable.Rows.Count +3)+ " class=\"MaterTitle\" style='height:14.25pt'>杭州士腾科技有限公司<br/>考勤表</th></tr>\n";
            s_Head += "<tr>\n";
            s_Head += "<th class=\"thstyle\" rowspan=\"2\" >序号</th>\n";
            s_Head += "<th class=\"thstyle\" rowspan=\"2\" align=center>姓名</th>\n";
            for (int i = 0; i <= day; i++)
            {
                DateTime d_Time = DateTime.Parse(s_StartDate).AddDays(i);
                s_Head += "<th class=\"thstyle\" rowspan=\"2\" align=center>" + d_Time.Day.ToString() + "</th>\n";
            }
            if (Dtb_BasicTable.Rows.Count > 0)
            {
                s_Head += "<th class=\"thstyle\" rowspan=1  colspan=" + Dtb_BasicTable.Rows.Count.ToString() + " align=center>出勤情况统计(单位：天)</th>\n";
            }
            s_Head += "<th class=\"thstyle\" rowspan=\"2\" align=center>员工确认</th>\n";
            s_Head += "</tr>\n";

            s_Head += "<tr>\n";
            for (int i = 0; i < Dtb_BasicTable.Rows.Count; i++)
            {
                s_Head += "<th class=\"thstyle\"  align=center>" + Dtb_BasicTable.Rows[i]["PBC_Name"].ToString() + "</th>\n";
            }
            s_Head += "</tr>\n";
            s_Head += "</thead><tbody class=\"scrollContent\">";
            s_Details += "</div>";

            this.Lbl_Details.Text = s_Head + s_Details;
        }
    }
    public string GetState(string s_StaffNO, DateTime D_Time, int i_State)
    {
        string s_Return = "√", s_Sql = "";
        try
        {

            string s_PMBeginDate = "", s_PMEndDate = "", s_AMBeginDate = "", s_AMEndDate = "", s_BeginDate = "", s_EndDate = "";
            s_BeginDate = D_Time.ToShortDateString() + " 00:01";
            s_EndDate = D_Time.ToShortDateString() + " 17:25";
            if ((D_Time.Month >= 5) && (D_Time.Month <= 5))//夏令时
            {
                //上午
                s_PMBeginDate = D_Time.ToShortDateString() + " 09:00";
                s_PMEndDate = D_Time.ToShortDateString() + " 11:00";
                s_AMBeginDate = D_Time.ToShortDateString() + " 13:00";
                s_AMEndDate = D_Time.ToShortDateString() + " 17:30";
            }
            else
            {
                //上午
                s_PMBeginDate = D_Time.ToShortDateString() + " 09:00";
                s_PMEndDate = D_Time.ToShortDateString() + " 12:30";
                s_AMBeginDate = D_Time.ToShortDateString() + " 12:30";
                s_AMEndDate = D_Time.ToShortDateString() + " 17:00";
            }

            //找当天是否有请假申请
            if ((D_Time.DayOfWeek.ToString() == "Saturday") || (D_Time.DayOfWeek.ToString() == "Sunday"))
            {
                s_Return = "休";
            }
            s_Sql = " Select cast(dbo.replaceTime(StartDateTime)as DateTime) as BeginDate,cast(dbo.replaceTime(EndDateTime)as DateTime) as EndDate, AddDateTime,thisKings,KRO_Type from KNet_Resource_OutManage ";
            s_Sql += " Where StaffNo='" + s_StaffNO + "'   ";
            if (i_State == 0)//上午
            {
                s_Sql += " and cast(dbo.replaceTime(StartDateTime)as DateTime)<='" + s_PMBeginDate + "' and cast(dbo.replaceTime(EndDateTime)as DateTime)>='" + s_PMEndDate + "'  ";
            }
            else//下午
            {
                s_Sql += " and cast(dbo.replaceTime(StartDateTime)as DateTime)<='" + s_AMBeginDate + "'and cast(dbo.replaceTime(EndDateTime)as DateTime)>='" + s_AMEndDate + "' ";
            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            DataTable Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                //开始日期
                //结束日期
                //添加日期
                //考勤类型
                switch (Dtb_Table.Rows[0]["thisKings"].ToString())
                {
                    case "1"://请假申请
                        if (Dtb_Table.Rows[0]["KRO_Type"].ToString() != "")
                        {
                            s_Return = base.Base_GetBasicCodeName("151", Dtb_Table.Rows[0]["KRO_Type"].ToString()).Substring(0, 1);
                        }
                        break;
                    case "3"://出差
                        s_Return = "差";
                        break;
                }
            }
            //找开始日期在12点以前的外出，
            s_Sql = " Select thisKings,KRO_Type from KNet_Resource_OutManage ";
            s_Sql += " Where StaffNo='" + s_StaffNO + "' and thisKings in ('2','6','7')  ";
            if (i_State == 0)//上午
            {
                s_Sql += " and cast(dbo.replaceTime(StartDateTime)as DateTime)<='" + s_AMBeginDate + "' and  year(cast(dbo.replaceTime(StartDateTime)as DateTime))=year('" + s_AMBeginDate + "') and  Month(cast(dbo.replaceTime(StartDateTime)as DateTime))=Month('" + s_AMBeginDate + "') and  day(cast(dbo.replaceTime(StartDateTime)as DateTime))=day('" + s_AMBeginDate + "')   ";
            }
            else//下午
            {
                s_Sql += " and cast(dbo.replaceTime(StartDateTime)as DateTime)>='" + s_AMBeginDate + "' and  year(cast(dbo.replaceTime(StartDateTime)as DateTime))=year('" + s_AMBeginDate + "') and  Month(cast(dbo.replaceTime(StartDateTime)as DateTime))=Month('" + s_AMBeginDate + "') and  day(cast(dbo.replaceTime(StartDateTime)as DateTime))=day('" + s_AMBeginDate + "')  ";
            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                //开始日期
                //结束日期
                //添加日期
                //考勤类型
                switch (Dtb_Table.Rows[0]["thisKings"].ToString())
                {
                    case "2"://外出申请
                        s_Return = "外";
                        break;
                    case "6"://晚打卡申请
                        s_Return = "晚";
                        break;
                    case "7"://早打卡申请
                        s_Return = "早";
                        break;
                }
            }

            s_Sql = " Select cast(dbo.replaceTime(StartDateTime)as DateTime) as BeginDate,cast(dbo.replaceTime(EndDateTime)as DateTime) as EndDate, AddDateTime,thisKings,KRO_Type from KNet_Resource_OutManage ";
            s_Sql += " Where StaffNo='" + s_StaffNO + "'    ";
            if (i_State == 0)//上午
            {
                s_Sql += " and AddDateTime>= '" + s_BeginDate + "' and AddDateTime<='" + D_Time.ToShortDateString() + " 23:15" + "' ";
            }
            else//下午
            {

                s_Sql += " and AddDateTime>= '" + s_EndDate + "' and AddDateTime<='" + D_Time.ToShortDateString() + " 23:59" + "' ";
            }
            this.BeginQuery(s_Sql);
            this.QueryForDataTable();
            Dtb_Table = this.Dtb_Result;
            if (Dtb_Table.Rows.Count > 0)
            {
                //开始日期
                //结束日期
                //添加日期
                //考勤类型
                switch (Dtb_Table.Rows[0]["thisKings"].ToString())
                {
                    case "4"://上班登记
                        s_Return = "上";
                        break;
                    case "5"://下班登记
                        s_Return = "下";
                        break;
                }

            }
        }
        catch
        { }
        return s_Return;
    }
    public string GetTimes(string s_StaffNO, string s_BeginTime, string s_EndTime, int i_Type)
    {
        string s_Return = "";
          return s_Return;
    }
}
