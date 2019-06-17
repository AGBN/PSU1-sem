using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace DBPopulator
{
    public class PopBook
    {
        private Random rng = new Random();

        public void createBooks(int amount, int titleId)
        {
            for (int i = 1; i < amount + 1; i++)
            {
                Book m = createBook(i, titleId);
            }
        }

        public Book createBook(int id, int titleId)
        {
            Book b = new Book();

            b.TitleID = titleId;
            b.CopyNr = id;
            b.BookState = "state_" + titleId + "_" + id;
            b.Available = ((id) % 2 == 1 ? true : false);
            b.DateAcquired = new DateTime(rng.Next(2005, 2020), rng.Next(1, 13), rng.Next(1, 28));

            return insertBook(b);
        }

        private Book insertBook(Book b)
        {
            Book a = null;

            string query = String.Format("INSERT INTO Book VALUES(@index0, @index1, @index2, @index3, @index4); " +
                "SELECT TOP 1 * FROM [Book] ORDER BY Copynr, TitleID DESC;");

            try
            {
                using (var connection = new SqlConnection(PopStorage.connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@index0", b.TitleID);
                        command.Parameters.AddWithValue("@index1", b.CopyNr);
                        command.Parameters.AddWithValue("@index2", b.BookState);
                        command.Parameters.AddWithValue("@index3", b.Available);
                        command.Parameters.AddWithValue("@index4", b.DateAcquired);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            a = new Book();
                            a.TitleID = reader.GetInt32(reader.GetOrdinal("TitleID"));
                            a.CopyNr = reader.GetInt32(reader.GetOrdinal("CopyNr"));
                            a.BookState = reader.GetString(reader.GetOrdinal("BookState"));
                            a.Available = reader.GetBoolean(reader.GetOrdinal("Available"));
                            a.DateAcquired = reader.GetDateTime(reader.GetOrdinal("DateAcquired"));
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
                throw new Exception();
            }
            else
            {
                return a;
            }
        }
    }
}
