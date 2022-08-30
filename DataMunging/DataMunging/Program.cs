using System;
using System.Reflection;
using DataMungingLibrary.Interfaces.Services;
using Ninject;

namespace DataMunging
{
    class Program
    {
        private static IProgramManager _ProgramManager;

        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly()); 

            _ProgramManager = kernel.Get<IProgramManager>(); //Utils/Bindings.cs for the bindings

            _ProgramManager.Run();
        }
    }
}
