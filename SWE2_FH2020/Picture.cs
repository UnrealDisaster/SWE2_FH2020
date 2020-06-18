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

        public static Picture randomPicture(string newDirectory,int exifid, int iptcid)
        {
            var p = new Picture();
            p.exif = Exif.randomExif();
            p.getExif().setId(exifid);
            p.iptc = Iptc.randomIptc();
            p.getIptc().setId(iptcid);
            p.directory = newDirectory;

            return p;
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

        public Photographer PhotographerData {
            get {
                return photographer;
            }
            set {
                photographer = value;
            }
        }

        public Photographer getPhotographer()
        {
            return photographer;
        }
        public void setPhotographer(Photographer newPhotographer)
        {
            photographer = newPhotographer;
        }

        public Exif ExifData {
            get {
                return exif;
            }
            set {
                exif = value;
            }
        }
        public Exif getExif()
        {
            return exif;
        }
        public void setExif(Exif newExif)
        {
            exif = newExif;
        }

        public Iptc IptcData {
            get {
                return iptc;
            }
            set {
                iptc = value;
            }
        }

        public Iptc getIptc()
        {
            return iptc;
        }
        public void setIptc(Iptc newIptc)
        {
            iptc = newIptc;
        }

        public string Directory {
            get {
                return directory;
            }
            set {
                directory = value;
            }
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
