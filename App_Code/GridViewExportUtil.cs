using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Web.Framework
{
    public class GridViewExportUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="gv"></param>
        public static void Export(string fileName, GridView gv)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader(
                "content-disposition", string.Format("attachment; filename={0}", fileName));
            HttpContext.Current.Response.ContentType = "application/ms-excel";

            StringBuilder strb = new StringBuilder();

            //  add the header row to the table
            if (gv.HeaderRow != null)
            {
                strb.AppendFormat("{0}", GridViewExportUtil.PrepareControlForExport(gv.HeaderRow).Replace("&nbsp;", ""));
                strb.Append("\n");
            }

            foreach (GridViewRow row in gv.Rows)
            {                
                strb.AppendFormat("{0}", GridViewExportUtil.PrepareControlForExport(row).Replace("&nbsp;", ""));
                strb.Append("\n");
            }

            //  add the footer row to the table
            if (gv.FooterRow != null)
            {
                strb.AppendFormat("{0}", GridViewExportUtil.PrepareControlForExport(gv.FooterRow).Replace("&nbsp;", ""));
                strb.Append("\n");
            }


            HttpContext.Current.Response.Write(strb);
            HttpContext.Current.Response.End();

        }

        /// <summary>
        /// Replace any of the contained controls with literals
        /// </summary>
        /// <param name="control"></param>
        private static string PrepareControlForExport(Control control)
        {
            StringBuilder strControls = new StringBuilder();

            for (int i = 0; i < control.Controls.Count; i++)
            {
                bool isVisible = true;

                Control current = control.Controls[i];
                if (current is DataControlFieldCell || current is DataControlFieldHeaderCell)
                {
                    if (current is DataControlFieldCell && (current as DataControlFieldCell).ContainingField.Visible == false)
                    {
                        isVisible = false;
                    }
                    if (current is DataControlFieldHeaderCell && (current as DataControlFieldHeaderCell).ContainingField.Visible == false)
                    {
                        isVisible = false;
                    }
                    if (isVisible)
                    {                        
                        if (current.HasControls())
                        {
                            strControls.AppendFormat("\"{0}\"", SingleQuatoToDouble(GridViewExportUtil.PrepareControlForExport(current)));
                        }
                        else
                        {
                            strControls.AppendFormat("\"{0}\"", SingleQuatoToDouble((current as DataControlFieldCell).Text));
                        }
                        strControls.Append(",");
                    }
                }
                else
                {
                    if (current.HasControls())
                    {
                        //strControls.Append(" ");
                        strControls.AppendFormat("{0}", SingleQuatoToDouble(GridViewExportUtil.PrepareControlForExport(current)));
                    }
                    else
                    {
                        if (current is LinkButton)
                        {
                            //control.Controls.Remove(current);
                            //control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
                            strControls.AppendFormat("{0}",(current as LinkButton).Text);
                        }
                        else if (current is ImageButton)
                        {
                            //control.Controls.Remove(current);
                            //control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
                            strControls.AppendFormat("{0}", (current as ImageButton).AlternateText);
                        }
                        else if (current is HyperLink)
                        {
                            //control.Controls.Remove(current);
                            //control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
                            strControls.AppendFormat("{0}", (current as HyperLink).Text);
                        }
                        else if (current is DropDownList)
                        {
                            //control.Controls.Remove(current);
                            //control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
                            strControls.AppendFormat("{0}", (current as DropDownList).SelectedItem.Text);
                        }
                        else if (current is CheckBox)
                        {
                            //control.Controls.Remove(current);
                            //control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                            strControls.AppendFormat("{0}", (current as CheckBox).Checked ? "True" : "False");
                        }
                        else if (current is Label)
                        {
                            //control.Controls.Remove(current);
                            //control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
                            strControls.AppendFormat("{0}", (current as Label).Text);
                        }
                        else if (current is System.Web.UI.DataBoundLiteralControl)
                        {
                            if ((current as DataBoundLiteralControl).Text.IndexOf("<img") != -1)
                            {
                                //control.Controls.Remove(current);
                            }
                            else
                            {
                                //control.Controls.Remove(current);
                                //control.Controls.AddAt(i, new LiteralControl((current as DataBoundLiteralControl).Text));
                                strControls.AppendFormat("{0}", (current as DataBoundLiteralControl).Text);
                            }
                            //control.Controls.Remove(current);
                        }
                        else if (current is System.Web.UI.LiteralControl)
                        {                            
                            //control.Controls.Remove(current);
                            //control.Controls.AddAt(i, new LiteralControl((current as DataBoundLiteralControl).Text));
                            strControls.AppendFormat("{0}", (current as LiteralControl).Text.Trim().Replace("\r\n", ""));                            
                        }
                    }
                }
            }


            return strControls.ToString();
        }
                

        public static string SingleQuatoToDouble(string strSingle)
        {
            string strReturn = strSingle;
            strReturn = strReturn.Replace("\"", "\"\"");
            return strReturn;
        }
    }
}
