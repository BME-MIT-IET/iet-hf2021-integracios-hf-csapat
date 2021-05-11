# Unit tests - enhance code coverage

The were many units tests already in the code, but still, lot of files had very low or even zero code coverage.
The task was to increase the coverage of some of these low coverage files.

A snippet of the coverage report, after cloning the project:
![](image/code_cov_before.png)

## Shortest paths algorithms

There are 3 shortest paths algorithms implemented in the project:

- Dijkstra
- Bellman-Ford
- Breadth first

Although all of them have the same interface (HasPathTo, DistanceTo, ShortestPathTo), only Dijkstra had a comprehensive test coverage. The task was to refactor `UnitTest/AlgorithmsTests/GraphsDijkstraShortestPathsTest.cs` tests to be executed on all three algorithms.

First, all the algorithm classes made to implement a new interface called `IShortestPath`. Then each test method got parameterized to execute the same test on the three different implementations. Some tests are only executed on one or two of these implementations as not all of them support the same kind of graphs (Dijkstra does not support negative edges, BreadthFirst does not support weights). After executing the tests, several got failed: they were expecting `ArgumentException` but got `Exception`. After replacing all `Exception`s with `ArgumentException` (which made actually sense) two tests were still failing. They were two little bugs:

- BellmanFordShortestPaths initalized its `_edgeTo` array with wrong size, causing an `IndexOutOfRangeException`
- In _checkOptimalityConditions checking whether each edge is relaxed did not handle Infinity if a vertex had infinity distance

 After fixing these bugs, all tests executed successfully.

As a result the code was improved in several ways:
- More unit test coverage
- A bugfix in BellmanFordShortestPaths
- More consistency between shortest path algorithms (implementing the same interface, throwing the same type of exceptions)
