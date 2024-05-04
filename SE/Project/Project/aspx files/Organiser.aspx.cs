using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using Project.Database_Handler;

namespace SE
{
    public partial class Organiser : System.Web.UI.Page
    {
        string connectionString = Connection.GetInstance().ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Retrieve faculty ID from cookies
                if (Request.Cookies["FacultyId"] != null)
                {
                    int facultyId = Convert.ToInt32(Request.Cookies["FacultyId"].Value);

                    PopulateDropdown();

                    // Set "My Events" as the initially selected value
                    ddlEvents.SelectedValue = "MyEvents";

                    // Load "My Events" initially
                    LoadMyEvents(facultyId);
                }
            }
        }

        private void LoadMyEvents(int facultyId)
        {
            DataTable myEvents = GetMyEvents(facultyId);
            // Bind myEvents DataTable to GridView
            gvEvents.DataSource = myEvents;
            gvEvents.DataBind();
        }







        // Method to retrieve My Events from the database
        private DataTable GetMyEvents(int facultyId)
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Event WHERE organizer_faculty_id = @FacultyId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FacultyId", facultyId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Method to retrieve Other Events from the database
        private DataTable GetOtherEvents(int facultyId)
        {
            DataTable dt = new DataTable();
           
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Event WHERE organizer_faculty_id != @FacultyId";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FacultyId", facultyId);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Method to populate the dropdown with events
        private void PopulateDropdown()
        {
            // Clear existing items
            ddlEvents.Items.Clear();

            // Add options
            ddlEvents.Items.Add(new ListItem("My Events", "MyEvents"));
            ddlEvents.Items.Add(new ListItem("Other Events", "OtherEvents"));
        }

        // Event handler for dropdown selection
        protected void ddlEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show the add event button if "My Events" is selected
            addevent.Visible = ddlEvents.SelectedValue == "MyEvents";

            // Show Button1 only when "My Events" is selected
            Button1.Visible = ddlEvents.SelectedValue == "MyEvents";
            EventID.Visible = ddlEvents.SelectedValue == "MyEvents";
            EventTitle.Visible = ddlEvents.SelectedValue == "MyEvents";
            EventDesc.Visible = ddlEvents.SelectedValue == "MyEvents";
            Date.Visible = ddlEvents.SelectedValue == "MyEvents";
            Time.Visible = ddlEvents.SelectedValue == "MyEvents";
            venue.Visible = ddlEvents.SelectedValue == "MyEvents";
            DropDownList1.Visible = ddlEvents.SelectedValue == "MyEvents";
            Category.Visible = ddlEvents.SelectedValue == "MyEvents";
            Registration.Visible = ddlEvents.SelectedValue == "MyEvents";
            int facultyId = Convert.ToInt32(Request.Cookies["FacultyId"].Value);

            if (ddlEvents.SelectedValue == "MyEvents")
            {
                DataTable myEvents = GetMyEvents(facultyId);
                // Bind myEvents DataTable to GridView
                gvEvents.DataSource = myEvents;
                gvEvents.DataBind();

                
            }
            else if (ddlEvents.SelectedValue == "OtherEvents")
            {
                DataTable otherEvents = GetOtherEvents(facultyId);
                // Bind otherEvents DataTable to GridView
                gvEvents.DataSource = otherEvents;
                gvEvents.DataBind();

                
            }
        }

        protected void addevent_Click(object sender, EventArgs e)
        {
            // Gather data from text boxes
            int eventId;
            if (!int.TryParse(EventID.Text, out eventId))
            {
                
                return;
            }

            string title = EventTitle.Text;
            string description = EventDesc.Text;
            DateTime date = DateTime.Parse(Date.Text);
            TimeSpan time = TimeSpan.Parse(Time.Text);
            string venue1 = venue.Text;
            string department = DropDownList1.SelectedValue;
            string category = Category.Text;

            // Get faculty ID from cookies
            int organizerFacultyId = int.Parse(Request.Cookies["FacultyId"].Value);

            // Convert registration status to 1 or 0
            int registrationOpen = (Registration.SelectedValue == "Open") ? 1 : 0;

            // Check if the event ID already exists
            if (IsEventIdExists(eventId))
            {
                // Display a message indicating that the event ID already exists
                Response.Write("<script>alert('EventID');</script>");
                return;
            }

            // Insert into the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Event (event_id, title, description, date, time, venue, Department, category, organizer_faculty_id, registrationopen)
             VALUES (@EventId, @Title, @Description, @Date, @Time, @Venue, @Department, @Category, @OrganizerFacultyId, @RegistrationOpen)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@Date", date);
                    command.Parameters.AddWithValue("@Time", time);
                    command.Parameters.AddWithValue("@Venue", venue1);
                    command.Parameters.AddWithValue("@Department", department);
                    command.Parameters.AddWithValue("@Category", category);
                    command.Parameters.AddWithValue("@OrganizerFacultyId", organizerFacultyId);
                    command.Parameters.AddWithValue("@RegistrationOpen", registrationOpen);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private bool IsEventIdExists(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Event WHERE event_id = @EventId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

       
        protected void gvEvents_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected row
            GridViewRow row = gvEvents.SelectedRow;

            // Check if a row is selected
            if (row != null)
            {
                // Find the index of the event ID column in your GridView
                int eventIDColumnIndex = 0; // Assuming the event ID is the first column, adjust if needed

                // Retrieve the event ID from the selected row
                string eventID = row.Cells[eventIDColumnIndex].Text;

                // Now you have the event ID, you can perform further actions like deleting the event
                //DeleteEvent(eventID);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewFeedback.Aspx");
        }

        protected void DelEvent_Click(object sender, EventArgs e)
        {
            // Gather event ID from the textbox
            int eventId;
            if (!int.TryParse(DeleteEvent.Text, out eventId))
            {
                // Display a message if the entered ID is not a number
                Response.Write("<script>alert('Please enter a valid event ID.');</script>");
                return;
            }

            // Check if the event exists in the database
            if (!IsEventIdExists(eventId))
            {
                // Display a message indicating that the event was not found
                Response.Write("<script>alert('Event not found.');</script>");
                return;
            }

            // Delete the event from the database
            DeleteEventById(eventId);

            // Optionally, you can display a success message or perform any other actions after deleting the event
            Response.Write("<script>alert('Event deleted successfully.');</script>");
            // Reload the page
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void DeleteEventById(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Event WHERE event_id = @EventId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            // Extract data from fields
            int eventId;
            if (!int.TryParse(EventID.Text, out eventId))
            {
                // Display error message or handle invalid input
                return;
            }

            // Check if any data is entered
            bool dataEntered = false;

            // Create the update query
            string query = "UPDATE Event SET ";

            // Update title if entered
            if (!string.IsNullOrEmpty(EventTitle.Text))
            {
                query += "title = @Title, ";
                dataEntered = true;
            }

            // Update description if entered
            if (!string.IsNullOrEmpty(EventDesc.Text))
            {
                query += "description = @Description, ";
                dataEntered = true;
            }

            // Update date if entered
            DateTime date;
            if (DateTime.TryParse(Date.Text, out date))
            {
                query += "date = @Date, ";
                dataEntered = true;
            }

            // Update time if entered
            TimeSpan time;
            if (TimeSpan.TryParse(Time.Text, out time))
            {
                query += "time = @Time, ";
                dataEntered = true;
            }

            // Update venue if entered
            if (!string.IsNullOrEmpty(venue.Text))
            {
                query += "venue = @Venue, ";
                dataEntered = true;
            }

            // Update department if entered
            if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
            {
                query += "Department = @Department, ";
                dataEntered = true;
            }

            // Update category if entered
            if (!string.IsNullOrEmpty(Category.Text))
            {
                query += "category = @Category, ";
                dataEntered = true;
            }

            // Update organizer faculty id if entered
            int organizerFacultyId;
            if (int.TryParse(Request.Cookies["FacultyId"].Value, out organizerFacultyId))
            {
                query += "organizer_faculty_id = @OrganizerFacultyId, ";
                dataEntered = true;
            }

            // Update registration open status if entered
            int registrationOpen;
            if (Registration.SelectedValue == "Open" || Registration.SelectedValue == "Closed")
            {
                registrationOpen = (Registration.SelectedValue == "Open") ? 1 : 0;
                query += "registrationopen = @RegistrationOpen, ";
                dataEntered = true;
            }

            // Remove the trailing comma and space
            if (dataEntered)
            {
                query = query.Remove(query.Length - 2);
                query += " WHERE event_id = @EventId";
            }
            else
            {
                // No data entered, do nothing
                return;
            }

            // Update table with entered parameters
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);

                    // Add parameters if data is entered
                    if (!string.IsNullOrEmpty(EventTitle.Text))
                    {
                        command.Parameters.AddWithValue("@Title", EventTitle.Text);
                    }

                    if (!string.IsNullOrEmpty(EventDesc.Text))
                    {
                        command.Parameters.AddWithValue("@Description", EventDesc.Text);
                    }

                    if (DateTime.TryParse(Date.Text, out date))
                    {
                        command.Parameters.AddWithValue("@Date", date);
                    }

                    if (TimeSpan.TryParse(Time.Text, out time))
                    {
                        command.Parameters.AddWithValue("@Time", time);
                    }

                    if (!string.IsNullOrEmpty(venue.Text))
                    {
                        command.Parameters.AddWithValue("@Venue", venue.Text);
                    }

                    if (!string.IsNullOrEmpty(DropDownList1.SelectedValue))
                    {
                        command.Parameters.AddWithValue("@Department", DropDownList1.SelectedValue);
                    }

                    if (!string.IsNullOrEmpty(Category.Text))
                    {
                        command.Parameters.AddWithValue("@Category", Category.Text);
                    }

                    if (int.TryParse(Request.Cookies["FacultyId"].Value, out organizerFacultyId))
                    {
                        command.Parameters.AddWithValue("@OrganizerFacultyId", organizerFacultyId);
                    }

                    if (Registration.SelectedValue == "Open" || Registration.SelectedValue == "Closed")
                    {
                        registrationOpen = (Registration.SelectedValue == "Open") ? 1 : 0;
                        command.Parameters.AddWithValue("@RegistrationOpen", registrationOpen);
                    }

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            // Gather event ID from the textbox
            int eventId;
            if (!int.TryParse(RegBox.Text, out eventId))
            {
                // Display a message if the entered ID is not a number
                Response.Write("<script>alert('Please enter a valid event ID.');</script>");
                return;
            }

            // Check if the event exists in the database
            if (!IsEventIdExists(eventId))
            {
                // Display a message indicating that the event was not found
                Response.Write("<script>alert('Event not found.');</script>");
                return;
            }

            // Close the registration for the event
            CloseEventRegistration(eventId);

            // Optionally, you can display a success message or perform any other actions after closing the registration
            Response.Write("<script>alert('Event registration closed successfully.');</script>");
            // Reload the page or take any other necessary actions
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        private void CloseEventRegistration(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Event SET registrationopen = 0 WHERE event_id = @EventId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void Open_Click(object sender, EventArgs e)
        {
            
        }

        private void OpenEventRegistration(int eventId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Event SET registrationopen = 1 WHERE event_id = @EventId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EventId", eventId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        protected void Open_Click1(object sender, EventArgs e)
        {
            // Gather event ID from the textbox
            int eventId;
            if (!int.TryParse(RegBox.Text, out eventId))
            {
                // Display a message if the entered ID is not a number
                Response.Write("<script>alert('Please enter a valid event ID.');</script>");
                return;
            }

            // Check if the event exists in the database
            if (!IsEventIdExists(eventId))
            {
                // Display a message indicating that the event was not found
                Response.Write("<script>alert('Event not found.');</script>");
                return;
            }

            // Close the registration for the event
            OpenEventRegistration(eventId);

            // Optionally, you can display a success message or perform any other actions after closing the registration
            Response.Write("<script>alert('Event registration closed successfully.');</script>");
            // Reload the page or take any other necessary actions
            Response.Redirect(Request.Url.AbsoluteUri);
        }













        // Event handler for RowDataBound event of GridView



    }
}
