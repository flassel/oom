using System;

namespace Task2
{
    class MainClass
	{
		public static void Main (string[] args)
		{
			var notebooks = new [] {
				new Notebook("Apple", "MacBook Pro 13", 13.3, "i5-5257U", 8, 256, 1447m, Currency.EUR),
				new Notebook("DELL", "XPS 13 2016", 13.3, "i5-6200U", 8, 256, 1295m, Currency.EUR),
				new Notebook("HP", "Spectre x360 13-4104ng", 13.3, "i5-6200U", 8, 256, 1087.19m, Currency.EUR)
			};

			for (var currency = Currency.EUR; (int)currency <= 4; currency++) {
				Console.WriteLine ("A list of Notebooks: ({0})", currency);
				Console.WriteLine ("#######################################################################################################");
				Console.WriteLine ("# Manufacturer #          Model         # Diplay Size # Processor # Memory # Capacity #     Price     #");
				Console.WriteLine ("#######################################################################################################");

				foreach (var a in notebooks) {
					Console.WriteLine ("# {0,12} # {1,22} # {2,6} inch # {3,9} # {4,3} GB # {5,5} GB # {6,9:0.00} {7} #"
						, a.Manufacturer, a.Model, a.Display_Size, a.Processor
						, a.Memory, a.Capacity, a.GetPrice(currency), currency);
				}
				Console.WriteLine ("#######################################################################################################");
				Console.WriteLine ();
			}
		}
	}
}
