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
        string organiserKey;
        int amountOfEventsOrganised;
        string currentOrganisingRole;
        public Organiser(string id, string name, string password, string email, string rollNumber, string type, string organiserKey) : base(id, name, password, email, rollNumber, type)
        {
            this.organiserKey = organiserKey;
        }
        public override Organiser getOrganiser()
        {
            return this;
        }
        public override Participant getParticipant()
        {
            throw new NotImplementedException("Organiser not a participant");
        }
        public void organiseEvent(string organiserKey, string currentOrganisingRole, _Event e)
        {
            this.organiserKey = organiserKey;
            this.currentOrganisingRole = currentOrganisingRole;
            isOrganising(e);
        }
        public void isOrganising(_Event e)
        {
            e.addOrganiser(this);
        }
        public void finishEvent(_Event e)
        {
            currentOrganisingRole = null;
        }
    }
}