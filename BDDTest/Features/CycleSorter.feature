Feature: CycleSorter
	Simple calculator for adding two numbers

@sortAscending
Scenario: CycleSorter integer list implicit ascending sorting
	Given the random seed is 75208
	And a random list of length 10000 is generated
	When the list is sorted
	Then the list should be in ascending order

@sortAscending
Scenario: CycleSorter integer list explicit ascending sorting
	Given the random seed is 94238
	And a random list of length 10000 is generated
	When the list is sorted ascending
	Then the list should be in ascending order

@sortDescendign
Scenario: CycleSorter integer list explicit descending sorting
	Given the random seed is 13602
	And a random list of length 10000 is generated
	When the list is sorted descending
	Then the list should be in descending order