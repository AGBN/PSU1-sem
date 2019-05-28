using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTL.View.Models
{
    public class LoanModel
    {

        public int ISBN { get; set; }
        public string TitleName { get; set; }
        public DateTime LoanDate { get; set; }

        public int memberSSN { get; set; }
    }
}