using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Task2
{
	public class Notebook
	{
		private decimal m_price;

		/// <summary>
		/// Creates a new notebook object.
		/// </summary>
		/// <param name="manufacturer">Manufacturer must not be empty.</param>
		/// <param name="model">Model must not be empty.</param>
		/// <param name="display_size">Display size must not be empty.</param>
		/// <param name="processor">Processor must not be empty.</param>
		/// <param name="memory">Memory must not be empty.</param> 
		/// <param name="capacity">Capacity must not be empty.</param>
		/// <param name="price">Price must not be empty or negative.</param> 
		public Notebook(string manufacturer, string model, double display_size, string processor, decimal memory, decimal capacity, decimal price, Currency currency)
		{
			if (string.IsNullOrWhiteSpace(manufacturer)) 
				throw new ArgumentException("Manufacturer must not be empty.", nameof(manufacturer));
				
			if (string.IsNullOrWhiteSpace(model)) 
				throw new ArgumentException("Model must not be empty.", nameof(model));
			
			if (display_size <= 0) 
				throw new Exception("Display size must not be empty.");

			if (string.IsNullOrWhiteSpace(processor)) 
				throw new ArgumentException("Processor must not be empty.", nameof(processor));
			
			if (memory <= 0) 
				throw new Exception("Memory must not be empty.");
			
			if (capacity <= 0) 
				throw new Exception("Capacity must not be empty.");

			if (price <= 0) 
				throw new Exception("Price must not be negative.");

			Manufacturer = manufacturer;
			Model = model;
			Display_Size = display_size;
			Processor = processor;
			Memory = memory;
			Capacity = capacity;
			Price = price;
			UpdatePrice(price, currency);
			}

		/// <summary>
		/// Gets the manufacuter of the notebook.
		/// </summary>
		public string Manufacturer { get; set; }

		/// <summary>
		/// Gets the model of the notebook.
		/// </summary>
		public string Model { get; }

		/// <summary>
		/// Gets the display size of the notebook.
		/// </summary>
		public double Display_Size { get; }

		/// <summary>
		/// Gets the processor of the notebook.
		/// </summary>
		public string Processor { get; }

		/// <summary>
		/// Gets the RAM of the notebook.
		/// </summary>
		public decimal Memory  { get; }

		/// <summary>
		/// Gets the harddisk capacity of the notebook.
		/// </summary>
		public decimal Capacity { get; }

		/// <summary>
		/// Gets and sets the price of the notebook.
		/// </summary>
		public decimal Price 
		{
			get 
			{
				return m_price;
			} 

			private set 
			{
				if (value < 0)
					throw new Exception("Price must not be negative.");
				m_price = value;
			}
		}

		/// <summary>
		/// Gets the currency of this notebook's price.
		/// </summary>
		public Currency Currency { get; private set;}

		/// <summary>
		/// Gets the notebook's price in the given currency.
		/// </summary>
		public decimal GetPrice(Currency currency)
		{
			// if the price is requested in it's own currency, then simply return the stored price
			if (currency == Currency) return m_price;

			// use web service to query current exchange rate
			// request : http://download.finance.yahoo.com/d/quotes.csv?s=EURUSD=X&f=sl1d1t1c1ohgv&e=.csv
			// response: "EURUSD=X",1.0930,"12/29/2015","6:06pm",-0.0043,1.0971,1.0995,1.0899,0
			var key = string.Format("{0}{1}", Currency, currency); // e.g. EURUSD means "How much is 1 EUR in USD?".

			// create the request URL, ...
			var url = string.Format(@"http://download.finance.yahoo.com/d/quotes.csv?s={0}=X&f=sl1d1t1c1ohgv&e=.csv", key);
			// download the response as string

			var data = new WebClient().DownloadString(url);
			// split the string at ','<
			var parts = data.Split(',');
			// convert the exchange rate part to a decimal 
			var rate = decimal.Parse(parts[1], CultureInfo.InvariantCulture);

			// and finally perform the currency conversion
			return m_price * rate;
		}

		/// <summary>
		/// Updates the notebook's price.
		/// </summary>
		/// <param name="newPrice">Price must not be negative.</param>
		/// <param name="newCurrency">Currency.</param>
		public void UpdatePrice(decimal newPrice, Currency currency)
		{
			if (newPrice < 0) throw new ArgumentException("Price must not be negative.", nameof(newPrice));
			m_price = newPrice;
			Currency = currency;
		}
	}
}

