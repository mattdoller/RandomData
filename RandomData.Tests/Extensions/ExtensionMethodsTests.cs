using System.Linq;
using NUnit.Framework;
using System;
using FluentAssertions;
using RandomData.Extensions;

namespace RandomData.Tests.Extensions
{
	[TestFixture]
	public class ExtensionMethodsTests
	{
		private FakeRandom random;

		[SetUp]
		public void SetUp()
		{
			random = new FakeRandom(3);
		}

		[Test]
		public void Test_PickFrom_Picks_Single_Item()
		{
			var array = new[] { "one", "two", "three", "four", "five" };
			random.PickFrom(array).Should().Be("one");
		}

		[Test]
		public void Test_PickFrom_ArgumentNullException()
		{
			Action action = () => random.PickFrom((int[]) null);
			action.ShouldThrow<ArgumentNullException>();
		}

		[Test]
		public void Test_PickFrom_Empty_Array_Throws_ArgumentException()
		{
			Action action = () => random.PickFrom(new string[0]);
			action.ShouldThrow<ArgumentException>();
		}
	}
}
