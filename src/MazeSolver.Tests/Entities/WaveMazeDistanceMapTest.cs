using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WealthKernel.Solution.DomainModel.Entities;
using WealthKernel.Solution.DomainModel.ValueObjects;

namespace WealthKernel.Test.Entities
{
    [TestClass]
    public class WaveMazeDistanceMapTest
    {
        [TestMethod]
        //Assert
        [ExpectedException(typeof(ArgumentNullException))]
        public void WaveMazeDistanceMap_Constructor_ArgumentNull()
        {
            //Act
            new WaveMazeDistanceMap(null, MazeEntryPointEnum.A);
        }

        [TestMethod]
        //Assert
        [ExpectedException(typeof(ArgumentException))]
        public void WaveMazeDistanceMap_Constructor_InvalidMap()
        {
            //arrange
            var invalidMap = new [,]
            {
                {1, 10, 5},
                {0, 2, 4},
                {0, 4, 1}
            };
            //act
            new WaveMazeDistanceMap(invalidMap, MazeEntryPointEnum.A);
        }


        [TestMethod]
        public void WaveMazeDistanceMap_ReadSolution_HappyPath()
        {
            //arrange
            var distances = new[,]
            {
                {6, 5, 6},
                {0, 4, 0},
                {0, 3, 2}
            };
            var distanceMap = new WaveMazeDistanceMap(distances, MazeEntryPointEnum.C);
            //act
            var solution = distanceMap.ReadSolution().GetShortForm();
            //assert
            Assert.AreEqual("L2UL", solution);

        }

        [TestMethod]
        public void WaveMazeDistanceMap_ReadSolution_AllWallMap()
        {
            //arrange
            var distances = new[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            var distanceMap = new WaveMazeDistanceMap(distances, MazeEntryPointEnum.C);
            //act
            var solution = distanceMap.ReadSolution().GetShortForm();
            //assert
            Assert.AreEqual("", solution);

        }


    }

}
