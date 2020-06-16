using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class Photographer
    {
        private int id;
        private string vorname;
        private string nachname;
        private DateTime date;
        private string notiz;

        public int getId()
        {
            return id;
        }
        public void setId(int newId)
        {
            this.id = newId;
        }
        public string getVorname()
        {
            return vorname;
        }
        public void setVorname(string newVorname)
        {
            this.vorname = newVorname;
        }
        public string getNachname()
        {
            return nachname;
        }
        public void setNachname(string newNachname)
        {
            this.nachname = newNachname;
        }
        public DateTime getDate()
        {
            return date;
        }
        public void setDate(DateTime newDate)
        {
            this.date = newDate;
        }
        public string getNotiz()
        {
            return notiz;
        }
        public void setNotiz(string newNotiz)
        {
            this.notiz = newNotiz;
        }
    }
}
