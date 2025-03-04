using Microsoft.VisualStudio.TestTools.UnitTesting;
using WealthKernel.Solution.DomainModel.ValueObjects;
using WealthKernel.Solution.DomainServices;
using WealthKernel.Solution.ResourceAccess;
using WealthKernel.Test.Mocks;

namespace WealthKernel.Test
{
    [TestClass]
    public class EndToEndTests
    {
        [TestMethod]
        public void TestCaseSmall_A()
        {
            DoTest(FakeFileReader.TestCaseEnum.SmallMaze_Valid, MazeEntryPointEnum.A);
        }

        [TestMethod]
        public void TestCaseSmall_B()
        {
            DoTest(FakeFileReader.TestCaseEnum.SmallMaze_Valid, MazeEntryPointEnum.B);
        }

        [TestMethod]
        public void TestCaseSmall_C()
        {
            DoTest(FakeFileReader.TestCaseEnum.SmallMaze_Valid, MazeEntryPointEnum.C);
        }

        [TestMethod]
        public void TestCaseMedium_A()
        {
            DoTest(FakeFileReader.TestCaseEnum.MedimMaze_Valid, MazeEntryPointEnum.A);
        }

        [TestMethod]
        public void TestCaseMedium_B()
        {
            DoTest(FakeFileReader.TestCaseEnum.MedimMaze_Valid, MazeEntryPointEnum.B);
        }

        [TestMethod]
        public void TestCaseMedium_C()
        {
            DoTest(FakeFileReader.TestCaseEnum.MedimMaze_Valid, MazeEntryPointEnum.C);
        }

        private void DoTest(FakeFileReader.TestCaseEnum  testCase, MazeEntryPointEnum entryPoint)
        {
            //Arrange
            var fileReader = new FakeFileReader(testCase);
            var parser = new MazeParser();
            var maze = parser.Read(fileReader);
            var mazeSolver = new MazeSolver(new WavePropagator());
            //Act
            var actualResult = mazeSolver.SolveMaze(maze, entryPoint);
            //Assert
            Assert.AreEqual(fileReader.GetSolution(entryPoint), actualResult);
        }
    }
}