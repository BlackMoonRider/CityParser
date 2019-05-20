using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // This commented-out code is for debugging purposes
            // Parser parser = new Parser("Kharkiv=1431000,350;Kiev=2804000,839;Las Vegas=603400,352");
            // Parser parser = new Parser("Kiev=2804000,839;Las Vegas=603400,352;Kharkiv=1431000,350");

            Console.WriteLine("Enter a list of cities:");
            Parser parser = new Parser(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            List<City> cities = parser.GetCities();
            Statistics statistics = new Statistics(cities);
            Console.WriteLine(statistics);

            Console.ReadKey();
        }
    }
}
