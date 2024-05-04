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
        string type { set; get; }

        public User(string id, string name, string password, string email, string type)
        { 
            this.id = id;
            this.name = name;
            this.password = password;
            this.email = email;
            this.type = type;
        }
       public abstract Participant getParticipant();
       public abstract Organiser getOrganiser();
    }
}