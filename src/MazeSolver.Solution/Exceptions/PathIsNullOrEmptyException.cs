using System;
using System.Runtime.Serialization;

namespace WealthKernel.Solution.Exceptions
{
    [Serializable]
    public class PathIsNullOrEmptyException : MazeExceptionBase
    {
        public PathIsNullOrEmptyException()
        {
        }

        public PathIsNullOrEmptyException(string message) : base(message)
        {
        }

        public PathIsNullOrEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PathIsNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}