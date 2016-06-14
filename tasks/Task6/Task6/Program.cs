using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var countries = new [] {
                new Country("Austria", 8699730m),
                new Country("Germany", 81770944m),
                new Country("Italy", 60665551m),
            };

            Push_Pull.Run(countries);
        }
    }
}
