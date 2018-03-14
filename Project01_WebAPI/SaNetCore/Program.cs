using System;
using Newtonsoft.Json;

namespace SaNetCore
{
    class Program
    {

        class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
        }        

        static void Main(string[] args)
        {
            var product = new Product{ID=123, Name="Banana", Price=0.23};

            var json = JsonConvert.SerializeObject(product);
            Console.WriteLine(json);

            var product2 = JsonConvert.DeserializeObject<Product>(json);

            var json2 = JsonConvert.SerializeObject(product2);
            Console.WriteLine(json2);
        }
    }
}
