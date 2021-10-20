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
    public partial class playerperformance : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGameIdValues();
            }
            GridView1.DataBind();
        }
        //Show Event and competitor ID
        void fillGameIdValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT Event_ID from event;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList1.DataSource = dt;
                DropDownList1.DataValueField = "Event_ID";
                DropDownList1.DataBind();

                SqlCommand cmd1 = new SqlCommand("SELECT Competitor_ID from competitor;", con);
                SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                DropDownList2.DataSource = dt1;
                DropDownList2.DataValueField = "Competitor_ID";
                DropDownList2.DataBind();



            }
            catch (Exception ex)
            {

            }
        }
        //GO
        protected void go_Click(object sender, EventArgs e)
        {
            getEventByID();
        }
        //Get Details
        void getEventByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from event_competition where Event_ID='" + DropDownList1.SelectedItem.Value + "' AND Competitor_ID='" + DropDownList2.SelectedItem.Value + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        position.Text = dr.GetValue(2).ToString();
                        DropDownList3.Text = dr.GetValue(3).ToString();
                       
                    }

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
        //Add
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfEventExists())
            {
                Response.Write("<script>alert('Event with this ID already Exist. You cannot add another Event with the same Game ID');</script>");
            }
            else
            {
                addNewEvent();
            }
        }
        //Add new function
        void addNewEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO event_competition(Event_ID,Competitor_ID,Competitor_Position,Competitor_Medal) values(@event_id,@competitor_id,@postion,@medal)", con);

                cmd.Parameters.AddWithValue("@event_id", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@competitor_id", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@postion", position.Text.Trim());
                cmd.Parameters.AddWithValue("@medal", DropDownList3.SelectedItem.Value);
            
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Event added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        
       //Update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfEventExists())
            {
                updateEvent();

            }
            else
            {
                Response.Write("<script>alert('Event does not exist');</script>");
            }
        }
        //Delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfEventExists())
            {
                deleteEvent();

            }
            else
            {
                Response.Write("<script>alert('Event does not exist');</script>");
            }
        }
        bool checkIfEventExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from event_competition where Event_ID='" + DropDownList1.SelectedItem.Value + "' AND Competitor_ID='" + DropDownList2.SelectedItem.Value + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }

        }
        void updateEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE event_competition SET Competitor_Position=@position,Competitor_Medal=@medal WHERE Event_ID='" + DropDownList1.SelectedItem.Value + "' AND Competitor_ID='" + DropDownList2.SelectedItem.Value + "'", con);


                cmd.Parameters.AddWithValue("@position", position.Text.Trim());
                cmd.Parameters.AddWithValue("@medal", DropDownList3.SelectedItem.Value);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Event Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM event_competition WHERE Event_ID ='" + DropDownList1.SelectedItem.Value + "' AND Competitor_ID='" + DropDownList2.SelectedItem.Value + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Event Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void clearForm()
        {
            DropDownList1.Text = "";
            DropDownList2.Text = "";
            DropDownList3.Text = "";
            position.Text = "";
        }

    }
}