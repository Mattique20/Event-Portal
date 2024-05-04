using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Database_Handler;

namespace SE
{
    public partial class RegisteredEvents : System.Web.UI.Page
    {
        // Connection string for your database
        string connectionString = Connection.GetInstance().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Bind registered events every time the page loads
            BindRegisteredEvents();
        }


        private void BindRegisteredEvents()
        {
            // Retrieve student roll number from cookies
            string studentRollNumber = Request.Cookies["RollNumber"]?.Value;

            if (!string.IsNullOrEmpty(studentRollNumber))
            {
                // Query to retrieve registered events for the student
                string query = @"
                    SELECT E.title, E.description, E.date, E.time, E.venue, E.Department, E.category
                    FROM Event E
                    INNER JOIN EventRegistration ER ON E.event_id = ER.event_id
                    WHERE ER.student_roll_number = @studentRollNumber";

                // Create a connection object
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a command object with the query and connection
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@studentRollNumber", studentRollNumber);

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

                                // Create a card for the event and add it to the page
                                AddEventCard(title, description, date, time, venue, department, category);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions
                        // You can log the exception or show an error message to the user
                        // For simplicity, this example will re-throw the exception
                        throw ex;
                    }
                }
            }
        }

        private void AddEventCard(string title, string description, DateTime date, TimeSpan time, string venue, string department, string category)
        {
            // Create a card element
            Panel card = new Panel();
            card.CssClass = "card";

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

            // Add feedback TextBox and submit button
            TextBox feedbackTextBox = new TextBox();
            feedbackTextBox.ID = "txtFeedback_" + title.Replace(" ", "_") + "_" + Guid.NewGuid().ToString("N"); // Unique ID for each TextBox
            feedbackTextBox.CssClass = "feedback-textbox";
            feedbackTextBox.Attributes["placeholder"] = "Enter Feedback";
            card.Controls.Add(feedbackTextBox);

            Button submitButton = new Button();
            submitButton.ID = "btnSubmit_" + title.Replace(" ", "_") + "_" + Guid.NewGuid().ToString("N"); // Unique ID for each Button
            submitButton.Text = "Submit";
            submitButton.CssClass = "submit-button";
            submitButton.Click += SubmitFeedback_Click; // Event handler for submit button click
            card.Controls.Add(submitButton);

            // Add the card to the page
            eventContainer.Controls.Add(card);
        }


        protected void SubmitFeedback_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string eventId = clickedButton.ID.Split('_')[1]; // Extract event ID from the button ID

            TextBox feedbackTextBox = (TextBox)FindControl("txtFeedback_" + eventId); // Find the corresponding feedback TextBox
            string feedback = feedbackTextBox.Text; // Get the feedback entered by the user

            // Process the feedback (for example, save it to the database or display it on the page)

            // Remove the feedback TextBox and submit button from the card
            Panel card = (Panel)clickedButton.Parent;
            card.Controls.Remove(feedbackTextBox);
            card.Controls.Remove(clickedButton);

            // Reload the page
            Response.Redirect(Request.RawUrl); // Reload the current page
        }



    }
}
