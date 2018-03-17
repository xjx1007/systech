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
	/// 上传文件的类
	/// </summary>
	public class Up_Loadcs
	{
        ///默认只能上传gif文件和jpg文件
        ///最大不超过3M
        ///默认地址文件夹是:Pic_upload
		public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile  FileName)
		{
			if (FileName.PostedFile.ContentLength == 0)
			{
				 return "错误:上传失败或指定的文件不存在";
			}
			else
			{
				string upFileName ;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 3)) //默认是2M
                    {
                        return "错误:您的文件过大，不能上传！";
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
                            return "错误:您上传的文件类型不被服务器接受！" + FileType;
                        }               
                    }
                }
                catch (Exception ex)
                {
                    return "错误:"+ex.ToString();
                }
			}		
		}

        ///带两个参数
        ///第一个上传文件
        ///第二个上传到的路径
        public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile FileName,string FilePath)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "错误:上传失败或指定的文件不存在";
            }
            else
            {
                string upFileName;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 3)) //默认是2M
                    {
                        return "错误:您的文件过大，不能上传！";
                    }
                    else
                    {
                        string FileType = FileName.PostedFile.ContentType;
                        if (FileType == "image/gif" || FileType == "image/pjpeg")
                        {
                            string FilePath1 = "/temp/"; //临时文件夹
                            try
                            {
                               FilePath1 = System.Web.HttpContext.Current.Server.MapPath(FilePath);
                            }
                            catch
                            {
                                return "错误:" + FilePath+"，此路径不存在";
                            }

                            FileName.PostedFile.SaveAs(FilePath1 + upFileName);
                            return FilePath+upFileName;
                        }
                        else
                        {
                            return "错误:您上传的文件类型不被服务器接受！" + FileType;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return "错误:" + ex.ToString();
                }
            }
        }

        ///带三个参数
        ///第二个确定存储路径
        ///第三个确定文件类型,多个类型用逗号分开
        public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile FileName, string FilePath, string FileType)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "错误:上传失败或指定的文件不存在";
            }
            else
            {
                string upFileName;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (1024 * 3)) //默认是2M
                    {
                        return "错误:您的文件过大，不能上传！";
                    }
                    else
                    {
                        foreach(string temp in FileType.ToLower().Split(','))
                        {
                            if (Path.GetExtension(FileName.PostedFile.FileName).ToLower().Replace(".","").CompareTo(temp)==0)
                            {
                                string FilePath1 = "/temp/"; //临时文件夹                           
                                try
                                {
                                    FilePath1 = System.Web.HttpContext.Current.Server.MapPath(FilePath);
                                }
                                catch
                                {
                                    return "错误:" + FilePath + "，此路径不存在";
                                }
                                FileName.PostedFile.SaveAs(FilePath1 + upFileName);
                                return FilePath + upFileName;
                             }
                         }
                        return "错误:您上传的文件类型不被服务器接受！" + FileType;

                    }
                }
                catch (Exception ex)
                {
                    return "错误:" + ex.ToString();
                }
            }
        }

        ///带四个参数:
        ///第二个确定存储路径
        ///第三个确定文件类型
        ///第四个参数为上传文件在大小,单位为:KB
        public string UpFile(System.Web.UI.HtmlControls.HtmlInputFile FileName, string FilePath, string FileType,int FileSize)
        {
            if (FileName.PostedFile.ContentLength == 0)
            {
                return "错误:上传失败或指定的文件不存在";
            }
            else
            {
                string upFileName;
                try
                {
                    upFileName = System.DateTime.Now.ToString().Replace("-", "").Replace(" ", "").Replace(":", "") + Path.GetExtension(FileName.PostedFile.FileName);
                    if (FileName.PostedFile.ContentLength / 1024 > (FileSize)) 
                    {
                        return "错误:您的文件过大，不能上传！";
                    }
                    else
                    {
                        foreach (string temp in FileType.ToLower().Split(','))
                        {
                            if (Path.GetExtension(FileName.PostedFile.FileName).ToLower().Replace(".", "").CompareTo(temp) == 0)
                            {
                                string FilePath1 = "/temp/"; //临时文件夹                           
                                try
                                {
                                    FilePath1 = System.Web.HttpContext.Current.Server.MapPath(FilePath);
                                }
                                catch
                                {
                                    return "错误:" + FilePath + "，此路径不存在";
                                }
                                FileName.PostedFile.SaveAs(FilePath1 + upFileName);
                                return FilePath + upFileName;
                            }
                        }
                        return "错误:您上传的文件类型不被服务器接受！" + FileType;
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
                if (fileName.IndexOf("prnopic.jpg") != -1)
                {
                    if (File.Exists(System.Web.HttpContext.Current.Server.MapPath(fileName)))
                    {
                        File.Delete(System.Web.HttpContext.Current.Server.MapPath(fileName));
                        return "删除成功！";
                    }
                    else
                    {
                        return "文件不存在";
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
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
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
                case "HW":// 按比较缩放(改后)

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

                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
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

            //新建一个bmp图片
            Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
                new Rectangle(x, y, ow, oh),
                GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
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
              说明:高或者宽可能会大于需求值。比如，我需要的图片宽为150，高为120，当原图
            * 高为150，宽为150或差距不大时，生成的图片不会有变化，即也是高150，宽150，这样，
            当把这些图片显示到网页上的高为150，高为120的规格里的时候，高方向就会
            * 被撑破 。
            * 修改后:当出现这种情况后，图片会按最小边进行缩略，即如果原图高为150，宽为150，
            要求宽150，高120，那生成的图片就是120*120。总之，就是不会出现网页被
            * 撑破的或变形的情况。
            * 
            * 使用方法:

            * zoomImage.MakeZoomImage(原文件名, 缩略图文件名, 缩略图宽,缩略图高 , 模式);

            * 如:zoomImage.MakeZoomImage(Server.MapPath("~/uploads/")  + bigFilename, Server.MapPath("~/uploads/")  + smallFileName1, 150, 120, "HW");
            */
    }
}