using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.Models
{
    public static class FactoryModels
    {

        public static Member CreateMember(int ssn, string firstName, string lastName, string mobilePhoneNr,
            Address campusAddress, Address homeAddress, MemberType memberType, DateTime dateCreated)
        {
            Member m = new Member();

            
            m.SSN = ssn;
            m.MobilePhoneNr = mobilePhoneNr; // TODO needs phone nr verification.
            m.FirstName = firstName;
            m.LastName = lastName;

            m.CampusAddress = campusAddress; // TODO needs address verification.
            m.HomeAddress = homeAddress;
            m.CampusAddressID = campusAddress.AddressID;
            m.HomeAddressID = homeAddress.AddressID;

            m.MemberType = memberType;
            m.Type = memberType.TypeName;

            m.DateCreated = dateCreated;

            return m;
        }

        public static Address CreateAddress(string zip, string city, string streetName, string streetNr, int floorNr = -1, string aptNr = "", string phoneNr = "")
        {
            Address adr = new Address();

            adr.Zip = zip;
            adr.City = city;
            adr.StreetName = streetName;
            adr.StreetNr = streetNr;
            adr.FloorNr = floorNr;
            adr.AptNr = aptNr;
            adr.PhoneNr = phoneNr;

            return adr;
        }

        public static Loan CreateLoan(Librarian librarian, Member member, ICollection<LoanBook> bookList)
        {
            Loan l = new Loan();

            if (member == null)
                throw new ArgumentException("Could not add Member.");
            else if (librarian == null)
                throw new ArgumentException("Could not add Librarian.");

            l.Librarian = librarian;
            l.LibrarianID = librarian.SSN;

            l.Member = member;
            l.MemberID = member.SSN;

            l.LoanBooks = bookList;

            return l;
        }

        public static ICollection<LoanBook> CreateLoanBookList(ICollection<Book> bookList)
        {
            ICollection<LoanBook> loanBooks = new List<LoanBook>();

            foreach (Book item in bookList)
            {
                LoanBook lb = new LoanBook();

                lb.Book = item;
                lb.BookID = item.TitleID;
                lb.CopyNr = item.CopyNr;

                loanBooks.Add(lb);
            }

            if (loanBooks.Count < 1)
                throw new ArgumentException("A loan must contain at least 1 book.");

            return loanBooks;
        }

        public static Title CreateTitle(string publisher, string titleName, string language, int isbn, int edition, 
            int publicationYear, string description, string type, string subject, bool isLoanAble, 
            ICollection<Author> authors, DateTime dateCreated)
        {
            Title t = new Title();

            if (authors.Count < 1)
                throw new Exception("Title must have at least 1 author. Use 'Unknown' if author is not known.");

            t.Publisher = publisher;
            t.TitleName = titleName;
            t.Language = language;
            t.ISBN = isbn;
            t.Edition = edition;
            t.PublicationYear = publicationYear;
            t.Description = description;
            t.Type = type;
            t.Subject = subject;
            t.IsLoanable = isLoanAble;
            t.Authors = authors;
            t.DateCreated = dateCreated;

            return t;
        }

        public static Book CreateBook(Title bookTitle, DateTime dateCreated, string bookState = "New")
        {
            Book b = new Book();

            b.Title = bookTitle;
            b.TitleID = bookTitle.ID;
            b.BookState = bookState;
            b.DateAcquired = dateCreated;

            return b;
        }

        public static Librarian CreateLibrarian(Member m, string username, string password, LibrarianRole role, DateTime dateCreated)
        {
            Librarian lib = new Librarian();

            lib.Member = m;
            lib.SSN = m.SSN;

            lib.Username = username;
            lib.Password = password;

            lib.LibrarianRole1 = role;
            lib.LibrarianRole = role.RoleName;

            lib.DateHired = dateCreated;

            return lib;
        }
    }
}
