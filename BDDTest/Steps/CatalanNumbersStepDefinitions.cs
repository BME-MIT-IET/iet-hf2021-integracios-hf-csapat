using Algorithms.Numeric;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDTest.Steps
{
	[Binding]
	[Scope(Feature = "CatalanNumbers")]
	public sealed class CatalanNumbersStepDefinitions
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly List<BigInteger> _firstFewCatalanNumbers = new List<BigInteger>()
		{
			1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862, 16796, 58786,
			208012, 742900, 2674440, 9694845, 35357670, 129644790,
			477638700, 1767263190, 6564120420, 24466267020, 91482563640,
			343059613650, 1289904147324, 4861946401452
		};
		private int _from = 0;
		private int _to = 0;
		private int _rank = 0;
		private BigInteger _catalanNumber = 0;
		private List<BigInteger> _range = new List<BigInteger>();

		public CatalanNumbersStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[When("I get a range of catalan numbers from (.*) to (.*)")]
		public void WhenIGetARangeOfCatalanNumbers(uint from, uint to)
		{
			_from = Convert.ToInt32(from);
			_to = Convert.ToInt32(to);

			if (from <= 26 && to <= 26)
				_range = CatalanNumbers.GetRange(from, to);
			else
				_scenarioContext.Pending();
		}

		[When("I get the (.*). catalan number using binom coefficients")]
		public void WhenIGetCatalanNumberUsingBinomCoefficients(uint rank)
		{
			_rank = Convert.ToInt32(rank);

			if (rank <= 26)
				_catalanNumber = CatalanNumbers.GetNumberByBinomialCoefficients(rank);
			else
				_scenarioContext.Pending();
		}

		[Then("the range should be correct")]
		public void ThenTheRangeShouldBeCorrect()
		{
			_range.Should().BeEquivalentTo(
				_firstFewCatalanNumbers.GetRange(_from, _to - _from + 1)
			);
		}

		[Then("the range should be null")]
		public void ThenTheRangeShouldBeNull()
		{
			_range.Should().BeNull();
		}

		[Then("the number should be correct")]
		public void ThenTheNumberShouldBeCorrect()
		{
			_catalanNumber.Should().BeEquivalentTo(_firstFewCatalanNumbers[_rank]);
		}
	}
}
