using System;
using System.Globalization;
using System.Net;

namespace Task6
{
    public class Country
    {
        private decimal m_country;

        /// <summary>
        /// Creates a new notebook object.
        /// </summary>
        /// <param name="name">Manufacturer must not be empty.</param>
        /// <param name="population">Model must not be empty.</param>
        public Country(string name, decimal population)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Manufacturer must not be empty.", nameof(name));

            if (population <= 0)
                throw new Exception("Display size must not be empty.");

            Name = name;
            Population = population;
        }

        /// <summary>
        /// Gets the name of the country.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the population of the country.
        /// </summary>
        public decimal Population { get; }
    }
}

