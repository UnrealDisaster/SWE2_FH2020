using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class Picture
    {
        private int id;
        private Photographer photographer;
        private Exif exif;
        private Iptc iptc;
        private string directory;

        public Picture(int newId, Photographer newPhotographer, Exif newExIf, Iptc newIptc, string newDirectory)
        {
            this.id = newId;
            this.photographer = newPhotographer;
            this.exif = newExIf;
            this.iptc = newIptc;
            this.directory = newDirectory;
        }
        public Picture()
        {

        }
        public int getId()
        {
            return id;
        }
        public void setId(int newId)
        {
            id = newId;
        }
        public Photographer getPhotographer()
        {
            return photographer;
        }
        public void setPhotographer(Photographer newPhotographer)
        {
            photographer = newPhotographer;
        }
        public Exif getExif()
        {
            return exif;
        }
        public void setExif(Exif newExif)
        {
            exif = newExif;
        }
        public Iptc getIptc()
        {
            return iptc;
        }
        public void setIptc(Iptc newIptc)
        {
            iptc = newIptc;
        }
        public string getDirectory()
        {
            return directory;
        }
        public void setDirectory(string newDirectory)
        {
            directory = newDirectory;
        }
    }
}
