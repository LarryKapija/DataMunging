using System;
using DataMungingLibrary.Interfaces.Services;

namespace DataMungingLibrary.Bases.Services
{
    public abstract class ConsoleManagerBase : IConsoleManager
    {
        public abstract void Clear();
        public abstract ConsoleKeyInfo ReadKey();
        public abstract string ReadLine();
        public abstract void Write(object value);
        public abstract void WriteLine(object value);
    }
}

