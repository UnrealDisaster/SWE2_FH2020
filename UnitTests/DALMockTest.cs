using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWE2_FH2020;
using System;
using System.Text;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class DALMockTest
    {
        [TestMethod]
        public void Get_Complete_PhotographersList()
        {
            //Arrange
            DALMock test = new DALMock();
            string expected = "Hochwald";

            //Act
            string actual = test.getPhotographers()[0].getNachname();

            // Assert
            Assert.AreEqual(expected, actual, "Wrong Name");
        }
        
        [TestMethod]
        public void Get_Complete_PhotographersList_String()
        {
            //Arrang
            DALMock test = new DALMock();
            string expected = "Barack Obama";
            string actual = "test";

            //Act
            IEnumerable<string> tester = test.photographerList();

            foreach(var item in tester)
            {
                actual = item;
            }
            
            // Assert
            Assert.AreEqual(expected, actual, "Wrong Name");
        }

        [TestMethod]
        public void delete_Photographer_from_List()
        {
            //Arrange
            DALMock test = new DALMock();
            string tester = "Marius Hochwald";
            string expected = "Daniel Krottendorfer";

            //Act
            test.deletePhotographer(tester);

            // Assert
            Assert.AreEqual(expected, test.getString(), "Wrong Name");
        }

        [TestMethod]
        public void add_Photographer_test()
        {
            //Arrange
            DALMock test = new DALMock();
            Photographer temp = new Photographer();
            temp.setDate(new DateTime(1999, 4, 8, 0, 0, 0));
            temp.setId(1);
            temp.setNachname("Krottendorfer");
            temp.setVorname("Daniel");
            temp.setNotiz("Das ist eine Notiz");
            string expected = "Krottendorfer";

            //Act
            test.addPhotographer(temp);

            // Assert
            Assert.AreEqual(expected, test.getAddedPhotograph(), "Wrong Name");
        }

        [TestMethod]
        public void edit_Photographer_test()
        {
            //Arrange
            DALMock test = new DALMock();
            Photographer temp = new Photographer();
            string expected = "Krottendorfer";
            temp.setVorname("Daniel");
            temp.setNachname("Krottendorfer");

            //Act
            test.editPhotographer(temp);

            // Assert
            Assert.AreEqual(expected, test.geteditPhotographer(), "Wrong Name");
        }

        [TestMethod]
        public void get_Picture_test()
        {
            //Arrange
            DALMock test = new DALMock();
            Picture temp = new Picture();
            string expected = "test.png";
            int ter = 1;

            //Act
            temp = test.getPicture(ter);
            string actual = temp.getDirectory();

            // Assert
            Assert.AreEqual(expected, actual, "Wrong Name");
        }

        [TestMethod]
        public void get_Pictures_test()
        {
            //Arrange
            DALMock test = new DALMock();
            List<Picture> temp = new List<Picture>();
            string expected = "test.png";

            //Act
            temp = test.getPictures();
            string actual = temp[0].getDirectory();

            // Assert
            Assert.AreEqual(expected, actual, "Wrong Name");
        }

        [TestMethod]
        public void save_Picture_test()
        {
            //Arrange
            DALMock test = new DALMock();
            Picture temp = new Picture();
            string expected = "test.png";
            temp.setId(1);
            temp.setDirectory("test.png");

            //Act
            test.savePicture(temp);
            string actual = test.geteditPicture();

            // Assert
            Assert.AreEqual(expected, actual, "Wrong Name");
        }

        [TestMethod]
        public void setup_Picture_test()
        {
            //Arrange
            DALMock test = new DALMock();
            List<Picture> temp = new List<Picture>();
            for(int i = 0; i < 3; i++)
            {
                Picture t = new Picture();
                t.setId(i);
                if(i == 2)
                {
                    t.setDirectory("new.png");
                }
                else
                {
                    t.setDirectory("test.png");
                }

                temp.Add(t);
            }
            string expected = ("new.png");

            //Act
            test.setupPictures(temp);
            string actual = test.getSetupPicDirectoryString();

            // Assert
            Assert.AreEqual(expected, actual, "Wrong Name");
        }
    }
}
