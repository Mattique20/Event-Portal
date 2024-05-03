/*
 TODO : 
- organisers
- participants
- dbManagement
- Feedback
- declare winneres
- genrate report
 */

using Antlr.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Project.Business_Logic
{
    public class _Event
    {
        string id { get; set; }
        string name { get; set; }
        string type { get; set; }
        int numberOfParticipants { get; set; }
        int teamSize { get; set; }
        /*List<User> organisers*/
        /*List<User> participants*/
        DateTime startTime { get; set; }
        DateTime endTime { get; set; }
        private bool isRegistrationOpen { get; set; }
        private bool isEventStarted { get; set; }

        public _Event(string id, string name, string type, int numberOfParticipants, int teamSize, DateTime startTime, DateTime endTime)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.numberOfParticipants = numberOfParticipants;
            this.teamSize = teamSize;
            this.startTime = startTime;
            this.endTime = endTime;
            this.isRegistrationOpen = true;
            this.isEventStarted = false;
        }
        public void setEvent(_Event e)
        {
            this.id = e.id;
            this.name = e.name;
            this.type = e.type;
            this.numberOfParticipants = e.numberOfParticipants;
            this.teamSize = e.teamSize;
            this.startTime = e.startTime;
            this.endTime = e.endTime;
            this.isRegistrationOpen = e.isRegistrationOpen;
            this.isEventStarted = e.isEventStarted;
        }

        public void addParticipant(/*User p*/)
        {
            //participants.add(p);
        }

        public void removeParticipant(/*User p*/) 
        {
            //participants.remove(p);
        }

        public void addOrganiser(/*User o*/)
        {
            //participants.add(o);
        }

        public void removeOrganiser(/*User o*/)
        {
            //participants.remove(o);
        }

        public void addFeedback(/*Feedback*/) { }

        public void openRegistration() { isRegistrationOpen = true; }

        public void closeRegistration() {  isRegistrationOpen = false; }

        public void startEvent() { isEventStarted = true; }

        public void endEvent() {  isEventStarted = false; }

        public void declareWinners() { }

        public void generateEventReport() { }
    }
}