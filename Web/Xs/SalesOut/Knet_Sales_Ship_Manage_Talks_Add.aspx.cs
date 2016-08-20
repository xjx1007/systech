using System;
using System.Data;
using System.Data.SqlClient;
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

/// <summary>
/// 发货 跟踪信息 添加
/// </summary>
public partial class Knet_Sales_Ship_Manage_Talks_Add : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "发货跟踪信息添加";

        if (!IsPostBack)
        {
            this.BeginQuery("Select * from PB_Basic_Wl ");
            this.QueryForDataTable();
            this.Drop_KD.DataSource = this.Dtb_Result;
            this.Drop_KD.DataTextField = "PBW_Name";
            this.Drop_KD.DataValueField = "PBW_Code";
            this.Drop_KD.DataBind();
            ListItem item = new ListItem("--请选择--", "-1"); //默认值
            Drop_KD.Items.Insert(0, item);
            AdminloginMess AM = new AdminloginMess();
            if (AM.CheckLogin("发货单跟踪") == false)
            {
                Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
                Response.End();
            }
            else
            {
                string s_DirectOutNo = Request.QueryString["DirectOutNo"] == null ? "" : Request.QueryString["DirectOutNo"].ToString();
   
                if (s_DirectOutNo != "")
                {
                    this.Tbx_DirectOutNo.Text = s_DirectOutNo;
                    KNet.BLL.KNet_WareHouse_DirectOutList_Details Bll = new KNet.BLL.KNet_WareHouse_DirectOutList_Details();
                    DataSet Dts_Table = Bll.GetList(" DirectOutNo='" + s_DirectOutNo + "'");
                    this.MyGridView1.DataSource = Dts_Table;
                    this.MyGridView1.DataBind();
                    KNet.BLL.KNet_WareHouse_DirectOutList Bll_DirectOutList = new KNet.BLL.KNet_WareHouse_DirectOutList();
                    KNet.Model.KNet_WareHouse_DirectOutList Model_DirectOutList=Bll_DirectOutList.GetModelB(s_DirectOutNo);
                    if ((Model_DirectOutList.DirectOutCheckYN.ToString() != "2") && (Model_DirectOutList.DirectOutCheckYN.ToString() != "3"))
                    {
                        this.Pan_Details.Visible = true;
                    }
                    else
                    {

                        this.Pan_Details.Visible = false;
                    }
                    this.Tbx_CkTime.Text = DateTime.Parse(Model_DirectOutList.DirectOutDateTime.ToString()).ToShortDateString();
                    this.Tbx_OldTime.Text = DateTime.Parse(Model_DirectOutList.DirectOutDateTime.ToString()).ToShortDateString();
                    this.Tbx_ZwTime.Text = DateTime.Parse(Model_DirectOutList.KWD_CWOutTime.ToString()).ToShortDateString();
                    this.Tbx_ZwOldTime.Text = DateTime.Parse(Model_DirectOutList.KWD_CWOutTime.ToString()).ToShortDateString();
                    
                }
                if (Request.QueryString["DirectOutNo"] != null && Request.QueryString["DirectOutNo"] != "")
                {
                    this.HyperLink2.NavigateUrl = "Knet_Sales_Ship_Manage_Talks_Add.aspx?DirectOutNo=" + Request.QueryString["DirectOutNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                    this.HyperLink1.NavigateUrl = "Knet_Sales_Ship_Manage_Talks_List.aspx?DirectOutNo=" + Request.QueryString["DirectOutNo"].Trim() + "&Sn=" + DateTime.Now.ToFileTimeUtc().ToString() + "";
                }
                else
                {
                    Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                    Response.End();
                }
            }

        }
    }


    /// <summary>
    /// 确定添加
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        AdminloginMess AM = new AdminloginMess();
        if (AM.CheckLogin() == false)
        {
            Response.Write("<script language=javascript>alert('您未登陆系统或已超过，请重新登陆系统!');window.close();</script>");
            Response.End();
        }
        else
        {
            string s_Return = "";
            string OutWareNo = null;
            string FollowNo = DateTime.Now.ToFileTimeUtc().ToString();
            DateTime FollowDateTime = DateTime.Now;
            bool FollowEnd = false;

            string FollowStaffNo = AM.KNet_StaffNo;
            string FollowText = this.FollowText.Text.Trim();


            if (Request.QueryString["DirectOutNo"] != null && Request.QueryString["DirectOutNo"] != "")
            {
                OutWareNo = Request.QueryString["DirectOutNo"].Trim();
            }
            else
            {
                Response.Write("<script language=javascript>alert('非法请求参数！');window.close();</script>");
                Response.End();
            }



            KNet.BLL.KNet_Sales_OutWareList_FlowList BLL = new KNet.BLL.KNet_Sales_OutWareList_FlowList();
            KNet.Model.KNet_Sales_OutWareList_FlowList model = new KNet.Model.KNet_Sales_OutWareList_FlowList();
            model.FollowNo = FollowNo;
            model.OutWareNo = OutWareNo;
            model.FollowDateTime = FollowDateTime;
            model.FollowStaffNo = FollowStaffNo;
            model.FollowText = FollowText;
            model.FollowEnd = FollowEnd;
            model.KDCode = this.Tbx_Code.Text;
            model.KDName = this.Drop_KD.SelectedValue;
            model.KDCodeName = this.Drop_KD.SelectedItem.Text;
            model.ReTime = DateTime.Parse(this.Tbx_OldTime.Text);
            model.KSO_Phone = this.Tbx_Phone.Text;
            if (this.Chk_IsFH.Checked)
            {
                model.KSO_ISFH = 101;
            }
            else
            {
                model.KSO_ISFH = 102;
            }
            try
            {
                    try
                    {
                        string s_Sql = "";

                        if (this.Tbx_ZwTime.Text != this.Tbx_ZwOldTime.Text)
                        {
                            s_Sql += " Update KNet_WareHouse_DirectOutList Set KWD_CWOutTime='" + this.Tbx_ZwTime.Text + "' where DirectOutNo='" + this.Tbx_DirectOutNo.Text + "' ";
                            model.FollowNo += " 修改账务日期为：" + this.Tbx_CkTime.Text + " ";
                        }
                        if (this.Tbx_CkTime.Text != this.Tbx_OldTime.Text)
                        {
                            s_Sql += " Update KNet_WareHouse_DirectOutList Set DirectOutDateTime='" + this.Tbx_CkTime.Text + "' where DirectOutNo='" + this.Tbx_DirectOutNo.Text + "' ";
                            model.FollowNo += " 修改出库日期为：" + this.Tbx_CkTime.Text + " ";
                        }
                        for (int i = 0; i < this.MyGridView1.Rows.Count; i++)
                        {
                            CheckBox Chk_cb = (CheckBox)MyGridView1.Rows[i].Cells[0].FindControl("Chbk");
                            TextBox Tbx_Number = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_Number");
                            TextBox Tbx_BNumber = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_BNumber");
                            
                            String s_OldNumber = MyGridView1.Rows[i].Cells[4].Text;
                            TextBox Tbx_DirectOutUnitPrice = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_DirectOutUnitPrice");

                            TextBox Tbx_DID = (TextBox)MyGridView1.Rows[i].Cells[0].FindControl("Tbx_DID");
                            if (Chk_cb.Checked)
                            {
                                model.FollowNo += " 修改数量";
                                s_Sql += " Update KNet_WareHouse_DirectOutList_Details Set DirectOutAmount='" + decimal.Parse(Tbx_Number.Text).ToString() + "', KWD_BNumber='" + decimal.Parse(Tbx_BNumber.Text).ToString() + "',DirectOutTotalNet='" + Convert.ToString(decimal.Parse(Tbx_Number.Text) * decimal.Parse(Tbx_DirectOutUnitPrice.Text)) + "',KWD_SalesTotalNet=KWD_SalesUnitPrice*" + decimal.Parse(Tbx_Number.Text) + " where ID='" + Tbx_DID.Text + "' ";
                                s_Sql += " Insert into KNet_WareHouse_DirectOutList_Details_Update(KDU_ID,KUD_WareHouseDID,KUD_OldNumber,KUD_Number) Values('" + base.GetNewID("KNet_WareHouse_DirectOutList_Details_Update", 1) + "','" + Tbx_DID.Text + "','" + s_OldNumber + "','" + Tbx_Number.Text + "') ";
                            }
                        }
                        DbHelperSQL.ExecuteSql(s_Sql);
                        s_Return = "，出库数量更新成功！";
                    }
                    catch
                    { }

                    BLL.Add(model);
                    AdminloginMess LogAM = new AdminloginMess();
                    LogAM.Add_Logs("销售管理--->发货跟踪添加--->发货跟踪添加 操作成功！发货单号：" + OutWareNo);

                    Response.Write("<script>alert('发货跟踪添加 成功" + s_Return + "！');location.href='Knet_Sales_Ship_Manage_Talks_List.aspx?OutWareNo=" + OutWareNo + "';</script>");
                    Response.End();
                    if (FollowText == "" || FollowText == null)
                    {
                        Response.Write("<script>alert('发货跟踪情况内容不能为空！');history.back(-1);</script>");
                        Response.End();
                    }
                    else
                    {
                    }

            }
            catch
            {
                Response.Write("<script>alert('发货跟踪添加 失败2！');history.back(-1);</script>");
                Response.End();
            }
        }
    }
}
