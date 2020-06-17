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
                OnPropertyChanged("IsInputValid");
            }
        }
        private string _nachname = "";
        public string Nachname {
            get {
                return _nachname;
            }
            set {
                _nachname = value;
                OnPropertyChanged("IsInputValid");
            }
        }
        private DateTime _geburtsdatum = DateTime.Now;
        public DateTime Geburtsdatum {
            get {
                return _geburtsdatum;
            }
            set {
                _geburtsdatum = value;
                OnPropertyChanged("IsInputValid");
            }
        }
        private string _notiz = "";
        public string Notiz {
            get {
                return _notiz;
            }
            set {
                _notiz = value;
                OnPropertyChanged("IsInputValid");
            }
        }
        public bool IsInputValid {
            get {
                string regExAllowed = "^([a-zA-Z])";
                if (Regex.IsMatch(Vorname, regExAllowed) && Regex.IsMatch(Nachname, regExAllowed) && Regex.IsMatch(Notiz, regExAllowed) && DateTime.Now > _geburtsdatum)
                {
                    return true;
                }
                return false;
            }
        }

        public void AddUser(){
            Console.WriteLine("Stuff");
        }

    }
}