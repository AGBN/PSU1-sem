using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;


namespace DBPopulator
{
    public class PopTitle
    {
        private Random rng = new Random();

        public void createTitles(int amount)
        {
            Console.WriteLine("Creating " + amount + " Titles");
            for (int i = 1+2; i < amount+2 + 1; i++)
            {
                Title m = createTitle(i);

                new PopBook().createBooks(rng.Next(1,5), i);
            }
            Console.WriteLine("Title creation finished.");
        }

        public Title createTitle(int id)
        {
            Title t = new Title();

            t.Publisher = "pub_" + id;
            t.TitleName = "title_" + id;
            t.Language = "lang_" + id;
            t.ISBN = id % 1_000_000;
            t.Edition = id % 10;
            t.PublicationYear = 2000;
            t.Description = "desc_" + id;
            t.Type = "book";
            t.Subject = "Test";
            t.IsLoanable = (id % 2 == 1 ? true : false);
            t.DateCreated = new DateTime(rng.Next(2015, 2020), rng.Next(1, 13), rng.Next(1, 28));
        
            return insertTitle(t);
        }

        private Title insertTitle(Title t)
        {
            Title a = null;

            string query = String.Format("INSERT INTO Title VALUES(@index0, @index1, @index2, @index3, @index4, @index5, @index6, @index7, @index8, @index9, @index10); " +
                "SELECT TOP 1 * FROM [Title] ORDER BY id DESC;");

            try
            {
                using (var connection = new SqlConnection(PopStorage.connectionString))
                {
                    using (var command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        command.Parameters.AddWithValue("@index0", t.Publisher);
                        command.Parameters.AddWithValue("@index1", t.TitleName);
                        command.Parameters.AddWithValue("@index2", t.Language);
                        command.Parameters.AddWithValue("@index3", t.ISBN);
                        command.Parameters.AddWithValue("@index4", t.Edition);
                        command.Parameters.AddWithValue("@index5", t.PublicationYear);
                        command.Parameters.AddWithValue("@index6", t.Description);
                        command.Parameters.AddWithValue("@index7", t.Type);
                        command.Parameters.AddWithValue("@index8", t.Subject);
                        command.Parameters.AddWithValue("@index9", t.IsLoanable);
                        command.Parameters.AddWithValue("@index10", t.DateCreated);

                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            a = new Title();
                            a.ID = reader.GetInt32(reader.GetOrdinal("ID"));
                            a.Publisher = reader.GetString(reader.GetOrdinal("Publisher"));
                            a.TitleName = reader.GetString(reader.GetOrdinal("TitleName"));
                            a.Language = reader.GetString(reader.GetOrdinal("Language"));
                            a.ISBN = reader.GetInt32(reader.GetOrdinal("ISBN"));
                            a.Edition = reader.GetInt32(reader.GetOrdinal("Edition"));
                            a.PublicationYear = reader.GetInt32(reader.GetOrdinal("PublicationYear"));
                            a.Description = reader.GetString(reader.GetOrdinal("Description"));
                            a.Type = reader.GetString(reader.GetOrdinal("Type"));
                            a.Subject = reader.GetString(reader.GetOrdinal("Subject"));
                            a.IsLoanable = reader.GetBoolean(reader.GetOrdinal("IsLoanable"));
                            a.DateCreated = reader.GetDateTime(reader.GetOrdinal("DateCreated"));
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
                Console.WriteLine("Failed Title: " + t.ID);
                throw new Exception();
            }
            else
            {
                Console.WriteLine("Created Title: " + t.ID);
                return a;
            }
        }
    }
}
