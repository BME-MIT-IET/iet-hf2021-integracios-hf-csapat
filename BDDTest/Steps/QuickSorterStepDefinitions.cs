using Algorithms.Sorting;
using System;
using System.Collections.Generic;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BDDTest.Steps
{
	[Binding]
	public sealed class QuickSorterStepDefinitions
	{

		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		private readonly ScenarioContext _scenarioContext;
		private List<int> list = new List<int>();
		private Random random;

		public QuickSorterStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Given("the random seed is (.*)")]
		public void GivenTheRandomSeedIs(int randomSeed)
		{
			random = new Random(randomSeed);
		}

		[Given("the list is of length (.*)")]
		public void GivenListIsOfLength(int length)
		{
			for (int i = 0; i < length; i++)
			{
				list.Add(random.Next());
			}
		}

		[When("the list is sorted")]
		public void WhenTheListIsSorted()
		{
			list.QuickSort<int>();
		}

		[Then("the list should be in ascending order")]
		public void ThenTheListShouldBeAscending()
		{
			list.Should().BeInAscendingOrder(x => x);
		}
	}
}
