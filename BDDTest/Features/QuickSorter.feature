Feature: QuickSorter

Link to a feature: [QuickSorter](BDDTest/Features/QuickSorter.feature)

@sorter
Scenario: QuickSorter integer list sorting
	Given the random seed is 42
	And the list is of length 100000
	When the list is sorted
	Then the list should be in ascending order