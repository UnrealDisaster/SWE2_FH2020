using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace SWE2_FH2020
{
    public class Iptc
    {
        private int id;
        private DateTime date;
        private TimeSpan time;
        private string byLine;
        private string copyright;

        public static Iptc randomIptc()
        {
            var rand = new Random();
            var e = new Iptc();

            int y = 1980;
            int m = (rand.Next() % 12) + 1;
            int d = (rand.Next() % 27) + 1;

            DateTime date = new DateTime(y, m, d);
            e.setDate(date);

            TimeSpan ts = new TimeSpan(rand.Next() % 24, rand.Next() % 60, rand.Next() % 60);
            e.setTime(ts);


            string[] vornamen = new string[5] { "Liam", "Noah", "William", "James", "Oliver" };
            string[] nachnamen = { "Smith", "Johnson", "Williams", "Brown", "Jones" };
            string a = vornamen[(rand.Next()) % (vornamen.Length)];
            string b = nachnamen[(rand.Next()) % (nachnamen.Length)];

            e.setByLine(a + " " + b);
            e.setCopyright(b + " Co.");

            return e;
        }
        public int getId()
        {
            return id;
        }
        public void setId(int newId)
        {
            this.id = newId;
        }

        public DateTime getDate()
        {
            return date;
        }
        public void setDate(DateTime newDate)
        {
            this.date = newDate;
        }

        public TimeSpan getTime()
        {
            return time;
        }
        public void setTime(TimeSpan newTime)
        {
            this.time = newTime;
        }

        public string getByLine()
        {
            return byLine;
        }
        public void setByLine(string newByLine)
        {
            this.byLine = newByLine;
        }

        public string getCopyright()
        {
            return copyright;
        }
        public void setCopyright(string newCopyright)
        {
            this.copyright = newCopyright;
        }
    }
}
