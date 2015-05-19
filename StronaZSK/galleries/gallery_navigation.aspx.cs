using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StronaZSK.galleries
{
    public partial class gallery : System.Web.UI.Page
    {
        private String galleriesPath = HttpRuntime.AppDomainAppPath + @"galleries\";        

        protected void Page_Load(object sender, EventArgs e)
        {            
            //createThumbnailsForDirectory(HttpRuntime.AppDomainAppPath + @"galleries\wyklad_upc\");
            createGalleryNavigation();
        }

        protected void createGalleryNavigation()
        {
            string[] directoriesPaths = Directory.GetDirectories(galleriesPath);
            
            for (int i = 0; i < directoriesPaths.Length; i++)
            {
                string directoryName = new DirectoryInfo(directoriesPaths[i]).Name;
                createThumbnailsForDirectory(directoriesPaths[i]);
                string[] filePaths = Directory.GetFiles(directoriesPaths[i]);
                if (filePaths.Length > 0)
                {
                    string relativePath = @"/" + directoriesPaths[i].Replace(Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty) + @"\";
                    string fileName = Path.GetFileName(filePaths[0]);                    
                    
                    HtmlGenericControl divcontrol = new HtmlGenericControl("div");
                    divcontrol.Attributes["class"] = "image-field";
                    panelGallery.Controls.Add(divcontrol);                   
                    
                    ImageButton img = new ImageButton();
                    img.CssClass = "image";
                    img.ImageUrl = relativePath + @"_thumb\" + fileName;
                    img.CommandArgument = directoriesPaths[i];
                    img.Click += new ImageClickEventHandler(Image_Click);
                    divcontrol.Controls.Add(img);
                    Label imageLabel = new Label();
                    imageLabel.CssClass = "image-label";
                    imageLabel.Text = directoryName;
                    divcontrol.Controls.Add(imageLabel);
                }
            }
        }

        private void Image_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton im = (ImageButton)sender;
            Session["fullDirectoryPath"] = im.CommandArgument;
            Response.Redirect(@"/galleries/gallery.aspx");
        }              

        protected void createThumbnailsForDirectory(String fullDirectoryPath)
        {            
            string fullThumbnailsPath = fullDirectoryPath + @"\_thumb\";
            string[] filePaths = Directory.GetFiles(fullDirectoryPath);

            for (int i = 0; i < filePaths.Length; i++)
            {
                if (!Directory.Exists(fullThumbnailsPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(fullThumbnailsPath);
                    di.Attributes = FileAttributes.Directory | FileAttributes.Hidden; 
                }

                if (!File.Exists(fullThumbnailsPath + Path.GetFileName(filePaths[i])))
                {
                    System.Drawing.Image image = System.Drawing.Image.FromFile(filePaths[i]);
                    System.Drawing.Image thumb;
                    

                    if (image.Width > image.Height)
                    {
                        float ratio = image.Height / (float)image.Width;
                        thumb = image.GetThumbnailImage(160, (int)(160 * ratio), () => false, IntPtr.Zero);
                    }
                    else
                    {
                        float ratio = image.Width / (float)image.Height;
                        thumb = image.GetThumbnailImage((int)(120*ratio), 120, () => false, IntPtr.Zero);
                    }
                    thumb.Save(fullThumbnailsPath + Path.GetFileName(filePaths[i]));
                }
            }
        }


        /*protected void createThumbnailIfNecessary(String filePath)
        {
            if (!File.Exists(filePath.Substring(0, filePath.Length - 4) + "_thumb" + Path.GetExtension(filePath)))
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(filePath);
                System.Drawing.Image thumb = image.GetThumbnailImage(160, 120, () => false, IntPtr.Zero);
                thumb.Save(filePath.Substring(0, filePath.Length - 4) + "_thumb" + Path.GetExtension(filePath));                
            }
        }*/        
    }
}