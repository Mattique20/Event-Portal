using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project.Database_Handler;

namespace Project.Business_Logic
{
    public class ManagementSystem
    {
        private static ManagementSystem instance;
        DatabaseHandler db = DatabaseHandler.getInstance();

        private ManagementSystem()
        {
            //No More than one instance
        }

        public static ManagementSystem getInstance()
        {
            if (instance == null)
            {
                instance = new ManagementSystem();
            }
            return instance;
        }

        public void registerAccount(string name, string email, string password, string gender, string rollNo)
        {
            
        }

        public bool login(string email, string password)
        {
            
            return false;
        }

        public void registerEvent()
        {

        }

        public _Event getEvent(string id)
        {
            return db.getEvent(id);
        }

        public void getRegisteredEvent() { }

        public void closeEventRegistration() { }

        public void recordFeedback() { }

        public List<_Event> getAllEvents(int id) 
        {
            return db.getAllEvents(id);
        }

        public void getAllRegisteredUsers() { }

        public void getAllRegisteredOrganisers() { }

        public void switchDisplayMode() { }

        public void createEvent() { }

        public void addFAQ() { }

        public void getFAQ() { }
    }
}