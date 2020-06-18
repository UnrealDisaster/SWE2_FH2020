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
            // Überprüft anhand des Config files, ob die DALFactory die MockDB oder die echte DB zurück gibt
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
