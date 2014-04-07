using System;

namespace RandomData.Generators
{
	public class SystemRandom : IRandomGenerator
	{
		private readonly Random _random;

		public SystemRandom()
		{
			_random = new Random();
		}

		public int Next()
		{
			return _random.Next();
		}

		public int Next(int maxValue)
		{
			return _random.Next(maxValue);
		}

		public int Next(int minValue, int maxValue)
		{
			return _random.Next(minValue, maxValue);
		}
	}
}