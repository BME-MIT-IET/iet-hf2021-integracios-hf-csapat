Feature: SkipList
	The Skip-List data structure implementation. 
	Uses the custom class SkipListNode<T>.

@instantiate
Scenario: Instantiate
	Given a new list is created
	Then the list should be empty
	And the list's element count should be 0
	And the list's level should be between 1 and 1
	And the list's root should be 0

@add
Scenario: Add element then check if it's contained
	Given a new list is created
	And the following element is added: 42
	Then the list should contain 42

@add
Scenario: Add element
	Given a new list is created
	And the following element is added: 42
	Then the list should not be empty
	And the list's element count should be 1
	And the list's level should be between 1 and 2
	And the list's root should be 0

@addAndRemove
Scenario: Add then remove element
	Given a new list is created
	And the following element is added: 42
	And the following element is removed: 42
	Then the result of removing should have been true
	And the list should be empty
	And the list's element count should be 0
	And the list's level should be between 1 and 2
	And the list's root should be 0

@addAndRemove
Scenario: Add then remove, but preserve element
	Given a new list is created
	And the following element is added: 42
	And the following element is removed and preserved: 42
	Then the result of removing should have been true
	And the list should be empty
	And the list's element count should be 0
	And the list's level should be between 1 and 2
	And the list's root should be 0
	And the removed element should be 42
	And the result of removing should have been true

@addAndRemove
Scenario: Remove element not in list and try to preserve it
	Given a new list is created
	And the following element is added: 42
	And the following element is removed and preserved: 123
	Then the list should not be empty
	And the list's element count should be 1
	And the list's level should be between 1 and 2
	And the list's root should be 0
	And the result of removing should have been false