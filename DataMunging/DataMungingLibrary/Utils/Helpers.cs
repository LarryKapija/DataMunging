using System;
using DataMungingLibrary.Attributes;
using System.Reflection;
using System.Collections.Generic;

namespace DataMungingLibrary.Utils
{
    public static class Helpers
    {
        public static class FieldsMapper 
        {
            public static void LoadObject(object target, string[] fields)
            {
                Type targetType = target.GetType();
                PropertyInfo[] properties = targetType.GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    // Make sure the property is writeable (has a Set operation)
                    if (property.CanWrite)
                    {
                        // find CSVPosition attributes assigned to the current property
                        object[] attributes = property.GetCustomAttributes(typeof(CsvPositionAttribute), false);

                        // if Length is greater than 0 we have
                        // at least one CSVPositionAttribute
                        if (attributes.Length > 0)
                        {
                            // We will only process the first CSVPositionAttribute
                            CsvPositionAttribute positionAttr = (CsvPositionAttribute)attributes[0];

                            //Retrieve the postion value from the CSVPositionAttribute
                            int position = positionAttr.Position;

                            try
                            {
                                // get the CSV data to be manipulate
                                // and written to object
                                object data = fields[position];

                                // set the value on our target object with the data
                                property.SetValue(target,
                                  Convert.ChangeType(data, property.PropertyType), null);
                            }
                            catch(Exception ex )
                            {
                                // simple error handling
                                Console.WriteLine(ex.Message);
                                throw;
                            }
                        }
                    }
                }
            }

            public static IEnumerable<T> FillByLines<T>(IEnumerable<string> lines)
            {
                var output = new List<T>();

                foreach (var line in lines)
                {
                    T item = Activator.CreateInstance<T>();

                    LoadObject(item, line.Split(","));

                    output.Add(item);
                }

                return output;
            }
        }
    }
}

