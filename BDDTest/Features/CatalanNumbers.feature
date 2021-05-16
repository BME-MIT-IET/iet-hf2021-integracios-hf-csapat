Feature: CatalanNumbers
	Simple calculator for adding two numbers

@getRange
Scenario: Get range of Catalan numbers
	When I get a range of catalan numbers from <from> to <to>
	Then the range should be <range>

	Examples:
		| from | to | range                                  |
		| 0    | 5  | 1,1,2,5,14,42                          |
		| 6    | 10 | 132,429,1430,4862,16796                |
		| 11   | 15 | 58786,208012,742900,2674440,9694845    |
		| 22   | 24 | 91482563640,343059613650,1289904147324 |

@getRange
Scenario: Get wrong range of Catalan numbers
	When I get a range of catalan numbers from 10 to 5
	Then the range should contain null

@getNumber
Scenario: Get Catalan number using the Binomial Coefficients
	When I get the <index>. catalan number using binom coefficients
	Then the number should be <catalanNumber>

	Examples:
		| index | catalanNumber |
		| 5     | 42            |
		| 10    | 16796         |
		| 15    | 9694845       |