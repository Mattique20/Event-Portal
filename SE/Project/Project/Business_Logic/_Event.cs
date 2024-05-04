/*
 TODO : 
- dbManagement
- Feedback
- genrate report
 */

using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Project.Database_Handler;

namespace Project.Business_Logic
{
    public class _Event
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string venue { get; set; }
        public TimeSpan time { get; set; }
        public DateTime date { get; set; }
        public List<User> registered_participants;
        public int organiser_faculty_id { get; set; }
        public string department {  get; set; }
        public string category { get; set; }

        public _Event(int id, string name, string type, string venue, string department, string category, TimeSpan time, DateTime date, int orgId)
        {
            registered_participants = new List<User>();
            this.id = id;
            this.name = name;
            this.description = type;
            this.venue = venue;
            this.department = department;
            this.category = category;
            this.date = date;
            this.time = time;
            this.organiser_faculty_id = orgId;
        }

        public _Event getEvent()
        {
            return null;
            //_Event e = DatabaseHandler.getInstance().
        }

        public void storeEvent() 
        {
            DatabaseHandler.getInstance().storeEvent(this);
        }
        public void registerUser(User user)
        {
            registered_participants.Add(user);
        }
    }
}