using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomBoolean : RandomCategoryBase
	{
		public RandomBoolean(IRandomGenerator random) 
			: base(random)
		{
		}

		public bool Boolean()
		{
			return RandomBoolean();
		}
	}
}