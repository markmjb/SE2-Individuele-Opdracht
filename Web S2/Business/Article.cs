using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Article
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Body { get; set; }

        public string Username { get; set; }

        public Article()
        {
            
        }
        public Article(int id, string title, DateTime date, string body, string username)
        {
            this.ID = id;
            this.Title = title;
            this.Date = date;
            this.Body = body;
            this.Username = username;
        }
    }
}
