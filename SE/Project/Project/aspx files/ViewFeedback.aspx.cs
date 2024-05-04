using System;
using System.Data.SqlClient;
using Project.Database_Handler;

namespace SE
{
    public partial class ViewFeedback : System.Web.UI.Page
    {
        string connectionString = Connection.GetInstance().ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindFeedbackData();
            }
        }

        private void BindFeedbackData()
        {
            string query = @"SELECT e.title AS EventTitle, o.faculty_name AS FacultyName, ef.feedback_text AS Feedback, ef.feedback_date AS Time
                            FROM Event e
                            JOIN EventFeedback ef ON e.event_id = ef.event_id
                            JOIN Organizer o ON e.organizer_faculty_id = o.faculty_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                }
                else
                {
                    // No rows found
                }

                reader.Close();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchKeyword))
            {
                string query = $@"SELECT e.title AS EventTitle, o.faculty_name AS FacultyName, ef.feedback_text AS Feedback, ef.feedback_date AS Time
                                FROM Event e
                                JOIN EventFeedback ef ON e.event_id = ef.event_id
                                JOIN Organizer o ON e.organizer_faculty_id = o.faculty_id
                                WHERE e.title LIKE '%{searchKeyword}%' OR o.faculty_name LIKE '%{searchKeyword}%' OR ef.feedback_text LIKE '%{searchKeyword}%'";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        GridView1.DataSource = reader;
                        GridView1.DataBind();
                    }
                    else
                    {
                        // No rows found
                    }

                    reader.Close();
                }
            }
            else
            {
                // Empty search keyword
                BindFeedbackData(); // Re-bind original data
            }
        }

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Organiser.aspx");
        }
    }
}
