using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Database_Handler;

namespace SE
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void toReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //For Login
            string email = TextBox1.Text;
            string password = TextBox2.Text;

            if (email == "admin" && password == "12345")
            {
                Response.Redirect("About.aspx");
            }

            string connectionString = Connection.GetInstance().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Student WHERE email = @Email AND password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    // Retrieve user data
                    string queryUserData = "SELECT * FROM Student WHERE email = @Email";
                    SqlCommand commandUserData = new SqlCommand(queryUserData, connection);
                    commandUserData.Parameters.AddWithValue("@Email", email);

                    SqlDataReader reader = commandUserData.ExecuteReader();
                    if (reader.Read())
                    {
                        // Retrieve user information
                        int rollNumber = reader.GetInt32(reader.GetOrdinal("roll_number"));
                        string userName = reader.GetString(reader.GetOrdinal("name"));
                        //int age = reader.GetInt32(reader.GetOrdinal("age"));
                        string gender = reader.GetString(reader.GetOrdinal("gender"));
                        string mail = reader.GetString(reader.GetOrdinal("email"));

                        // Store user data in cookies
                        Response.Cookies["RollNumber"].Value = rollNumber.ToString();
                        Response.Cookies["UserName"].Value = userName;
                        Response.Cookies["email"].Value = mail;
                        Response.Cookies["Gender"].Value = gender;
                    }

                    // Close the reader
                    reader.Close();

                    // Redirect to Home.aspx
                    Response.Redirect("About.aspx");
                }

                else
                {
                    // Invalid account
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Invalid account');", true);
                }
            }
        }
    }
}