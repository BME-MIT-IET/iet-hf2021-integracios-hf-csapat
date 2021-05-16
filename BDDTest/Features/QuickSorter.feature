Feature: QuickSorter

Link to a feature: [QuickSorter](BDDTest/Features/QuickSorter.feature)

@sortAscending
Scenario: QuickSorter integer list sorting
	Given the random seed is 42
	And a random list of length 100000 is generated
	When the list is sorted
	Then the list should be in ascending order