using Microsoft.VisualStudio.TestTools.UnitTesting;
using WealthKernel.Solution.DomainModel.Entities;

namespace WealthKernel.Test.Entities
{
    [TestClass]
    public class MazeTest
    {
        [TestMethod]
        public void Maze_ImmutabilityTest()
        {
            //Arrange
            var maze=new Maze(new [,] { {0,0},{0,0}});
            //Act
            maze.GetInnerRepresentation()[0, 0] = 1;
            //Assert
            Assert.AreEqual(maze.GetInnerRepresentation()[0, 0], 0);
        }
    }
}
