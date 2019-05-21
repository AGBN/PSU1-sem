using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTL.Controllers;
using GTL.Models;
using GTL.UnitTests.MockClasses.MockControllers;
using Newtonsoft.Json;

namespace GTL.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow(123, "Mogens", "Pedersen", "+4567982409", "Student", true)]
        [TestMethod]
        public void CreateMember(int SSN, string FirstName, string LastName, string MobilePhoneNr, string MemberType, bool IsActive)
        {
            //Arrange
            Factories.FactoryController.Instance = new MockFactoryController();
            Factories.FactoryDataAccess.Instance = new MockFactoryDataAccess();

            MockLibraryCardController LibraryCardController = (MockLibraryCardController)Factories.FactoryController.Instance.Create("libraryCard");

                // Creates an instance of a controller, WITHOUT using the singleton factory, thus NOT creating a Mock Factory.
            MemberController memberController = (MemberController)new Factories.FactoryController().Create("Member");

            Address homeAddress = new Address();
            Address campusAddress = new Address();
            MemberType membertype = new MemberType();
            DateTime dateCreated = DateTime.UtcNow;

            Member expected = FactoryModels.CreateMember(SSN, FirstName, LastName, MobilePhoneNr, campusAddress, homeAddress, membertype, dateCreated);
            expected.LibraryCards.Add(LibraryCardController.Create());
            expected.IsActive = IsActive;

            //Act

            Member actual = memberController.Create(SSN, FirstName, LastName, MobilePhoneNr, campusAddress, homeAddress, membertype);

            actual.DateCreated = dateCreated;

                //This is done, because Assert.AreEqual does not work on different instances of objects.
            string expectedJSON = JsonConvert.SerializeObject(expected);
            string actualJSON = JsonConvert.SerializeObject(actual);

            //Assert

            Assert.AreEqual(expectedJSON, actualJSON);

        }
    }
}
