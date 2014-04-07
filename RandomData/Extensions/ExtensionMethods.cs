using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RandomData.Generators;

namespace RandomData.Extensions
{
	public static class ExtensionMethods
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

		public static void Each<T>(this IEnumerable<T> sequence, Action<T> action)
		{
			foreach (var item in sequence)
			{
				action(item);
			}
		}

		public static StringBuilder AppendAll(this StringBuilder stringBuilder, params string[] strings)
		{
			foreach (var item in strings)
			{
				stringBuilder.Append(item);
			}
			return stringBuilder;
		}

		public static IEnumerable<char> To(this char start, char end)
		{
			if (end <= start)
			{
				throw new ArgumentException("end must be greater than start");
			}

			while (start <= end)
			{
				yield return start;
				start++;
			}
		}

		public static string[] SplitResource(this string s)
		{
			return s.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
		}
	}
}

