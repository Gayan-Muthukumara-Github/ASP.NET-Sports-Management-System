using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagement
{
    public partial class Game : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("gamemanagement.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginmodule.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginmodule.aspx");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {

        }
    }
}