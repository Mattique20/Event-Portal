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
        int activeEventsRegistered;
        int allTimeRegisteredEvents;
        int disqualifications;
        int winnings;
        int runnerUps;
        
        public Participant(string id, string name, string password, string email, string rollNumber, string type) : base(id, name, password, email, rollNumber, type)
        {
        }
        public override Organiser getOrganiser()
        {
            throw new NotImplementedException("Participant is not an organiser");
        }
        public override Participant getParticipant()
        {
            return this;
        }

        public void addEvent()
        {
            activeEventsRegistered++;
            allTimeRegisteredEvents++;
        }

        public void removeEvent()
        {
            activeEventsRegistered--;
            allTimeRegisteredEvents--;
        }
        public void addDisqualify()
        {
            activeEventsRegistered--;
            disqualifications++;
        }
        public void addWin()
        {
            activeEventsRegistered--;
            winnings++;
        }
        public void addRunnerUp()
        {
            activeEventsRegistered--;
            runnerUps++;
        }
    }
}