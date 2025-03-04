using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WealthKernel.Solution.DomainModel.Entities;
using WealthKernel.Solution.DomainModel.ValueObjects;
using WealthKernel.Solution.DomainServices;

namespace WealthKernel.Test.DomainServices
{
    [TestClass]
    public class WavePropagatorTest
    {
        [TestMethod]
        //assert
        [ExpectedException(typeof(ArgumentNullException))]
        public void WavePropagator_CreateMap_ArgumentNull()
        {
            //arrange
            var wavePropagator = new WavePropagator();
            //act
            wavePropagator.CreateMap(null, MazeEntryPointEnum.A);
        }

        [TestMethod]
        public void WavePropagator_CreateMap_OnlyStepSideWays()
        {
            //arrange
            var wavePropagator = new WavePropagator();
            var simpleMaze = new int[,]
            {
                { 1,0,0},
                { 0,1,0},
                { 0,0,1},
            };
            
            //act
            var solution=wavePropagator.CreateMap(new Maze(simpleMaze), MazeEntryPointEnum.A);
            //assert- test if the diagonal is visited
            Assert.AreEqual(solution[1,1],1);
        }

        [TestMethod]

        public void WavePropagator_CreateMap_AreWallsSkipped()
        {
            //arrange
            var wavePropagator = new WavePropagator();
            var simpleMaze = new int[,]
            {
                {1,0,0 },
                {0,0,0 },
                {0,0,1 }
            };
            //act
            var result=wavePropagator.CreateMap(new Maze(simpleMaze), MazeEntryPointEnum.C);
            
            //assert - test if we don't overwrite the 0s
            Assert.AreEqual(result[0,0],1);
            Assert.AreEqual(result[0, 1], 0);
            Assert.AreEqual(result[0,2], 0);
            Assert.AreEqual(result[1, 0], 0);
            Assert.AreEqual(result[1, 1], 0);
            Assert.AreEqual(result[1, 2], 0);
            Assert.AreEqual(result[2, 0], 0);
            Assert.AreEqual(result[2, 1], 0);
            Assert.AreEqual(result[2, 2], 2);
        }
    }
}
