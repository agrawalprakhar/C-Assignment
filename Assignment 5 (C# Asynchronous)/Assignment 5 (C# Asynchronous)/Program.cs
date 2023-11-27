using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5__C__Asynchronous_
{
    public class BackgroundOperation
    {
        public async Task WriteToFileAsync(string message)
        {
            await Task.Delay(3000); // Simulating a delay (for demonstration purposes)

            using (StreamWriter writer = new StreamWriter("tmp.txt", append: true))
            {
                await writer.WriteAsync(message);
            }
        }
    }

    public class KioskSystem
    {
        private readonly BackgroundOperation backgroundOperation;

        public KioskSystem()
        {
            backgroundOperation = new BackgroundOperation();
        }

        public async Task StartKiosk()
        {
            while (true)
            {
                Console.WriteLine("Kiosk Menu:");
                Console.WriteLine("1. Write 'Hello World'");
                Console.WriteLine("2. Write Current Date");
                Console.WriteLine("3. Write OS Version");
                Console.WriteLine("Enter your choice (1/2/3) or 'q' to quit:");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await PerformOperation("Hello World");
                        break;
                    case "2":
                        await PerformOperation(DateTime.Now.ToString());
                        break;
                    case "3":
                        await PerformOperation(Environment.OSVersion.VersionString);
                        break;
                    case "q":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, 3, or 'q'.");
                        break;
                }
            }
        }

        private async Task PerformOperation(string message)
        {
            Console.WriteLine($"Performing operation... Writing '{message}' to the file.");

            try
            {
                await backgroundOperation.WriteToFileAsync(message);
                Console.WriteLine("Operation completed. Data written to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }
    }

    public class Program
    {
        public static async Task Main()
        {
            var kiosk = new KioskSystem();
            await kiosk.StartKiosk();
        }
    }
}
