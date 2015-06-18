namespace Business
{
    using Oracle.DataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Databaseconnection
    {
        //The oracle connection used throughout the whole dbconnection.
        private readonly OracleConnection connection;
        // Initialize the reader here so you can close it safely.
        private OracleDataReader reader;

        private bool returnbool;
        // General comments:
        // - Initialize returnvariables before the try (both declare and initialize) , and return them after the finally. 
        // - Do not use reserved keywords for parameters. 
        // - OracleException and Exception are interchangable: but OracleException shows the popup directly when it crashes. 
        // - These example use the latest database from PTS2 as found on https://portal.fhict.nl/IS/S2/Lesmateriaal%20Reguliere%20stroom/OracleScripts_Camping.rar
        public Databaseconnection()
        {
            this.connection = new OracleConnection
            {
                ConnectionString =
                    "User Id=mark;Password=mark;Data Source=localhost/xe;"
            };
            //Connection string for Athena Oracle Database (Backup)
            //this.connection.ConnectionString = "User Id=dbi304910;Password=drlc3PnAnP;Data Source=//192.168.15.50:1521/fhictora;";
            //Connection string for Local Oracle Database
        }
        public bool Checklogin(string username, string passw)
        {
            try
            {
                OracleCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "select Email from dbuser where Email= :email and dbpassword=:pw";
                cmd.Parameters.Add("email", username);
                cmd.Parameters.Add("pw", passw);
                this.connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                this.returnbool = reader.HasRows;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                this.connection.Close();
            }
            return this.returnbool;
        }

        public bool CheckRegister(User user)
        {
            try
            {
                OracleCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "select Email from dbuser where Email= :email";
                cmd.Parameters.Add("email", user.Email);
                this.connection.Open();
                OracleDataReader reader = cmd.ExecuteReader();
                this.returnbool = !reader.HasRows;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                this.connection.Close();
            }
            return this.returnbool;
        }

        public void Register(User user)
        {
            try
            {
                OracleCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "INSERT INTO DBUSER (EMAIL, DBPASSWORD, USERNAME ) VALUES (:Email,:Pass,:Name)";
                cmd.Parameters.Add("Email", user.Email);
                cmd.Parameters.Add("Pass", user.Password);
                cmd.Parameters.Add("Name", user.Name);

                this.connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void UpdatePass(string username, string passw)
        {
            try
            {
                OracleCommand cmd = this.connection.CreateCommand();
                cmd.CommandText = "UPDATE dbuser SET dbpassword = :Pass WHERE email = :Email";
                cmd.Parameters.Add("Pass", passw);
                cmd.Parameters.Add("Email", username);
                this.connection.Open();
                cmd.ExecuteReader();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
            finally
            {
                this.connection.Close();
            }
        }

        public List<Article> GetArticles()
        {
            List<Article> articles = new List<Article>();
            OracleCommand cmd = this.connection.CreateCommand();
            cmd.CommandText = "select * from Article";
            try
            {
                this.connection.Open();
                this.reader = cmd.ExecuteReader();
                while (this.reader.Read())
                {
                    var a = new Article
                                    {
                                        ID = Convert.ToInt32(this.reader["ID"]),
                                        Title = Convert.ToString(this.reader["Title"]),
                                        Body = Convert.ToString(this.reader["Bodyy"]),
                                        Date = Convert.ToDateTime(this.reader["Releasedate"])
                                    };
                    articles.Add(a);

                }
            }
            catch (OracleException e)
            {
                Debug.WriteLine(e);
            }
            finally
            {
               this.connection.Close();
            }
            return articles;
        }
    }
}
