using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Product
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Version { get; set; }

        public DateTime Releasedate { get; set; }

        public Product(int id, string brand, string version, DateTime releasedate)
        {
            this.Id = id;
            this.Brand = brand;
            this.Version = version;
            this.Releasedate = releasedate;
        }
    }
}
