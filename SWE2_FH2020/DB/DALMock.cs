using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class DALMock : IDAL
    {
        public void delete(Picture p)
        {
            throw new NotImplementedException();
        }

        public List<Photographer> getPhotographers()
        {
            throw new NotImplementedException();
        }

        public void deletePhotographer(string name)
        {
            List<string> names = new List<string>() { "Marius Hochwald", "Daniel Krottendorfer", "Barack Obama" };
            foreach(string i in names)
            {
                if(i == name)
                {
                    names.Remove(i);
                }
            }
        }
        public void addPhotographer(Photographer newPhotographer)
        {
            throw new NotImplementedException();
        }
        public Picture getPicture(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Picture> getPictures()
        {
            throw new NotImplementedException();
        }

        public NpgsqlConnection initialize()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> photographerList()
        {
            List<string> names = new List<string>() { "Marius Hochwald", "Daniel Krottendorfer", "Barack Obama" };
            IEnumerable<string> test = names;
            return test;
        }

        public void savePicture(Picture p)
        {
            throw new NotImplementedException();
        }
        public List<Iptc> getIptcData()
        {
            throw new NotImplementedException();
        }
        public List<Exif> getExifData()
        {
            throw new NotImplementedException();
        }
    }
}
