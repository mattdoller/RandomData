using System;

namespace RandomData
{
	public class RandomDate : RandomCategoryBase
	{
		public RandomDate(int seed)
			: base(seed)
		{
		}

		public DateTime DateBetween(DateTime lower, DateTime upper)
		{
			var days = (upper - lower).Days;
			return lower.AddDays(NewRandom().NextDouble() * days);
		}
	}
}

