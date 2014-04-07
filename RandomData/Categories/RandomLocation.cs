using System;
using RandomData.Data;
using RandomData.Generators;

namespace RandomData.Categories
{
	public class RandomLocation : RandomCategoryBase
	{
		public RandomLocation(IRandomGenerator random) 
			: base(random)
		{
		}

		public string AddressLine1()
		{
			throw new NotImplementedException();
		}

		public string AddressLine2()
		{
			throw new NotImplementedException();
		}

		public string City()
		{
			throw new NotImplementedException();
		}

		public string ZipCode()
		{
			return NumericString(5);
		}

		public string ZipCodePlusFour()
		{
			return String.Format("{0}-{1}", ZipCode(), NumericString(4));
		}

		public string State()
		{
			throw new NotImplementedException();
		}

		public string StateName()
		{
			throw new NotImplementedException();
		}

		public string Country()
		{
			throw new NotImplementedException();
		}
	}
}

