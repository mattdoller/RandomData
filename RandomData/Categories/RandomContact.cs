using System;
using System.Linq;
using RandomData.Extensions;
using RandomData.Generators;
using RandomData.Resources;

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
			return String.Format("({0}) {1}-{2}", 
				NumericString(3),
				NumericString(3),
				NumericString(4)
			);
		}

		public string InternationalPhone()
		{
			return String.Format("+{0} {1} {2} {3}",
				NumericString(2),
				NumericString(2),
				NumericString(4),
				NumericString(4)
			);
		}

		public string Email()
		{
			var initial = RandomAlphaCharacter();
			var lastName = NewRandom().PickFrom(Strings.LastNames.SplitResource());
			var domain = NewRandom().PickFrom(Strings.Domains.SplitResource());

			return String.Format("{0}{1}@{2}", 
				initial,
				lastName,
				domain
			).ToLower();
		}
	}
}

