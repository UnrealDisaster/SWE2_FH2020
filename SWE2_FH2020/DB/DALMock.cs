using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class DALMock : IDAL
    {
        private List<string> delPhotographer = new List<string>() { "Marius Hochwald", "Daniel Krottendorfer", "Barack Obama" };
        private List<Photographer> addPhoto = new List<Photographer>();
        private Photographer editPhoto = new Photographer();
        private Picture getPictureNow = new Picture();
        private Picture editPicture = new Picture();
        private List<Picture> setupPictureTest = new List<Picture>();
        private Photographer photographerById = new Photographer();


        public List<Photographer> getPhotographers()
        {
            List<Photographer> test = new List<Photographer>();

            for (int i = 0; i < 3;i++)
            {
                Photographer temp = new Photographer();
                temp.setDate(new DateTime(2012,2,12,0,0,0));
                temp.setVorname("Marius");
                temp.setNachname("Hochwald");
                temp.setNotiz("Das ist eine Notiz");
                test.Add(temp);
            }
            return test;
        }

        public void deletePhotographer(string name)
        {
            List<string> test = getList();
            int temp = 0;
            foreach (string ar in test)
            {
                if(ar == name)
                {
                    temp = test.IndexOf(ar);
                }
            }
            test.RemoveAt(temp);
            setList(test);
        }
        public void addPhotographer(Photographer temp)
        {
            addPhoto.Add(temp);
        }
        public Picture getPicture(int ID)
        {
            getPictureNow.setId(ID);
            getPictureNow.setDirectory("test.png");
            return getPictureNow;
        }

        public List<Picture> getPictures()
        {
            List<Picture> temp = new List<Picture>();
            for (int i = 0; i < 3; i++)
            {
                Picture test = new Picture();
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
            editPicture.setId(2);
            editPicture.setDirectory("new.png");

            editPicture.setId(p.getId());
            editPicture.setDirectory(p.getDirectory());
        }
        public void setupPictures(List<Picture> pic)
        {
            setupPictureTest = pic;
        }
        public void editPhotographer(Photographer photogr)
        {
            editPhoto.setVorname("Marius");
            editPhoto.setNachname("Hochwald");

            editPhoto.setVorname(photogr.getVorname());
            editPhoto.setVorname(photogr.getNachname());
        }
        public string getString()
        {
            return delPhotographer[0];
        }
        public List<string> getList()
        {
            return delPhotographer;
        }
        public void setList(List<string> newList)
        {
            delPhotographer = newList;
        }
        public string getAddedPhotograph()
        {
            return addPhoto[0].getNachname();
        }
        public string geteditPhotographer()
        {
            return editPhoto.getVorname();
        }

        public string geteditPicture()
        {
            return editPicture.getDirectory();
        }
        public string getSetupPicDirectoryString()
        {
            return setupPictureTest[2].getDirectory();
        }
        public void dropRecreateTables()
        {
            throw new NotImplementedException();
        }
        public Photographer getPhotographerById(int id)
        {
            photographerById.setVorname("Marius");
            photographerById.setNachname("Hochwald");
            photographerById.setNotiz("BIn eine Notiz");
            return photographerById;
        }
        public void setPhotographerToPicture(int id, string name)
        {
            throw new NotImplementedException();
        }
        public string getPhotographerWithPicture(int id)
        {
            throw new NotImplementedException();
        }
    }
}
