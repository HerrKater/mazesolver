using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WealthKernel.Solution.DomainModel.Entities;
using WealthKernel.Solution.DomainServices.Interfaces;
using WealthKernel.Solution.Exceptions;
using WealthKernel.Solution.ResourceAccess.Interfaces;

namespace WealthKernel.Solution.DomainServices
{
    /// <summary>
    ///     Reads the lines from a filereader and creates the Maze object
    /// </summary>
    public class MazeParser : IMazeParser
    {
        public Maze Read(IFileReader fileReader)
        {
            if(fileReader==null)
                throw new ArgumentNullException(nameof(fileReader));
            //getting the enumerator to prevent multiple enumeration of IEnumerable
            var linesCollection = fileReader.ReadLines();
            if(linesCollection==null)
                throw new FileIsEmptyException(fileReader.Path);
            var linesEnumerator =linesCollection.GetEnumerator();
            var dimensions = ReadDimensions(linesEnumerator, fileReader.Path);
            //allocate the maze
            var cols = dimensions[0];
            var rows = dimensions[1];
            var maze = new int[rows, cols];
            //read all the lines
            int rowIndex = 0, colIndex = 0;
            while (linesEnumerator.MoveNext())
            {
                foreach (var c in linesEnumerator.Current)
                {
                    if (c != '0' && c != '1')
                        throw new InvalidMazeException(rowIndex,colIndex);
                    maze[rowIndex, colIndex] = c == '0' ? 0 : 1;
                    colIndex++;
                }
                if(colIndex!=cols)
                    throw new InvalidDimensionException($"Column count mismatch. Expected column count {cols} , actual: {colIndex}, line: {rowIndex}");
                colIndex = 0;
                rowIndex++;
            }
            if(rowIndex!=rows)
                throw new InvalidDimensionException($"Row count mismatch. Expected row count:{rows}, actual:{rowIndex}");

            if (rowIndex == 0)
                throw new InvalidDimensionException("There are no rows in the maze");
            return new Maze(maze);
        }


        private int[] ReadDimensions(IEnumerator<string> linesEnumerator, string path)
        {
            //reading the array size
            if (!linesEnumerator.MoveNext() || string.IsNullOrEmpty(linesEnumerator.Current))
            {
                throw new FileIsEmptyException(path);
            }
            //validate dimension
            var numersUnparsed = linesEnumerator.Current.Split(' ');
            if (numersUnparsed.Length != 2)
                throw new InvalidDimensionException("The number of the dimensions should be 2" + linesEnumerator.Current);
            try
            {
                var dimensions = numersUnparsed.Select(int.Parse).ToArray();
                return dimensions;
            }
            catch (Exception ex)
            {
                throw new InvalidDimensionException("The following dimensions are invalid" + linesEnumerator.Current);
            }
    }
    }
}