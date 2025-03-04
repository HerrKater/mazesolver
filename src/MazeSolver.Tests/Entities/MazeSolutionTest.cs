using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WealthKernel.Solution.DomainModel.Entities;

namespace WealthKernel.Test.Entities
{
    [TestClass]
    public class MazeSolutionTest
    {
        [TestMethod]
        public void MazeSolutionTest_GetShortForm_HappyPath()
        {
            //Arrange
            var objectToTest = new MazeSolution("DDLLLLUULL");
            //Act
            var result = objectToTest.GetShortForm();
            //Assert
            Assert.AreEqual("2D4L2U2L", result);
        }

        [TestMethod]
        public void MazeSolutionTest_GetShortForm_Null()
        {
            //Arrange
            var objectToTest = new MazeSolution(null);
            //Act
            var result = objectToTest.GetShortForm();
            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void MazeSolutionTest_GetShortForm_EmptyString()
        {
            //Arrange
            var objectToTest = new MazeSolution("");
            //Act
            var result = objectToTest.GetShortForm();
            //Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MazeSolutionTest_GetShortForm_InvalidChars()
        {
            //Arrange
            new MazeSolution("asdi8sufo9sd8gofdu");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MazeSolutionTest_GetShortForm_LowerCaseLetters()
        {
            //Arrange
            new MazeSolution("dduullrr");
        }
    }
}
