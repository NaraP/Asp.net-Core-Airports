using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcCoreApplication
{
    public class GetConfigFileData
    {
        public static IConfigurationRoot Configuration;

        public static String GetConfigurationData()
        {
            String ConfigData = string.Empty;

            try
            {
                var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json");

                Configuration = builder.Build();

                string ApiServiceUrl = ($"{Configuration["APIService:APIServiceUrl"]}");

                string FilterAirports = ($"{Configuration["Airport:Airports"]}");

                string Continent = ($"{Configuration["continent:continents"]}");

                string[] values = { ApiServiceUrl, FilterAirports, Continent };

                ConfigData = ApiServiceUrl + "," + FilterAirports + "," + Continent;
            }
            catch (Exception ex)
            {
            }

            return ConfigData; ;
        }
       public static String StringBuilderAppend(string seperator, params string[] values)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(values[0]);
            for (int i = 1; i < values.Length; i++)
            {
                builder.Append(seperator);
                builder.Append(values[i]);
            }
            return builder.ToString();
        }

    }
}
