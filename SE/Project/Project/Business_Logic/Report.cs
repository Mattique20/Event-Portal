/*
 * TODO:
 * generate report
 * generally check report
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Business_Logic
{
    public class Report
    {
        int id { set; get; }
        string eventID { set; get; }
        string reportID { set; get; }

        public Report(int id, string eventID, string reportID)
        {
            this.id = id;
            this.eventID = eventID;
            this.reportID = reportID;
        }
        void generateReport()
        {
            //TODO;
        }
    }
}