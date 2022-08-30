using System;
namespace DataMungingLibrary.Interfaces.Services
{
    public interface IConsoleManager
    {
        void Write(object value);
        void WriteLine(object value);
        void Clear();

        ConsoleKeyInfo ReadKey();
        string ReadLine();
    }
}

