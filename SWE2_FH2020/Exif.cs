using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class Exif
    {
        private int id;
        private int isoSpeedRating;
        private string make;
        private DateTime dateTime;
        private bool flash;
        private string exposureTime;

        public static Exif randomExif()
        {
            var rand = new Random();
            var e = new Exif();

            e.setIsoSpeedRating(rand.Next() % 800);

            if (rand.Next() % 2 > 0)
                e.setMake("Canon");
            else
                e.setMake("Nikon");

            if (rand.Next() % 2 > 0)
                e.setFlash(true);
            else
                e.setFlash(false);

            e.setExposureTime("1/"+rand.Next() % 100+" sec");

            int y = 1980;
            int m = (rand.Next() % 12)+1;
            int d = (rand.Next() % 27)+1;

            DateTime date = new DateTime(y,m,d);
            e.setDateTime(date);

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
        public int getIsoSpeedRating()
        {
            return isoSpeedRating;
        }
        public void setIsoSpeedRating(int newIso)
        {
            this.isoSpeedRating = newIso;
        }
        public string getMake()
        {
            return make;
        }
        public void setMake(string newMake)
        {
            this.make = newMake;
        }
        public DateTime getDateTime()
        {
            return dateTime;
        }
        public void setDateTime(DateTime newdateTime)
        {
            this.dateTime = newdateTime;
        }
        public bool getFlash()
        {
            return flash;
        }
        public void setFlash(bool newFlash)
        {
            this.flash = newFlash;
        }
        public string getExposureTime()
        {
            return exposureTime;
        }
        public void setExposureTime(string newExposureTime)
        {
            this.exposureTime = newExposureTime;
        }
    }
}
