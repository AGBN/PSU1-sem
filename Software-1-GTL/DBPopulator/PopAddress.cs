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
            adr.StreetNr    = "snr_" + id;
            adr.FloorNr     = id % 100;
            adr.AptNr       = "apt_" + id;
            adr.PhoneNr     = "ph_" + id;
            adr.AddressID   = id;

            return insertAddress(adr);
        }

        private Address insertAddress(Address adr)
        {
            Address a = null;

            string query = String.Format("INSERT INTO [Address] VALUES(@index0, @index1, @index2, @index3, @index4, @index5, @index6); " +
                "SELECT TOP 1 * FROM [Address] ORDER BY AddressID DESC;");

            try
            {
                using (var connection = new SqlConnection(PopStorage.connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@index0", adr.Zip);
                        command.Parameters.AddWithValue("@index1", adr.City);
                        command.Parameters.AddWithValue("@index2", adr.StreetName);
                        command.Parameters.AddWithValue("@index3", adr.StreetNr);
                        command.Parameters.AddWithValue("@index4", adr.FloorNr);
                        command.Parameters.AddWithValue("@index5", adr.AptNr);
                        command.Parameters.AddWithValue("@index6", adr.PhoneNr);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            a = new Address();
                            a.AddressID = reader.GetInt32(reader.GetOrdinal("AddressID"));
                            a.Zip = reader.GetString(reader.GetOrdinal("Zip"));
                            a.City = reader.GetString(reader.GetOrdinal("City"));
                            a.StreetName = reader.GetString(reader.GetOrdinal("StreetName"));
                            a.StreetNr = reader.GetString(reader.GetOrdinal("StreetNr"));
                            a.FloorNr = reader.GetInt32(reader.GetOrdinal("FloorNr"));
                            a.AptNr = reader.GetString(reader.GetOrdinal("AptNr"));
                            a.PhoneNr = reader.GetString(reader.GetOrdinal("PhoneNr"));
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {

                throw e;
            }
            

            if (a == null)
            {
                Console.WriteLine("Failed Address: " + adr.AddressID);
                throw new Exception();
            }
            else
            {
                Console.WriteLine("Created Address: " + adr.AddressID);
                return a;
            }

        }
    }
}