// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Site.Master.cs" company="Software">
//   Mark©
// </copyright>
// <summary>
//   The site master.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Web_S2
{
    using System;
    using System.Web.UI;

    using Business;

    /// <summary>
    /// The site master.
    /// </summary>
    public partial class SiteMaster : MasterPage
    {
        /// <summary>
        /// The temp.
        /// </summary>
        private string temp;

        /// <summary>
        /// The page start
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Init(object sender, EventArgs e)
        {
            this.temp = (string)this.Session["LoggedInUserName"];

            if (!this.IsPostBack)
            {
                if (this.Session["LoggedInUserName"] != null)
                {
                    this.Registerpage.InnerText = this.temp;
                    this.Registerpage.HRef = "Account/Manage";
                    this.Logging.InnerText = "Sign Off";
                }
            }
        }

        /// <summary>
        /// The master_ page_ pre load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void MasterPagePreLoad(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The homepage logo_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void HomepageLogo_Click(object sender, ImageClickEventArgs e)
        {
            this.Response.Redirect("~/Default.aspx");
        }

        /// <summary>
        /// The button search click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BtnSearchClick(object sender, EventArgs e)
        {
        this.Response.Write("Not Implemented");
        }

        /// <summary>
        /// The product page on server click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Productpage_OnServerClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Products.aspx");
        }

        /// <summary>
        /// The register page on server click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Registerpage_OnServerClick(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Account/Register.aspx");
        }

        /// <summary>
        /// The logging_ on server click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Logging_OnServerClick(object sender, EventArgs e)
        {
            if (this.Logging.InnerText == "Sign Off")
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