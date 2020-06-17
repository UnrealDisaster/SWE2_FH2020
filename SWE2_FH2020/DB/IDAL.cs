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
        List<Exif> getExifData();
        List<Iptc> getIptcData();
        void savePicture(Picture p);
        void delete(Picture p);

    }
}
