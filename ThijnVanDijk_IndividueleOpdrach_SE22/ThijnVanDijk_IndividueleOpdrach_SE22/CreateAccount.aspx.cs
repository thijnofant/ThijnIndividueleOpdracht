using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["WhaleTV"] != null || Session["UserName"] != null)
            {
                Session["UserName"] = null;
                Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(-5);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnNewAccount_Click(object sender, EventArgs e)
        {
            string userName = this.tbUserName.Text;
            string password = this.tbPassword.Text;

            Controller.Instance.NewAccount(userName, password);

            if (Controller.Instance.LogIn(userName, password) == "1")
            {
                Response.Cookies["WhaleTV"]["UserName"] = userName;
                Response.Cookies["WhaleTV"].Expires = DateTime.Now.AddMinutes(15);
                Response.Redirect("CreateAccount.aspx");
            }
        }
    }
}