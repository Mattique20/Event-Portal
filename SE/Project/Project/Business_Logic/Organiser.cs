/*
 * TODO
 * Implement Organiser Class
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Business_Logic
{
    public class Organiser : User
    {
        public Organiser(string id, string name, string password, string email, string rollNumber, string type) : base(id, name, password, email, rollNumber, type)
        {
        }
        /*

        public override Organiser getOrganiser()
        {
            throw new NotImplementedException();
        }

        public override Participant getParticipant()
        {
            throw new NotImplementedException("Organiser not a participant");
        }*/
    }
}