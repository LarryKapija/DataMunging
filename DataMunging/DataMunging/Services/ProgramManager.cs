using System;
using System.Linq;
using DataMungingLibrary.Models;
using DataMungingLibrary.Bases.Services;
using DataMungingLibrary.Interfaces.Repos;
using DataMungingLibrary.Interfaces.Services;
using System.Collections.Generic;

namespace DataMunging.Services
{
    public class ProgramManager : ProgramManagerBase
    {
        private readonly IConsoleManager _ConsoleManger;
        private readonly IDataReader _DataReader;
        
        private IEnumerable<Category> categories;

        public ProgramManager(IConsoleManager consoleManager, IDataReader dataReader)
        {
            _ConsoleManger = consoleManager;
            _DataReader = dataReader;
        }
        public override void Run()
        {
            categories = _DataReader.GetCategoriesFromStringInput();
            var expenses = _DataReader.GetExpensesFromStringInput();

            var bill =                              //THE SAME AS
                (from ex in expenses                // expenses.
                where FilterExpenses(ex)            // Where( x => FilterExpenses(x))
                group ex by new                     // .GroupBy( ex => new
                {                                   // {
                    ex.Location,                    //      ex.Location,
                    ex.Date                         //      ex.Date,
                }                                   // })
                into b select new Bill()            // .Select(b => new Bill()
                {                                   // {
                    Expenses = b.ToList()           //      Expenses = b.ToList()
                })                                  // })
                .OrderByDescending(x => x.Total);   //.OrderByDescending(x => x.Total);
                                                    
            foreach (var spent in bill)
            {
                _ConsoleManger.WriteLine(spent);
            }
            
            _ConsoleManger.ReadKey();
        }

        private bool FilterExpenses(Spent spent)
        {
            return categories.FirstOrDefault(c => c.ID == spent.CategoryId).IsExpensible;
        }
    }
}