using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThijnVanDijk_IndividueleOpdrach_SE22
{
    public partial class _Default : System.Web.UI.Page
    {
        private DBConnect connect = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.GridView1.DataSource = this.connect.Read();
            this.GridView1.DataBind();
        }
    }
}
