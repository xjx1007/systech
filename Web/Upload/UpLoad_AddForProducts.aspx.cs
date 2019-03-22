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
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using KNet.DBUtility;
using KNet.Common;


public partial class UpLoad_AddForProducts : BasePage
{
    public string s_ProductsTable_BomDetail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_DoSql = base_GetProductsFileUpdateType();
            
            base.Base_DropBasicCodeBindByWhere(this.Ddl_Type, "780", " and PBC_Code in('"+s_DoSql+"')");
            string s_ID = Request.QueryString["UpdateID"] == null ? "" : Request.QueryString["UpdateID"].ToString();
            this.Tbx_UpdateID.Text = s_ID;
           
            KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
            KNet.Model.PB_Basic_Attachment model = BLL.GetModel(s_ID);
            if (model != null)
            {
                this.Tbx_UpdateName.Text = model.PBA_Name;
                this.Ddl_Type.SelectedValue = model.PBA_ProductsType;              
                if (base_GetProductsFileUpdateType(model.PBA_ProductsType)==false)
                {
                    AlertAndClose("没有 更新" + base.Base_GetBasicCodeName("780", model.PBA_ProductsType) + " 权限!");
                }
                else
                {
                    string type = Request.QueryString["Type"].ToString();
                    string productcode = Request.QueryString["PBC_FID"].ToString();
                    SyProduct(s_ID,type, productcode);
                }
            }

            
        }

    }

    public void SyProduct(string id,string type,string productcode)
    {
        
        tr9.Visible = false;
        string s_ProductsRC = "";
        string sql = "select(case when PBA_FID = '" + productcode + "' then 0 else 1 end) as productcode, a.* from PB_Basic_Attachment a where PBA_URL in(select PBA_URL from PB_Basic_Attachment where PBA_ID = '" + id + "') order by productcode asc";
        DataTable Dtb_RCProducts = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        if (Dtb_RCProducts.Rows.Count > 0)
        {

            for (int i = 0; i < Dtb_RCProducts.Rows.Count; i++)
            {
                int a = i + 1;
                s_ProductsRC += "<tr>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + a + "</td>";                
                if (type=="Update")
                {
                    s_ProductsRC += "<td class=\"ListHeadDetails\">";
                    s_ProductsRC += "<input type=\"hidden\"  Name=\"ProductBarCode_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_FID"].ToString() + "'><input type=\"hidden\"  Name=\"PBA_ID_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_ID"].ToString() + "'><input type=\"radio\" ID=\"Chk_IsReplace_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=1>更新<br/>";
                    s_ProductsRC += "<input type=\"radio\" ID=\"Chk_IsDelete_" + i.ToString() + "\"  name=\"groupname_" + i.ToString() + "\" value=2 checked>不更新<br/>";
                    s_ProductsRC += "</td>";
                }
                else
                {
                    s_ProductsRC += "<td class=\"ListHeadDetails\">";
                    s_ProductsRC += "<input type=\"hidden\"  Name=\"ProductBarCode_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_FID"].ToString() + "'><input type=\"hidden\"  Name=\"PBA_ID_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_ID"].ToString() + "'><input type=\"radio\" ID=\"Chk_IsReplace_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=1>停用<br/>";
                    s_ProductsRC += "<input type=\"radio\" ID=\"Chk_IsDelete_" + i.ToString() + "\"  name=\"groupname_" + i.ToString() + "\" value=2 checked>启用<br/>";
                    s_ProductsRC += "</td>";
                }
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dtb_RCProducts.Rows[i]["PBA_FID"].ToString()) + "</td>";

                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dtb_RCProducts.Rows[i]["PBA_FID"].ToString()) + "</td>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_RCProducts.Rows[i]["PBA_FID"].ToString()) + "</td>";

                s_ProductsRC += "</tr>";
            }
            this.Products_BomNum.Text = Dtb_RCProducts.Rows.Count.ToString();
        }
        s_ProductsTable_BomDetail = s_ProductsRC;
    }
    protected void save_Click(object sender, EventArgs e)
    {
        //Alert(Request.Form["DemoProdoctsBarCode_1"]);

        if (!(uploadFile.PostedFile.ContentLength > 0))
        {
            Alert("您没有选择文件!");
        }
        else
        {
            AdminloginMess AM = new AdminloginMess();
            KNet.Model.PB_Basic_Attachment model = new KNet.Model.PB_Basic_Attachment();
            string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
            GetThumbnailImage1(model);
            try
            {
                //停用老附近

                KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();

                if (model.PBA_UpdateFID != "")
                {
                    for (int i = 0; i < int.Parse(Products_BomNum.Text); i++)
                    {
                        string s_ProdoctsBarCode = Request.Form["ProductBarCode_" + i.ToString() + ""] == null
                               ? ""
                               : Request.Form["ProductBarCode_" + i.ToString() + ""].ToString();
                        string s_IsModiy = Request.Form["groupname_" + i.ToString() + ""] == null ? "0" : Request.Form["groupname_" + i.ToString() + ""].ToString();
                        string s_PBAID = Request.Form["PBA_ID_" + i.ToString() + ""] == null ? "0" : Request.Form["PBA_ID_" + i.ToString() + ""].ToString();

                        if (s_ProdoctsBarCode!=""&& s_PBAID!="")
                        {
                            //Alert(s_ProdoctsBarCode+"状态："+ s_IsModiy);
                            KNet.Model.PB_Basic_Attachment Mode_att = BLL.GetModel(s_PBAID);
                            if (Mode_att != null && s_IsModiy == "1")
                            {
                                Mode_att.PBA_Del = 1;
                                BLL.UpdateByDel(Mode_att);
                                AM.Add_Logs("停用附件：" + Mode_att.PBA_ID);
                                if (AM.KNet_StaffName == "李文立")
                                {
                                    model.PBA_State = 1;
                                }
                                model.PBA_ID=GetMainIDFile(s_ProdoctsBarCode);
                                model.PBA_FID = s_ProdoctsBarCode;
                                BLL.Add(model);
                            }
                        }
                       
                    }
                    
                }
                else
                {

                    if (Tbx_ProductsTypeNo.Text != "")
                    {
                        //BLL.Add(model);
                        string sql = "select * from KNet_Sys_Products  where ProductsType='" + Tbx_ProductsTypeNo.Text + "' and ProductsBarCode  not in(select PBA_FID from PB_Basic_Attachment where PBA_ProductsType='"+ Ddl_Type.SelectedValue+ "')";
                        DataTable dataTable = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql).Tables[0];
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            model.PBA_FID = dataTable.Rows[i]["ProductsBarCode"].ToString();
                            model.PBA_ID = GetMainIDFile(model.PBA_FID);
                            if (AM.KNet_StaffName == "李文立")
                            {
                                model.PBA_State = 1;
                            }
                            BLL.Add(model);
                        }
                    }
                    else
                    {
                        BLL.Add(model);
                        for (int i = 1; i <= int.Parse(Products_BomNum.Text); i++)
                        {
                            string s_ProdoctsBarCode = Request.Form["DemoProdoctsBarCode_" + i.ToString() + ""] == null
                                ? ""
                                : Request.Form["DemoProdoctsBarCode_" + i.ToString() + ""].ToString();
                            model.PBA_FID = s_ProdoctsBarCode;
                            model.PBA_ID = GetMainIDFile(s_ProdoctsBarCode);
                            if (AM.KNet_StaffName == "李文立")
                            {
                                model.PBA_State = 1;
                            }
                            BLL.Add(model);
                        }
                    }
                }

                AM.Add_Logs("附件上传成功：编号：" + model.PBA_ID);
                string s_Return = "1";
                StringBuilder s = new StringBuilder();
                s.Append("<script language=javascript>" + "\n");
                s.Append("alert('操作成功！');" + "\n");
                s.Append("if(window.opener != undefined)");
                s.Append("{\n");
                s.Append("    window.opener.returnValue = '" + s_Return + "';\n");
                s.Append("    window.opener.SetReturnValueInOpenner_UploadForProducts('" + s_Return + "');\n");
                s.Append("}\n");
                s.Append("else\n");
                s.Append("{\n");
                s.Append("    window.returnValue = '" + s_Return + "';\n");
                s.Append("}\n");
                //s.Append("if(window.opener != undefined) {window.opener.returnValue='1';} else{window.returnValue='1';}" + "\n");
                s.Append("window.close();" + "\n");
                s.Append("</script>");
                Type cstype = this.GetType();
                ClientScriptManager cs = Page.ClientScript;
                string csname = "ltype";
                if (!cs.IsStartupScriptRegistered(cstype, csname))
                    cs.RegisterStartupScript(cstype, csname, s.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public string GetMainIDFile(string str)
    {
        string s_ID = "M";
        try
        {
            string s_Date = DateTime.Now.ToString("yyMMddhhmmss");
            s_ID += s_Date + str.Substring(1,str.Length-1);
        }
        catch
        { }
        return s_ID;
    }

    #region 资料上传操作
    /// <summary>
    /// 图片上传
    /// </summary>
    protected void GetThumbnailImage1(KNet.Model.PB_Basic_Attachment model)
    {
        AdminloginMess AM = new AdminloginMess();
        //类别下面的
        //历史的
        string UploadPath = "/UpFile/" + Request.QueryString["PBC_Type"] + "/" + Request.QueryString["PBC_FID"].ToString() + "/";  //上传路径
        string AutoPath = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "").Replace("/", "");
        string fileExt = Path.GetExtension(uploadFile.PostedFile.FileName).Replace(".",""); //获扩展名
        string FileType = uploadFile.PostedFile.ContentType.ToString(); //文件类型
        string FileName = Path.GetFileName(uploadFile.PostedFile.FileName);
        string filePath = UploadPath + AutoPath + "_" + FileName; //大文件名
        if (!Directory.Exists(Server.MapPath(UploadPath)))
        {
            Directory.CreateDirectory(Server.MapPath(UploadPath));
        }
        uploadFile.PostedFile.SaveAs(Server.MapPath(filePath)); //上传


        model.PBA_FID = Request.QueryString["PBC_FID"];
        model.PBA_Type = Request.QueryString["PBC_Type"];
        model.PBA_ID = GetMainIDFile(Request.QueryString["PBC_FID"]);
        model.PBA_Name = this.Tbx_Name.Text;
        model.PBA_URL = filePath;
        model.PBA_CTime = DateTime.Now;
        model.PBA_Creator = AM.KNet_StaffNo;
        model.PBA_Remarks = this.Tbx_Remarks.Text;
        model.PBA_ProductsType=this.Ddl_Type.SelectedValue;
        model.PBA_FileType = fileExt;
        model.PBA_Edition = this.Tbx_Version.Text;
        model.PBA_UpdateFID = this.Tbx_UpdateID.Text;
        if (PBA_EndTime.Text=="")
        {
            model.PBA_EndTime=DateTime.Now;
        }
        else
        {
            model.PBA_EndTime = DateTime.Parse(this.PBA_EndTime.Text);
        }
       
    }
    #endregion

}