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
	[Scope(Feature = "OddEvenSorter")]
	public sealed class OddEvenSorterStepDefinitions
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

		private List<int> _intList = new List<int>();
		private List<string> _stringList = new List<string>();
		private int _stringLength = 0;
		private Random _random;

		public OddEvenSorterStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Given("the random seed is (.*)")]
		public void GivenTheRandomSeedIs(int randomSeed)
		{
			_random = new Random(randomSeed);
		}

		[Given("the length of strings is (.*)")]
		public void GivenTheLengthOfStringsIs(int lengthOfStrings)
		{
			_stringLength = lengthOfStrings;
		}

		[Given("a random list of strings is generated with length (.*)")]
		public void GivenARandomListOfStringsIsGeneratedWithLength(int lengthOfList)
		{
			_stringList.Clear();

			for (int i = 0; i < lengthOfList; i++)
			{
				var stringChars = new char[_stringLength];

				for (int j = 0; i < _stringLength; i++)
				{
					stringChars[j] = chars[_random.Next(chars.Length)];
				}

				_stringList.Add(new String(stringChars));
			}
		}

		[Given("a random list of integers is generated with length (.*)")]
		public void GivenARandomListOfIntegersIsGeneratedWithLength(int length)
		{
			_intList.Clear();

			for (int i = 0; i < length; i++)
			{
				_intList.Add(_random.Next());
			}
		}

		[When("the string list is sorted")]
		public void WhenTheStringListIsSorted()
		{
			_stringList.OddEvenSort<string>();
		}

		[When("the string list is sorted descending")]
		public void WhenTheStringListIsSortedDescending()
		{
			_stringList.OddEvenSortDescending<string>(Comparer<string>.Default);
		}

		[When("the integer list is sorted")]
		public void WhenTheIntegerListIsSorted()
		{
			_intList.OddEvenSort<int>();
		}

		[When("the integer list is sorted ascending")]
		public void WhenTheIntegerListIsSortedAscending()
		{
			_intList.OddEvenSortAscending<int>(Comparer<int>.Default);
		}

		[When("the integer list is sorted descending")]
		public void WhenTheIntegerListIsSortedDescending()
		{
			_intList.OddEvenSortDescending<int>(Comparer<int>.Default);
		}

		[Then("the integer list should be in ascending order")]
		public void ThenTheIntegerListShouldBeAscending()
		{
			_intList.Should().BeInAscendingOrder(x => x);
		}

		[Then("the integer list should be in descending order")]
		public void ThenTheIntegerListShouldBeDescending()
		{
			_intList.Should().BeInDescendingOrder(x => x);
		}

		[Then("the string list should be in alphabetical order")]
		public void ThenTheStringListShouldBeInAlphabeticalOrder()
		{
			_stringList.Should().BeInAscendingOrder();
		}

		[Then("the string list should be in reversed alphabetical order")]
		public void ThenTheStringListShouldBeInReversedAlphabeticalOrder()
		{
			_stringList.Should().BeInDescendingOrder();
		}
	}
}
