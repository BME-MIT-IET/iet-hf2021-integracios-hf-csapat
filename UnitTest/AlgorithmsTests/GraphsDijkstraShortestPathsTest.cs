using Algorithms.Graphs;
using DataStructures.Graphs;
using System;
using System.Linq;
using Xunit;

namespace UnitTest.AlgorithmsTests
{
    public enum ShortestPathAlgorithm
    {
        DIJKSTRA,
        BELLMAN_FORD,
        BREADTH_FIRST,
    }

    public class ShortestPathsTest
    {
        private static IShortestPath<string> CreateAlgorithm(ShortestPathAlgorithm algEnum, DirectedWeightedSparseGraph<string> Graph, string Source)
        {
            switch (algEnum)
            {
                case ShortestPathAlgorithm.DIJKSTRA: return new DijkstraShortestPaths<DirectedWeightedSparseGraph<string>, string>(Graph, Source);
                case ShortestPathAlgorithm.BELLMAN_FORD: return new BellmanFordShortestPaths<DirectedWeightedSparseGraph<string>, string>(Graph, Source);
                case ShortestPathAlgorithm.BREADTH_FIRST: return new BreadthFirstShortestPaths<string>(Graph, Source);
            }
            throw new ArgumentException("unkown algorithm: " + algEnum);
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void Constructor_Throw_WhenGraphInNull(ShortestPathAlgorithm alg)
        {
            Assert.Throws<ArgumentNullException>(() => CreateAlgorithm(alg, null, "vertex"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void Constructor_Throw_WhenSourceVertexIsNull(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            Assert.Throws<ArgumentNullException>(() => CreateAlgorithm(alg, graph, null));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void Constructor_Throw_WhenSourceIsNotPartOfGraph(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");
            graph.AddVertex("d");
            Assert.Throws<ArgumentException>(() => CreateAlgorithm(alg, graph, "x"));
        }

        // Only running with DIJKSTRA, as it is the only one allowing negative edges
        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        public void Constructor_Throw_WhenAnyEdgeWeightIsLessThanZeroShortestPathAlgorithm(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");

            graph.AddEdge("a", "b", -1);

            Assert.Throws<ArgumentException>(() => CreateAlgorithm(alg, graph, "a"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void ShortestPathTo_Throw_WhenDestinationIsNotInGraph(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");
            graph.AddVertex("d");

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            Assert.Throws<ArgumentException>(() => dijkstra.ShortestPathTo("z"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void ShortestPathTo_ReturnNull_WhenDestinationIsNotAchievable(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");
            graph.AddVertex("d");

            graph.AddEdge("a", "b", 1);
            graph.AddEdge("b", "c", 1);
            graph.AddEdge("c", "a", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            Assert.Null(dijkstra.ShortestPathTo("d"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void ShortestPathTo_ReturnSingleVertex_WhenDestinationIsSameAsSource(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");
            graph.AddVertex("d");

            graph.AddEdge("a", "b", 1);
            graph.AddEdge("b", "c", 1);
            graph.AddEdge("c", "a", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            var result = dijkstra.ShortestPathTo("a");
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("a", result.Single());
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void ShortestPathTo_FindShortestPath_WhenThereIsOnlyOnePath(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");
            graph.AddVertex("d");

            graph.AddEdge("a", "b", 1);
            graph.AddEdge("b", "c", 1);
            graph.AddEdge("a", "c", 1);
            graph.AddEdge("c", "d", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            var result = dijkstra.ShortestPathTo("d");
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Contains("a", result);
            Assert.Contains("c", result);
            Assert.Contains("d", result);
            Assert.Equal(2, dijkstra.DistanceTo("d"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void ShortestPathTo_FindShortestPath_WhenThereIsPossibleMultiplePaths(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");
            graph.AddVertex("d");

            graph.AddEdge("a", "b", 1);
            graph.AddEdge("b", "c", 1);
            graph.AddEdge("c", "a", 1);
            graph.AddEdge("c", "d", 1);
            graph.AddEdge("b", "d", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            var result = dijkstra.ShortestPathTo("d");
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
            Assert.Contains("a", result);
            Assert.Contains("b", result);
            Assert.Contains("d", result);
            Assert.Equal(2, dijkstra.DistanceTo("d"));
        }

        // Not running with BREADTH_FIRST, it does not support weights
        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        public void ShortestPathTo_FindShortestPath_WhenEdgeHaveDifferentWeight(ShortestPathAlgorithm alg)
        {
            var vertices = new[] { "r", "s", "t", "x", "y", "z" };
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertices(vertices);

            graph.AddEdge("r", "s", 7);
            graph.AddEdge("r", "t", 6);
            graph.AddEdge("s", "t", 5);
            graph.AddEdge("s", "x", 9);
            graph.AddEdge("t", "x", 10);
            graph.AddEdge("t", "y", 7);
            graph.AddEdge("t", "z", 5);
            graph.AddEdge("x", "y", 2);
            graph.AddEdge("x", "z", 4);
            graph.AddEdge("y", "z", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "s");
            var shortestToZ = dijkstra.ShortestPathTo("z");
            Assert.NotNull(shortestToZ);
            Assert.Equal(3, shortestToZ.Count());
            Assert.Contains("s", shortestToZ);
            Assert.Contains("t", shortestToZ);
            Assert.Contains("z", shortestToZ);
            Assert.Equal(10, dijkstra.DistanceTo("z"));

            var shortestToY = dijkstra.ShortestPathTo("y");
            Assert.NotNull(shortestToY);
            Assert.Equal(3, shortestToY.Count());
            Assert.Contains("s", shortestToY);
            Assert.Contains("x", shortestToY);
            Assert.Contains("y", shortestToY);
            Assert.Equal(11, dijkstra.DistanceTo("y"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void HasPathTo_Throw_WhenVertexIsNotInGraph(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");

            graph.AddEdge("a", "b", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            Assert.Throws<ArgumentException>(() => dijkstra.HasPathTo("z"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void HasPathTo_ReturnTrue_WhenVertexIsAchievable(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");

            graph.AddEdge("a", "b", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            Assert.True(dijkstra.HasPathTo("b"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void HasPathTo_ReturnFalse_WhenVertexIsNotAchievable(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");

            graph.AddEdge("a", "b", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            Assert.False(dijkstra.HasPathTo("c"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void DistanceTo_Throw_WhenVertexIsNotInGraph(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");

            graph.AddEdge("a", "b", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            Assert.Throws<ArgumentException>(() => dijkstra.DistanceTo("z"));
        }

        [Theory]
        [InlineData(ShortestPathAlgorithm.DIJKSTRA)]
        [InlineData(ShortestPathAlgorithm.BELLMAN_FORD)]
        [InlineData(ShortestPathAlgorithm.BREADTH_FIRST)]
        public void DistanceTo_ReturnInfinity_WhenVertexIsNotAchievable(ShortestPathAlgorithm alg)
        {
            var graph = new DirectedWeightedSparseGraph<string>();
            graph.AddVertex("a");
            graph.AddVertex("b");
            graph.AddVertex("c");

            graph.AddEdge("a", "b", 1);

            var dijkstra = CreateAlgorithm(alg, graph, "a");
            Assert.Equal(long.MaxValue, dijkstra.DistanceTo("c"));
        }
    }
}
