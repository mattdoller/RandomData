using System;
using System.Text;
using RandomData.Generators;

namespace RandomData.Categories
{
	public abstract class RandomCategoryBase
	{
		private readonly IRandomGenerator _random;

		protected RandomCategoryBase(IRandomGenerator random)
		{
			_random = random;
		}

		protected IRandomGenerator NewRandom()
		{
			return _random;
		}

		protected string NumericString(int length)
		{
			if (length <= 0)
			{
				throw new ArgumentException("length must be greater than 0");
			}

			StringBuilder numeric = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				numeric.Append(NewRandom().Next(0, 9));
			}
			return numeric.ToString();
		}
	}
}