using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace SWE2_FH2020
{
    class FotografInnenViewModel:ViewModel
    {
        private IEnumerable<Photographer> _Photographers = null;
        public IEnumerable<Photographer> Photographers {
            get {
                if (_Photographers == null)
                    _Photographers = DBConnection.Instance.getPhotographers();
                return _Photographers;
            }
        }
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

        private string _vorname ="";
        public string Vorname {
            get {
                return _vorname;
            }
            set {
                _vorname = value;
                OnPropertyChanged("Validity");
            }
        }
        private string _nachname = "";
        public string Nachname {
            get {
                return _nachname;
            }
            set {
                _nachname = value;
                OnPropertyChanged("Validity");
            }
        }
        private DateTime _geburtsdatum = DateTime.Now;
        public DateTime Geburtsdatum {
            get {
                return _geburtsdatum;
            }
            set {
                _geburtsdatum = value;
                OnPropertyChanged("Validity");
            }
        }
        private string _notiz = "";
        public string Notiz {
            get {
                return _notiz;
            }
            set {
                _notiz = value;
                OnPropertyChanged("Validity");
            }
        }
        public bool Validity{
            get {
                return this.IsInputValid();
            }
        }
        public bool IsInputValid() {
            string regExAllowed = "^[a-zA-Z ]+$";
            if (Regex.IsMatch(Vorname, regExAllowed) && Regex.IsMatch(Nachname, regExAllowed) && Regex.IsMatch(Notiz, regExAllowed) && DateTime.Now > Geburtsdatum)
            {
                return true;
            }
            return false;
        }

        public void AddPhotographer(){
            var p = new Photographer();
            p.setDate(Geburtsdatum);
            p.setVorname(Vorname);
            p.setNachname(Nachname);
            p.setNotiz(Notiz);

            BL test = new BL();
            test.addPhotographer(p);
            OnPropertyChanged("Names");
        }

    }
}