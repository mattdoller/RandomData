using System.Linq;
using NUnit.Framework;
using System;
using FluentAssertions;
using RandomData.Extensions;
using RandomData.Generators;

namespace RandomData.Tests.Extensions
{
	[TestFixture()]
	public class ExtensionMethodsTests
	{
		private IRandomGenerator random;

		[SetUp]
		public void SetUp()
		{
			random = new FakeRandom();
		}

		[Test]
		public void Test_PickFrom_Picks_Single_Item()
		{
			var array = new[] { "one", "two", "three", "four", "five" };
			random.PickFrom(array).Should().Be("five");
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

		[Test]
		public void Test_ToChar_Throws_Exception_For_Invalid_Args()
		{
			Action action = () => 'e'.To('a');
			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void Test_ToChar()
		{
			var letters = 'a'.To('j').ToArray();
			var expected = new[] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'};
			letters.ShouldBeEquivalentTo(expected);
		}
	}
}

