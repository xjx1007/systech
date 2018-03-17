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

public partial class Web_Sales_Xs_Transfer_Cheque_Print : BasePage
{
    public string s_Remarks = "", s_Year = "", s_Month = "", s_Day = "", s_PayeeName = "";
    public string s_ChineseMoney = "", s_Money = "", s_UseName = "", s_Account = "", s_Type = "", s_BankName = "", s_BankNo = "";
    public string s_SendProvice = "", s_SendPlace = "", s_ReceProvice = "", s_RecePlace = "";
    public string s_BillType = "", s_BillNumber = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            AdminloginMess AM=new AdminloginMess();
            if (AM.CheckLogin()==false)
            {
                
            }
            string s_ID = Request.QueryString["ID"] == null ? "" : Request.QueryString["ID"].ToString();
            KNet.BLL.Xs_Transfer_Cheque Bll = new KNet.BLL.Xs_Transfer_Cheque();
            KNet.Model.Xs_Transfer_Cheque Model = Bll.GetModel(s_ID);
            s_Remarks = Model.XTC_Remarks;
            s_Year = DateTime.Parse(Model.XTC_Stime.ToString()).Year.ToString();
            s_Month = DateTime.Parse(Model.XTC_Stime.ToString()).Month.ToString();
            s_Day = DateTime.Parse(Model.XTC_Stime.ToString()).Day.ToString();
            s_Type = base.Base_GetBasicCodeName("123", Model.XTC_Type);

            s_BillType = base.Base_GetBasicCodeName("754", Model.XTC_BillType);
            s_BillNumber =Model.XTC_BillNumber;

            s_ChineseMoney = Model.XTC_ChineseMoney;
            s_Money = base.FormatNumber1(Model.XTC_Money.ToString(), 2);
            s_UseName = Model.XTC_UseName;
            s_BankName = Model.XTC_BankName;
            s_BankNo = Model.XTC_BankAccount;
            s_ReceProvice = Model.XTC_Shen == null ? "" : Model.XTC_Shen.ToString();
            s_RecePlace = Model.XTC_Shi == null ? "" : Model.XTC_Shi.ToString();
            s_PayeeName = Model.XTC_PayeeName;
            if (s_PayeeName == "")
            {
                // s_SendProvice=
                //s_SendPlace=
                if (base.Base_GetCustomerName(Model.XTC_PayeeValue) == "--")
                {
                    KNet.BLL.Knet_Procure_Suppliers BLL_Suppliers = new KNet.BLL.Knet_Procure_Suppliers();
                    KNet.Model.Knet_Procure_Suppliers Model_Suppliers = BLL_Suppliers.GetModelB(Model.XTC_PayeeValue);

                    s_PayeeName = base.Base_GetSupplierName(Model.XTC_PayeeValue);
                    s_ReceProvice = base.Base_GetCityName(Model_Suppliers.SuppProvince);
                    s_RecePlace = base.Base_GetShiName(Model_Suppliers.SuppCity);
                }
                else
                {
                    KNet.BLL.KNet_Sales_ClientList BLL_ClientList = new KNet.BLL.KNet_Sales_ClientList();
                    KNet.Model.KNet_Sales_ClientList Model_ClientList = BLL_ClientList.GetModelB(Model.XTC_PayeeValue);

                    s_PayeeName = base.Base_GetCustomerName(Model.XTC_PayeeValue);
                    s_ReceProvice = base.Base_GetCityName(Model_ClientList.CustomerProvinces);
                    s_RecePlace = base.Base_GetShiName(Model_ClientList.CustomerCity);

                }
            }
         
            if (s_PayeeName != "")
            {
                s_ReceProvice = s_ReceProvice.Replace("省","");
                s_ReceProvice = s_ReceProvice.Replace("北京市", "");
                s_ReceProvice = s_ReceProvice.Replace("上海市", "");
                s_ReceProvice = s_ReceProvice.Replace("重庆市", "");
            }
            if (s_RecePlace != "")
            {
                s_RecePlace = s_RecePlace.Replace("市", "");
            }

           // s_Account = base.Base_GetBankName(Model.XTC_Account.ToString());
        }
    }
}
