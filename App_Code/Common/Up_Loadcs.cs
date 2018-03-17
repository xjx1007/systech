using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;
using System.IO;

namespace KNet.Common
{
	/// <summary>
	/// �ϴ��ļ�����
	/// </summary>
	public class Up_Loadcs
	{
        ///Ĭ��ֻ���ϴ�gif�ļ���jpg�ļ�
        ///��󲻳���3M
        ///Ĭ�ϵ�ַ�ļ�����:Pic_upload
		public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile  FileName)
		{
			if (FileName.PostedFile.ContentLength == 0)
			{
				 return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
			}
			else
			{
				string upFileName ;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 3)) //Ĭ����2M
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {   
                    	string FileExt = Path.GetExtension(FileName.PostedFile.FileName);
                        string FileType = FileName.PostedFile.ContentType;
                     
                        if (FileType == "image/gif" || FileType == "image/pjpeg")
                        {
                            FileName.PostedFile.SaveAs(System.Web.HttpContext.Current.Server.MapPath("~/Logo_upload/") + upFileName);
                            return "/Pic_upload/" + upFileName;
                        }
                        else
                        {
                            return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;
                        }               
                    }
                }
                catch (Exception ex)
                {
                    return "����:"+ex.ToString();
                }
			}		
		}

        ///����������
        ///��һ���ϴ��ļ�
        ///�ڶ����ϴ�����·��
        public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile FileName,string FilePath)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
            }
            else
            {
                string upFileName;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 3)) //Ĭ����2M
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType;
                        if (FileType == "image/gif" || FileType == "image/pjpeg")
                        {
                            string FilePath1 = "/temp/"; //��ʱ�ļ���
                            try
                            {
                               FilePath1 = System.Web.HttpContext.Current.Server.MapPath(FilePath);
                            }
                            catch
                            {
                                return "����:" + FilePath+"����·��������";
                            }

                            FileName.PostedFile.SaveAs(FilePath1 + upFileName);
                            return FilePath+upFileName;
                        }
                        else
                        {
                            return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "����:" + ex.ToString();
                }
            }
        }

        ///����������
        ///�ڶ���ȷ���洢·��
        ///������ȷ���ļ�����,��������ö��ŷֿ�
        public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile FileName, string FilePath, string FileType)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
            }
            else
            {
                string upFileName;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 3)) //Ĭ����2M
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {
                        foreach(string temp in FileType.ToLower().Split(','))
                        {
                            if (Path.GetExtension(FileName.PostedFile.FileName).ToLower().Replace(".","").CompareTo(temp)==0)
                            {
                                string FilePath1 = "/temp/"; //��ʱ�ļ���                           
                                try
                                {
                                    FilePath1 = System.Web.HttpContext.Current.Server.MapPath(FilePath);
                                }
                                catch
                                {
                                    return "����:" + FilePath + "����·��������";
                                }
                                FileName.PostedFile.SaveAs(FilePath1 + upFileName);
                                return FilePath + upFileName;
                             }
                         }
                        return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;

                    }
                }
                catch (Exception ex)
                {
                    return "����:" + ex.ToString();
                }
            }
        }

        ///���ĸ�����:
        ///�ڶ���ȷ���洢·��
        ///������ȷ���ļ�����
        ///���ĸ�����Ϊ�ϴ��ļ��ڴ�С,��λΪ:KB
        public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile FileName, string FilePath, string FileType,int FileSize)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "����:�ϴ�ʧ�ܻ�ָ�����ļ�������";
            }
            else
            {
                string upFileName;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (FileSize)) 
                    {
                        return "����:�����ļ����󣬲����ϴ���";
                    }
                    else
                    {
                        foreach (string temp in FileType.ToLower().Split(','))
                        {
                            if (Path.GetExtension(FileName.PostedFile.FileName).ToLower().Replace(".", "").CompareTo(temp) == 0)
                            {
                                string FilePath1 = "/temp/"; //��ʱ�ļ���                           
                                try
                                {
                                    FilePath1 = System.Web.HttpContext.Current.Server.MapPath(FilePath);
                                }
                                catch
                                {
                                    return "����:" + FilePath + "����·��������";
                                }
                                FileName.PostedFile.SaveAs(FilePath1 + upFileName);
                                return FilePath + upFileName;
                            }
                        }
                        return "����:���ϴ����ļ����Ͳ������������ܣ�" + FileType;
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
                if (fileName.IndexOf("prnopic.jpg") != -1)
                {
                    if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(fileName)))
                    {
                        File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileName));
                        return "ɾ���ɹ���";
                    }
                    else
                    {
                        return "�ļ�������";
                    }
                }
                else
                {
                    return "";
                }
            }
            catch (IOException IE)
            {
                return IE.ToString();
            }
        }



        /// <summary>
        /// ��������ͼ
        /// </summary>
        /// <param name="originalImagePath">Դͼ·��������·����</param>
        /// <param name="thumbnailPath">����ͼ·��������·����</param>
        /// <param name="width">����ͼ���</param>
        /// <param name="height">����ͼ�߶�</param>
        /// <param name="mode">��������ͼ�ķ�ʽ</param>    
        public void MakeZoomImage(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            Image originalImage = Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":// ���Ƚ�����(�ĺ�)

                    if (originalImage.Width > originalImage.Height)
                    {
                        toheight = originalImage.Height * width / originalImage.Width;
                    }
                    else
                    {
                        towidth = originalImage.Width * height / originalImage.Height;
                    }

                    if (toheight > height)
                    {
                        int h = toheight;
                        toheight = height;
                        towidth = towidth * height / h;
                    }

                    if (towidth > width)
                    {
                        int w = towidth;
                        towidth = width;
                        toheight = toheight * width / w;
                    }

                    break;

                case "W"://ָ�����߰�����                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://ָ���ߣ�������
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://ָ���߿�ü��������Σ�                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //�½�һ��bmpͼƬ
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //�½�һ������
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //���ø�������ֵ��
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //���ø�����,���ٶȳ���ƽ���̶�
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //��ջ�������͸������ɫ���
            g.Clear(Color.Transparent);

            //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                //��jpg��ʽ��������ͼ
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }


            /*
              ˵��:�߻��߿���ܻ��������ֵ�����磬����Ҫ��ͼƬ��Ϊ150����Ϊ120����ԭͼ
            * ��Ϊ150����Ϊ150���಻��ʱ�����ɵ�ͼƬ�����б仯����Ҳ�Ǹ�150����150��������
            ������ЩͼƬ��ʾ����ҳ�ϵĸ�Ϊ150����Ϊ120�Ĺ�����ʱ�򣬸߷���ͻ�
            * ������ ��
            * �޸ĺ�:���������������ͼƬ�ᰴ��С�߽������ԣ������ԭͼ��Ϊ150����Ϊ150��
            Ҫ���150����120�������ɵ�ͼƬ����120*120����֮�����ǲ��������ҳ��
            * ���ƵĻ���ε������
            * 
            * ʹ�÷���:

            * zoomImage.MakeZoomImage(ԭ�ļ���, ����ͼ�ļ���, ����ͼ��,����ͼ�� , ģʽ);

            * ��:zoomImage.MakeZoomImage(Server.MapPath("~/uploads/")  + bigFilename, Server.MapPath("~/uploads/")  + smallFileName1, 150, 120, "HW");
            */
    }
}