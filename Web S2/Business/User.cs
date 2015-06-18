// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Software">
//   Mark B ©
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Business
{
    /// <summary>
    /// The user.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        public User(string email, string name, string password)
        {
            this.Email = email;
            this.Name = name;
            this.Password = password;
        }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }
    }
}