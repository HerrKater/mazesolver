using System.Collections.Generic;
using System.IO;
using WealthKernel.Solution.Exceptions;
using WealthKernel.Solution.ResourceAccess.Interfaces;

namespace WealthKernel.Solution.ResourceAccess
{
    /// <summary>
    ///     Reads the lines from a file
    /// </summary>
    public class FileReader : IFileReader
    {
        public string Path { get; }

        public FileReader(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new PathIsNullOrEmptyException();
            if(!File.Exists(path))
                throw new FileNotFoundException("The input file cannot be found",path);
            this.Path = path;
        }

        public IEnumerable<string> ReadLines()
        {
            return File.ReadAllLines(Path);
        }
    }
}