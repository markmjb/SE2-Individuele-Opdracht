// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="Software">
//  Mark B ©
// </copyright>
// <summary>
//   The product.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Business
{
    using System;

    /// <summary>
    /// The product.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="brand">
        /// The brand.
        /// </param>
        /// <param name="version">
        /// The version.
        /// </param>
        /// <param name="releasedate">
        /// The release date.
        /// </param>
        public Product(int id, string brand, string version, DateTime releasedate)
        {
            this.Id = id;
            this.Brand = brand;
            this.Version = version;
            this.Releasedate = releasedate;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the brand.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        public DateTime Releasedate { get; set; }
    }
}