using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace DBPopulator
{
    public class PopAddress
    {
        public Address createAddress(int id)
        {
            Address adr = new Address();

            adr.Zip         = "Z_" + id;
            adr.City        = "c_" + id;
            adr.StreetName  = "sn_" + id;
            adr.FloorNr     = id % 100;
            adr.AptNr       = "apt_" + id;
            adr.PhoneNr     = "ph_" + id;
            adr.AddressID   = id;

            return insertAddress(adr);
        }

        private Address insertAddress(Address adr)
        {
            using (var connection = new SqlConnection())


        }
    }
}