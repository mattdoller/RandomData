using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests
{
	[TestFixture]
	public class RandomizedTests
	{
		[Test]
		public void Test_Randomized_Output_Matches_Regex()
		{
			Randomized.Contacts.Email().Should().MatchRegex(@"[a-z]+@[a-z]+.[a-z]+");
			Randomized.Contacts.Phone().Should().MatchRegex(@"\(\d{3}\) \d{3}-\d{4}");
			Randomized.Contacts.InternationalPhone().Should().MatchRegex(@"\+\d{2} \d{2} \d{4} \d{4}");
			Randomized.Locations.AddressLine1().Should().MatchRegex(@"\d{3} \w+ \w+.");
			Randomized.Locations.AddressLine2().Should().MatchRegex(@"[A-Z][a-z]+. \d{3}");
			Randomized.Locations.City().Should().MatchRegex(@"[A-Z][a-z]+");
			Randomized.Locations.Country().Should().MatchRegex(@"[A-Z][a-z]+");
			Randomized.Locations.PostalCode().Should().MatchRegex(@"\d{5}");
			Randomized.Locations.PostalCode(PostalCodeFormat.Canada).Should().MatchRegex(@"[A-Z]\d[A-Z] \d[A-Z]\d");
			Randomized.Locations.PostalCode(PostalCodeFormat.UnitedKingdom).Should().MatchRegex(@"\w{4} \w{3}");
			Randomized.Locations.PostalCode(PostalCodeFormat.UnitedStatesZipCode).Should().MatchRegex(@"\d{5}");
			Randomized.Locations.PostalCode(PostalCodeFormat.UnitedStatesZipCodePlusFour).Should().MatchRegex(@"\d{5}-\d{4}");
			Randomized.Locations.State().Should().MatchRegex(@"[A-Z]{2}");
			Randomized.Locations.StateName().Should().MatchRegex(@"[A-Z]+");
			Randomized.Locations.ZipCode().Should().MatchRegex(@"\d{5}");
			Randomized.Locations.ZipCodePlusFour().Should().MatchRegex(@"\d{5}-\d{4}"); ;
			Randomized.Names.FirstName().Should().MatchRegex(@"[A-Z][a-z]+");
			Randomized.Names.FirstNameMale().Should().MatchRegex(@"[A-Z][a-z]+");
			Randomized.Names.FirstNameFemale().Should().MatchRegex(@"[A-Z][a-z]+");
			Randomized.Names.LastName().Should().MatchRegex(@"[A-Z][a-z]+");
			Randomized.Names.FullName().Should().MatchRegex(@"[A-Z][a-z]+ [A-Z][a-z]+");
			Randomized.Names.FullNameMale().Should().MatchRegex(@"[A-Z][a-z]+ [A-Z][a-z]+");
			Randomized.Names.FullNameFemale().Should().MatchRegex(@"[A-Z][a-z]+ [A-Z][a-z]+");
			Randomized.Names.Initial().Should().MatchRegex(@"[A-Z]{1}");
			Randomized.Net.IPv4().Should().MatchRegex(@"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}");
			Randomized.Net.Url().Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}");
			Randomized.Net.Url(UrlType.DomainOnly).Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}");
			Randomized.Net.Url(UrlType.DomainAndPath).Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}\/[a-z]{6}");
			Randomized.Net.Url(UrlType.DomainPathAndPage).Should().MatchRegex(@"http:\/\/www.example.[a-z]{3}\/[a-z]{6}\/[a-z]{6}.html");
			Randomized.Text.Numeric(20).Should().MatchRegex(@"\d{20}");
			Randomized.Text.Alpha(20).Should().MatchRegex(@"[A-Z]{20}");
			Randomized.Text.Alphanumeric(20).Should().MatchRegex(@"\w{20}");
		}
	}
}