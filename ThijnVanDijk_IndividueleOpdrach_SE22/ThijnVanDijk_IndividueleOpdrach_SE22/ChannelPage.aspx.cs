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
            if (Session["UserName"] != null)
            {

                if (Session["UserName"].ToString() == Page.RouteData.Values["ChannelName"].ToString())
                {
                    this.btnUpgrade.Visible = true;
                    this.ChannelNAme.Visible = true;
                    this.tbChannelName.Visible = true;
                    this.tbDisc.Visible = true;
                    this.cbAdds.Visible = true;
                    this.RequiredFieldValChannelName.Enabled = true;
                    this.btnUpload.Visible = false;
                }
            }
            else if (Request.Cookies["WhaleTV"] != null && Page.RouteData.Values["ChannelName"].ToString() == Request.Cookies["WhaleTV"]["Channel"])
            {
                btnUpgrade.Visible = false;
                ChannelNAme.Visible = false;
                tbChannelName.Visible = false;
                cbAdds.Visible = false;
                tbDisc.Visible = false;
                RequiredFieldValChannelName.Enabled = false;
                this.btnUpload.Visible = true; ;
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
                this.btnUpload.Visible = false;
                string subs = Controller.Instance.GetSubs(Page.RouteData.Values["ChannelName"].ToString());
                lblSub.Text = "Subscribers: " + subs;
            }
            if (Request.Cookies["WhaleTV"] != null && Request.Cookies["WhaleTV"]["Channel"] == Page.RouteData.Values["ChannelName"].ToString())
            {
                lblDiscription.Text = Controller.Instance.GetDisc(Page.RouteData.Values["ChannelName"].ToString());
                btnUpgrade.Visible = false;
                ChannelNAme.Visible = false;
                tbChannelName.Visible = false;
                cbAdds.Visible = false;
                tbDisc.Visible = false;
                RequiredFieldValChannelName.Enabled = false;
                this.btnUpload.Visible = true;
                string subs = Controller.Instance.GetSubs(Page.RouteData.Values["ChannelName"].ToString());
                lblSub.Text = "Subscribers: " + subs;
            }
            lblChannelName.Text = Page.RouteData.Values["ChannelName"].ToString();
        }

        protected void btnUpgrade_Click(object sender, EventArgs e)
        {
            Controller.Instance.UpgradeAccount(Session["UserName"].ToString(), tbChannelName.Text, cbAdds.Checked, tbDisc.Text);
            Response.Cookies["WhaleTV"]["Channel"] = tbChannelName.Text;
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSub_Click(object sender, EventArgs e)
        {
            Controller.Instance.Subscribe(Page.RouteData.Values["ChannelName"].ToString(), Session["UserName"].ToString());
            Response.RedirectToRoute("ChannelPage", "ChannelName='" + Page.RouteData.Values["ChannelName"].ToString() + "'");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VideoUpload.aspx");
        }
    }
}