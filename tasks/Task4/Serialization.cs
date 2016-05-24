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

            // 1. serialize a single book to a JSON string
            Console.WriteLine(JsonConvert.SerializeObject(notebook));

            // 2. ... with nicer formatting
            Console.WriteLine(JsonConvert.SerializeObject(notebook, Formatting.Indented));

            // 3. serialize all items
            // ... include type, so we can deserialize sub-classes to interface type
            var settings = new JsonSerializerSettings() { Formatting = Formatting.Indented, TypeNameHandling = TypeNameHandling.Auto };
            Console.WriteLine(JsonConvert.SerializeObject(products, settings));

            // 4. store json string to file "items.json" on your Desktop
            var text = JsonConvert.SerializeObject(products, settings);
            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filename = Path.Combine(desktop, "products.json");
            File.WriteAllText(filename, text);

            // 5. deserialize items from "items.json"
            // ... and print Description and Price of deserialized items
            var textFromFile = File.ReadAllText(filename);
            var itemsFromFile = JsonConvert.DeserializeObject<Product[]>(textFromFile, settings);
            var currency = Currency.EUR;
            foreach (var x in itemsFromFile) Console.WriteLine("{0,-40} {1,9:0.00} {2}", x.Description.Truncate(40), x.GetPrice(currency), currency);
        }
    }
}
