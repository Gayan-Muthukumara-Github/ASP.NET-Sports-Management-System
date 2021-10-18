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
    public partial class eventmanagement : System.Web.UI.Page
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
        //Go
        protected void go_Click(object sender, EventArgs e)
        {
            getEventByID();
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
        void getEventByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from event where Event_ID='" + eventid.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        //DropDownList3.SelectedValue = dr.GetValue(1).ToString();
                        featureevent.Text = dr.GetValue(2).ToString();
                        eventvenue.Text = dr.GetValue(3).ToString();
                        eventdate.Text = dr.GetValue(4).ToString();
                        starttime.Text = dr.GetValue(5).ToString();
                        endtime.Text = dr.GetValue(6).ToString();
                        eventdescription.Text = dr.GetValue(7).ToString();
                        worldrecord.Text = dr.GetValue(8).ToString();


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
        bool checkIfEventExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from event where Event_ID='" + eventid.Text.Trim() + "';", con);
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
        void addNewEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO event(Event_ID,Game_ID,FeatureEvent,EventVenue,EventDate,EventStartTime,EventEndTime,EventDescription,WorldRecord) values(@event_id,@game_id,@event_feature,@event_venue,@event_date,@event_stime,@event_etime,@event_description,@event_wrecord)", con);

                cmd.Parameters.AddWithValue("@event_id", eventid.Text.Trim());
                cmd.Parameters.AddWithValue("@game_id", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@event_feature", featureevent.Text.Trim());
                cmd.Parameters.AddWithValue("@event_venue", eventvenue.Text.Trim());
                cmd.Parameters.AddWithValue("@event_date", eventdate.Text.Trim());
                cmd.Parameters.AddWithValue("@event_stime", starttime.Text.Trim());
                cmd.Parameters.AddWithValue("@event_etime", endtime.Text.Trim());
                cmd.Parameters.AddWithValue("@event_description", eventdescription.Text.Trim());
                cmd.Parameters.AddWithValue("@event_wrecord", worldrecord.Text.Trim());


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
        void updateEvent()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE event SET Game_ID=@game_id,FeatureEvent=@feature_event,EventVenue=@event_venue,EventDate=@event_date,EventStartTime=@start_time,EventEndTime=@end_time,EventDescription=@event_description,WorldRecord=@world_record WHERE Event_ID='" + eventid.Text.Trim() + "'", con);

                
                cmd.Parameters.AddWithValue("@game_id", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@feature_event", featureevent.Text.Trim());
                cmd.Parameters.AddWithValue("@event_venue", eventvenue.Text.Trim());
                cmd.Parameters.AddWithValue("@event_date", eventdate.Text.Trim());
                cmd.Parameters.AddWithValue("@start_time", starttime.Text.Trim());
                cmd.Parameters.AddWithValue("@end_time", endtime.Text.Trim());
                cmd.Parameters.AddWithValue("@event_description", eventdescription.Text.Trim());
                cmd.Parameters.AddWithValue("@world_record", worldrecord.Text.Trim());

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

                SqlCommand cmd = new SqlCommand("DELETE from event WHERE Event_ID='" + eventid.Text.Trim() + "'", con);

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
            eventid.Text = "";
            featureevent.Text = "";
            eventvenue.Text = "";
            eventdate.Text = "";
            starttime.Text = "";
            endtime.Text = "";
            eventdescription.Text = "";
            worldrecord.Text ="";
        }
        void fillGameIdValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT Game_ID from game;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "Game_ID";
                DropDownList3.DataBind();

                

            }
            catch (Exception ex)
            {

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}