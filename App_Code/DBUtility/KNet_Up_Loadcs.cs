using System;
using System.IO;


namespace KNet.DBUtility
{
    /// <summary>
    /// 文档管理与查询系统，文档上传类....
    /// ling xing gao写于2008年3月份 
    /// </summary>
	public class KNet_Up_Loadcs
	{
        /// <summary>
        /// AAAAAAAAAAAAAA
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
		public string UpFileA(System.Web.UI.HtmlControls.HtmlInputFile  FileName)
		{
			if (FileName.PostedFile.ContentLength == 0)
			{
				 return "错误:上传失败或指定的文件不存在";
			}
			else
			{
                string upFileName = "Student.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //默认是2M
                    {
                        return "错误:您的文件过大，不能上传！";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //扩展名
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //文件类型
                        string path = "/upfile/";
                        if (FileExt == ".xls")
                        {
                            if (FileType == "application/vnd.ms-excel")
                            {
                                FileName.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path) + upFileName);
                                return path + upFileName;
                            }
                            else
                            {
                                return "错误:您上传的文件类型不被服务器接受！" + FileType;
                            }
                        }
                        else
                        {
                               return "错误:您上传的文件格式不被服务器接受！" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "错误:"+ex.ToString();
                }
			}
		
		}

        /// <summary>
        /// BBBBBBBB
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public string UpFileB(System.Web.UI.HtmlControls.HtmlInputFile FileName)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "错误:上传失败或指定的文件不存在";
            }
            else
            {
                string upFileName = "mathinfo.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //默认是2M
                    {
                        return "错误:您的文件过大，不能上传！";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //扩展名
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //文件类型
                        string path = "/upfile/";
                        if (FileExt == ".xls")
                        {
                            if (FileType == "application/vnd.ms-excel")
                            {
                                FileName.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path) + upFileName);
                                return path + upFileName;
                            }
                            else
                            {
                                return "错误:您上传的文件类型不被服务器接受！" + FileType;
                            }
                        }
                        else
                        {
                            return "错误:您上传的文件格式不被服务器接受！" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "错误:" + ex.ToString();
                }
            }

        }



        /// <summary>
        /// CCCCCCCCCCCCCCC
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public string UpFileC(System.Web.UI.HtmlControls.HtmlInputFile FileName)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "错误:上传失败或指定的文件不存在";
            }
            else
            {
                string upFileName = "DBTelogInfo.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //默认是2M
                    {
                        return "错误:您的文件过大，不能上传！";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //扩展名
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //文件类型
                        string path = "/upfile/";
                        if (FileExt == ".xls")
                        {
                            if (FileType == "application/vnd.ms-excel")
                            {
                                FileName.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path) + upFileName);
                                return path + upFileName;
                            }
                            else
                            {
                                return "错误:您上传的文件类型不被服务器接受！" + FileType;
                            }
                        }
                        else
                        {
                            return "错误:您上传的文件格式不被服务器接受！" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "错误:" + ex.ToString();
                }
            }

        }


        /// <summary>
        /// DDDDDDDDDDDDDDD
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public string UpFileD(System.Web.UI.HtmlControls.HtmlInputFile FileName)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "错误:上传失败或指定的文件不存在";
            }
            else
            {
                string upFileName = "DBEnglistInfo.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //默认是2M
                    {
                        return "错误:您的文件过大，不能上传！";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //扩展名
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //文件类型
                        string path = "/upfile/";
                        if (FileExt == ".xls")
                        {
                            if (FileType == "application/vnd.ms-excel")
                            {
                                FileName.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath(path) + upFileName);
                                return path + upFileName;
                            }
                            else
                            {
                                return "错误:您上传的文件类型不被服务器接受！" + FileType;
                            }
                        }
                        else
                        {
                            return "错误:您上传的文件格式不被服务器接受！" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "错误:" + ex.ToString();
                }
            }

        }
        //删除文件
        public string Del(string fileName)
        {
            try
            {
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(fileName)))
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileName));
                    return "删除成功！";
                }
                else {
                    return "文件不存在";
                }
            }
            catch (IOException IE)
            {
                return IE.ToString();
            }
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="dir"></param>
        public void CreateDir(string dir)
        {
            if (dir.Length == 0) return;
            if (!Directory.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
                Directory.CreateDirectory(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
        }

        /// <summary>
        /// 根据日期得到目录名
        /// </summary>
        /// <returns>yyyyMMdd</returns>
        public string GetDateDir()
        {
            return DateTime.Now.ToString("yyyyMM");
        }
    }
}