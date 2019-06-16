using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace DBPopulator
{
    public class PopLibrarian
    {
        private Random rng = new Random();

        public void createLibrarians(int amount)
        {
            Console.WriteLine("Creating " + amount + " Librarians");
            for (int i = 1; i < amount + 1; i++)
            {
                Librarian m = createLibrarian(i);
            }
            Console.WriteLine("Librarian creation finished.");
        }

        public Librarian createLibrarian(int id)
        {
            Librarian l = new Librarian();

            l.SSN = new PopMember().createMember(id + PopStorage.amountMembers).SSN;
            l.Username = "user_" + id;
            l.Password = "pass_" + id;
            l.LibrarianRole = "ChiefLibrarian";
            l.DateHired = new DateTime(rng.Next(2010, 2018), rng.Next(1, 13), rng.Next(1, 28));

            return insertLibrarian(l);
        }

        private Librarian insertLibrarian(Librarian l)
        {
            Librarian a = null;

            string query = String.Format("INSERT INTO Librarian VALUES(@index0, @index1, @index2, @index3, @index4); " +
                "SELECT TOP 1 * FROM [Librarian] ORDER BY ssn DESC;");

            try
            {
                using (var connection = new SqlConnection(PopStorage.connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@index0", l.SSN);
                        command.Parameters.AddWithValue("@index1", l.Username);
                        command.Parameters.AddWithValue("@index2", l.Password);
                        command.Parameters.AddWithValue("@index3", l.LibrarianRole);
                        command.Parameters.AddWithValue("@index4", l.DateHired);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            a = new Librarian();
                            a.SSN = reader.GetInt32(reader.GetOrdinal("SSN"));
                            a.Username = reader.GetString(reader.GetOrdinal("Username"));
                            a.Password = reader.GetString(reader.GetOrdinal("Password"));
                            a.LibrarianRole = reader.GetString(reader.GetOrdinal("LibrarianRole"));
                            a.DateHired = reader.GetDateTime(reader.GetOrdinal("DateHired"));
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
                Console.WriteLine("Failed Librarian: " + l.SSN);
                throw new Exception();
            }
            else
            {
                Console.WriteLine("Created Librarian: " + l.SSN);
                return a;
            }
        }

        public Librarian check(Librarian m, int run = 1)
        {

            string query = "SELECT TOP " + (run + 1) + " * FROM [Librarian] ORDER BY ssn DESC;";
            if (m.SSN == 2020002 || m.SSN == 1010001 || m.SSN == 123456)
            {
                using (var connection = new SqlConnection(PopStorage.connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            m = new Librarian();
                            m.SSN = reader.GetInt32(reader.GetOrdinal("SSN"));
                            m.Username = reader.GetString(reader.GetOrdinal("Username"));
                            m.Password = reader.GetString(reader.GetOrdinal("Password"));
                            m.LibrarianRole = reader.GetString(reader.GetOrdinal("LibrarianRole"));
                            m.DateHired = reader.GetDateTime(reader.GetOrdinal("DateHired"));
                        }

                        connection.Close();
                    }
                }

                return check(m, run + 1);
            }
            else
            {
                return m;
            }
        }
    }
}
