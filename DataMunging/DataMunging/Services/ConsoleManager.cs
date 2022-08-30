using System;
using DataMungingLibrary.Bases.Services;

namespace DataMunging.Services
{
    public class ConsoleManager : ConsoleManagerBase
    {
        public override void Clear()
         => Console.Clear();

        public override ConsoleKeyInfo ReadKey()
         => Console.ReadKey();
        
        public override string ReadLine()
         => Console.ReadLine();
        
        public override void Write(object value)
         => Console.Write(value);
        
        public override void WriteLine(object value)
         => Console.WriteLine(value);
    }
}

