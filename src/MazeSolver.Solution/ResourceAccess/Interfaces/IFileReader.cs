using System.Collections.Generic;

namespace WealthKernel.Solution.ResourceAccess.Interfaces
{
    /// <summary>
    ///     Abstracting the file access to gain more testability
    /// </summary>
    public interface IFileReader
    {
        //using IEnumerable to support lazy loading in the future
        IEnumerable<string> ReadLines();
        string Path { get; }
    }
}