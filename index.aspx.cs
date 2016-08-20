using KNet.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class index : BasePage
{
        public string s_FirstMenu = "";
        public string s_SenMenu = "";
        public string s_DropMenu = "";
        public string s_Person = "", loginUser = "";

        public string s_LeftMenu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    AdminloginMess AM = new AdminloginMess();
                    loginUser = "{uid:\"" + AM.KNet_StaffNo + "\", user_id:\"" + AM.KNet_StaffNo + "\", user_name:\"" + AM.KNet_StaffName + "\"}";
                    LoadLeftMenu();
                    this.Lbl_UserCount.Text = AM.GetOnlineCount();

                    s_Person = AM.KNet_StaffName;
                    this.Tbx_UserID.Text = AM.KNet_StaffNo;
                    this.Tbx_CompanyName.Text = AM.KNet_Sys_CompanyName;
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            AdminloginMess AM = new AdminloginMess();
            AM.Logout();
            AlertAndRedirect("退出成功！", "signin.aspx");
        }
        private void LoadLeftMenu()
        {
            #region 三级菜单
            /*
            <li>
             * <a href="javascript:void(0);"><i class="icon-list-ol"></i>行政人事中心 </a>
                <ul class="sub-menu">
                    <li class="open-default"><a href="javascript:void(0);"><i class="icon-cogs"></i>Item 1 <span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li class="open-default"><a href="javascript:void(0);"><i class="icon-user"></i>Sample Link 1 <span class="arrow"></span></a></li>
                            <li><a href="javascript:void(0);"><i class="icon-user"></i>Sample Link 1</a></li>
                            <li><a href="javascript:void(0);"><i class="icon-external-link"></i>Sample Link 2</a></li>
                            <li><a href="javascript:void(0);"><i class="icon-bell"></i>Sample Link 3</a></li>
                        </ul>
                    </li>
                    <li><a href="javascript:void(0);"><i class="icon-globe"></i>Item 2 <span class="arrow"></span></a>
                        <ul class="sub-menu">
                            <li><a href="javascript:void(0);"><i class="icon-user"></i>Sample Link 1</a></li>
                            <li><a href="javascript:void(0);"><i class="icon-external-link"></i>Sample Link 1</a></li>
                            <li><a href="javascript:void(0);"><i class="icon-bell"></i>Sample Link 1</a></li>
                        </ul>
                    </li>
                    <li><a href="javascript:void(0);"><i class="icon-folder-open"></i>Item 3 </a></li>
                </ul>
            </li>
            */
            #endregion

            //Ajax.Utility.RegisterTypeForAjax(typeof(Knetwork_Admin_NewMain));
            try
            {
                s_LeftMenu = "";          
                KNet.Model.PB_Basic_Menu Model_Menu = new KNet.Model.PB_Basic_Menu();
                KNet.BLL.PB_Basic_Menu BLL_Menu = new KNet.BLL.PB_Basic_Menu();
                string s_SqlWhere = "";
                s_SqlWhere = " PBM_Level in ('0')  order by PBM_Level,isnull(PBM_Order,6),PBM_ID";
                List<KNet.Model.PB_Basic_Menu> aryTopMenus = BLL_Menu.GetModelList(s_SqlWhere);

                if (aryTopMenus.Count > 0)
                {
                    foreach (KNet.Model.PB_Basic_Menu topMenu in aryTopMenus)
                    {
                        s_LeftMenu += "<li>";
                        if (topMenu.PBM_FatherID == "" || topMenu.PBM_FatherID == null)
                        {
                            string strIcon = "icon-list-ol";
                            if (topMenu.PBM_Icon != "" && topMenu.PBM_Icon != null)
                            {
                                strIcon = topMenu.PBM_Icon;
                            }
                            s_LeftMenu += "<a href=\"javascript:void(0);\"><i class=\"" + strIcon + "\"></i>" + topMenu.PBM_Name + " </a>";
                            s_LeftMenu += LoadSubMenu(topMenu.PBM_ID);
                        }
                        s_LeftMenu += "</li>";
                    }
                }
            }
            catch (Exception ex)
            {
                Alert(ex.Message);
            }
        }

        private string LoadSubMenu(string strParentID)
        {
            string strMenu = "";
            KNet.BLL.PB_Basic_Menu BLL_Menu = new KNet.BLL.PB_Basic_Menu();
            string s_SqlWhere = "";
            s_SqlWhere = " PBM_FatherID = '" + strParentID + "'  order by PBM_Level,isnull(PBM_Order,6),PBM_ID";
            List<KNet.Model.PB_Basic_Menu> arySubMenus = BLL_Menu.GetModelList(s_SqlWhere);

            if (arySubMenus.Count > 0)
            {
                strMenu += "<ul class=\"sub-menu\">";

                foreach (KNet.Model.PB_Basic_Menu menu in arySubMenus)
                {
                    strMenu += "<li>";
                    string strIcon = "icon-list-ol";
                    if (menu.PBM_Icon != "" && menu.PBM_Icon != null)
                    {
                        strIcon = menu.PBM_Icon;
                    }
                    strMenu += "<a href=\"" + menu.PBM_URL + "\" target=\"main\"><i class=\"" + strIcon + "\"></i>" + menu.PBM_Name + " </a>";
                    strMenu += LoadSubMenu(menu.PBM_ID);
                    strMenu += "</li>";
                }
                strMenu += "</ul>";
            }
            return strMenu;
        }
}
