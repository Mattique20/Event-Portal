using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using Project.Database_Handler;

namespace SE
{
    public partial class StudentEvent : System.Web.UI.Page
    {
        string connectionString = Connection.GetInstance().ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindEvents();
            }
        }

        private void BindEvents()
        {
            // Connection string for your database
            

            // Initialize the query string
            string query = "";

            // Retrieve student roll number from cookies
            string studentRollNumber = Request.Cookies["RollNumber"]?.Value;

            // If student roll number is available, adjust the query to filter out events already registered by the student
            if (!string.IsNullOrEmpty(studentRollNumber))
            {
                query += @"
                SELECT title, description, date, time, venue, Department, category 
                FROM Event
                WHERE event_id NOT IN (
                SELECT event_id
                FROM EventRegistration
                WHERE student_roll_number = @studentRollNumber
            )";
            }

            // Create a connection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a command object with the query and connection
                SqlCommand command = new SqlCommand(query, connection);

                // Add parameter if student roll number is available
                if (!string.IsNullOrEmpty(studentRollNumber))
                {
                    command.Parameters.AddWithValue("@studentRollNumber", studentRollNumber);
                }

                try
                {
                    // Open the database connection
                    connection.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Iterate through the result set
                        while (reader.Read())
                        {
                            // Retrieve event details from the result set
                            string title = reader["title"].ToString();
                            string description = reader["description"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date"]);
                            TimeSpan time = TimeSpan.Parse(reader["time"].ToString());
                            string venue = reader["venue"].ToString();
                            string department = reader["Department"].ToString();
                            string category = reader["category"].ToString();

                            // Create a card for the event and add it to the eventContainer div
                            AddEventCard(title, description, date, time, venue, department, category);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    // You can log the exception or show an error message to the user
                    // For simplicity, this example will re-throw the exception
                    Console.WriteLine("Hi");
                }
            }
        }


        public void viewRegisteredEvents()
        {
            Response.Redirect("RegisteredEvents.aspx");
        }

        public void viewBookmarkedEvents()
        {
            Response.Redirect("BookmarkedEvents.aspx");
        }

        private void AddEventCard(string title, string description, DateTime date, TimeSpan time, string venue, string department, string category)
        {
            // Create a card element
            Panel card = new Panel();
            card.CssClass = "card";
            card.Attributes.Add("data-department", department);

            // Populate card content
            Literal content = new Literal();
            content.Text = "<h3>" + title + "</h3>" +
                           "<p>" + description + "</p>" +
                           "<p>Date: " + date.ToString("yyyy-MM-dd") + "</p>" +
                           "<p>Time: " + time.ToString(@"hh\:mm") + "</p>" +
                           "<p>Venue: " + venue + "</p>" +
                           "<p>Department: " + department + "</p>" +
                           "<p>Category: " + category + "</p>";

            card.Controls.Add(content);


            // Add the card to the eventContainer div
            eventContainer.Controls.Add(card);
        }


        private int GetEventIdByTitle(string eventTitle)
        {
            int eventId = -1; // Initialize with a default value

            // Query to retrieve the event ID based on the title
            string query = "SELECT event_id FROM Event WHERE title = @Title";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", eventTitle);

                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    eventId = Convert.ToInt32(result);
                }
            }

            return eventId;
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
