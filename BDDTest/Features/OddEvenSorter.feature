Feature: OddEvenSorter
	OddEvenSorter Based on bubble sort

@sortAscending
Scenario: OddEvenSorter integer list implicit ascending sorting
	Given the random seed is 32462
	And a random list of integers is generated with length 10000
	When the integer list is sorted
	Then the integer list should be in ascending order

@sortAscending
Scenario: OddEvenSorter integer list explicit ascending sorting
	Given the random seed is 72684
	And a random list of integers is generated with length 10000
	When the integer list is sorted ascending
	Then the integer list should be in ascending order

@sortDescending
Scenario: OddEvenSorter integer list explicit descending sorting
	Given the random seed is 49316
	And a random list of integers is generated with length 10000
	When the integer list is sorted descending
	Then the integer list should be in descending order

@sortAscending
Scenario: OddEvenSorter string list implicit ascending sorting
	Given the random seed is 21632
	And the length of strings is 10
	And a random list of strings is generated with length 10000
	When the string list is sorted
	Then the string list should be in alphabetical order

@sortDescending
Scenario: OddEvenSorter string list explicit descending sorting
	Given the random seed is 21632
	And the length of strings is 10
	And a random list of strings is generated with length 10000
	When the string list is sorted descending
	Then the string list should be in reversed alphabetical order