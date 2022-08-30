using System.Linq;
using System.Reflection;
using DataMungingLibrary.Interfaces.Repos;
using DataMungingTest.Stubs;
using Ninject;
using NUnit.Framework;

namespace DataMungingTest.Tests
{
    public class DataReaderTests : TestsBase
    {
        private static IDataReader _DataReader;

        protected override void SetUp()
        {        
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            _DataReader = kernel.Get<IDataReader>();
        }

        protected override void TearDown()
        {
            _DataReader = null;
        }

        [Order(0)]
        [Description("Testing if the setup is working.")]
        [Test]
        public void SetupTest()
        {
            Assert.That(_DataReader.GetType() == typeof(DataReaderStub),
                    message: "The setup is not working");
        }

        [Order(1)]
        [Description("Testing if the categories from csv file are loading correctly")]
        [Test]
        public void GetCategoriesFromCSVTest()
        {
            var categories = _DataReader.GetCategoriesFromCSV();

            Assert.AreEqual(categories.Count(),3);
        }

        [Order(2)]
        [Description("Testing if the expenses from csv file are loading correctly")]
        [Test]
        public void GetExpensesFromCSVTest()
        {
            var expenses = _DataReader.GetExpensesFromCSV();

            Assert.AreEqual(expenses.Count(),7);
        }

        [Order(3)]
        [Description("Testing if the categories from string input are loading correctly")]
        [Test]
        public void GetCategoriesFromStringInputTest()
        {
            var categories = _DataReader.GetCategoriesFromStringInput();

            Assert.AreEqual(categories.Count(),3);
        }

        [Order(4)]
        [Description("Testing if the expenses from string input are loading correctly")]
        [Test]
        public void GetExpensesFromStringInputTest()
        {
            var categories = _DataReader.GetExpensesFromStringInput();

            Assert.AreEqual(categories.Count(),7);
        }
    }
}