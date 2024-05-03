using System;
using System.Data.SqlClient;
using System.Threading;

namespace SE
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void toLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }


        protected void reg_Click(object sender, EventArgs e)
        {
            // Retrieve data from text boxes
            string email1 = email.Text;
            string name1 = name.Text;
            string gender1 = gender.Text;
            string password1 = password.Text;
            string rollNumberStr1 = rollNumber.Text;

            // Validate roll number
            int rollNumber1;
            if (!int.TryParse(rollNumberStr1, out rollNumber1))
            {
                // Roll number is not a valid number
                Response.Write("<script>alert('Roll number must be a valid number.');</script>");
                return;
            }

            // Connect to the database
            string connectionString = "Data Source=SHAHEER\\SQLEXPRESS01;Initial Catalog=SE_Project;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if roll number already exists
                string query = "SELECT COUNT(*) FROM Student WHERE roll_number = @rollNumber";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@rollNumber", rollNumber1);
                    int existingCount = (int)command.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        // Roll number already exists
                        Response.Write("<script>alert('Account already exists.');</script>");
                        return;
                    }
                }

                // Check if email already exists
                query = "SELECT COUNT(*) FROM Student WHERE email = @Email";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email1);
                    int existingEmailCount = (int)command.ExecuteScalar();

                    if (existingEmailCount > 0)
                    {
                        // Email already exists
                        Response.Write("<script>alert('Email already exists. Please use a different email.');</script>");
                        return;
                    }
                }

                // Insert new record
                query = "INSERT INTO Student (roll_number, email, name, password, gender) VALUES (@rollNumber, @email, @name, @password, @gender)";
                using (SqlCommand insertCommand = new SqlCommand(query, connection))
                {
                    insertCommand.Parameters.AddWithValue("@rollNumber", rollNumber1);
                    insertCommand.Parameters.AddWithValue("@email", email1);
                    insertCommand.Parameters.AddWithValue("@name", name1);
                    insertCommand.Parameters.AddWithValue("@password", password1);
                    insertCommand.Parameters.AddWithValue("@gender", gender1);
                    insertCommand.ExecuteNonQuery();

                    // Registration successful prompt
                    Response.Write("<script>alert('Registration successful. Please log in.');</script>");

                    // Redirect to login page
                    Response.Redirect("LoginPage.aspx");
                }
            }
        }

    }
}
