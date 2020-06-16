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
