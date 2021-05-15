Feature: CatalanNumbers
	Simple calculator for adding two numbers

@getRange
Scenario: Get range of Catalan numbers
	When I get a range of catalan numbers from 0 to 25
	Then the range should be correct

@getRange
Scenario: Get wrong range of Catalan numbers
	When I get a range of catalan numbers from 10 to 5
	Then the range should be null

@getNumber
Scenario: Get Catalan number using the Binomial Coefficients
	When I get the 12. catalan number using binom coefficients
	Then the number should be correct