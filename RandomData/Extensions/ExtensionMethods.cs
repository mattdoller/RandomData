using System;
using System.Collections.Generic;
using System.Text;

namespace RandomData
{
	public static class ExtensionMethods
	{
		public static T PickFrom<T>(this Random random, T[] array)
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
	}
}

