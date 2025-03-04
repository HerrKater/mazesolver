using System;
using System.Runtime.Serialization;

namespace WealthKernel.Solution.Exceptions
{
    [Serializable]
    public class FileIsEmptyException : MazeExceptionBase
    {
        public FileIsEmptyException()
        {
        }

        public FileIsEmptyException(string path) : base(path+" is empty")
        {
        }

        public FileIsEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileIsEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}