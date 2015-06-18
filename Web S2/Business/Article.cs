// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Article.cs" company="Software">
//   Mark B ©
// </copyright>
// <summary>
//   The article.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Business
{
    using System;

    /// <summary>
    /// The article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        public Article()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="date">
        /// The date.
        /// </param>
        /// <param name="body">
        /// The body.
        /// </param>
        /// <param name="username">
        /// The username.
        /// </param>
        public Article(int id, string title, DateTime date, string body, string username)
        {
            this.ID = id;
            this.Title = title;
            this.Date = date;
            this.Body = body;
            this.Username = username;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }
    }
}