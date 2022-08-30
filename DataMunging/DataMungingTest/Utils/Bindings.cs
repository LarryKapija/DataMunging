
using DataMungingLibrary.Interfaces.Repos;
using DataMungingTest.Stubs;
using Ninject.Modules;

namespace DataMungingTest.Utils
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataReader>().To<DataReaderStub>();
        }
    }
}