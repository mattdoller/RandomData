using System;
using FluentAssertions;
using NUnit.Framework;

namespace RandomData.Tests
{
	[TestFixture]
	public class RandomBooleanTests
	{
		[Test]
		public void Test_Random_True()
		{
			var randomized = new RandomBoolean(100);
			randomized.Boolean().Should().Be(true);
		}

		[Test]
		public void Test_Random_False()
		{
			var randomized = new RandomBoolean(101);
			randomized.Boolean().Should().Be(false);
		}
	}
}

