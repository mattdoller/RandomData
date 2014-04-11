using System;
using RandomData.Categories;
using RandomData.Generators;

namespace RandomData
{
	public static class Randomized
	{
		private static readonly Lazy<IRandomGenerator> _randomGenerator	= 
			new Lazy<IRandomGenerator>(() => new SystemRandom());

		private static readonly Lazy<RandomBoolean> _booleans =
			new Lazy<RandomBoolean>(() => new RandomBoolean(_randomGenerator.Value));

		private static readonly Lazy<RandomContact> _contacts =
			new Lazy<RandomContact>(() => new RandomContact(_randomGenerator.Value));

		private static readonly Lazy<RandomDate> _dates =
			new Lazy<RandomDate>(() => new RandomDate(_randomGenerator.Value));

		private static readonly Lazy<RandomLocation> _locations =
			new Lazy<RandomLocation>(() => new RandomLocation(_randomGenerator.Value));

		private static readonly Lazy<RandomName> _names =
			new Lazy<RandomName>(() => new RandomName(_randomGenerator.Value));

		private static readonly Lazy<RandomNet> _net =
			new Lazy<RandomNet>(() => new RandomNet(_randomGenerator.Value));

		private static readonly Lazy<RandomText> _text =
			new Lazy<RandomText>(() => new RandomText(_randomGenerator.Value));

		public static RandomBoolean Booleans 
		{
			get { return _booleans.Value; }
		}

		public static RandomContact Contacts
		{
			get { return _contacts.Value; }
		}

		public static RandomDate Dates
		{
			get { return _dates.Value; }
		}

		public static RandomLocation Locations
		{
			get { return _locations.Value; }
		}

		public static RandomName Names
		{
			get { return _names.Value; }
		}

		public static RandomNet Net
		{
			get { return _net.Value; }
		}

		public static RandomText Text
		{
			get { return _text.Value; }
		}
	}
}
