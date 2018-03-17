using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using KNet.DBUtility;


namespace KNet.Common
{
    /// <summary>
    /// KNetPage 的摘要说明
    /// </summary>
    public class KNetPage
    {


        /// <summary>
        /// 防SQL网页式注入
        /// </summary>
        public static void StartProcessRequest()
        {
            //System.Web.HttpContext.Current.Response.Write("<script>alert('dddd');</script>");
            try
            {
                string getkeys = "";
                //string sqlErrorPage = System.Configuration.ConfigurationSettings.AppSettings["CustomErrorPage"].ToString();
                if (System.Web.HttpContext.Current.Request.QueryString != null)
                {

                    for (int i = 0; i < System.Web.HttpContext.Current.Request.QueryString.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.QueryString.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.QueryString[getkeys], 0))
                        {
                            //System.Web.HttpContext.Current.Response.Redirect (sqlErrorPage+"?errmsg=sqlserver&sqlprocess=true");
                            System.Web.HttpContext.Current.Response.Write("<script>alert('请勿非法提交！');history.back();</script>");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
                if (System.Web.HttpContext.Current.Request.Form != null)
                {
                    for (int i = 0; i < System.Web.HttpContext.Current.Request.Form.Count; i++)
                    {
                        getkeys = System.Web.HttpContext.Current.Request.Form.Keys[i];
                        if (!ProcessSqlStr(System.Web.HttpContext.Current.Request.Form[getkeys], 1))
                        {
                            //System.Web.HttpContext.Current.Response.Redirect (sqlErrorPage+"?errmsg=sqlserver&sqlprocess=true");
                            System.Web.HttpContext.Current.Response.Write("<script>alert('请勿非法提交！');history.back();</script>");
                            System.Web.HttpContext.Current.Response.End();
                        }
                    }
                }
            }
            catch
            {
                // 错误处理: 处理用户提交信息!
            }
        }

        /// <summary>
        /// 防SQL注入
        /// </summary>
        /// <param name="Str"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static bool ProcessSqlStr(string Str, int type)
        {
            string SqlStr;

            if (type == 1)
                SqlStr = "exec |insert |select |delete |update |count |chr |mid |master |truncate |char |declare ";
            else
                SqlStr = "'|and|exec|insert|select|delete|update|count|chr|mid|master|truncate|char|declare|20%";

            bool ReturnValue = true;
            try
            {
                if (Str != "")
                {
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string ss in anySqlStr)
                    {
                        if (Str.IndexOf(ss) >= 0)
                        {
                            ReturnValue = false;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }



        /// <summary>
        /// 替换html中的特殊字符
        /// </summary>
        /// <param name="theString">需要进行替换的文本。</param>
        /// <returns>替换完的文本。</returns>
        public static string KHtmlEncode(string theString)
        {
            theString = theString.Replace(">", "&gt;");
            theString = theString.Replace("<", "&lt;");
            theString = theString.Replace("  ", " &nbsp;");
            theString = theString.Replace("  ", " &nbsp;");
            theString = theString.Replace("\"", "&quot;");
            theString = theString.Replace("\'", "&#39;");
            theString = theString.Replace("\n", "<br/> ");
            theString = theString.Replace("\r\n", "<br/>");
            return theString;
        }
        /// <summary>
        /// 恢复html中的特殊字符
        /// </summary>
        /// <param name="theString">需要恢复的文本。</param>
        /// <returns>恢复好的文本。</returns>
        public static string KHtmlDiscode(string theString)
        {
            if (theString != null)
            {
                theString = theString.Replace("&gt;", ">");
                theString = theString.Replace("&lt;", "<");
                theString = theString.Replace("&nbsp;", " ");
                theString = theString.Replace("&nbsp;", "  ");
                theString = theString.Replace("&quot;", "\"");
                theString = theString.Replace("&#39;", "\'");
                theString = theString.Replace("<br/> ", "\n");
 
            }
            return theString;
            
        }
        /// <summary>
        /// 获得双字节字符串的字节数
        /// </summary>
        /// <param name="str">要检测的字符串</param>
        /// <returns>返回字节数</returns>
        public static int GetStrLength(string str)
        {
            ASCIIEncoding n = new ASCIIEncoding();
            byte[] b = n.GetBytes(str);
            int l = 0;  // l 为字符串之实际长度
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == 63)  //判断是否为汉字或全脚符号
                {
                    l++;
                }
                l++;
            }
            return l;
        }

        /// <summary>
        /// 截取字符串
        /// </summary>
        /// <param name="strInput">输入字符串</param>
        /// <param name="intLen">字符串长度</param>
        /// <returns></returns>
        public static string CutString(string strInput, int intLen)
        {
            strInput = strInput.Trim();
            byte[] buffer1 = Encoding.Default.GetBytes(strInput);
            if (buffer1.Length > intLen)
            {
                string text1 = "";
                for (int num1 = 0; num1 < strInput.Length; num1++)
                {
                    byte[] buffer2 = Encoding.Default.GetBytes(text1);
                    if (buffer2.Length >= (intLen - 4))
                    {
                        break;
                    }
                    text1 = text1 + strInput.Substring(num1, 1);
                }
                return (text1 + "...");
            }
            return strInput;
        }
        /// <summary>
        /// 截取中英文混合字符串
        /// </summary>
        /// <param name="original">原始字符串</param>
        /// <param name="length">截取长度</param>
        /// <param name="fill">截取串小于原始串时,尾部附加字符串</param>
        /// <returns></returns>
        public static String CnCutString(String original, Int32 length, String fill)
        {
            Regex CnRegex = new Regex("[\u4e00-\u9fa5]+", RegexOptions.Compiled);
            Char[] CharArray = original.ToCharArray();
            Int32 tmplength = 0;
            for (Int32 i = 0; i < CharArray.Length; i++)
            {
                tmplength += CnRegex.IsMatch(CharArray[i].ToString()) ? 2 : 1;
                if (tmplength > length) return original.Substring(0, i - fill.Length) + fill;
            }

            return original;
        }

        /// <summary>
        /// 无法创建统计图表
        /// </summary>
        /// <param name="message"></param>
        static public void NoChart()
        {
            HttpContext.Current.Response.Write("<B>错误！</B><br>无法使用统计图表，请下载并安装 Microsoft Office Web Components 组件 ");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// xxx返回加密码后的字串
        /// </summary>
        /// <returns></returns>
        public static string KNetMD5(string CodeFormating)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(CodeFormating.ToUpper(), "MD5");
        }


        /// <summary>
        /// 返回表中的记录数
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static int GetDBTableNum(string TableName)
        {
            using (SqlConnection conn = DBClass.GetConnection("KNetJxcDB"))
            {
                conn.Open();
                string Dostr = "SELECT COUNT(*) as TBNum FROM " + TableName + "";
                SqlCommand cmd = new SqlCommand(Dostr, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        return int.Parse(dr["TBNum"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }








        #region 生成随机数（订单号） 
        
        
         /// <summary>
        /// 生成随机数（订单号）
         /// </summary>
         /// <param name="FrString">前缀</param>
         /// <returns></returns>
        public static string GetOrderId(string FrString)
        {
            string orderId = FrString;
            DateTime Date = DateTime.Now;
            string year = Date.Year.ToString();
            orderId += year.Substring(2, 2);
            int month = (int)Date.Month;
            int day = (int)Date.Day;
            int hour = (int)Date.Hour;
            int minute = (int)Date.Minute;
            int second = (int)Date.Second;

            Random rnd = new Random();
            int RndNumber = rnd.Next(1000, 9999);

            if (month < 10)
            {
                orderId += "0" + month.ToString();
            }
            else
            {
                orderId += month.ToString();
            }

            if (day < 10)
            {
                orderId += "0" + day.ToString();
            }
            else
            {
                orderId += day.ToString();
            }

            if (hour < 10)
            {
                orderId += "0" + hour.ToString();
            }
            else if (hour == 0)
            {
                orderId += "00";
            }
            else
            {
                orderId += hour.ToString();
            }

            if (minute < 10)
            {
                orderId += "0" + minute.ToString();
            }
            else if (minute == 0)
            {
                orderId += "00";
            }
            else
            {
                orderId += minute.ToString();
            }
            if (second < 10)
            {
                orderId += "0" + second.ToString();
            }
            else if (second == 0)
            {
                orderId += "00";
            }
            else
            {
                orderId += second.ToString();
            }
            orderId += RndNumber.ToString();
            return orderId;
        }
        #endregion

        #region 导出到Exel和word时模式化特殊元素


        /// <summary>
        /// 导出到Exel和word时模式化特殊元素
        /// </summary>
        /// <param name="gv"></param>
        static public void PrepareGridViewForExport(Control gv) 
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();
            string name = String.Empty;
            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }

                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }

                else if (gv.Controls[i].GetType() == typeof(CheckBox))
                {
                    l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(ImageButton))
                {
                    l.Text = "图片";
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].HasControls())
                {
                    PrepareGridViewForExport(gv.Controls[i]);
                }
            }
        }

        #endregion

        #region 验证输入类型


        /// <summary>
        /// 是否数字字符串
        /// </summary>
        public static bool IsNumber(string inputData)
        {
            Regex RegNumber = new Regex("^[0-9]+$");
            try
            {
                Match m = RegNumber.Match(inputData);
                return m.Success;
            }
            catch
            {
                return false;
            }
        } 

        /// <summary>
        /// 是否是日期格式
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static bool IsDate(string strDate) 
        {
            DateTime dtDate;
            bool bValid = true;
            try 
            {
                dtDate = DateTime.Parse(strDate);
            }
            catch (FormatException) 
            {
                // 如果解析方法失败则表示不是日期性数据
                bValid = false;
            }
            return bValid;
        }



#endregion


        #region 人民币转大写

        public static string CmycurD(decimal num)
        {
            string str1 = "零壹贰叁肆伍陆柒捌玖"; //0-9所对应的汉字 
            string str2 = "万仟佰拾亿仟佰拾万仟佰拾元角分"; //数字位所对应的汉字 
            string str3 = ""; //从原num值中取出的值 
            string str4 = ""; //数字的字符串形式 
            string str5 = ""; //人民币大写金额形式 
            int i; //循环变量 
            int j; //num的值乘以100的字符串长度 
            string ch1 = ""; //数字的汉语读法 
            string ch2 = ""; //数字位的汉字读法 
            int nzero = 0; //用来计算连续的零值是几个 
            int temp; //从原num值中取出的值 

            num = Math.Round(Math.Abs(num), 2); //将num取绝对值并四舍五入取2位小数 
            str4 = ((long)(num * 100)).ToString(); //将num乘100并转换成字符串形式 
            j = str4.Length; //找出最高位 
            if (j > 15) { return "溢出"; }
            str2 = str2.Substring(15 - j); //取出对应位数的str2的值。如:200.55,j为5所以str2=佰拾元角分 

            //循环取出每一位需要转换的值 
            for (i = 0; i < j; i++)
            {
                str3 = str4.Substring(i, 1); //取出需转换的某一位的值 
                temp = Convert.ToInt32(str3); //转换为数字 
                if (i != (j - 3) && i != (j - 7) && i != (j - 11) && i != (j - 15))
                {
                    //当所取位数不为元、万、亿、万亿上的数字时 
                    if (str3 == "0")
                    {
                        ch1 = "";
                        ch2 = "";
                        nzero = nzero + 1;
                    }
                    else
                    {
                        if (str3 != "0" && nzero != 0)
                        {
                            ch1 = "零" + str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                    }
                }
                else
                {
                    //该位是万亿，亿，万，元位等关键位 
                    if (str3 != "0" && nzero != 0)
                    {
                        ch1 = "零" + str1.Substring(temp * 1, 1);
                        ch2 = str2.Substring(i, 1);
                        nzero = 0;
                    }
                    else
                    {
                        if (str3 != "0" && nzero == 0)
                        {
                            ch1 = str1.Substring(temp * 1, 1);
                            ch2 = str2.Substring(i, 1);
                            nzero = 0;
                        }
                        else
                        {
                            if (str3 == "0" && nzero >= 3)
                            {
                                ch1 = "";
                                ch2 = "";
                                nzero = nzero + 1;
                            }
                            else
                            {
                                if (j >= 11)
                                {
                                    ch1 = "";
                                    nzero = nzero + 1;
                                }
                                else
                                {
                                    ch1 = "";
                                    ch2 = str2.Substring(i, 1);
                                    nzero = nzero + 1;
                                }
                            }
                        }
                    }
                }
                if (i == (j - 11) || i == (j - 3))
                {
                    //如果该位是亿位或元位，则必须写上 
                    ch2 = str2.Substring(i, 1);
                }
                str5 = str5 + ch1 + ch2;

                if (i == j - 1 && str3 == "0")
                {
                    //最后一位（分）为0时，加上“整” 
                    str5 = str5 + '整';
                }
            }
            if (num == 0)
            {
                str5 = "零元整";
            }
            return str5;
        }
        public static string CmycurD(string numstr)
        {
            try
            {
                decimal num = Convert.ToDecimal(numstr);
                return CmycurD(num);
            }
            catch
            {
                return "非数字形式！";
            }
        }

      #endregion



    }

}
