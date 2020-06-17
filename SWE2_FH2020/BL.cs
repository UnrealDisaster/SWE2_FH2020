﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class BL
    {
        private IDAL _dal;

        public BL()
        {
            _dal = DALFactory.getDAL();
        }

        public IEnumerable<string> photographerList()
        {
            return _dal.photographerList();
        }
    }
}
