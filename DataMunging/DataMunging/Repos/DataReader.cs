using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DataMungingLibrary.Utils;
using DataMungingLibrary.Models;
using DataMungingLibray.Bases.Repos;
using static DataMunging.Utils.Constants;
using static DataMungingLibrary.Utils.Helpers.FieldsMapper;

namespace DataMunging.Repos
{
    public class DataReader : DataReaderBase
    {

        #region CSV
        public override IEnumerable<Category> GetCategoriesFromCSV()
        {
            IEnumerable<Category> categories;

            var stream = GetFileStream(FilesPaths.categoriesCSV);
            var lines = stream.ReadLines();

            if (lines == null) throw new NullReferenceException();

            categories = FillByLines<Category>(lines);
            return categories;
        }

        public override IEnumerable<Spent> GetExpensesFromCSV()
        {
            IEnumerable<Spent> expenses;

            var stream = GetFileStream(FilesPaths.expensesCSV);
            var lines = stream.ReadLines();

            if (lines == null) throw new NullReferenceException();

            expenses = FillByLines<Spent>(lines);
            return expenses;
        }
        #endregion

        #region StringInput
        public override IEnumerable<Category> GetCategoriesFromStringInput()
        {
            IEnumerable<Category> categories;
            var lines = FilesContent.categories.SplitByNewLine();

            if (lines == null) throw new NullReferenceException();

            categories = FillByLines<Category>(lines);
            return categories;
        }

        public override IEnumerable<Spent> GetExpensesFromStringInput()
        {
            IEnumerable<Spent> expenses;

            var lines = FilesContent.expenses.SplitByNewLine();

            if (lines == null) throw new NullReferenceException();

            expenses = FillByLines<Spent>(lines);
            return expenses;
        }
        #endregion


        private Stream GetFileStream(string filePath)
            => Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);
    }
}

