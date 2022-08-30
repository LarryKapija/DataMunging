using System;
using DataMunging.Repos;
using DataMunging.Services;
using DataMungingLibrary.Interfaces.Repos;
using DataMungingLibrary.Interfaces.Services;
using Ninject.Modules;

namespace DataMunging.Utils
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IConsoleManager>().To<ConsoleManager>();
            Bind<IProgramManager>().To<ProgramManager>();
            Bind<IDataReader>().To<DataReader>();
        }
    }
}

