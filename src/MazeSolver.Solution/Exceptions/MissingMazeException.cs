using System;

namespace WealthKernel.Solution.Exceptions
{
    [Serializable]
    public class InvalidMazeException : MazeExceptionBase
    {
        public InvalidMazeException(int row, int col):base($"The maze contains invalid char at:[{row},{col}]")
        {
            
        }
    }
}