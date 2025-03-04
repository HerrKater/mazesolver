using System;
using WealthKernel.Solution.DomainModel.ValueObjects;
using WealthKernel.Solution.DomainServices;
using WealthKernel.Solution.ResourceAccess;

namespace WealthKernel.Solution
{
    internal class Program
    {
        /// <summary>
        /// Takes a command line argument, which is the local path to the Maze file.
        /// It finds the path for each possible entry point.
        /// The program assumes that there is only one path for each entry point.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            if(args.Length==0)
                throw new ArgumentException("The path to the input file must be specified.");
            //read the data
            var fileReader = new FileReader(args[0]);
            //process the lines
            var parser = new MazeParser();
            var maze = parser.Read(fileReader);
            //solve the maze
            var mazeSolver = new MazeSolver(new WavePropagator());
            Console.WriteLine(mazeSolver.SolveMaze(maze, MazeEntryPointEnum.A));
            Console.WriteLine(mazeSolver.SolveMaze(maze, MazeEntryPointEnum.B));
            Console.WriteLine(mazeSolver.SolveMaze(maze, MazeEntryPointEnum.C));
            Console.Read();
        }
    }
}