using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Collections;

namespace SWE2_FH2020.DB
{
    public sealed class DBConnection
    {
        //Singleton pattern for db connection, so only one connection is established
        private DBConnection()
        {
        }
        private static readonly object padlock = new object();
        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DBConnection();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<string> GetFotografinnen() {


            string connstring = "Server=127.0.0.1; Port=5432; User ID=postgres; Password=postgres;Database=postgres;";
            NpgsqlConnection db = new NpgsqlConnection(connstring);
            db.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from fotograf ", db);


            try
            {
                cmd.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            NpgsqlDataReader reader = cmd.ExecuteReader();

            var vnt = new List<string>();

            while (reader.Read())
            {
                string vorname = reader.GetString(1);
                string nachname = reader.GetString(2);
                DateTime itsTime = reader.GetDateTime(3);
                vnt.Add(vorname +" " + nachname + " " + itsTime);
                Console.WriteLine(vorname + nachname + itsTime);
            }
            cmd.Dispose();
            reader.Close();
            db.Close();
            return vnt;
        }

        public void DBConnecting()
        {
            // Example for new db functions
            // Example to call singleton function
            // DBConnection.Instance.DBConnecting();
            string connstring = "Server=127.0.0.1; Port=5432; User ID=postgres; Password=postgres;Database=postgres;";
            NpgsqlConnection db = new NpgsqlConnection(connstring);
            db.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("Select * from fotograf ", db);
            //cmd.
            try
            {
                cmd.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }

            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DateTime itsTime = reader.GetDateTime(3);
                int test = reader.GetInt32(0);
                Console.WriteLine(test.ToString(), itsTime);
            }
            cmd.Dispose();
            reader.Close();
            db.Close();
            //return db;
        }

    }
}
