using System;
using FluentAssertions;
using NUnit.Framework;

namespace RandomData.Tests
{
	[TestFixture]
	public class RandomNetTests
	{
		private RandomNet randomizer;

		[SetUp]
		public void SetUp()
		{
			randomizer = new RandomNet(100);
		}

		[Test]
		public void Test_IPv4()
		{
			randomizer.IPv4().Should().Be("144.17.91.161");
		}

		[Test]
		public void Test_IPv4_Matches_Regex()
		{
			randomizer = new RandomNet();
			randomizer.IPv4().Should().MatchRegex(@"\d.\d.\d.\d");
		}
	}
}

