using FluentAssertions;
using NUnit.Framework;

namespace RandomData.Tests
{
	[TestFixture]
	public class FakeRandomTests
	{
		private FakeRandom random;

		[SetUp]
		public void SetUp()
		{
			random = new FakeRandom();
		}
	
		[Test]
		public void Test_Next_Values_Loop()
		{
			random.Next().Should().Be(1);
			random.Next().Should().Be(2);
			random.Next().Should().Be(3);
			random.Next().Should().Be(5);
			random.Next().Should().Be(8);
			random.Next().Should().Be(13);
			random.Next().Should().Be(21);
			random.Next().Should().Be(34);
			random.Next().Should().Be(55);
			random.Next().Should().Be(89);
			random.Next().Should().Be(144);
			random.Next().Should().Be(233);
			random.Next().Should().Be(1);
			random.Next().Should().Be(2);
		}

		[Test]
		public void Test_Next_With_MaxValue_Mods_Returned_Value()
		{
			random.Next(20).Should().Be(1);
			random.Next(20).Should().Be(2);
			random.Next(20).Should().Be(3);
			random.Next(20).Should().Be(5);
			random.Next(20).Should().Be(8);
			random.Next(20).Should().Be(13);
			random.Next(20).Should().Be(1);
			random.Next(20).Should().Be(14);

			// change up the max value - the results should be modded correctly
			random.Next(50).Should().Be(5);
			random.Next(100).Should().Be(89);
			random.Next(100).Should().Be(44);
			random.Next(5).Should().Be(3);
			random.Next(20).Should().Be(1);
			random.Next(20).Should().Be(2);
		}

		[Test]
		public void Test_Next_With_MinValue_And_MaxValue_Adds_Min_Value_To_Result()
		{
			random.Next(10, 100).Should().Be(11);
			random.Next(10, 100).Should().Be(12);
			random.Next(10, 100).Should().Be(13);
			random.Next(10, 100).Should().Be(15);
			random.Next(10, 100).Should().Be(18);
			random.Next(10, 100).Should().Be(23);
			random.Next(10, 100).Should().Be(31);
			random.Next(10, 100).Should().Be(44);
			random.Next(10, 100).Should().Be(65);
			random.Next(10, 100).Should().Be(99);
			random.Next(10, 100).Should().Be(54);
			random.Next(10, 100).Should().Be(43);
			random.Next(10, 100).Should().Be(11);
			random.Next(10, 100).Should().Be(12);
		}
	}
}