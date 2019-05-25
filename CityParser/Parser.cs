using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityParser
{
    class Parser
    {
        private string[] InputSemicolonDelimited { get; }

        public Parser(string input)
        {
            InputSemicolonDelimited = DelimitBySemicolon(input);
        }

        public string GetStatistics()
        {
            List<City> cities = GetCities();
            return new Statistics(cities).ToString();
        }

        private string[] DelimitBySemicolon(string input) => input.Split(';');

        private List<City> GetCities() 
        {
            List<City> cityList = new List<City>();

            string name;
            uint population;
            uint area;

            foreach (string item in InputSemicolonDelimited)
            {
                string[] semicolonDelimited = item.Split('=');
                name = semicolonDelimited[0];
                string[] populationAndArea = semicolonDelimited[1].Split(',');
                uint.TryParse(populationAndArea[0], out population);
                uint.TryParse(populationAndArea[1], out area);

                cityList.Add(new City(name, population, area));
            }

            return cityList;
        }
    }
}
