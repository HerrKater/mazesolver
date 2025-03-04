using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WealthKernel.Solution.DomainServices;
using WealthKernel.Solution.Exceptions;
using WealthKernel.Test.Mocks;

namespace WealthKernel.Test.DomainServices
{
    [TestClass]
    public class MazeParserTest
    {
        
        [TestMethod]
        //assert
        [ExpectedException(typeof(ArgumentNullException))]
        public void MazeParser_Read_NullReader()
        {
            //arrange
            var mazeParser=new MazeParser();
            //act
            mazeParser.Read(null);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(FileIsEmptyException))]
        public void MazeParser_Read_NullEmptyFile()
        {
            //arrange
            var fileReader = new FakeFileReader(0);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_InvalidCharsInDimensions()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.InvalidCharsInDimensions);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_EmptyDimension()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.EmptyDimensionRow);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_SingleDimension()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.SingleDimension);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_ExtraDimension()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.ExtraDimension);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_ColumnDimensionDoesNotMatchColumnCount()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.ColumnDimensionDoesNotMatchColumnCount);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_RowDimensionDoesNotMatchRowCount()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.RowDimensionDoesNotMatchRowCount);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_MissingMaze()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.RowDimensionDoesNotMatchRowCount);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidDimensionException))]
        public void MazeParser_Read_ShorterLines()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.ShorterLines);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

        [TestMethod]
        //assert
        [ExpectedException(typeof(InvalidMazeException))]
        public void MazeParser_Read_InvalidCharsInMaze()
        {
            //arrange
            var fileReader = new FakeFileReader(FakeFileReader.TestCaseEnum.InvalidCharsInMaze);
            var mazeParser = new MazeParser();
            //act
            mazeParser.Read(fileReader);
        }

    }

}
