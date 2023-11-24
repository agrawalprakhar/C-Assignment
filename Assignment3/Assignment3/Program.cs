using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating a dictionary to store prime ministers and their respective years
            Dictionary<int, string> primeMinisters = new Dictionary<int, string>
        {
            { 1998, "Atal Bihari Vajpayee" },
            { 2014, "Narendra Modi" },
            { 2004, "Manmohan Singh" }
        };

            // Finding the Prime Minister of 2004
            if (primeMinisters.ContainsKey(2004))
            {
                string primeMinisterOf2004 = primeMinisters[2004];
                Console.WriteLine($"Prime Minister of 2004: {primeMinisterOf2004}");
                Console.ReadLine(); // Keep console window open
            }
            else
            {
                Console.WriteLine("Prime Minister of 2004 not found.");
                Console.ReadLine(); // Keep console window open
            }

            // Adding the current Prime Minister (hypothetical name)
            int currentYear = DateTime.Now.Year; // Getting the current year
            Console.Write("Enter the name of the current Prime Minister: ");
            string currentPrimeMinister = Console.ReadLine();
            primeMinisters[currentYear] = currentPrimeMinister;
            Console.WriteLine("Current Prime Minister added successfully.");
            Console.ReadLine(); // Keep console window open

            // Sorting the dictionary by year
            var sortedPrimeMinisters = primeMinisters.OrderBy(pm => pm.Key);

            // Displaying the sorted dictionary
            Console.WriteLine("\nPrime Ministers sorted by year:");
            foreach (var pair in sortedPrimeMinisters)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            
            }
            Console.ReadLine(); // Keep console window open
        }
    }
}
