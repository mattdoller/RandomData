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

		public DateTime Date(int range = 10)
		{
			var multiplier = RandomBoolean() ? 1 : -1;
			var difference = multiplier * NewRandom().Next(range);
			return DateTime.Now.AddDays(difference);
		}

		public DateTime DateBetween(DateTime lower, DateTime upper)
		{
			var days = (upper - lower).Days;
			return lower.AddDays(NewRandom().Next(days));
		}
	}
}

