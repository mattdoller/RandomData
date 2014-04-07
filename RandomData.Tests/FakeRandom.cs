using RandomData.Generators;

namespace RandomData.Tests
{
	public class FakeRandom : IRandomGenerator
	{
		private static readonly int[] Values = new[] {1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233};

		private const int GREATER_THAN_MAX = 234;

		private int CurrentIndex
		{
			get; set;
		}

		public FakeRandom()
		{
			CurrentIndex = 0;
		}

		public int Next()
		{
			return Next(0, GREATER_THAN_MAX);
		}

		public int Next(int maxValue)
		{
			return Next(0, maxValue);
		}

		public int Next(int minValue, int maxValue)
		{
			return (NextValue() + minValue) % maxValue;
		}

		private int NextValue()
		{
			if (CurrentIndex >= Values.Length)
			{
				CurrentIndex = 0;
			}
			return Values[CurrentIndex++];
		}
	}
}