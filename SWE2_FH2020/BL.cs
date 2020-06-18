using System;
using System.Collections.Generic;
using System.Text;
using IronPdf;

namespace SWE2_FH2020
{
    public class BL
    {
        // Business Layer
        private IDAL _dal;

        public BL()
        {
            //Bekommt von der DALFactory den DAL zurück
            _dal = DALFactory.getDAL();
        }

        public IEnumerable<string> photographerList()
        {
            // gibt ein IEnumerable vom Typ string mit Vor- und Nachnamen zurück
            return _dal.photographerList();
        }

        public void delPhotographer(string name)
        {
            // löscht den Fotografen anhand dessen Vor- und Nachnamen
            _dal.deletePhotographer(name);
        }

        public void addPhotographer(Photographer newPhotographer)
        {
            // fügt einen Fotografen der DB hinzu
            _dal.addPhotographer(newPhotographer);
        }
        public List<Picture> getPictureList()
        {
            // returned eine Liste von Pictures
            return _dal.getPictures();
        }
        public List<Photographer> getPhotographers()
        {
            //bekommt eine Liste von Fotografen
            return _dal.getPhotographers();
        }
        public void setupPicturesData(List<Picture> pic)
        {
            // trägt die Liste von Bildern in die DB hinzu
            _dal.setupPictures(pic);
        }
        public Picture getPictureInfo(int id)
        {
            // Anhand der ID werden die Bilderinformationen returned
            return _dal.getPicture(id);
        }
        public void savePictureData(Picture p)
        {
            // Daten eines Bildes werden in der DB geändert
            _dal.savePicture(p);
        }
        public void editPhotographData(Photographer ph)
        {
            //Daten eines Fotografen werden in der DB geändert
            _dal.editPhotographer(ph);
        }
        public void printReport(Picture p)
        {
            //setzt das Verzeichnis der Bilder und der Berichte
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string pathReport = startupPath + "../../../../reports/";
            string pathPicture = startupPath + "../../../../res/";

            // holt sich Namen des Files und schneidet das .png/.jpg etc. raus
            string pic = p.getDirectory();
            string name = pic.Split('.')[0];

            // neue Instanz von HtmlToPdf wird erstellt
            // und dem String werden HTML Elemente mit den Bilderdaten hinzugefügt
            var htmlToPdf = new HtmlToPdf();
            var html = @"<h1>" + name + "</h1><br>";
            html += "<p>Iso Speed Ratings: " + p.getExif().getIsoSpeedRating() + "</p>";
            html += "<p>Make: " + p.getExif().getMake() + "</p>";
            html += "<p>Date Time: " + p.getExif().getDateTime() + "</p>";
            html += "<p>Flash: " + p.getExif().getFlash() + "</p>";
            html += "<p>Exposure Time: " + p.getExif().getExposureTime() + "</p>";

            html += "<p>Date created: " + p.getIptc().getDate() + "</p>";
            html += "<p>Time created: " + p.getIptc().getTime() + "</p>";
            html += "<p>By-Line: " + p.getIptc().getByLine() + "</p>";
            html += "<p>Copyright: " + p.getIptc().getCopyright() + "</p>";
            
            html += "<img src='" + pathPicture + pic + "'>";
            Photographer ph = _dal.getPhotographerById(p.getPhotographerId());
            html += "<p>Fotograf: " + ph.getVorname() + " " + ph.getNachname() + "</p>";

            // HTML zu PDF
            var pdf = htmlToPdf.RenderHtmlAsPdf(html);
            // Speichert das PDF
            pdf.SaveAs(pathReport + name + ".Pdf");
        }
        public void newDB()
        {
            // löscht alle Tables und erstellt diese wieder und fügt Fotografen Einträge ein
            _dal.dropRecreateTables();
        }
        public void setPhotographerToPic(int id, string name)
        {
            // setzt beim Bild die FotografenID
            _dal.setPhotographerToPicture(id, name);
        }
        public string getNamebyPic(int id)
        {
            // returned Fotografennamen anhand der BildID
            return _dal.getPhotographerWithPicture(id);
        }
    }
}
