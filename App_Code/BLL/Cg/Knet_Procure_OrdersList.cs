using System;
using System.Data;
using System.Collections.Generic;
using KNet.Model;
using System.Net.Mail;

namespace KNet.BLL
{
    /// <summary>
    /// 业务逻辑类Knet_Procure_OrdersList
    /// </summary>
    public class Knet_Procure_OrdersList
    {
        private readonly KNet.DAL.Knet_Procure_OrdersList dal = new KNet.DAL.Knet_Procure_OrdersList();
        //private readonly KNet.DAL.KNet_Product_Burn dal1 = new KNet.DAL.KNet_Product_Burn();
        public Knet_Procure_OrdersList()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string OrderNo)
        {
            return dal.Exists(OrderNo);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(KNet.Model.Knet_Procure_OrdersList model)
        {
            string productlist = "";
            if (model.ContractNos.ToString() != "")
            {
                string s_ContractNo = model.ContractNos.ToString();
                //更新采购单为 “已完成”
                string DoSqlOrder = " update KNet_Sales_ContractList set  isOrder='1' where ContractNo in ('" + s_ContractNo.Replace(",", "','") + "')";
                DbHelperSQL.ExecuteSql(DoSqlOrder);
            }
           
            dal.Add(model);
            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            if (model.Arr_ProductsList != null)
            {
                for (int i = 0; i < model.Arr_ProductsList.Count; i++)
                {
                    KNet.Model.Knet_Procure_OrdersList_Details Model_Details = (KNet.Model.Knet_Procure_OrdersList_Details)model.Arr_ProductsList[i];
                  
                    Model_Details.OrderNo = model.OrderNo;
                    productlist += "'" + Model_Details + "'"+",";
                    BLL_Details.Add(Model_Details);
                }
            }
            //if (model.ContractNos!="")//判断如果是生产订单，就生成烧录程序审核
            //{
            //    KNet.DAL.KNet_Product_Burn dal_Burn = new DAL.KNet_Product_Burn();
            //    KNet.Model.KNet_Product_Burn Model_Burn = new Model.KNet_Product_Burn();
            //    Model_Burn.KSB_OrderNo = model.OrderNo;
            //    Model_Burn.KSB_Sperson = model.OrderStaffNo;
            //    Model_Burn.KSB_Time=DateTime.Now;
            //    dal_Burn.Add(Model_Burn);
            //    productlist = productlist.Substring(0, productlist.Length - 1);
            //    KNet.DAL.PB_Basic_Attachment pba_dal=new DAL.PB_Basic_Attachment();
              
            //    DataSet Dtb_Mail =pba_dal.GetEmialList(productlist);
            //    if (Dtb_Mail.Tables[0].Rows.Count > 0)
            //    {
            //        string s_SendEmail = "";
            //        for (int i = 0; i < Dtb_Mail.Tables[0].Rows.Count; i++)
            //        {
            //            s_SendEmail += Dtb_Mail.Tables[0].Rows[0][0].ToString() + "|";
            //        }

            //        string subject = "烧录文件审核确认通知";
            //        string body = "生产单号为" + model.OrderNo + "已经创建成功，请您及时去确认烧录程序是否正确，确认无误后请及时审核！以免耽误生产进程";
            //        //string email_list = "hyy@systech.com.cn" + "|" + "lzh@systech.com.cn" + "|";
            //        string File_Path = "";
            //        //"zb@systech.com.cn" + "|" + "xb@systech.com.cn" + "|" + "lwl@systech.com.cn" + "|" + "hyy@systech.com.cn" + "|";
            //        Send(subject, body, s_SendEmail, File_Path);
            //    }
            //}
           
        }
        #region 订单生成后，以邮件的形式发给研发负责人，确认烧录文件
        public static void Send(string subject, string body, string email_list, string File_Path)
        {
            string MailUser = "xjx@systech.com.cn";//我测试的是qq邮箱，其他邮箱一样的道理
            string MailPwd = "systech#88888888";//邮箱密码
            string MailName = "ERP系统";
            string MailHost = "smtp.mxhichina.com";//根据自己选择的邮箱来查询smtp的地址

            MailAddress from = new MailAddress(MailUser, MailName); //邮件的发件人  
            MailMessage mail = new MailMessage();

            //设置邮件的标题  
            mail.Subject = subject;

            //设置邮件的发件人  
            //Pass:如果不想显示自己的邮箱地址，这里可以填符合mail格式的任意名称，真正发mail的用户不在这里设定，这个仅仅只做显示用  
            mail.From = from;

            //设置邮件的收件人  
            string address = "";

            //传入多个邮箱，用“|”分割开，可以自己自定义，再通过mail.To.Add（）添加到列表
            string[] email = email_list.Split('|');
            foreach (string name in email)
            {
                if (name != string.Empty)
                {
                    address = name;
                    mail.To.Add(new MailAddress(address));
                }
            }

            //设置邮件的抄送收件人  
            //这个就简单多了，如果不想快点下岗重要文件还是CC一份给领导比较好  
            //mail.CC.Add(new MailAddress("Manage@hotmail.com", "尊敬的领导");  

            //设置邮件的内容  
            mail.Body = body;
            //设置邮件的格式  
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            //设置邮件的发送级别  
            mail.Priority = MailPriority.Normal;

            //设置邮件的附件，将在客户端选择的附件先上传到服务器保存一个，然后加入到mail中  
            if (File_Path != "")
            {
                mail.Attachments.Add(new Attachment(File_Path));
                mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            }
            SmtpClient client = new SmtpClient();
            //设置用于 SMTP 事务的主机的名称，填IP地址也可以了  
            client.Host = MailHost;
            //设置用于 SMTP 事务的端口，默认的是 25  
            client.Port = 587;
            client.UseDefaultCredentials = false;
            //这里才是真正的邮箱登陆名和密码， 我的用户名为 MailUser ，我的密码是 MailPwd  
            client.Credentials = new System.Net.NetworkCredential(MailUser, MailPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            ////如果发送失败，SMTP 服务器将发送 失败邮件告诉我  
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            //都定义完了，正式发送了，很是简单吧！  
            client.Send(mail);

        }
        #endregion
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(KNet.Model.Knet_Procure_OrdersList model)
        {
            KNet.BLL.Knet_Procure_OrdersList BLL_Procure_OrdersList = new Knet_Procure_OrdersList();
            KNet.Model.Knet_Procure_OrdersList Model_Procure_OrdersList = BLL_Procure_OrdersList.GetModelB(model.OrderNo);
            if (Model_Procure_OrdersList != null)
            {
                if (Model_Procure_OrdersList.ContractNo.ToString() != "")
                {
                    //更新采购单为 “已完成”
                    string DoSqlOrder = " update KNet_Sales_ContractList set isOrder='0' where ContractNo='" + Model_Procure_OrdersList.ContractNo.ToString() + "'";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                }
                if (model.ContractNo.ToString() != "")
                {
                    //更新采购单为 “已完成”
                    string DoSqlOrder = " update KNet_Sales_ContractList set isOrder='1' where ContractNo='" + model.ContractNo.ToString() + "'";
                    DbHelperSQL.ExecuteSql(DoSqlOrder);
                }
            }

            dal.Update(model);

            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new KNet.BLL.Knet_Procure_OrdersList_Details();
            BLL_Details.Delete(model.OrderNo);
            if (model.Arr_ProductsList != null)
            {
                for (int i = 0; i < model.Arr_ProductsList.Count; i++)
                {
                    KNet.Model.Knet_Procure_OrdersList_Details Model_Details = (KNet.Model.Knet_Procure_OrdersList_Details)model.Arr_ProductsList[i];
                    Model_Details.OrderNo = model.OrderNo;
                    BLL_Details.Add(Model_Details);
                }
            }
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateIsSend(KNet.Model.Knet_Procure_OrdersList model)
        {
            dal.UpdateIsSend(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateRKState(KNet.Model.Knet_Procure_OrdersList model)
        {
            dal.UpdateRKState(model);

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void UpdateRkState(KNet.Model.Knet_Procure_OrdersList model)
        {
            dal.UpdateRkState(model);
        }

        public bool IsDetails(string s_OrderNo)
        {
            return dal.IsDetails(s_OrderNo);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string OrderNo)
        {
            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new Knet_Procure_OrdersList_Details();
            BLL_Details.Delete(OrderNo);
            dal.Delete(OrderNo);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void DeleteByOrderNo(string OrderNo)
        {
            KNet.BLL.Knet_Procure_OrdersList_Details BLL_Details = new Knet_Procure_OrdersList_Details();
            dal.Delete(OrderNo);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_OrdersList GetModel(string ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public KNet.Model.Knet_Procure_OrdersList GetModelB(string OrderNo)
        {
            return dal.GetModelB(OrderNo);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        public DataSet GetList1(string strWhere)
        {
            return dal.GetList1(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }


        #endregion  成员方法
    }
}

