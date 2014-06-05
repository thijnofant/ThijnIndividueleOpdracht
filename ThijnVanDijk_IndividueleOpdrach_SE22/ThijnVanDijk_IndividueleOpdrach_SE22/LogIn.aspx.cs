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
            if (this.Session["UserName"] != null)
            {
                this.Response.Redirect("Default.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userName = this.tbUserName.Text;
            string password = this.tbPassword.Text;

            string passcheck = Controller.Instance.LogIn(userName, password);

            if (passcheck == "1")
            {
                this.Session["UserName"] = this.tbUserName.Text;
                this.Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(15);
                this.Response.Redirect("LogIn.aspx");
            }
            else if (passcheck != "0")
            {
                this.Session["UserName"] = this.tbUserName.Text;
                this.Session.Timeout = 5;
                this.Response.Cookies["WhaleTV"]["Channel"] = passcheck;
                this.Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(15);
                this.Response.Redirect("LogIn.aspx");
            }
        }
    }
}