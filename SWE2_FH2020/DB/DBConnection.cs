using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SWE2_FH2020.DB
{
    public sealed class DBConnection
    {
        DBConnection()
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

        public int DBConnectidasdasdasd()
        {
            Console.WriteLine("WTF");
            return 5;
        }

    }
}
