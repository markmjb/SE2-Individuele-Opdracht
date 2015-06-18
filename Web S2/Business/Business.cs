// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Business.cs" company="Software">
//   Mark B ©
// </copyright>
// <summary>
//   The business.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Business
{
    using System.Collections.Generic;

    /// <summary>
    /// The business.
    /// </summary>
    public class Business
    {
        /// <summary>
        /// The connection to the database.
        /// </summary>
        private readonly Databaseconnection databaseconnection = new Databaseconnection();

        /// <summary>
        /// The get articles.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Article> GetArticles()
        {
            return this.databaseconnection.GetArticles();
        }

        /// <summary>
        /// Checks the register
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CheckRegister(User user)
        {
            return this.databaseconnection.CheckRegister(user);
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        public void Register(User user)
        {
            this.databaseconnection.Register(user);
        }

        /// <summary>
        /// The check if the login info exists.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Checklogin(string text, string s)
        {
            return this.databaseconnection.Checklogin(text, s);
        }

        /// <summary>
        /// The update pass.
        /// </summary>
        /// <param name="s">
        /// The s.
        /// </param>
        /// <param name="text">
        /// The text.
        /// </param>
        public void UpdatePass(string s, string text)
        {
            this.databaseconnection.UpdatePass(s, text);
        }
    }
}