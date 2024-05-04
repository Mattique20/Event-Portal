using Project.Business_Logic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.Database_Handler
{
    public class DatabaseHandler
    {
        private static string connection;
        private static DatabaseHandler instance;

        private DatabaseHandler() 
        {
            connection=Connection.GetInstance().ConnectionString;
        }

        public static DatabaseHandler getInstance()
        {
            if (instance == null)
                instance = new DatabaseHandler();
            return instance;
        }

        public void storeEvent(_Event e)
        {
            string query = "INSERT INTO Event (event_id, title, description, date, time, venue, Department, category, organizer_faculty_id) " +
                "VALUES (@event_id, @title, @description, @date, @time, @venue, @Department, @category, @organizer_faculty_id)";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    // Add parameters to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@event_id", e.id);
                    command.Parameters.AddWithValue("@title", e.name);
                    command.Parameters.AddWithValue("@description", e.description);
                    command.Parameters.AddWithValue("@date", e.date);
                    command.Parameters.AddWithValue("@time", e.time);
                    command.Parameters.AddWithValue("@venue", e.venue);
                    command.Parameters.AddWithValue("@Department", e.department);
                    command.Parameters.AddWithValue("@category", e.category);
                    command.Parameters.AddWithValue("@organizer_faculty_id", e.organiser_faculty_id);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        // Handle exception
                    }
                }
            }
        }

        public _Event getEvent(string id)
        {
            string query = "SELECT event_id, title, description, date, time, venue, Department, category, organizer_faculty_id" +
                " FROM Event WHERE event_id = @EventID";

            using (SqlConnection conn = new SqlConnection(connection))
            {
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@EventId", id);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Create an Event object and populate its properties from the database
                            _Event e = new _Event
                            (
                                reader.GetInt32(0),     // id
                                reader.GetString(1),    // name
                                reader.GetString(2),    // description
                                reader.GetString(5),    // venue
                                reader.GetString(6),    // department
                                reader.GetString(7),    // category
                                reader.GetTimeSpan(4), // time
                                reader.GetDateTime(3), // date
                                reader.GetInt32(8)     // organiser_faculty_id
                            );

                            return e;
                        }
                        else
                        {
                            // No event found
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        // Handle exception
                        return null;
                    }
                }
            }
        }

        public List<_Event> getAllEvents(int studentRollNumber)
        {
            // Initialize the query string
            string query = "";

            // If student roll number is available, adjust the query to filter out events already registered by the student
            query += @"
            SELECT event_id, title, description, date, time, venue, Department, category, organizer_faculty_id 
            FROM Event
            WHERE event_id NOT IN (
                SELECT event_id
                FROM EventRegistration
                WHERE student_roll_number = @studentRollNumber
            )";

            // Create a connection object
            using (SqlConnection conn = new SqlConnection(connection))
            {
                // Create a command object with the query and connection
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter if student roll number is available
                command.Parameters.AddWithValue("@studentRollNumber", studentRollNumber);
                List<_Event> evl = new List<_Event>();
                try
                {
                    // Open the database connection
                    conn.Open();

                    // Execute the query and retrieve the data
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Iterate through the result set
                        while (reader.Read())
                        {
                            // Retrieve event details from the result set
                            _Event e = new _Event
                            (
                                reader.GetInt32(0),     // id
                                reader.GetString(1),    // name
                                reader.GetString(2),    // description
                                reader.GetString(5),    // venue
                                reader.GetString(6),    // department
                                reader.GetString(7),    // category
                                reader.GetTimeSpan(4), // time
                                reader.GetDateTime(3), // date
                                reader.GetInt32(8)     // organiser_faculty_id
                            );

                            evl.Add( e );

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any exceptions
                    // You can log the exception or show an error message to the user
                    // For simplicity, this example will re-throw the exception
                    Console.WriteLine("Error While Reading All Events" + ex);
                }
                return evl;
            }
        }
    }
}