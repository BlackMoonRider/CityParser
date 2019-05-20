using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityParser
{
    class Parser
    {
        public string Input { get; }
        public List<string> InputSemicolonDelimited { get; }
        public List<City> Cities { get; private set; }

        public Parser(string input)
        {
            Input = input;
            InputSemicolonDelimited = DelimitBySemicolon(Input);
        }

        private List<string> DelimitBySemicolon(string input)
        {
            List<string> output = new List<string>();
            output = input.Split(';').ToList();
            return output;
        }

        public List<City> GetCities()
        {
            return GetCities(InputSemicolonDelimited);
        }

        public List<City> GetCities(List<string> inputSemicolonDelimited) 
        {
            List<City> cityList = new List<City>();

            string name;
            uint population;
            uint area;

            foreach (string item in inputSemicolonDelimited)
            {
                var semicolonDelimited = item.Split('=');
                name = semicolonDelimited[0];
                uint.TryParse(semicolonDelimited[1].Split(',')[0], out population);
                uint.TryParse(semicolonDelimited[1].Split(',')[1], out area);

                cityList.Add(new City(name, population, area));
            }

            return cityList;
        }
    }
}
