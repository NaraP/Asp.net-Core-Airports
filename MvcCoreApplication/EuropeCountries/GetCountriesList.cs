using MvcCoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace MvcCoreApplication.EuropeCountries
{
    public class GetCountriesList
    {
        public static List<EuropeanCountries> GetEuropeCountriesList()
        {
            string filePath = "E:\\Narasimha_Data\\GitHub\\MvcCoreApplication\\MvcCoreApplication\\EuropeCountries\\EuropeCountriesList.xml";

            EuropeanCountries _Counries = null;
            List<EuropeanCountries> EuropeanCountriesData = new List<EuropeanCountries>();

            try
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(filePath);

                _Counries = new EuropeanCountries();

                foreach (XmlNode node in doc.SelectNodes("//country"))
                {
                    EuropeanCountriesData.Add(new EuropeanCountries { CountryName = node.InnerText.ToString(), CountryCode = node.Attributes["code"].InnerText });
                }
            }
            catch (Exception ex)
            {
            }
            return EuropeanCountriesData;
        }

        public static List<KeyValuePair<string, string>> GetEuropeCountriesListData()
        {
            string filePath = "E:\\Narasimha_Data\\GitHub\\MvcCoreApplication\\MvcCoreApplication\\EuropeCountries\\EuropeCountriesList.xml";

            XmlDocument doc = new XmlDocument();

            var CountriesListList = new List<KeyValuePair<string, string>>();

            doc.Load(filePath);

            foreach (XmlNode node in doc.SelectNodes("//country"))
            {
                //DesignationList.Add(new KeyValuePair {  = node.InnerText.ToString(), CountryCode = node.Attributes["code"].InnerText });
                CountriesListList.Add(new KeyValuePair<string, string>(node.InnerText.ToString(), node.Attributes["code"].InnerText));
            }
     
            return CountriesListList;
        }
    }
}
