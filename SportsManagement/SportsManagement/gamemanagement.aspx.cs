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
    public partial class gamemanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //Go
        protected void go_Click(object sender, EventArgs e)
        {
            getGameByID();
        }
        //Add
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkIfGameExists())
            {
                Response.Write("<script>alert('Game with this ID already Exist. You cannot add another Game with the same Game ID');</script>");
            }
            else
            {
                addNewGame();
            }
        }
        //Update
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfGameExists())
            {
                updateGame();

            }
            else
            {
                Response.Write("<script>alert('Game does not exist');</script>");
            }

        }
        //Delete
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfGameExists())
            {
                deleteGame();

            }
            else
            {
                Response.Write("<script>alert('Game does not exist');</script>");
            }

        }
        //Get GAme details Function
        void getGameByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("select * from game where Game_ID='" + gameid.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        gamecode.Text = dr.GetValue(1).ToString();
                        gamename.Text = dr.GetValue(2).ToString();
                        gamedhours.Text = dr.GetValue(3).ToString();
                        gamedescription.Text = dr.GetValue(4).ToString();
                        

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
        //Add New Game Function
        void addNewGame()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO game(Game_ID,Game_Code,Game_Name,Game_DurationInHours,Game_Description) values(@game_id,@game_code,@game_name,@game_duration,@game_description)", con);

                cmd.Parameters.AddWithValue("@game_id", gameid.Text.Trim());
                cmd.Parameters.AddWithValue("@game_code", gamecode.Text.Trim());
                cmd.Parameters.AddWithValue("@game_name", gamename.Text.Trim());
                cmd.Parameters.AddWithValue("@game_duration", gamedhours.Text.Trim());
                cmd.Parameters.AddWithValue("@game_description", gamedescription.Text.Trim());
     

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Game added Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //Check Game Function
        bool checkIfGameExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from game where Game_ID='" + gameid.Text.Trim() + "';", con);
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
        //Update Game Function
        void updateGame()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE game SET Game_Code=@game_code,Game_Name=@game_name,Game_DurationInHours=@game_duration,Game_Description=@game_description WHERE Game_ID='" + gameid.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@game_code", gamecode.Text.Trim());
                cmd.Parameters.AddWithValue("@game_name", gamename.Text.Trim());
                cmd.Parameters.AddWithValue("@game_duration", gamedhours.Text.Trim());
                cmd.Parameters.AddWithValue("@game_description", gamedescription.Text.Trim());

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
        //Delete Game function
        void deleteGame()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from game WHERE Game_ID='" + gameid.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Game Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //Clear Text feild
        void clearForm()
        {
            gameid.Text = "";
            gamename.Text = "";
            gamecode.Text = "";
            gamedhours.Text = "";
            gamedescription.Text = "";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //home
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void gamecode_TextChanged(object sender, EventArgs e)
        {

        }
    }
}