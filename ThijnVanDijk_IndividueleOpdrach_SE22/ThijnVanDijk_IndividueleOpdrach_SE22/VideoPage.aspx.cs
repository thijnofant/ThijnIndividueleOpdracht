using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class VideoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.ToString() == "http://localhost:37078/VideoPage.aspx")
            {
                lblTitle.Text = "The title is here";
                linkChannel.Text = "Uploaders Channel";
                linkChannel.NavigateUrl = "~/Default.aspx";
            }
            else
            {
                Video vid = Controller.Instance.GetVid(Convert.ToInt32(Page.RouteData.Values["VideoID"]));
                lblTitle.Text = Page.RouteData.Values["VideoID"].ToString();
                linkChannel.Text = vid.ChannelName;
                linkChannel.NavigateUrl = "Channel/" + vid.ChannelName;
                lblLenght.Text = Controller.Instance.lenghtconverter(vid.Lenght);
                lblViews.Text = vid.views.ToString();
                lblLike.Text = vid.Likes.ToString();
                lblDislike.Text = vid.Dislikes.ToString();
            }
        }
    }
}