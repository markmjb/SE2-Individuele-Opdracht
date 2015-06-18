using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNet.Membership.OpenAuth;

namespace Web_S2.Account
{
    using Business;

    public partial class Manage : System.Web.UI.Page
    {
        readonly Business business = new Business();

        protected void Page_Load()
        {
              this.lblPass.Visible = false;
            

        }
        protected void Changepass(object sender, EventArgs e)
        {
            if (this.business.Checklogin((string)this.Session["LoggedInUserName"], this.Password.Text))
            {
                this.lblPass.Visible = false;
                this.business.UpdatePass((string)this.Session["LoggedInUserName"], this.TextBox1.Text);
            }
            else
            {
                this.lblPass.Visible = true;
            }
        }
    }
}