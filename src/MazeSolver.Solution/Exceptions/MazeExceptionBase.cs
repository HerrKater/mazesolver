using System;
using System.Runtime.Serialization;

namespace WealthKernel.Solution.Exceptions
{
    /// <summary>
    /// Base class for exceptions
    /// </summary>
    public abstract class MazeExceptionBase:Exception
    {
        protected MazeExceptionBase()
        {
        }

        protected MazeExceptionBase(string path) : base(path)
        {
        }

        protected MazeExceptionBase(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MazeExceptionBase(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
