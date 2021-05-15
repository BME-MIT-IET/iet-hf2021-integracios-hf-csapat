Feature: GnomeSorter

@sortAscending
Scenario: GnomeSorter integer list implicit ascending sorting
	Given the random seed is 68137
	And a random list of length 10000 is generated
	When the list is sorted
	Then the list should be in ascending order

@sortAscending
Scenario: GnomeSorter integer list explicit ascending sorting
	Given the random seed is 29459
	And a random list of length 10000 is generated
	When the list is sorted ascending
	Then the list should be in ascending order

@sortDescending
Scenario: GnomeSorter integer list explicit descending sorting
	Given the random seed is 54872
	And a random list of length 10000 is generated
	When the list is sorted descending
	Then the list should be in descending order