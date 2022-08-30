using System;
using DataMungingLibrary.Models;
using System.Collections.Generic;

namespace DataMungingLibrary.Interfaces.Repos
{
    public interface IDataReader
    {
        IEnumerable<Category> GetCategoriesFromCSV();
        IEnumerable<Spent> GetExpensesFromCSV();

        IEnumerable<Category> GetCategoriesFromStringInput();
        IEnumerable<Spent> GetExpensesFromStringInput();
    }
}

