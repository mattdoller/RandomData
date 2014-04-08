using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomContactTests
	{
		private RandomContact randomized;

		[SetUp]
		public void SetUp()
		{
			randomized = new RandomContact(new FakeRandom());
		}
		
		[Test]
		public void Test_Phone()
		{
			randomized.Phone().Should().Be("(123) 584-3718");
		}

		[Test]
		public void Test_InternationalPhone()
		{
			randomized.InternationalPhone().Should().Be("+12 35 8437 1808");
		}

		[Test]
		public void Test_Email()
		{
			randomized.Email().Should().Be("bandrews@example.edu");
		}
	}
}
