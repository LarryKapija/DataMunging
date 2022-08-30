using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataMungingLibrary.Utils
{
    public static class Extensions
    {
        public static string[] SplitByNewLine(this string input)
        {
            return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static IEnumerable<string> ReadLines(this Stream streamProvider)
        {
            using (var reader = new StreamReader(streamProvider, Encoding.UTF8))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}