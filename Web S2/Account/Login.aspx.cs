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
        Business.Databaseconnection databaseconnection = new Databaseconnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
            ///Check if remember me is checked, if so create cookies if not delete cookies
            if (RememberMe.Checked == true)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["UserName"].Value = UserName.Text;
                Response.Cookies["Password"].Value = Password.Text;
            }
            else
            {
                if (Request.Cookies["UserName"] != null || Request.Cookies["Password"] != null)
                {
                    Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                }
            }

            //Kijkt of de login gegevens juist zijn, als het true returnt dan logt de gebruiker in en wordt hij verwijst naar zijn profiel
            //zo niet dan krijgt hij een error message te zien.
            if (databaseconnection.Checklogin(UserName.Text, Password.Text))
            {
                Session["LoggedInUserName"] = UserName.Text;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                FailureText.Text = "Incorrecte login gegevens!";
                ErrorMessage.Visible = true;
            }
        }
    }
}