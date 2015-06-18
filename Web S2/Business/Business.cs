namespace Business
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Business
    {
        private readonly Databaseconnection databaseconnection = new Databaseconnection();

        public List<Article> GetArticles()
        {
            return this.databaseconnection.GetArticles();
        }

        public bool CheckRegister(User user)
        {
            return this.databaseconnection.CheckRegister(user);
        }

        public void Register(User user)
        {
            this.databaseconnection.Register(user);
        }

        public bool Checklogin(string text, string s)
        {
            return this.databaseconnection.Checklogin(text,s);
        }

        public void UpdatePass(string s, string text)
        {
            this.databaseconnection.UpdatePass(s, text);
        }
    }
}
