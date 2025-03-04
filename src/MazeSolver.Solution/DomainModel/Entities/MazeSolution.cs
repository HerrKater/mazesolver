using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WealthKernel.Solution.DomainModel.Entities
{
    /// <summary>
    ///     Represents a path which leads out of the maze. Example: DDLLLLUULL
    /// </summary>
    public class MazeSolution
    {
        private readonly string longRepresentation;

        public MazeSolution(string longRepresentation)
        {
            if(!string.IsNullOrWhiteSpace(longRepresentation) &&!Regex.IsMatch(longRepresentation, "^[DULR]*$"))
                throw new ArgumentException("The solution should only contain: D,U,L,R chars");
            this.longRepresentation = longRepresentation;
        }

        /// <summary>
        ///     Calculates the short form of the solution,
        ///     where each letter is preceded by amount of steps in this direction
        ///     if this number is greater than one.
        ///     Example: DDLLLLUULL->2D4L2U2L
        ///     TODO: maybe it should be a domain service
        /// </summary>
        /// <returns></returns>
        public string GetShortForm()
        {
            if (string.IsNullOrWhiteSpace(longRepresentation))
                return longRepresentation;
            var shortForm = new StringBuilder();
            var prev = longRepresentation[0];
            var sequenceCount = 1;

            foreach (var c in longRepresentation.Skip(1))
            {
                if (prev == c)
                {
                    sequenceCount++;
                }
                else
                {
                    if (sequenceCount > 1)
                    {
                        shortForm.Append(sequenceCount.ToString());
                    }
                    sequenceCount = 1;
                    shortForm.Append(prev);
                }
                prev = c;
            }
            if (sequenceCount > 1)
            {
                shortForm.Append(sequenceCount.ToString());
            }
            shortForm.Append(prev);
            return shortForm.ToString();
        }
    }
}