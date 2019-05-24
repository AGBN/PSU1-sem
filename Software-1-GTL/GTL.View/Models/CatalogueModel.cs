using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTL.View.Models
{
    public class BookList
    {
        public List<CatalogueModel> LoanableBooks { get;set; }
        public BookList()
        {
            LoanableBooks = new List<CatalogueModel>();
        }
    }
    public class CatalogueModel
    {
        public int  ID { get; set; }
        public string Publisher { get; set; }
        public string TitleName { get; set; }
        public string Language { get; set; }
        public int ISBN { get; set; }
        public int Edition { get; set; }
        public string PublicationYear { get; set; }
        public string Type { get; set; }
        public string Subject { get; set; }
        public bool isLoanable { get; set; }
        public string DateCreated { get; set; }
    }
}