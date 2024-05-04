using System;
using System.Data.SqlClient;
using Project.Database_Handler;

namespace No
{
    public partial class regEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve the title from the query parameter
                string title = Request.QueryString["title"];
                // Set the retrieved title as the page title
                if (!string.IsNullOrEmpty(title))
                {
                    // Set the text of the pageTitle element to the retrieved title
                    pageTitle.InnerText = title;

                    // Retrieve logged-in student's roll number from cookie
                    int rollNumber = Convert.ToInt32(Request.Cookies["RollNumber"].Value);

                    // Check if the student is already registered for the event
                    bool isRegistered = CheckRegistration(rollNumber, title);

                    if (isRegistered)
                    {
                        // Display message indicating the student is already registered
                        // You can modify this to show a message in the HTML or add a label control
                        Response.Write("You are already registered for this event.");
                    }
                    else
                    {
                        // Display registration button
                        btnConfirmRegistration.Style.Remove("display");
                    }
                }
            }
        }

        // Function to check if the student is already registered for the event
        private bool CheckRegistration(int rollNumber, string eventTitle)
        {
            // Connection string for your database
            string connectionString = Connection.GetInstance().ConnectionString;

            // SQL query to check if the student is registered for the event
            string query = "SELECT COUNT(*) FROM EventRegistration " +
                           "INNER JOIN Event ON EventRegistration.event_id = Event.event_id " +
                           "WHERE Event.title = @Title AND EventRegistration.student_roll_number = @RollNumber";

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command to execute the SQL query
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@Title", eventTitle);
                    command.Parameters.AddWithValue("@RollNumber", rollNumber);

                    // Open the connection
                    connection.Open();

                    // Execute the query and get the result
                    int count = (int)command.ExecuteScalar();
                    connection.Close();
                    // If count > 0, student is registered for the event
                    return count > 0;
                }
            }
        }

        protected void btnConfirmRegistration_Click(object sender, EventArgs e)
        {
            // Retrieve logged-in student's roll number from cookie
            int rollNumber = Convert.ToInt32(Request.Cookies["RollNumber"].Value);

            // Retrieve the title from the query parameter
            string title = Request.QueryString["title"];

            // Insert the registration data into the database
            if (!string.IsNullOrEmpty(title))
            {
                InsertRegistration(rollNumber, title);
            }
        }

        private void InsertRegistration(int rollNumber, string eventTitle)
        {
            string connectionString=Connection.GetInstance().ConnectionString;
            string query = "INSERT INTO EventRegistration (registration_id, event_id, student_roll_number) " +
               "SELECT NEXT VALUE FOR RegistrationSequence, event_id, @RollNumber FROM Event WHERE title = @Title";


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RollNumber", rollNumber);
                    command.Parameters.AddWithValue("@Title", eventTitle);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void btnhome_Click(object sender, EventArgs e)
        {
            Response.Redirect("About.aspx");
        }
    }
}
