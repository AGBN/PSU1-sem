using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTL.Models;

namespace DBPopulator
{
    public class Program
    {
        private static Random rng = new Random();

        static void Main(string[] args)
        {
            new PopMember().createMembers(PopStorage.amountMembers);
            new PopLibrarian().createLibrarians(PopStorage.amountLibrarians);
            new PopTitle().createTitles(PopStorage.amountTitles);

            foreach (int item in PopStorage.titleIDs)
            {
                new PopBook().createBooks(rng.Next(1, 5), item);
            }

            Console.WriteLine("Database population done....");
            Console.ReadKey();
        }
    }

    public static class PopStorage
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GTL;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static int amountMembers = 20_000;
        public static int amountLibrarians = 100;
        public static int amountTitles = 100_000;

        public static List<int> titleIDs = new List<int>();

        private static Dictionary<string, int> Counters = new Dictionary<string, int>();
    }
    


}
