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
                Console.WriteLine("Total Cases: " + covidArray[countryCode]["total_cases"].ToString());
                Console.WriteLine("New Cases: " + covidArray[countryCode]["new_cases"].ToString());
                Console.WriteLine("Total Deaths: " + covidArray[countryCode]["total_deaths"].ToString());
                Console.WriteLine("New Deaths: " + covidArray[countryCode]["new_deaths"].ToString());
                Console.WriteLine("Reproduction Rate: " + covidArray[countryCode]["reproduction_rate"].ToString());
                Console.WriteLine("ICU Patients: " + covidArray[countryCode]["icu_patients"].ToString());
                Console.WriteLine("Hospital Patients: " + covidArray[countryCode]["hosp_patients"].ToString());
                Console.WriteLine("Total Tests: " + covidArray[countryCode]["total_tests"].ToString());
                Console.WriteLine("New Tests: " + covidArray[countryCode]["new_tests"].ToString());
                Console.WriteLine("Positive Rate: " + covidArray[countryCode]["positive_rate"].ToString());
                Console.WriteLine("Total Vaccinations: " + covidArray[countryCode]["total_vaccinations"].ToString());
                Console.WriteLine("Population: " + covidArray[countryCode]["population"].ToString());
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