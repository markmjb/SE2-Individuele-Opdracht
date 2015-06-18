using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using Business;

namespace Web_S2.Account
{
    using Business = Business;

    public partial class Register : Page
    {
       readonly Business.Business business = new Business.Business();
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //Checkt op een uniek email en vervolgens, als dit kan maakt hij het aan en logt hij in.
            if (this.business.CheckRegister(new User(this.UserName.Text, this.Name.Text, this.Password.Text)))
            {
                this.business.Register(new User(this.UserName.Text, this.Name.Text, this.Password.Text));
               {
                    Session["LoggedInUserName"] = UserName.Text;
                    Response.Redirect("~/Default.aspx");
                }
            }
            else 
            {
                ErrorMessage.Text = "Email is al in gebruik!";
            }
        }
    }
}