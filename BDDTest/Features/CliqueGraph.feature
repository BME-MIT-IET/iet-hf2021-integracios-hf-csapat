Feature: CliqueGraph
	Represents an unweighted undirected graph, modeling with a set of its maximal complete subgraphs of it.
	Should be fast in clustered graphs

@addVertices
Scenario: Add vertices to the graph as a list
	Given the graph is empty
	When these vertices are added |ab, bc, cd, de, ef|
	Then the graph's vertices should be |ab, bc, cd, de, ef|

@addVertices
Scenario: Add vertices to the graph one-by-one
	Given the graph is empty
	When this vertex is added ab
	And this vertex is added bc
	And this vertex is added cd
	And this vertex is added de
	And this vertex is added ef
	Then the graph's vertices should be |ab, bc, cd, de, ef|