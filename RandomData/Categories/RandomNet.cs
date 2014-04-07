using System;

namespace RandomData.Categories
{
	public class RandomNet : RandomCategoryBase
	{
		public RandomNet()
		{
		}

		public RandomNet(int seed)
			: base(seed)
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

