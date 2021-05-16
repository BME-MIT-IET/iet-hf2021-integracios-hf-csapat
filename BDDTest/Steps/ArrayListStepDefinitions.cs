using DataStructures.Lists;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BDDTest.Steps
{
	[Binding]
	[Scope(Feature = "ArrayList")]
	public sealed class ArrayListStepDefinitions
	{
		// For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

		private readonly ScenarioContext _scenarioContext;
		private int _capacity;
		private ArrayList<string> _arrayList;

		public ArrayListStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Given("the capacity is (.*)")]
		public void GivenTheCapacityIs(int number)
		{
			_capacity = number;
		}

		[Given("the array list is created")]
		public void GivenTheArrayListIsCreated()
		{
			try
			{
				_arrayList = new ArrayList<string>(_capacity);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				_scenarioContext.Add("ArgOutOfRangeExThrown", true);
			}
		}

		[Given("the array list is filled with (.*)")]
		public void GivenTheArrayListIsFilledWith(string value)
		{
			for (int i = 0; i < _arrayList.Capacity; i++)
			{
				_arrayList.Add(value);
			}
		}

		[When("the first element is accessed")]
		public void WhenTheFirstElementIsAccessed()
		{
			try
			{
				var first = _arrayList.First;
			}
			catch (IndexOutOfRangeException ex)
			{
				_scenarioContext.Add("IdxOutOfRangeExTrown", ex.Message);
			}
		}

		[When("the last element is accessed")]
		public void WhenTheLastElementIsAccessed()
		{
			try
			{
				var last = _arrayList.Last;
			}
			catch (IndexOutOfRangeException ex)
			{
				_scenarioContext.Add("IdxOutOfRangeExTrown", ex.Message);
			}
		}

		[When("the element is accessed at index (.*)")]
		public void WhenTheElementIsAccessedAt(int index)
		{
			try
			{
				var element = _arrayList[index];
			}
			catch (IndexOutOfRangeException ex)
			{
				_scenarioContext.Add("IdxOutOfRangeExTrown", ex.Message);
			}
		}

		[When("the element is set at index (.*) as (.*)")]
		public void WhenTheElementIsSetAt(int index, string value)
		{
			try
			{
				_arrayList[index] = value;
			}
			catch (IndexOutOfRangeException ex)
			{
				_scenarioContext.Add("IdxOutOfRangeExTrown", ex.Message);
			}
		}

		[When("(.*) is added repeatedly (.*) times")]
		public void WhenTheElementIsSetAt(object value, int count)
		{
			try
			{
				_arrayList.AddRepeatedly(value.ToString(), count);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				_scenarioContext.Add("ArgOutOfRangeExThrown", true);
			}
		}
		
		[When("the element is removed at (.*)")]
		public void WhenTheElementIsRemovedAt(int index)
		{
			try
			{
				_arrayList.RemoveAt(index);
			}
			catch (IndexOutOfRangeException ex)
			{
				_scenarioContext.Add("IdxOutOfRangeExTrown", ex.Message);
			}
		}

		[Then("the result should be ArgumentOutOfRangeException")]
		public void ThenTheResultShouldBeArgOutOfRangeExcepltion()
		{
			_scenarioContext.ContainsKey("ArgOutOfRangeExThrown").Should().BeTrue();
			((bool) _scenarioContext["ArgOutOfRangeExThrown"]).Should().BeTrue();
		}

		[Then("the result should be IndexOutOfRangeException")]
		public void ThenTheResultShouldBeIndexOutOfRangeException()
		{
			_scenarioContext.ContainsKey("IdxOutOfRangeExTrown").Should().BeTrue();
		}

		[Then("the new array list should have the capacity (.*)")]
		public void ThenNewArrayListShouldHaveTheCapacity(int expectedCapacity)
		{
			_arrayList.Capacity.Should().Be(expectedCapacity);
		}

		[Then("the last element should be (.*)")]
		public void ThenTheLastElementShouldBe(string value)
		{
			_arrayList.Last.Should().Be(value);
		}
	}
}
