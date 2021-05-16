using Algorithms.Sorting;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDTest.Steps
{
	[Binding]
	[Scope(Feature = "GnomeSorter")]
	public sealed class GnomeSorterStepDefinitions
	{

		private readonly ScenarioContext _scenarioContext;
		private List<int> _list = new List<int>();
		private Random _random;

		public GnomeSorterStepDefinitions(ScenarioContext scenarioContext)
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
			_list.Clear();

			for (int i = 0; i < length; i++)
			{
				_list.Add(_random.Next());
			}
		}

		[When("the list is sorted")]
		public void WhenTheListIsSorted()
		{
			_list.GnomeSort<int>();
		}

		[When("the list is sorted ascending")]
		public void WhenTheListIsSortedAscending()
		{
			_list.GnomeSortAscending<int>(Comparer<int>.Default);
		}

		[When("the list is sorted descending")]
		public void WhenTheListIsSortedDescending()
		{
			_list.GnomeSortDescending<int>(Comparer<int>.Default);
		}

		[Then("the list should be in ascending order")]
		public void ThenTheListShouldBeAscending()
		{
			_list.Should().BeInAscendingOrder(x => x);
		}

		[Then("the list should be in descending order")]
		public void ThenTheListShouldBeDescending()
		{
			_list.Should().BeInDescendingOrder(x => x);
		}
	}
}
