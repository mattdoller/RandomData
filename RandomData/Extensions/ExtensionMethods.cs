using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomData.Generators;

namespace RandomData.Extensions
{
	internal static class ExtensionMethods
	{
		public static T PickFrom<T>(this IRandomGenerator random, T[] array)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}

			if (array.Length == 0)
			{
				throw new ArgumentException("array");
			}

			var index = random.Next(array.Length);
			return array[index];
		}

		public static string[] SplitResource(this string s)
		{
			return s.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
		}
	}
}

