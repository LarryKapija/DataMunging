using System;

namespace DataMungingLibrary.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false)]
    public sealed class CsvPositionAttribute : Attribute
    {
        public int Position;

        public CsvPositionAttribute(int position)
        {
            Position = position;
        }
    }
}

