using System;
using System.Text;
using RandomData.Extensions;
using RandomData.Generators;
using RandomData.Resources;

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

		public string Sentences(int count = 2)
		{
			if (count <= 0)
			{
				throw new ArgumentException("count must be greater than 0");
			}

			var sentences = new StringBuilder();
			string separator = "";

			for (int i = 0; i < count; i++)
			{
				var sentence = NewRandom().PickFrom(Strings.Sentences.SplitResource());

				sentences
					.Append(separator)
					.Append(sentence);

				separator = " ";
			}

			return sentences.ToString();
		}
	}
}
