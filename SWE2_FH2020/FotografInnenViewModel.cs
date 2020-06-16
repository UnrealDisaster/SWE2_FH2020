using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    class FotografInnenViewModel
    {
        public IEnumerable<string> Names {
            get {
                var i = DB.DBConnection.Instance;
                return i.GetFotografinnen();
            }
        }
    }
}
