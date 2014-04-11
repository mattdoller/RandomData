using System;
using System.Linq;
using System.Text;
using RandomData.Generators;

namespace RandomData.Categories
{
	public abstract class RandomCategoryBase
	{
		private const string ALPHA = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		private const string NUMERIC = "0123456789";
		private const string ALPHANUMERIC = ALPHA + NUMERIC;

		private readonly IRandomGenerator _random;

		protected RandomCategoryBase(IRandomGenerator random)
		{
			_random = random;
		}

		protected IRandomGenerator NewRandom()
		{
			return _random;
		}

		protected char RandomAlphaCharacter()
		{
			return RandomString(1, ALPHA.ToCharArray()).First();
		}

		protected char RandomNumericCharacter()
		{
			return RandomString(1, NUMERIC.ToCharArray()).First();
		}

		protected char RandomAlphanumericCharacter()
		{
			return RandomString(1, ALPHANUMERIC.ToCharArray()).First();
		}

		protected string NumericString(int length)
		{
			return RandomString(length, NUMERIC.ToCharArray());
		}

		protected string AlphaString(int length)
		{
			return RandomString(length, ALPHA.ToCharArray());
		}

		protected string AlphanumericString(int length)
		{
			return RandomString(length, ALPHANUMERIC.ToCharArray());
		}

		private string RandomString(int length, char[] candiates)
		{
			if (length <= 0)
			{
				throw new ArgumentException("length must be greater than 0");
			}

			StringBuilder randomString = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				var random = candiates[NewRandom().Next(candiates.Length)];
				randomString.Append(random);
			}
			return randomString.ToString();
		}
	}
}