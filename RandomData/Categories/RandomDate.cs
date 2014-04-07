using System;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomDate : RandomCategoryBase
	{
		public RandomDate(IRandomGenerator random) 
			: base(random)
		{
		}

		public DateTime DateBetween(DateTime lower, DateTime upper)
		{
			var days = (upper - lower).Days;
			throw new NotImplementedException();
		}
	}
}

