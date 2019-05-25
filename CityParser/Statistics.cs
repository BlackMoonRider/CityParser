using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityParser
{
    class Statistics
    {
        private City MostPopulated { get; }
        private City LongestName { get; }
        private List<City> DensitySortedDescending { get; }

        public Statistics(List<City> cities)
        {
            MostPopulated = GetMostPopulatedCity(cities);
            LongestName = GetLongestNameCity(cities);
            DensitySortedDescending = GetDensitySortedDescendingCities(cities);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Most populated: {MostPopulated.Name} ({MostPopulated.Population} people)");
            stringBuilder.AppendLine($"Longest name: {LongestName.Name} ({LongestName.Name.Count()} letters)");
            stringBuilder.AppendLine($"Density: ");

            foreach (City city in DensitySortedDescending)
            {
                stringBuilder.AppendLine($"\t{city.Name} - {city.Density}");
            }

            return stringBuilder.ToString();
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
    }
}
