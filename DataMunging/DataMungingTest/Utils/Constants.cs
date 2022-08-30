using System;
namespace DataMungingTest.Utils
{
    public static class Constants
    {
        public static class FilesPaths
        {

            public const string categoriesCSV = "DataMungingTest.Resources.CSV.Categories.csv";
            public const string expensesCSV = "DataMungingTest.Resources.CSV.Expenses.csv";
        }

        public static class FilesContent
        {
            public const string categories = "CFE,Coffee,Y\nFD,Food,Y\nPRS,Personal,N";
            public const string expenses = "Starbucks,3/10/2018,Iced Americano,4.28,CFE\nStarbucks,3/10/2018,Nitro Cold Brew,3.17,CFE\nStarbucks,3/10/2018,Souvineer Mug,8.19,PRS\nStarbucks,3/11/2018,Nitro Cold Brew,3.17,CFE\nHigh Point Market,3/11/2018,Iced Americano,2.75,CFE\nHigh Point Market,3/11/2018,Pastry,2.00,FD\nHigh Point Market,3/11/2018,Gift Card,10.00,PRS";
        }
    }
}

