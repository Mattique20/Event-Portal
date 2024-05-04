using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Web.UI.WebControls;
using Project.Database_Handler;
using Project.Business_Logic;

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
            // Retrieve student roll number from cookies
            string studentRollNumber = Request.Cookies["RollNumber"]?.Value;
            int id = int.Parse(studentRollNumber);

            List<_Event> ee = ManagementSystem.getInstance().getAllEvents(id);

            for (int i = 0; i < ee.Count; i++)
            {
                AddEventCard(ee[i].name, ee[i].description, ee[i].date, ee[i].time, ee[i].venue, ee[i].department, ee[i].category);
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
