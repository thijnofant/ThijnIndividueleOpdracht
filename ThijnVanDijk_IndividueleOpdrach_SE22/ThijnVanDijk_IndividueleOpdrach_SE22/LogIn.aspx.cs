using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string password = tbPassword.Text;

            string passcheck = Controller.Instance.LogIn(userName, password);

            if (passcheck == "1")
            {
                Session["UserName"] = tbUserName.Text;
                Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(15);
                Response.Redirect("LogIn.aspx");
            }
            else if (passcheck != "0")
            {
                Session["UserName"] = tbUserName.Text;
                Session.Timeout = 5;
                Response.Cookies["WhaleTV"]["Channel"] = passcheck;
                Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(15);
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}