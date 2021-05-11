using DataStructures.Graphs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Graphs
{
    public interface IShortestPath<TVertex>
    {
        /// <summary>
        ///     Determines whether there is a path from the source vertex to this specified vertex.
        /// </summary>
        bool HasPathTo(TVertex destination);

        /// <summary>
        ///     Returns the distance between the source vertex and the specified vertex.
        /// </summary>
        long DistanceTo(TVertex destination);

        /// <summary>
        ///     Returns an enumerable collection of nodes that specify the shortest path from the source vertex to the destination vertex.
        /// </summary>
        IEnumerable<TVertex> ShortestPathTo(TVertex destination);
    }
}
