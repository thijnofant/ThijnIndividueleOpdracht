﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WhaleTV"] != null)
            {
                HyperLink1.Text = Request.Cookies["WhaleTV"]["UserName"];
                HyperLink1.NavigateUrl = "";

                hpSignUp.Text = "SignOut";
            }
        }
    }
}
