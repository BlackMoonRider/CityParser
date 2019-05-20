using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityParser
{
    class Statistics
    {
        public City MostPopulated { get; }
        public City LongestName { get; }
        public List<City> DensitySortedDescending { get; }

        public Statistics(List<City> cities)
        {
            MostPopulated = GetMostPopulatedCity(cities);
            LongestName = GetLongestNameCity(cities);
            DensitySortedDescending = GetDensitySortedDescendingCities(cities);
        }

        private City GetMostPopulatedCity(List<City> cities)
        {
            City mostPopulated = null;

            foreach (City city in cities)
            {
                if (mostPopulated == null)
                    mostPopulated = city;
                else if (city.Population > mostPopulated.Population)
                        mostPopulated = city;
            }

            return mostPopulated;
        }

        private City GetLongestNameCity(List<City> cities)
        {
            City longestName = null;

            foreach (City city in cities)
            {
                if (longestName == null)
                    longestName = city;
                else if (city.Name.Count() > longestName.Name.Count())
                    longestName = city;
            }

            return longestName;
        }

        private List<City> GetDensitySortedDescendingCities(List<City> cities)
        {
            List<City> densitySortedDescending = cities;

            for (int i = 1; i < cities.Count; i++)
            {
                for (int j = 1; j < cities.Count - i + 1; j++)
                {
                    if (densitySortedDescending[j - 1].Density < densitySortedDescending[j].Density)
                    {
                        City temp = densitySortedDescending[j - 1];
                        densitySortedDescending[j - 1] = densitySortedDescending[j];
                        densitySortedDescending[j] = temp;
                    }
                }
            }

            return densitySortedDescending;
        }

        private void Swap (ref City city1, ref City city2)
        {
            City temp = city1;
            city1 = city2;
            city2 = temp;
        }

        public override string ToString()
        {
            string output;

            output = $"Most populated: {MostPopulated.Name} ({MostPopulated.Population} people)" + Environment.NewLine;
            output += $"Longest name: {LongestName.Name} ({LongestName.Name.Count()} letters)" + Environment.NewLine;
            output += $"Density: " + Environment.NewLine;
            foreach (City city in DensitySortedDescending)
            {
                output += $"\t{city.Name} - {city.Density}" + Environment.NewLine;
            }

            return output;
        }
    }
}
