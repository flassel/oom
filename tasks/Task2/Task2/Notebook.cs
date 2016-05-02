using System;

namespace Task2
{
	public class Notebook
	{
		/// <summary>
		/// Creates a new notebook object.
		/// </summary>
		public Notebook(string _manufacturer, string _model, decimal _display_size, string _processor, decimal _memory, decimal _capacity, decimal price)
		{
			Notebook a = new Notebook("Apple", "MacBook Pro", "13,3", "Intel Core i5", "8GB", 
		}

		/// <summary>
		/// Gets the manufacuter of the notebook.
		/// </summary>
		public string Manufacturer { get; }

		/// <summary>
		/// Gets the model of the notebook.
		/// </summary>
		public string Model { get; }

		/// <summary>
		/// Gets the display size of the notebook.
		/// </summary>
		public decimal Display_Size { get; }

		/// <summary>
		/// Gets the processor of the notebook.
		/// </summary>
		public string Processor { get; }

		/// <summary>
		/// Gets the RAM of the notebook.
		/// </summary>
		public decimal Memory { get; }

		/// <summary>
		/// Gets the harddisk capacity of the notebook.
		/// </summary>
		public decimal Capacity { get; }

		/// <summary>
		/// Gets and sets the price of the notebook.
		/// </summary>
		public decimal Price { get; private set; }

	}
}

