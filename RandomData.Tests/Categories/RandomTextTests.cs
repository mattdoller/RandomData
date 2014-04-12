using System;
using System.Text.RegularExpressions;
using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;
using RandomData.Generators;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomTextTests
	{
		private RandomText randomized;

		[SetUp]
		public void SetUp()
		{
			randomized = new RandomText(new SystemRandom());
		}

		[Test]
		public void Test_Alphanumeric_Case()
		{
			var alphanumeric = randomized.Alphanumeric(20);
			alphanumeric.Should().Be(alphanumeric.ToUpper());

			alphanumeric = randomized.Alphanumeric(20, Case.Upper);
			alphanumeric.Should().Be(alphanumeric.ToUpper());

			alphanumeric = randomized.Alphanumeric(20, Case.Lower);
			alphanumeric.Should().Be(alphanumeric.ToLower());
		}

		[Test]
		public void Test_Alpha_Case()
		{
			var alpha = randomized.Alpha(20);
			alpha.Should().Be(alpha.ToUpper());

			alpha = randomized.Alpha(20, Case.Upper);
			alpha.Should().Be(alpha.ToUpper());

			alpha = randomized.Alpha(20, Case.Lower);
			alpha.Should().Be(alpha.ToLower());
		}

		[Test]
		public void Test_Sentences()
		{
			randomized.Sentences().Should().NotBeNull();
		}

		[Test]
		public void Test_Single_Paragraph()
		{
			var breaks = Environment.NewLine + Environment.NewLine;
			var paragraph = randomized.Paragraphs(1);
			paragraph.Should().NotContain(breaks);
		}

		[Test]
		public void Test_Paragraph_Breaks()
		{
			var breaks = Environment.NewLine + Environment.NewLine;
			var paragraphs = randomized.Paragraphs(5);
			var count = new Regex(Regex.Escape(breaks)).Matches(paragraphs).Count;

			// five paragraphs should have four breaks in between them
			count.Should().Be(4);
		}

		[Test]
		public void Test_Random_Strings_Are_Correct_Lengths()
		{
			const int expected = 50;
			randomized.Numeric(expected).Should().HaveLength(expected);
			randomized.Alpha(expected).Should().HaveLength(expected);
			randomized.Alphanumeric(expected).Should().HaveLength(expected);
		}

		[Test]
		public void Test_Output_Matches_Regex()
		{
			randomized = new RandomText(new SystemRandom());

			randomized.Numeric(20).Should().MatchRegex(@"\d{20}");
			randomized.Alpha(20).Should().MatchRegex(@"[A-Z]{20}");
			randomized.Alphanumeric(20).Should().MatchRegex(@"\w{20}");

			randomized.Alpha(20, Case.Lower).Should().MatchRegex(@"[a-z]{20}");
			randomized.Alphanumeric(20, Case.Lower).Should().MatchRegex(@"\w{20}");

			randomized.Alpha(20, Case.Upper).Should().MatchRegex(@"[A-Z]{20}");
			randomized.Alphanumeric(20, Case.Upper).Should().MatchRegex(@"\w{20}");
		}
	}
}

