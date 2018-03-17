using System;
using System.Management;
using System.ServiceProcess;
using System.Configuration;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;


namespace KNet.DBUtility
{
    /// <summary>
    /// SoftRegister 的摘要说明
    /// </summary>
    public class SoftReg
    {
        public SoftReg()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 获取cpu序列号
        /// </summary>
        /// <returns></returns>
        public string GetCpuInfo()
        {
           return  "sdgsdgsdg";
        }
        /// <summary>
        /// 获取硬盘ID
        /// </summary>
        /// <returns></returns>
        public string GetHDid()
        {
            string HDid = "Kss201094552241545424";
            return HDid.ToString().Replace(" ","");
        }
        /// <summary>
        /// 获取网卡硬件地址
        /// </summary>
        /// <returns></returns>
        public string GetMoAddress()
        {
            string MoAddress = "K20102659836857455744457525";
            return MoAddress.ToString().Replace(" ", ""); 
        }
    }
    
}