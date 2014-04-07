using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

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
		public void Test_AddressLine1()
		{
			randomized.AddressLine1().Should().Be("123 Chestnut Pkwy.");
		}

		[Test]
		public void Test_AddressLine2()
		{
			randomized.AddressLine2().Should().Be("Bsmt. 235");
		}

		[Test]
		public void Test_City()
		{
			randomized.City().Should().Be("Mount Pleasant");
		}

		[Test]
		public void Test_Country()
		{
			randomized.Country().Should().Be("Albania");
		}

		[Test]
		public void Test_StateName()
		{
			randomized.StateName().Should().Be("Alaska");
		}

		[Test]
		public void Test_StateAbbreviation()
		{
			randomized.State().Should().Be("AK");
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

