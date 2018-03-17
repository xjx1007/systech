using System;
using System.IO;


namespace KNet.DBUtility
{
    /// <summary>
    /// �ĵ��������ѯϵͳ���ĵ��ϴ���....
    /// ling xing gaoд��2008��3�·� 
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
				 return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
			}
			else
			{
                string upFileName = "Student.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //Ĭ����2M
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //��չ��
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //�ļ�����
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
                                return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;
                            }
                        }
                        else
                        {
                               return "����:���ϴ����ļ���ʽ�������������ܣ�" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "����:"+ex.ToString();
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
                return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
            }
            else
            {
                string upFileName = "mathinfo.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //Ĭ����2M
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //��չ��
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //�ļ�����
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
                                return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;
                            }
                        }
                        else
                        {
                            return "����:���ϴ����ļ���ʽ�������������ܣ�" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "����:" + ex.ToString();
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
                return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
            }
            else
            {
                string upFileName = "DBTelogInfo.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //Ĭ����2M
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //��չ��
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //�ļ�����
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
                                return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;
                            }
                        }
                        else
                        {
                            return "����:���ϴ����ļ���ʽ�������������ܣ�" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "����:" + ex.ToString();
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
                return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
            }
            else
            {
                string upFileName = "DBEnglistInfo.xls";
                try
                {
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 90)) //Ĭ����2M
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType; //��չ��
                        string FileExt = Path.GetExtension(FileName.PostedFile.FileName); //�ļ�����
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
                                return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;
                            }
                        }
                        else
                        {
                            return "����:���ϴ����ļ���ʽ�������������ܣ�" + FileExt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "����:" + ex.ToString();
                }
            }

        }
        //ɾ���ļ�
        public string Del(string fileName)
        {
            try
            {
                if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(fileName)))
                {
                    File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileName));
                    return "ɾ���ɹ���";
                }
                else {
                    return "�ļ�������";
                }
            }
            catch (IOException IE)
            {
                return IE.ToString();
            }
        }

        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="dir"></param>
        public void CreateDir(string dir)
        {
            if (dir.Length == 0) return;
            if (!Directory.Exists(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir))
                Directory.CreateDirectory(System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\" + dir);
        }

        /// <summary>
        /// �������ڵõ�Ŀ¼��
        /// </summary>
        /// <returns>yyyyMMdd</returns>
        public string GetDateDir()
        {
            return DateTime.Now.ToString("yyyyMM");
        }
    }
}