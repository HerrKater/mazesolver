using System;

namespace WealthKernel.Solution.Exceptions
{
    [Serializable]
    public class InvalidDimensionException : MazeExceptionBase
    {
        public InvalidDimensionException(string s):base(s)
        {
            
        }
    }
}