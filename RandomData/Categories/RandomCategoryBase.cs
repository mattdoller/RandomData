using System;

namespace RandomData.Categories
{
	public abstract class RandomCategoryBase
	{
		private readonly Random _random;

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