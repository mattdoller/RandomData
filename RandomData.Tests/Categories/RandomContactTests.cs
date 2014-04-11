using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;
using RandomData.Generators;

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
			randomized.Phone().Should().Be("(123) 583-1459");
		}

		[Test]
		public void Test_InternationalPhone()
		{
			randomized.InternationalPhone().Should().Be("+12 35 8314 5943");
		}

		[Test]
		public void Test_Email()
		{
			randomized.Email().Should().Be("bandrews@example.edu");
		}

		[Test]
		public void Test_Output_Matches_Regex()
		{
			randomized = new RandomContact(new SystemRandom());

			randomized.Email().Should().MatchRegex(@"[a-z]+@[a-z]+.[a-z]+");
			randomized.Phone().Should().MatchRegex(@"\(\d{3}\) \d{3}-\d{4}");
			randomized.InternationalPhone().Should().MatchRegex(@"\+\d{2} \d{2} \d{4} \d{4}");
		}
	}
}
