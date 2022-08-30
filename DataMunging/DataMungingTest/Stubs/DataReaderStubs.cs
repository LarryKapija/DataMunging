
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DataMungingLibrary.Interfaces.Services;
using DataMungingLibrary.Models;
using DataMungingLibrary.Utils;
using DataMungingLibray.Bases.Repos;
using static DataMungingTest.Utils.Constants;
using static DataMungingLibrary.Utils.Helpers.FieldsMapper;

namespace DataMungingTest.Stubs
{
    class DataReaderStub : DataReaderBase
    {

        public override IEnumerable<Category> GetCategoriesFromCSV()
        {
            IEnumerable<Category> categories;

            var stream = GetFileStream(FilesPaths.categoriesCSV);

            var lines = stream.ReadLines();

            if (lines == null) throw new NullReferenceException();

            categories = FillByLines<Category>(lines);
            if (categories == null || categories.Count() == 0) throw new NullReferenceException("The categories are empty");
            return categories;
        }

        public override IEnumerable<Spent> GetExpensesFromCSV()
        {
            IEnumerable<Spent> expenses;

            var stream = GetFileStream(FilesPaths.expensesCSV);
            
            var lines = stream.ReadLines();

            if (lines == null) throw new NullReferenceException();

            expenses = FillByLines<Spent>(lines);
            if (expenses == null || expenses.Count() == 0) throw new NullReferenceException("The expenses are empty");
            return expenses;
        }

        public override IEnumerable<Category> GetCategoriesFromStringInput()
        {
            IEnumerable<Category> categories;
            var lines = FilesContent.categories.SplitByNewLine();

            if (lines == null) throw new NullReferenceException();

            categories = FillByLines<Category>(lines);
            if (categories == null || categories.Count() == 0) throw new NullReferenceException("The categories are empty");
            return categories;
        }

        public override IEnumerable<Spent> GetExpensesFromStringInput()
        {
            IEnumerable<Spent> expenses;

            var lines = FilesContent.expenses.SplitByNewLine();

            if (lines == null) throw new NullReferenceException();

            expenses = FillByLines<Spent>(lines);
            if (expenses == null || expenses.Count() == 0) throw new NullReferenceException("The expenses are empty");
            return expenses;
        }

        private Stream GetFileStream(string filePath)
        {
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);

            if(stream == null || stream.Length == 0) throw new NullReferenceException("The stream is empty");

            return stream;
        }
    }
}