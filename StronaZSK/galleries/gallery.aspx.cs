using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StronaZSK.galleries
{
    public partial class gallery1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["fullDirectoryPath"] == null)
            {
                Response.Redirect("/galleries/gallery_navigation.aspx");
            }
            else
            {
                string fullDirectoryPath = fullDirectoryPath = (string)Session["fullDirectoryPath"];
                Session["fullDirectoryPath"] = null;

                createGallery(fullDirectoryPath);
            }
        }

        protected void createGallery(string fullDirectoryPath)
        {
            string[] filePaths = Directory.GetFiles(fullDirectoryPath);
            string relativePath = @"/" + fullDirectoryPath.Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty) + @"\";

            for (int i = 0; i < filePaths.Length; i++)
            {                
                string fileName = Path.GetFileName(filePaths[i]);      
          
                HtmlGenericControl divcontrol = new HtmlGenericControl("div");
                divcontrol.Attributes["class"] = "image-field";
                panelGallery.Controls.Add(divcontrol);
                divcontrol.InnerHtml = string.Format("<a class='fancybox' rel='group' title='{2}' href='{0}'><img src='{1}' alt='' /></a>", relativePath + fileName,
                         relativePath + @"_thumb\" + fileName, Path.GetFileNameWithoutExtension(fileName));
            }
        }  
    }
}