using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Business_Logic
{
    public abstract class User
    {
        string id { set; get; }
        string name { set; get; }
        string password { set; get; }
        string email { set; get; }
        string rollNumber { set; get; }
        string type { set; get; }

        public User(string id, string name, string password, string email, string rollNumber, string type)
        { 
            this.id = id;
            this.name = name;
            this.password = password;
            this.email = email;
            this.rollNumber = rollNumber;
            this.type = type;
        }
        public void setUser(User user)
        {
            this.id = user.id;
            this.name = user.name;
            this.password = user.password;
            this.email = user.email;
            this.rollNumber = user.rollNumber;
            this.type = user.type;
        }

        public abstract Participant getParticipant();
        public abstract Organiser getOrganiser();
    }
}