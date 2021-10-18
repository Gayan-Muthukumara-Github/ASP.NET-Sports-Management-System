using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagement
{
    public partial class adminpage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("gamemanagement.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("competitormanagement.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventmanagement.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportmanagement.aspx");
        }
    }
}