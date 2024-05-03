using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Business_Logic
{
    public class ManagementSystem
    {
        private static ManagementSystem instance;
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

        public void getRegisteredEvent() { }

        public void closeEventRegistration() { }

        public void recordFeedback() { }

        public void getAllEvents() { }

        public void getAllRegisteredUsers() { }

        public void getAllRegisteredOrganisers() { }

        public void switchDisplayMode() { }

        public void createEvent() { }

        public void addFAQ() { }

        public void getFAQ() { }
    }
}