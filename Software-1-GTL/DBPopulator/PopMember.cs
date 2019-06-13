using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using GTL.Models;

namespace DBPopulator
{
    public class PopMember
    {
        private Random rng = new Random();

        public void createMembers(int amount)
        {
            for (int i = 1; i < amount + 1; i++)
            {

                Address adr = new PopAddress().createAddress(i);

                Member m = createMember(i);


            }
        }

        public Member createMember(int id)
        {
            Member m = new Member();

            m.SSN = id;
            m.MobilePhoneNr = "mp_" + id;
            m.FirstName = "fn_" + id;
            m.LastName = "ln_" + id;
            m.HomeAddressID = new PopAddress().createAddress(id).AddressID;
            m.CampusAddressID = 1;
            m.IsActive = (id%2 == 1 ? true : false);
            m.Type = "Student";
            m.DateCreated = new DateTime(rng.Next(2015, 2020), rng.Next(1, 13), rng.Next(1, 28));

            return insertMember(m);
        }

        private Member insertMember(Member m)
        {
            Member a = null;

            string query = String.Format("INSERT INTO Member VALUES({0},{1},{2},{3},{4},{5},{6},{7},{8})",
                m.SSN,
                m.MobilePhoneNr,
                m.FirstName,
                m.LastName,
                m.CampusAddressID,
                m.HomeAddressID,
                m.IsActive,
                m.Type,
                m.DateCreated
                );

            using (var connection = new SqlConnection(PopStorage.connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        a = new Member();
                        a.SSN = reader.GetInt32(reader.GetOrdinal("SSN"));
                        a.MobilePhoneNr = reader.GetString(reader.GetOrdinal("MobilePhoneNr"));
                        a.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                        a.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                        a.CampusAddressID = reader.GetInt32(reader.GetOrdinal("CampusAddressID"));
                        a.HomeAddressID = reader.GetInt32(reader.GetOrdinal("HomeAddressID"));
                        a.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        a.Type = reader.GetString(reader.GetOrdinal("Type"));
                        a.DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated"));
                    }
                }
            }

            if (a == null)
            {
                throw new Exception();
            }
            else
            {
                return a;
            }
        }
    }
}
