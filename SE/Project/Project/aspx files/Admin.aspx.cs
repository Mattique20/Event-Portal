using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Database_Handler;

namespace SE
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Event_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageEvents.aspx");
        }

        protected void Hire_Click(object sender, EventArgs e)
        {
            Response.Redirect("HireOrganiser.aspx");
        }
    }
}