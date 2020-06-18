using System;
using System.Collections.Generic;
using System.Text;

namespace SWE2_FH2020
{
    public class Picture
    {
        private int id;
        private int photographerId;
        private Exif exif;
        private Iptc iptc;
        private string directory;

        public Picture(int newId, int newPhotographerId, Exif newExIf, Iptc newIptc, string newDirectory)
        {
            this.id = newId;
            this.photographerId = newPhotographerId;
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

        public int getPhotographerId()
        {
            return photographerId;
        }
        public void setPhotographerId(int newphotographerId)
        {
            photographerId = newphotographerId;
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
