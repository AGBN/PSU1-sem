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
            Address a = new Address();

            string query = String.Format("INSERT INTO Address VALUES({0},{1},{2},{3},{4},{5},{6})",
                adr.Zip,
                adr.City,
                adr.StreetName,
                adr.StreetNr,
                adr.FloorNr,
                adr.AptNr,
                adr.PhoneNr);

            using (var connection = new SqlConnection(PopStorage.connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        a.
                    }
                }
            }


        }
    }
}