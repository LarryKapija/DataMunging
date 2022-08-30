using System;
using System.Globalization;
using DataMungingLibrary.Attributes;

namespace DataMungingLibrary.Models
{
    public class Spent
    {
        [CsvPosition(0)]
        public string Location { get; set; }

        [CsvPosition(1)]
        public DateTime Date { get; set; }

        [CsvPosition(2)]
        public string ItemDescription { get; set; }

        [CsvPosition(3)]
        public decimal Cost { get; set; }

        [CsvPosition(4)]
        public string CategoryId { get; set; }

        public Spent()
        {

        }

        public Spent(string location, string date, string itemDescription, string cost, string categoryId)
        {
            Location = location;
            Date = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.CurrentCulture);
            ItemDescription = itemDescription;
            Cost = decimal.Parse(cost);
            CategoryId = categoryId;
        }
    }
}

