using System.Collections.Generic;
using WealthKernel.Solution.DomainModel.ValueObjects;
using WealthKernel.Solution.ResourceAccess.Interfaces;

namespace WealthKernel.Test.Mocks
{
    
    public class FakeFileReader : IFileReader
    {
        public enum TestCaseEnum
        {
            EmptyFile=0,
            SmallMaze_Valid=1,
            MedimMaze_Valid=2,
            InvalidCharsInDimensions=3,
            EmptyDimensionRow=4,
            SingleDimension=5,
            ExtraDimension=6,
            ColumnDimensionDoesNotMatchColumnCount=7,
            RowDimensionDoesNotMatchRowCount=8,
            MissingMaze=9,
            ShorterLines=10,
            InvalidCharsInMaze=11

        }

        private readonly TestCaseEnum testCaseNumer;

        public string Path { get; }


        public List<TestCase> TestCases = new List<TestCase>
        {
            //0  empty file
            new TestCase(),
            //1  small maze (valid)
            new TestCase
            {
                Maze = "7 5\n1110001\n0010001\n1111111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },
            //2  medium maze (valid)
            new TestCase
            {
                Maze =
                    "13 9\n1111101110111\n0010001000001\n1011111111111\n1000000010100\n1111111110101\n0010000010001\n1111101010111\n1010001000100\n1011111111111",
                Solution_A = "2D10L2U2L",
                Solution_B = "2U2R2U6R2U6L2U2L",
                Solution_C = "10L4U6R2U6L2U2L"
            },
            //3  invalid chars in dimensions
            new TestCase
            {
                Maze = "7 5a\n1110001\n0010001\n1111111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },
            //4  empty dimension
            new TestCase
            {
                Maze = "1110001\n0010001\n1111111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },

            //5  single dimension
            new TestCase
            {
                Maze = "7\n1110001\n0010001\n1111111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },

            //6  extra dimension
            new TestCase
            {
                Maze = "7 5 9\n1110001\n0010001\n1111111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },

            //7  column dimension does not match the column count
            new TestCase
            {
                Maze = "7 99\n1110001\n0010001\n1111111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },
            //8  row dimension does not match the row count
            new TestCase
            {
                Maze = "99 5\n1110001\n0010001\n1111111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },
            //9  missing maze
            new TestCase
            {
                Maze = "7 5",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },

            //10  shorter lines
            new TestCase
            {
                Maze = "7 5\n1110001\n001000\n1111111\n000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },
            //11 invalid chars in the maze
             new TestCase
            {
                Maze = "7 99\n1110001\n0012001\n1113111\n0000101\n1111101",
                Solution_A = "2D4L2U2L",
                Solution_B = "4R2U2L2U2L",
                Solution_C = "2U4L2U2L"
            },
        };

        public FakeFileReader(TestCaseEnum testCase)
        {
            this.testCaseNumer = testCase;
        }

        public IEnumerable<string> ReadLines()
        {
            return TestCases[(int)testCaseNumer].Maze?.Split('\n');
        }

        public string GetSolution(MazeEntryPointEnum entryPoint)
        {
            switch (entryPoint)
            {
                case MazeEntryPointEnum.A:
                    return TestCases[(int)testCaseNumer].Solution_A;
                case MazeEntryPointEnum.B:
                    return TestCases[(int)testCaseNumer].Solution_B;
                case MazeEntryPointEnum.C:
                    return TestCases[(int)testCaseNumer].Solution_C;
            }
            return null;
        }

        public class TestCase
        {
            public string Maze;
            public string Solution_A;
            public string Solution_B;
            public string Solution_C;
        }
    }
}