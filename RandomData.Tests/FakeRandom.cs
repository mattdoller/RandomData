using RandomData.Generators;

namespace RandomData.Tests
{
	public class FakeRandom : IRandomGenerator
	{
		private static readonly int[] Values = new[] {1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233};

		private const int GREATER_THAN_MAX = 234;

		private int Seed
		{
			get; set;
		}

		public FakeRandom(int seed = 0)
		{
			Seed = seed % Values.Length;
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
			if (Seed >= Values.Length)
			{
				Seed = 0;
			}
			return Values[Seed++];
		}
	}
}