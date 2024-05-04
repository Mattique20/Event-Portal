using System;
using System.Configuration;
using System.Data.SqlClient;
using Project.Database_Handler;

namespace SE
{
    public partial class HireOrganiser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnHire_Click(object sender, EventArgs e)
        {
            string connectionString = Connection.GetInstance().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Organizer (faculty_id, faculty_name, faculty_email, faculty_password) VALUES (@FacultyId, @FacultyName, @FacultyEmail, @FacultyPassword)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FacultyId", txtFacultyId.Text);
                command.Parameters.AddWithValue("@FacultyName", txtFacultyName.Text);
                command.Parameters.AddWithValue("@FacultyEmail", txtFacultyEmail.Text);
                command.Parameters.AddWithValue("@FacultyPassword", txtFacultyPassword.Text);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    // Optionally, you can provide feedback to the user that the hiring process was successful
                    Response.Write("Organiser hired successfully!");
                }
                catch (Exception ex)
                {
                    // Handle exceptions, such as displaying an error message
                    Response.Write("Error: " + ex.Message);
                }
            }
        }
    }
}
