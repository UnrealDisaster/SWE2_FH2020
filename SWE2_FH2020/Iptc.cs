using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class Iptc
    {
        private int id;
        private DateTime date;
        private TimeSpan time;
        private string byLine;
        private string copyright;

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
