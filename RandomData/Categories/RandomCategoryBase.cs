using System;

namespace RandomData
{
	public abstract class RandomCategoryBase
	{
		protected int Seed 
		{ 
			get; set;
		}

		protected RandomCategoryBase() : this(new Random().Next())
		{
		}

		protected RandomCategoryBase(int seed)
		{
			Seed = seed;
		}
	}
}