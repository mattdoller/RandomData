using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomBooleanTests
	{
		[Test]
		public void Test_Random_True()
		{
			var randomized = new RandomBoolean(new FakeRandom());
			randomized.Boolean().Should().Be(true);
		}

		[Test]
		public void Test_Random_False()
		{
			var randomized = new RandomBoolean(new FakeRandom());
			randomized.Boolean().Should().Be(false);
		}
	}
}

