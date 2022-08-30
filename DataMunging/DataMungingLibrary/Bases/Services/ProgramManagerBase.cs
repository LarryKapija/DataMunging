using System;
using DataMungingLibrary.Interfaces.Services;

namespace DataMungingLibrary.Bases.Services
{
    public abstract class ProgramManagerBase : IProgramManager
    {
        public abstract void Run();
    }
}

