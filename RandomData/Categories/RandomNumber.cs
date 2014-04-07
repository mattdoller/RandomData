using System;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomNumber : RandomCategoryBase
	{
		public RandomNumber(IRandomGenerator random) 
			: base(random)
		{
		}

		public int IntBetween(int lower, int upper)
		{
			throw new NotImplementedException();
		}

		public long LongBetween(long lower, long upper)
		{
			throw new NotImplementedException();
		}

		public double DoubleBetween(double lower, double upper)
		{
			throw new NotImplementedException();
		}

		public decimal DecimalBetween(decimal lower, decimal upper)
		{
			throw new NotImplementedException();
		}
	}
}

