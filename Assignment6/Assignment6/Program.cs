using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    public class Program
    {
        public static async Task Main()
        {
            Console.WriteLine("Enter the URL to read content from:");
            string url = Console.ReadLine();

            try
            {
                string content = await ReadContentFromUrlAsync(url);
                await WriteContentToFileAsync(content);
                Console.WriteLine("Content has been successfully written to A.txt file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.ReadLine();
        }

        public static async Task<string> ReadContentFromUrlAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode(); // Throws exception for non-success status codes
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task WriteContentToFileAsync(string content)
        {
            using (StreamWriter writer = new StreamWriter("A.txt"))
            {
                await writer.WriteAsync(content);
            }
        }
    }
}
