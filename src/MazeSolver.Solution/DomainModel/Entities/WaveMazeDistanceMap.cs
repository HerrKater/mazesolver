using System;
using System.Data.Common;
using System.Linq;
using System.Text;
using WealthKernel.Solution.DomainModel.ValueObjects;

namespace WealthKernel.Solution.DomainModel.Entities
{
    /// <summary>
    ///     A map which contains the distances from a given entry point (A,B,C) to the exit (X)
    /// </summary>
    public class WaveMazeDistanceMap
    {
        private readonly int[,] _distances;

        public WaveMazeDistanceMap(int[,] map, MazeEntryPointEnum entryPoint)
        {
            if(map==null)
                throw new ArgumentNullException(nameof(map));
            ValidateMap(map);

            _distances = map;
            EntryPoint = entryPoint;
            RowCount = _distances.GetLength(0);
            ColumnCount = _distances.GetLength(1);
        }

        /// <summary>
        /// For each field in the map the following has to to be true:
        ///     -if both the field and it's neightbour are different than 0 or 1
        ///     then the difference of their values should be 1.
        /// </summary>
        /// <param name="map"></param>
        private void ValidateMap(int[,] map)
        {
            var rowCount = map.GetLength(0);
            var columnCount = map.GetLength(1);

            //going through each field by columns and comparing to the right neighbour
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount-1; j++)
                {
                    if (map[i, j] > 1 && map[i, j + 1] > 1)
                    {
                        if(Math.Abs(map[i, j] -map[i, j + 1])!=1)
                            throw new ArgumentException("Invalid map");
                    }
                }
            }

            //going through each field by rows and comparing to the right lower neightbour
            for (int i = 0; i < rowCount-1; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    if (map[i, j] > 1 && map[i+1, j] > 1)
                    {
                        if (Math.Abs(map[i, j] - map[i+1, j]) != 1)
                            throw new ArgumentException("Invalid map");
                    }
                }
            }

        }

        public MazeEntryPointEnum EntryPoint { get; }
        public int RowCount { get; }
        public int ColumnCount { get; }
        public int this[int row,int col] => _distances[row,col];

        /// <summary>
        ///     Returns the solution based on the map.
        ///     It starts from the exit, and looks for descendin values.
        ///     The entrypoint's distance is 2, which is a bit odd, but the 0s and 1s are already taken by the walls and
        ///     unreachable paths.
        ///     TODO: multiple solutions?
        /// </summary>
        /// <returns></returns>
        public MazeSolution ReadSolution()
        {
            var currentRow = 0;
            var currentCol = 0;
            var currentValue = _distances[currentRow, currentCol];
            var solution = new StringBuilder();

            while (currentValue > 2)
            {
                //UP
                if (currentRow > 0 && _distances[currentRow - 1, currentCol] == currentValue - 1)
                {
                    currentRow--;
                    solution.Append("D");
                }
                //DOWN
                else if (currentRow + 1 < RowCount && _distances[currentRow + 1, currentCol] == currentValue - 1)
                {
                    currentRow++;
                    solution.Append("U");
                }
                //LEFT
                else if (currentCol > 0 && _distances[currentRow, currentCol - 1] == currentValue - 1)
                {
                    currentCol--;
                    solution.Append("R");
                }
                //RIGHT
                else if (currentCol + 1 < ColumnCount && _distances[currentRow, currentCol + 1] == currentValue - 1)
                {
                    currentCol++;
                    solution.Append("L");
                }
                currentValue = _distances[currentRow, currentCol];
            }
            return new MazeSolution(ReverseString(solution.ToString()));
        }

        private static string ReverseString(string solution)
        {
            return string.Join("", solution.Reverse().Select(p => p.ToString()));
        }
    }
}