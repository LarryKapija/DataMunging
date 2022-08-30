using System.Linq;
using System.Reflection;
using DataMungingLibrary.Utils;
using NUnit.Framework;
using static DataMungingTest.Utils.Constants;

namespace DataMungingTest.Tests
{
    public class ExtensionsTests : TestsBase
    {
        [Description("Testing the SplitByNewLine string extension")]
        [TestCase(FilesContent.categories, ExpectedResult=3)]
        [TestCase(FilesContent.expenses, ExpectedResult=7)]
        public int SplitByNewLineTest(string csvContent)
        {
            return csvContent.SplitByNewLine().Length;
        }

        [Description("Testing the ReadLines stream extension")]
        [TestCase(FilesPaths.categoriesCSV, ExpectedResult=3)]
        [TestCase(FilesPaths.expensesCSV, ExpectedResult=7)]
        public int ReadLinesTest(string filePath)
        {
            return  Assembly.GetExecutingAssembly()
            .GetManifestResourceStream(filePath)
            .ReadLines().Count();
        }
    }
}