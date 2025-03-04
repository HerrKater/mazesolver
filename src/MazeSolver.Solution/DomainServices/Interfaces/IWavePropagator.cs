using WealthKernel.Solution.DomainModel.Entities;
using WealthKernel.Solution.DomainModel.ValueObjects;

namespace WealthKernel.Solution.DomainServices.Interfaces
{
    /// <summary>
    ///     Calculates the distances for each reachable field from the specified entry point
    /// </summary>
    public interface IWavePropagator
    {
        WaveMazeDistanceMap CreateMap(Maze maze, MazeEntryPointEnum entryPoint);
    }
}