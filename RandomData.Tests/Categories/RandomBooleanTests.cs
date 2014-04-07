using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomBooleanTests
	{
		private RandomBoolean randomized;

		[SetUp]
		public void SetUp()
		{
			randomized = new RandomBoolean(new FakeRandom());
		}

		[Test]
		public void Test_Random_Output()
		{
			randomized.Boolean().Should().Be(false);
			randomized.Boolean().Should().Be(true);
			randomized.Boolean().Should().Be(false);
		}
	}
}
