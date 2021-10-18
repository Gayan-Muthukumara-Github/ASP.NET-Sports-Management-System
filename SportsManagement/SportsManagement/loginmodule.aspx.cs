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
    public partial class loginmodule : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void useremail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uid = useremail.Text;
                string pass = userpassword.Text;
                string type = DropDownList1.SelectedValue;
                con.Open();
                string qry = "select * from [user] where UserEmail='" + uid + "' and UserPassword='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        
                        if (type == "Admin")
                        {
                            Response.Redirect("adminpage.aspx");
                        }
                        else if(type=="Event Manager")
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