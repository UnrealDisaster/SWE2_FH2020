using System;
using System.Collections.Generic;
using System.Text;
using IronPdf;

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
        public void printReport(Picture p)
        {
            Console.WriteLine("Printing .........................");
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string pathReport = startupPath + "../../../../reports/";
            string pathPicture = startupPath + "../../../../res/";

            string pic = p.getDirectory();
            string name = pic.Split('.')[0];

            var htmlToPdf = new HtmlToPdf();  // new instance of HtmlToPdf
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

            html += "<p>Fotograf: " + p.getPhotographer().getVorname() + " " + p.getPhotographer().getNachname() + "</p>";

            // turn html to pdf
            var pdf = htmlToPdf.RenderHtmlAsPdf(html);
            // save resulting pdf into file
            pdf.SaveAs(pathReport + name + ".Pdf");
        }
        public void newDB()
        {
            _dal.dropRecreateTables();
        }
    }
}
