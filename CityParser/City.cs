using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityParser
{
    public class City
    {
        public string Name { get; }
        public uint Population { get; }
        public uint Area { get; }
        public double Density { get { return (double)Population / Area; }}
        public City(string name, uint population, uint area)
        {
            Name = name;
            Population = population;
            Area = area;
        }

    }
}
