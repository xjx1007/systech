using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Web_Upload_State_ProductFile : BasePage
{
    public string s_ProductsTable_BomDetail = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string s_ID = Request.QueryString["UpdateID"] == null ? "" : Request.QueryString["UpdateID"].ToString();

            KNet.BLL.PB_Basic_Attachment BLL = new KNet.BLL.PB_Basic_Attachment();
            KNet.Model.PB_Basic_Attachment model = BLL.GetModel(s_ID);
            if (model != null)
            {
                if (base_GetProductsFileUpdateType(model.PBA_ProductsType) == false)
                {
                    AlertAndClose("没有 更新" + base.Base_GetBasicCodeName("780", model.PBA_ProductsType) + " 权限!");
                }
                else
                {
                    string sql = "select PBA_URL from PB_Basic_Attachment where PBA_ID='" + s_ID + "'";
                    DataTable dataTable = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql).Tables[0];
                    URL.Text = dataTable.Rows[0][0].ToString();
                    string type = Request.QueryString["Type"].ToString();
                    string productcode = Request.QueryString["PBC_FID"].ToString();
                    Type.Text = type;
                    ID.Text = s_ID;
                     SyProduct(s_ID, Type.Text,productcode);
                }
            }


        }
    }
    public void SyProduct(string id, string type,string productcode)
    {
        string s_ProductsRC = "";
        string sql = "select(case when PBA_FID = '"+ productcode + "' then 0 else 1 end) as productcode, a.* from PB_Basic_Attachment a where PBA_URL in(select PBA_URL from PB_Basic_Attachment where PBA_ID = '"+ id + "') order by productcode asc";
        DataTable Dtb_RCProducts = DbHelperSQL.ExecuteDataSet(CommandType.Text, sql).Tables[0];
        if (Dtb_RCProducts.Rows.Count > 0)
        {

            for (int i = 0; i < Dtb_RCProducts.Rows.Count; i++)
            {
                int a = i + 1;
                s_ProductsRC += "<tr>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">" +a+ "</td>";


                if (type == "State")
                {
                    if (Dtb_RCProducts.Rows[i]["PBA_Del"].ToString()=="0")
                    {
                        s_ProductsRC += "<td class=\"ListHeadDetails\">";
                        s_ProductsRC += "<input type=\"hidden\"  Name=\"ProductBarCode_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_FID"].ToString() + "'><input type=\"radio\" ID=\"Chk_IsReplace_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=0  checked>启用<br/>";
                        s_ProductsRC += "<input type=\"radio\" ID=\"Chk_IsDelete_" + i.ToString() + "\"  name=\"groupname_" + i.ToString() + "\" value=1>停用<br/>";
                        s_ProductsRC += "</td>";
                    }
                    else
                    {
                        s_ProductsRC += "<td class=\"ListHeadDetails\">";
                        s_ProductsRC += "<input type=\"hidden\"  Name=\"ProductBarCode_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_FID"].ToString() + "'><input type=\"radio\" ID=\"Chk_IsReplace_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=0 >启用<br/>";
                        s_ProductsRC += "<input type=\"radio\" ID=\"Chk_IsDelete_" + i.ToString() + "\"  name=\"groupname_" + i.ToString() + "\" value=1 checked>停用<br/>";
                        s_ProductsRC += "</td>";
                    }
                    
                }
                else
                {
                    if (Dtb_RCProducts.Rows[i]["PBA_State"].ToString() == "1")
                    {
                        s_ProductsRC += "<td class=\"ListHeadDetails\">";
                        s_ProductsRC += "<input type=\"hidden\"  Name=\"ProductBarCode_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_FID"].ToString() + "'><input type=\"radio\" ID=\"Chk_IsReplace_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=1  checked>审批<br/>";
                        s_ProductsRC += "<input type=\"radio\" ID=\"Chk_IsDelete_" + i.ToString() + "\"  name=\"groupname_" + i.ToString() + "\" value=0>反审批<br/>";
                        s_ProductsRC += "</td>";
                    }
                    else
                    {
                        s_ProductsRC += "<td class=\"ListHeadDetails\">";
                        s_ProductsRC += "<input type=\"hidden\"  Name=\"ProductBarCode_" + i.ToString() + "\" value='" + Dtb_RCProducts.Rows[i]["PBA_FID"].ToString() + "'><input type=\"radio\" ID=\"Chk_IsReplace_" + i.ToString() + "\" name=\"groupname_" + i.ToString() + "\" value=1>审批<br/>";
                        s_ProductsRC += "<input type=\"radio\" ID=\"Chk_IsDelete_" + i.ToString() + "\"  name=\"groupname_" + i.ToString() + "\" value=0 checked>反审批<br/>";
                        s_ProductsRC += "</td>";
                    }
                }
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsCode(Dtb_RCProducts.Rows[i]["PBA_FID"].ToString()) + "</td>";

                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProdutsName_Link(Dtb_RCProducts.Rows[i]["PBA_FID"].ToString()) + "</td>";
                s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetProductsEdition(Dtb_RCProducts.Rows[i]["PBA_FID"].ToString()) + "</td>";
                if (type == "State")
                {
                    s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("204", Dtb_RCProducts.Rows[i]["PBA_Del"].ToString()) + "</td>";
                }
                else
                {
                    s_ProductsRC += "<td class=\"ListHeadDetails\">" + base.Base_GetBasicCodeName("1133", Dtb_RCProducts.Rows[i]["PBA_State"].ToString()) + "</td>";
                }

                s_ProductsRC += "</tr>";
            }
            this.Products_BomNum.Text = Dtb_RCProducts.Rows.Count.ToString();
        }
        s_ProductsTable_BomDetail = s_ProductsRC;
    }
    protected void save_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < int.Parse(this.Products_BomNum.Text); i++)
        {
            if (Type.Text== "State")
            {
                string s_ProdoctsBarCode = Request.Form["ProductBarCode_" + i.ToString() + ""] == null
                               ? ""
                               : Request.Form["ProductBarCode_" + i.ToString() + ""].ToString();
                string s_IsModiy = Request.Form["groupname_" + i.ToString() + ""] == null ? "0" : Request.Form["groupname_" + i.ToString() + ""].ToString();
                UpdateAttachment(s_ProdoctsBarCode, "PBA_Del", int.Parse(s_IsModiy));
            }
            else
            {
                string s_ProdoctsBarCode = Request.Form["ProductBarCode_" + i.ToString() + ""] == null
                               ? ""
                               : Request.Form["ProductBarCode_" + i.ToString() + ""].ToString();
                string s_IsModiy = Request.Form["groupname_" + i.ToString() + ""] == null ? "0" : Request.Form["groupname_" + i.ToString() + ""].ToString();
                UpdateAttachment(s_ProdoctsBarCode, "PBA_State", int.Parse(s_IsModiy));
            }
        }
        AdminloginMess AM = new AdminloginMess();

        AM.Add_Logs("附件上传成功：编号：");
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
    /// <summary>
    /// 操作附件
    /// </summary>
    /// <param name="productcode">附件对应产品的编号</param>
    /// <param name="delorstate">要更改哪个字段</param>
    /// <param name="value">字段的值</param>
    public void UpdateAttachment(string productcode,string delorstate,int value)
    {
        string updatesql = "update PB_Basic_Attachment set "+ delorstate + "="+value+" where PBA_FID='"+ productcode + "' and PBA_URL='" + URL.Text + "'";
        DbHelperSQL.ExecuteSql(updatesql);
    }
}

