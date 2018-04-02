using MvcCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreApplication.EuropeanAirportsRepository
{
    public interface IAirportsRepository
    {
        //List<EuropeanCountries> GetEuropeCountriesList();
        Task<List<RootObject>> GetConvertJsonData();
        List<RootObject>  GetFilterAirpotNames(List<RootObject> ServiceJsonData, String CountryCode);
        List<RootObject> GetTwoAirportsDistance(List<RootObject> ServiceJsonData, String Lat, String Lon);

        List<RootObject> GetJsonFilerData(List<RootObject> ServiceJsonData ,String Type,string Continent);
    }
}
