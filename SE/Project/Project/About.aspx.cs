using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string cssPath = Server.MapPath("./Content");  // Replace with actual path

            if (Directory.Exists(cssPath))
            {
                AddCssLinks(cssPath);
            }*/
        }

        private void AddCssLinks(string cssPath)
        {
            /*
            StringBuilder sb = new StringBuilder();
            foreach (string file in Directory.EnumerateFiles(cssPath, "*.css"))
            {
                string relativePath = VirtualPathUtility.ToAbsolute("./Content") + "/" + Path.GetFileName(file);  // Replace with actual path
                sb.AppendFormat("<link rel='stylesheet' href='{0}' />", relativePath);
            }

            LiteralControl control = new LiteralControl(sb.ToString());
            // Add the control to the appropriate location in your page (e.g., header)
            Page.Header.Controls.Add(control);*/
        }

    }
}