using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagement
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Login
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginmodule.aspx");
        }
    }
}