using MvcCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Utility.ErrorLog;

namespace MvcCoreApplication.EuropeanAirportsRepository
{
    public class AirportsRepository : IAirportsRepository
    {
        String ConfigData = string.Empty;
       public IErrorLoggers Error = null;
        public AirportsRepository(IErrorLoggers _Error)
        {
            ConfigData = GetConfigFileData.GetConfigurationData();
            Error = _Error;
        }

        public async Task<List<RootObject>> GetConvertJsonData()
        {
            List<RootObject> myDeserializedObjList = null;

            string[] ApiUrl = ConfigData.Split(',');

            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(ApiUrl[0]);

                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    myDeserializedObjList = new List<RootObject>();

                    myDeserializedObjList = (List<RootObject>)Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody, typeof(List<RootObject>));
                }
            }
            catch (Exception ex)
            {
                Error.ExceptionHandler(ex, "GetConvertJsonData", "Repository name");
            }
            finally
            {
            }

            return myDeserializedObjList;
        }

        public List<RootObject> GetJsonFilerData(List<RootObject> ServiceJsonData, String Type, string Continent)
        {
            List<RootObject> JSonData = null;
            string Continents = string.Empty;
            string AirPorts = string.Empty;
            string[] AirportsAndContinents = ConfigData.Split(',');
            AirPorts = AirportsAndContinents[1];
            Continents = AirportsAndContinents[2];

            try
            {
                JSonData = new List<RootObject>();

                JSonData = ((from cn in ServiceJsonData
                             select new RootObject
                             {
                                 name = cn.name,
                                 iso = cn.iso,
                                 iata = cn.iata,
                                 type = cn.type,
                                 lon = cn.lon,
                                 lat = cn.lat,
                                 continent = cn.continent
                             }).Where(c => c.type == AirPorts && c.continent == Continents)).ToList();
            }
            catch (Exception ex)
            {
                Error.ExceptionHandler(ex, "GetJsonFilerData", "Repository name");
            }

            return JSonData;
        }

        //public  List<EuropeanCountries> GetEuropeCountriesList()
        //{
        //    string filePath = "E:\\Narasimha_Data\\GitHub\\MvcCoreApplication\\MvcCoreApplication\\EuropeCountries\\EuropeCountriesList.xml";

        //    EuropeanCountries _Counries = null;
        //    List<EuropeanCountries> EuropeanCountriesData = new List<EuropeanCountries>();

        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();

        //        doc.Load(filePath);

        //        _Counries = new EuropeanCountries();

        //        foreach (XmlNode node in doc.SelectNodes("//country"))
        //        {
        //           EuropeanCountriesData.Add(new EuropeanCountries { CountryCode = node.InnerText.ToString(), CountryName = node.Attributes["code"].InnerText });
        //        }
        //    }
        //    catch(Exception ex)
        //    {

        //    }
        //    return EuropeanCountriesData;
        //}

        public List<RootObject> GetFilterAirpotNames(List<RootObject> ServiceJsonData, String CountryCode)
        {
            List<RootObject> FilterAirpotNames = null;

            try
            {
                if (ServiceJsonData.Count > 0)
                {
                    FilterAirpotNames = new List<RootObject>();

                    FilterAirpotNames = (from names in ServiceJsonData
                                         select new RootObject
                                         {
                                             name = names.name,
                                             iso = names.iso,
                                             lat = names.lat,
                                             lon=names.lon
                                         }).Where(nm => nm.iso == CountryCode && nm.name != null).ToList();

                }
            }
            catch(Exception ex)
            {
                Error.ExceptionHandler(ex, "GetFilterAirpotNames", "Repository name");
            }
            return FilterAirpotNames;
        }

        public List<RootObject> GetTwoAirportsDistance(List<RootObject> ServiceJsonData,string Lat, string Lon)
        {
            List<RootObject> TwoAirportsDistance = null;

            try
            {
                if (ServiceJsonData.Count > 0)
                {
                    TwoAirportsDistance = new List<RootObject>();

                    TwoAirportsDistance = (from names in ServiceJsonData
                                           select new RootObject
                                           {
                                               name = names.name,
                                               iso = names.iso
                                           }).Where(nm => nm.iso == "BG").ToList();
                }
            }
            catch(Exception ex)
            {
                Error.ExceptionHandler(ex, "GetTwoAirportsDistance", "Repository name");
            }
            return TwoAirportsDistance;
        }
    }
}
