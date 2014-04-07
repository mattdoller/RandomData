namespace RandomData.Categories
{
	public class RandomBoolean : RandomCategoryBase
	{
		public RandomBoolean(int seed)
			: base(seed)
		{
		}

		public bool Boolean()
		{
			return NewRandom().Next() % 2 == 0;
		}
	}
}

