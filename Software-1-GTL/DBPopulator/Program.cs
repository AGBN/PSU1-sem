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


        }
    }

    public static class PopStorage
    {
        public static string connectionString = "";

        public static int amountMembers = 20_000;
        public static int amountLibrarians = 20_000;

        public static Dictionary<int, DateTime> memberDict;
    }
    


}
