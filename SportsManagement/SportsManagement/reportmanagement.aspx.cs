using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagement
{
    public partial class reportmanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            GridView2.Visible = false;
        }
        //View Details of Event using event ID
        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from event where Event_ID='" + TextBox1.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                    clearForm();
                    con.Close();

                }





                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //View Medal's using country
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT Game_ID,Competitor_FName,Competitor_Medal FROM event_competition,competitor,game_competitor WHERE event_competition.Competitor_ID = competitor.Competitor_ID AND game_competitor.Competitor_ID = competitor.Competitor_ID AND Competitor_Country = '" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                    clearForm();
                    con.Close();

                }





                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //View World record acheived by game
        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select WorldRecord from event where Game_ID='" + TextBox3.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                    clearForm();
                    con.Close();

                }





                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //View World record acheived by country
        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT event.WorldRecord FROM event,competitor,event_competition WHERE event.Event_ID=event_competition.Event_ID AND competitor.Competitor_ID=event_competition.Competitor_ID AND Competitor_Country='" + TextBox4.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    GridView1.Visible = true;
                    GridView1.DataSource = dr;
                    GridView1.DataBind();
                    clearForm();
                    con.Close();

                }





                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //Overall world record
        protected void Button5_Click(object sender, EventArgs e)
        {
            GridView2.Visible = true;
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";


        }

    }
}