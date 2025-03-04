namespace WealthKernel.Solution.DomainModel.Entities
{
    /// <summary>
    ///     Represents a maze where 0s are walls and 1s are the path.
    /// </summary>
    public class Maze
    {
        private readonly int[,] _innerRepresentation;

        //should only be called by the MazeParser
        public Maze(int[,] maze)
        {
            _innerRepresentation = maze;
            RowCount = _innerRepresentation.GetLength(0);
            CloumnCount = _innerRepresentation.GetLength(1);
        }

        public int RowCount { get; }
        public int CloumnCount { get; }


        /// <summary>
        ///     Returns a copy of the inner representation
        /// </summary>
        /// <returns></returns>
        public int[,] GetInnerRepresentation()
        {
            var clone = new int[RowCount, CloumnCount];
            for (var i = 0; i < RowCount; i++)
                for (var j = 0; j < CloumnCount; j++)
                    clone[i, j] = _innerRepresentation[i, j];

            return clone;
        }
    }
}