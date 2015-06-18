using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_S2
{
    using System.Web.DynamicData;

    using Business;

    public partial class _Default : Page
    {
        readonly Business business = new Business();

        private List<Article> articles = new List<Article>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
            this.articles  = this.business.GetArticles();
            this.Session["Articles"] = this.articles;
            }
            this.lbArticles.DataSource = (List<Article>)this.Session["Articles"];
            this.lbArticles.DataValueField = "id";
            this.lbArticles.DataBind();
            this.lbArticles.SelectedIndex = 1;

        }

        protected void BtnComment_Click(object sender, EventArgs e)
        {
           
        }

        protected void lbArticles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            this.articles = (List<Article>)this.Session["Articles"];
            foreach (var article in this.articles)
            {
                if (article.Title==this.lbArticles.SelectedItem.ToString())
                {
                    this.lblHeader.Text = article.Title;
                    this.tbbody.Text = article.Body;
                }
            }
        }
    }

}