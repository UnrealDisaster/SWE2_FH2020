using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class DALMock : IDAL
    {
        public List<Photographer> getPhotographers()
        {
            List<Photographer> test = new List<Photographer>();

            for (int i = 0; i < 3;i++)
            {
                Photographer temp = new Photographer();
                temp.setDate(new DateTime(2012,i,12,0,0,0));
                temp.setVorname("Marius");
                temp.setNachname("Hochwald");
                temp.setNotiz("Das ist eine Notiz");
                test.Add(temp);
            }
            return test;
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
            List<Photographer> test = new List<Photographer>();
            Photographer temp = new Photographer();
            temp.setDate(new DateTime(2012, 1, 12, 0, 0, 0));
            temp.setVorname("Marius");
            temp.setNachname("Hochwald");
            temp.setNotiz("Das ist eine Notiz");
            test.Add(temp);
            test.Add(newPhotographer);
        }
        public Picture getPicture(int ID)
        {
            Picture test = new Picture();
            test.setDirectory("test.png");
            test.getExif().setFlash(true);
            test.getExif().setDateTime(new DateTime(2012, 1, 12, 0, 0, 0));
            test.getExif().setExposureTime("1/10 sec");
            test.getExif().setId(1);
            test.getExif().setIsoSpeedRating(200);
            test.getExif().setMake("Nikon");
            test.getIptc().setId(1);
            test.getIptc().setByLine("Marius Hochwald");
            test.getIptc().setCopyright("Hochwald Copyright GmbH");
            test.getIptc().setDate(new DateTime(2012, 1, 12, 0, 0, 0));
            test.getIptc().setTime(new TimeSpan(0, 2, 3, 4, 5));
            test.getPhotographer().setDate(new DateTime(1999, 4, 8, 0, 0, 0));
            test.getPhotographer().setId(1);
            test.getPhotographer().setNachname("Hochwald");
            test.getPhotographer().setVorname("Marius");
            test.getPhotographer().setNotiz("Das ist eine Notiz");
            test.setId(ID);
            test.setDirectory("test.png");
            return test;
        }

        public List<Picture> getPictures()
        {
            List<Picture> temp = new List<Picture>();
            for (int i = 0; i < 3; i++)
            {
                Picture test = new Picture();
                test.setDirectory("test.png");
                test.getExif().setFlash(true);
                test.getExif().setDateTime(new DateTime(2012, 1, 12, 0, 0, 0));
                test.getExif().setExposureTime("1/10 sec");
                test.getExif().setId(i);
                test.getExif().setIsoSpeedRating(200);
                test.getExif().setMake("Nikon");
                test.getIptc().setId(i);
                test.getIptc().setByLine("Marius Hochwald");
                test.getIptc().setCopyright("Hochwald Copyright GmbH");
                test.getIptc().setDate(new DateTime(2012, 1, 12, 0, 0, 0));
                test.getIptc().setTime(new TimeSpan(0, 2, 3, 4, 5));
                test.getPhotographer().setDate(new DateTime(1999, 4, 8, 0, 0, 0));
                test.getPhotographer().setId(i);
                test.getPhotographer().setNachname("Hochwald");
                test.getPhotographer().setVorname("Marius");
                test.getPhotographer().setNotiz("Das ist eine Notiz");
                test.setId(i);
                test.setDirectory("test.png");
                temp.Add(test);
            }
            return temp;
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
        public void setupPictures(List<Picture> p)
        {
            throw new NotImplementedException();
        }
        public void editPhotographer(Photographer photogr)
        {
            throw new NotImplementedException();
        }
    }
}
