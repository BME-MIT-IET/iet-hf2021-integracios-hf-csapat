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


## Open Addressing Hashtable

After running the code coverage analyzer on the project, we found out that the OpenAddressingHashTable algorithms were not tested at all. 
To ensure the quality and reliability of these algorithms we wrote unit tests. 
The unit tests are the following:

- AddValueToHashTableTest()
![](image/AddValueToHashTableTest.PNG)

To make sure the initalization of this class works properly we instantiated this class, and tested the Count property

- HashSearchTest()
![](image/HashSearchTest.PNG)

We were testing the search function of the hashTable, that returns the index of the of searched key.


- ExpandHashSizeTest()
![](image/ExpandHashSizeTest.PNG)

We were initializing the hashTable with the length of two, and added 3 elements to the table to test if the expand feature works properly, so the table does not throw exeption and returns the expected length.

- IndexingHashTest()
![](image/IndexingHashTest.PNG)

We were testing the [] indexing operator of the hashTable, if it returns the expected value.

- RemoveTest()
![](image/RemoveTest.PNG)

We were testing the Remove() function of the class, by adding an element, removing it using the key, and then checking the length of the hashTable, if it is empty. 


- IndexElementExceptionTest()
![](image/IndexElementExceptionTest.PNG)

After trying to assign value to a given key, which has not prevously been initialized the program throws a keynotfound exception. 


- ClearElementsTest()
![](image/ClearElementsTest.PNG)

We were testing the Clear() function of the class by adding several elements to the hashTable, and then clearing it, and checking if it is empty.


- ContainsElementTest()
![](image/ContainsElementTest.PNG)
We were testing the Contains() function of the class by adding an element to the hashTable, then creating another element with the same properties as the prevous element, and checking if the hashTable contains this element.


- TryGetValueTest()
![](image/TryGetValueTest.PNG)
We were testing the TryGetValue() function by adding an element to the hashTable, and calling the TryGetValue() function with the key of the added element, and checking if it returned true.


- AddElementStringKeyTest()
![](image/AddElementStringKeyTest.PNG)
We were adding elements to the hashTable, that have string keys. We were testing if these elements were properly added.


- RemoveKeyTest()
![](image/RemoveKeyTest.PNG)
We were testing the Remove() function of the class, by adding an element, removing it using the element, and then checking the length of the hashTable, if it is empty. 


## Sorting Algorithms

After running the code coverage analyzer on the project, we found out that the several sorting algorithms were not tested at all. To ensure the quality and reliability of these algorithms we wrote unit tests. 

We were testing three different sorting algorithms:
- CombSorter
- ShellSorter
- BucketSorter

![](image/CombSorter.PNG)
![](image/ShellSorter.PNG)
![](image/BucketSorter.PNG)

We were testing both the Ascending and Descending functions of the three sorters.


## PrimeHashingFamily

After running the code coverage analyzer on the project, we found out that the PrimeHashingFamily algorithms were not tested at all. 
To ensure the quality and reliability of these algorithms we wrote unit tests. 
The unit tests are the following:

- CheckHashIdenticalInt()
![](image/CheckHashIdenticalInt.PNG)
We were testing if all the 5 implemented hashing algorithms gives the same deterministic hashed value for the given integer parameter. 


- CheckInvalidHashConstruction()
![](image/CheckInvalidHashConstruction.PNG)
PrimeHashingFamily can not be initialized with 0 hashing algorithms, and we are expecting it to throw an exception.



- CheckInvalidHashFunction()
![](image/CheckInvalidHashFunction.PNG)
We were testing if using the 0. hashing algorithm throws an expected exception.


- CheckHashIdenticalString()
![](image/CheckHashIdenticalString.PNG)
We were testing if all the 5 implemented hashing algorithms gives the same deterministic hashed value for the given string parameter. 


- CheckInvalidHashFunctionString()
![](image/CheckInvalidHashFunctionString.PNG)
We were testing if hashing algorithm throws an expected exception if we are hashing on null.


