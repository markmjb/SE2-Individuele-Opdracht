// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Default.aspx.cs" company="Software">
//   Mark©
// </copyright>
// <summary>
//   The _ default.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Web_S2
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    using Business;

    /// <summary>
    /// The _ default.
    /// </summary>
    public partial class _Default : Page
    {
        /// <summary>
        /// The business.
        /// </summary>
        private readonly Business business = new Business();

        /// <summary>
        /// The articles.
        /// </summary>
        private List<Article> articles = new List<Article>();

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
            if (!this.IsPostBack)
            {
                this.articles = this.business.GetArticles();
                this.Session["Articles"] = this.articles;
            }

            this.lbArticles.DataSource = (List<Article>)this.Session["Articles"];
            this.lbArticles.DataValueField = "id";
            this.lbArticles.DataBind();
            this.lbArticles.SelectedIndex = 1;
        }

        /// <summary>
        /// The button comment click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BtnComment_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The label articles_ on selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void LbArticles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.articles = (List<Article>)this.Session["Articles"];
            foreach (var article in this.articles)
            {
                if (article.Title == this.lbArticles.SelectedItem.ToString())
                {
                    this.lblHeader.Text = article.Title;
                    this.tbbody.Text = article.Body;
                }
            }
        }
    }
}