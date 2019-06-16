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
            Console.WriteLine("Creating " + amount + " Members");
            for (int i = 1; i < amount + 1; i++)
            {
                Member m = createMember(i);
            }
            Console.WriteLine("Member creation finished.");

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

            string query = String.Format("INSERT INTO Member VALUES(@index0, @index1, @index2, @index3, @index4, @index5, @index6, @index7, @index8); " +
                "SELECT TOP 2 * FROM [Member] ORDER BY ssn DESC;");

            try
            {
                using (var connection = new SqlConnection(PopStorage.connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@index0", m.SSN);
                        command.Parameters.AddWithValue("@index1", m.MobilePhoneNr);
                        command.Parameters.AddWithValue("@index2", m.FirstName);
                        command.Parameters.AddWithValue("@index3", m.LastName);
                        command.Parameters.AddWithValue("@index4", m.CampusAddressID);
                        command.Parameters.AddWithValue("@index5", m.HomeAddressID);
                        command.Parameters.AddWithValue("@index6", m.IsActive);
                        command.Parameters.AddWithValue("@index7", m.Type);
                        command.Parameters.AddWithValue("@index8", m.DateCreated);

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

                        a = check(a);

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
                Console.WriteLine("Failed Member: " + m.SSN);
                throw new Exception();
            }
            else
            {
                Console.WriteLine("Created Member: " + m.SSN);
                return a;
            }
        }

        public Member check(Member m, int run = 1)
        {

            string query = "SELECT TOP " + (run+1) + " * FROM [Member] ORDER BY ssn DESC;";
            if (m.SSN == 2020002 || m.SSN == 1010001 || m.SSN == 123456)
            {
                using (var connection = new SqlConnection(PopStorage.connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        while(reader.Read())
                        {
                            m = new Member();
                            m.SSN = reader.GetInt32(reader.GetOrdinal("SSN"));
                            m.MobilePhoneNr = reader.GetString(reader.GetOrdinal("MobilePhoneNr"));
                            m.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                            m.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                            m.CampusAddressID = reader.GetInt32(reader.GetOrdinal("CampusAddressID"));
                            m.HomeAddressID = reader.GetInt32(reader.GetOrdinal("HomeAddressID"));
                            m.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                            m.Type = reader.GetString(reader.GetOrdinal("Type"));
                            m.DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated"));
                        }

                        connection.Close();
                    }
                }

                return check(m, run+1);
            }
            else
            {
                return m;
            }
        }
    }
}
