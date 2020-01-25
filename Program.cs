using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Linq;

namespace RestCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient http = new HttpClient();

            string baseUrl = "https://restcountries.eu/rest/v2/name/eesti";

            string queryFilter = "?fields=name;capital;region;cioc;population;topLevelDomain;languages";

            string url = baseUrl + queryFilter;

            HttpResponseMessage response = http.GetAsync(new Uri(url)).Result;

            string responseBody = response.Content.ReadAsStringAsync().Result;

            var countries = JsonConvert.DeserializeObject<List<Andmed.Country>>(responseBody);

            PrintCountryInfo(countries);
        }
        public static void PrintCountryInfo(List<Andmed.Country> countries)
        {
            foreach (var country in countries)
            {
                Console.WriteLine("Country name: " + country.Name);

                Console.WriteLine("Country capital: " + country.Capital);

                Console.WriteLine("Region: " + country.Region);

                Console.WriteLine("CIOC: " + country.Cioc);

                Console.WriteLine("Population: " + country.Population);

                foreach (var domain in country.TopLevelDomain)
                {
                    Console.WriteLine("Domain: " + country.TopLevelDomain[0]);
                }

                foreach (var language in country.Languages)
                {
                    Console.WriteLine("Language: " + language.Name);
                }
            }
        }
    }
}
