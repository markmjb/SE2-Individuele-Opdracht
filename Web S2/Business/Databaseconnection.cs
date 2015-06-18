// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Databaseconnection.cs" company="Software">
//   Mark B ©
// </copyright>
// <summary>
//   The databaseconnection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Business
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Oracle.DataAccess.Client;

    /// <summary>
    /// The connection.
    /// </summary>
    public class Databaseconnection
    {
    // The oracle connection used throughout the whole dbconnection.

        /// <summary>
        /// The connection.
        /// </summary>
        private readonly OracleConnection connection;
        
        /// <summary>
        /// The reader.
        /// </summary>
        private OracleDataReader reader;

        /// <summary>
        /// The either true or false that you return.
        /// </summary>
        private bool returnbool;

        /// <summary>
        /// Initializes a new instance of the <see cref="Databaseconnection"/> class.
        /// </summary>
        public Databaseconnection()
        {
            this.connection = new OracleConnection
                                  {
                                      ConnectionString =
                                          "User Id=mark;Password=mark;Data Source=localhost/xe;"
                                  };

            // Connection string for Athena Oracle Database (Backup)
            // this.connection.ConnectionString = "User Id=dbi304910;Password=drlc3PnAnP;Data Source=//192.168.15.50:1521/fhictora;";
            // Connection string for Local Oracle Database
        }

        /// <summary>
        /// Checks if login is good.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="passw">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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

        /// <summary>
        /// The check register.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
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

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
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

        /// <summary>
        /// The update pass.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="passw">
        /// The password.
        /// </param>
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

        /// <summary>
        /// The get articles.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
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