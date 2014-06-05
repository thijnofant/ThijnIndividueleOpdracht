using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Routing;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 10;

            if (Session["UserName"] != null)
            {
                this.HyperLink1.Text = Session["UserName"].ToString();

                if (Request.Cookies["WhaleTV"]["Channel"] != null)
                {
                    this.HyperLink1.NavigateUrl = "Channel/" + Request.Cookies["WhaleTV"]["Channel"];
                }
                else
                {
                    this.HyperLink1.NavigateUrl = "Channel/" + Session["UserName"];
                }

                this.hpSignUp.Text = "SignOut";
            }
        }
    }
}
