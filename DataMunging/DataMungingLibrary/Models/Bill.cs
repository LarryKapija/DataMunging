using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DataMungingLibrary.Models
{
    public class Bill
    {
        public List<Spent> Expenses { get; set; }

        public DateTime Date => Expenses.FirstOrDefault().Date;
        public string Location => Expenses.FirstOrDefault().Location;
        public decimal Total => Expenses.Sum(x => x.Cost);

        public Bill()
        {
        }

        public override string ToString()
        {
            return $"{Date.ToString("dd/MM/yyyy")}: {Location} - ${Total}";
        }
    }
}

