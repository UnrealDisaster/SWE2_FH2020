using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;
using System.Configuration;

namespace SWE2_FH2020
{
    public class DALFactory
    {
        public static IDAL getDAL()
        {
            string mode = ConfigurationManager.AppSettings.Get("testDB");
            if (mode.Equals("1"))
            {
                return new DALMock();
            }
            else
            {
                return DBConnection.Instance;
            }
        }
    }
}
