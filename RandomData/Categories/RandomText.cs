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

		public string Alphanumeric(int length = 16, Case caseOptions = Case.Upper)
		{
			var alphanumeric = AlphanumericString(length);
			if (caseOptions == Case.Lower)
			{
				alphanumeric = alphanumeric.ToLower();
			}
			return alphanumeric;
		}

		public string Numeric(int length = 8)
		{
			return NumericString(length);
		}

		public string Alpha(int length = 8, Case caseOptions = Case.Upper)
		{
			var alpha = AlphaString(length);
			if (caseOptions == Case.Lower)
			{
				alpha = alpha.ToLower();
			}
			return alpha;
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

		public string Paragraphs(int count = 2)
		{
			var paragraphs = new StringBuilder();
			var breaks = "";

			for (int i = 0; i < count; i++)
			{
				paragraphs
					.Append(breaks)
					.Append(Sentences(4));

				// two lines between each each paragraph
				breaks = Environment.NewLine + Environment.NewLine;
			}

			return paragraphs.ToString();
		}
	}

	public enum Case
	{
		Upper,
		Lower
	}
}
