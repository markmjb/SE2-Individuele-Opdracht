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
    public partial class Register : Page
    {
        readonly Business.Databaseconnection databaseconnection = new Databaseconnection();

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //Checkt op een uniek email en vervolgens, als dit kan maakt hij het aan en logt hij in.
            if (databaseconnection.CheckRegister(new User(UserName.Text, Name.Text, Password.Text)))
            {
                databaseconnection.Register(new User(UserName.Text, Name.Text, Password.Text));
                databaseconnection.Checklogin(UserName.Text, Password.Text);
                if (true)
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