using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WealthKernel.Solution.Exceptions;
using WealthKernel.Solution.ResourceAccess;

namespace WealthKernel.Test.ResourceAccess
{
    [TestClass]
    public class FileReaderTest
    {
        [TestMethod]
        //assert
        [ExpectedException(typeof(PathIsNullOrEmptyException))]
        public void FileReader_TestEmptyPath()
        {
            //Act
            new FileReader("");
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileReader_TestNonExistingPath()
        {
            //Act
            new FileReader(@"X:\foo\bar");
        }

    }
}
