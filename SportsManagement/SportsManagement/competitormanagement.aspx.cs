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
    public partial class competitormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //Go
        protected void go_Click(object sender, EventArgs e)
        {
            getCompetitorByID();
        }
        //Add
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfCompetitorExists())
            {
                Response.Write("<script>alert('Competitor with this ID already Exist. You cannot add another Game with the same Game ID');</script>");
            }
            else
            {
                addNewCompetitor();
            }
        }
        //Update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfCompetitorExists())
            {
                updateCompetitor();

            }
            else
            {
                Response.Write("<script>alert('Competitor does not exist');</script>");
            }
        }
        //Delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfCompetitorExists())
            {
                deleteCompetitor();

            }
            else
            {
                Response.Write("<script>alert('Competitor does not exist');</script>");
            }
        }
        void getCompetitorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from competitor where Competitor_ID='" + competitorid.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       
                        firstname.Text = dr.GetValue(1).ToString();
                        surname.Text = dr.GetValue(2).ToString();
                        dob.Text = dr.GetValue(3).ToString();
                        country.Text = dr.GetValue(4).ToString();
                        bio.Text = dr.GetValue(5).ToString();


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
        void addNewCompetitor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO competitor(Competitor_ID,Competitor_FName,Competitor_Surname,Competitor_DOB,Competitor_Country,Competitor_Bio) values(@competitor_id,@first_name,@sur_name,@dob,@country,@bio)", con);

                cmd.Parameters.AddWithValue("@competitor_id", competitorid.Text.Trim());
                cmd.Parameters.AddWithValue("@first_name", firstname.Text.Trim());
                cmd.Parameters.AddWithValue("@sur_name", surname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
                cmd.Parameters.AddWithValue("@country", country.Text.Trim());
                cmd.Parameters.AddWithValue("@bio", bio.Text.Trim());


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Competitor added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        bool checkIfCompetitorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from competitor where Competitor_ID='" + competitorid.Text.Trim() + "';", con);
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
        void updateCompetitor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE competitor SET Competitor_ID=@competitor_id,Competitor_FName=@first_name,Competitor_Surname=@sur_name,Competitor_DOB=@dob,Competitor_Country=@country,Competitor_Bio=@bio WHERE Competitor_ID='" + competitorid.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@competitor_id", competitorid.Text.Trim());
                cmd.Parameters.AddWithValue("@first_name", firstname.Text.Trim());
                cmd.Parameters.AddWithValue("@sur_name", surname.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", dob.Text.Trim());
                cmd.Parameters.AddWithValue("@country", country.Text.Trim());
                cmd.Parameters.AddWithValue("@bio", bio.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Game Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void deleteCompetitor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from competitor WHERE Competitor_ID='" + competitorid.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Competitor Deleted Successfully');</script>");
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
            competitorid.Text="";
            firstname.Text="";
            surname.Text="";
            dob.Text="";
            country.Text="";
            bio.Text="";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}