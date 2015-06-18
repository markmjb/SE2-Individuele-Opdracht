using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Web_S2.Account
{
    public partial class Login : Page
    {
        readonly Business.Databaseconnection databaseconnection = new Databaseconnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    UserName.Text = Request.Cookies["UserName"].Value;
                    Password.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            
            if (this.RememberMe.Checked == true)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["UserName"].Value = UserName.Text;
                Response.Cookies["Password"].Value = Password.Text;
            }
            else
            {
                if (this.Request.Cookies["UserName"] != null || this.Request.Cookies["Password"] != null)
                {
                    this.Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    this.Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                }
            }

            //Kijkt of de login gegevens juist zijn, als het true returnt dan logt de gebruiker in en wordt hij verwijst naar zijn profiel
            //zo niet dan krijgt hij een error message te zien.
            if (this.databaseconnection.Checklogin(this.UserName.Text, this.Password.Text))
            {
                this.Session["LoggedInUserName"] = this.UserName.Text;
                this.Response.Redirect("~/Default.aspx");
            }
            else
            {
                this.FailureText.Text = "Incorrecte login gegevens!";
                this.ErrorMessage.Visible = true;
            }
        }
    }
}