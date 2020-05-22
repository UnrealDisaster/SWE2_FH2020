using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    class SearchViewModel:ViewModel
    {
        string searchWord = "";
        public string Text {
            set {
                searchWord = value;
                OnPropertyChanged("searchWordChanged");
            }
            get {
                return searchWord;
            }
        }

    }
}
