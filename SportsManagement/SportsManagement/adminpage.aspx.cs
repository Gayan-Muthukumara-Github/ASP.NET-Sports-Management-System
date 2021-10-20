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
        //Admin Page Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("gamemanagement.aspx");
        }
        //Competitor Management Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("competitormanagement.aspx");
        }
        //Event Management Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventmanagement.aspx");
        }
        //Repprt Management Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportmanagement.aspx");
        }
        //Play Performance Button
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("playerperformance.aspx");
        }
    }
}