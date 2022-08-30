using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DataMungingLibrary.Models;
using DataMungingLibrary.Utils;
using NUnit.Framework;
using static DataMungingTest.Utils.Constants;
using static DataMungingLibrary.Utils.Helpers.FieldsMapper;

namespace DataMungingTest.Tests
{
    public class HelpersTests : TestsBase
    {
        [Order(0)]
        [Description("Testing the LoadObject helper. Must fill the object bassed on the properties array (string)")]
        [TestCase(typeof(Spent),new string[]{"Starbucks","3/11/2018","Nitro Cold Brew","3.17","CFE"})]
        [TestCase(typeof(Spent), new string[]{"PRS","Personal","N"})]
        public void LoadObjectTest(Type objectType, string[] fields)
        {
            MethodInfo method = typeof(Activator).GetMethods()
                .FirstOrDefault(x => x.Name == "CreateInstance" && x.IsGenericMethod);
            
            var methodOutput = method.MakeGenericMethod(objectType)
                            .Invoke(this,null);

            LoadObject(methodOutput, fields);

            var isTheSameTypeAsPassedType = methodOutput.GetType().Equals(objectType);

            var isDefaultValue = method.MakeGenericMethod(objectType)
                            .Invoke(this,null).Equals(methodOutput);

            Assert.That(isTheSameTypeAsPassedType && !isDefaultValue,
                message: "Does not fill the object.");
        }



        [Order(1)]
        [Description("Testing the FillByLine helper. Must return a list of the passed type.")]
        [TestCase(FilesContent.expenses, typeof(Spent))]
        [TestCase(FilesContent.categories, typeof(Category))]
        public void FillByLinesTest(string csvContent, Type objectType)
        {            
            var lines = csvContent.SplitByNewLine();

            if (lines == null) throw new NullReferenceException("SplitByNewLine extension does not work");

            MethodInfo method = typeof(Helpers.FieldsMapper).GetMethod("FillByLines");
        
            var methodOutput =  method.MakeGenericMethod(objectType)
                                    .Invoke(this, new object[]{lines});

            var isAList = methodOutput.GetType()
                .GetGenericTypeDefinition()
                .IsAssignableFrom(typeof(List<>));

            var isAListOffPassedType = methodOutput.GetType().ToString()
                .Contains(objectType.Name);
                
            Assert.That(isAList && isAListOffPassedType, 
                message: "Does not fill the list of objects.");
        }
    }
}