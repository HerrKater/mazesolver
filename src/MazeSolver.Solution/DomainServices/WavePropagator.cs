using System;
using WealthKernel.Solution.DomainModel.Entities;
using WealthKernel.Solution.DomainModel.ValueObjects;
using WealthKernel.Solution.DomainServices.Interfaces;

namespace WealthKernel.Solution.DomainServices
{
    /// <summary>
    ///     Uses the wave propagation algorithm to create a "map" for the maze.
    ///     The "waves" start from the entrypoint and reaches every accessable field in the maze.
    ///     Each field gets a number, which is the number of the steps required to take from the entry point.
    /// </summary>
    public class WavePropagator : IWavePropagator
    {
        public WaveMazeDistanceMap CreateMap(Maze mazeToSolve, MazeEntryPointEnum entryPoint)
        {
            if(mazeToSolve==null)
                throw new ArgumentNullException(nameof(mazeToSolve));
            var arrayRepresentation = mazeToSolve.GetInnerRepresentation();
            switch (entryPoint)
            {
                case MazeEntryPointEnum.A:
                    PropagateWave(arrayRepresentation, 0, mazeToSolve.CloumnCount - 1, 1);
                    break;
                case MazeEntryPointEnum.B:
                    PropagateWave(arrayRepresentation, mazeToSolve.RowCount - 1, 0, 1);
                    break;
                case MazeEntryPointEnum.C:
                    PropagateWave(arrayRepresentation, mazeToSolve.RowCount - 1, mazeToSolve.CloumnCount - 1, 1);
                    break;
            }
            return new WaveMazeDistanceMap(arrayRepresentation, entryPoint);
        }

        /// <summary>
        ///     Recursively traverses the maze and sets the distances of each field
        ///     for each point:
        ///     - if the field is not a wall set the distance to sourceDistance+1
        ///     - if there is a neighbour field which is not a wall(0) and not visited(>1) ie 1, recurse
        /// </summary>
        private void PropagateWave(int[,] maze, int currentRow, int currentColumn, int sourceValue)
        {
            //todo: have the columncount and the rowcount as parameters
            var rowCount = maze.GetLength(0);
            var columnCount = maze.GetLength(1);

            var currentValue = sourceValue + 1;
            //if the field is not a "wall"
            if (maze[currentRow, currentColumn] != 0)
                maze[currentRow, currentColumn] = currentValue;
            //Searching for the next non visited, non wall field
            //UP
            if (currentRow > 0 && maze[currentRow - 1, currentColumn] == 1)
            {
                PropagateWave(maze, currentRow - 1, currentColumn, currentValue);
            }
            //DOWN
            if (currentRow + 1 < rowCount && maze[currentRow + 1, currentColumn] == 1)
            {
                PropagateWave(maze, currentRow + 1, currentColumn, currentValue);
            }
            //LEFT
            if (currentColumn > 0 && maze[currentRow, currentColumn - 1] == 1)
            {
                PropagateWave(maze, currentRow, currentColumn - 1, currentValue);
            }
            //RIGHT
            if (currentColumn + 1 < columnCount && maze[currentRow, currentColumn + 1] == 1)
            {
                PropagateWave(maze, currentRow, currentColumn + 1, currentValue);
            }
        }
    }
}