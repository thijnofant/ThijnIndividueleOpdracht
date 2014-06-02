using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class ChannelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WhaleTV"] != null && Request.Cookies["WhaleTV"]["UserName"] == Page.RouteData.Values["ChannelName"].ToString()
                && Request.Cookies["WhaleTV"]["Channel"] == null)
            {
                btnUpgrade.Visible = true;
                ChannelNAme.Visible = true;
                tbChannelName.Visible = true;
                tbDisc.Visible = true;
                cbAdds.Visible = true;
                RequiredFieldValChannelName.Enabled = true;
            }
            else
            {
                lblDiscription.Text = Controller.Instance.GetDisc(Page.RouteData.Values["ChannelName"].ToString());
                btnUpgrade.Visible = false;
                ChannelNAme.Visible = false;
                tbChannelName.Visible = false;
                cbAdds.Visible = false;
                tbDisc.Visible = false;
                RequiredFieldValChannelName.Enabled = false;
                string subs = Controller.Instance.GetSubs(Page.RouteData.Values["ChannelName"].ToString());
                lblSub.Text = "Subscribers: " + subs;
            }
            lblChannelName.Text = Page.RouteData.Values["ChannelName"].ToString();
        }

        protected void btnUpgrade_Click(object sender, EventArgs e)
        {
            Controller.Instance.upgradeAccount(Request.Cookies["WhaleTV"]["UserName"], tbChannelName.Text, cbAdds.Checked, tbDisc.Text);
            Response.Cookies["WhaleTV"]["Channel"] = tbChannelName.Text;
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            Controller.Instance.Subscribe(Page.RouteData.Values["ChannelName"].ToString(), Request.Cookies["WhaleTV"]["UserName"]);
            Response.RedirectToRoute("ChannelPage", "ChannelName='" + Page.RouteData.Values["ChannelName"].ToString() + "'");
        }
    }
}