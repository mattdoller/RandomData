using System;
using FluentAssertions;
using NUnit.Framework;

namespace RandomData.Tests
{
	[TestFixture]
	public class RandomDateTests
	{
		[Test]
		public void Test_DateBetween()
		{
			var randomized = new RandomDate(100);
			var lower = new DateTime(1800, 1, 1);
			var upper = new DateTime(2100, 1, 1);
			var expected = new DateTime(2005, 9, 19);

			var random = randomized.DateBetween(lower, upper);

			random.Date.Should().Be(expected);
		}
	}
}