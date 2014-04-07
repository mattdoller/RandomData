using System;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomNet : RandomCategoryBase
	{
		public RandomNet(IRandomGenerator random) 
			: base(random)
		{
		}

		public string IPv4()
		{
			return String.Format("{0}.{1}.{2}.{3}",
	      NewRandom().Next(255),
	      NewRandom().Next(255),
	      NewRandom().Next(255),
	      NewRandom().Next(255)
			);
		}

		public string Url()
		{
			throw new NotImplementedException();
		}
	}
}

