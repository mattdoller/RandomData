using System;

namespace RandomData
{
	public abstract class RandomCategoryBase
	{
		protected int Seed 
		{ 
			get; set;
		}

		protected RandomCategoryBase(int seed)
		{
			Seed = seed;
		}

		protected RandomCategoryBase()
			: this(new Random().Next())
		{
		}

		protected Random NewRandom()
		{
			return new Random(Seed);
		}
	}
}