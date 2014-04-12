using System;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;
using RandomData.Generators;

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
		public void Test_IPv6()
		{
			randomizer.IPv6().Should().Be("1235:8D52:7909:1235:8D52:7909:1235:8D52");
		}

		[Test]
		public void Test_Url_With_Invalid_UrlType_Throws_Exception()
		{
			const UrlType urlType = (UrlType) (-1);
			Action action = () => randomizer.Url(urlType);
			action.ShouldThrow<ArgumentException>();
		}

		[Test]
		public void Test_Output_Matches_Regex()
		{
			var ipv4 = String.Join(@"\.", Enumerable.Repeat(@"\d{1,3}", 4));
			var ipv6 = String.Join(":", Enumerable.Repeat(@"[A-Z0-9]{4}", 8));
	
			randomizer = new RandomNet(new SystemRandom());
			randomizer.IPv4().Should().MatchRegex(ipv4);
			randomizer.IPv6().Should().MatchRegex(ipv6);
			randomizer.Url().Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}");
			randomizer.Url(UrlType.DomainOnly).Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}");
			randomizer.Url(UrlType.DomainAndPath).Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}\/[a-z]{6}");
			randomizer.Url(UrlType.DomainPathAndPage).Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}\/[a-z]{6}\/[a-z]{6}.html");
		}
	}
}

