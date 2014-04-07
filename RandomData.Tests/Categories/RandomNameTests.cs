using FluentAssertions;
using NUnit.Framework;
using RandomData.Categories;

namespace RandomData.Tests.Categories
{
	[TestFixture]
	public class RandomNameTests
	{
		private RandomName randomized;

		[SetUp]
		public void SetUp()
		{
			randomized = new RandomName(100);
		}

		[Test]
		public void Test_FirstName()
		{
			randomized.FirstName().Should().Be("Bob");
		}

		[Test]
		public void Test_FirstNameMale()
		{
			Assert.Fail();
		}

		[Test]
		public void Test_FirstNameFemale()
		{
			Assert.Fail();
		}

		[Test]
		public void Test_LastName()
		{
			Assert.Fail();
		}

		[Test]
		public void Test_FullName()
		{
			Assert.Fail();
		}

		[Test]
		public void Test_FullNameMale()
		{
			Assert.Fail();
		}

		[Test]
		public void Test_FullNameFemale()
		{
			Assert.Fail();
		}

		[Test]
		public void Test_Initial()
		{
			randomized.Initial().Should().Be("Y");
		}
	}
}

