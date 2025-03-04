using WealthKernel.Solution.DomainModel.Entities;
using WealthKernel.Solution.DomainModel.ValueObjects;
using WealthKernel.Solution.DomainServices.Interfaces;

namespace WealthKernel.Solution.DomainServices
{
    /// <summary>
    ///     Solves the maze using the passed in wavePropagator,
    ///     and returns the solutions short form.
    /// </summary>
    public class MazeSolver
    {
        private readonly IWavePropagator _wavePropagator;

        public MazeSolver(IWavePropagator wavePropagator)
        {
            _wavePropagator = wavePropagator;
        }

        public string SolveMaze(Maze maze, MazeEntryPointEnum entryPoint)
        {
            var distanceMap = _wavePropagator.CreateMap(maze, entryPoint);
            var solution = distanceMap.ReadSolution();
            var solutionShortForm = solution.GetShortForm();
            return solutionShortForm;
        }
    }
}