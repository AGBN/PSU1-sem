//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GTL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LibraryCard
    {
        public int CardNr { get; set; }
        public int MemberID { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime ExpirationDate { get; set; }
    
        public virtual Member Member { get; set; }
    }
}
