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
	[Scope(Feature = "SkipList")]
	public sealed class SkipListStepDefinitions
	{
		private readonly ScenarioContext _scenarioContext;
		private SkipList<int> _list;
		private int _removedElement;
		private bool _removeSucceeded;

		public SkipListStepDefinitions(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
		}

		[Given("a new list is created")]
		public void GivenANewListIsCreated()
		{
			_list = new SkipList<int>();
		}

		[Given("the following element is added: (.*)")]
		public void GivenTheFollowingElementIsAdded(int element)
		{
			_list.Add(element);
		}

		[Given("the following element is removed: (.*)")]
		public void GivenTheFollowingElementIsRemoved(int element)
		{
			_removeSucceeded = _list.Remove(element);
		}

		[Given("the following element is removed and preserved: (.*)")]
		public void GivenTheFollowingElementIsRemovedAndPreserved(int element)
		{
			_removeSucceeded = _list.Remove(element, out _removedElement);
		}

		[Then("the list should be empty")]
		public void ThenTheListShouldBeEmpty()
		{
			_list.IsEmpty.Should().BeTrue();
		}

		[Then("the list should not be empty")]
		public void ThenTheListShouldNotBeEmpty()
		{
			_list.IsEmpty.Should().BeFalse();
		}

		[Then("the list's element count should be (.*)")]
		public void ThenTheListsElementCountShouldBe(int number)
		{
			_list.Count.Should().Be(number);
		}

		[Then("the list's level should be between (.*) and (.*)")]
		public void ThenTheListsLevelShouldBeBetween(int from, int to)
		{
			// Levels are added randomly based on a probabilty
			// so we can only test if it's in the corrent range.

			_list.Level.Should().BeGreaterOrEqualTo(from);
			_list.Level.Should().BeLessOrEqualTo(to);
		}

		[Then("the list's root should be (.*)")]
		public void ThenTheListsRootShouldBe(int number)
		{
			_list.Root.Should().Be(new SkipListNode<int>(number, 32));
		}

		[Then("the removed element should be (.*)")]
		public void ThenTheRemovedElementShouldBe(int number)
		{
			_removedElement.Should().Be(number);
		}

		[Then("the result of removing should have been (.*)")]
		public void ThenTheResultOfRemovingShouldHaveBeen(bool didRemoveSucceed)
		{
			_removeSucceeded.Should().Be(didRemoveSucceed);
		}

		[Then("the list should contain (.*)")]
		public void ThenTheListShouldContain(int number)
		{
			_list.Contains(number).Should().Be(true);
		}
	}
}
