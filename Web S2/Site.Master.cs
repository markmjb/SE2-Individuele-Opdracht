using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business;

namespace Web_S2
{
    public partial class SiteMaster : MasterPage
    {
       private readonly Databaseconnection databaseconnection = new Databaseconnection();

        private string temp;
        protected void Page_Init(object sender, EventArgs e)
        {
            temp = (string)Session["LoggedInUserName"];

            if (!IsPostBack)
            {
                if (Session["LoggedInUserName"] != null)
                {

                    Registerpage.InnerText = temp;
                    Registerpage.HRef = "Account/Manage";
                    Logging.InnerText = "Sign Off";
                }
            }
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HomepageLogo_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnSearchClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        protected void Productpage_OnServerClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Products.aspx");
        }

        protected void Registerpage_OnServerClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Account/Register.aspx");
        }

        protected void Logging_OnServerClick(object sender, EventArgs e)
        {
            if (Logging.InnerText == "Sign Off")
            {
                this.Session["LoggedInUserName"] = null;
                this.Response.Redirect("~/Default.aspx");
            }
            else if (this.Logging.InnerText == "Log in")
            {
                this.Response.Redirect("~/Account/Login.aspx");
            }
        }
    }
}