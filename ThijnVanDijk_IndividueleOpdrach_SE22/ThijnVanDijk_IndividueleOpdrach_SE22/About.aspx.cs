using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WhaleTV"] != null)
            {
                Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(-5);
                Response.Redirect("About.aspx");
            }
        }
    }
}
