using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace Task02_Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string patern = @"(=|\/{1})([A-Z][A-z]{2,})\1";

            Regex findValidLocations = new Regex(patern);

            string text = Console.ReadLine();

            MatchCollection validLocations = findValidLocations.Matches(text);

            int travelPoints = 0;
            List<string> validLocationsForPrint = new List<string>();

            foreach (Match element in validLocations)
            {
                validLocationsForPrint.Add(element.Groups[2].ToString());
                travelPoints += element.Groups[2].ToString().Length;
            }

            Console.Write("Destinations: ");
            Console.WriteLine(string.Join(", ", validLocationsForPrint));
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
