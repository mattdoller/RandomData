using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;
using RandomData.Generators;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomNameTests
	{
		private RandomName randomized;

		[SetUp]
		public void SetUp()
		{
			randomized = new RandomName(new FakeRandom());
		}

		[Test]
		public void Test_FirstName()
		{
			randomized.FirstName().Should().Be("Anthony");
		}

		[Test]
		public void Test_FirstNameMale()
		{
			randomized.FirstNameMale().Should().Be("Anthony");
		}

		[Test]
		public void Test_FirstNameFemale()
		{
			randomized.FirstNameFemale().Should().Be("Ann");
		}

		[Test]
		public void Test_LastName()
		{
			randomized.LastName().Should().Be("Anderson");
		}

		[Test]
		public void Test_FullName()
		{
			randomized.FullName().Should().Be("Arthur Anthony");
			randomized.FullName(NameType.FirstMiddleInitialLast).Should().Be("Donald N. Jeffries");
			randomized.FullName(NameType.FirstMiddleLast).Should().Be("John Hugh Peters");
		}

		[Test]
		public void Test_FullNameMale()
		{
			randomized.FullNameMale().Should().Be("Anthony Andrews");
			randomized.FullNameMale(NameType.FirstMiddleInitialLast).Should().Be("Brian F. Clarke");
			randomized.FullNameMale(NameType.FirstMiddleLast).Should().Be("Harold Kevin Moore");
		}

		[Test]
		public void Test_FullNameFemale()
		{
			randomized.FullNameFemale().Should().Be("Ann Andrews");
			randomized.FullNameFemale(NameType.FirstMiddleInitialLast).Should().Be("Anne F. Clarke");
			randomized.FullNameFemale(NameType.FirstMiddleLast).Should().Be("Dorothy Jessica Moore");
		}

		[Test]
		public void Test_Initial()
		{
			randomized.Initial().Should().Be("B");
		}

		[Test]
		public void Test_CompanyName()
		{
			randomized.CompanyName().Should().Be("Anderson and Andrews Consulting, LLP");
			randomized.CompanyName(1).Should().Be("Clarke Industries, LLP");
			randomized.CompanyName(2).Should().Be("Moore and Anderson Publishing, LLC");
			randomized.CompanyName(3).Should().Be("Hall, Anderson, and Andrews Consulting, LLP");
		}

		[Test]
		public void Test_Output_Matches_Regex()
		{
			randomized = new RandomName(new SystemRandom());

			randomized.FirstName().Should().MatchRegex(@"[A-Z][a-z]+");
			randomized.FirstNameMale().Should().MatchRegex(@"[A-Z][a-z]+");
			randomized.FirstNameFemale().Should().MatchRegex(@"[A-Z][a-z]+");
			randomized.LastName().Should().MatchRegex(@"[A-Z][a-z]+");
			randomized.FullName().Should().MatchRegex(@"[A-Z][a-z]+ [A-Z][a-z]+");
			randomized.FullNameMale().Should().MatchRegex(@"[A-Z][a-z]+ [A-Z][a-z]+");
			randomized.FullNameFemale().Should().MatchRegex(@"[A-Z][a-z]+ [A-Z][a-z]+");
			randomized.Initial().Should().MatchRegex(@"[A-Z]{1}");
			randomized.CompanyName().Should().MatchRegex(@"\w+ and \w+ \w+, \w+");
			randomized.CompanyName(1).Should().MatchRegex(@"\w+ \w+, \w+");
			randomized.CompanyName(2).Should().MatchRegex(@"\w+ and \w+ \w+, \w+");
			randomized.CompanyName(3).Should().MatchRegex(@"\w+, \w+, and \w+ \w+, \w+");
		}
	}
}

