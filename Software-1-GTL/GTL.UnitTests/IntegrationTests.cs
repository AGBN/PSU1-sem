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
        List<Title> validTitles;

        [TestInitialize]
        public void TestInitialize()
        {
            validTitles = new List<Title>();

            Title ttmp;
            Book btmp;
            ttmp = new Title();
            btmp = new Book();

            ttmp.TitleName = "A song of fire and ice";
            ttmp.IsLoanable = true;
;
            btmp.Available = true;
            ttmp.Books.Add(btmp);


            validTitles.Add(ttmp);

        }

        [TestCleanup]
        public void TestIniTestCleanup()
        {
            validTitles = null;

        }

        [TestMethod]
        public void CreateLoan(string testname, int memberSSN, int librarianSSN, string librarianRole, bool memberIsActive, int nrOfValidBooks, Title titleToBeLoaned, Book bookToBeLoaned, DateTime currentDate )
        {
            //Arrange;
            Factories.FactoryDataAccess.Instance = new MockFactoryDataAccess();

            Member member = new Member() {SSN = memberSSN, IsActive = memberIsActive};

            Librarian librarian = new Librarian() {SSN = librarianSSN, LibrarianRole = librarianRole};

            bool libraryCardValid = false;
            int actualNrOfBooksLoaned = 0;

            Loan actual = null;


            bookToBeLoaned.Title = titleToBeLoaned;
            List<Book> toBeLoanedList = new List<Book>();
            toBeLoanedList.Add(bookToBeLoaned);

            for (int i = 0; i < nrOfValidBooks; i++)
            {
                validTitles[i].Title = titles[i%titles.Length];
                Loan l = new Loan();
                LoanBook lb = new LoanBook();

                lb.Book = books[i];

                l.LoanBooks.Add(lb);

                member.Loans.Add(l);
            }




            // Creates an instance of a controller, WITHOUT using the singleton factory, thus NOT creating a Mock Factory.
            LoanController loanController = (LoanController)new Factories.FactoryController().Create("loan");

            //Act
            try
            {
                actual = loanController.Create(member, librarian, toBeLoanedList);

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
                Assert.IsTrue(item.Book.Available == true);
                Assert.IsTrue(item.Book.Title.IsLoanable);
            }

            Assert.IsTrue(actualNrOfBooksLoaned < 5);

            // Verify that the loan has inserted into the database. Its ID is given there.
            Assert.IsTrue(actual.ID > 0);




        }
    }
}
