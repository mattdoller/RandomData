using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomNetTests
	{
		private RandomNet randomizer;

		[SetUp]
		public void SetUp()
		{
			randomizer = new RandomNet(new FakeRandom());
		}

		[Test]
		public void Test_IPv4()
		{
			randomizer.IPv4().Should().Be("1.2.3.5");
		}

		[Test]
		public void Test_IPv4_Matches_Regex()
		{
			randomizer.IPv4().Should().MatchRegex(@"\d.\d.\d.\d");
		}
	}
}

