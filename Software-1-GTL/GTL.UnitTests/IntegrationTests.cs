using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GTL.Models;
using GTL.DataAccess;
using GTL.Controllers;

namespace GTL.UnitTests
{
    [TestClass]
    public class IntegrationTests
    {
        Book validBook;

        [TestInitialize]
        public void TestInitialize()
        {
            validBook = new Book();
            validBook.Available = true;
            validBook.Title = new Title();

            validBook.Title.TitleName = "The Hobbit";
            validBook.Title.IsLoanable = true;
        }

        [TestCleanup]
        public void TestIniTestCleanup()
        {
            validBook = null;
        }


        [DataRow("CreateLoan - 1", 001010001, 002020002, "CheckOut", true, 2, "A song of ice and fire", true, true, "01/01/2015")]


        [TestMethod]
        public void CreateLoan(string testname, int memberSSN, int librarianSSN, string librarianRole, bool memberIsActive, int nrOfValidBooks, 
            string titleName, bool titleIsloanable, bool bookIsAvailable, string currentDateString )
        {
            //Arrange;
            Factories.FactoryDataAccess.Instance = new MockFactoryDataAccess();

            Member member = new Member() {SSN = memberSSN, IsActive = memberIsActive};
            Librarian librarian = new Librarian() {SSN = librarianSSN, LibrarianRole = librarianRole};

            DateTime currentDate = DateTime.Parse(currentDateString);
            bool libraryCardValid = false;
            int actualNrOfBooksLoaned = 0;

                // add a preset amount of valid books.
            for (int i = 0; i < nrOfValidBooks; i++)
            {
                Loan l = new Loan();
                LoanBook lb = new LoanBook();
                lb.Book = validBook;

                l.LoanBooks.Add(lb);

                member.Loans.Add(l);
            }

                // create book to be loaned.
            Book bookToBeLoaned = new Book();
            Title titleToBeLoaned = new Title();

            bookToBeLoaned.Available = bookIsAvailable;
            titleToBeLoaned.TitleName = titleName;
            titleToBeLoaned.IsLoanable = titleIsloanable;

            bookToBeLoaned.Title = titleToBeLoaned;

            Loan actual = null;



            // Creates an instance of a controller, WITHOUT using the singleton factory, thus NOT creating a Mock Factory.
            LoanController loanController = (LoanController)new Factories.FactoryController().Create("loan");

            //Act
            try
            {
                actual = loanController.Create(member, librarian, new Book[] { bookToBeLoaned});

                foreach (var item in actual.Member.LibraryCards)
                {
                    if (item.ExpirationDate > currentDate)
                        libraryCardValid = true; break;
                }

                foreach (var item in actual.Member.Loans)
                {
                    foreach (var loanBooks in item.LoanBooks)
                    {
                        if (loanBooks.DateReturned <= currentDate)
                        {
                            actualNrOfBooksLoaned++;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                Assert.Fail(testname + " positive test encountered an exception.");
            }

            

            //Assert
            Assert.AreEqual(actual.Librarian.LibrarianRole, "CheckOut");
            Assert.IsTrue(actual.Member.IsActive);
            Assert.IsTrue(libraryCardValid);

            foreach (var item in actual.LoanBooks)
            {
                Assert.IsTrue(item.Book.Available == false);
                Assert.IsTrue(item.Book.Title.IsLoanable);
            }

            Assert.IsTrue(actualNrOfBooksLoaned < 6);

            // Verify that the loan has inserted into the database. Its ID is given there.
            Assert.IsTrue(actual.ID > 0);




        }
    }
}
