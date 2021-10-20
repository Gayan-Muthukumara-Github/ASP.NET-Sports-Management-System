using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SportsManagement
{
    public partial class loginmodule : System.Web.UI.Page
    {

        string strcon = WebConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void useremail_TextChanged(object sender, EventArgs e)
        {

        }
        //login button function
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
               
              

                SqlCommand cmd = new SqlCommand("select * from user_login where UserEmail='" + useremail.Text.Trim() + "' AND UserPassword='" +userpassword.Text.Trim() + "'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Session["role"] = sdr.GetValue(0).ToString();
                        string role = sdr.GetValue(3).ToString();
                        if (role=="Admin")
                        {
                            Response.Redirect("adminpage.aspx");
                        }
                        else if(role=="Event Manager")
                        {
                            Response.Redirect("eventmanagerpage.aspx");
                        }
                        
                    }
                    
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credential');</script>");

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
           
        }
    }
}