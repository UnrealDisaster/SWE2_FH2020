using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace SWE2_FH2020
{
    public class DALFactory
    {
        private static bool useMock = false;
        public static void setMock()
        {
            useMock = true;
        }
        public static IDAL getDAL()
        {
            if (useMock)
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
