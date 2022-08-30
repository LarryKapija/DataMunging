using System;
using System.Collections.Generic;
using DataMungingLibrary.Interfaces.Repos;
using DataMungingLibrary.Models;

namespace DataMungingLibray.Bases.Repos
{
    public abstract class DataReaderBase : IDataReader
    {
        public abstract IEnumerable<Category> GetCategoriesFromCSV();

        public abstract IEnumerable<Category> GetCategoriesFromStringInput();

        public abstract IEnumerable<Spent> GetExpensesFromCSV();

        public abstract IEnumerable<Spent> GetExpensesFromStringInput();
    }
}

