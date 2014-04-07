using System;
using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomDateTests
	{
		[Test]
		public void Test_DateBetween()
		{
			var randomized = new RandomDate(new FakeRandom(10));
			var lower = new DateTime(2014, 1, 1);
			var upper = new DateTime(2014, 6, 30);
			var expected = new DateTime(2014, 5, 25);

			var random = randomized.DateBetween(lower, upper);

			random.Date.Should().Be(expected);
		}
	}
}