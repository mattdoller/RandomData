using System;
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
			randomized.ZipCodePlusFour().Should().Be("12358-3145");
		}

		[Test]
		public void Test_PostalCode()
		{
			randomized.PostalCode().Should().Be("12358");
		}

		[TestCase(PostalCodeFormat.UnitedStatesZipCode, "12358")]
		[TestCase(PostalCodeFormat.UnitedStatesZipCodePlusFour, "12358-3145")]
		[TestCase(PostalCodeFormat.Canada, "B2D 5I3")]
		[TestCase(PostalCodeFormat.UnitedKingdom, "BCDF INV")]
		public void Test_PostalCode_With_Format(PostalCodeFormat format, string expected)
		{
			randomized.PostalCode(format).Should().Be(expected);
		}

		[Test]
		public void Test_PostalCode_With_Unrecognized_Format_Throws_Exception()
		{
			const PostalCodeFormat invalid = (PostalCodeFormat) (-1);
			Action action = () => randomized.PostalCode(invalid);
			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void Test_Output_Matches_Regex()
		{
			randomized = new RandomLocation(new SystemRandom());

			randomized.AddressLine1().Should().MatchRegex(@"\d{3} \w+ \w+.");
			randomized.AddressLine2().Should().MatchRegex(@"[A-Z][a-z]+. \d{3}");
			randomized.City().Should().MatchRegex(@"[A-Z][a-z]+");
			randomized.Country().Should().MatchRegex(@"[A-Z][a-z]+");
			randomized.PostalCode().Should().MatchRegex(@"\d{5}");
			randomized.PostalCode(PostalCodeFormat.Canada).Should().MatchRegex(@"[A-Z]\d[A-Z] \d[A-Z]\d");
			randomized.PostalCode(PostalCodeFormat.UnitedKingdom).Should().MatchRegex(@"\w{4} \w{3}");
			randomized.PostalCode(PostalCodeFormat.UnitedStatesZipCode).Should().MatchRegex(@"\d{5}");
			randomized.PostalCode(PostalCodeFormat.UnitedStatesZipCodePlusFour).Should().MatchRegex(@"\d{5}-\d{4}");
			randomized.State().Should().MatchRegex(@"[A-Z]{2}");
			randomized.StateName().Should().MatchRegex(@"[A-Z]+");
			randomized.ZipCode().Should().MatchRegex(@"\d{5}");
			randomized.ZipCodePlusFour().Should().MatchRegex(@"\d{5}-\d{4}"); ;
		}
	}
}

