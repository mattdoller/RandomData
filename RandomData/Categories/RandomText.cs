using System;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomText : RandomCategoryBase
	{
		public RandomText(IRandomGenerator random) 
			: base(random)
		{
		}

		public string Alphanumeric(int length = 16)
		{
			throw new NotImplementedException();
		}

		public string Paragraphs(int count = 2)
		{
			throw new NotImplementedException();
		}
	}
}
