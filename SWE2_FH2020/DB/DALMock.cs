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
            // setzt Dummy Daten in eine Fotografenliste
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
            // löscht den Eintrag in der Liste anhand des Namens, bekommt einen DUmmy Namen
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
            //fügt den DUmmy Fotografen in der Dummy Liste hinzu
            addPhoto.Add(temp);
        }
        public Picture getPicture(int ID)
        {
            // setzt Daten in ein Picture und returned diesen, Test ist teilweise sinnlos
            getPictureNow.setId(ID);
            getPictureNow.setDirectory("test.png");
            return getPictureNow;
        }

        public List<Picture> getPictures()
        {
            List<Picture> temp = new List<Picture>();
            // setzt Dummy Daten in eine Picture Liste und returned diesen
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
            // erstellt eine Dummy Liste von Fotografernamen und returned diesen
            List<string> names = new List<string>() { "Marius Hochwald", "Daniel Krottendorfer", "Barack Obama" };
            IEnumerable<string> test = names;
            return test;
        }

        public void savePicture(Picture p)
        {
            // speichert die Werte in einem Bild
            editPicture.setId(2);
            editPicture.setDirectory("new.png");

            editPicture.setId(p.getId());
            editPicture.setDirectory(p.getDirectory());
        }
        public void setupPictures(List<Picture> pic)
        {
            // setzt die aktuelle Liste mit dem übermittelten Parameter
            setupPictureTest = pic;
        }
        public void editPhotographer(Photographer photogr)
        {
            // setzt Fotografendaten, dient für einen void Unit test
            editPhoto.setVorname("Marius");
            editPhoto.setNachname("Hochwald");

            editPhoto.setVorname(photogr.getVorname());
            editPhoto.setVorname(photogr.getNachname());
        }
        public string getString()
        {
            // returned den ersten Wert einer 
            return delPhotographer[0];
        }
        public List<string> getList()
        {
            // gibt eine Liste zurück
            return delPhotographer;
        }
        public void setList(List<string> newList)
        {
            // setzt eine Liste, dient für einen void Unit test
            delPhotographer = newList;
        }
        public string getAddedPhotograph()
        {
            // gibt den Nachnamen eines Fotografen zurück, dient für einen void Unit test
            return addPhoto[0].getNachname();
        }
        public string geteditPhotographer()
        {
            // gibt den VOrnamen zurück, dient für einen void Unit test
            return editPhoto.getVorname();
        }

        public string geteditPicture()
        {
            // gibt Namen des Pictures zurück
            return editPicture.getDirectory();
        }
        public string getSetupPicDirectoryString()
        {
            // returned den dritten Wert der Directory von einer PictureListe
            return setupPictureTest[2].getDirectory();
        }
        public void dropRecreateTables()
        {
            // wird nicht getestet
            throw new NotImplementedException();
        }
        public Photographer getPhotographerById(int id)
        {
            // setzt FotografenDaten und returned diesen anhand der ID
            photographerById.setVorname("Marius");
            photographerById.setNachname("Hochwald");
            photographerById.setNotiz("BIn eine Notiz");
            return photographerById;
        }
        public void setPhotographerToPicture(int id, string name)
        {
            // wird nicht getestet
            throw new NotImplementedException();
        }
        public string getPhotographerWithPicture(int id)
        {
            // wird nicht getestet
            throw new NotImplementedException();
        }
    }
}
