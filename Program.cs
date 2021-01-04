using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace CovStat
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintStatistics();
        }

        private static void PrintStatistics()
        {
            // fuck covid

            String covidData = String.Empty;
            String covidUrl = "https://raw.githubusercontent.com/owid/covid-19-data/master/public/data/latest/owid-covid-latest.json";


            using (WebClient client = new WebClient())
            {
                covidData = client.DownloadString(covidUrl);
            }

            dynamic covidArray = JObject.Parse(covidData);

            Console.WriteLine("Please enter the country code:");
            String countryCode = Console.ReadLine().ToUpper();

            try
            {
                Console.Clear();
                Console.WriteLine("Continent: " + covidArray[countryCode]["continent"].ToString());
                Console.WriteLine("Location: " + covidArray[countryCode]["location"].ToString());
                Console.WriteLine("Total Cases: " + string.Format("{0:n0}", covidArray[countryCode]["total_cases"]));
                Console.WriteLine("New Cases: " + string.Format("{0:n0}", covidArray[countryCode]["new_cases"]));
                Console.WriteLine("Total Deaths: " + string.Format("{0:n0}", covidArray[countryCode]["total_deaths"]));
                Console.WriteLine("New Deaths: " + string.Format("{0:n0}", covidArray[countryCode]["new_deaths"]));
                Console.WriteLine("Reproduction Rate: " + covidArray[countryCode]["reproduction_rate"].ToString());
                Console.WriteLine("ICU Patients: " + covidArray[countryCode]["icu_patients"].ToString());
                Console.WriteLine("Hospital Patients: " + string.Format("{0:n0}", covidArray[countryCode]["hosp_patients"]));
                Console.WriteLine("Total Tests: " + string.Format("{0:n0}", covidArray[countryCode]["total_tests"]));
                Console.WriteLine("New Tests: " + string.Format("{0:n0}", covidArray[countryCode]["new_tests"]));
                Console.WriteLine("Positive Rate: " + covidArray[countryCode]["positive_rate"].ToString());
                Console.WriteLine("Total Vaccinations: " + string.Format("{0:n0}", covidArray[countryCode]["total_vaccinations"]));
                Console.WriteLine("Population: " + string.Format("{0:n0}", covidArray[countryCode]["population"]));
                Console.WriteLine("Life expectancy: " + covidArray[countryCode]["life_expectancy"].ToString());

                Console.WriteLine(Environment.NewLine);
                PrintStatistics();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown country. Try again.");
                PrintStatistics();
            }
        }
    }
}