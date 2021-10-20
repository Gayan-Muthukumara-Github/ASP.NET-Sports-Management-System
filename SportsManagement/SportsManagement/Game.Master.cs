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

            if (Session["role"] == null)
            {
                LinkButton2.Visible = true;
                LinkButton2.Text = "No user";
            }
            else if (Session["role"].Equals("1"))
            {
                LinkButton2.Visible = true;//User Label
                LinkButton2.Text = "Admin";
                LinkButton11.Visible = true; //Game Managment Link
                LinkButton12.Visible = true; //Event Managment Link
                LinkButton8.Visible = true; //Report Managment Link
                LinkButton10.Visible = true; //Competitor Managment Link
                LinkButton3.Visible = true; //Playerperformance link
                LinkButton4.Visible = true;//logout button
            }
            else if (Session["role"].Equals("2"))
            {
                LinkButton2.Visible = true;
                LinkButton2.Text = "Event Manager";
                LinkButton12.Visible = true; 
                LinkButton10.Visible = true; 
                LinkButton3.Visible = true;
                LinkButton4.Visible = true;
            }


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
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            
        }

        protected void LinkButton11_Click1(object sender, EventArgs e)
        {
            Response.Redirect("gamemanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventmanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("competitormanagement.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("reportmanagement.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            
            
            LinkButton2.Text = "No User";
            LinkButton11.Visible = false; 
            LinkButton12.Visible = false; 
            LinkButton8.Visible = false; 
            LinkButton10.Visible = false; 
            LinkButton4.Visible = false; 
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("playerperformance.aspx");
        }
    }
}