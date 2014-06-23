using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class VideoUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            int lenght;
            bool inttest = int.TryParse(tbLenght.Text, out lenght);
            if (inttest && fileUp.HasFile && Request.Cookies["WhaleTV"]["Channel"] != null)
            {
                string filepath = @"C:\Users\Systeembeheer\Desktop\" + fileUp.FileName;
                fileUp.SaveAs(filepath);
                Video temp = new Video(tbTitle.Text, Request.Cookies["WhaleTV"]["Channel"], lenght, filepath);
                if (Controller.Instance.uploadvid(temp))
                {
                    lblConfirm.Text = "Video has been uploaded";
                }
                else
                {
                    lblConfirm.Text = "Something went wrong, please try again later";
                }
            }
            else
            {
                if (inttest == false)
                {
                    lblConfirm.Text = "Something went wrong, please check if the lenght is in seconds";
                }
                else if (Request.Cookies["WhaleTV"]["Channel"] == null)
                {
                    lblConfirm.Text = "Something went wrong, please check if you're logged in";
                }
                else
                {
                      lblConfirm.Text = "Something went wrong, please check if you've selected a video to upload.";
                }
            }
        }
    }
}