/*
 * TODO
 * DB Management
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Business_Logic
{

    public class Organiser : User
    {
        string facultyID;
        public Organiser(string id, string name, string password, string email, string type, string facultyID) : base(id, name, password, email, type)
        {
            this.facultyID = facultyID;
        }
        public override Organiser getOrganiser()
        {
            return this;
        }
        public override Participant getParticipant()
        {
            throw new NotImplementedException("Organiser not a participant");
        }
    }
}