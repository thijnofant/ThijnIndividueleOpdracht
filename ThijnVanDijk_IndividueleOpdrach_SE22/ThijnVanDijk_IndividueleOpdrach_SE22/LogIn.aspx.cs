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
            if (Request.Cookies["WhaleTV"] != null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text;
            string password = tbPassword.Text;

            string Passcheck = Controller.Instance.LogIn(userName, password);

            if (Passcheck == "1")
            {
                Response.Cookies["WhaleTV"]["UserName"] = tbUserName.Text;
                Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(15);
                Response.Redirect("LogIn.aspx");
            }
            else if (Passcheck != "0")
            {
                Response.Cookies["WhaleTV"]["UserName"] = tbUserName.Text;
                Response.Cookies["WhaleTV"]["Channel"] = Passcheck;
                Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(15);
                Response.Redirect("LogIn.aspx");
            }
        }
    }
}