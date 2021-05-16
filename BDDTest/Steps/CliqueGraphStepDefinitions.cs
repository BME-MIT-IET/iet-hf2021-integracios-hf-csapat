using DataStructures.Graphs;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDTest.Steps
{
	[Binding]
	[Scope(Feature = "CliqueGraph")]
	public sealed class CliqueGraphStepDefinitions
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		private readonly ScenarioContext _scenarioContext;
		private CliqueGraph<string> _cliqueGraph;
		private string[] _vertices;

		public CliqueGraphStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Given("the graph is empty")]
		public void GivenTheGraphIsEmpty()
		{
			_cliqueGraph = new CliqueGraph<string>();
		}

		[Given("the vertices are (.*)")]
		public void GivenTheVerticesAre(string vertices)
		{
			_vertices = vertices.Split(",");
		}

		[When("a graph is instantiated with vertices: (.*)")]
		public void WhenGraphIsInstantiatedWithVertices(string vertices)
		{
			_cliqueGraph = new CliqueGraph<string>(vertices.Split(","));
		}

		[When("a graph is instantiated with null")]
		public void WhenGraphIsInstantiatedWithNull()
		{
			List<string> nullList = null;
			_cliqueGraph = new CliqueGraph<string>(nullList);
		}

		[When("these vertices are added (.*)")]
		public void WhenTheseVerticesAreAdded(string vertices)
		{
			_cliqueGraph.AddVertices(vertices.Split(","));
		}

		[When("this vertex is added (.*)")]
		public void WhenThisVertexIsAreAdded(string vertex)
		{
			_cliqueGraph.AddVertex(vertex);
		}

		[Then("the graph's vertices should be (.*)")]
		public void ThenTheGraphsVerticesShouldBe(string expectedVertices)
		{
			_cliqueGraph.Vertices.Should().BeEquivalentTo(expectedVertices.Split(","));
		}

		[Then("getting the graph's vertices should return null")]
		public void ThenTheGraphsVerticesShouldBeNull()
		{
			_cliqueGraph.Vertices.Should().BeEmpty();
		}

		[Then("isComplete should be (.*)")]
		public void ThenIsCompleteShouldBe(bool isComplete)
		{
			_cliqueGraph.isComplete(_vertices).Should().Be(isComplete);
		}

	}
}
