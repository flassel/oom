using System;
using System.IO;
using Newtonsoft.Json;

namespace Task4
{
    class Serialization
    {
        public static void Run(Product[] products)
        {
            var notebook = products[0];

            // serialize
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(products, settings));
            
            // store to desktop
            var text = JsonConvert.SerializeObject(products, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "products.json");
            File.WriteAllText(filename, text);

            // deserialize from desktop file
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<Product[]>(textFromFile, settings);
            var currency = Currency.EUR;
            foreach (var x in itemsFromFile) Console.WriteLine("{0,-40} {1,9:0.00} {2}", x.Description.Truncate(40), x.GetPrice(currency), currency);
        }
    }
}
