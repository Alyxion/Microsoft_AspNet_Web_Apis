using System;
using Newtonsoft.Json;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Create product object
            var product1 = new Product { ID=101, Name="Red Apple", Price=1.99 };

            // Serialize the objec to JSON
            var jsonString = JsonConvert.SerializeObject(product1);

            System.Console.WriteLine(jsonString);

            // Deserialize
            var product2 = JsonConvert.DeserializeObject<Product>(jsonString);

            System.Console.WriteLine($"The name is "+product2.Name);
            System.Console.WriteLine($"The ID is "+product2.ID);
            System.Console.WriteLine($"The price is is "+product2.Price);
        }
    }

    // Create model class
    class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
