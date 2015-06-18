using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNet.Membership.OpenAuth;

namespace Web_S2.Account
{
    using Business;

    public partial class Manage : System.Web.UI.Page
    {
        Databaseconnection databaseconnection = new Databaseconnection();

        protected void Page_Load()
        {
              lblPass.Visible = false;
            

        }
        protected void Changepass(object sender, EventArgs e)
        {
            if (databaseconnection.Checklogin((string)Session["LoggedInUserName"], Password.Text))
            {
                lblPass.Visible = false;
                databaseconnection.UpdatePass((string)Session["LoggedInUserName"], TextBox1.Text);
            }
            else
            {
                lblPass.Visible = true;
            }
        }
    }
}