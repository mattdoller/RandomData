using System;
using System.Threading;

namespace RandomData.Generators
{
	public class SystemRandom : IRandomGenerator
	{
		private readonly Random _random;

		public SystemRandom()
		{
			_random = RandomHelper.Instance;
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

		private static class RandomHelper
		{
			private static int seedCounter = new Random().Next();

			[ThreadStatic] 
			private static Random random;

			public static Random Instance
			{
				get
				{
					if (random == null)
					{
						int seed = Interlocked.Increment(ref seedCounter);
						random = new Random(seed);
					}
					return random;
				}
			}
		}
	}
}