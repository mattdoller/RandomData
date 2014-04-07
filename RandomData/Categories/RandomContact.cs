using System;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomContact : RandomCategoryBase
	{
		public RandomContact(IRandomGenerator random) 
			: base(random)
		{
		}

		public string Phone()
		{
			throw new NotImplementedException();
		}

		public string InternationalPhone()
		{
			throw new NotImplementedException();
		}

		public string Email()
		{
			throw new NotImplementedException();
		}
	}
}

