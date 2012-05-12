using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonitorSystem.Web.Servers;

namespace MonitorSystem.Web
{
    public partial class test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //
            string ComputeStr = "CHN[3,107,2]+30";

            Paser p = new Paser();
            string s = p.Execute("", ComputeStr);
            Response.Write(s);
        }
    }
}