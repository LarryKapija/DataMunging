using System;
using DataMungingLibrary.Attributes;

namespace DataMungingLibrary.Models
{
    public class Category
    {
        [CsvPosition(0)]
        public string ID { get; set; }

        [CsvPosition(1)]
        public string Name { get; set; }

        [CsvPosition(2)]
        public string ExpensibleKey { get; set; }

        public bool IsExpensible => ExpensibleKey.ToLowerInvariant().Equals("y");

        public Category() { }

        public Category(string id, string name, string isExpensible)
        {
            ID = id;
            Name = name;
            ExpensibleKey = isExpensible;
        }
    }
}

