using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTL.DataAccess
{
    public static class Config
    {
        public static string ConnectionString
        {
            get
            {
                return LocalConnString;
                //return connectionString;
            }
        }

        
        private static readonly string connectionString = 
            string.Format(@" [Insert ConnectionString Here] ", User, Pass);
        private static readonly string User = "";
        private static readonly string Pass = "";

        // Use for running the application through a local database
        private static readonly string LocalConnString =
            @"";

    }
}
