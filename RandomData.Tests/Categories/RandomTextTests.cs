using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomTextTests
	{
		private RandomText randomized;

		[SetUp]
		public void SetUp()
		{
			randomized = new RandomText(new FakeRandom());
		}

		[Test]
		public void Test_Sentences()
		{
			randomized.Sentences().Should().NotBeNull();
		}
	}
}

