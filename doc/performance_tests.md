# Performance test of some algoritms

## Comparision of sorting algorithms

There are serveral sorting algorithms implemented in the project. The performance is really important for an algorithmm, so I've done a little benchmarking. Since many of the algoritms implemented here are known to be slow, only the three most used algoritms were tested: heap sort, merge sort, quick sort. Each one was executed on the same list containing 3 000 000 random integers. For reference, the List.Sort() method of the .NET Framework is also tested.

The execution times:

| Heap sort   | 3.67s |
|-------------|-------|
| Merge sort  | 1.78s |
| Quick sort  | 1.50s |
| List.Sort() | 0.21s |

As it could be expected, none of them outperformed the .NET Framework's implementation, they are not even close. Comparing the three algorithms they are performing as usual: qucick sort is the fastest, and heap sort is the slowest.
