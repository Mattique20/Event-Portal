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
    public class Participant : User
    {
        string roll_number;
        
        public Participant(string id, string name, string password, string email, string rollNumber, string type) : base(id, name, password, email, type)
        {
            this.roll_number = rollNumber;
        }
        public override Organiser getOrganiser()
        {
            throw new NotImplementedException("Participant is not an organiser");
        }
        public override Participant getParticipant()
        {
            return this;
        }
    }
}