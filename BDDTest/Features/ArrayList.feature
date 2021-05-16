Feature: ArrayList
	The Array-Based List Data Structure.

@instantiate
Scenario: Set capacity below 0
	Given the capacity is -1
	And the array list is created
	Then the result should be ArgumentOutOfRangeException

@instantiate
Scenario: Instantiate with capacity 
	Given the capacity is 42
	And the array list is created
	Then the new array list should have the capacity 42

@outOfRange
Scenario: Instantiate with 0 capacity and get first
	Given the capacity is 0
	And the array list is created
	When the first element is accessed
	Then the result should be IndexOutOfRangeException

@outOfRange
Scenario: Instantiate with 0 capacity and get last
	Given the capacity is 0
	And the array list is created
	When the last element is accessed
	Then the result should be IndexOutOfRangeException

@outOfRange
Scenario: Get with negative index
	Given the capacity is 10
	And the array list is created
	When the element is accessed at index -1
	Then the result should be IndexOutOfRangeException

@outOfRange
Scenario: Get with index grater than length
	Given the capacity is 10
	And the array list is created
	When the element is accessed at index 10
	Then the result should be IndexOutOfRangeException

@outOfRange
Scenario: Set with negative index
	Given the capacity is 10
	And the array list is created
	When the element is set at index -1 as value
	Then the result should be IndexOutOfRangeException

@outOfRange
Scenario: Set with index grater than length
	Given the capacity is 10
	And the array list is created
	When the element is set at index 10 as value
	Then the result should be IndexOutOfRangeException

@access
Scenario: Get last element
	Given the capacity is 10
	And the array list is created
	And the array list is filled with value
	When the element is set at index 9 as lastValue
	Then the last element should be lastValue

@outOfRange
Scenario: Add repeatedly with count less than 0
	Given the capacity is 10
	And the array list is created
	When value is added repeatedly -1 times
	Then the result should be ArgumentOutOfRangeException

@outOfRange
Scenario: Remove element with negative index
	Given the capacity is 10
	And the array list is created
	And the array list is filled with value
	When the element is removed at -1
	Then the result should be IndexOutOfRangeException

@outOfRange
Scenario: Remove element with index grater than length
	Given the capacity is 10
	And the array list is created
	And the array list is filled with value
	When the element is removed at 10
	Then the result should be IndexOutOfRangeException
