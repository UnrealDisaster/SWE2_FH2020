using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace SWE2_FH2020
{
    public interface IDAL
    {
        public NpgsqlConnection initialize();
        List<Picture> getPictures();
        List<Photographer> getPhotographers();
        IEnumerable<string> photographerList();
        void deletePhotographer(string name);
        void addPhotographer(Photographer newPhotographer);
        Picture getPicture(int ID);
        void savePicture(Picture p);
        void setupPictures(List<Picture> pic);
        void editPhotographer(Photographer photogr);

    }
}
