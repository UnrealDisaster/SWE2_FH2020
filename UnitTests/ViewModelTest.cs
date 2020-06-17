using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWE2_FH2020;
using System;
using System.Text;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void Input_Valid_test()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = true;
            test.Vorname = "Marius";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = new DateTime(2018,2,2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }
        [TestMethod]
        public void Input_Valid_DoubleName_test()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = true;
            test.Vorname = "Marius Hochwald";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = new DateTime(2018, 2, 2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }
        
        [TestMethod]
        public void Invalid_TripleName_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = false;
            test.Vorname = "Marius Mario Hochwald";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = new DateTime(2018, 2, 2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }
        
        [TestMethod]
        public void Invalid_FirstName_Characters_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = false;
            test.Vorname = "Marius@!?";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = new DateTime(2018, 2, 2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }

        [TestMethod]
        public void Invalid_FirstName_Length_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = false;
            test.Vorname = "MariusMariusMariusMariusMariusMariusMariusMariusMariusMariusMariusMariusMariusMariusMariusMariusMarius";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = new DateTime(2018, 2, 2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }

        [TestMethod]
        public void Invalid_LastName_Length_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = false;
            test.Vorname = "Marius";
            test.Nachname = "HochwaldHochwaldHochwaldHochwaldHochwaldHochwaldHochwald";
            test.Geburtsdatum = new DateTime(2018, 2, 2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }

        [TestMethod]
        public void Invalid_LastName_Characters_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = false;
            test.Vorname = "Marius";
            test.Nachname = "Hochwald!?@";
            test.Geburtsdatum = new DateTime(2018, 2, 2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }

        [TestMethod]
        public void Invalid_Geburtsdatum_Zukunft_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = false;
            test.Vorname = "Marius";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = new DateTime(2022, 2, 2);
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }

        [TestMethod]
        public void Valid_Geburtsdatum_Today_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = true;
            test.Vorname = "Marius";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = DateTime.Today;
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }

        [TestMethod]
        public void Valid_Firstname_SpecialCharacter_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = true;
            test.Vorname = "MariuÖÄüäßs";
            test.Nachname = "Hochwald";
            test.Geburtsdatum = DateTime.Today;
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }

        [TestMethod]
        public void Valid_LastName_SpecialCharacter_PhotographersList()
        {
            //Arrange
            FotografInnenViewModel test = new FotografInnenViewModel();
            bool expected = true;
            test.Vorname = "Marius";
            test.Nachname = "HochwaldäöüÄÜÖß";
            test.Geburtsdatum = DateTime.Today;
            test.Notiz = "Ich bin eine Testnotiz.";

            //Act
            bool actual = test.IsInputValid();

            // Assert
            Assert.AreEqual(expected, actual, "No valid Input for new photographer");
        }
    }
}
