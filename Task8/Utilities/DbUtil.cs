using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BankAssignment.Utilities
{
    internal static class DbUtil
    {
        private static IConfiguration _iconfig;
        static DbUtil()
        {
            GetAppSettings();
        }

        private static void GetAppSettings()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            _iconfig = builder.Build();
        }

        public static string GetConnection()
        {
            return _iconfig.GetConnectionString("LocalConnectionString");
        }

    }
}
