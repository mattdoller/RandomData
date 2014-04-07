using System;

namespace RandomData
{
	public abstract class RandomCategoryBase
	{
		private Random _random;

		protected int Seed 
		{ 
			get; set;
		}

		protected RandomCategoryBase(int seed)
		{
			_random = new Random(seed);
		}

		protected RandomCategoryBase()
			: this(new Random().Next())
		{
		}

		protected Random NewRandom()
		{
			return _random;
		}
	}
}