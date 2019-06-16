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
        static void Main(string[] args)
        {
            new PopMember().createMembers(PopStorage.amountMembers);
            new PopLibrarian().createLibrarians(PopStorage.amountLibrarians);
            new PopTitle().createTitles(PopStorage.amountTitles);
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

        private static Dictionary<string, int> Counters = new Dictionary<string, int>();
    }
    


}
