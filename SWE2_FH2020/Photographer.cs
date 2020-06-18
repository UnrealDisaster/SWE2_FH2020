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

        public Photographer randomPhotographer() {
            var rand = new Random();
            var p = new Photographer();

            string[] vornamen = new string[5]{ "Liam", "Noah", "William", "James", "Oliver" };
            string[] nachnamen = { "Smith", "Johnson", "Williams", "Brown", "Jones" };
            DateTime date = new DateTime(1980, rand.Next() % 13, rand.Next() % 30);
            p.setDate(date);
            p.setVorname(vornamen[(rand.Next())%(vornamen.Length)]);
            p.setNachname(nachnamen[(rand.Next()) % (nachnamen.Length)]);
            p.setNotiz("das ist eine Notiz");
            return p;
        }

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
