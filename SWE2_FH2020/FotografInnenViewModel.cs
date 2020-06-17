using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SWE2_FH2020
{
    class FotografInnenViewModel:ViewModel
    {
        public IEnumerable<string> Names {
            get {
                BL test = new BL();
                return test.photographerList();
                //return DBConnection.Instance.photographerList();
            }
        }
        public void FotografGeloescht()
        {
            OnPropertyChanged("Names");
        }
    }
}
