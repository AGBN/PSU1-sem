using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GTL.Controllers;
using GTL.Models;
using GTL.UnitTests.MockClasses.MockControllers;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GTL.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [DataRow("first", 123, "Mogens", "Pedersen", "+4567982409", "Student", true)]
        [TestMethod]
        public void CreateMember(string testname, int SSN, string FirstName, string LastName, string MobilePhoneNr, string MemberType, bool IsActive)
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
            expected.LibraryCards.Add(LibraryCardController.Create(1, expected));
            expected.IsActive = IsActive;

            //Act

            Member actual = memberController.Create(SSN, FirstName, LastName, MobilePhoneNr, campusAddress, homeAddress, membertype);

            actual.DateCreated = dateCreated;

                //This is done, because Assert.AreEqual does not work on different instances of objects.
            string expectedJSON = JsonConvert.SerializeObject(expected);
            string actualJSON = JsonConvert.SerializeObject(actual);

            //Assert
                //Are equal does not work on reference types, instead Json is used to compare objects.
            Assert.AreEqual(expectedJSON, actualJSON, testname);

        }


        [DataRow("Login - 1", "Magret45", "Horses4Lyfe")]
        [TestMethod]
        public void Login(string testname, string username, string password)
        {
            //Arrange
            Factories.FactoryController.Instance = new MockFactoryController();
            Factories.FactoryDataAccess.Instance = new MockFactoryDataAccess();
            bool result;

                // Creates an instance of a controller, WITHOUT using the singleton factory, thus NOT creating a Mock Factory.
            LibrarianController librarianController = (LibrarianController)new Factories.FactoryController().Create("librarian");

            //Act
            result = librarianController.Login(username, password);

            //Assert
            Assert.IsTrue(result, testname);

        }

        [DataRow("LoginNegative - 1", "Magret456", "HorsesLyfe")]
        [TestMethod]
        public void LoginNegative(string testname, string username, string password)
        {
            //Arrange
            Factories.FactoryController.Instance = new MockFactoryController();
            Factories.FactoryDataAccess.Instance = new MockFactoryDataAccess();
            bool result;

            // Creates an instance of a controller, WITHOUT using the singleton factory, thus NOT creating a Mock Factory.
            LibrarianController librarianController = (LibrarianController)new Factories.FactoryController().Create("librarian");

            //Act
            result = librarianController.Login(username, password);

            //Assert
            Assert.IsFalse(result, testname);

        }


        [DataRow("CreateLoan - 1", 001010001, true, 002020002, "CheckOut", 2, "A song of ice and fire", true)]



        [TestMethod]
        public void CreateLoan(string testname, int MemberSSN, bool isActive, int librarianSSN, string role, int nrOfBooksLoaned, string bookName, bool bookAvailable)
        {
            //Arrange
            Factories.FactoryController.Instance = new MockFactoryController();
            Factories.FactoryDataAccess.Instance = new MockFactoryDataAccess();
            Member member = new Member() { SSN = MemberSSN, IsActive = isActive };
            Librarian librarian = new Librarian() { SSN = librarianSSN, LibrarianRole = role };
            ICollection<Book> booksToBeLoaned = new List<Book>() { new Book() { Available = bookAvailable } };
            Loan actual = null;

            Loan loan = new Loan();

            for (int i = 0; i < nrOfBooksLoaned; i++)
            {
                loan.LoanBooks.Add(new LoanBook() { Book = new Book() });
            }

            member.Loans.Add(loan);


                // Creates an instance of a controller, WITHOUT using the singleton factory, thus NOT creating a Mock Factory.
            LoanController loanController = (LoanController)new Factories.FactoryController().Create("loan");

            //Act
            try
            {
                actual = loanController.Create(member, librarian, booksToBeLoaned);
            }
            catch (Exception e)
            {
            }

            //Assert

            Assert.IsNotNull(actual, testname);

        }

        [DataRow("CreateLoanNegative - 1", 021010001, false, 002020002, "CheckOut", 2, "A song of ice and fire", true)]
        [DataRow("CreateLoanNegative - 2", 001010001, true, 042020002, "Reference", 2, "A song of ice and fire", true)]
        [DataRow("CreateLoanNegative - 3", 001010001, true, 002020002, "CheckOut", 2, "Winnie the pooh", false)]
        [TestMethod]
        public void CreateLoanNegative(string testname, int MemberSSN, bool isActive, int librarianSSN, string role, int nrOfBooksLoaned, string bookName, bool bookAvailable)
        {
            //Arrange
            Factories.FactoryController.Instance = new MockFactoryController();
            Factories.FactoryDataAccess.Instance = new MockFactoryDataAccess();
            Member member = new Member() { SSN = MemberSSN, IsActive = isActive };
            Librarian librarian = new Librarian() { SSN = librarianSSN, LibrarianRole = role };
            ICollection<Book> booksToBeLoaned = new List<Book>() { new Book() { Available = bookAvailable } };
            Loan actual = null;
            bool testSuccess = false;

            Loan loan = new Loan();

            for (int i = 0; i < nrOfBooksLoaned; i++)
            {
                loan.LoanBooks.Add(new LoanBook() { Book = new Book() });
            }

            member.Loans.Add(loan);


            // Creates an instance of a controller, WITHOUT using the singleton factory, thus NOT creating a Mock Factory.
            LoanController loanController = (LoanController)new Factories.FactoryController().Create("loan");

            //Act
            try
            {
                actual = loanController.Create(member, librarian, booksToBeLoaned);
            }
            catch (Exception e)
            {
                testSuccess = true;
            }

            //Assert

            Assert.IsTrue(testSuccess, testname);

        }
    }
}
