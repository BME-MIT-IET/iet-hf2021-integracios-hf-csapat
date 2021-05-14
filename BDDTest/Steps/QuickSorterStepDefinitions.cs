using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDDTest.Steps
{
	[Binding]
	[Scope(Feature = "QuickSorter")]
	public sealed class QuickSorterStepDefinitions
	{

		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		private readonly ScenarioContext _scenarioContext;
		private List<int> _list = new List<int>();
		private Random _random;

		public QuickSorterStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Given("the random seed is (.*)")]
		public void GivenTheRandomSeedIs(int randomSeed)
		{
			_random = new Random(randomSeed);
		}

		[Given("a random list of length (.*) is generated")]
		public void GivenListIsOfLength(int length)
		{
			for (int i = 0; i < length; i++)
			{
				_list.Add(_random.Next());
			}
		}

		[When("the list is sorted")]
		public void WhenTheListIsSorted()
		{
			_list.QuickSort<int>();
		}

		[Then("the list should be in ascending order")]
		public void ThenTheListShouldBeAscending()
		{
			_list.Should().BeInAscendingOrder(x => x);
		}
	}
}
