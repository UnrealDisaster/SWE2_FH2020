using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class BL
    {
        private IDAL _dal;

        public BL()
        {
            _dal = DALFactory.getDAL();
        }

        public IEnumerable<string> photographerList()
        {
            return _dal.photographerList();
        }

        public void delPhotographer(string name)
        {
            _dal.deletePhotographer(name);
        }

        public void addPhotographer(Photographer newPhotographer)
        {
            _dal.addPhotographer(newPhotographer);
        }
        public List<Picture> getPictureList()
        {
            return _dal.getPictures();
        }
        public List<Photographer> getPhotographers()
        {
            return _dal.getPhotographers();
        }
        public void setupPicturesData(List<Picture> pic)
        {
            _dal.setupPictures(pic);
        }
        public Picture getPictureInfo(int id)
        {
            return _dal.getPicture(id);
        }
        public void savePictureData(Picture p)
        {
            _dal.savePicture(p);
        }
        public void editPhotographData(Photographer ph)
        {
            _dal.editPhotographer(ph);
        }
    }
}
