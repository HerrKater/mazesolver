using WealthKernel.Solution.DomainModel.Entities;
using WealthKernel.Solution.ResourceAccess.Interfaces;

namespace WealthKernel.Solution.DomainServices.Interfaces
{
    /// <summary>
    ///     Creates a mase object based on the lines from the file reader
    /// </summary>
    public interface IMazeParser
    {
        Maze Read(IFileReader fileReader);
    }
}