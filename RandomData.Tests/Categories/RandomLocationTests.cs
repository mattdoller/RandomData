using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;
using RandomData.Generators;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomLocationTests
	{
		private RandomLocation randomized;

		[SetUp]
		public void SetUp()
		{
			randomized = new RandomLocation(new FakeRandom());
		}

		[Test]
		public void Test_ZipCode()
		{
			randomized.ZipCode().Should().Be("12358");
		}

		[Test]
		public void Test_ZipCodePlusFour()
		{
			randomized.ZipCodePlusFour().Should().Be("12358-4371");
		}
	}
}

