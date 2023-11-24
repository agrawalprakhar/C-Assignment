using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            InventorySystem inventory = new InventorySystem();

            // Initialize inventory with provided products
            List<Product> initialProducts = new List<Product>
        {
            new Product("lettuce", 10.5, 50, "Leafy green"),
            new Product("cabbage", 20, 100, "Cruciferous"),
            new Product("pumpkin", 30, 30, "Marrow"),
            new Product("cauliflower", 10, 25, "Cruciferous"),
            new Product("zucchini", 20.5, 50, "Marrow"),
            new Product("yam", 30, 50, "Root"),
            new Product("spinach", 10, 100, "Leafy green"),
            new Product("broccoli", 20.2, 75, "Cruciferous"),
            new Product("garlic", 30, 20, "Leafy green"),
            new Product("silverbeet", 10, 50, "Marrow")
        };

            // Adding initial products to inventory
            foreach (var product in initialProducts)
            {
                inventory.AddProduct(product);
            }

            Console.WriteLine($"Total number of products in the list: {inventory.TotalNumberOfProducts()}");
            Console.ReadLine(); // Keep console window open


            inventory.AddNewProduct("Potato", 10, 50, "Root");
            inventory.DisplayProducts();
            Console.WriteLine($"Total number of products after adding new product: {inventory.TotalNumberOfProducts()}");
            Console.ReadLine(); // Keep console window open

            inventory.PrintTypeProducts("Leafy green");
            Console.ReadLine(); // Keep console window open

            inventory.RemoveProduct("garlic");
            Console.WriteLine($"Total number of products left after removing garlic: {inventory.TotalNumberOfProducts()}");
            Console.ReadLine(); // Keep console window open

            inventory.UpdateQuantity("cabbage", 50);
            var cabbage = inventory.products.FirstOrDefault(p => p.Name.Equals("cabbage", StringComparison.OrdinalIgnoreCase));
            if (cabbage != null)
            {
                Console.WriteLine($"Final quantity of cabbage in the inventory: {cabbage.Quantity}");
                Console.ReadLine(); // Keep console window open
            }


            Dictionary<string, int> itemsWithQuantity = new Dictionary<string, int>
        {
            { "lettuce", 1 },  // 1 kg lettuce
            { "zucchini", 2 }, // 2 kg zucchini
            { "broccoli", 1 }  // 1 kg broccoli
        };


            double totalCost = inventory.CalculatePurchaseCostWithQuantity(itemsWithQuantity);
            Console.WriteLine($"Total cost for purchasing 1kg lettuce, 2kg zucchini, 1kg broccoli: {totalCost} RS");
            Console.ReadLine(); // Keep console window open
        }
     
    }   



    class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Product(string name, double price, int quantity, string type)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Type = type;
        }
    }

    class InventorySystem
    {
        public List<Product> products;

        public InventorySystem()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
            Console.WriteLine("Product added successfully!");
        }

        public void DisplayProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products available in the inventory.");
            }
            else
            {
                Console.WriteLine("Product Inventory:");
                foreach (var product in products)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Type: {product.Type}");
                }
            }
        }

        public int TotalNumberOfProducts()
        {
            return products.Count;
        }

        public void AddNewProduct(string name, double price, int quantity, string type)
        {
            Product newProduct = new Product(name, price, quantity, type);
            products.Add(newProduct);
            Console.WriteLine("New product added successfully!");
        }

        public void PrintTypeProducts(string type)
        {
            var typeProducts = products.Where(p => p.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
            if (typeProducts.Count == 0)
            {
                Console.WriteLine($"No products of type '{type}' available in the inventory.");
            }
            else
            {
                Console.WriteLine($"Products of type '{type}':");
                foreach (var product in typeProducts)
                {
                    Console.WriteLine($"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Type: {product.Type}");
                }
            }
        }

        public void RemoveProduct(string productName)
        {
            var productToRemove = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                Console.WriteLine($"{productName} removed from the inventory.");
            }
            else
            {
                Console.WriteLine($"{productName} not found in the inventory.");
            }
        }

        public void UpdateQuantity(string productName, int additionalQuantity)
        {
            var product = products.FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));
            if (product != null)
            {
                product.Quantity += additionalQuantity;
                Console.WriteLine($"Quantity of {productName} updated successfully!");
            }
            else
            {
                Console.WriteLine($"{productName} not found in the inventory.");
            }
        }

        public double CalculatePurchaseCostWithQuantity(Dictionary<string, int> itemsWithQuantity)
        {
            double totalCost = 0;
            foreach (var item in itemsWithQuantity)
            {
                var product = products.FirstOrDefault(p => p.Name.Equals(item.Key, StringComparison.OrdinalIgnoreCase));
                if (product != null)
                {
                    totalCost += product.Price * item.Value;
                }
            }
            return totalCost;
        }

    }

}